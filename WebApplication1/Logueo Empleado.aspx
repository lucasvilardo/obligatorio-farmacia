<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logueo Empleado.aspx.cs" Inherits="WebApplication1.Logueo_Empleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LOGUEO EMPLEADO</title>
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 99px;
            align-items: center;
        }
         .titulo {
            text-align: center;
            font-size: 40px;
            margin-top: 20px;
        }
        .auto-style2 {
            width: 66%;
            height: 77px;
            align-items: center;
            text-align: center;
            margin-left: 134px;
        }
        .auto-style3 {
            height: 29px;
        }
        .auto-style4 {
            width: 233px;
            height: 28px;
        }
        .auto-style5 {
            height: 29px;
            width: 233px;
        }
        .auto-style6 {
            height: 28px;
        }
    </style>
</head>
     
<body>
    <h1 class="titulo">LOGUEO EMPLEADO</h1>

    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <form id="form1" runat="server">
            <table border="1" class="auto-style2">
                <tr>
                    <td class="auto-style4">Ingresar usuario:</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtUsuario" runat="server" Width="261px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Ingresar contraseña:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtContraseña" runat="server" Width="261px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" Width="229px" OnClick="btnIngresar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </form>
    </div>

    <div class="auto-style1" style="text-align: center">
        <p style="text-align: center;">
            &nbsp;<asp:HyperLink ID="hplkVolver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
        </p>
    </div>
</body>
</html>