<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HRevisiones.aspx.vb" Inherits="Consultas_AvisosActD_HRevisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DetailsView ID="DtPCon" runat="server" AutoGenerateRows="False" 
                CellPadding="4" DataKeyNames="Num_Sol" EnableModelValidation="True" 
                Font-Size="X-Small" ForeColor="#333333" GridLines="None" Height="84px" 
                Width="95%">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EmptyDataTemplate>
                    <asp:Label ID="MsgResult" runat="server" CssClass="alerta" SkinID="MsgResult" 
                        Text="No se encontraro la solicitud en la base de datos "></asp:Label>
                </EmptyDataTemplate>
                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <Fields>
                    <asp:BoundField DataField="Cod_Sol" HeaderText="Número de la Solicitud" 
                        SortExpression="Cod_Sol">
                    <ItemStyle Font-Bold="True" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOM_TPROC" HeaderText="Modalidad de Contratación" 
                        SortExpression="NOM_TPROC" />
                    <asp:BoundField DataField="OBJ_SOL" HeaderText="Objeto" 
                        SortExpression="OBJ_SOL" />
                    <asp:BoundField DataField="Dep_Nec" 
                        HeaderText="Dependencia que Genera la Necesidad" SortExpression="Dep_Nec" />
                    <asp:BoundField DataField="DEP_DEL" 
                        HeaderText="Dependencia a Cargo del Proceso" SortExpression="DEP_DEL" />
                    <asp:BoundField DataField="Encargado" HeaderText="Funcionario Encargado" 
                        SortExpression="Encargado" />
                    <asp:BoundField DataField="EST_CONCEPTO" HeaderText="Concepto de Revisión" />
                </Fields>
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderTemplate>
                    INFORMACIÓN DETALLADA DE LA SOLICITUD
                </HeaderTemplate>
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:DetailsView>
            <br />
            <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
                Text="Historial de Revisiones"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="Cod_Sol,Id_HRev" Width="912px" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="Id_HRev" HeaderText="Id" SortExpression="Id_HRev" />
                    <asp:TemplateField HeaderText="Código de la Solicitud" SortExpression="Cod_Sol">
                        <ItemTemplate>
                            <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Cod_Sol") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de Registro" 
                        SortExpression="Fecha_Recibido">
                        <ItemTemplate>
                            <asp:Label ID="LbFec" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Fecha_Recibido","{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Recibido Abogado" 
                        SortExpression="Fec_Rec_Abog">
                        <ItemTemplate>
                            <asp:Label ID="LbFec_Rec_Abog" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Fec_Rec_Abog","{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacion Recibido" 
                        SortExpression="Obs_Recibido">
                        <ItemTemplate>
                            <asp:Label ID="LbEncSig" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Obs_Recibido_Abog") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de Revision">
                        <ItemTemplate>
                            <asp:Label ID="LbEncAnt" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Fecha_Revisado","{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacion Revision">
                        <ItemTemplate>
                            <asp:Label ID="LbRec" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Obs_Revisado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Concepto de la Revision">
                        <ItemTemplate>
                            <asp:Label ID="Lbobs" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Nom_Est") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Historico de Observaciones">
                        <ItemTemplate>
                            <asp:Label ID="LbhReV" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("HObs_Revisado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Abogado que Recibe" 
                        SortExpression="Nit_Abog_Recibe">
                        <ItemTemplate>
                            <asp:Label ID="LbAbog" runat="server" Text='<%# Bind("Encargado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="N° Proceso" SortExpression="Pro_Sel_Nro">
                        <ItemTemplate>
                            <asp:Label ID="LbNumPro" runat="server" Text='<%# Bind("Pro_Sel_Nro") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="Cod_Sol,Id_Hrev" 
                        DataNavigateUrlFormatString="~/Solicitudes/ReporteRevision/RptRv.aspx?Cod_Sol={0}&amp;Id_Hrev={1}&amp;dest=word" 
                        HeaderText="Imprimir Notificación" Target="_blank" Text="Exportar a Word" />
                    <asp:HyperLinkField DataNavigateUrlFields="Cod_Sol,Id_Hrev" 
                        DataNavigateUrlFormatString="~/Solicitudes/ReporteRevision/RptRv.aspx?Cod_Sol={0}&amp;Id_Hrev={1}&amp;dest=html" 
                        HeaderText="Imprimir Notificación" Target="_blank" Text="Imprimir" />
                </Columns>
                <EmptyDataTemplate>
                    No hay conceptos de revisión en el sistema
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

