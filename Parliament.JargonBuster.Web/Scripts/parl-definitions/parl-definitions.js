$(document).ready(function() {
	var jargonBuster = new ParlJargonBuster();

    jargonBuster.Build(".main-content");
});


function ParlJargonBuster()
{
	var _contentSelector;

 	function build(contentSelector) {
 		_contentSelector = contentSelector;
 		var content = $(_contentSelector).text();

        getPhrases(content);
	 }

 	function initPopovers() {
 	    var options = {
 	        placement: optimalPopoverPlacement,
 	        html: "true",
 	        trigger: "hover" //and for mobile?
 	    }

 	    $('[data-toggle="tooltip"]').tooltip();
 	    $('[data-toggle="popover"]').popover(options);
 	}

 	function optimalPopoverPlacement(context, source) {
 	    var position = $(source).position();
 	    if ((window.innerHeight - position.top) < 100) {
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
            success: function (phrases) {
                $(phrases.jargonItems).each(applyPopoverAnchors);
                initPopovers();
            },
            error: function(result) {
                alert("an error occurred");
            }
        });
    }

    function applyPopoverAnchors(index, jargonItem)
    {
    	var phrasedElements = getNodesThatContain(jargonItem.phrase.toLowerCase());
    	phrasedElements.each(function(phrasedElementIndex, phrasedElementItem) {
    		applyPopoverAnchor(jargonItem, phrasedElementItem);
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
        var textToReplace = new RegExp("\\b(" + jargonItem.phrase + ")\\b", 'gi');
        //remove global flag to only highlight first instance?

        var replacedContent = elementContent.replace(textToReplace, buildPopoverAnchor(jargonItem, "$1"));
        $(element).html(replacedContent);
    }

    function buildPopoverAnchor(jargonItem, textToReplace) {
    	return "<a class='definition' href='#' data-toggle='popover' data-content='<div><b>Definition:</b> " + jargonItem.definition + "</div><div>Alternative: " + jargonItem.alternate + "</div>'>" + textToReplace + "</a>";
    }

    this.Build = build;
    this.InitPopovers = initPopovers;
}

        // TODO - Content length checking to not put a new jargon buster too close
        // TODO - Phrase containing another smaller phrase
        // TODO - Do not apply jargon busters to links or headers
        // TODO (optional) - Possible override of header?

