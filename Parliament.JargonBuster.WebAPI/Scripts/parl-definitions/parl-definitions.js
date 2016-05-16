function ParlJargonBuster(options) {

    var _options = options;
    var _defaultOptions =
    {
        wordFrequency: 3,
        contentSelectors: [],
        enabled: true,
        project: "default",
        onSuccess: null
    };

	function build() {
	    _options = $.extend({}, _defaultOptions, _options);

	    var content = "";
	    $(_options.contentSelectors).each(function (contentSelectorIndex, contentSelector) {
	        var $contentSelector = $(contentSelector).clone();
	        $contentSelector.find("script, link, iframe").remove();
            if ($contentSelector.length !== 0) {
                content += $contentSelector.text();
                content = content.replace(/\s+/g, " ");
            }   
        });

        getPhrases(content);
	 }

 	function initPopovers() {
 	    var options = {
 	        placement: "vertical",
 	        type: "html",
 	        trigger: "hover", //and for mobile?
 	        width: 500
 	    }
        
 	    var $popovers = $('[data-toggle="popover"]');         
 	    $popovers.webuiPopover(options);
	    $popovers.removeClass("disabled");
	    $popovers.click(function (e) { e.preventDefault(); });
	    $popovers.focusin(function () {
	         $(this).webuiPopover('show');
	    });
	    $popovers.focusout(function () {
	        $(this).webuiPopover('hide');
	    });
	 }

    function getPhrases(content)
 	{
        $.ajax({
            cache: false,
            type: "POST",
            url: _options.webApiUrl + "/api/definitions",
            data: JSON.stringify({
                PageContent: content,
                PageUrl: window.location.href,
                ProjectName: _options.project
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                resultsContainer = result;
                $(result.Phrases).each(applyPopoverAnchors);
                initPopovers();
                if (_options.onSuccess != null) _options.onSuccess(result);
            },
            error: function () {
                //TODO - useful error handling
            }
        });
    }

    function applyPopoverAnchors(index, jargonItem) {
        $(_options.contentSelectors).each(function(contentSelectorIndex, contentSelector) {
            var phrasedElements = getNodesThatContain(jargonItem, contentSelector);
            phrasedElements.each(function (phrasedElementIndex, phrasedElementItem) {
                var phrases = jargonItem.Alternates.slice(0);
                phrases.push(jargonItem.Phrase);
                if (phrasedElementIndex % _options.wordFrequency === 0) {
                    $(phrases).each(function (phraseIndex, phraseItem) {
                        applyPopoverAnchor(jargonItem, phraseItem, phrasedElementItem, index + "_" + contentSelectorIndex + "_" + phrasedElementIndex + "_" + phraseIndex);
                    });
                }
            });
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

    function getNodesThatContain(jargonItem, contentSelector) {
        var phrasesToLookFor = jargonItem.Alternates.slice(0);
        phrasesToLookFor.push(jargonItem.Phrase);

        var textNodes = $(contentSelector).find(":not(title, iframe, script, a, :header, div.definition-content-container)").contents().filter(
            function () {
                return isTextNode(this.nodeType) && isPhraseInText(this.textContent.toLowerCase(), phrasesToLookFor);
            });
       var nodes = $.grep(textNodes, function(node) {
           return $(node).parents("a").length <= 0 && $(node).parents("div.definition-content-container").length <= 0;
       });
       return $(nodes).parent();
    };

    function applyPopoverAnchor(jargonItem, phraseItem, element, uniqueId) {
        var $element = $(element);
        var elementContent = $element.html();

        var alreadyBuiltDefinitions = $element.find("a[class='definition']");
        var placeholders = [];
        if (alreadyBuiltDefinitions.length > 0) {
            alreadyBuiltDefinitions.each(function(i, element) {
                var placeholder = "{" + i + "}";
                var $element = $(element);
                var containerContent = $element.parent().find($element.attr("data-url"));
                if (containerContent.length > 0) {
                    var html = element.outerHTML + containerContent[0].outerHTML;
                    placeholders.push({
                        Placeholder: placeholder,
                        Html: html
                    });
                    elementContent = elementContent.replace(html, placeholder);
                }
            });
        }



        var textToReplace = new RegExp("\\b(" + phraseItem + ")\\b", 'i');

        var replacedContent = elementContent.replace(textToReplace, buildPopoverAnchor(jargonItem, "$1", phraseItem, uniqueId));

        $(placeholders).each(function (i, element) {
            replacedContent = replacedContent.replace(element.Placeholder, element.Html);
        });

        $element.html(replacedContent);
    }

    function buildPopoverAnchor(jargonItem, textToReplace, phraseItem, uniqueId) {
        var alternates = "";
        var alternativeTitle = "";
        if (jargonItem.DisplayAlternates) {
            alternativeTitle = "<div class='definition-alternates'><p class='definition-content-titles'>Alternatives: </p>";
            var alternativePhrasesUnaltered = jargonItem.Alternates.slice(0);
            var alternativePhrases = jargonItem.Alternates.slice(0).map(function (phrase) {
                return phrase.toLowerCase();
            });
            var indexOfPhrase = alternativePhrases.indexOf(phraseItem.toLowerCase());
            if (indexOfPhrase > -1) {
                alternativePhrasesUnaltered.splice(indexOfPhrase, 1);
                alternativePhrasesUnaltered.push(jargonItem.Phrase);
                alternates = "<p class='definition-actual-content'>" + alternativePhrasesUnaltered.join(", ").replace("'", "&apos;") + "</p></div>";
            } else {
                alternates = "<p class='definition-actual-content'>" + jargonItem.AlternatesContent.replace("'", "&apos;") + "</p></div>";
            }
        }

        var content = "<div class='definition-content'><b class='definition-content-titles'>Definition: </b><p class='definition-actual-content'>" + jargonItem.Definition + "</p></div>" + alternativeTitle + alternates;
        var phrase = jargonItem.Phrase.replace("'", "&apos;");
        
        return "<a class='definition' href='#' data-toggle='popover' aria-describedby='" + uniqueId + "' data-url='div[data-phrase=&quot;" + phrase + "&quot;]:first'>" + textToReplace.replace("'", "&apos;") + "</a><div class='definition-content-container' id='" + uniqueId + "' data-phrase='" + phrase + "'>" + content + "</div>";
    }
    
    function disablePopovers() {
        $('[data-toggle="popover"]').webuiPopover("destroy");
        $('[data-toggle="popover"]').each(function() {
            $(this).contents().unwrap();
        });
    }

    function toggleDefinitions(result, results) {
        _options.enabled = result;

        if (_options.enabled) {
            $(results.Phrases).each(applyPopoverAnchors);
            initPopovers();
        } else {
            disablePopovers();
        }
    }

    this.Build = build;
    this.InitPopovers = initPopovers;
    this.ToggleDefinitions = toggleDefinitions;
}