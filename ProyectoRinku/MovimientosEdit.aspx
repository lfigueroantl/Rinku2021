<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MovimientosEdit.aspx.cs" Inherits="ProyectoRinku.MovimientosEdit" %>
<asp:Content ID="Content1" ClientIDMode="Static" ContentPlaceHolderID="styles" runat="server">
    <link href="Content/css/select2.css" rel="stylesheet" />
    <link href="Content/datepicker.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ClientIDMode="Static" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        <form class="formsave">
            <div class="form-block same-group">

                <div class="col-lg-12">
                    <h2>Nuevo Movimiento</h2>

                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Número de empleado <span class="required"></span></label>
                                <input type="text" id="txtNumero" name="txtNumero" class="form-control" maxlength="8" required />
                            </div>
                        </div>
                    </div>

                </div>

                <hr class="breakline" />
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Fecha<span class="required"></span></label>
                                <input type="date" class="form-control" id="txtFecha" name="txtFecha" required/>
                            </div>
                        </div>
                         <div class="col-lg-4">
                            <div class="form-group">
                                <label>Cantidad de entregas<span class="required"></span></label>
                                <input type="number" class="form-control" id="txtCantidadEntregas" name="txtCantidadEntregas" required/>
                            </div>
                        </div>
                                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Cubrio turno<span class="required"></span></label>
                                <input type="checkbox" class="form-control" id="chkCubrio" name="chkCubrio" required/>
                            </div>
                        </div>
            </div>
        </form>
    </div>

    <div class="actions-group col-lg-12">
        <button type="button" class="btn btn-success" id="btnGuardar"><span class="glyphicon glyphicon-ok"></span>Guardar</button>
        <button type="button" class="btn btn-primary" id="btnLimpiar"><span class="glyphicon glyphicon-file"></span>Limpiar controles</button>
        <button type="button" class="btn btn-info" id="btnRegresar"><span class="glyphicon glyphicon-arrow-left"></span>Regresar a listado</button>
    </div>
</asp:Content>

<asp:Content ID="Content3" ClientIDMode="Static" ContentPlaceHolderID="scripts" runat="server">
    <script src="Scripts/autoNumeric-1.9.25.min.js"></script>
    <script src="Scripts/select2.min.js"></script>
    <script src="Scripts/select2_locale_es.js"></script>
    <script src="Scripts/jquery.validate.min.js"></script>
    <script src="Scripts/messages_es.min.js"></script>
    <script src="Scripts/moment.js"></script>
    <script src="Scripts/datepicker.js"></script>
    <script src="Scripts/ScriptForm/MovimientosEdit.js?v=1.01"></script>
</asp:Content>
