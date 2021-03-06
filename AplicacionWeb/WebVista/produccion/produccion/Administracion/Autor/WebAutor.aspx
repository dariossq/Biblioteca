<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/produccion/masterPrincipal.Master" AutoEventWireup="true" CodeBehind="WebAutor.aspx.cs" Inherits="WebVista.produccion.produccion.Administracion.Autor.WebAutor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    
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
            <asp:PostBackTrigger ControlID="BtnCancelar" />
        </Triggers> 
          <Triggers>
            <asp:PostBackTrigger ControlID="BtnEliminar" />
        </Triggers> 
    </asp:UpdatePanel>
   

        <div class="right_col" role="main">
            <p>Autores registrados</p>
            <div class="">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_content">
                                <div class="form-horizontal form-label-left">
                                    <div class="x_title">
                                        <h2>Autores</h2>
                                        <ul class="nav navbar-right panel_toolbox">
                                            <li class="dropdown"></li>
                                        </ul>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Autor">
                                            Nombre completo<span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="TxtNombre" runat="server" class="form-control col-md-7 col-xs-12" MaxLength="50"
                                                ToolTip="Nombre del Autor" placeholder="Wish" required="required"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Autor">
                                            Fecha de Nacimiento<span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">

                                            <asp:TextBox ID="TxtFechaNacimiento" runat="server" placeholder="dd/mm/yyyy" Format="dd/MM/yyyy" CssClass="form-control"
                                                ToolTip="Fecha de nacimiento  (Dia/Mes/Año)"
                                                MaxLength="10"></asp:TextBox>

                                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtFechaNacimiento"
                                                Format="MM/dd/yyyy"></ajaxtoolkit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                ControlToValidate="TxtFechaNacimiento" CssClass="mensaje" ErrorMessage="***" ForeColor="Red"
                                                ValidationGroup="GUARDAR">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Autor">
                                            Ciudad de procedencia <span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="TxtCiudad" runat="server" class="form-control col-md-7 col-xs-12" MaxLength="50"
                                                ToolTip="Ciudad" placeholder="Popa..." required="required"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Autor">
                                            Mail<span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="TxtMail" runat="server" class="form-control col-md-7 col-xs-12" MaxLength="1000" ToolTip="ejemplo@..."
                                                placeholder="ejemplo@..." required="required"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="ln_solid"></div>

                                    <div class="item form-group">
                                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Autor">
                                            Buscar Autor
                                        </label>
                                       
                                        <div class="col-md-6 col-sm-6 col-xs-6">
                                            <asp:DropDownList ID="DdlAutor" runat="server" AutoPostBack="true" AppendDataBoundItems="True" CssClass="form-control"
                                            ToolTip="Lista de Autores" OnSelectedIndexChanged="DdlAutor_SelectedIndexChanged">
                                        </asp:DropDownList>
                                       
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
                                    DataKeyNames="ID_AUTOR, NOMBRE_COMPLETO, FECHA_NACIMIENTO, CIUDAD_PROCEDENCIA, CORREOELECTRONICO"
                                    OnSelectedIndexChanged="GvDatos_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" ForeColor="Black" Height="12px"
                                        Wrap="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" HeaderText="SELECT"
                                            SelectImageUrl="~/produccion/images/edit.png" ShowSelectButton="True">
                                            <ItemStyle Width="25px" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID_AUTOR" HeaderText="ID_AUTOR"
                                            Visible="false" />
                                        <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="Nombre completo">
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FECHA_NACIMIENTO" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}">
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CIUDAD_PROCEDENCIA" HeaderText="Ciudad Procedencia">
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CORREOELECTRONICO" HeaderText="Mail">
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
