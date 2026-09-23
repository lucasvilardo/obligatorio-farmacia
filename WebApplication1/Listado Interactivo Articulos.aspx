<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Listado Interactivo Articulos.aspx.cs" Inherits="WebApplication1.Listado_Interactivo_Articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        body, html {
    margin: 0;
    padding: 0;
    height: 100%;
}

.contenedor {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    padding: 20px 0;
}

.seccion {
    width: 100%;
    max-width: 900px;
    margin: 20px 0;
    text-align: center;
}

.grid {
    margin: 0 auto;
    display: table;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contenedor">
            <h1>Listado Interactivo de Artículos</h1>
            <div class="seccion">
                <asp:DropDownList ID="ddlCategorias" runat="server" Height="30px" Width="241px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged"></asp:DropDownList>

                <asp:Label ID="lblError" runat="server" CssClass="label-error"></asp:Label>

                <asp:DropDownList ID="ddlArticulos" runat="server" Height="30px" Width="241px" AutoPostBack="True" OnSelectedIndexChanged="ddlArticulos_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="seccion">
                <h3>DATOS DEL ARTÍCULO</h3>
                <asp:ListBox ID="lbxDatos" runat="server" Height="23px" Width="731px"></asp:ListBox>
            </div>

            
            <div class="seccion">
    <h3>VENTAS DEL ARTÍCULO</h3>
    <asp:GridView ID="GrillaVentasdArticulo" runat="server" CssClass="grid"
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
        CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False"
        Height="129px" Width="496px"
        OnSelectedIndexChanged="GrillaVentasdArticulo_SelectedIndexChanged"
        DataKeyNames="numVenta">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField AccessibleHeaderText="Número de Venta" DataField="numVenta" HeaderText="Número de Venta" />
            <asp:BoundField AccessibleHeaderText="Fecha Realizada" DataField="fechaRealizada" HeaderText="Fecha Realizada" />
            <asp:BoundField AccessibleHeaderText="Estado" DataField="estado" HeaderText="Estado" />
            <asp:CommandField ShowSelectButton="True" HeaderText="Seleccionar" />
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
</div>
                <div>

           
            <div class="seccion">
                <h3>VENTA COMPLETA Y CLIENTE</h3>
                <asp:ListBox ID="lbxVenta" runat="server" Height="22px" Width="1180px"></asp:ListBox>
            </div>
</asp:Content>
