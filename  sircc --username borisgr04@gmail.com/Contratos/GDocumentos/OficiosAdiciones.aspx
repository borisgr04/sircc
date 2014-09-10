<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="OficiosAdiciones.aspx.vb" Inherits="Contratos_GDocumentos_OficiosAdiciones" %>

<%@ Register Src="../../CtrlUsr/DetContratos/DetContrato.ascx" TagName="DetContrato" TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/grdAdiC/grdAdiC.ascx" TagName="grdAdiC" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>

        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label><br />
        <uc2:DetContrato ID="DetContratoN1" runat="server" OnAceptarClicked="DetContratoN1_AceptarClicked" />
        <br />


        <asp:ObjectDataSource ID="ObjObli" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords"
            TypeName="CObligaciones">
            <SelectParameters>
                <asp:ControlParameter ControlID="DetContratoN1" Name="Cod_Con"
                    PropertyName="Cod_Con" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <br />
        
        <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="grd" runat="server" AllowSorting="True"
                AutoGenerateColumns="False" DataKeyNames="NRO_ADI" EnableModelValidation="True"
                ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="N° Documento">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NRO_ADI") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo Documento">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("NOM_tip") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de Suscripción">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server"
                                Text='<%# Bind("FEC_SUS_ADI", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Plazo de Ejecución">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("PLA_EJE_ADI") %>'></asp:Label>
                        </ItemTemplate>

                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Adición">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("VAL_ADI", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>

                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Obser" HeaderText="Observación" />
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                </Columns>

            </asp:GridView>


        </asp:Panel>
        <br />
        <br />
        <br />
        &nbsp;<asp:LinkButton ID="LnkRPC" runat="server" Visible="False">SOLICITUD   DE   REGISTRO  PRESUPUESTAL DE  COMPROMISOS</asp:LinkButton><br />
        &nbsp;<asp:LinkButton ID="LinkDesSup" runat="server" Visible="False">CARTA DE DESIGNACION DE SUPERVISOR</asp:LinkButton>



        <asp:ObjectDataSource ID="ObjTipAdic" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords"
            TypeName="Tipo_Adciones"></asp:ObjectDataSource>

    </div>
</asp:Content>


