function ParlJargonBuster(options) {
    var _options = options;
    var _defaultOptions =
    {
        wordFrequency: 3,
        contentSelectors: [],
        enabled: true,
        definitionToggleSelector: ".parl-definitions"
    };

	function build() {
	    _options = $.extend({}, _defaultOptions, _options);

	    var content = "";
	    $(_options.contentSelectors).each(function (contentSelectorIndex, contentSelector) {
	        var $contentSelector = $(contentSelector);
            if ($contentSelector.length !== 0) {
                content += $contentSelector.text();
            }   
        });

        getPhrases(content);
	 }

 	function initPopovers() {
 	    var options = {
 	        placement: optimalPopoverPlacement,
 	        type: "html",
 	        trigger: "click", //and for mobile?
 	        width: 500
 	    }

 	    $('[data-toggle="popover"]').webuiPopover(options);
 	}

 	function optimalPopoverPlacement() {
	    var popover = this.$element;
 	    var position = $(popover).position().top - $(window).scrollTop();
 	    if ((window.innerHeight - position) < 100) {
 	        return "top";
 	    }
 	    return "bottom";
 	}

    function getPhrases(content)
 	{
        $.ajax({
            cache: false,
            type: "POST",
            url: "http://definitions.webapi.local.dev.parliament.uk/api/definitions",
            data: JSON.stringify({
                PageContent: content,
                PageUrl: window.location.href
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                $(result.Phrases).each(applyPopoverAnchors);
                initPopovers();
                bindToggleDefinitions(result.ToggleDefinitionHtml);
            },
            error: function(result) {
                alert("an error occurred");
            }
        });
    }

    function applyPopoverAnchors(index, jargonItem)
    {
    	var phrasedElements = getNodesThatContain(jargonItem.Phrase);
    	phrasedElements.each(function (phrasedElementIndex, phrasedElementItem) {
            if (phrasedElementIndex % _options.wordFrequency === 0) {
                applyPopoverAnchor(jargonItem, phrasedElementItem);
            }
    	});
    }

    function getNodesThatContain(text) {
        var textNodes = $(document).find(":not(title, iframe, script, a, :header)").contents().filter(
            function() {
                return this.nodeType == 3 && this.textContent.toLowerCase().indexOf(text) > -1;
            });
        return textNodes.parent();
    };

    function applyPopoverAnchor(jargonItem, element) {
    	var elementContent = $(element).html();
    	var textToReplace = new RegExp("\\b(" + jargonItem.Phrase + ")\\b", 'i');
    	var replacedContent = elementContent.replace(textToReplace, buildPopoverAnchor(jargonItem, "$1"));

        $(element).html(replacedContent);
    }

    function buildPopoverAnchor(jargonItem, textToReplace) {
        var alternates = "";
        var alternativeTitle = "";
        if (jargonItem.DisplayAlternates) {
            alternativeTitle = "<b>Alternative(s): </b>";
            alternates = jargonItem.Alternates;
        }

        var content = "'<div class=&quot;definition-content-titles&quot;><b>Definition: </b>" + alternativeTitle + "</div><div class=&quot;definition-actual-content&quot;><p>" + jargonItem.Definition + "</p><p>" + alternates + "</p></div>'";
    	return "<a class='definition' href='#' data-toggle='popover' data-content=" + content + ">" + textToReplace + "</a>";
    }

    function disablePopovers() {
        $('[data-toggle="popover"]').webuiPopover("destroy");
    }

    function toggleDefinitions() {
        _options.enabled = !_options.enabled;

        if (_options.enabled) {
            initPopovers();
        } else {
            disablePopovers();
        }
    }

    function bindToggleDefinitions(html) {
        var options = {
            placement: "bottom",
            type: "html",
            trigger: "click"
        }
        $(_options.definitionToggleSelector).attr("data-content", html);
        $(_options.definitionToggleSelector).webuiPopover(options);
    }

    this.Build = build;
    this.InitPopovers = initPopovers;
    this.ToggleDefinitions = toggleDefinitions;
}

        // TODO - Content length checking to not put a new jargon buster too close
        // TODO - Phrase containing another smaller phrase
        // TODO - Do not apply jargon busters to links or headers
        // TODO (optional) - Possible override of header?

