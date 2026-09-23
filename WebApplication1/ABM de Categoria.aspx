<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="ABM de Categoria.aspx.cs" Inherits="WebApplication1.ABM_de_Categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style9 {
            width: 523px;
            text-align: center;
        }
        .auto-style4 {
            height: 33px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            height: 31px;
            width: 204px;
        }
        .auto-style8 {
            height: 31px;
            width: 523px;
            margin: auto;
            text-align: center;
        }
        .auto-style13 {
            height: 33px;
            width: 156px;
            text-align: center;
        }
        .auto-style14 {
            height: 31px;
            width: 156px;
        }
        .auto-style15 {
            width: 60%;
            margin: auto;
            text-align: center;
        }
        .auto-style16 {
            height: 56px;
            width: 154px;
            text-align: center;
        }
        .auto-style17 {
            height: 42px;
            width: 154px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">
        <h1>ABM de Categoría</h1>
    </div>

    <table border="2" class="auto-style15">
        <tr>
            <td class="auto-style16">Código:</td>
            <td class="auto-style9">
                <asp:TextBox ID="txtCodigo" runat="server" Width="258px"></asp:TextBox>
            </td>
            <td class="auto-style13">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="105px" OnClick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style16">Nombre:</td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtNombre" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="154px" OnClick="btnLimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style17"></td>
            <td class="auto-style8">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAlta" runat="server" Height="26px" Text="Alta" Width="67px" OnClick="btnAlta_Click" />
&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            </td>
            <td class="auto-style14"></td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>