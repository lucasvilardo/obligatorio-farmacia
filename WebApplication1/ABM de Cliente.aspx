<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="ABM de Cliente.aspx.cs" Inherits="WebApplication1.ABM_de_Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style3 {
            width: 219px;
            height: 33px;
        }
        .auto-style4 {
            height: 33px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            height: 31px;
            width: 219px;
        }
        .auto-style8 {
            height: 31px;
            width: 256px;
        }
        .auto-style9 {
            width: 256px;
        }
         .auto-style10 {
             height: 33px;
             width: 177px;
         }
         .auto-style11 {
             height: 31px;
             width: 177px;
         }
         .auto-style12 {
             width: 59%;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div style="text-align:center" >
    
        <h1>ABM de Clientes</h1>
            </div>
   <table border="3" style="max-width: 800px; margin: 0 auto; text-align:center; " class="auto-style12">
        <tr>
            <td class="auto-style3">Número de CI:</td>
            <td class="auto-style9">
                <asp:TextBox ID="txtCI" runat="server" Width="258px"></asp:TextBox>
            </td>
            <td class="auto-style10">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="105px" OnClick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Nombre:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtNombre" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Número de tarjeta:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtTarjeta" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Teléfono de contacto:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtTelefono" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="154px" OnClick="btnLimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style8">
                <asp:Button ID="btnAlta" runat="server" Height="26px" Text="Alta" Width="67px" OnClick="btnAlta_Click" />
&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            </td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
    
</asp:Content>
