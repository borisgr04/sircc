<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="true" AutoEventWireup="false" CodeFile="NuevoProceso.aspx.vb" 
Inherits="Procesos_NuevoProceso_Default"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../../CtrlUsr/grdOblig/grdOblig.ascx" tagname="grdOblig" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/grdCDP/grdCDP.ascx" tagname="grdCDP" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        
        <br />
        <asp:Label ID="Label10" runat="server" CssClass="Titulo" 
            Text="REGISTRO DE PROCESOS PRECONTRACTUALES"></asp:Label>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 41px">
                            <asp:ImageButton ID="IBtnNuevo" runat="server" Height="32px" 
                                ImageUrl="~/images/Operaciones/New1.png" Width="32px" />
                        </td>
                        <td style="width: 115px">
                            <asp:TextBox ID="TxtNprocA" runat="server" AutoPostBack="True"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender 
                            id="autoComplete1" runat="server" TargetControlID="TxtNprocA" 
                            BehaviorID="AutoCompleteEx" CompletionInterval="1000" CompletionListCssClass="autocomplete_completionListElement" 
                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listitem" 
                            CompletionSetCount="20" DelimiterCharacters=";, :" EnableCaching="true" MinimumPrefixLength="1" ServicePath="AutoComplete.asmx" 
                            ServiceMethod="GetPContratos">
        <Animations>
                    <OnShow>
                        <Sequence>
                            
                            <OpacityAction Opacity="0" />
                            <HideAction Visible="true" />
                            
                            
                            <ScriptAction Script="
                                // Cache the size and setup the initial size
                                var behavior = $find('AutoCompleteEx');
                                if (!behavior._height) {
                                    var target = behavior.get_completionList();
                                    behavior._height = target.offsetHeight - 2;
                                    target.style.height = '0px';
                                }" />
                            
                            
                            <Parallel Duration=".4">
                                <FadeIn />
                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                            </Parallel>
                        </Sequence>
                    </OnShow>
                    <OnHide>
                        
                        <Parallel Duration=".4">
                            <FadeOut />
                            <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                        </Parallel>
                    </OnHide></Animations>
    </ajaxToolkit:AutoCompleteExtender>
                        </td>
                        <td style="width: 53px">
                            <asp:ImageButton ID="IBtnAbrir" runat="server" Height="32px" 
                                ImageUrl="~/images/mnProcesos/open-icon32.png" Width="32px" />
                        </td>
                        <td style="width: 53px">
                            <asp:ImageButton ID="IBtnEditar" runat="server" Height="32px" 
                                ImageUrl="~/images/Operaciones/Edit2.png" Width="32px" />
                        </td>
                        <td style="width: 61px">
                            <asp:ImageButton ID="IBtnGuardar" runat="server" Height="32px" 
                                SkinID="IBtnGuardar" Width="32px" />
                        </td>
                        <td style="width: 79px">
                            <asp:ImageButton ID="IBtnCancelar" runat="server" Height="32px" 
                                ImageUrl="~/images/mnProcesos/undo.png" Width="32px" />
                        </td>
                        <td>
                            <asp:Button ID="BtnVerMinuta" runat="server" Text="Ver Minuta" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 41px">
                            Nuevo</td>
                        <td style="width: 115px">
                            &nbsp;</td>
                        <td style="width: 53px">
                            Abrir</td>
                        <td style="width: 53px">
                            Editar</td>
                        <td style="width: 61px">
                            Guardar</td>
                        <td style="width: 79px">
                            Cancelar</td>
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
                        <td style="width: 61px">
                            &nbsp;</td>
                        <td style="width: 79px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
    <br />
                <table border="0px" cellpadding="2px" cellspacing="2px" style="width: 90%; ">
                    <tr>
                        <td colspan="6">
                            <asp:Label ID="Label12" runat="server" CssClass="SubTitulo" 
                                Text="DATOS BASICOS DEL PROCESO"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label2" runat="server" Text="Dependencia a Cargo del Proceso" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 92px">
                            &nbsp;</td>
                        <td colspan="4">
                            <b>
                            <asp:Label ID="Label5" runat="server" Text="Número de Proceso" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td>
                            <b>
                            <asp:Label ID="Label11" runat="server" CssClass="Caption" Text="Estado"></asp:Label>
                            </b></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="TxtNProc" runat="server" Width="180px" BackColor="#000066" 
                                Font-Size="12pt" ForeColor="White" ReadOnly="True"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtNProc_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtNProc" 
                                WatermarkCssClass="watermarked" WatermarkText="Automático ">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                        <td>
                            <asp:Label ID="LbEstado" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label4" runat="server" 
                                Text="Dependencia que Genera la Necesidad" CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 92px">
                            &nbsp;</td>
                        <td colspan="4">
                            <b>
                            <asp:Label ID="Label6" runat="server" 
                                Text="Planeación Precontractual/Estudio Previo" CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DropDownList ID="cboDep" runat="server" DataSourceID="ObjDep" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="TxtNPla" runat="server"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtNPla_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtNPla" 
                                WatermarkCssClass="watermarked" WatermarkText="Numero de Planeación">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label7" runat="server" Text="Proceso de Contratación" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 92px">
                            &nbsp;</td>
                        <td colspan="3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 25px">
                            <asp:DropDownList ID="CboTproc" runat="server" CssClass="txt" 
                                DataSourceID="ObjTipoProc" DataTextField="Nom_TProc" DataValueField="Cod_TProc" 
                                ToolTip="Proceso PreContractual">
                            </asp:DropDownList>
                        </td>
                        <td style="height: 25px">
                            </td>
                        <td style="height: 25px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label8" runat="server" Text="Tipo de Documento Contractual" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td colspan="2">
                            <b>
                            <asp:Label ID="Label9" runat="server" Text="Clase de Contratación" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td colspan="2" style="width: 119px">
                            <b>
                            <asp:Label ID="Label15" runat="server" CssClass="Caption" 
                                Text="Fecha de Recibido"></asp:Label>
                            </b>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" CssClass="txt" 
                                DataSourceID="ObjTiposCont" DataTextField="Nom_Tip" DataValueField="Cod_Tip">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 92px">
                            <asp:DropDownList ID="cboStip" runat="server" CssClass="txt" 
                                DataSourceID="ObjSubTipos" DataTextField="nom_stip" 
                                DataValueField="cod_stip" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" style="width: 64px">
                        
                            <asp:TextBox ID="TxtFechaRecibido" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender 
                            ID="CalFechaRecibido" 
                            runat="server" 
                            TargetControlID="TxtFechaRecibido" 
                            Format="dd/MM/yyyy"> 
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <table style="width: 90%">
                    <tr>
                        <td style="font-weight: 700" colspan="3">
                            <b>
                            <asp:Label ID="Label13" runat="server" CssClass="Caption" 
                                Text="Objeto a Contratar"></asp:Label>
                            </b></td>
                        <td colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:TextBox ID="TxtObj" runat="server" CssClass="txt" Height="68px" 
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                            <asp:Label ID="Label14" runat="server" CssClass="Caption" 
                                Text="Funcionario Encargado"></asp:Label>
                            </b>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LbEncargado" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <hr />
        <br />
    <asp:ObjectDataSource ID="ObjDep" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Dependencias"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjDepDel" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelbyUser" 
            TypeName="Dependencias" 
            InsertMethod="AsignarAbogado" >
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
        <asp:ObjectDataSource ID="ObjTipoProc" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="TiposProc"></asp:ObjectDataSource>
            
            
        <br />
            
            
</div>
</asp:Content>

