<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rEvaluacionWF.aspx.cs" Inherits="EvaluacionWF.Registro.rEvaluacionWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color: darkgray">
        <div class="form-row">

            <%-- Fecha Id--%>
            <div class="form-group col-md-offset-10">
                <label for="Fecha">Fecha</label>
                <asp:TextBox ID="FechaTextBox" runat="server" CssClass="form-control" TextMode="Date"> </asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="form-label-group form-control-lg">
                    <label for="LabelEvaluacion" class="col-md-1"><strong>Id</strong></label>
                    <asp:TextBox ID="EvaluacionTextBox" runat="server" Text="0" type="number" CssClass="col-md-7" />
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary col-md-3 offset-0" OnClick="Buscar_Click" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <label for="Estudiante">Estudiante</label>
                <asp:DropDownList ID="EstudianteDropDownList" runat="server" Class="form-control">
          
                </asp:DropDownList>
            </div>
            <!-- Button trigger modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">+</button>

            <!-- Modal -->
            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col">
                                    <div class="form-label-group form-control-lg">
                                        <label for="LabelId" class="col-md-1"><strong>Id</strong></label>
                                        <asp:TextBox ID="TextBoxEstuduanteId" runat="server" Text="0" type="number" CssClass="col-md-7" />
                                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary col-md-3 offset-0" OnClick="BuscarCliente_Click" />
                                    </div>
                                </div>
                            </div>

                              <div class="row">
                                <div class="col">
                                    <div class="form-label-group form-control-lg">
                                        <label for="LabelId" class="col-md-1"><strong>Nombres</strong></label>
                                        <asp:TextBox ID="NombreTextBox" runat="server" type="text" CssClass="col-md-8 offset-md-2" />
                                    </div>
                                </div>
                            </div>

                             <div class="row">
                                <div class="col">
                                    <div class="form-label-group form-control-lg">
                                        <label for="MatriculaLabel" class="col-md-1"><strong>Matricula</strong></label>
                                        <asp:TextBox ID="MatriculaTextBox" runat="server" type="text" CssClass="col-md-8 offset-md-2" />
                                    </div>
                                </div>
                            </div>

                             <div class="row">
                                <div class="col">
                                    <div class="form-label-group form-control-lg">
                                        <label for="PuntosPerdidosLabel" class="col-md-1"><strong>Perdidos</strong></label>
                                        <asp:TextBox ID="PuntosPerdidosTextBox" runat="server" type="numeric" ReadOnly="true" CssClass="col-md-8 offset-md-2" />
                                    </div>
                                </div>
                            </div>
                            `
                        </div>
                        <div class="modal-footer">
                           <div class="col">
                                <asp:Button ID="Button4" runat="server" Text="Limpiar" class=" btn btn-primary col-sm-2 offset-3" OnClick="LimpiarCliente_Click" />
                                <asp:Button ID="Button5" runat="server" Text="Guardar" class=" btn btn-success col-sm-2 " OnClick="GuardarCliente_Click" />
                                <asp:Button ID="Button6" runat="server" Text="Elimnar" class=" btn btn-danger col-sm-2 " OnClick="EliminarCliente_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>


        <div class="row">
            <div class="col">
                <label for="Categoria">Categoria</label>
                <asp:DropDownList ID="CategoriaDropDownList" runat="server" Class="form-control">
                </asp:DropDownList>
            </div>
             <!-- Button trigger modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#CategoriaModalCenter">+</button>

            <!-- Modal -->
            <div class="modal fade" id="CategoriaModalCenter" tabindex="-1" role="dialog" aria-labelledby="CategoriaModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="CategoriaModalLongTitle">Modal title</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col">
                                    <div class="form-label-group form-control-lg">
                                        <label for="LabelId" class="col-md-1"><strong>Id</strong></label>
                                        <asp:TextBox ID="CategoriaIdTextBox" runat="server" Text="0" type="number" CssClass="col-md-7" />
                                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary col-md-3 offset-0" OnClick="BuscarCategiria_Click" />
                                    </div>
                                </div>
                            </div>

                              <div class="row">
                                <div class="col">
                                    <div class="form-label-group form-control-lg">
                                        <label for="LabelNombreCategoria" class="col-md-1"><strong>Nombre</strong></label>
                                        <asp:TextBox ID="NombreCategoriaTextBox" runat="server" type="text" CssClass="col-md-8 offset-md-2" />
                                    </div>
                                </div>
                            </div>

                             <div class="row">
                                <div class="col">
                                    <div class="form-label-group form-control-lg">
                                        <label for="ValorLabel" class="col-md-1"><strong>Valor</strong></label>
                                        <asp:TextBox ID="ValorCategoriaTextBox" runat="server" type="number" CssClass="col-md-8 offset-md-2" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                           <div class="col">
                                <asp:Button ID="Button7" runat="server" Text="Limpiar" class=" btn btn-primary col-sm-2 offset-3" OnClick="LimpiarCategoria_Click" />
                                <asp:Button ID="Button8" runat="server" Text="Guardar" class=" btn btn-success col-sm-2 " OnClick="GuardarCategoria_Click" />
                                <asp:Button ID="Button9" runat="server" Text="Elimnar" class=" btn btn-danger col-sm-2 " OnClick="EliminarCategoria_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col">
                <label for="Valor">Valor</label>
                <asp:TextBox ID="ValorTextBox" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col">
                <label for="Logro">Logro</label>
                <asp:TextBox ID="LogradoTextBox" CssClass="form-control" runat="server" />
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:Button ID="Agregar" runat="server" Text="Agregar" OnClick="Agregar_Click" />
            </div>
        </div>

        <asp:GridView ID="GridView1" runat="server" class="table table-condensed  table-responsive" CellPadding="6" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:HyperLinkField ControlStyle-ForeColor="#0094ff"
                    HeaderText="Opciones"
                    DataNavigateUrlFields="DetalleEvaluacionId"
                    DataNavigateUrlFormatString="/Registro/rEvaluacionWF.aspx?Id={0}"
                    Text="Eliminar"></asp:HyperLinkField>
            </Columns>
            <HeaderStyle BackColor="#0094ff" Font-Bold="true" ForeColor="black" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:GridView>


        <div class="row">
            <div class="col">
                <asp:Label ID="Label2" runat="server" Text="Total"></asp:Label>
                <asp:TextBox ID="TotalTextBox" runat="server"></asp:TextBox>
            </div>
        </div>

        <hr />


        <div class="col">
            <asp:Button ID="Button1" runat="server" Text="Limpiar" class=" btn btn-primary col-sm-2 offset-3" OnClick="Limpiar_Click" />
            <asp:Button ID="Button2" runat="server" Text="Guardar" class=" btn btn-success col-sm-2 " OnClick="Guardar_Click" />
            <asp:Button ID="Button3" runat="server" Text="Elimnar" class=" btn btn-danger col-sm-2 " OnClick="Eliminar_Click" />
        </div>

    </div>

</asp:Content>
