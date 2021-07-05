$(document).ready(function () {
    FillTable();
});

function FillTable() {

    showProcessing("Cargando...");

    var param = {
        type: "GET",
        url: "../Handlers/MovimientoHandler.ashx",
        data: { method: "ObtenerMovimientos" },
        method: function (data) {

            var append = "";

            for (var i = 0; i < data.Movimientos.length; i++) {
                var item = data.Movimientos[i];

                append +=

                    "<tr id='" + item.Codigo + "'>" +
                        "<td>" + item.NumeroEmpleado + "</td>" +
                        "<td>" + item.NombreEmpleado+ "</td>" +
                        "<td>" + item.Fecha + "</td>" +
                        "<td>" + item.CantidadEntregas + "</td>" +
                        "<td>" + item.CubrioTurno + "</td>" +
                        "<td class='text-center'><a href='MovimientosEdit.aspx?id=" + item.Codigo + "' class='btn'><span class='glyphicon glyphicon-cog'></span></a></td>" +
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

    if (confirm('Desea eliminar el movimiento?')) {
        var itemCodigo = $(this).closest('tr').attr('id');
        var param = {
            type: "POST",
            url: "MovimientosEdit.aspx/Eliminar",
            data: "{ codigo:" + itemCodigo + " }",

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