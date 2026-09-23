<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 408px;
            margin-top: 0px;
        }

    </style>
</head>
<body>
    <div class="auto-style1" style="  text-align: center">
    
        <p style="font-size: 40px;">FARMACIA</p>
    <form id="form1" runat="server">
        Grilla de ventas que aún no se encuentran en: &quot;Entregado&quot; ni &quot;Devuelto&quot;
        <br />
        <br />
        
         
        <asp:GridView ID="GrillaEstado" runat="server" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Height="141px" Width="667px" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField AccessibleHeaderText="Número de Venta" DataField="numVenta" HeaderText="Número de Venta" />
                <asp:BoundField AccessibleHeaderText="Fecha Realizada" DataField="fechaRealizada" HeaderText="Fecha Realizada" />
                <asp:BoundField AccessibleHeaderText="Estado" DataField="estado" HeaderText="Estado" />
                <asp:BoundField AccessibleHeaderText="Dirección" DataField="direccion" HeaderText="Dirección" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
         

            
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <asp:HyperLink ID="hlnkLogueo" runat="server" NavigateUrl="~/Logueo Empleado.aspx" EnableViewState="false">PÁGINA DE LOGUEO A EMPLEADOS</asp:HyperLink>
    </form>
</body>
</html>
