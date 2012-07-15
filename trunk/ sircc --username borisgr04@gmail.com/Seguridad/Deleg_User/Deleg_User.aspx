<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Deleg_User.aspx.vb" Inherits="Seguridad_Deleg_User_Deleg_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        

    <asp:Label id="msgResult" runat="server" Width="90%" Height="30px"  
            Visible="True"></asp:Label>&nbsp;<table >
    <tr ><td style="WIDTH: 84px" ><asp:Label id="Label1" runat="server"  Text="Usuario"></asp:Label></td>
        <td >
    <asp:TextBox id="TxtUsername" runat="server" Width="150px" 
        AutoPostBack="True"></asp:TextBox>&nbsp; 
    <asp:ImageButton id="ImageButton1" onclick="ImageButton1_Click" runat="server" 
         ToolTip="Boton Buscar" ValidationGroup="BusTer" 
        SkinID="IBtnBuscar" Height="22px" Width="25px"></asp:ImageButton>
         <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"  ControlToValidate="TxtUsername" ErrorMessage="Seleccione un Tercero">*</asp:RequiredFieldValidator> 
         
          <asp:TextBox id="TxtRazSoc" runat="server" Width="223px" Enabled="False"></asp:TextBox> </td>
        <td >
            <asp:Label ID="LbIsUser" runat="server"></asp:Label>
        </td></tr>
    <tr ><td style="WIDTH: 84px" >&nbsp;</td>
        <td >
            &nbsp;</td>
        <td >
            &nbsp;</td></tr>
    <tr ><td style="WIDTH: 84px" >&nbsp;</td>
        <td >
            <asp:GridView ID="GridView1" runat="server" Width="589px"  AllowSorting="False"
                DataSourceID="ObjUsuDel" GridLines="None"
                CellPadding="4" DataKeyNames="Cod_dep" 
                AutoGenerateColumns="False" 
                EmptyDataText="Digite la Identificación del Usuario y Presiones el Botón Buscar" EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderText="Seleccionar">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkEst" runat="server" Checked='<%# eval("est") %>' />
                         <asp:HiddenField ID="HdEst" runat="server" Value='<%# Eval("estado") %>' />
                         <asp:HiddenField ID="hdcod_dep" runat="server" Value='<%# Eval("Cod_Dep") %>' />
                         <asp:HiddenField ID="hdID_HDEP" runat="server" Value='<%# Eval("ID_HDEP") %>' />
                         <asp:HiddenField ID="HdAsigProc" runat="server" Value='<%# MostrarBool(eval("asig_proc")) %>' />
                         <asp:HiddenField ID="HdCoord" runat="server" Value='<%# MostrarBool(Eval("Coordinador")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre Dependencia" >
                        <ItemTemplate>
                            <asp:Label ID="LbNom" runat="server" Text='<%# Bind("Nom_Dep") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Maneja Procesos" >
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkAsigProc" runat="server" Checked='<%# MostrarBool(eval("asig_proc")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Coordinador" >
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkCoord" runat="server" Checked='<%# MostrarBool(eval("coordinador")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                 
                </Columns>
            </asp:GridView>


            <asp:ObjectDataSource ID="ObjUsuDel" runat="server" 
        OldValuesParameterFormatString="" SelectMethod="GetDepDel" 
        TypeName="UsuDel">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtUsername" Name="ide_ter" PropertyName="Text" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

        </td>
        <td >
            &nbsp;</td></tr>
    <tr ><td style="WIDTH: 84px" >&nbsp;</td>
        <td style="text-align: center" >
                            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" />

        </td>
        <td >
            &nbsp;</td></tr>
     </table>
     </ContentTemplate>
        </asp:UpdatePanel>


</div>
</asp:Content>

