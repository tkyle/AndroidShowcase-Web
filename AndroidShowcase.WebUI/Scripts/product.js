$(document).ready(function () {

   $(document).on("click", ".deleteButton", function () {

        var pid = $(this).closest("tr").data("productid");
        var uid = $(this).closest("tr").data("userid");

        $.ajax({
            url: "Product/Delete",
            type: "post",
            data: { productid: pid, userid: uid },
            success: function (result) {
                $("#productlist").html(result);
            }
        });
    });

    $(document).on("click", ".editButton", function () {
        $.ajax({
            url: "Product/Edit",
            type: "get",
            data: $("form").serialize(),
            success: function (result) {
                $("#productlist").html(result);
            }
        });
    });

})