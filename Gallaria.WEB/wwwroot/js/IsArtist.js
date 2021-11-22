function showProfileDescription() {
    var divProfileDescription = document.getElementById("profileDescription");
    var checkBox = document.getElementById("wantToBeArtist");
    var textAreaProfileDescription = document.getElementById("textAreaProfileDescription")

    if (checkBox.checked == true) {
        divProfileDescription.style.display = 'block';
        textAreaProfileDescription.disabled = false;
        textAreaProfileDescription.setAttribute("required", "Profile description is required");
    } else {
        divProfileDescription.style.display = 'none';
        textAreaProfileDescription.disabled = true;
        textAreaProfileDescription.value = "";
    }
}