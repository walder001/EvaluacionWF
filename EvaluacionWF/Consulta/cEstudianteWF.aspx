<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cEstudianteWF.aspx.cs" Inherits="EvaluacionWF.Consulta.cEstudianteWF" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
    <div class="container">
        <ul class="nav justify-content-center bg-success">
            <li>
                <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true"></a>

                <h5 class="text-light">Consulta Estudiante</h5>
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
                <asp:ListItem Text="Nombre" />
                <asp:ListItem Text="Matricula" />
                <asp:ListItem Text="Putos Perdidos" />
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
               <%--Imprimir--%>
            <div class="card-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <button type="button" class="btn btn-warning mt-4" data-toggle="modal" data-target=".bd-example-modal-lg">Imprimir</button>
                    </div>
                </div>
            </div>
            <!-- Modal para mi Reporte.// -->
            <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm" style="max-width: 600px!important; min-width: 300px!important">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">REPORTE ESTUDIANTE</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:ScriptManager runat="server" />
                            <%--Viewer--%>
                            <rsweb:ReportViewer ID="MyReportViewer" runat="server" ProcessingMode="Remote" Height="400px" Width="500px">
                                <ServerReport ReportPath="" ReportServerUrl="" />
                            </rsweb:ReportViewer>
                        </div>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
