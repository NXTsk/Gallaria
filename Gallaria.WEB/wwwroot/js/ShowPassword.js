function showPassword() {
    var passwordText = document.getElementById("password");

    if (passwordText.type == "password") {
        passwordText.type = "text";
        document.getElementById("icon").src = "/Images/hidden.png"
    } else {
        passwordText.type = "password"
        document.getElementById("icon").src = "/Images/show.png"
    }
}

function showConfirmPassword() {
    var confirmPasswordText = document.getElementById("confirmPassword");
    if (confirmPasswordText.type == "password") {
        confirmPasswordText.type = "text";
    } else {
        confirmPasswordText.type = "password";
    }
}
