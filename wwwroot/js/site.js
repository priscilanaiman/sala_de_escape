
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
