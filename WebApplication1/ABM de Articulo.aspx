<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="ABM de Articulo.aspx.cs" Inherits="WebApplication1.ABM_de_Articulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style9 {
            width: 256px;
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
        .auto-style10 {
            height: 33px;
            width: 340px;
        }
        .auto-style12 {
    width: 66%;
    margin-left: auto;
    margin-right: auto;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center;">ABM de Artículos</h1>
    <table border="3" class="auto-style12">
        <tr>
            <td class="auto-style3">Código:</td>
            <td class="auto-style9">
                <asp:TextBox ID="txtCodigo" runat="server" Width="258px"></asp:TextBox>
            </td>
            <td class="auto-style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Width="105px" />
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">Nombre:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtNombre" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Precio:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtPrecio" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Tipo de Presentación:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtPresentacion" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Tamaño:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtTamaño" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Código de Categoría:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtCodigoC" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">&nbsp;<asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" Width="154px" />
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">&nbsp;&nbsp;
                <asp:Button ID="btnAlta" runat="server" Height="26px" Text="Alta" Width="67px" OnClick="btnAlta_Click" />
&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblError" runat="server"></asp:Label>
                &nbsp;</td>
        </tr>
    </table>
                 <div style="text-align: center;">
                     <br />
    </div>

</asp:Content>
