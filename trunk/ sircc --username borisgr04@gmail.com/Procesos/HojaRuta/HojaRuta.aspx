<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="HojaRuta.aspx.vb" Inherits="Procesos_HojaRuta_HojaRuta" %>

<%@ Register Src="../../CtrlUsr/AyudaIzq/ctrAyudIzql.ascx" TagName="ctrAyudIzql"
    TagPrefix="uc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Datos de la Solicitud/Proceso de Contratación</legend>
                <p>
                    <asp:Label ID="LbCodSol" runat="server" Text="Solicitud N°"> </asp:Label>
                    <asp:TextBox ID="TxtCodSol" runat="server" Enabled="False"></asp:TextBox>
                    <asp:Label ID="LbNroProc" runat="server" Text="Proceso N°"></asp:Label>
                    <asp:TextBox ID="TxtNroProc" runat="server" Enabled="False"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="LbObjeto" runat="server" Text="Objeto a Contratar"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="TxtObjeto" runat="server" Enabled="False" TextMode="MultiLine" Width="90%"></asp:TextBox>
                </p>
            </fieldset>
            <asp:CheckBox ID="ChkEtapaF" runat="server" AutoPostBack="True" Text="Filtrar por Etapa" />
            <asp:DropDownList ID="CboEtapas" runat="server" AutoPostBack="True" DataSourceID="ObjEtapas"
                DataTextField="Nom_Eta" DataValueField="Cod_Eta">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjEtapas" runat="server" SelectMethod="GetEtapas" TypeName="Hojas_Rutas">
            </asp:ObjectDataSource>
            <hr />
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                SelectedIndex="1">
                <Tabs>
                    <telerik:RadTab runat="server" Text="Documentos Sin Seleccionar" 
                        PageViewID="RadPageView1">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Documentos Seleccionados" 
                        PageViewID="RadPageView1" Selected="True">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageView1" runat="server">
                    <br />
                    <asp:Label ID="LbSubTit" runat="server" CssClass="SubTitulo" Text="Documentos Relacionados"></asp:Label>
                    <uc1:ctrAyudIzql ID="ctrAyudIzql1" runat="server" />
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="IBtnGuardar" runat="server" SkinID="IBtnGuardar" />
                            </td>
                            <td style="text-align: center">
                                <asp:ImageButton ID="IBtnPDF" runat="server" SkinID="IBtnPDF" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Guardar
                            </td>
                            <td style="text-align: center">
                                Hoja de Ruta<br /> PDF
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                    <asp:HiddenField ID="HdTip" runat="server" Value="SIN" />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjHR"
                        Width="94%" EnableModelValidation="True">
                        <Columns>
                            <asp:TemplateField>
                                <%--<EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("cod_sol") %>' />
                        </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkSel" runat="server" Checked='<%# MostrarCheck(Eval("cod_sol")) %>'
                                        Enabled="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="LbCodTip" runat="server" Enabled="true" Text='<%# Bind("Cod_Tip") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nom_Eta" HeaderText="Etapa" />
                            <asp:BoundField DataField="Nom_Doc" HeaderText="Documento" />
                            <asp:BoundField DataField="Doc_Oblig" HeaderText="Obligatorio" />
                            <asp:TemplateField HeaderText="Fecha Documento">
                                <ItemTemplate>
                                    <telerik:RadDatePicker ID="TxtFecDoc" runat="server">
                                    </telerik:RadDatePicker>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Observación">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtIdeDoc" runat="server" Enabled="true" Text='<%# Bind("Ide_Doc") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
            <div style="visibility: hidden">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="100%">
                    <LocalReport ReportPath="Reportes\HojaRuta\RptHR.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjHRSolPro" Name="DataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjSolPro" Name="DataSet2" />
                            <rsweb:ReportDataSource DataSourceId="ObjDsEntidad" Name="DataSet3" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
            </div>
            <asp:ObjectDataSource ID="ObjDsEntidad" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetDatos" TypeName="EntidadMin"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjSolPro" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetSolPro" TypeName="HRSolProDAO">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodSol" DefaultValue="" Name="Cod_Sol" PropertyName="Text"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="IBtnPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
    <asp:ObjectDataSource ID="ObjHR" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetRecords" TypeName="Hojas_Rutas">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtCodSol" DefaultValue="" Name="Cod_Sol" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="HdTip" DefaultValue="" Name="Tip" PropertyName="Value"
                Type="String" />
            <asp:ControlParameter ControlID="CboEtapas" Name="Eta" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="ChkEtapaF" Name="FEtapa" PropertyName="Checked"
                Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjHRSolPro" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetRecords" TypeName="Hojas_Rutas">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtCodSol" DefaultValue="" Name="Cod_Sol" PropertyName="Text"
                Type="String" />
            <asp:Parameter DefaultValue="CON" Name="Tip" Type="String" />
            <asp:Parameter Name="Eta" Type="String" />
            <asp:Parameter Name="FEtapa" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>
