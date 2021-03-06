var id = 0;
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

    id = parseInt(GetURLParameter("id"));

    if (id === undefined) {
        id = 0;
    }
    if (id == 0) {
        id = 0;
        hideProcessing();
        return false;
    }


    var param2 = {
        type: "GET",
        url: "Handlers/EmpleadoHandler.ashx",
        data: { method: "ObtenerEmpleado", args: { numero: id } },
        method: function (data) {

            $("#txtNumero").val(data.Numero);
            $("#txtNombre").val(data.Nombre);
            $("#txtApellidoP").val(data.ApellidoPaterno);
            $("#txtApellidoM").val(data.ApellidoMaterno);
            $("#cboTipo").val(data.Tipo).trigger("change");
            $("#cboRol").val(data.Rol).trigger("change");

        },
        unblockMessage: true
    };

    ajaxRequest(param2);
});
$("#btnGuardar").on("click", function () {


    if (!$(".formsave").valid()) {
        warningMessage("Información incompleta");
        return;
    }
    var res = false;
    $('.valNumero').each(function (i, el) {
        if ($(el).val() == 0) {
            $(el).addClass('error');
            res = true;
        } else {
            $(el).removeClass('error');
        }


    });
    if (res) {
        warningMessage("Información incompleta");
        return;
    }

    showProcessing("Guardando...");

    var item = {
        Numero: $("#txtNumero").val(),
        Nombre: $("#txtNombre").val(),
        ApellidoPaterno: $("#txtApellidoP").val(),
        ApellidoMaterno: $("#txtApellidoM").val(),
        Tipo: $("#cboTipo").val(),
        Rol: $("#cboRol").val()
    };

    var param = {
        type: "POST",
        url: "EmpleadosEdit.aspx/Guardar",
        data: "{ item:" + JSON.stringify(item) +" }",

        method: function (data) {

            if (data.message != undefined && data.message.length > 0) {
                hideProcessing();
                errorMessage(data.message);
                return false;
            }

            LimpiarControles();

            successMessage();
        }
    };

    ajaxRequest(param);
});

$("#btnLimpiar").on("click", function () {
    LimpiarControles();
});
$("#btnRegresar").on("click", function () {
    window.location.replace("EmpleadosList.aspx");
});
function LimpiarControles() {
    $("input").val("");
    $("select").select2("val", "").trigger("change");
    id = 0;
    $(".form-control.error").removeClass("error");
    $(".error").css("display", "none");
    $(".message .error").css("display", "none");
}