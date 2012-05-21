<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Proponentes.aspx.vb" Inherits="Procesos_Proponentes_Proponente" %>
<%@ Register src="../../CtrlUsr/DetPContratos/DetPContrato.ascx" tagname="DetPContrato" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>
<%@ Register src="../../CtrlUsr/CrProponentes/CrProponentes.ascx" tagname="CrProponentes" tagprefix="uc2" %>
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
          <uc1:DetPContrato ID="DetPContrato1" runat="server" 
                 />
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
                        <td style="width: 145px; text-align: right;">
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" 
                                ImageUrl="~/images/Operaciones/Proponente.png" ToolTip="Agregar Proponente" 
                                ValidationGroup="AgregarProponente" Width="32px" />
                        </td>
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
                    Width="574px">
                    <Columns>
                        <asp:BoundField DataField="NOM_TIPPROP" HeaderText="Tipo" />
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
                    </Columns>
                </asp:GridView>

                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <table class="style1">
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Button ID="BtnVoler" runat="server" Text="Volver" CausesValidation="False" ValidationGroup="NOVALIDAR" />
                                    </td>
                                </tr>
                            </table>
                            <uc2:CrProponentes ID="CrProponentes1" runat="server" />
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
                                                    EnableModelValidation="True" Height="130px" OnRowCommand="GridView1_RowCommand" 
                                                    ShowFooter="True" SkinID="gridView" Width="574px">
                                                    <Columns>
                                                        <asp:BoundField DataField="Ide_Miembro" HeaderText="Identificación" />
                                                        <asp:BoundField DataField="Nom_Miembro" HeaderText="Nombre" />
                                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                                        <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                                                            ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                                                        <asp:ButtonField ButtonType="Image" CommandName="Editar" 
                                                            ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
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
                                                <asp:Label ID="Label6" runat="server" Text="Estado"></asp:Label>
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
                                                <asp:DropDownList ID="CmbEst" runat="server" Width="92px">
                                                    <asp:ListItem Value="AC">ACTIVO</asp:ListItem>
                                                    <asp:ListItem Value="IN">INACTIVO</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 226px">
                                                <asp:ImageButton ID="BtnGuardar" runat="server" SkinID="IBtnGuardar" 
                                                    ValidationGroup="GuardarMiembro" />
                                            </td>
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
                    TypeName="PProponentes">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DetPContrato1" Name="Num_Proc" 
                            PropertyName="CodigoPContrato" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjMiembros" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyTer" 
                    TypeName="Consorcios" InsertMethod="Insert">
                    <InsertParameters>
                        <asp:Parameter Name="Ide_Ter" Type="String" />
                        <asp:Parameter Name="Id_Miembros" Type="String" />
                        <asp:Parameter Name="Id_Estado" Type="String" />
                    </InsertParameters>
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

