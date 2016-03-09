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


        var phrases = getPhrases(content);

        $(phrases.jargonItems).each(applyPopoverAnchors);
 	}

    function getPhrases(content)
    {
    	//TODO 
    	return {
    		"jargonItems":[
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
    	// var indexOfItem = $(_contentSelector)[0].innerText.indexOf(item.phrase);
    	// if (indexOfItem == -1) return;

    	// TODO - contains selector - find the element with the text directly in the element

    	// TODO - Content length checking to not put a new jargon buster too close
    	// TODO - Phrase containing another smaller phrase
    	// TODO - Do not apply jargon busters to links or headers
    	// TODO (optional) - Possible override of header?

    	var phrasedElements = $(":last-child:contains('" + jargonItem.phrase + "')");

    	phrasedElements.each(function(phrasedElementIndex, phrasedElementItem) {
    		applyPopoverAnchor(jargonItem, phrasedElementItem);
    	});
    	
    }

    function applyPopoverAnchor(jargonItem, element) {
    	var elementContent = element.innerHTML;
    	elementContent.replace(jargonItem.phrase, buildPopoverAnchor(jargonItem));
    	$(element).html(elementContent);
    }

    function buildPopoverAnchor(jargonItem) {
    	return "<a href='#' data-popup='" + jargonItem.definition + "' data-alternate='" + jargonItem.alternate + "'>" + jargonItem.phrase + "</a>";
    }

	this.Build = build;
}





// // 
// {
// 	JargonItems[]
// 	{
// 		Phrase
// 		Definition
// 		Alternate[]
// 	}
// }