<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="true"
    AutoEventWireup="false" CodeFile="GDProcesos.aspx.vb" Inherits="GesDocumentos_Pre_Contractual_GDProcesos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../CtrlUsr/Progreso/Progress.ascx" TagName="Progress" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

        <asp:HiddenField ID="hdUrl" runat="server" />

        <asp:Label ID="Label10" runat="server" CssClass="Titulo" Text="GENERAR DOCUMENTOS DEL PROCESO CONTRACTUAL Y CONTRATO"></asp:Label>
        <br />


        <asp:UpdatePanel ID="UpdMin" runat="server">
            <ContentTemplate>
                <br />
                <table>
                    <tr>
                        <td style="width: 75px">N° de Proceso
                        </td>
                        <td style="width: 229px">
                            <asp:TextBox ID="TxtNprocA" runat="server" AutoPostBack="True" Width="200px"></asp:TextBox>
                        </td>
                       
                        <td style="width: 50px">&nbsp;</td>
                        
                       
                    </tr>


                    <tr>
                        <td>Grupo
                            <asp:ObjectDataSource ID="ObjGrupos" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyProc" TypeName="Grupos">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="TxtNprocA" Name="Num_Proc" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:DropDownList ID="CboGrupos" runat="server" AutoPostBack="True" DataSourceID="ObjGrupos" DataTextField="Grupos" DataValueField="Grupo">
                                <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 30px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Etapa<asp:ObjectDataSource ID="ObjEtapa" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" TypeName="Etapas">
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboEtapas" runat="server" AutoPostBack="True" DataSourceID="ObjEtapa" DataTextField="NOM_ETA" DataValueField="COD_ETA">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Tipo<asp:ObjectDataSource ID="ObjTipDoc" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyEtapa" TypeName="Tip_Doc" UpdateMethod="Update">
                            
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cboEtapas" Name="Cod_Eta" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                            
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboTipDoc" runat="server" AutoPostBack="True" DataSourceID="ObjTipDoc" DataTextField="DES_TIP" DataValueField="COD_TIP">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Plantilla<asp:ObjectDataSource ID="ObjPlantillas" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPreCon" TypeName="PPlantillas">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cboTipDoc" Name="CODIGO" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:DropDownList ID="CboPlantilla" runat="server" DataSourceID="ObjPlantillas" DataTextField="Nom_Pla" DataValueField="Ide_Pla" Height="21px" Width="226px">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Fecha </td>
                        <td>
                            <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="BtnGen" runat="server" Height="32px" SkinID="IBtnMinuta" style="text-align: center" Width="32px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            Generar Archivo</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

                <asp:Label ID="LbMinuta" runat="server" Height="100%" Text="" Width="50%"></asp:Label>
                <br />

                <table style="width: 100%;">
                    <tr>
                        <td>
                            <br />
                            Lista de Documentos<asp:GridView ID="grdDocP" runat="server" DataSourceID="ObjDocP" EnableModelValidation="True" DataKeyNames="Id">
                                <Columns>
                                    
                                    <asp:ButtonField ButtonType="Image" HeaderText="Ver DOC" ImageUrl="~/images/2012/EditarM.png"
                                        CommandName="doc" Text="Ver PDF" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Ver PDF" ImageUrl="~/images/2013/pdf.png"
                                        CommandName="pdf" Text="Ver PDF" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Anular" ImageUrl="~/images/2012/AnularMinuta.png"
                                        CommandName="Inhabilitar" Text="Anular" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjDocP" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocs2" TypeName="DocPContratos">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="TxtNprocA" Name="NUM_PROC" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:CheckBox ID="ChkLog" runat="server" AutoPostBack="True" Text="Ver LOG"></asp:CheckBox>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TxtLog" ReadOnly="true" Height="300" runat="server" Text="" TextMode="MultiLine"
                                Width="100%" Visible="False"></asp:TextBox>
                            <br />
                            Minuta del Contrato
                            <asp:GridView ID="GrdMin" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ObjPGContratosM" EnableModelValidation="True">
                                <Columns>
                                    <asp:BoundField DataField="Fec_Reg" HeaderText="Fecha de Generación" />
                                    <asp:ButtonField ButtonType="Image" CommandName="doc" HeaderText="Ver DOC" ImageUrl="~/images/2012/EditarM.png" Text="Ver Doc" />
                                    <asp:ButtonField ButtonType="Image" CommandName="pdf" HeaderText="Ver PDF" ImageUrl="~/images/2013/pdf.png" Text="Ver PDF" />
                                    <asp:ButtonField ButtonType="Image" CommandName="Inhabilitar" HeaderText="Anular" ImageUrl="~/images/2012/AnularMinuta.png" Text="Anular" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdPrgMin" runat="server" AssociatedUpdatePanelID="UpdMin">
            <ProgressTemplate>
                <uc3:Progress ID="PrgMin" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <span></span>
        <br />
        <br />
        <asp:ObjectDataSource ID="ObjPGContratosM" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetbyPG" TypeName="PGContratosM">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtNprocA" Name="NUM_PROC" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="CboGrupos" Name="GRUPO" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </div>
</asp:Content>
