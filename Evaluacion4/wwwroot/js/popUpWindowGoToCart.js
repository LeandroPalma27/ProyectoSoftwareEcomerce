// <===================Para mostrar un alert de que se hizo la compra (momentaneo)=====================>
var botonAñadirCarrito = document.getElementsByClassName("btn-agregar-carrito");
var btnCerrarPopUp = document.querySelectorAll('.btn-cerrar');
var btnPagarAll = document.getElementById('btnTodoPago');
var btnPagarOne = document.querySelectorAll('.boton-pagar-uno');
var btnPagar = document.querySelectorAll('.btn-pagarOneAll');
var btnCerrarPopUpPagoTodo = document.getElementById('btnCerrar');


//Documentar y entender este codigo:
[].forEach.call(botonAñadirCarrito, function (e) {
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

btnPagar.forEach(button => {
    button.addEventListener('click', () => {
        let btnCerrarPopUp = button.closest('.contenedor-modal__resumen');
        cerrarPopUp(btnCerrarPopUp);
    })
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

btnPagarAll.addEventListener('click', function (e) {
    let contenedorModalCart = document.getElementById('contenedorModalResumen');
    mostrarPopUp(contenedorModalCart);
});

btnCerrarPopUpPagoTodo.addEventListener('click', function (e) {
    let btnCerrarPopUp = btnCerrarPopUpPagoTodo.closest('.contenedor-modal__resumen');
    cerrarPopUp(btnCerrarPopUp);
});

