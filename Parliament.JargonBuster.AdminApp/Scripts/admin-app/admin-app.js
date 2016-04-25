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

    $("body").on("click", ".open-modal", function (e) {
        console.log("banana");
        e.preventDefault();
        $(this).attr("data-target", "#modal-container");
        $(this).attr("data-toggle", "modal");
    });

    $("body").on("click", ".modal-close-btn", function (e) {
        $("#modal-container").modal("hide");
    });

    $("#modal-container").on("hidden-bs-modal", function () {
        this.removeData("bs-modal");
    });

    $("#btnSave").click(function () {
        $("#modal-container").modal("hide");
    })

});

