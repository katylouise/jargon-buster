"use strict";

$(document).ready(function () {

    $(".edit-alternatives__add").click(function () {
        var listId = $("li").last().attr("id");
        var counter = listId === undefined ? 0 : parseInt(listId) + 1;
        var newLi = '<li><input name="Alternates[' + counter + '].AlternateDefinition" type="text" value="" class="edit-alternatives__term"></li>';
        $("ul").append(newLi);
        $("li").last().attr("id", counter);
        console.log("banana");
    });

    $('body').on('click', '.open-modal', function (e) {
        e.preventDefault();
        $(this).attr('data-target', '#modal-container');
        $(this).attr('data-toggle', 'modal');
    });

    $("#modal-container").on("hidden-bs-modal", function () {
        $(this).removeData("bs-modal");
    });
});

