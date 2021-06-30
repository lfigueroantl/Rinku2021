<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ProyectoRinku._default" %>
<asp:Content ID="Content1" ClientIDMode="Static" ContentPlaceHolderID="body" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ClientIDMode="Static" ContentPlaceHolderID="scripts" runat="server">
    <%--<script>
        $(document).ready(function () {

             var param = {
                type: "GET",
                url: "../Handlers/AdeudoHandler.ashx",
                data: { method: "TieneAdeudo", args: { id: "1830200025" } },
                method: function (data) {
                    var res = data.resultado;
                    alert(res);
                },
                unblockMessage: true
            };

            ajaxRequest(param);
        });
    </script>--%>
</asp:Content>