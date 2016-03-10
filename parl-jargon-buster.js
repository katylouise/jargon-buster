$(document).ready(function() {
	var jargonBuster = new ParlJargonBuster();

    jargonBuster.Build(".main-content");
    initPopovers();
});

function initPopovers() {
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-toggle="popover"]').popover();
}

function ParlJargonBuster()
{
	var _contentSelector;

 	function build(contentSelector) {
 		_contentSelector = contentSelector;
 		var content = $(_contentSelector).text();

        var phrases = getPhrases(content);
        $(phrases.jargonItems).each(applyPopoverAnchors);
 	}

    function getPhrases(content)
    {
    	//TODO
    	return {
    		"jargonItems":[
                {
                    "phrase":"jargon buster",
                    "definition":"jargon buster test",
                    "alternate":["rubbish buster"]
                },
                {
                    "phrase":"Jargon Banana",
                    "definition":"yellow jargon",
                    "alternate":["jargon fruit"]
                },
    			{
    				"phrase":"Test",
    				"definition":"Test",
    				"alternate":["Test1","Test2"]
    			},
    			{
    				"phrase":"jargon",
    				"definition":"jargon test",
    				"alternate":["rubbish"]
    			}
			]}
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
        var replacedContent = elementContent.replace(textToReplace, buildPopoverAnchor(jargonItem, "$1"));
        $(element).html(replacedContent);
    }

    function buildPopoverAnchor(jargonItem, textToReplace) {
    	return "<a class='definition' href='#' data-toggle='popover' data-html='true' data-trigger='hover' data-placement='auto bottom' data-content='<div><b>Definition: </b>" + jargonItem.definition + "</div><div>Alternative: " + jargonItem.alternate + "</div>'>" + textToReplace + "</a>";
    }

	this.Build = build;
}

        // TODO - Content length checking to not put a new jargon buster too close
        // TODO - Phrase containing another smaller phrase
        // TODO - Do not apply jargon busters to links or headers
        // TODO (optional) - Possible override of header?
