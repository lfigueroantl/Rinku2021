$(document).ready(function () {
    $("select").select2();
    $(".formsave").validate({
        highlight: function (element) {
            jQuery(element).closest('.form-control').addClass('error');
        },
        success: function (element) {
            jQuery(element).closest('.form-control').removeClass('error');
        },
        onfocusout: false,
        invalidHandler: function (form, validator) {
            var error = validator.numberOfInvalids();

            if (error) {
                validator.errorList[0].element.focus();
            }
        },
        ignore: 'input[type=hidden]',
        messages: {
            cboCargo: {
                required: "Este campo es obligatorio"
            },
            cboDependencia: {
                required: "Este campo es obligatorio"
            }
        },
        rules: {
            txtContraseña: "required",
            txtContraseñaConfirmacion: {
                equalTo: "#txtContraseña"
            }
        }
    });

    var param = {
        type: "GET",
        url: "Handlers/EmpleadoHandler.ashx",
        data: { method: "ObtenerComboEmpleados" },
        method: function (data) {
            var cboEmpleado = $("#cboEmpleado");
            LoadSelects(cboEmpleado, data.Combo, true);
            cboEmpleado.select2("val", "");
        },
        unblockMessage: true
    };

    ajaxRequest(param);


});


$("#btnConsultar").on("click", function () {
    showProcessing("Cargando...");
    var param = {
        type: "GET",
        url: "Handlers/MovimientoHandler.ashx",
        data: { method: "ObtenerSueldoMensual", args: { numeroempleado: $("#cboEmpleado").val(), fecha: $("#txtFecha").val() } },
        method: function (data) {
            var append = "";
                append +=

                    "<tr>" +
                        "<td>" + data.diasTrabajados + "</td>" +
                        "<td>" + data.totalEntregas+ "</td>" +
                        "<td>" + data.sueldoBase+ "</td>" +
                        "<td>" + data.extraEntregas + "</td>" +
                        "<td>" + data.bonoPorHoras + "</td>" +
                        "<td>" + data.ISR + "</td>" +
                        "<td>" + data.valesDespensa + "</td>" +
                        "<td>" + data.sueldoNeto + "</td>" +
                    "</tr>";
            
            $("tbody").empty().append(append);

            hideProcessing();
        },
        unblockMessage: true
    };

    ajaxRequest(param);
});