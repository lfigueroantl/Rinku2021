<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConsultaSueldo.aspx.cs" Inherits="ProyectoRinku.ConsultaSueldo" %>
<asp:Content ID="Content1" ClientIDMode="Static" ContentPlaceHolderID="styles" runat="server">
    <link href="Content/css/select2.css" rel="stylesheet" />
    <link href="Content/datepicker.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ClientIDMode="Static" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        <form class="formsave">
            <div class="form-block same-group">

                    <div class="col-lg-12">
                        <h2>Consulta de sueldos</h2>

                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>Empleado <span class="required"></span></label>
                                    <select class="form-control" id="cboEmpleado" name="cboEmpleado"></select>
                                </div>
                            </div>
                        </div>
                                            <div class="row">
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>Fecha<span class="required"></span></label>
                                    <input type="month" class="form-control" id="txtFecha" name="txtFecha" required/>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label style="visibility:hidden">consultar</label><br />
                                    <button type="button" id="btnConsultar" name="btnConsultar" class="btn btn-success">Consultar</button>
                                </div>
                            </div>
                    </div>
                    </div>

                </div>                     
        </form>
    </div>

    <div class="actions-group col-lg-12">
                     <div class="row">
                <div class="col-lg-12">
                        <table id="dataTable" class="display table table-bordered datagrid">
                            <thead>
                                <tr>
                                    <th class="text-center  col-lg-1">Días trabajados</th>
                                    <th class="text-center  col-lg-1">Total entregas</th>
                                    <th class="text-center">Sueldo base</th>
                                    <th class="text-center">Extra por entregas</th>
                                    <th class="text-center">Bono por horas</th>
                                    <th class="text-center">ISR</th>
                                    <th class="text-center">Vales de despensa</th>
                                    <th class="text-center">Sueldo Neto</th>
                                </tr>
                            </thead>
                            <tbody id="tbody">
                            </tbody>
                        </table>
                </div>
            </div>
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
    <script src="Scripts/ScriptForm/ConsultaSueldo.js?v=1.01"></script>
</asp:Content>
