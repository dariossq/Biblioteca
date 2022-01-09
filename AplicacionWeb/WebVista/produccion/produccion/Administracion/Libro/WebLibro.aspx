<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/produccion/masterPrincipal.Master" AutoEventWireup="true" CodeBehind="WebLibro.aspx.cs" Inherits="WebVista.produccion.produccion.Administracion.Libro.WebLibro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    
        <asp:HiddenField ID="HfLibroId" runat="server" />
    <asp:HiddenField ID="HfAutorId" runat="server" />
       
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="messagealert" id="alert_container">
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnRegistrar" />
        </Triggers> 
         <Triggers>
            <asp:PostBackTrigger ControlID="BtnActualiza" />
        </Triggers> 
         
          <Triggers>
            <asp:PostBackTrigger ControlID="BtnEliminar" />
        </Triggers> 
    </asp:UpdatePanel>
   

        <div class="right_col" role="main">
            <p>Libros registrados</p>
            <div class="">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_content">
                                <div class="form-horizontal form-label-left">
                                    <div class="x_title">
                                        <h2>Libro</h2>
                                        <ul class="nav navbar-right panel_toolbox">
                                            <li class="dropdown"></li>
                                        </ul>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Libro">
                                            Titulo<span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="TxtTitulo" runat="server" class="form-control col-md-7 col-xs-12" MaxLength="50"
                                                ToolTip="Título del libro" placeholder="Wish" required="required"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Libro">
                                            Año<span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">

                                            <asp:TextBox ID="TxtAnio" runat="server" placeholder="yyyy" Format="yyyy" CssClass="form-control"
                                                ToolTip="Año (Año)"
                                                MaxLength="10"></asp:TextBox>

                                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtAnio"
                                                Format="yyyy"></ajaxtoolkit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                ControlToValidate="TxtAnio" CssClass="mensaje" ErrorMessage="***" ForeColor="Red"
                                                ValidationGroup="GUARDAR">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Libro">
                                            Genero <span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="TxtGenro" runat="server" class="form-control col-md-7 col-xs-12" MaxLength="50"
                                                ToolTip="Genero" placeholder="Accion" required="required"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Libro">
                                            Número de páginas<span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="TxtPaginas" runat="server" class="form-control col-md-7 col-xs-12" MaxLength="1000" ToolTip="12"
                                                placeholder="12" required="required"></asp:TextBox>
                                        </div>
                                    </div>

                                      <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Libro">
                                            Autor<span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                           
                                        <asp:DropDownList ID="DdlAutor" runat="server" AutoPostBack="true" AppendDataBoundItems="True" CssClass="form-control"
                                            ToolTip="Lista de Autores" >
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="mensaje"
                                            ErrorMessage="***" ControlToValidate="DdlAutor" ForeColor="Red"
                                            ValidationGroup="GUARDAR">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                       




                                    </div>
                                    <div class="item form-group">     
    <div class="ln_solid"></div>

                                    <div class="item form-group">
                                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Autor">
                                            Buscar Libro
                                        </label>
                                       
                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                            <asp:DropDownList ID="DdlLibro" runat="server" AutoPostBack="true" AppendDataBoundItems="True" CssClass="form-control"
                                            ToolTip="Lista de Libros" OnSelectedIndexChanged="DdlLibro_SelectedIndexChanged">
                                        </asp:DropDownList>
                                       
                                            </div>
                                         </div>
                                    </div>

                                    <div class="ln_solid"></div>
                                    <div class="form-group">
                                        <div class="col-md-6 col-md-offset-3">
                                            <!--Campo botoneras-->
                                            <asp:Button ID="BtnRegistrar" runat="server" Text="REGISTRAR" Visible="true" ToolTip="Botón para realizar un registro" CssClass="btn btn-primary" ValidationGroup="GUARDAR" OnClick="BtnRegistrar_Click" />
                                            <asp:Button ID="BtnActualiza" runat="server" Text="ACTIALIZAR" Visible="false" ToolTip="Botón para actualizar un registro" CssClass="btn btn-success" ValidationGroup="GUARDAR" OnClick="BtnActualiza_Click" />
                                            <asp:Button ID="BtnCancelar" runat="server" Text="CANCELAR" Visible="true" ToolTip="Botón para cancelar todo tipo de proceso" CssClass="btn btn-danger" OnClick="BtnCancelar_Click" />
                                            <asp:Button ID="BtnEliminar" runat="server" Text="ELIMINAR" Visible="false" ToolTip="botón para eliminar un registro seleccionado" CssClass="btn btn-dark" OnClick="BtnEliminar_Click" />
                                                                                    </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                                    </div>
                <div class="x_panel">
                    <div class="row">

                        <div class="x_title">
                            <h2>Lista de Autores registrados <small></small></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="table-responsive">
                            <table id="datatable" class="table table-striped table-bordered">
                                
                                <asp:GridView ID="GvDatos" runat="server" Height="14px" Width="991px" Style="text-transform: uppercase"
                                    EmptyDataText=""
                                    HorizontalAlign="Center"
                                    CellPadding="1"
                                    CssClass="table table-striped table-bordered table-hover dataTable"
                                    Font-Size="X-Small" ForeColor="Black" GridLines="Vertical"
                                    PageSize="100" ShowFooter="True" ShowHeaderWhenEmpty="True"
                                    ViewStateMode="Enabled" UseAccessibleHeader="False"
                                    AutoGenerateColumns="False"
                                    DataKeyNames="ID_LIBRO, TITULO , ANO, GENERO , NUMERO_PAGINAS , ID_AUTOR"
                                    OnSelectedIndexChanged="GvDatos_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" ForeColor="Black" Height="12px"
                                        Wrap="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" HeaderText="SELECT"
                                            SelectImageUrl="~/produccion/images/edit.png" ShowSelectButton="True">
                                            <ItemStyle Width="25px" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID_LIBRO" HeaderText="ID_LIBRO" Visible="true" />
                                        <asp:BoundField DataField="ID_AUTOR" HeaderText="ID_AUTOR" Visible="true" />

                                        <asp:BoundField DataField="TITULO" HeaderText="TITULO">
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ANO" HeaderText="Año" DataFormatString="{0:d}">
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GENERO" HeaderText="GENERO">
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NUMERO_PAGINAS" HeaderText="NUMERO_PAGINAS">
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BackColor="White" />
                                    <FooterStyle BackColor="#006699" Font-Bold="True" ForeColor="White"
                                        HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"
                                        Height="10px" HorizontalAlign="Center" VerticalAlign="Top" Width="10px"
                                        Wrap="False" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="Black" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                                                
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
