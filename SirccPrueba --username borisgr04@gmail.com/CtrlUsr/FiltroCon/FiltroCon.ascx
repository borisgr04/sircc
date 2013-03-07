<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FiltroCon.ascx.vb" Inherits="CtrlUsr_FiltroCon" %>
  
    <style type="text/css">
        .stylefp
        {
            width: 229px;
        }
        .txt
        {}
        .style1
        {
            width: 172px;
        }
        .style3
        {
        }
        .style4
        {
            width: 183px;
        }
    </style>
  
    <table style="width: 80%">
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                            <asp:CheckBox ID="ChkVig" runat="server" AutoPostBack="True" 
                                Text="Vigencia" Checked="True" Enabled="False" />
                            
                        </td>
            <td colspan="3">
                <asp:DropDownList ID="CmbVigencia" runat="server" Width="142px" 
                    DataSourceID="ObjVigencias" DataTextField="Year_Vig" 
                    DataValueField="Year_Vig">
                </asp:DropDownList>
                        </td>
        </tr>
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                            <asp:CheckBox ID="ChkNProc" runat="server" AutoPostBack="True" 
                                Text="N° de Contrato" />
                            
                        </td>
            <td colspan="3">
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
            <td colspan="3">
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
            <td colspan="3">
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
                                Text="Dependencia a Cargo del Proceso" />
                            
                        </td>
            <td colspan="3">
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
            <td colspan="3">
                            <asp:TextBox ID="TxtObj" runat="server" CssClass="txt" Height="39px" 
                                TextMode="MultiLine" Width="100%" AutoPostBack="True"></asp:TextBox>
                        </td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                <asp:CheckBox ID="ChkFecSus" runat="server" Text="Fecha de Suscripción" 
                    ToolTip="Fecha de Suscripción del Contrato" Width="208px" 
                    Font-Bold="False" AutoPostBack="True" />
                        </td>
            <td class="style1">
                Desde
                <asp:TextBox ID="TxtFecSus1" runat="server" Height="19px" 
                    Width="125px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender 
                            ID="CalTxtFecSus1" 
                            runat="server" 
                            TargetControlID="TxtFecSus1" 
                            Format="dd/MM/yyyy"> 
                            </ajaxToolkit:CalendarExtender>
                        </td>
            <td class="style4">
                Hasta
                <asp:TextBox ID="TxtFecSus2" runat="server" Width="125px" 
                    Height="20px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender 
                            ID="CalendarExtender1" 
                            runat="server" 
                            TargetControlID="TxtFecSus2" 
                            Format="dd/MM/yyyy"> 
                            </ajaxToolkit:CalendarExtender>
                        </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                <asp:CheckBox ID="ChkFecR" runat="server" Text="Fecha de Registro" 
                    ToolTip="Fecha de Suscripción del Contrato" Width="208px" 
                    Font-Bold="False" AutoPostBack="True" />
                        </td>
            <td class="style1">
                Desde
                <asp:TextBox ID="TxtFecReg1" runat="server" Height="19px" Width="125px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender 
                            ID="CalendarExtender2" 
                            runat="server" 
                            TargetControlID="TxtFecReg1" 
                            Format="dd/MM/yyyy"> 
                            </ajaxToolkit:CalendarExtender>
                        </td>
            <td class="style4">
                Hasta
                <asp:TextBox ID="TxtFecReg2" runat="server" Height="20px" Width="125px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender 
                            ID="CalendarExtender3" 
                            runat="server" 
                            TargetControlID="TxtFecReg2" 
                            Format="dd/MM/yyyy"> 
                            </ajaxToolkit:CalendarExtender>
                        </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
      
        <tr>
            <td style="width: 20px">
                            &nbsp;</td>
            <td class="stylefp">
                           
                <asp:CheckBox ID="ChkValC" runat="server" Text="Valor del Contrato/Convenio" 
                    Width="197px" Font-Bold="False" AutoPostBack="True" />
                        </td>
            <td class="style1">
                Desde:<telerik:RadNumericTextBox ID="TxtValC1" Runat="server" Culture="es-CO" 
                    Skin="Default" Value="0" Width="125px" Height="19px">
                </telerik:RadNumericTextBox>

                        </td>
            <td class="style4">
                Hasta:<telerik:RadNumericTextBox ID="TxtValC2" Runat="server" Culture="es-CO" 
                    Value="0" Width="125px" Height="19px" Skin="Default">
                </telerik:RadNumericTextBox>
                        </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
      
        <tr>
            <td colspan="5" style="text-align: center">
                <asp:Button ID="BtnFiltrar" runat="server" Text="Filtrar" />
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

            <asp:ObjectDataSource ID="ObjVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Vigencias"></asp:ObjectDataSource>
        

            