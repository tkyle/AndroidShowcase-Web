$(document).ready(function () {

   $(".deleteButton").click(function () {

        var pid = $(this).closest("tr").data("productid");
        var uid = $(this).closest("tr").data("userid");

        $.ajax({
            url: "Product/Delete",
            type: "post",
            data: { productid: pid, userid: uid },
            success: function (result) {
                $("#partial").html(result);
            }
        });
    });

    $(".editButton").click(function () {
        $.ajax({
            url: "Product/Edit",
            type: "get",
            data: $("form").serialize(), //if you need to post Model data, use this
            success: function (result) {
                $("#productlist").html(result);
            }
        });
    });

})