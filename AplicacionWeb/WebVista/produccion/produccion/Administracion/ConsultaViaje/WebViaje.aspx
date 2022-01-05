<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/produccion/masterPrincipal.Master" AutoEventWireup="true" CodeBehind="WebViaje.aspx.cs" Inherits="WebVista.produccion.produccion.Administracion.ConsultaViaje.WebViaje" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="right_col" role="main">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="messagealert" id="alert_container">
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="BtnBuscarTodo" />
            </Triggers>
            <Triggers>
                <asp:PostBackTrigger ControlID="BtnBuscarViajes" />
            </Triggers>
        </asp:UpdatePanel>
        <p>Busqueda de viajes por empleado</p>
        <div class="">
            <div class="row">
                <%--<div class="col-md-12 col-sm-12 col-xs-12">--%>
                <div class="x_panel">
                    <div class="x_content">
                        <div class="form-horizontal form-label-left">
                            <div class="x_title">
                                <h2>Todos los campos obligatorios </h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li class="dropdown"></li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Viaje">
                                    Nombre Empleado <span class="required">*</span>
                                </label>

                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DdlPersona" runat="server" AppendDataBoundItems="True" CssClass="form-control" required="required"
                                                AutoPostBack="False"
                                                ToolTip="Lista de empleados">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="DdlPersona" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Viaje">
                                    Vehiculo <span class="required">*</span>
                                </label>

                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DdlVehiculo" runat="server" AppendDataBoundItems="True" CssClass="form-control" required="required"
                                                AutoPostBack="False"
                                                ToolTip="Lista de vehiculos">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="DdlVehiculo" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="vereda">
                                    Fecha <span class="required">*</span>
                                </label>
                                <div class="col-md-2 col-sm-2 col-xs-12">
                                    <asp:TextBox ID="TxtFecha" runat="server" placeholder="yyyy/mm/dd" Format="yyyy-MM-dd" CssClass="form-control" required="required"
                                        ToolTip="Fecha de de busqueda (Dia/Mes/Año)"
                                        MaxLength="10"></asp:TextBox>

                                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtFecha"
                                        Format="yyyy-MM-dd"></ajaxtoolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                        ControlToValidate="TxtFecha" CssClass="mensaje" ErrorMessage="***" ForeColor="Red"
                                        ValidationGroup="GUARDAR">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:Button ID="BtnBuscarTodo" runat="server" ToolTip="Botón para mostrar toda la informacion" Visible="false" OnClick="BtnBuscarTodo_Click" CssClass="btn btn-success" Text="Buscar Todo" />
                                    <asp:Button ID="BtnBuscarViajes" runat="server" ToolTip="Botón para actualizar información" Text="Buscar" OnClick="BtnBuscarViajes_Click" CssClass="btn btn-info" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- </div>--%>

                <%--<div class="clearfix"></div>  --%>

                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Viajes<small>Registros de viajes por Empleado</small></h2>
                                <div class="clearfix"></div>
                            </div>
                            <div class="table-responsive">
                                <table id="datatable" class="table table-striped table-bordered">

                                    <asp:GridView ID="GvDatos" class="table table-striped table-bordered" Width="100%" 
                                        runat="server" AutoGenerateColumns="True"
                                        CellPadding="1" DataKeyNames=""
                                        EmptyDataText="" Font-Size="X-Small" ForeColor="Black" GridLines="Vertical"
                                        Height="14px" HorizontalAlign="Center"
                                        PageSize="100"
                                        ShowFooter="True" ShowHeaderWhenEmpty="True" Style="text-transform: uppercase"
                                        UseAccessibleHeader="False" ViewStateMode="Enabled">
                                        <AlternatingRowStyle BackColor="White" ForeColor="Black" Height="12px"
                                            Wrap="True" />
                                        <Columns>

                                            <asp:CommandField ButtonType="Image" HeaderText="SELECT"
                                                SelectImageUrl="~/produccion/images/edit.png" ShowSelectButton="True">
                                                <ItemStyle Width="25px" />
                                            </asp:CommandField>
                                              <asp:BoundField DataField="ID_AUTOR" HeaderText="ID_AUTOR"
                                                Visible="false" />
                                            <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="Origen">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="FECHA_NACIMIENTO" HeaderText="Destino">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CIUDAD_PROCEDENCIA" HeaderText="Duracion de viaje">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CORREOELECTRONICO" HeaderText="Hora salida">
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
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
