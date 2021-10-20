// <===================Para mostrar un alert de que se hizo la compra (momentaneo)=====================>
var botonAñadirCarrito = document.getElementsByClassName("btn-agregar-carrito");

//Documentar y entender este codigo:
[].forEach.call(botonAñadirCarrito, function(e) {
    e.onclick = function () {
        alert("¡Se añadio al carrito!");
    }
})