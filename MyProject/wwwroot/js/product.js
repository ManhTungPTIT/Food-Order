var btDeleteProducts = document.querySelectorAll(".delete");
var btEdit = document.querySelectorAll(".EditProduct");


btDeleteProducts.forEach((bt, index) => {
    console.log("zoooo")
    bt.onclick = function (){
        console.log("vaooo")
        var id = bt.getAttribute("data-routerId");
        $.ajax({
            url: '/Product/DeleteProduct',
            type: 'POST',
            data: {
                id: parseInt(id),
            },
            success: function (){
                window.location.href = "/Product/ListProduct";
            }
        })
    }
})

btEdit.forEach((bt,index) => {
    bt.onclick = function (){
        var id = bt.getAttribute("data-productID");
        console.log(id);
        console.log(typeof id);
        $.ajax({
            url: `/Product/DeleteProduct`,
            data: {
                id: parseInt(id),
            },
            success: function (){
                window.location.href = "/Product/ListProduct";
            }
        })
    }
})