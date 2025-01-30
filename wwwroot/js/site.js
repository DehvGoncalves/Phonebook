

$(document).ready(function () {
    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close'); // Remove o alerta após o fadeOut
        });
    }, 4000); // 4000 milissegundos = 4 segundos
});