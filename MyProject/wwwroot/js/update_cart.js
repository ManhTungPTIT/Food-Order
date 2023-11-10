var btAdds = document.querySelectorAll("#add");
var totals = document.getElementById("total");
var containerOrder = document.getElementById("List_order");
var confirm =document.getElementById("confirm");
var customer = document.getElementById("name_customer");

var listId =[];
updateCartInfo()
btAdds.forEach((button, index) => {
    button.onclick = function (){
        const productId = button.getAttribute("data-productId");
        addToCart(productId);
    }
})

function addToCart(productId){
    $.ajax({
        type: 'POST',
        url: '/Menu/AddToCart?productId=' + productId,
        data: {productId: productId},
        success: function () {
            updateCartInfo();
            
        },
        error: function (xhr, status, error) {
            console.log('Failed to add product to cart.');
            console.log('Lỗi AJAX: ' + error);

        }
    });
}

function updateFooter(quantityElement, priecElement){
    var total = 0;
    quantityElement.forEach((quantity, index) => {
        quantity = parseInt(quantityElement[index].value);
        var price = parseInt(priecElement[index].value);
        
        total += quantity * price;
    })
    
    totals.textContent = total;
}

function updateCartInfo() {
    var table = document.getElementById("bill");
    $.ajax({
        type: 'GET',
        url: '/Menu/CartInfo',
        success: function (data) {
            console.log(data);
            var render = "";
            data.forEach(order => {
                render += `
                    <div class="Table-main_item" data-productId = "${order.product.id}">
                    <div class="Table-main_item-img">
                        <img
                            src="${order.product.image}"
                            alt="Anh"/>
                    </div>

                    <div class="Table-main_item-info">
                        <p class="infor-name">${order.product.productName}</p>                    
                        <div class="d-flex flex-row ">
                                <p style="margin-bottom: 0">Số lượng: </p>
                                <input type="number" id="quantity" class="info_quantity ms-5" value="${order.quantity}" readonly/>
                        </div>
                        <div class="d-flex flex-row ">
                                <p style="margin-bottom: 0">Giá tiền: </p>
                                <input type="number" id="totalPrice" class="info_price ms-5" value="${order.product.price}" readonly/>
                        </div>
                                
                    </div>
                </div>
                `;
            })

            containerOrder.innerHTML = render;
            var quantities = document.querySelectorAll(".info_quantity");
            var prices = document.querySelectorAll(".info_price");
            var items = document.querySelectorAll(".Table-main_item");
            items.forEach((item, index) => {
                const id = item.getAttribute("data-productId");
                listId.push(id);
            })
            updateFooter(quantities, prices);
            
        },
        error: function () {
            console.log('Failed to update cart info.');
        }
    });
}

console.log(listId);
confirm.onclick = function (){
    if(customer.value === ""){
        alert("Vui lòng nhập tên khách hàng")
    }
    else {
        $.ajax({
        url: `/Menu/ClearOrder`,
        type: 'GET',
        data: {
            name : customer.value,
            listId: listId,
        },
        success: function (){
            alert("Đặt đơn thành công")
            window.location.href = "/Home/Index";
        }
    })
    }
}