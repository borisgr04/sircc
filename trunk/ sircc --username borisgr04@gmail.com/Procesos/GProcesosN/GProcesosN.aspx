<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="true" AutoEventWireup="false" CodeFile="GProcesosN.aspx.vb" 
Inherits="Procesos_GProcesoN_Default"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../../CtrlUsr/grdObliGP/grdObligGP.ascx" tagname="grdObligGP" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/grdCDPGP/grdCDPGP.ascx" tagname="grdCDPGP" tagprefix="uc2" %>
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

    .style1
    {
        width: 65px;
    }

    .style3
    {
        width: 291px;
    }

        .style4
        {
            width: 110px;
        }
        .style5
        {
            width: 6px;
            height: 34px;
        }
        .style6
        {
            width: 271px;
        }
        .style7
        {
            width: 608px;
        }

        .style9
        {
            width: 110px;
            height: 24px;
            text-align: left;
        }
        .style10
        {
            width: 6px;
            height: 24px;
        }
        .style11
        {
            width: 26px;
            height: 24px;
        }
        .style12
        {
            height: 24px;
        }
        .style13
        {
            width: 110px;
            height: 34px;
            text-align: left;
        }
        .style14
        {
            width: 26px;
            height: 34px;
        }
        .style15
        {
            height: 34px;
        }

        .style16
        {
        }

        .style17
        {
            width: 38px;
        }
        .style18
        {
            width: 20px;
        }

        .style19
        {
            width: 71px;
        }

        .style20
        {
            width: 147px;
        }

        .style21
        {
        }
        .style22
        {
            width: 114px;
        }
        .style23
        {
            width: 116px;
        }
        .style24
        {
            width: 252px;
        }

        .style25
        {
            width: 129px;
            height: 27px;
        }
        .style27
        {
            width: 116px;
            height: 27px;
        }
        .style28
        {
            width: 252px;
            height: 27px;
        }
        .style29
        {
            height: 27px;
        }

        .style30
        {
            width: 114px;
            height: 27px;
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

        .style34
        {
        }
        
        .style41
        {
            width: 126px;
        }

        .style42
        {
            width: 105px;
        }
        .style43
        {
            width: 322px;
        }

        .style44
        {
            width: 41px;
        }
        .style45
        {
            width: 77px;
        }
        .style46
        {
            width: 602px;
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
            function ValIVA(){
            var val1=document.aspnetForm.<%=Me.TxtValTot.ClientID%>.value;
            var Val2=document.aspnetForm.<%=Me.TxtValSinIva.ClientID%>.value;
            if (val1==''&& Val2==''){
            document.aspnetForm.<%=Me.TxtValIVA.ClientID%>.value=0;
            document.aspnetForm.<%=Me.TxtValSinIva.ClientID%>.value=(parseFloat(Val2)).toFixed(2);
            }
            else if (val1==''&& Val2!=''){
            document.aspnetForm.<%=Me.TxtValIVA.ClientID%>.value=(-parseFloat(Val2)).toFixed(2);
            document.aspnetForm.<%=Me.TxtValSinIva.ClientID%>.value=(parseFloat(Val2)).toFixed(2);
            }
            else if (val1!=''&& Val2==''){
            document.aspnetForm.<%=Me.TxtValIVA.ClientID%>.value=(parseFloat(val1)).toFixed(2);
            document.aspnetForm.<%=Me.TxtValSinIva.ClientID%>.value=(parseFloat(Val2)).toFixed(2);
            }
            else {
            document.aspnetForm.<%=Me.TxtValIVA.ClientID%>.value=(parseFloat(val1)-parseFloat(Val2)).toFixed(2);
            document.aspnetForm.<%=Me.TxtValSinIva.ClientID%>.value=(parseFloat(Val2)).toFixed(2);
            }
                              
            }
            function ValRub(){
            
            var val1=document.aspnetForm.<%=Me.TxtValRub.ClientID%>.value;
            
            document.aspnetForm.<%=Me.TxtValRub.ClientID%>.value=(parseFloat(val1)).toFixed(2);
                                    
            }
            
            function ValPago(){
            
            var val1=document.aspnetForm.<%=Me.TxtValPago.ClientID%>.value;
            
            document.aspnetForm.<%=Me.TxtValPago.ClientID%>.value=(parseFloat(val1)).toFixed(2);
                                    
            }
            function ValTotal(){
            
            var val1=document.aspnetForm.<%=Me.TxtValTot.ClientID%>.value;
            
            document.aspnetForm.<%=Me.TxtValTot.ClientID%>.value=(parseFloat(val1)).toFixed(2);
            document.aspnetForm.<%=Me.TxtValProp.ClientID%>.value=(parseFloat(val1)).toFixed(2);   
            document.aspnetForm.<%=Me.TxtValSinIva.ClientID%>.value=(parseFloat(val1)).toFixed(2);
            document.aspnetForm.<%=Me.TxtValIva.ClientID%>.value=(parseFloat(0)).toFixed(2);                    
            }
            function ValAporGob(){
            
            var val2=document.aspnetForm.<%=Me.TxtValProp.ClientID%>.value;
            
            document.aspnetForm.<%=Me.TxtValProp.ClientID%>.value=(parseFloat(val2)).toFixed(2);
            
                                    
            }
            
     </script>

        <asp:Label ID="Label10" runat="server" CssClass="Titulo" 
            Text="REGISTRO DE DATOS DEL CONTRATO"></asp:Label>
            <br />
        <br />
        
        <asp:UpdatePanel ID="UpdBarra" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td style="width: 41px">
                        <asp:ImageButton ID="IBtnNuevo" runat="server" Height="32px" 
                            ImageUrl="~/images/Operaciones/New1.png" Visible="False" Width="32px" />
                    </td>
                    <td style="width: 115px">
                        <asp:TextBox ID="TxtNprocA" runat="server" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td style="width: 115px">
                        <asp:DropDownList ID="CboGrupos" runat="server" DataSourceID="ObjGrupos" 
                            DataTextField="Grupos" DataValueField="Grupo" 
                            AutoPostBack="True">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjGrupos" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyProc" 
                            TypeName="Grupos">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtNprocA" Name="Num_Proc" PropertyName="Text" 
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
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
                        <asp:ImageButton ID="IBtnGuardar" runat="server" Height="32px" 
                            SkinID="IBtnGuardar" ValidationGroup="Guardar" Width="32px" />
                    </td>
                    <td style="width: 79px">
                        <asp:ImageButton ID="IBtnCancelar" runat="server" Height="32px" 
                            ImageUrl="~/images/mnProcesos/undo.png" Width="32px" />
                    </td>
                    <td class="style31">
                        <asp:ImageButton ID="BtnDefinitivo" runat="server" Height="32px" 
                            ImageUrl="~/images/Operaciones/Definitivo.png" 
                            ToolTip=", Validar los Datos y pasa el proceso a definitivo para generar minuta y radicar" 
                            Visible="False" Width="32px" />
                    </td>
                    <td class="style32">
                        <asp:ImageButton ID="BtnTramite" runat="server" Height="32px" 
                            ImageUrl="~/images/Operaciones/tramite.png" 
                            ToolTip="Revertir Validaci�n y permite modificar datos al proceso." 
                            Visible="False" Width="32px" />
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
                    <td style="width: 41px">
                        &nbsp;</td>
                    <td style="width: 115px">
                        &nbsp;</td>
                    <td style="width: 115px">
                        Grupos</td>
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
                    <td class="style31">
                        <asp:Label ID="LblDef" runat="server" Text="Validar" 
                            ToolTip="Validar los Datos y pasa el proceso a definitivo para generar minuta y radicar" 
                            Visible="False"></asp:Label>
                    </td>
                    <td class="style32">
                        <asp:Label ID="LblTra" runat="server" Text="Revertir " 
                            ToolTip="Revertir Validaci�n y permite modificar datos al proceso." 
                            Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="LnkProponentes" runat="server">Proponentes</asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="LnkAdj" runat="server">Adjudicaci�n</asp:LinkButton>
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
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
                    <td colspan="5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                DisplayMode="List" SkinID="validationsummary1" ValidationGroup="Guardar" />
            <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
        
        <asp:CheckBox ID="ChkEC" runat="server" Text="Estudio de Conveniencia" 
                                Width="150px" Visible="false"/>
        
        <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="-1"
            HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContentByA" FadeTransitions="false" FramesPerSecond="40" 
            TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
           <Panes>
               <ajaxToolkit:AccordionPane ID="AccordionPane7" runat="server">
                <Header><a href="" class="accordionLink"> 1. Datos B�sicos </a></Header>
                <Content>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table style="width: 100%">
                    <tr>
                        <td colspan="4"><a name="#DG"></a>
                            <asp:Label ID="Label3" runat="server" CssClass="SubTitulo"   Text="" Width="100%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label20" runat="server" CssClass="Caption" Text="N� de Proceso"></asp:Label>
                        </td>
                        <td colspan="3">
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
                                WatermarkCssClass="watermarked" WatermarkText="Autom�tico N�mero de Proceso">
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
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label21" runat="server" CssClass="Caption" 
                                Text="Modalidad de Contrataci�n"></asp:Label>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label26" runat="server" CssClass="Caption" 
                                Text="N� Planeaci�n Precontractual" Visible="false"></asp:Label>
                        </td>
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
                        <td>
                            <asp:TextBox ID="TxtNPla" runat="server" Width="200px" Visible="false"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtNPla_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtNPla" 
                                WatermarkCssClass="watermarked" WatermarkText="Numero de Planeaci�n">
                            </cc1:TextBoxWatermarkExtender>
                            <ajaxToolkit:FilteredTextBoxExtender 
                            ID="FilteredTextBoxExtender5" 
                            runat="server" 
                            TargetControlID="TxtNPla" 
                            FilterType="Numbers">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label23" runat="server" CssClass="Caption" 
                                Text="Dependencia a Cargo del Proceso"></asp:Label>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label22" runat="server" CssClass="Caption" 
                                Text="Dependencia que Genera la Necesidad"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:DropDownList ID="cboDep" runat="server" DataSourceID="ObjDep" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="250px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label27" runat="server" CssClass="Caption" 
                                Text="Tipo de Contrataci�n"></asp:Label>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label28" runat="server" CssClass="Caption" 
                                Text="SubTipo de Contrataci�n"></asp:Label>
                        </td>
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
                        <td>
                            <asp:DropDownList ID="cboStip" runat="server" CssClass="txt" 
                                DataSourceID="ObjSubTipos" DataTextField="nom_stip" DataValueField="cod_stip" 
                                Width="250px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label25" runat="server" CssClass="Caption" 
                                Text="Objeto a Contratar"></asp:Label>
                        </td>
                        <td colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:TextBox ID="TxtObj" runat="server" CssClass="txt" Height="68px" 
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <hr />
                <table style="width: 100%">
                <tr style="vertical-align:middle">
                        <td>
                            <asp:Label ID="Label19" runat="server" Text="Valor Total"></asp:Label>
                        </td>
                        <td >
                          
                        </td>
                        <td colspan="2" >
                          <asp:Label ID="Label30" runat="server" Text="Valor aportes Propios"></asp:Label>
                        </td>
                        <td colspan="2" >
                            
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Valor aportes Otros"></asp:Label>
                        </td>
                        <td >
                              
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%--<telerik:RadNumericTextBox ID="TxtValTot" runat="server" Skin="Forest">
                            </telerik:RadNumericTextBox>--%>
                            <asp:TextBox ID="TxtValTot" runat="server" AutoPostBack="true"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender 
                            ID="FilteredTextBoxExtender1" 
                            runat="server" TargetControlID="TxtValTot" FilterType="Custom, Numbers" ValidChars=".">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                ControlToValidate="TxtValTot" 
                                ErrorMessage="Debe deligenciar el Valor del Contrato" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                        <td >
                          <asp:Label ID="LbValTot"
                                runat="server" Text="Label"></asp:Label>    
                        </td>
                        <td colspan="2">
                         <asp:TextBox ID="TxtValProp" runat="server" Width="119px" AutoPostBack="true" ></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender 
                            ID="FilteredTextBoxExtender2" 
                            runat="server" TargetControlID="TxtValProp" FilterType="Custom, Numbers" ValidChars=".">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                ControlToValidate="TxtValProp" 
                                ErrorMessage="Debe diligenciar el Valor de los Aportes Propios" 
                                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                         
                        <td colspan="2">
                         <asp:Label ID="LbValProp"
                                runat="server" Text="Label"></asp:Label>  
                        </td>
                        <td>
                           <asp:TextBox ID="TxtValOtros" runat="server" ReadOnly="True" Enabled="false"></asp:TextBox>
                        </td>
                        <td >
                <asp:Label ID="LbValOtros"
                                runat="server" Text="Label"></asp:Label> 
                        </td>
                    </tr>
                    <tr>
                    <td>
                            <asp:Label ID="Label9" runat="server" Text="Valor Sin IVA"></asp:Label>
                        </td>
                        <td colspan="5">
                            <asp:TextBox ID="TxtValSinIva" runat="server" Text="0"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender 
                            ID="FilteredTextBoxExtender9" 
                            runat="server" TargetControlID="TxtValSinIva" FilterType="Custom, Numbers" ValidChars=".">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="TxtValSinIva" 
                                ErrorMessage="Debe deligenciar el Valor del Contrato sin IVA" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="Valor del IVA"></asp:Label>
                        </td>
                        <td style="width: 172px">
                            <asp:TextBox ID="TxtValIva" runat="server" Width="119px" Text="0" ReadOnly="true"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender 
                            ID="FilteredTextBoxExtender10" 
                            runat="server" TargetControlID="TxtValIva" FilterType="Custom, Numbers" ValidChars=".">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="TxtValIva" 
                                ErrorMessage="Debe diligenciar el Valor de los Aportes Propios" 
                                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 171px">
                            <asp:Label ID="Label13" runat="server" Text="Plazo"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                ControlToValidate="TxtPlazo" ErrorMessage="Debe diligenciar el Plazode ejecucion del Contrato" 
                                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="style41">
                            <b>
                            <asp:TextBox ID="TxtPlazo" runat="server" Width="108px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender 
                                ID="FilteredTextBoxExtender7" 
                                runat="server"
                                FilterType="Numbers" 
                                TargetControlID="TxtPlazo">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </b>
                        </td>
                        <td style="width: 171px" colspan="2">
                            <asp:DropDownList ID="CboTPlazo" runat="server" DataSourceID="Tipo_Plazos" 
                                DataTextField="Nom_Pla" DataValueField="Cod_TPla" Width="92px" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="Tipo_Plazos" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                TypeName="Tipo_Plazos"></asp:ObjectDataSource>
                        </td>
                        <td colspan="2">
                        <b>
                            <asp:TextBox ID="TxtPlazo2" runat="server" Width="70px" Text="0"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender 
                                ID="FilteredTextBoxExtender8" 
                                runat="server"
                                FilterType="Numbers" 
                                TargetControlID="TxtPlazo">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </b>
                        </td>
                        <td style="width: 171px">
                            
                            <asp:DropDownList ID="CboTPlazo3" runat="server" DataSourceID="ObjTipoPlazo2" 
                                DataTextField="Nom_Pla" DataValueField="Cod_TPla" 
            Width="92px">
                            </asp:DropDownList><asp:ObjectDataSource ID="ObjTipoPlazo2" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByTipo1" 
            TypeName="Tipo_Plazos">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="CboTPlazo" Name="tipo" 
                                        PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
        </asp:ObjectDataSource>
                        </td>
                        
                        <td style="width: 172px">
                              <asp:CheckBox ID="ChkAgotarPpto" runat="server" Text="Hasta Agotar Ppto" 
                                Width="157px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 171px">
                            <asp:Label ID="Label14" runat="server" Text="Forma Contractual "></asp:Label>
                        </td>
                        <td class="style41">
                            <asp:DropDownList ID="CboFor" runat="server" CssClass="txt" 
                                ToolTip="Forma Contractual">
                                <asp:ListItem>CON FORMALIDAD</asp:ListItem>
                                <asp:ListItem>SIN FORMALIDAD</asp:ListItem>
                                <asp:ListItem Selected="True" Value="-----o-----">-------o--------</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 171px" colspan="2">
                            <asp:Label ID="Label16" runat="server" Text="Sector Destino"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="CboSec" runat="server" CssClass="txt" 
                                DataSourceID="ObjectDataSource1" DataTextField="Nom_Sec" 
                                DataValueField="Cod_Sec" Width="117px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 171px">
                            
                            &nbsp;</td>
                        
                        <td style="width: 172px">
                            <asp:CheckBox ID="ChkUM" runat="server" Text="Urgencia Manifiesta" 
                                Width="157px" /> 
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 171px">
                            <asp:Label ID="Label17" runat="server" Text="Lugar de Ejecuci�n"></asp:Label>
                        </td>
                        <td colspan="7">
                            <asp:TextBox ID="TxtLugEje" runat="server" Width="93%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                ControlToValidate="TxtLugEje" 
                                ErrorMessage="Debe diliganciar el Lugar de Ejecuci�n" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                    <td style="width: 171px">
                            <asp:Label ID="Label18" runat="server" Text="Interventor/Supervisor"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="CboInterventoria" runat="server" DataSourceID="ObjDep" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="250px">
                            </asp:DropDownList></td>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label24" runat="server" Text="Revisado Por"></asp:Label>
                        </td>
                        <td colspan="3">
                           <asp:DropDownList ID="CboRevPor" runat="server" DataSourceID="ObjCord" 
                                DataTextField="Nom_Ter" DataValueField="Ide_Ter" Width="250px">
                           </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                                SelectMethod="GetRecords" TypeName="Sector" UpdateMethod="Update">
                                <UpdateParameters>
                                    <asp:Parameter Name="Cod_Sec_O" Type="String" />
                                    <asp:Parameter Name="Cod_Sec" Type="String" />
                                    <asp:Parameter Name="Nom_Sec" Type="String" />
                                    <asp:Parameter Name="estado" Type="String" />
                                </UpdateParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Cod_Sec" Type="String" />
                                    <asp:Parameter Name="Nom_Sec" Type="String" />
                                    <asp:Parameter Name="estado" Type="String" />
                                </InsertParameters>
                            </asp:ObjectDataSource>
                        </td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                        Municipios Beneficiados
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                        <div id="DIV1" language="javascript" style="z-index: 101; overflow: auto; width: 237px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" title="MUNICPIOS">
                    <asp:DataList ID="DataList1" runat="server" CellPadding="4" CellSpacing="5" CssClass="txt"
                        DataKeyField="COD_MUN" DataSourceID="ObjConMun" ForeColor="#333333" GridLines="Vertical"
                        Height="40px" RepeatColumns="1" Width="202px">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <ItemTemplate>
                            &nbsp;<asp:CheckBox ID="chknommun" runat="server" Checked='<%# eval("est") %>' Text='<%# Eval("NOM_MUN") %>' />
                            <asp:TextBox ID="txtcodmun" runat="server" Text='<%# Eval("COD_MUN") %>' Visible="False"
                                Width="197px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:DataList><br />
                </div>
                        </td>
                    </tr>
                    </table> 
                    <asp:ObjectDataSource ID="ObjDep" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Dependencias"></asp:ObjectDataSource>
            
            <asp:ObjectDataSource ID="ObjCord" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetCoordinadores" 
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
        
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtValTot" EventName="TextChanged" />
        </Triggers>
        </asp:UpdatePanel>                
<asp:UpdateProgress ID="UpdateProgressGral" runat="server" 
AssociatedUpdatePanelID="UpdatePanel1">
<progresstemplate>
<uc3:Progress ID="Progress2" runat="server" />
</progresstemplate>
</asp:UpdateProgress>

                        </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header><a href="" class="accordionLink"> 2. Forma de Pago</a></Header>
                <Content>
                    <asp:UpdatePanel ID="UpdFpago" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Label ID="lbInfoP" runat="server" SkinID="MsgResult" CssClass="infor" Text="El Campo fecha determina el orden en el que se mostraran los Pagos en la Minuta."></asp:Label>
                    <asp:GridView ID="GrPagos" runat="server" AutoGenerateColumns="False"  GridLines="None"
                                DataKeyNames="Id,Num_Proc" DataSourceID="PagosParciales" SkinID="gridView" 
                                EmptyDataText="No ha especificado la forma de pago" ShowFooter="True">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                    <asp:BoundField DataField="Fecha_Pago" DataFormatString="{0:d}" HeaderText="Fecha de Pago" 
                                        SortExpression="Fecha_Pago" />
                                    <asp:BoundField DataField="Valor_Pago" HeaderText="Valor" DataFormatString="{0:c3}"
                                        SortExpression="Valor_Pago" />
                                    <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje" DataFormatString="{0:p3}"
                                        SortExpression="Porcentaje" />
                                    <asp:BoundField DataField="Aportes_Propios" HeaderText="Aportes Propios" 
                                        SortExpression="Aportes_Propios" />
                                    <asp:BoundField DataField="Forma_Pago" HeaderText="Descripci�n" 
                                        SortExpression="Forma_Pago" />
                                    <asp:ButtonField ButtonType="Image" CommandName="Editar" 
                                        ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                                    <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                                        ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="PagosParciales" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
                                TypeName="Pagos_Gprocesos">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="TxtNProcA" Name="Num_Proc" PropertyName="Text" 
                                        Type="String" />
                                    <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" PropertyName="SelectedValue" 
                                        Type="String" />    
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <br />
                        <asp:Label ID="Label8" runat="server" Text="Registro de Pagos"  CssClass="SubTitulo"></asp:Label>
                            <table style="width:100%;">
                                <tr>
                                    <td class="style21" colspan="5">
                                        <asp:Label ID="MsgPagos" runat="server" SkinID="MsgResult"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style21">
                                        <asp:Label ID="Label40" runat="server" Text="Tipo de Pago"></asp:Label>
                                    </td>
                                    <td class="style22">
                                        <asp:Label ID="Label41" runat="server" Text="Fecha del Pago"></asp:Label>
                                    </td>
                                    <td class="style23">
                                        <asp:RadioButton ID="RbtValPago" runat="server" Text="Valor" GroupName="Valpago" />
                                        <asp:RadioButton ID="RbtPorcentaje" runat="server" Text="%" GroupName="Valpago" Checked="True" />
                                    </td>
                                    <td class="style23">
                                        <asp:CheckBox ID="ChkPagGober" runat="server" Checked="true" Text="Aportes Propios" />
                                    </td>
                                    <td class="style24">
                                        <asp:Label ID="Label43" runat="server" Text="Condici�n de Pago"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style25">
                                        <asp:DropDownList ID="CboTipPago" runat="server" DataSourceID="TipoPago" 
                                            DataTextField="Des_Pago" DataValueField="Id_Pago" Width="119px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style30">
                                        <asp:TextBox ID="TxtFecPago" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender 
                                        ID="CalendarExtender1" 
                                        runat="server" TargetControlID="TxtFecPago" Format="dd/MM/yyyy">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                    <td class="style27">
                                        <asp:TextBox ID="TxtValPago" runat="server"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender 
                                        ID="FilteredTextBoxExtender4" 
                                        runat="server" 
                                        TargetControlID="TxtValPago" 
                                        FilterType="Custom, Numbers" 
                                        ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    <td class="style28" style="vertical-align:top">
                                        <asp:TextBox ID="TxtCondicionPago" runat="server"  TextMode="MultiLine"
                                            Width="339px"></asp:TextBox>
                                    </td>
                                    <td class="style29">
                                        <asp:ImageButton ID="BtnGuardarPago" runat="server" SkinID="IBtnGuardar" 
                                            ValidationGroup="GuardarPago" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style21">
                                        &nbsp;</td>
                                    <td class="style22">
                                        <asp:Label ID="fechavalida" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td class="style23">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                            ControlToValidate="TxtValPago" ErrorMessage="Cantidad no Valida" 
                                            ValidationExpression="^[0-9]+(\.[0-9]+)?$" ValidationGroup="GuardarPago"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="TxtValPago" ErrorMessage="Digite el Valor" 
                                            ValidationGroup="GuardarPago"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="style24">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                            ControlToValidate="TxtCondicionPago" ErrorMessage="Digite la condicion de pago" 
                                            ValidationGroup="GuardarPago"></asp:RequiredFieldValidator>
                                    </td>
                                  </tr>
                            </table>
                    </ContentTemplate>
                 <%--   <Triggers>
                    <asp:PostBackTrigger ControlID="BtnGuardarPago" />
                    </Triggers>--%>
                    </asp:UpdatePanel>  
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdFpago">
                    <progresstemplate>
                   <uc3:Progress ID="Progress3" runat="server" />
                    </progresstemplate>
                    </asp:UpdateProgress>   
                       
                </Content>
            </ajaxToolkit:AccordionPane>
             <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header><a href="" class="accordionLink"> 3. Obligaciones</a></Header>
                <Content>
                    <asp:UpdatePanel ID="updOblig" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <uc1:grdObligGP ID="grdObligGP1" runat="server" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                    AssociatedUpdatePanelID="updOblig">
                    <progresstemplate>
                   <uc3:Progress ID="Progress4" runat="server" />
                    </progresstemplate>
                    </asp:UpdateProgress>                    
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                <Header><a href="" class="accordionLink"> 4. Proyectos</a></Header>
                <Content>
                    <asp:UpdatePanel ID="UpdProy" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Label ID="Label11" runat="server" SkinID="MsgResult" CssClass="infor" Text="En caso de no tener Proyectos Diligencie las Observaciones en la Pesta�a Otros Datos(Item 8)."></asp:Label>
                    <asp:Label ID="MsgProy" runat="server"></asp:Label>
                            
                            <asp:GridView ID="GrProyectos" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="pproyectos" SkinID="gridView" GridLines="None"
                                DataKeyNames="Proyecto,Num_Proc" 
                                EmptyDataText="No hay Proyectos Asignados al Proceso" Width="498px" 
                                ShowFooter="True">
                                <Columns>
                                    <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" />
                                    <asp:BoundField DataField="Nombre_Proyecto" HeaderText="Nombre del Proyecto" />
                                    <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" 
                                        Text="Eliminar" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="pproyectos" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
                                TypeName="GPProyectos">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="TxtNProcA" Name="Num_Proc" PropertyName="Text" 
                                        Type="String" />
                                    <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" PropertyName="SelectedValue" 
                                        Type="String" />    
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <table style="width:100%;">
                                <tr>
                                    <td class="style13">
                                        <asp:TextBox ID="TxtProyecto" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td class="style5">
                                        <asp:ImageButton ID="BtnBuscaProy" runat="server" SkinID="IBtnBuscar" />
                                    </td>
                                    <td class="style14">
                                        <asp:TextBox ID="TxtNomProyecto" runat="server" Width="310px" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td class="style15">
                                        <asp:ImageButton ID="BtnGuardaProy" runat="server" SkinID="IBtnGuardar" 
                                            ValidationGroup="GuardarProy" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style9">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="TxtProyecto" ErrorMessage="Seleccione el proyecto" 
                                            ValidationGroup="GuardarProy"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="style10">
                                    </td>
                                    <td class="style11">
                                    </td>
                                    <td class="style12">
                                    </td>
                                </tr>
                            </table>
                    </ContentTemplate>
                    </asp:UpdatePanel> 
                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                    AssociatedUpdatePanelID="UpdProy">
                    <progresstemplate>
                   <uc3:Progress ID="Progress5" runat="server" />
                    </progresstemplate>
                    </asp:UpdateProgress>                
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header><a href="" class="accordionLink"> 5. CDP - Certificado de Disponiblidad Presupuestal</a></Header>
                <Content>
                    <asp:UpdatePanel ID="UpdCDP" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Label ID="Lb10" runat="server" SkinID="MsgResult" CssClass="infor" Text="En caso de no tener CDP Diligencie las Observaciones en la Pesta�a Otros Datos(Item 8)."></asp:Label>
                        <br />
                        <uc2:grdCDPGP ID="grdCDPGP1" runat="server" />
                        <br />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" 
                    AssociatedUpdatePanelID="UpdCDP">
                    <progresstemplate>
                    <uc3:Progress ID="Progress6" runat="server" />
                    </progresstemplate>
                    </asp:UpdateProgress>                 
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                <Header><a href="" class="accordionLink"> 6. Rubros</a></Header>
                <Content>
                    <asp:UpdatePanel ID="UpdRubros" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GrRubros" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="Rubros" Width="519px" DataKeyNames="Cod_Rub,Num_Pro" 
                                ShowFooter="True" EnableModelValidation="True" SkinID="gridView" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="Cod_Rub" HeaderText="Rubro" />
                                    <asp:BoundField DataField="Des_Rub" HeaderText="Descripci�n" />
                                    <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:c}" />
                                    <asp:BoundField DataField="Nro_Cdp" HeaderText="N� de CDP"  />
                                    <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                                        ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="Rubros" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
                                TypeName="Rubros_GProcesos">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="TxtNProcA" Name="Num_Proc" PropertyName="Text" 
                                        Type="String" />
                                    <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" PropertyName="SelectedValue" 
                                        Type="String" />    
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <table style="width:100%;">
                                <tr>
                                    <td class="style16" colspan="6">
                                        <asp:Label ID="MsgRubro" runat="server" SkinID="MsgResult"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style20">
                                        <asp:Label ID="Label35" runat="server" Text="C�digo"></asp:Label>
                                    </td>
                                    <td class="style17">
                                        &nbsp;</td>
                                    <td class="style17">
                                        <asp:Label ID="Label36" runat="server" Text="Rubro"></asp:Label>
                                    </td>
                                    <td class="style18">
                                        <asp:Label ID="Label37" runat="server" Text="Valor"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="Label38" runat="server" 
                                            Text=" N� CDP "></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style20">
                                        <asp:TextBox ID="Txt_CodRub" runat="server" Width="165px" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="IbtnBucaRubro" runat="server" SkinID="IBtnBuscar" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txt_DesRub" runat="server" Width="291px" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td class="style18">
                                        <asp:TextBox ID="TxtValRub" runat="server"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender 
                                        ID="FilteredTextBoxExtender3" 
                                        runat="server" TargetControlID="TxtValRub" FilterType="Custom, Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    <td class="style19">
                                        <asp:DropDownList ID="CboCDP" runat="server" Width="119px" 
                                            DataSourceID="CDP" DataTextField="Nro_CDP" DataValueField="Nro_CDP">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="BtnGuardaRubro" runat="server" SkinID="IBtnGuardar" 
                                            ValidationGroup="GuardarRubro" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style20">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="Txt_CodRub" ErrorMessage="Seleccione el rubro" 
                                            ValidationGroup="GuardarRubro"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="TxtValRub" ErrorMessage="Cantidad no Valida" 
                                            ValidationExpression="^[0-9]+(\.[0-9]+)?$" ValidationGroup="GuardarRubro"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="TxtValRub" ErrorMessage="Digite el Valor" 
                                            ValidationGroup="GuardarRubro"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="2">
                                        &nbsp;</td>
                                </tr>
                            </table>
                    </ContentTemplate>
                    </asp:UpdatePanel>        
                         <asp:UpdateProgress ID="UpdPrgRubros" runat="server" 
                AssociatedUpdatePanelID="UpdRubros">
                <progresstemplate>
                        <uc3:Progress ID="Progress1" runat="server" />
                </progresstemplate>
            </asp:UpdateProgress>         
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server">
                <Header><a href="" class="accordionLink"> 7. Polizas</a></Header>
                <Content>
                    <asp:UpdatePanel ID="UpdPolizas" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
           <asp:Label ID="Label31" runat="server" SkinID="MsgResult" CssClass="infor" Text="En caso de no tener Polizas Diligencie las Observaciones en la Pesta�a Otros Datos(Item 8)."></asp:Label>
           <table style="width:100%;" >
            <tr>
                <td class="style1" colspan="3">
                    <asp:GridView ID="Grv_Ppol" runat="server" AutoGenerateColumns="False" 
                        SkinID="gridView" Width="615px" DataSourceID="ppolizas" GridLines="None"
                        EnableModelValidation="True" DataKeyNames="Cod_Pol,Num_Proc" 
                        EmptyDataText="No existen Polizas registradas para el proceso">
                        <Columns>
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                                SortExpression="Descripcion" />
                            <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                                ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ppolizas" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyTproc" 
                        TypeName="GPPolizas">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtNProcA" Name="Num_Proc" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" PropertyName="SelectedValue" 
                                        Type="String" />    
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style34" colspan="3">
                    <asp:Label ID="MsgPol" runat="server" SkinID="MsgResult"></asp:Label>
                </td>
                <td class="style34">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style42">
                    <asp:Label ID="Label2" runat="server" Text="Amparo"></asp:Label>
                </td>
                <td class="style43">
                    <asp:DropDownList ID="CboAmparo" runat="server" DataSourceID="Polizas" 
                        DataTextField="Nom_Pol" DataValueField="Cod_Pol" Width="350px" 
                        AppendDataBoundItems="True">
                        <asp:ListItem Value="Seleccione...">Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
                <td class="style3">
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style42">
                    <asp:Label ID="Label4" runat="server" Text="% o SMMLV"></asp:Label>
                </td>
                <td class="style43">
                    <asp:TextBox ID="TxtSMMLV" runat="server" Width="60px"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender 
                    runat="server" 
                    ID="FilSMMLV" 
                    FilterType="Numbers"
                    TargetControlID="TxtSMMLV">                    
                    </ajaxToolkit:FilteredTextBoxExtender>
                         <asp:DropDownList ID="cboTipo" runat="server">
                    <asp:ListItem Text="SMMLV" Value="SMMLV"></asp:ListItem>
                    <asp:ListItem Text="%" Value="%"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style3">
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style42">
                    <asp:Label ID="Label5" runat="server" Text="Calcular a partir de"></asp:Label>
                </td>
                <td class="style43">
                    <asp:DropDownList ID="CboCalPol" runat="server" Width="350px" 
                        DataSourceID="calculopol" DataTextField="Descripcion" ValidationGroup="GuardarPoliza"
                        DataValueField="Cod_Cal" AppendDataBoundItems="True">
                        <asp:ListItem Value="Seleccione...">Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style3">
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style42">
                    <asp:Label ID="Label6" runat="server" Text="Vigencia(En d�as)"></asp:Label>
                </td>
                <td class="style43">
                    <asp:TextBox ID="TxtVigencia" runat="server" Width="60px"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender 
                    runat="server" 
                    ID="FilteredTextBoxExtender6" 
                    FilterType="Numbers"
                    TargetControlID="TxtVigencia">                    
                    </ajaxToolkit:FilteredTextBoxExtender>
                </td>
                <td class="style3">
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style42">
                    <asp:Label ID="Label7" runat="server" Text="A partir de"></asp:Label>
                </td>
                <td class="style43">
                    <asp:DropDownList ID="CboCalVigPol" runat="server" Width="350px" ValidationGroup="GuardarPoliza" 
                        DataSourceID="Cal_Vig_Pol" DataTextField="Descripcion" 
                        DataValueField="Cod_Cal" AppendDataBoundItems="True">
                        <asp:ListItem Value="Seleccione...">Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style3">
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style42">
                    &nbsp;</td>
                <td class="style43">
                    <asp:Button ID="BtnGuardarPol" runat="server" Text="Guardar" ValidationGroup="GuardarPoliza"  />
                    &nbsp;</td>
                <td class="style3">
              
                    </td>
                <td class="style3">
              
                    &nbsp;</td>
            </tr>
        </table>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BtnGuardarPol" EventName="Click" />
                    </Triggers>
                    </asp:UpdatePanel>        
                         <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
                AssociatedUpdatePanelID="UpdPolizas">
                <progresstemplate>
                    <uc3:Progress ID="Progress7" runat="server" />
                </progresstemplate>
            </asp:UpdateProgress>         
                </Content>
            </ajaxToolkit:AccordionPane>
               <ajaxToolkit:AccordionPane ID="AccordionPane8" runat="server">
                <Header><a href="" class="accordionLink"> 8. Otros Datos (Considerandos, Aportes Propios y Observaciones)</a></Header>
                <Content>
                    <asp:UpdatePanel ID="UpdCons" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Considerandos"  CssClass="SubTitulo"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TxtConsiderandos" style="text-align:justify" TextMode="MultiLine" Width="100%" Height="200px"  runat="server" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LbConsiderandos" runat="server" Text="Label" Width="100%" style="text-align:justify" visible=false ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td>
                            <asp:Label ID="Label190" runat="server" Text="Aprotes Propios"  CssClass="SubTitulo"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td>
                            <asp:TextBox ID="TxtAportes" runat="server" style="text-align:justify" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>
                            </td>
                            </tr>
                        </table>
                    <hr />
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label32" runat="server" Text="Observaciones a CDP"  CssClass="SubTitulo"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TxtObsCDP" runat="server" style="text-align:justify" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label34" runat="server" Text="Observaciones a Proyectos"  CssClass="SubTitulo"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TxtObsProy" runat="server" style="text-align:justify" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label42" runat="server" Text="Observaciones a Polizas"  CssClass="SubTitulo"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TxtObsPol" runat="server" style="text-align:justify" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>              
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TxtConsiderandos" EventName="TextChanged" />
                    </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="UpdateProgress8" runat="server" 
                    AssociatedUpdatePanelID="UpdCons">
                    <progresstemplate>
                    <uc3:Progress ID="Progress8" runat="server" />
                    </progresstemplate>
                        
                    </asp:UpdateProgress>                 
                </Content>
            </ajaxToolkit:AccordionPane>
            
              <ajaxToolkit:AccordionPane ID="AccordionPane9" runat="server">
                <Header><a href="" class="accordionLink"> 9. Generar Minutas </a></Header>
                <Content>
                    <asp:UpdatePanel ID="UpdMin" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Label ID="LbMinuta" runat="server" Text="" Width="80%" Height="100%"></asp:Label>
                    <table style="width:80%;">
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style45">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style44">
                    <asp:DropDownList ID="CboPlantilla" runat="server" Height="21px" Width="226px" 
                        DataSourceID="ObjPlantillas" DataTextField="Nom_Pla" DataValueField="Ide_Pla">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjPlantillas" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNumProc" 
                        TypeName="PPlantillas">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtNprocA" Name="Num_Proc" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td class="style45" style="text-align:center">
                        <asp:ImageButton ID="BtnGen" runat="server" Height="32px" Width="32px" 
                         SkinID="IBtnMinuta" />
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
            <td>
            </td>
            <td>Generar Minuta</td>
            </tr>
            </table>
            <table style="width:100%;"><tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            </tr>
            <tr>
            <td colspan="3">
             <asp:GridView ID="GrdMin" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjPGContratosM" EnableModelValidation="True" DataKeyNames="ID">
               <Columns>
                   <asp:BoundField DataField="Fec_Reg" HeaderText="Fecha de Generaci�n" />
                   <asp:CommandField SelectText="Ver" ShowSelectButton="True" />
                   <asp:ButtonField ButtonType="Link" CommandName="Inhabilitar" Text="Anular" />
               </Columns>
                    </asp:GridView>
            </td>
            </tr>
            <tr>
            <td><asp:CheckBox ID="ChkLog" runat="server" AutoPostBack="True" Text="Ver LOG"></asp:CheckBox></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            </tr>
            <tr>
            <td><asp:TextBox ID="TxtLog" ReadOnly="true" Height="300" runat="server" Text="" TextMode="MultiLine" Width="100%" Visible="False"></asp:TextBox></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            </tr>
            </table>
                        
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="UpdPrgMin" runat="server" 
                    AssociatedUpdatePanelID="UpdMin">
                    <progresstemplate>
                    <uc3:Progress ID="PrgMin" runat="server" />
                    </progresstemplate>
                        
                    </asp:UpdateProgress>                 
                </Content>
            </ajaxToolkit:AccordionPane>
            
                </Panes>
            </ajaxToolkit:Accordion>  

           <br />
          
                
                
                    
           <br />
<asp:ObjectDataSource ID="ObjPGContratosM" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyPG" 
            TypeName="PGContratosM">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtNprocA" Name="NUM_PROC" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="CboGrupos" Name="GRUPO" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjConMun" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPConMun" 
        TypeName="GProcesos" InsertMethod="InsertP">
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
            <asp:ControlParameter ControlID="CboGrupos" Name="GRUPO" 
                PropertyName="SelectedValue" Type="String" />
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
                                            TypeName="CDP_GProcesos">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="TxtNProcA" Name="Num_Pcon" PropertyName="Text" 
                                                    Type="String" />
                                                <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" 
                                                    PropertyName="SelectedValue" Type="String" />
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
   
            
            
        <asp:Panel ID="Panel1" runat="server" Width="639px" BackColor="White">
            <asp:Panel ID="Panel2" runat="server" CssClass="BarTitleModal2" Height="26px">
                <table style="width:100%;">
                    <tr>
                        <td class="style7">
                            <asp:Label ID="Label33" runat="server" Text="Seleccionar Proyectos"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="BtnCerrar" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ScrollBars="Both" runat="server" Height="473px">
            <uc4:ConProyectos ID="ConProyectos1" runat="server" />
            </asp:Panel>
        </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Btn_Target" runat="server"></asp:Button>
        <ajaxToolkit:ModalPopupExtender 
        ID="ModalPopupExtender1" 
        runat="server" 
        Drag="True" 
        CancelControlID="BtnCerrar" 
        PopupDragHandleControlID="Panel2" 
        PopupControlID="Panel1" 
        TargetControlID="Btn_Target"
        BackgroundCssClass="modalBackground"
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>    
            
            
        <asp:Panel ID="Panel3" runat="server" Width="639px" BackColor="White">
            <asp:Panel ID="Panel4" runat="server" CssClass="BarTitleModal2" Height="26px">
                <table style="width:100%;">
                    <tr>
                        <td class="style7">
                            <asp:Label ID="Label39" runat="server" Text="Seleccionar Rubros"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="BtnCerrar1" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel5" ScrollBars="Both" runat="server" Height="473px">
            <uc6:ConRubros ID="ConRubros1" runat="server" />
            </asp:Panel>
        </asp:Panel>
       <asp:Button style="DISPLAY: none" id="Button1" runat="server"></asp:Button>
        <ajaxToolkit:ModalPopupExtender 
        ID="ModalPopupRubros" 
        runat="server" 
        Drag="True" 
        CancelControlID="BtnCerrar1" 
        PopupDragHandleControlID="Panel4" 
        PopupControlID="Panel3" 
        TargetControlID="Button1"
        BackgroundCssClass="modalBackground"
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>  
        
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

