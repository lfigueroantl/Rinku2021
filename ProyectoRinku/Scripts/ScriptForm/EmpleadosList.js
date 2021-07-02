$(document).ready(function () {
    FillTable();
});

function FillTable() {

    showProcessing("Cargando...");

    var param = {
        type: "GET",
        url: "../Handlers/EmpleadoHandler.ashx",
        data: { method: "ObtenerEmpleados" },
        method: function (data) {

            var append = "";

            for (var i = 0; i < data.Empleados.length; i++) {
                var item = data.Empleados[i];

                append +=

                    "<tr id='"+item.Numero+"'>" +
                        "<td>" + item.Numero + "</td>" +
                        "<td>" + item.Nombre+" "+item.ApellidoPaterno+" "+item.ApellidoMaterno + "</td>" +
                        "<td>" + item.NombreTipo + "</td>" +
                        "<td>"+item.NombreRol+"</td>"+
                        "<td class='text-center'><a href='EmpleadosEdit.aspx?id=" + item.Numero + "' class='btn'><span class='glyphicon glyphicon-cog'></span></a></td>" +
                        "<td class='text-center'><a  class='btn eliminar'><span class='glyphicon glyphicon-trash'></span></a></td>" +

                    "</tr>";
            }
            $("tbody").empty().append(append);
            $('.table').DataTable({
                "language": {
                    "url": "../Scripts/Spanish.json"
                }
            });
        },
        unblockMessage: true
    };

    ajaxRequest(param);
}

$(document).delegate(".eliminar", "click", function () {

    if (confirm('Desea eliminar al empleado?')) {
        var itemNumero = $(this).closest('tr').attr('id');
        var param = {
            type: "POST",
            url: "EmpleadosEdit.aspx/Eliminar",
            data: "{ numEmpleado:" + itemNumero + " }",

            method: function (data) {

                if (data.message != undefined && data.message.length > 0) {
                    hideProcessing();
                    errorMessage(data.message);
                    return false;
                }
                successMessage("Eliminado correctamente.");
                window.location.reload();
            }
        };

        ajaxRequest(param);
    } else {
    }

})