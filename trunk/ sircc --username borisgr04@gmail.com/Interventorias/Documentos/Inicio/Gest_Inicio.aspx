<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Gest_Inicio.aspx.vb" Inherits="Contratos_GesContratos_Default" %>

<%@ Register src="../../CtrlUsr/DetContratosI/DetContratoI.ascx" tagname="DetContratoI" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

    

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
                    Text="GESTIÓN DE CONTRATOS"></asp:Label>
                <br />
                <uc2:DetContratoI ID="DetContratoI1" runat="server" />
                    <asp:Label ID="MsgResult" runat="server" Height="30px" 
                        Width="90%">Hola......</asp:Label>
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
    <table  >
        <tr>
            <td colspan="6" 
                style="text-align: left; empty-cells: show; vertical-align: top;">
                
                
                
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 21px">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td >
                Documento</td>
            <td colspan="3" >
                <asp:DropDownList ID="CboEstSig" runat="server" DataTextField="NOM_EST"
                    DataValueField="EST_FIN" DataSourceID="ObjRutaEst" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Label ID="LbEst" runat="server"></asp:Label>
            </td>
            <td >
            </td>
        </tr>
        
        <tr>
            <td >
                &nbsp;</td>
            <td colspan="3" >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                <asp:ImageButton ID="BtnNuevo" runat="server" SkinID="IBtnNuevo" />
            </td>
           
            <td style="text-align: center">
                <asp:ImageButton ID="BtnCancelar" runat="server" Enabled="False" 
                    SkinID="IBtnCancelar" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                Nuevo</td>
            
            <td style="text-align: center">
                Cancelar</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" >
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 21px; text-align: center">
                <asp:ObjectDataSource ID="ObjRutaEst" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetByEstIni" 
                    TypeName="Est_Ruta">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DetContratoI1" DefaultValue="00" Name="EST_INI" 
                            PropertyName="Estado" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdEstContratos" runat="server" 
        AutoGenerateColumns="False"
                    DataKeyNames="ID" DataSourceID="ObjEstContratos" ShowFooter="True" SkinID="gridView" 
                            EnableModelValidation="True">
                    <Columns>
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/BlueTheme/Select.png" SelectText=""
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="ESTADO_INICIAL" HeaderText="DOCUMENTO ANTERIOR" SortExpression="ESTADO_INICIAL" Visible="False" />
                        <asp:BoundField DataField="ESTADO_FINAL" HeaderText="DOCUMENTO " SortExpression="ESTADO_FINAL" />
                        <asp:BoundField DataField="NRO_DOC" HeaderText="N° DOCUMENTO" SortExpression="Nro_Doc" />
                        <asp:BoundField DataField="FECHA" DataFormatString="{0:d}" HeaderText="FECHA" SortExpression="FECHA" />
                        <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" SortExpression="USUARIO" />
                        <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" Visible="False" />
                        <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" Visible="False" />
                        <asp:BoundField DataField="NVISITAS" HeaderText="N° VISITAS" Visible="True" />
                        <asp:BoundField DataField="por_eje_fis" HeaderText="% EJECUCIÓN FISICO" Visible="True"  >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VALOR_PAGO" HeaderText="VALOR AUTORIZADO A PAGAR" Visible="True" DataFormatString="{0:c}" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="EDITAR" 
                            ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                        <asp:TemplateField ShowHeader="False" HeaderText="ANULAR">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Anular" visible='<%#IIF((DataBinder.Eval(Container.DataItem, "Ult")="OK"),True,False)%>' 
                                    Text="Anular" CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex")) %>'  ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:ObjectDataSource ID="ObjEstContratos" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyCod_Con" 
                            TypeName="EstContratos" InsertMethod="Insert" UpdateMethod="Update">
                          
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DetContratoI1" Name="cod_con" 
                                    PropertyName="cod_con" Type="String" />
                            </SelectParameters>
                      
                        </asp:ObjectDataSource>


    <br />
    <br />

                </asp:Panel>
                </ContentTemplate>
                </asp:UpdatePanel>


    </div>
    </asp:Content>

