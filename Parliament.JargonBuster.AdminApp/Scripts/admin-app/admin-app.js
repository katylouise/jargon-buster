"use strict";

$(document).ready(function () {

    $("body").on("click", ".addAlternate", function () {
        var listId = $("li").last().attr("id");
        var counter = listId === undefined ? 0 : parseInt(listId) + 1;
        var newLi = '<li><input name="Alternates[' + counter + '].AlternateDefinition" type="text" value="" class="edit-alternatives__term"></li>';
        $("ul").append(newLi);
        $("li").last().attr("id", counter);
    });

    $('body').on('click', '.open-modal', function (e) {
        e.preventDefault();
        $(this).attr('data-target', '#modal-container');
        $(this).attr('data-toggle', 'modal');
    });

    $("#modal-container").on("hidden.bs.modal", function () {
        $(this).removeData("bs.modal");
    });

    $("body").on("click", ".btnSave", function (e) {
        e.preventDefault();
        var phrase = $(".formInput").val();
        $.ajax({
            url: "/Home/ValidateDefinition",
            type: "POST",
            dataType: "json",
            data: "phrase=" + phrase,
            success: function (result) {
                if (result) {
                    $(".modalForm").submit();
                }
                else {
                    $(".errorMessage").text("This is a duplicate term.");
                }
            }
        })
    });

    setTimeout(function () {
        $(".sitewide-message").fadeOut()
    }, 5000);
});

