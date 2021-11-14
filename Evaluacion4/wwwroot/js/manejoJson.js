

var contenidoJson = document.getElementById("contenedorJson");
console.log(contenidoJson);
var jsonString = contenidoJson.innerHTML;

console.log(jsonString);

var jsonFinal = JSON.parse(jsonString);

for (var i = 0; i < jsonFinal.length; i++) {
    console.log(jsonFinal[i].Nombre);
};

console.log(jsonFinal);


