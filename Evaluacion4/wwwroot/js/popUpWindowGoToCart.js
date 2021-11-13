// <===================Para mostrar un alert de que se hizo la compra (momentaneo)=====================>
var botonAñadirCarrito = document.getElementsByClassName("btn-agregar-carrito");
var btnCerrarPopUp = document.querySelectorAll('.btn-cerrar');


//Documentar y entender este codigo:
[].forEach.call(botonAñadirCarrito, function(e) {
    e.onclick = function () {
        let contenedorModal = document.getElementById('contenedorModal');
        mostrarPopUp(contenedorModal);
    }
})

// btnAddToCart.forEach(button => {
//     button.addEventListener('click', () => {
//         let contenedorModal = document.getElementById('contenedorModal');
//         mostrarPopUp(contenedorModal);
//     });
// });

btnCerrarPopUp.forEach(button => {
    button.addEventListener('click', () => {
        let btnCerrarPopUp = button.closest('.contenedor-modal');
        cerrarPopUp(btnCerrarPopUp);
    });
});

function mostrarPopUp(data) {
    data.classList.toggle('active');
    let bodyBlur = document.getElementById('bodyBlur');
    bodyBlur.classList.toggle('active');
}

function cerrarPopUp(data) {
    data.classList.remove('active');
    bodyBlur.classList.remove('active');
}
