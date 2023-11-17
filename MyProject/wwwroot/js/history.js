var details = document.querySelectorAll(".detail");
var orderId = document.querySelectorAll(".orderId")
var container = document.getElementById("ListProduct");

details.forEach((button, index) => {
    button.onclick = function (){
        console.log(orderId[index].textContent)
        $.ajax({
            url: `/History/GetDetailOrder`,
            type: 'GET',
            data: {
                id: orderId[index].textContent
            },
            success: function (data){
                console.log(data);
                var render = "";
                data.forEach(product => {
                    render += `
                        <tr class="align-middle">
                                <td>
                                    <div class="d-flex align-item-center">
                                        <img
                                            src="${product.image}"
                                            alt="Anh"
                                            class="avatar"/>                                             
                                    </div>
                                </td>
                                <td class="mt-4 ms-2">Tên sản phẩm:${product.productName}</td>
                                <td class="text-center">Giá sản phẩm: ${product.price}</td>
                            </tr>
                    `
                })
                container.innerHTML = render;
            }
        })
    }
})