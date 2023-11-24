var items = document.querySelectorAll(".tab-item");

items.forEach((item, index) => {
    item.onclick = function (){
        if(index === 0 ){
            window.location.href = "/Product/Listproduct";
        }
        else if (index === 1){
            window.location.href = "/Category/Index"
        }
        else{
            window.location.href = "/Order/Index"
        }
    }
})