var btn = document.querySelectorAll(".pageBtn");
var container = document.getElementById("List_item");
var indexActive;
var pageFirst = document.getElementById("pageFirst");
var pageLast = document.getElementById("pageLast");
var title_page = document.getElementById("title-page");
var btAdds = document.querySelectorAll("#add");
var totals = document.getElementById("total");
var containerOrder = document.getElementById("List_order");
var confirm =document.getElementById("confirm");

var listId =[];
function cleaneButton() {
    btn.forEach((bt, index) => {
        if (bt.classList.contains("activeBt")) {
            indexActive = index;
            bt.classList.remove("activeBt");
        }
    })
}

function checkBtActive() {
    btn.forEach((bt, index) => {
        if (bt.classList.contains("activeBt")) {
            indexActive = index;
        }
    })
}

function updateButton(number) {
    if (btn[number + 1].innerHTML === "1") {
        btn[0].style.display = "none"
        btn[1].style.display = "none"
    } else {
        btn[0].style.display = "block"
        btn[1].style.display = "block"
    }

    if (number === btn.length - 4) {
        btn[btn.length - 1].style.display = "none"
        btn[btn.length - 2].style.display = "none"
    } else {
        btn[btn.length - 1].style.display = "block"
        btn[btn.length - 2].style.display = "block"
    }
}

btn.forEach((bt) => {
    checkBtActive();
    updateButton(indexActive - 1);

    bt.onclick = function () {
        cleaneButton();

        let number;
        if (bt.innerHTML === "First") number = 1;
        else if (bt.innerHTML === "Next") number = indexActive;
        else if (bt.innerHTML === "Previous") number = indexActive - 2;
        else if (bt.innerHTML === "Last") number = btn.length - 4;
        else number = Number(bt.innerHTML);

        if (bt.innerHTML === "First") btn[2].classList.add("activeBt");
        else if (bt.innerHTML === "Last") btn[(btn.length) - 3].classList.add("activeBt");
        else if (bt.innerHTML === "Next") btn[indexActive + 1].classList.add("activeBt");//
        else if (bt.innerHTML === "Previous") btn[indexActive - 1].classList.add("activeBt");//
        else bt.classList.add("activeBt");

        let pageSize = bt.getAttribute("data-pageSize");
        let totalEntries = bt.getAttribute("data-totalEntries");
        pageFirst = pageSize * (number - 1) + number - (number - 1);
        pageLast = pageFirst + Number(pageSize - 1);
        if (pageLast > totalEntries) pageLast = totalEntries;

        var titleRender = `<div class="fs-6 " id="title-page" style="color: grey ">
                            Showing <span >${pageFirst}</span> to <span >${pageLast}</span> of ${totalEntries} entries
                        </div>`;


        updateButton(number);

        $.ajax({
            url: `/Menu/UpdateListProduct/`,
            type: `GET`,
            data: {
                page: number,
            },
            success: function (data) {
                var render = "";
                
                data.forEach(product => {

                    render += `
                    <div class="Item">
                            <div class="Item-img">
                                <img
                                    src="${product.image}"
                                    alt=""
                                    id="image"/>
                            </div>
                            <p id="name">${product.productName}</p>
                            <p id="price">${product.price}</p>
                            <button id="add" data-productId="${product.id}">Thêm vào giỏ</button>
                        </div>
            `;
                });
                
                container.innerHTML = render;
                var btAddsRender = document.querySelectorAll("#add");
                btAddsRender.forEach(button => {
                    button.onclick = function (){
                        const productId = button.getAttribute("data-productId");
                        addToCart(parseInt(productId));
                    }
                })
            }
        })

    }
})

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
                                <p style="margin-bottom: 0; width: 5rem">Số lượng: </p>
                                <input type="number" id="quantity" class="info_quantity ms-5" value="${order.quantity}" readonly/>
                        </div>
                        <div class="d-flex flex-row ">
                                <p style="margin-bottom: 0; width: 5rem ">Giá tiền: </p>
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
    $.ajax({
        url: `/Menu/ClearOrder`,
        type: 'GET',
        data: {
            listId: listId,
        },
        success: function (){
            alert("Đặt đơn thành công")
            window.location.href = "/Menu/Index";
        }
    })
}
