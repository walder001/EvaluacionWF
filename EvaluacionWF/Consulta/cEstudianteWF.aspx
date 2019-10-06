<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cEstudianteWF.aspx.cs" Inherits="EvaluacionWF.Consulta.cEstudianteWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <ul class="nav justify-content-center bg-success">
            <li>
                <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true"></a>

                <h5 class="text-light">Consulta Categoria</h5>
                <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true"></a>

            </li>
        </ul>
        <div class="row">
            <div class="col col-4">
                <asp:TextBox ID="FechaIncio" CssClass="form-control" TextMode="Date" runat="server" />
            </div>
            <div class="col offset-1">
                <asp:CheckBox ID="checkbox" runat="server" />
            </div>
            <div class="col col-5 offset-1">
                <asp:TextBox ID="FechaFin" CssClass="form-control" TextMode="Date" runat="server" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-1"><strong>Filtro</strong></label>
            <asp:DropDownList ID="DropDrom" runat="server" CssClass="col-2" >
                <asp:ListItem Text="Id" />
            </asp:DropDownList>
            <label class="col-1"><strong>Contenido </strong></label>
            <asp:TextBox ID="TextBoxCriterio" runat="server" CssClass="col-6 form-control" />
            <asp:Button Text="Buscar" runat="server" CssClass=" btn btn-primary col-2" OnClick="Buscar_Click"/>
        </div>
        <div>
        </div>
    </div>

    <div class="table-responsive container">
        <asp:GridView ID="DatosGridView" runat="server" class="table table-condensed  table-responsive" CellPadding="6" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:HyperLinkField ControlStyle-ForeColor="#0094ff"
                    HeaderText="Opciones"
                    DataNavigateUrlFields="EstudianteId"
                    DataNavigateUrlFormatString="/Registros/rEstudianteWF.aspx?Id={0}"
                    Text="Editar"></asp:HyperLinkField>
            </Columns>
            <HeaderStyle BackColor="Green" Font-Bold="true" ForeColor="black" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:GridView>
    </div>
</asp:Content>
