<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FiltroPConE.ascx.vb" Inherits="CtrlUsr_FiltroPCon_FiltroPConE" %>
  
    <style type="text/css">
        .stylefp
        {
            width: 229px;
        }
        .txt
        {}
    </style>
  
    <table style="width: 80%">
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                            <asp:CheckBox ID="ChkNProc" runat="server" AutoPostBack="True" 
                                Text="N° de Proceso" />
                            
                        </td>
            <td>
                            <asp:TextBox ID="TxtNProc" runat="server" Width="180px" AutoPostBack="True" 
                                 ></asp:TextBox>
                        </td>
        </tr>
        <tr><td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">

                            <asp:CheckBox ID="ChkTproc" runat="server" AutoPostBack="True" 
                                Text="Modalidad de Contratación" />
                            
                        </td>
            <td>
                            <asp:DropDownList ID="CboTproc" runat="server" CssClass="txt" 
                                DataSourceID="ObjTipoProc" DataTextField="Nom_TProc" DataValueField="Cod_TProc" 
                                ToolTip="Proceso PreContractual" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
        </tr>
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                            <asp:CheckBox ID="ChkDep" runat="server" AutoPostBack="True" 
                                Text="Dependencia que Genera la Necesidad" />
                            
                        </td>
            <td>
                            <asp:DropDownList ID="cboDep" runat="server" DataSourceID="ObjDep" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="85%" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
        </tr>
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                            <asp:CheckBox ID="ChkDepP" runat="server" AutoPostBack="True" 
                                Text="Dependencia a Cargo del Proceso" Checked="True" Enabled="False" />
                            
                        </td>
            <td>
                            <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="85%" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                            <asp:CheckBox ID="ChkObj" runat="server" AutoPostBack="True" 
                                Text="Objeto a Contratar" />
                        </td>
            <td>
                            <asp:TextBox ID="TxtObj" runat="server" CssClass="txt" Height="39px" 
                                TextMode="MultiLine" Width="100%" AutoPostBack="True"></asp:TextBox>
                        </td>
        </tr>
      
        <tr>
            <td colspan="3">
                <asp:Button ID="BtnFiltrar" runat="server" Text="Filtrar" Visible="False" />
                            <asp:Label ID="LbFiltro" runat="server"></asp:Label>
                        </td>
        </tr>
          </table>
    
    <asp:ObjectDataSource ID="ObjDep" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Dependencias"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjDepDel" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelbyUser" 
            TypeName="Dependencias" DeleteMethod="Delete" 
            InsertMethod="AsignarAbogado" UpdateMethod="DAsignarAbogado">
            <DeleteParameters>
                <asp:Parameter Name="cod_dep" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Cod_Dep" Type="String" />
                <asp:Parameter Name="Ide_Ter" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ID_HDEP" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjTipoProc" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="TiposProc"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjPEstados" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyTproc" 
        TypeName="PEstados">
        <SelectParameters>
            <asp:ControlParameter ControlID="CboTproc" Name="Cod_Tpro" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

            