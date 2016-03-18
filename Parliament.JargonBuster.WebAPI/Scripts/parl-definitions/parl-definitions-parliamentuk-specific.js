$(document).ready(function () {
    var jargonBuster = new ParlJargonBusterParliamentUK();
    var options = {
         webApiUrl: $("#parl-definitions-url").val()
    };
    jargonBuster.Build(options);
});

function ParlJargonBusterParliamentUK(options) {
    var _options = options;
    var _defaultOptions = {
        wordFrequency: 3,
        contentSelectors: ["#content"],
        project: "parliament-uk-old",
        definitionToggleSelector: ".parl-definitions",
        onSuccess: onSuccessParliamentUK
    };
    var _jargonBuster;

    function build() {
        _options = $.extend({}, _defaultOptions, _options);
        _jargonBuster = new ParlJargonBuster(_options);

        addDefinitionsToggleLink();

        _jargonBuster.Build();
    }

    function onSuccessParliamentUK(results) {
        addRightHandModule(results);
        bindToggleDefinitions(results);
    }

    function getCustomModuleByName(customModules, name) {
        var customModule = $.grep(customModules, function (e) { return isCustomModuleNameEqualTo(name, e); });
        if (customModule.length <= 0) return null;
        return customModule[0];
    }

    /* Right Hand Module */
    function addRightHandModule(results) {
        var customModule = getCustomModuleByName(results.CustomModules, "definitions-right-module");
        if (customModule == null) return;

        $("#content #panel").prepend(customModule.ModuleHtml);
        $(".parl-definitions-close").click(hideRightModule);
        buildPopoverAnchorDemo();
        //TODO - Bind links for feedback form
    }

    function hideRightModule(e) {
        if (e != null) e.preventDefault();
        $(".parl-definitions-right-hand-module").hide();
    }

    function showRightModule() {
        $(".parl-definitions-right-hand-module").show();
    }

    //TODO - refactor the parl-definitions version of this so we can just create our own custom popup anchors
    function buildPopoverAnchorDemo() {
        var options = {
            placement: "vertical",
            type: "html",
            trigger: "click",
            width: 500
        }
        $(".definitions-example").webuiPopover(options);
        $(".definitions-example").click(function (e) { e.preventDefault(); });
    }

    /* Enable / Disable Definitions */
    function addDefinitionsToggleLink() {
        $("#navigation #level-1").append("<li class='parl-definitions-toggle-list'><a class='parl-definitions'>Definitions <img class='info-icon' src='http://definitions.webapi.local.dev.parliament.uk/Content/popover/question-icon-2.svg'></a></li>");

        //TODO - Could do an ajax request to get just the module content if the WebAPI hasn't either yet returned the page content (or if definitions is currently disabled)      
    }

    function isCustomModuleNameEqualTo(expectedName, customModule) {
        return customModule.ModuleName === expectedName;
    }

    function bindToggleDefinitions(results) {
        var customModule = getCustomModuleByName(results.CustomModules, "definitions-toggle");
        if (customModule == null) return;

        var options = {
            placement: "vertical",
            type: "html",
            trigger: "click",
            onShow: bindEnableDisable,
            onHide: unbindEnableDisable
        }
        $(_options.definitionToggleSelector).attr("data-content", customModule.ModuleHtml);
        $(_options.definitionToggleSelector).webuiPopover(options);
    }

    function bindEnableDisable() {
        $(".parl-toggle-definitions-button").click(function () {
            var enabled = $(this).attr("data-value") === "true";
            _jargonBuster.ToggleDefinitions(enabled);
            $(".parl-toggle-definitions-button.enabled").removeClass("enabled");
            $(this).addClass("enabled");
            if (!enabled) {
                hideRightModule();
            }
            else if (hasHiddenRightModuleAtLeastOnce()) {
                showRightModule();
            }
        });
    }

    function hasHiddenRightModuleAtLeastOnce() {
        return false; //TODO - Cookie this!
    }

    function unbindEnableDisable() {
        $(".parl-toggle-definitions-button").unbind("click");
    }

    this.Build = build;

}