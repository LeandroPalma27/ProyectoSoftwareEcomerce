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
    if (inputCantidadNumber == 99 || inputCantidadNumber > 100) {
        alert('Cantidad excedida (solo 99 productos por compra)');
    } else {
        inputCantidadNumber++;
        inputCantidad.innerHTML = inputCantidadNumber;
        inputCantidad.value = inputCantidadNumber;
    }
});