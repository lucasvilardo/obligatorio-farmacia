<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Listado Interactivo Clientes.aspx.cs" Inherits="WebApplication1.Listado_Interactivo_Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        .contenedor {
            width: 80%;
            margin: 0 auto; 
            text-align: center; 
        }

        h1 {
            margin-bottom: 30px;
        }

        .seccion {
            margin: 20px 0;
        }

        .label-error {
            color: red;
            margin-left: 10px;
        }

        .grid {
            margin: 0 auto;
        }
        .centrar-grilla {
    display: flex;
    justify-content: center;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
            <h1>Listado Interactivo de Clientes</h1>
            <div class="seccion">
                Lista de Clientes<br />
                <br />
                 <div class="centrar-grilla">
                <asp:GridView ID="GrillaClientes" runat="server" AutoGenerateColumns="False"
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" CssClass="grid" DataKeyNames="ci" GridLines="Vertical"
            Height="129px" OnSelectedIndexChanged="GrillaClientes_SelectedIndexChanged"
            Width="800px">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="CI" DataField="ci" HeaderText="CI" />
                        <asp:BoundField AccessibleHeaderText="Número Telefónico" DataField="numTelefonico" HeaderText="Número Telefónico" />
                        <asp:BoundField AccessibleHeaderText="Número Tarjeta" DataField="numTarjeta" HeaderText="Número Tarjeta" />
                        <asp:BoundField AccessibleHeaderText="Nombre Cliente" DataField="nombreCli" HeaderText="Nombre Cliente" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
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
                 </div>

            <div class="seccion">
                <h3>LISTADO COMPLETO DE VENTAS ASOCIADAS</h3>
                <p>
                    <asp:DropDownList ID="ddlVentas" runat="server" Height="19px" Width="810px">
                    </asp:DropDownList>
                </p>
            </div>

            
            <div class="seccion">
                <h3>LSITADO COMPLETO DE ARTICULOS QUE COMPRÓ</h3>
                <p>
                    <asp:DropDownList ID="ddlArticulos" runat="server" Height="16px" Width="672px">
                    </asp:DropDownList>
                </p>
            </div>

           
            <div class="seccion">
                <h3>MONTO TOTAL GASTADO EN LA FARMACIA</h3>
                <p>
                    <asp:Label ID="lblMonto" runat="server"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </p>
</asp:Content>
