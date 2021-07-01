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

                    "<tr>" +
                        "<td>" + item.Numero + "</td>" +
                        "<td>" + item.Nombre+" "+item.ApellidoPaterno+" "+item.ApellidoMaterno + "</td>" +
                        "<td>" + item.Tipo + "</td>" +
                        "<td>"+item.NombreRol+"</td>"+
                        "<td class='text-center'><a href='EmpleadosEdit.aspx?id=" + item.Numero + "' class='btn'><span class='icon icon-cog'></span></a></td>" +
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