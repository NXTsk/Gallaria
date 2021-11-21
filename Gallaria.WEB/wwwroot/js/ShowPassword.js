function showPassword() {
    var passwordText = document.getElementById("password");
    if (passwordText.type == "password") {
        passwordText.type = "text";
    } else {
        passwordText.type = "password";
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
