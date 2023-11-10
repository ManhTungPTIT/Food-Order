var btn = document.querySelectorAll(".pageBtn");
var container = document.getElementById("List-item");
var indexActive;
var pageFirst = document.getElementById("pageFirst");
var pageLast = document.getElementById("pageLast");
var title_page = document.getElementById("title-page");

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
            url: `/Product/UpdateListProduct/`,
            type: `GET`,
            data: {
                page: number,
            },
            success: function (data) {
                var render = "";
                console.log(data);
                data.forEach(product => {

                    render += `
                    <div class="card border shadow-none mb-4">
                        <div class="card-body d-flex flex-row justify-content-between">
                            <div class="InfoProduct d-flex align-items-start">
                                <div class="me-4">
                                    <img
                                        class="img-thumbnail rounded"
                                        src="
                                        ${product.image}"
                                        alt=""
                                        style="width: 7rem; height: 7rem"/>
                                </div>
                                <div class="Info d-flex flex-column justify-content-around">
                                    <h5>${product.productName}</h5>
                                    <p>${product.price}</p>
                                    <p>${product.categories}</p>
                                </div>
                            </div>
                            <div class="Activity d-flex flex-column justify-content-between">
                                <button type="button" class="btn btn-outline-secondary"
                                        asp-action="DeleteProduct" asp-router-id="${product.id}">
                                    Delete
                                </button>
                                <button type="button" class="btn btn-outline-warning">
                                    Edit
                                </button>
                            </div>
                        </div>
                    </div>
            `;
                });
                container.innerHTML = render;
                var btAdds = document.querySelectorAll("#add");
                console.log(btAdds);
            }
        })

    }
})