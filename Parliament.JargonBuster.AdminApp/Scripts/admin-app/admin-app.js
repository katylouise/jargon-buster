"use strict";

$(document).ready(function () {

    $(".addAlternate").click(function () {
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

    $('body').on('click', '.modal-close-btn', function () {
        $('#modal-container').modal('hide');
    });

    $('#modal-container').on('hidden.bs.modal', function () {
        console.log("elephant");
        $(this).removeData('bs.modal');
    });

});

