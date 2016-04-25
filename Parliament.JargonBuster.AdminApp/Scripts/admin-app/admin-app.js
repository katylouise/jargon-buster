"use strict";

$(document).ready(function () {

    $(".addAlternate").click(function () {
        var listId = $("li").last().attr("id");
        console.log(listId);
        var counter = listId === undefined ? 0 : parseInt(listId) + 1;
        var newLi = '<li><input name="Alternates['+ counter +'].AlternateDefinition" type="text" value=""></li>';
        $("ul").append(newLi);
        $("li").last().attr("id", counter);
    });

    $("a[data-toggle]").click(function () {
        var modal = this.data("target");
        modal.show();
    });

});

