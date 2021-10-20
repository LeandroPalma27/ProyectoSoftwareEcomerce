// Para el boton de mostrar/ocultar contraseña:
var x = document.getElementById("inputPassword");
var y = document.getElementById("openEye");
var z = document.getElementById("closeEye");

var x2 = document.getElementById("inputConfirmPassword");
var y2 = document.getElementById("openEyev2");
var z2 = document.getElementById("closeEyev2");

function showPassword() {
    if (x.type === 'password') {
        x.type = "text";
        y.style.display = "block";
        z.style.display = "none";
    } else {
        x.type = "password";
        y.style.display = "none";
        z.style.display = "block";
    }
}

function showConfirmPassword() {
    if (x2.type === 'password') {
        x2.type = "text";
        y2.style.display = "block";
        z2.style.display = "none";
    } else {
        x2.type = "password";
        y2.style.display = "none";
        z2.style.display = "block";
    }
}


