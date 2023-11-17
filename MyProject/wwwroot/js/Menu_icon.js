document.addEventListener("DOMContentLoaded", function () {
    const menuItems = document.querySelectorAll(".Icon-item");
    var I = document.querySelectorAll(".Icon-item i");
    var P = document.querySelectorAll(".Icon-item p");
    var listItems = document.querySelectorAll('.container-icon-setting');

    var url = window.location.pathname;

    // Xóa tất cả trạng thái active trước đó
    function updateClean() {
        menuItems.forEach((menuItem, index) => {
            menuItem.classList.remove("active");
            P[index].classList.remove("Active");
            I[index].classList.remove("Active");
        });
    }

    if (url.includes("Admin/ProductManagement")) {
        listItems[0].getAttribute('')
    }

    for (var i = 0; i < menuItems.length; i++) {

        if (url.includes("Profile")) {
            updateClean();
            menuItems[0].classList.add("active");
            P[0].classList.add("Active");
            I[0].classList.add("Active");
        } else if (url.includes("Menu")) {
            updateClean();
            menuItems[1].classList.add("active");
            P[1].classList.add("Active");
            I[1].classList.add("Active");
        }  else if (url.includes("History")) {
            updateClean();
            menuItems[2].classList.add("active");
            P[2].classList.add("Active");
            I[2].classList.add("Active");
        }   else {
            updateClean();
            menuItems[0].classList.add("active");
            P[0].classList.add("Active");
            I[0].classList.add("Active");
        }
    }

});


