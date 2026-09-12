
function verificarCodigoSala1() 
{
    let codigoIngresado = document.getElementById("codigo").value;
    let codigoCorrecto = "372";
    let mensajeError = document.getElementById("mensajeError");

    if (codigoIngresado === codigoCorrecto)
    {
        return true; // Permitir el envío del formulario
    }
    else
    {
        mensajeError.innerHTML = "Código incorrecto. Inténtalo de nuevo.";
        return false; // Bloquear el envío del formulario
    }
}
function verificarCodigoSala5()
{
// codigo PRESIÓN
 let codigoIngresado = document.getElementById("codigo").value;
    let codigoCorrecto = "PRESIÓN";
    let mensajeError = document.getElementById("mensajeError");

    if (codigoIngresado === codigoCorrecto)
    {
        return true; // Permitir el envío del formulario
    }
    else
    {
        mensajeError.innerHTML = "Código incorrecto. Inténtalo de nuevo.";
        return false; // Bloquear el envío del formulario
    }
}
function verificarCodigoSala3()
{
    let codigoIngresado = document.getElementById("codigo").value;
    let codigoCorrecto = "01101001";
    let mensajeError = document.getElementById("mensajeError");

    if (codigoIngresado === codigoCorrecto)
    {
        return true; // Permitir el envío del formulario
    }
    else
    {
        mensajeError.innerHTML = "Código incorrecto. Inténtalo de nuevo.";
        return false; // Bloquear el envío del formulario
    }
}
//crear sumar numero y verificar codigo

let totalSala4 = 0;
const objetivoSala4 = parseInt(document.getElementById("objetivoSala4").textContent);

function sumarValor(valor) {
    totalSala4 += valor;
    document.getElementById("totalSala4").textContent = "Total actual: " + totalSala4;
}

function verificarCodigoSala4() {
    if (totalSala4 === objetivoSala4) {
        return true;
    } 
    else {
        document.getElementById("mensajeError").textContent = "El total no coincide con el objetivo. Intenta de nuevo.";
        totalSala4 = 0;
        document.getElementById("totalSala4").textContent = "Total actual: 0";
        return false;
    }
}
//crear agregar color a la secuencia y verificar el codigo
//let secuencia = "";
function agregarColor(color) 
{
    
    //secuencia += color;
    document.getElementById("secuenciaSala6").innerText += color;
}

function verificarCodigoSala6() 
{
    let secuencia = document.getElementById("secuenciaSala6").innerText;
    const codigoCorrecto = "RGPY"; // Cambia esto según la secuencia correcta
    if (secuencia === codigoCorrecto) {
        return true; // Permite enviar el formulario
    } else {
        document.getElementById("mensajeError").innerText = "La secuencia es incorrecta. Intenta de nuevo.";
        //secuencia = ""; // Reinicia la secuencia
        document.getElementById("secuenciaSala6").innerText = ""; // Reinicia la visualización de la secuencia
        return false; // Evita enviar el formulario
    }
}

function verificarCodigoSala2() {
    let codigoIngresado = document.getElementById("codigo").value;
    let codigoCorrecto = "44246056";
    let mensajeError = document.getElementById("mensajeError");

    if (codigoIngresado === codigoCorrecto) {
        return true;
    } else {
        mensajeError.innerHTML = "Código incorrecto. Inténtalo de nuevo.";
        return false;
    }
}