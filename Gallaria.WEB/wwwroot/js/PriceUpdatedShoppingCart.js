
function updateCartTotal() {
    var cartItemContainer = document.getElementsByClassName('product')[0]
    var cartRows = cartItemContainer.getElementsByClassName('row')
    var total = 0
    for (var i = 0; i < cartRows.length; i++) {
        var cartRow = cartRows[i]
        var priceElement = cartRow.getElementsByClassName('price')[0]
        var quantityElement = cartRow.getElementsByClassName('quantity')[0]

        var price = parseFloat(priceElement.innerText.replace('€', ''))
        var quantity = quantityElement.value
        total = total + (price * quantity)
    }
    document.getElementById('total')[0].innerText = total + '€'
}