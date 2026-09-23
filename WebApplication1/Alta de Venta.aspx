<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Alta de Venta.aspx.cs" Inherits="WebApplication1.Alta_de_Venta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style3 {
             width: 349px;
             height: 33px;
         }
        .auto-style4 {
            height: 33px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            height: 18px;
            width: 219px;
        }
        .auto-style8 {
            height: 18px;
            width: 249px;
        }
        .auto-style9 {
            height: 18px;
        }
         .auto-style10 {
             width: 80%;
             height: 61px;
             margin-left: 210px;
         }
         .auto-style11 {
             height: 42px;
             width: 349px;
         }
         .auto-style12 {
             height: 54px;
         }
         .auto-style13 {
             height: 54px;
             width: 349px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center" >
    
        <h1>Alta de Venta</h1>
            </div>
    <table border="3" class="auto-style10" style="text-align:center">
        <tr>
            <td class="auto-style13">Código de Artículo:</td>
            <td colspan="2" class="auto-style12">
                <asp:TextBox ID="txtCodigo" runat="server" Width="258px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Cantidad:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtCantidad" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">CI de Cliente:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtCI" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Dirección:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtDireccion" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="365px" OnClick="btnLimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style11"></td>
            <td class="auto-style8">
&nbsp;&nbsp;
                &nbsp;
                <asp:Button ID="btnAlta" runat="server"  Text="ALTA" Width="154px" OnClick="btnAlta_Click" />
            </td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
