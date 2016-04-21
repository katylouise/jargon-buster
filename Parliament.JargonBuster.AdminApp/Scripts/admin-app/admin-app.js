"use strict";

$(document).ready(function () {

    $(".addAlternate").click(function () {
        var counter = parseInt($("li").last().attr("id")) + 1;
        var newLi = '<li><input name="Alternates['+ counter +'].AlternateDefinition" type="text" value=""></li>';
        $("ul").append(newLi);
        $("li").last().attr("id", counter);
    });
});

