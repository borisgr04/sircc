<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FiltroSolE.ascx.vb" Inherits="CtrlUsr_FiltroSol_FiltroSolE" %>
  
    <style type="text/css">
        .stylefp
        {
            width: 229px;
        }
        .txt
        {}
        .style1
        {
            width: 20px;
            height: 24px;
        }
        .style2
        {
            width: 229px;
            height: 24px;
        }
        .style3
        {
            height: 24px;
        }
    </style>
  
    <table style="width: 80%">
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                            <asp:CheckBox ID="ChkNProc" runat="server" AutoPostBack="True" 
                                Text="Código de la Solicitud" />
                            
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
                                Text="Dependencia a Cargo de la Solicitud" Checked="True" 
                                Enabled="False" />
                            
                        </td>
            <td>
                            <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="85%" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
        </tr>
      
        <tr>
            <td class="style1">
                            </td>
            <td class="style2">
                            <asp:CheckBox ID="ChkTipProc" runat="server" AutoPostBack="True" 
                                Text="Tipo de Documento Contractual" />
                            
                        </td>
            <td class="style3">
                            <asp:DropDownList ID="CboTipProc" runat="server" DataSourceID="ObjTipProc" 
                                DataTextField="Nom_Tip" DataValueField="Cod_Tip" Width="85%" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                            <asp:CheckBox ID="ChkObj" runat="server" AutoPostBack="True" 
                                Text="Objeto de la Solicitud" />
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

            <asp:ObjectDataSource ID="ObjTipProc" runat="server" 
    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
    SelectMethod="GetRecords" TypeName="Tipos" UpdateMethod="Update">
                <InsertParameters>
                    <asp:Parameter Name="Cod_Tip" Type="String" />
                    <asp:Parameter Name="Nom_Tip" Type="String" />
                    <asp:Parameter Name="Est_Tip" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Cod_Tip_O" Type="String" />
                    <asp:Parameter Name="Cod_Tip" Type="String" />
                    <asp:Parameter Name="Nom_Tip" Type="String" />
                    <asp:Parameter Name="Est_Tip" Type="String" />
                </UpdateParameters>
</asp:ObjectDataSource>
        
        

            