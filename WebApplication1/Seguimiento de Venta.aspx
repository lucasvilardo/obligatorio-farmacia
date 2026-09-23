<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Seguimiento de Venta.aspx.cs" Inherits="WebApplication1.Seguimiento_de_Venta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 63%;
            margin-left: 210px;
            height: 61px;
        }
        .auto-style3 {
            width: 219px;
            height: 49px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style9 {
            width: 167px;
            height: 49px;
        }
        .auto-style11 {
            width: 128px;
            height: 49px;
        }
        .auto-style12 {
            height: 14px;
        }
        .auto-style13 {
            width: 156px;
        }
         .auto-style14 {
             width: 63%;
             height: 61px;
             margin-left: 210px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="text-align:center" >
    
        <h1>Seguimiento de Venta</h1>
            </div>
    <table border="3" class="auto-style14" style="text-align:center">
        <tr>
            <td class="auto-style3">Número de Venta:</td>
            <td class="auto-style9">
                <asp:TextBox ID="txtNumVenta" runat="server" Width="165px" Height="18px"></asp:TextBox>
            </td>
            <td class="auto-style11">
                &nbsp;&nbsp;
                &nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="78px" OnClick="btnBuscar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="auto-style13" rowspan="2">
                Estado Actual:&nbsp;
                <asp:Label ID="lblEstado" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style12" colspan="3">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="112px" OnClick="btnLimpiar_Click" />
            &nbsp;&nbsp;
                <asp:Button ID="btnCambiar" runat="server" Text="Cambiar Estado" Width="307px" OnClick="btnCambiar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td class="auto-style13">
                Próximo Estado:
                <asp:Label ID="lblProxEstado" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
