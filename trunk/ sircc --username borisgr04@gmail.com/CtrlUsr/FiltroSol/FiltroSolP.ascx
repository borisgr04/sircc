<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FiltroSolP.ascx.vb" Inherits="CtrlUsr_FiltroSol_FiltroSolP" %>
  
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
                                Text="Codigo de la Solicitud" />
                            
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
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                            <asp:CheckBox ID="ChkTipDoc" runat="server" AutoPostBack="True" 
                                Text="Tipo de Documento" />
                            
                        </td>
            <td>
                            <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" CssClass="txt" 
                                DataSourceID="ObjTiposCont" DataTextField="Nom_Tip" 
                                DataValueField="Cod_Tip">
                            </asp:DropDownList>
                        </td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                            <asp:CheckBox ID="ChkClase" runat="server" AutoPostBack="True" 
                                Text="Clase de Contratación" />
                            
                        </td>
            <td>
                            <asp:DropDownList ID="cboStip" runat="server" CssClass="txt" 
                                DataSourceID="ObjSubTipos" DataTextField="nom_stip" 
                                DataValueField="cod_stip" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                            <asp:CheckBox ID="ChkEnc" runat="server" AutoPostBack="True" 
                                Text="Encargado" />
                            
                        </td>
            <td>
                            <asp:DropDownList ID="CboEnc" runat="server" DataSourceID="ObjTerceros" 
                                DataTextField="Nom_Ter" DataValueField="Ide_Ter" AutoPostBack="True" 
                                AppendDataBoundItems="True">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                            <asp:CheckBox ID="ChkConcepto" runat="server" AutoPostBack="True" 
                                Text="Estado Solicitud" />
                            
                        </td>
            <td>
                 <asp:DropDownList ID="CboConcepto" runat="server" Width="108px" 
                     AutoPostBack="True">
                                        <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="P">PENDIENTE</asp:ListItem>
                                        <asp:ListItem Value="A">ACEPTADO</asp:ListItem>
                                        <asp:ListItem Value="R">RECHAZADO</asp:ListItem>
                                    </asp:DropDownList>
                        </td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                            <asp:CheckBox ID="ChkFechaRec" runat="server" AutoPostBack="True" 
                                Text="Fecha de Recibido" />
                            
                        </td>
            <td>
                            Desde
                            <asp:TextBox ID="TxtF1" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="TxtF1_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TxtF1">
                            </ajaxToolkit:CalendarExtender>
&nbsp;Hasta
                            <asp:TextBox ID="TxtF2" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="TxtF2_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TxtF2">
                            </ajaxToolkit:CalendarExtender>
                        </td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                            <asp:CheckBox ID="ChkNProceso" runat="server" AutoPostBack="True" 
                                Text="N° de Proceso" />
                            
                        </td>
            <td>
                            <asp:TextBox ID="TxtNProceso" runat="server" AutoPostBack="True"></asp:TextBox>
                        </td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                            <asp:CheckBox ID="ChkEstProc" runat="server" AutoPostBack="True" 
                                Text="Estado del Proceso" />
                            
                        </td>
            <td>
                                            <asp:DropDownList ID="cboEstProc" runat="server" DataSourceID="ObjEstProc" 
                                                DataTextField="Nom_Est" DataValueField="Nom_Est" 
                                AutoPostBack="True">
                                            </asp:DropDownList>
                        </td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                            &nbsp;</td>
            <td>
                            &nbsp;</td>
        </tr>
      
        <tr>
            <td style="text-align: center;" colspan="3">
                <asp:Button ID="BtnFiltrar" runat="server" Text="Filtrar" />
                            </td>
        </tr>
        <tr>
            <td colspan="3">
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
        <asp:ObjectDataSource ID="ObjTiposCont" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Tipos"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjSubTipos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByTipo" 
            TypeName="SubTipos" InsertMethod="Insert" UpdateMethod="Update">
            <UpdateParameters>
                <asp:Parameter Name="Cod_Stip_O" Type="String" />
                <asp:Parameter Name="Cod_Stip" Type="String" />
                <asp:Parameter Name="Nom_Stip" Type="String" />
                <asp:Parameter Name="Cod_Tip" Type="String" />
                <asp:Parameter Name="Cla_Con_Dep" Type="String" />
                <asp:Parameter Name="Crt_F20_1A" Type="String" />
                <asp:Parameter Name="Cla_Con_Dp" Type="String" />
                <asp:Parameter Name="Estado" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="CboTip" Name="cod_tip" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Cod_Stip" Type="String" />
                <asp:Parameter Name="Nom_Stip" Type="String" />
                <asp:Parameter Name="Cod_Tip" Type="String" />
                <asp:Parameter Name="Cla_Con_Dep" Type="String" />
                <asp:Parameter Name="Crt_F20_1A" Type="String" />
                <asp:Parameter Name="Cla_Con_Dp" Type="String" />
                <asp:Parameter Name="estado" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="ObjEstProc" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
    TypeName="PEstados"></asp:ObjectDataSource>


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

            <asp:ObjectDataSource ID="ObjTerceros" runat="server" 
    SelectMethod="GetTercerosxDep" TypeName="Terceros" DeleteMethod="Delete" 
    OldValuesParameterFormatString="original_{0}" 
    InsertMethod="AsignarAbogado">
                <DeleteParameters>
                    <asp:Parameter Name="Ide_ter" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Id_Ter" Type="String" />
                    <asp:Parameter Name="Id_Miembro" Type="String" />
                    <asp:Parameter Name="Id_Estado" Type="String" />
                </InsertParameters>
    <SelectParameters>
        <asp:Parameter Name="busc" Type="String" />
        <asp:ControlParameter ControlID="CboDepP" Name="cod_dep" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>