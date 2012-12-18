<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Admin.aspx.vb" Inherits="Seguridad_Roles_Admin" title="Permisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<script src="../../Scripts/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8rc3.custom.min.js" type="text/javascript"></script>
    <link href="../../Styles/Estyle.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.fcbkcomplete.min.js" type="text/javascript"></script>
    <link href="../../Styles/fcbkcomplete.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#<%= txtUserName.ClientID  %>").autocomplete({
                delay: 1,
                minLength: 1,
                source: function (request, response) {
                    PageMethods.ObtieneNombres(request.term,
                            function (data) {
                                var nombres = (typeof data) == 'string' ? eval('(' + data + ')') : data;
                                response(nombres);
                            },
                            fnLlamadaError);
                }

            });
        });

        function fnLlamadaError(excepcion) { alert('Ha ocurrido un error al traer los nombres: ' + excepcion.get_message()); }
    </script>
    
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
        </ajaxToolkit:ToolkitScriptManager>
            <br />
       <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
               
            <table style="width: 774px; height: 106px">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label1" runat="server" 
                            Text="Administrador de Usuarios y Permisos" CssClass="Titulo"></asp:Label></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Digite
                        &nbsp;UserName y Nombre y Apellidos para Consultar</td>
                    <td colspan="1" style="width: 100px">
                        &nbsp;</td>
                    <td colspan="1" style="width: 129px">
                        &nbsp;</td>
                    <td colspan="1" style="width: 148px">
                        &nbsp;</td>
                    <td style="width: 100px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
        <asp:TextBox ID="TxtUserName" runat="server" AutoPostBack="True" Width="500px"></asp:TextBox>
    <%--<ajaxToolkit:AutoCompleteExtender 
    ID="AutoCompleteExtender1" 
    TargetControlID="TxtUserName" MinimumPrefixLength="2"  DelimiterCharacters=";, :"
    runat="server" ServiceMethod="GetTerceros" UseContextKey="True" />
    --%>                </td>
                    <td style="width: 100px; text-align: center;">
                        <asp:ImageButton ID="ImageButton1" runat="server" SkinID="IBtnBuscar" />
                    </td>
                    <td style="width: 129px; text-align: center;">
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                            NavigateUrl="~/Seguridad/Usuarios/RegUsuarios.aspx" SkinID="HlnNuevo">Nuevo Usuario</asp:HyperLink>
                    </td>
                    <td style="width: 148px; text-align: center;">
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl="~/Seguridad/Roles/EnLinea.aspx" SkinID="HlnUsers">Ver Usuarios en Linea</asp:HyperLink>
                    </td>
                    <td style="width: 100px; text-align: center;">
                        <asp:ImageButton ID="IBtnRoles" runat="server" SkinID="IBtnRoles" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td style="width: 100px; text-align: center;">
                        Consulta</td>
                    <td style="width: 129px; text-align: center;">
                        Nuevo Usuario</td>
                    <td style="width: 148px; text-align: center;">
                        Usuario En Linea</td>
                    <td style="width: 100px; text-align: center;">
                        Sincronizar Roles/Opciones</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Label ID="msgResult2" runat="server" SkinID="MsgResult"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:ObjectDataSource ID="ObjModulos" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Modulos"></asp:ObjectDataSource>
                        <asp:HiddenField ID="HdFiltro" runat="server" />
                        <asp:ObjectDataSource ID="ObjUser" runat="server" SelectMethod="GetRecords" TypeName="Usuarios">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtUserName" Name="busc" PropertyName="Text" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataSourceID="ObjUser" Width="799px" 
                            DataKeyNames="username" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
                                <asp:BoundField DataField="Nom_Ter" HeaderText="Apellidos y Nombres" 
                                    SortExpression="Nom_Ter" />
                                <asp:BoundField DataField="LastLockoutDate" HeaderText="LastLockoutDate" ReadOnly="True"
                                    SortExpression="LastLockoutDate" />
                                <asp:BoundField DataField="CreateDate" HeaderText="Fecha de Creaci&#243;n" ReadOnly="True"
                                    SortExpression="CreateDate" />
                                <asp:BoundField DataField="Perfil" HeaderText="Perfil Desktop" />
                                <asp:TemplateField HeaderText="Activo" SortExpression="ISAPPROVED">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxA" runat="server" 
                                            Checked='<%# IIF(Container.DataItem("ISAPPROVED")=1,true,false) %>' 
                                            Enabled="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="ISLOCKEDOUT" HeaderText="Bloqueado">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxL" runat="server" Checked='<%# IIF(Container.DataItem("ISLOCKEDOUT")=1,true,false) %>' 
                                            Enabled="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                                    ShowSelectButton="True" />
                                <asp:ButtonField CommandName="activar" Text="Activar/Inactivar" />
                                <asp:ButtonField CommandName="desbloquear" Text="Desbloquear" />
                                <asp:ButtonField CommandName="AdminDesktop" Text="AdminDesktop" />
                            </Columns>
                        </asp:GridView>

                         </asp:View>
                <asp:View ID="View2" runat="server">
                        <asp:Label ID="Label2" runat="server" 
                            Text="Autorización de Opciones a Usuario" CssClass="Titulo"></asp:Label>&nbsp;<br />
                        Usuario:<asp:Label ID="LbUsuarios" runat="server" Font-Bold="True"></asp:Label>
                        <table >
                        <tr>
                            <td>
                        Módulo</td>
                            <td>
            <asp:DropDownList ID="CboMod" runat="server" DataTextField="Nom_Mod" 
                DataValueField="Cod_Mod" DataSourceID="ObjModulos" AutoPostBack="True">
            </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:ImageButton ID="IBtnGuardar" runat="server" SkinID="IBtnGuardar" />
                            </td>
                            <td>
                                <asp:ImageButton ID="BtnCancelar" runat="server" SkinID="IBtnCancelar" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                Guardar</td>
                            <td>
                                Volver</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
           </table>
                        &nbsp;<asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                        <div style="height:300px; overflow:auto">
        <table style="width: 693px; height: 331px">
            <tr>
                <td valign="top" colspan="3">
                                        <asp:TreeView ID="Tvw" runat="server" ImageSet="Arrows" ShowCheckBoxes="Root" ShowLines="True" Height="100%" Width="400px">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
            </tr>
       </table>
 </asp:View>
                </asp:MultiView>
    </div>
      <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        
    
    </div>

</asp:Content>

