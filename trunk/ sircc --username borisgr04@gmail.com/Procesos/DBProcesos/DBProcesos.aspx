<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="true" AutoEventWireup="false" CodeFile="DBProcesos.aspx.vb" 
Inherits="Procesos_DBProceso_Default"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../../CtrlUsr/grdOblig/grdOblig.ascx" tagname="grdOblig" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/grdCDP/grdCDP.ascx" tagname="grdCDP" tagprefix="uc2" %>
<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>



<%@ Register src="../../CtrlUsr/grdProy/ConProyectos.ascx" tagname="ConProyectos" tagprefix="uc4" %>
<%@ Register src="../../CtrlUsr/Rubros/ConRubros.ascx" tagname="ConRubros" tagprefix="uc6" %>
<%@ Register src="../../CtrlUsr/Progreso/Progress.ascx" tagname="Progress" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <style>
    #navlist li
{
display: inline;
list-style-type: none;
padding-right: 20px;
}

    .style3
    {
        width: 291px;
    }

        .style31
        {
            width: 77px;
            text-align: center;
        }
        .style32
        {
            width: 80px;
            text-align: center;
        }

        .style33
        {
            width: 172px;
        }

        .style34
        {
            width: 358px;
        }

        .style35
        {
            width: 228px;
        }

        </style>
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        <script type="text/javascript">
                   
            function AporOtros(){
            
            var val1=document.aspnetForm.<%=Me.TxtValTot.ClientID%>.value;
            var Val2=document.aspnetForm.<%=Me.TxtValProp.ClientID%>.value;
            if (val1==''&& Val2==''){
            document.aspnetForm.<%=Me.TxtValOtros.ClientID%>.value=0;
            }
            else if (val1==''&& Val2!=''){
            document.aspnetForm.<%=Me.TxtValOtros.ClientID%>.value=(-parseFloat(Val2)).toFixed(2);
            }
            else if (val1!=''&& Val2==''){
            document.aspnetForm.<%=Me.TxtValOtros.ClientID%>.value=(parseFloat(val1)).toFixed(2);
            }
            else {
            document.aspnetForm.<%=Me.TxtValOtros.ClientID%>.value=(parseFloat(val1)-parseFloat(Val2)).toFixed(2);
            }
                              
            }
            
            function ValTotal(){
            
            var val1=document.aspnetForm.<%=Me.TxtValTot.ClientID%>.value;
            
            document.aspnetForm.<%=Me.TxtValTot.ClientID%>.value=(parseFloat(val1)).toFixed(2);
            document.aspnetForm.<%=Me.TxtValProp.ClientID%>.value=(parseFloat(val1)).toFixed(2);                        
            }
            
            function ValAporGob(){
            
            var val2=document.aspnetForm.<%=Me.TxtValProp.ClientID%>.value;
            
            document.aspnetForm.<%=Me.TxtValProp.ClientID%>.value=(parseFloat(val2)).toFixed(2);
                                    
            }
            
     </script>

        <asp:Label ID="Label10" runat="server" CssClass="Titulo" 
            Text="REGISTRO DE PROCESOS PRECONTRACTUALES"></asp:Label>
            <br />
        <br />
        
        <asp:UpdatePanel ID="UpdBarra" runat="server">
        <ContentTemplate>
        <table style="width: 100%">
            <tr>
                <td style="width: 41px">
                    <asp:ImageButton ID="IBtnNuevo" runat="server" Height="32px" 
                        ImageUrl="~/images/Operaciones/New1.png" Width="32px" Visible="False" />
                </td>
                <td style="width: 115px">
                    <asp:TextBox ID="TxtNprocA" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="width: 53px">
                    <asp:ImageButton ID="IBtnAbrir" runat="server" Height="32px" 
                        ImageUrl="~/images/mnProcesos/open-icon32.png" Width="32px" />
                </td>
                <td style="width: 53px">
                    <asp:ImageButton ID="IbtnBucar" runat="server" Height="32px" 
                        SkinID="IBtnBuscar" ValidationGroup="NoValida" Width="32px" />
                </td>
                <td style="width: 53px">
                    <asp:ImageButton ID="IbtnEditar" runat="server" Height="32px" 
                        ImageUrl="~/images/Operaciones/Edit2.png" Width="32px" />
                </td>
                <td style="width: 61px">
                    <asp:ImageButton ID="IBtnGuardar" runat="server" Height="32px" Width="32px" 
                        SkinID="IBtnGuardar" ValidationGroup="Guardar" />
                </td>
                <td style="width: 79px">
                    <asp:ImageButton ID="IBtnCancelar" runat="server" Height="32px" 
                        ImageUrl="~/images/mnProcesos/undo.png" Width="32px" />
                </td>
                <td style="width: 79px; text-align: center;">
                    <asp:ImageButton ID="IBtnDatosC" runat="server" SkinID="IBtnCont" />
                </td>
                <td style="width: 79px; text-align: center;">
                    <asp:ImageButton ID="IBtnDocumentos" runat="server" SkinID="IBtnArchivoD" />
                </td>
                <td style="width: 79px">
                    &nbsp;</td>
                <td class="style31">
                    <asp:ImageButton ID="BtnDefinitivo" runat="server" Height="32px" 
                        ImageUrl="~/images/Operaciones/Definitivo.png" ToolTip=", Validar los Datos y pasa el proceso a definitivo para generar minuta y radicar" 
                        Visible="False" Width="32px" />
                </td>
                <td class="style32">
                    <asp:ImageButton ID="BtnTramite" runat="server" Height="32px" 
                        ImageUrl="~/images/Operaciones/tramite.png" 
                        ToolTip="Revertir Validación y permite modificar datos al proceso." Visible="False" 
                        Width="32px" />
                </td>
                <td>
                    <asp:Button ID="BtnVerMinuta" runat="server" Text="Ver Minuta" 
                        Visible="False" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 41px">
                    &nbsp;</td>
                <td style="width: 115px">
                    &nbsp;</td>
                <td style="width: 53px">
                    Abrir</td>
                <td style="width: 53px">
                    Buscar</td>
                <td style="width: 53px">
                    Editar</td>
                <td style="width: 61px">
                    Guardar</td>
                <td style="width: 79px">
                    Cancelar</td>
                <td style="width: 79px; text-align: center;">
                    Datos
                    <br />
                    Contratos</td>
                <td style="width: 79px; text-align: center;">
                    Documentos<br /> PreContractuales</td>
                <td style="width: 79px">
                    &nbsp;</td>
                <td class="style31">
                    <asp:Label ID="LblDef" runat="server" Text="Validar" Visible="False" 
                        ToolTip="Validar los Datos y pasa el proceso a definitivo para generar minuta y radicar"></asp:Label>
                </td>
                <td class="style32">
                    <asp:Label ID="LblTra" runat="server" Text="Revertir " Visible="False" 
                        ToolTip="Revertir Validación y permite modificar datos al proceso."></asp:Label>
                </td>
                <td>
                    <asp:Button ID="BtnCargar" runat="server" Text="Cargar Datos" Visible="False" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 41px">
                    &nbsp;</td>
                <td style="width: 115px">
                    &nbsp;</td>
                <td style="width: 53px">
                    &nbsp;</td>
                <td style="width: 53px">
                    &nbsp;</td>
                <td style="width: 53px">
                    &nbsp;</td>
                <td style="width: 61px">
                    &nbsp;</td>
                <td style="width: 79px">
                    &nbsp;</td>
                <td style="width: 79px">
                    &nbsp;</td>
                <td style="width: 79px" colspan="2">
                    &nbsp;</td>
                <td colspan="3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                DisplayMode="List" ValidationGroup="Guardar" SkinID="validationsummary1" />

        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
           
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
                <table style="width: 100%">
                    <tr>
                        <td colspan="10"><a name="#DG"></a>
                            <asp:Label ID="Label3" runat="server" CssClass="SubTitulo"   Text="" Width="100%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label20" runat="server" CssClass="Caption" Text="N° de Proceso"></asp:Label>
                        </td>
                        <td colspan="4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:TextBox ID="TxtNProc" runat="server" Width="202px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" 
                                Enabled="True" TargetControlID="TxtNProc" WatermarkCssClass="watermarked" 
                                WatermarkText="DD-PPPP-CCCC-VVVV ">
                            </cc1:TextBoxWatermarkExtender>
                            <cc1:TextBoxWatermarkExtender ID="TxtNProc_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtNProc" 
                                WatermarkCssClass="watermarked" WatermarkText="Automático Número de Proceso">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label29" runat="server" CssClass="Caption" Text="Estado"></asp:Label>
                        &nbsp;<asp:Label ID="LbEstado" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label21" runat="server" CssClass="Caption" 
                                Text="Modalidad de Contratación"></asp:Label>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="2">
                            <asp:Label ID="Label26" runat="server" CssClass="Caption" 
                                Text="N° Planeación Precontractual" Visible="False"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="CboTproc" runat="server" CssClass="txt" 
                                DataSourceID="ObjTipoProc" DataTextField="Nom_TProc" DataValueField="Cod_TProc" 
                                ToolTip="Proceso PreContractual" Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="2">
                            <asp:TextBox ID="TxtNPla" runat="server" Width="200px" Visible="False"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtNPla_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtNPla" 
                                WatermarkCssClass="watermarked" WatermarkText="Numero de Planeación">
                            </cc1:TextBoxWatermarkExtender>
                            <ajaxToolkit:FilteredTextBoxExtender 
                            ID="FilteredTextBoxExtender5" 
                            runat="server" 
                            TargetControlID="TxtNPla" 
                            FilterType="Numbers">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label23" runat="server" CssClass="Caption" 
                                Text="Dependencia a Cargo del Proceso"></asp:Label>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="5">
                            <asp:Label ID="Label22" runat="server" CssClass="Caption" 
                                Text="Dependencia que Genera la Necesidad"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="5">
                            <asp:DropDownList ID="cboDep" runat="server" DataSourceID="ObjDep" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label27" runat="server" CssClass="Caption" 
                                Text="Tipo de Contratación"></asp:Label>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="5">
                            <asp:Label ID="Label28" runat="server" CssClass="Caption" 
                                Text="SubTipo de Contratación"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" CssClass="txt" 
                                DataSourceID="ObjTiposCont" DataTextField="Nom_Tip" DataValueField="Cod_Tip" 
                                Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="5">
                            <asp:DropDownList ID="cboStip" runat="server" CssClass="txt" 
                                DataSourceID="ObjSubTipos" DataTextField="nom_stip" DataValueField="cod_stip" 
                                Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label25" runat="server" CssClass="Caption" 
                                Text="Objeto a Contratar"></asp:Label>
                        </td>
                        <td colspan="8">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="9">
                            <asp:TextBox ID="TxtObj" runat="server" CssClass="txt" Height="68px" 
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <hr />
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Valor Total"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="TxtValTot" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender 
                            ID="FilteredTextBoxExtender1" 
                            runat="server" TargetControlID="TxtValTot" FilterType="Custom, Numbers" ValidChars=".">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                ControlToValidate="TxtValTot" 
                                ErrorMessage="Debe deligenciar el Valor del Contrato" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Valor aportes Propios"></asp:Label>
                        </td>
                        <td class="style33">
                            <asp:TextBox ID="TxtValProp" runat="server" Height="19px" Width="119px"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender 
                            ID="FilteredTextBoxExtender2" 
                            runat="server" TargetControlID="TxtValProp" FilterType="Custom, Numbers" ValidChars=".">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                ControlToValidate="TxtValProp" 
                                ErrorMessage="Debe diligenciar el Valor de los Aportes Propios" 
                                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="style34">
                            <asp:Label ID="Label12" runat="server" Text="Valor aportes Otros"></asp:Label>
                        </td>
                        <td>
                            <b>
                            <asp:TextBox ID="TxtValOtros" runat="server" ReadOnly="True"></asp:TextBox>
                            </b>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 171px">
                            <asp:Label ID="Label46" runat="server" Text="Número de Contratos"></asp:Label>
                        </td>
                        <td class="style41" colspan="2">
                            <asp:TextBox ID="TxtNumGrupos" runat="server" Width="39px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TxtNumGrupos_FilteredTextBoxExtender" 
                                runat="server" FilterType="Numbers" TargetControlID="TxtNumGrupos">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td style="width: 171px">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td class="style33">
                            &nbsp;</td>
                        <td class="style34">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 171px">
                            &nbsp;</td>
                        <td colspan="6">
                            &nbsp;</td>
                        <td class="style34">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 171px">
                            &nbsp;</td>
                        <td colspan="6">
                            &nbsp;</td>
                        <td class="style34">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" class="style35">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="2" style="text-align: right">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="9">
                        
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>

        </ContentTemplate>
        </asp:UpdatePanel>                
<asp:UpdateProgress ID="UpdateProgressGral" runat="server" 
AssociatedUpdatePanelID="UpdatePanel1">
<progresstemplate>
<uc3:Progress ID="Progress2" runat="server" />
</progresstemplate>
</asp:UpdateProgress>  

            <asp:ObjectDataSource ID="ObjDep" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Dependencias"></asp:ObjectDataSource>
        
        <asp:ObjectDataSource ID="ObjDepDel" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelbyUser" 
            TypeName="Dependencias" DeleteMethod="Delete" 
            InsertMethod="AsignarAbogado" UpdateMethod="DAsignarAbogado">
            </asp:ObjectDataSource>
        
        <asp:ObjectDataSource ID="ObjTiposCont" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Tipos"></asp:ObjectDataSource>
        
        <asp:ObjectDataSource ID="ObjSubTipos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByTipo" 
            TypeName="SubTipos">
            <SelectParameters>
                <asp:ControlParameter ControlID="CboTip" Name="cod_tip" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>           
    <asp:ObjectDataSource ID="ObjConMun" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPConMun" 
        TypeName="PContratos" InsertMethod="InsertP">
        <InsertParameters>
            <asp:Parameter Name="COD_TPRO" Type="String" />
            <asp:Parameter Name="OBJ_CON" Type="String" />
            <asp:Parameter Name="DEP_CON" Type="String" />
            <asp:Parameter Name="DEP_PCON" Type="String" />
            <asp:Parameter Name="VIG_CON" Type="Decimal" />
            <asp:Parameter Name="TIP_CON" Type="String" />
            <asp:Parameter Name="STIP_CON" Type="String" />
            <asp:Parameter Name="FEC_RECIBIDO" Type="DateTime" />
            <asp:Parameter Name="NUM_SOL" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtNProcA" Name="cod_con" PropertyName="Text" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjPrev_CDP" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Prev_cdp" InsertMethod="Insert">
        <InsertParameters>
            <asp:Parameter Name="Vigencia" Type="String" />
            <asp:Parameter Name="Num_Previo" Type="String" />
            <asp:Parameter Name="VIGENCIA_CDP" Type="String" />
            <asp:Parameter Name="NUM_CERTIFICADO" Type="String" />
            <asp:Parameter Name="FEC_EXPEDICION" Type="DateTime" />
            <asp:Parameter Name="VALOR_TOTAL" Type="Decimal" />
        </InsertParameters>
        </asp:ObjectDataSource>

      
         
                                        <asp:ObjectDataSource ID="TipoPago" runat="server" 
                                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                            TypeName="Tipo_Pagos"></asp:ObjectDataSource>

      
         
      

                                        <asp:ObjectDataSource ID="CDP" runat="server" 
                                            
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                            TypeName="CDP_PContratos">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="TxtNProcA" Name="Num_Pcon" PropertyName="Text" 
                                                    Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="ObjTipoProc" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="TiposProc"></asp:ObjectDataSource>
            
            
    <asp:ObjectDataSource ID="Polizas" runat="server" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Polizas" UpdateMethod="Update">
        <UpdateParameters>
            <asp:Parameter Name="Cod_Pol_O" Type="String" />
            <asp:Parameter Name="Cod_Pol" Type="String" />
            <asp:Parameter Name="Nom_Pol" Type="String" />
            <asp:Parameter Name="Est_Pol" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Cod_Pol" Type="String" />
            <asp:Parameter Name="Nom_Pol" Type="String" />
            <asp:Parameter Name="Est_Pol" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="calculopol" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                        TypeName="CalculoPol"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="Cal_Vig_Pol" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                        TypeName="Cal_Vig_Pol"></asp:ObjectDataSource>      
            
            
                            <asp:ObjectDataSource ID="Tipo_Plazos" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                TypeName="Tipo_Plazos"></asp:ObjectDataSource>
            
            
         <asp:Panel ID="PanelvConP" runat="server" BackColor="White" Width="900px" Height="500px">
            <asp:Panel ID="Panel6" runat="server" CssClass="BarTitleModal2" BorderColor="White" 
                Height="27px" Width="100%" >
                <table style="width:100%;">
                    <tr>
                        <td style="width: 1159px">
                            <asp:Label ID="LbTitModal" runat="server" ForeColor="White" Text=" Consulta de Procesos a Cargo" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 923px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar2" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
            <uc4:ConPContratos ID="ConPContratos1" runat="server" />
            
            </asp:Panel>
             </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Btn_Target2" runat="server"></asp:Button>
           <ajaxToolkit:ModalPopupExtender ID="ModalPopupConP" 
        runat="server"
        TargetControlID="Btn_Target2" 
        PopupControlID="PanelvConP" 
        CancelControlID="BtnCerrar2" 
        BackgroundCssClass="modalBackground"
        PopupDragHandleControlID="Panel4" 
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>   
             
            
</div>
</asp:Content>

