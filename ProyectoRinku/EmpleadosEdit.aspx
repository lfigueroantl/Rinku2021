<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmpleadosEdit.aspx.cs" Inherits="ProyectoRinku.EmpleadosEdit" %>
<asp:Content ID="Content1" ClientIDMode="Static" ContentPlaceHolderID="styles" runat="server">
    <link href="Content/css/select2.css" rel="stylesheet" />
    <link href="Content/datepicker.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ClientIDMode="Static" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        <form class="formsave">
            <div class="form-block same-group">

                <div class="col-lg-12">
                    <h2>Nuevo Empleado</h2>

                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Número de empleado <span class="required"></span></label>
                                <input type="number" id="txtNumero" name="txtNumero" class="form-control" max="99999999" min="1" required />
                            </div>
                        </div>
                    </div>

                </div>

                <div class="col-lg-4">
                    <div>
                        <label>Nombre(s) <span class="required"></span></label>
                        <input type="text" id="txtNombre" name="txtNombre" class="form-control" maxlength="100" required />
                    </div>

                </div>

                <div class="col-lg-4">
                    <div>
                        <label>Apellido paterno <span class="required"></span></label>
                        <input type="text" id="txtApellidoP" name="txtApellidoP" class="form-control" maxlength="100" required />
                    </div>


                </div>

                <div class="col-lg-4">
                    <div>
                        <label>Apellido materno</label>
                        <input type="text" id="txtApellidoM" name="txtApellidoM" class="form-control" maxlength="100"/>
                    </div>
                </div>

                <hr class="breakline" />
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label>Tipo<span class="required"></span></label>
                                <select class="form-control" id="cboTipo" name="cboTipo" required>
                                    <option value="">SELECCIONE...</option>
                                    <option value="1">Interno</option>
                                    <option value="2">Externo</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label>Rol<span class="required"></span></label>
                                <select class="form-control" id="cboRol" name="cboRol" required>
                                    <option value="">SELECCIONE...</option>
                                    <option value="1">Chofer</option>
                                    <option value="2">Auxiliar</option>
                                    <option value="3">Cargador</option>
                                </select>
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
    <script src="Scripts/ScriptForm/EmpleadosEdit.js?v=1.01"></script>
</asp:Content>
