<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EnLinea.aspx.vb" Inherits="Seguridad_Roles_EnLinea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>

<div class="demoarea">

        
        <div class="demoheading">
              Usuarios En Linea    </div>

<table cellpadding="10px" >
<tr>
<td>
            <div id="DIV5"  style="z-index: 101; overflow: auto; width: 900px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            >

                        <asp:GridView ID="GridView1" runat="server" 
        AllowPaging="True" AllowSorting="True" DataSourceID="ObjUser" Width="799px" 
                            DataKeyNames="username" EnableModelValidation="True">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                                    ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>

                             </div>

                             <asp:GridView ID="grdSession" runat="server" 
                AllowSorting="True" DataSourceID="ObjSession" EnableModelValidation="True">
                                 <Columns>
                                     <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                                 </Columns>
                        </asp:GridView>
                             <asp:ObjectDataSource ID="ObjSession" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetSession" 
                TypeName="BDDatos"></asp:ObjectDataSource>
                             </td></tr></table>
                        <asp:ObjectDataSource ID="ObjUser" runat="server" 
        SelectMethod="UsuariosEnLinea" TypeName="Usuarios" 
        OldValuesParameterFormatString="original_{0}">
                        </asp:ObjectDataSource>

</div>
</asp:Content>

