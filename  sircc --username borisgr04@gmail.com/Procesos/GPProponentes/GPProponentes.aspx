<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GPProponentes.aspx.vb" Inherits="Procesos_Proponentes_GPProponente" %>
<%@ Register src="../../CtrlUsr/DetGProcesos/DetGProcesos.ascx" tagname="DetGProcesos" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>
<%@ Register src="../../CtrlUsr/CrGPProponentes/CrGPProponentes.ascx" tagname="CrGPProponentes" tagprefix="uc2" %>
<%@ Register src="../../CtrlUsr/AdmTercero/AdmTercero.ascx" tagname="AdmTercero" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

      
    <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="Registro de Proponentes"></asp:Label>
    <br />

      
<asp:UpdatePanel ID="UpdatePanel1"  UpdateMode="Conditional"
        runat="server" >
        <contenttemplate> 
          <uc1:DetGProcesos ID="DetGProcesos1" runat="server" 
                 />
            &nbsp;
            <table>
                <tr>
                    <td style="text-align: center">
                        <asp:ImageButton ID="IBtnAdjudicar" runat="server" SkinID="IBtnAdj" />
                    </td>
                    <td style="text-align: center">
                        <asp:ImageButton ID="IBtnDatosContrato" runat="server" SkinID="IBtnCont" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Adjudicar</td>
                    <td>
                        Datos del Contrato</td>
                </tr>
            </table>
                  <br />
            <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
        <br />
            <asp:Panel ID="PanelvConP" runat="server" BackColor="White" Width="900px" Height="500px">
            <asp:Panel ID="Panel4" runat="server" CssClass="BarTitleModal2" BorderColor="White" 
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
                            <asp:Button ID="BtnCerrar" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
            <uc4:ConPContratos ID="ConPContratos1" runat="server" />
            </asp:Panel>
             </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Btn_Target" runat="server"></asp:Button>

 


        <ajaxToolkit:ModalPopupExtender ID="ModalPopupConP" 
        runat="server"
        TargetControlID="Btn_Target" 
        PopupControlID="PanelvConP" 
        CancelControlID="BtnCerrar" 
        BackgroundCssClass="modalBackground"
        PopupDragHandleControlID="Panel4" 
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>
        

                   <table style="width:100%;">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="width: 475px; text-align: right;">
                            <asp:ImageButton ID="IBtnAddProp" runat="server" Height="32px" 
                                ImageUrl="~/images/Operaciones/Proponente.png" ToolTip="Agregar Proponente" 
                                ValidationGroup="AgregarProponente" Width="32px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                       <tr>
                           <td>
                               &nbsp;</td>
                           <td style="width: 475px; text-align: right;">
                               Nuevo Proponente</td>
                           <td>
                               &nbsp;</td>
                       </tr>
                </table>
     
                
             
            <%--<asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <ContentTemplate>--%>
                
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                           <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Ide_Prop" 
                    DataSourceID="ObjectPrponentes" 
                    EmptyDataText="El Proceso aun no cuenta con proponentes" 
                    EnableModelValidation="True" Height="130px" OnRowCommand="GridView1_RowCommand" 
                     ShowFooter="True" 
                    Width="719px">
                    <Columns>
                        <asp:BoundField DataField="NOM_TIPPROP" HeaderText="Tipo Proponente" />
                        <asp:BoundField DataField="TDOC_NOM" HeaderText="Tipo Identificación" />
                        <asp:BoundField DataField="Ide_Prop" HeaderText="Identificación" />
                        <asp:BoundField DataField="Razon_Social" HeaderText="Nombre del Proponente" />
                        <asp:BoundField DataField="Fec_Prop" DataFormatString="{0:d}" HeaderText="Fecha de la Propuesta" />
                        <asp:BoundField DataField="Val_Prop" HeaderText="Valor de la Propuesta" 
                            DataFormatString="{0:c}" />
                        <asp:BoundField DataField="Num_Folio" HeaderText="Número de Folios" />
                        <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="Editar" 
                            ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                            <asp:ButtonField ButtonType="Image" CommandName="AddMiembro" HeaderText="Agregar Miembro" 
                            ImageUrl="~/images/Operaciones/NuevoMiembro.png" Text="Agregar Miembro"/>
                            <asp:ButtonField ButtonType="Image" CommandName="Eliminar" HeaderText="Eliminar" 
                            ImageUrl="~/images/Operaciones/Delete2.png" Text="Eliminar"/>
                    </Columns>
                </asp:GridView>

                        </asp:View>
                        <asp:View ID="View2" runat="server">
                        <div style="height:300px; overflow:auot">
                        
                            <table class="style1">
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Button ID="BtnVoler" runat="server" Text="Volver" CausesValidation="False" ValidationGroup="NOVALIDAR" />
                                    </td>
                                </tr>
                            </table>
                            <uc2:CrGPProponentes ID="CrProponentes1" runat="server" />

                            </div>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                        
                            <table style="width:100%;">
                                <tr>
                                    <td style="width: 493px">
                                        &nbsp;</td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="Volver" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="MsgMiembros" runat="server" SkinID="MsgResult"></asp:Label>
                                    <br />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        DisplayMode="List" SkinID="ValidationSummary1" ValidationGroup="GuardarMiembro" 
                                        Width="345px" />
                                    <table style="width:100%;">
                                        <tr>
                                            <td style="width: 157px">
                                                <asp:Label ID="Label2" runat="server" Text="NIT"></asp:Label>
                                            </td>
                                            <td style="width: 26px">
                                                &nbsp;</td>
                                            <td colspan="3">
                                                <asp:Label ID="Label3" runat="server" Text="Nombre del Proponente"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td colspan="2">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 157px">
                                                <asp:Label ID="TxtNitProp" runat="server" __designer:wfdid="w3" 
                                                    BackColor="Navy" Font-Bold="True" Font-Size="Medium" ForeColor="White" 
                                                    Width="147px"></asp:Label>
                                            </td>
                                            <td style="width: 26px">
                                                &nbsp;</td>
                                            <td colspan="6">
                                                <asp:Label ID="TxtNomProp" runat="server" __designer:wfdid="w3" 
                                                    BackColor="Navy" Font-Bold="True" Font-Size="Medium" ForeColor="White" 
                                                    Width="310px"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 157px">
                                                &nbsp;</td>
                                            <td style="width: 26px">
                                                &nbsp;</td>
                                            <td colspan="6">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="9">
                                                <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                                                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Ide_Miembro" 
                                                    DataSourceID="ObjMiembros" 
                                                    EmptyDataText="No se encontraron registros en la Base de Datos" 
                                                    EnableModelValidation="True" Height="130px" OnRowCommand="GridView2_RowCommand" 
                                                    ShowFooter="True" SkinID="gridView" Width="574px">
                                                    <Columns>
                                                        <asp:BoundField DataField="Ide_Miembro" HeaderText="Identificación" />
                                                        <asp:BoundField DataField="Nom_Miembro" HeaderText="Nombre" />
                                                        <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                                                            ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                                                        </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 157px">
                                                &nbsp;</td>
                                            <td style="width: 26px">
                                                &nbsp;</td>
                                            <td colspan="6">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 157px">
                                                <asp:Label ID="Label4" runat="server" Text="Identificacion del Miembro"></asp:Label>
                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                    ControlToValidate="TxtIdMiembro" 
                                                    ErrorMessage="Debe diligenciar la identificacion del miembro" 
                                                    ValidationGroup="GuardarMiembro">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="width: 26px">
                                                &nbsp;</td>
                                            <td style="width: 240px">
                                                <asp:Label ID="Label5" runat="server" Text="Nombre del Miembro"></asp:Label>
                                            </td>
                                            <td style="width: 15px">
                                                &nbsp;</td>
                                            <td style="width: 226px">
                                                &nbsp;</td>
                                            <td colspan="2" style="width: 243px">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 157px">
                                                <asp:TextBox ID="TxtIdMiembro" runat="server" AutoPostBack="True" Width="143px"></asp:TextBox>
                                            </td>
                                            <td style="width: 26px">
                                                <asp:Button ID="BtnBuscar" runat="server" Text="..." />
                                            </td>
                                            <td style="width: 240px">
                                                <asp:TextBox ID="TxtNomMiembro" runat="server" Width="237px"></asp:TextBox>
                                            </td>
                                            <td style="width: 15px">
                                                <asp:ImageButton ID="BtnGuardar" runat="server" SkinID="IBtnGuardar" 
                                                    ValidationGroup="GuardarMiembro" />
                                            </td>
                                            <td style="width: 226px">
                                                &nbsp;</td>
                                            <td colspan="2" style="width: 243px">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        
                        </asp:View>
                    </asp:MultiView>
              <%--</ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BtnVoler" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>--%>

            </contenttemplate>
 </asp:UpdatePanel>

 <asp:ObjectDataSource ID="ObjectPrponentes" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
                    TypeName="GPProponentes" DeleteMethod="Delete" 
        InsertMethod="Insert" UpdateMethod="Adjudicar">
                    <DeleteParameters>
                        <asp:Parameter Name="Ide_Prop" Type="String" />
                        <asp:Parameter Name="Num_Proc" Type="String" />
                        <asp:Parameter Name="Grupo" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="grid" Type="Object" />
                        <asp:Parameter Name="NUM_PROC" Type="String" />
                        <asp:Parameter Name="FECHA_ADJUDICACION" Type="DateTime" />
                        <asp:Parameter Name="Grupo" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DetGProcesos1" Name="Num_Proc" 
                            PropertyName="CodigoPContrato" Type="String" />
                        <asp:ControlParameter ControlID="DetGProcesos1" DefaultValue="DetGProcesos1" 
                            Name="Grupo" PropertyName="Grupo" Type="String" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="tipo" Type="String" />
                        <asp:Parameter Name="Ide_Prop" Type="String" />
                        <asp:Parameter Name="Num_Proc" Type="String" />
                        <asp:Parameter Name="fec_prop" Type="DateTime" />
                        <asp:Parameter Name="val_prop" Type="Decimal" />
                        <asp:Parameter Name="Ape1_Prop" Type="String" />
                        <asp:Parameter Name="Dir_Prop" Type="String" />
                        <asp:Parameter Name="Tel_Prop" Type="String" />
                        <asp:Parameter Name="Email_Prop" Type="String" />
                        <asp:Parameter Name="Ape2_Prop" Type="String" />
                        <asp:Parameter Name="Nom1_Prop" Type="String" />
                        <asp:Parameter Name="Nom2_Prop" Type="String" />
                        <asp:Parameter Name="Razon_Social" Type="String" />
                        <asp:Parameter Name="Tip_Ide" Type="String" />
                        <asp:Parameter Name="Exp_Ide" Type="String" />
                        <asp:Parameter Name="Estado" Type="String" />
                        <asp:Parameter Name="Observacion" Type="String" />
                        <asp:Parameter Name="Num_Folio" Type="Int32" />
                        <asp:Parameter Name="dver" Type="String" />
                        <asp:Parameter Name="id_rep_leg" Type="String" />
                        <asp:Parameter Name="nom_rep_leg" Type="String" />
                        <asp:Parameter Name="Municipio" Type="String" />
                        <asp:Parameter Name="Grupo" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjMiembros" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyTer" 
                    TypeName="Consorcios" InsertMethod="Insert" 
        UpdateMethod="Update">
                    <InsertParameters>
                        <asp:Parameter Name="Ide_Ter" Type="String" />
                        <asp:Parameter Name="Id_Miembros" Type="String" />
                        <asp:Parameter Name="Id_Estado" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Ide_Ter" Type="String" />
                        <asp:Parameter Name="Id_Miembros" Type="String" />
                        <asp:Parameter Name="Id_Estado" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtNitProp" Name="IDE_TER" PropertyName="Text" 
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    <br />
    <asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> 
            <ajaxToolkit:ModalPopupExtender id="ModalPopup" 
            runat="server" BackgroundCssClass="modalBackground" 
        BehaviorID="programmaticModalPopupBehavior" DropShadow="True" 
        PopupControlID="programmaticPopup" 
        PopupDragHandleControlID="programmaticPopupDragHandle" 
        RepositionMode="RepositionOnWindowScroll" 
        TargetControlID="hiddenTargetControlForModalPopup" 
        CancelControlID="hideModalPopupViaClientButton">
            </ajaxToolkit:ModalPopupExtender> 
            <asp:Panel id="programmaticPopup" runat="server" Width="800px" Height="456px" 
                CssClass="ModalPanel2" ScrollBars="Auto" >
            <asp:Panel id="programmaticPopupDragHandle" runat="Server" Width="100%" 
                    Height="30px" CssClass="BarTitleModal2" >
            <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
            <DIV style="FLOAT: left">
                Buscar Tercero </DIV>
             <DIV style="FLOAT: right" __designer:dtid="1407383473487880"  >
            <INPUT id="hideModalPopupViaClientButton" type=button value="X" __designer:dtid="1407383473487881" /></DIV></DIV></asp:Panel>
                <panel id="pnCuadroInterno" runat="Server" ScrollBars="Auto" >
                    <uc3:AdmTercero ID="AdmTercero1" runat="server" />
                    <BR />
                </panel>
              </asp:Panel>
 </div>
</asp:Content>

