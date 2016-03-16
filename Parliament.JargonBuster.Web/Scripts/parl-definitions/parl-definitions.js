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
 	        placement: "vertical",
 	        type: "html",
 	        trigger: "click", //and for mobile?
 	        width: 500
 	    }

 	    $('[data-toggle="popover"]').webuiPopover(options);
 	    $('[data-toggle="popover"]').removeClass("disabled");
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
    	var phrasedElements = getNodesThatContain(jargonItem);
    	phrasedElements.each(function (phrasedElementIndex, phrasedElementItem) {
    	    var phrases = jargonItem.Alternates.slice(0);
	        phrases.push(jargonItem.Phrase);
    	    if (phrasedElementIndex % _options.wordFrequency === 0) {
	            $(phrases).each(function(phraseIndex, phraseItem) {
	                applyPopoverAnchor(jargonItem, phraseItem, phrasedElementItem);
	            });
                
            }
    	});
    }

    function isTextNode(nodeType) {
        return nodeType === 3;
    }

    function isPhraseInText(text, phrases) {
        text = text.trim();
        var phraseInText = false;
        var index = 0;
        if (text === "") return false;

        while (phraseInText === false && index < phrases.length) {
            if (text.indexOf(phrases[index].toLowerCase()) > -1) {
                phraseInText = true;
            }
            index += 1;
        }
        return phraseInText;
    }

    function getNodesThatContain(jargonItem) {
        var phrasesToLookFor = jargonItem.Alternates.slice(0);
        phrasesToLookFor.push(jargonItem.Phrase);
        var textNodes = $(document).find(":not(title, iframe, script, a, :header)").contents().filter(
            function () {
                return isTextNode(this.nodeType) && isPhraseInText(this.textContent.toLowerCase(), phrasesToLookFor);
            });
        return textNodes.parent();
    };

    function applyPopoverAnchor(jargonItem, phraseItem, element) {
        var elementContent = $(element).html();
        var textToReplace = new RegExp("\\b(" + phraseItem + ")\\b", 'i');

        var replacedContent = elementContent.replace(textToReplace, buildPopoverAnchor(jargonItem, "$1", phraseItem));
        $(element).html(replacedContent);
    }

    function buildPopoverAnchor(jargonItem, textToReplace, phraseItem) {
        var alternates = "";
        var alternativeTitle = "";
        if (jargonItem.DisplayAlternates) {
            alternativeTitle = "<div class=&quot;definition-alternates&quot;><p class=&quot;definition-content-titles&quot;>Alternative(s): </p>";
            var alternativePhrasesUnaltered = jargonItem.Alternates.slice(0);
            var alternativePhrases = jargonItem.Alternates.slice(0).map(function (phrase) {
                return phrase.toLowerCase();
            });
            var indexOfPhrase = alternativePhrases.indexOf(phraseItem.toLowerCase());
            if (indexOfPhrase > -1) {
                alternativePhrasesUnaltered.splice(indexOfPhrase, 1);
                alternativePhrasesUnaltered.push(jargonItem.Phrase);
                alternates = "<p class=&quot;definition-actual-content&quot;>" + alternativePhrasesUnaltered.join(", ") + "</p></div>";
            } else {
                alternates = "<p class=&quot;definition-actual-content&quot;>" + jargonItem.AlternatesContent + "</p></div>";
            }
        }

        var content = "'<div class=&quot;definition-content&quot;><b class=&quot;definition-content-titles&quot;>Definition: </b><p class=&quot;definition-actual-content&quot;>" + jargonItem.Definition + "</p></div>" + alternativeTitle + alternates + "'";
    	return "<a class='definition' href='#' data-toggle='popover' data-content=" + content + ">" + textToReplace + "</a>";
    }

    function disablePopovers() {
        $('[data-toggle="popover"]').webuiPopover("destroy");
        $('[data-toggle="popover"]').addClass("disabled");
    }

    function toggleDefinitions() {

        var result = $(this).attr("data-value") === "true";
        $(".parl-toggle-definitions-button.enabled").removeClass("enabled");
        $(this).addClass("enabled");

        _options.enabled = result;

        if (_options.enabled) {
            initPopovers();
        } else {
            disablePopovers();
        }
    }

    function bindToggleDefinitions(html) {
        var options = {
            placement: "vertical",
            type: "html",
            trigger: "click",
            onShow: bindEnableDisable,
            onHide: unbindEnableDisable
        }
        $(_options.definitionToggleSelector).attr("data-content", html);
        $(_options.definitionToggleSelector).webuiPopover(options);
    }

    function bindEnableDisable() {
        $(".parl-toggle-definitions-button").click(toggleDefinitions);
    }

    function unbindEnableDisable() {
        $(".parl-toggle-definitions-button").unbind("click");
    }

    this.Build = build;
    this.InitPopovers = initPopovers;
    this.ToggleDefinitions = toggleDefinitions;
}

        // TODO - Content length checking to not put a new jargon buster too close
        // TODO - Phrase containing another smaller phrase
        // TODO - Do not apply jargon busters to links or headers
        // TODO (optional) - Possible override of header?

