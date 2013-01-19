<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DetContratoI.ascx.vb" Inherits="Interventorias_CtrlUsr_DetContratosI" %>
     <asp:DetailsView ID="DtPCon" runat="server" AutoGenerateRows="False" CellPadding="4"
                        DataKeyNames="Cod_Tpro" EnableModelValidation="True" Font-Size="Small" ForeColor="#333333"
                        GridLines="None" Height="84px" Width="95%" EmptyDataText="El contrato, no se encuentra en el estado correspondiente para hacer plan de anticipo&quot;">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EmptyDataTemplate>
                            <br />
                            El Contrato no existe o pertenece a una Delegación de la cual no esta autorizado.
                        </EmptyDataTemplate>
                        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <Fields>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                            <asp:BoundField DataField="Numero" HeaderText="Número" SortExpression="Numero">
                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Size="Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OBJ_CON" HeaderText="Objeto" SortExpression="OBJ_CON" />
                            <asp:BoundField DataField="CONTRATISTA" HeaderText="Contratista" SortExpression="CONTRATISTA" />
                            <asp:BoundField DataField="FEC_SUS_CON" DataFormatString="{0:d}" HeaderText="Fecha de Suscripción"
                                SortExpression="FEC_SUS_CON" />
                            <asp:BoundField DataField="Valor_Total_Prop" DataFormatString="{0:c}" HeaderText="Valor Total   ">
                                <ItemStyle Font-Bold="True" Font-Size="Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PLAZO_TEXTO" HeaderText="Plazo de Ejecución Inicial" />
                            <asp:BoundField DataField="PLA_ADI" HeaderText="Plazo de Ejecución Adicional" />
                            <asp:BoundField DataField="PLA_EJE_CON" HeaderText="Plazo de Ejecución Total en Dias" />
                            <asp:BoundField DataField="VAL_CON" DataFormatString="{0:c}" HeaderText="Valor Inicial  " />
                            <asp:BoundField DataField="NRO_ADI" HeaderText="Cantidad de Adiciones " />
                            <asp:BoundField DataField="VAL_ADI" DataFormatString="{0:c}" HeaderText="Valor Adicionado " />
                            <asp:BoundField DataField="PLA_ADI" HeaderText="Plazo de Ejecución Adicional" />
                            <asp:BoundField DataField="Valor_Total_Doc" DataFormatString="{0:c}" HeaderText="Valor Total del Contrato/Convenio" />
                            <asp:BoundField DataField="FechaInicio" DataFormatString="{0:d}" HeaderText="Fecha de Acta de Inicio" />
                            <asp:BoundField DataField="fec_apr_pol" DataFormatString="{0:d}" HeaderText="Fecha Legalización" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:BoundField DataField="Dependencia" HeaderText="Dependencia que Genera la Necesidad"
                                SortExpression="Dependencia" />
                            <asp:BoundField DataField="DependenciaP" HeaderText="Dependencia a Cargo del Proceso"
                                SortExpression="DependenciaP" />
                            <asp:BoundField DataField="Abogado" HeaderText="Proyectó" />
                            <asp:BoundField DataField="RevisadoPor" HeaderText="Revisado Por" />
                        </Fields>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderTemplate>
                            INFORMACIÓN DETALLADA DEL CONTRATO
                        </HeaderTemplate>
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:DetailsView>
               