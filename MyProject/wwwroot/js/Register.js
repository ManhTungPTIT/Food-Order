function changePass() {
    let password = document.getElementById("password");
    password.type = password.type == "text" ? "password" : "text";
}
function change() {
    let password = document.getElementById("confirm");
    password.type = password.type == "text" ? "password" : "text";
}

var userName = document.getElementById("username");
// var name = document.getElementById("name");
var pass = document.getElementById("password");
var confirm = document.getElementById("confirm");
var button = document.getElementById("register");
var phone = document.getElementById("phone");
var birthday = document.getElementById("birthday");

const regexNumber =/\d/;
const regexText = /[-._@+]/;
const regexTextInHoa = /[A-Z]/

button.onclick = function (e){
    e.preventDefault()
    if(pass.value.length < 6){
       return  alert("Mật khẩu có độ dài ít nhất là 6 ")
    }
    else if(regexNumber.test(pass.value) === false){
        alert("Mật khẩu phải chứa số ")
    }
    else if(regexText.test(pass.value) === false){
        alert("Mật khẩu phải chứa ít nhất 1 trong các kí tự -._@+")
    }
    else if(regexTextInHoa.test(pass.value) === false){
        alert("Mật khẩu phải chứa ít nhất 1 chữ cái in hoa")
    }
    else if(pass.value !== confirm.value){
        alert("Vui lòng nhập lại mật khẩu !!!");
    }
    else{
        console.log(userName.value);
        // console.log(name.length);
        console.log(pass.value);
        console.log(phone.value);
        console.log(birthday.value);
        $.ajax({
            url: "~/Authen/Register",
            type: "POST",
            data: {
                userName: userName,
                password: pass,
            },
            
            success: function (){
                location.reload();
            }
        })
    }
}
