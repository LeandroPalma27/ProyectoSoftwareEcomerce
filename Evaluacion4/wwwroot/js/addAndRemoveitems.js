// var btnRemove, btnAdd, inputCantidad, inputCantidadNumber;
// inputCantidadNumber = 0;

// btnRemove = document.getElementsByClassName('cantidad_btn-remove');
// btnAdd = document.getElementsByClassName('cantidad_btn-add');
// inputCantidad = document.getElementsByClassName('input-cantidad');

// [].forEach.call(btnRemove, function (e) {
//     e.onclick = function () {
//         let tamañoArrayInputsCantidad = inputCantidad.length;
//         let contador = 0;
//         while (contador <= (tamañoArrayInputsCantidad)) {
//             contador++;
//             if (inputCantidad[contador].value < 100) {
//                 inputCantidadNumber++;
//                 inputCantidad[contador].innerHTML = inputCantidadNumber;
//                 inputCantidad[contador].value = inputCantidadNumber;
//             }
//             break;
//         }

//         for (var i = 0; i < inputCantidad.length; i++) {

//         }
//         [].forEach.call(inputCantidad, function (e) {

//         });
//     }
// });

var btnRemove, btnAdd, inputCantidad;

btnRemove = document.getElementById('btnRemove');
btnAdd = document.getElementById('btnAdd');
inputCantidad = document.getElementById('inputCantidad');

var inputCantidadNumber = parseInt((inputCantidad.value), 10);

if ((inputCantidadNumber) < 1) {
    inputCantidad.value = 1;
}

btnRemove.addEventListener('click', function (e) {
    if (inputCantidadNumber === 1) {
        alert('Debe comprar minimo 1 unidad.');
    } else {
        inputCantidadNumber--;
        inputCantidad.innerHTML = inputCantidadNumber;
        inputCantidad.value = inputCantidadNumber;
    }
});

btnAdd.addEventListener('click', function (e) {
    if (inputCantidadNumber > 99) {
        alert('Cantidad excedida (solo 99 productos por compra)');
    } else {
        inputCantidadNumber++;
        inputCantidad.innerHTML = inputCantidadNumber;
        inputCantidad.value = inputCantidadNumber;
    }
});


// btnAdd.addEventListener('click', function (e) {
//     if (inputCantidadNumber == 99 || inputCantidadNumber > 100) {
//         alert('Cantidad excedida (solo 99 productos por compra)');
//     } else {
//         inputCantidadNumber++;
//         inputCantidad.innerHTML = inputCantidadNumber;
//         inputCantidad.value = inputCantidadNumber;
//     }
// });