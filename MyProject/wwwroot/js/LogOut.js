var buttonLogOut = document.getElementById("LogOut");
var modal = document.getElementById("MyModal");
var span = document.getElementById("Close");
var Confirm = document.getElementById("confirmLogOut");
var cancel = document.getElementById("cancelLogOut");


buttonLogOut.onclick = function (){
    console.log("vao");
    modal.style.display = "block";
}

span.onclick = function (){
    modal.style.display = "none";
}

cancel.onclick = function (){
    modal.style.display = "none";
}

Confirm.onclick = function (){
    $.ajax({
        url: "/Authen/Logout",
        success: function (){
            window.location.href = "/Authen/Login";
        }
    })
}