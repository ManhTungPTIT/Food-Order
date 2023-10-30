$(document).ready(function () {
    $("button[id^='confirmButton']").click(function () {
        const productId = $(this).data("product-id");

        $.ajax({
            url: "/Admin/DeleteProduct",
            type: "POST",
            data: { productId: productId },
            success: function () {
                console.log("Xoá sản phẩm thành công!" + productId);
                const modalId = "confirDeleteProduct-" + productId;
                $("#" + modalId).modal("hide");

                window.location.href = "/Admin/ProductManagement";
            },
            error: function () {
                alert("Lỗi khi xoá sản phẩm!");
            }
        });
    });

    $("button[id^='confirmButtonCategory']").click(function () {
        const categoryId = $(this).data("category-id");
        console.log("Xoá category thành công!" + categoryId);
        $.ajax({
            url: "/Admin/DeleteCategory",
            type: "POST",
            data: { categoryId: categoryId },
            success: function () {
                console.log("Xoá sản phẩm thành công!" + categoryId);
                const modalId = "confirmDeleteCategory-" + categoryId;
                $("#" + modalId).modal("hide");

                window.location.href = "/Admin/ProductManagement";
            },
            error: function () {
                alert("Lỗi khi xoá sản phẩm!");
            }
        });
    });

});