$(document).ready(function () {

    $(document).on("tap", '[data-role="delete"]', function () {
                
        var pid = $(this).closest("tr").data("productid");
        var uid = $(this).closest("tr").data("userid");

        $.ajax({
            url: "Product/Delete",
            type: "post",
            cache: false,
            data: { productid: pid, userid: uid },
            success: function (result) {
                $("#productlist").html(result);
            },
            error: function (result){
                alert(JSON.stringify(result))
        }
        });
    });

    $(document).on("tap", '[data-role="edit"]', function () {

        var pid = $(this).closest("tr").data("productid");
        var uid = $(this).closest("tr").data("userid");

        $.ajax({
            url: "Product/GetProductDialog",
            type: "get",
            cache: false,
            data: { productid: pid, userid: uid },
            success: function (result) {
                $("#productDialog").html(result);
            },
            error: function (result) {
                alert(JSON.stringify(result))
            }
        });
    });

    $(document).on("tap", '[data-role="new"]', function () {

        var pid = "";
        var uid = "";

        $.ajax({
            url: "Product/GetProductDialog",
            type: "get",
            cache: false,
            data: { productid: pid, userid: uid },
            success: function (result) {
                $("#productDialog").html(result);
            },
            error: function (result) {
                alert(JSON.stringify(result))
            }
        });
    });

})