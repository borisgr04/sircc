﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DetContratoAdi.ascx.vb" Inherits="Controles_DetContratoAdi" %>
            <table >
                <tr>
                    <td >
                        <asp:Label ID="Label1" runat="server" CssClass="Caption" Text="Tipo"></asp:Label>
                    </td>
                    <td >
                        <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" CssClass="txt" 
                            DataSourceID="ObjTiposCont" DataTextField="NOM_TIP" DataValueField="COD_TIP">
                        </asp:DropDownList>
                    </td>
                    <td >
                        <asp:Label ID="Label2" runat="server" CssClass="Caption" Text="Número"></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="TxtCodCon" runat="server" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td >
                        <asp:Label ID="Label4" runat="server" Text="Solicitud"></asp:Label>
                    </td>
                    <td >
                        <asp:DropDownList ID="CboNumSol" runat="server" DataSourceID="ObjSolAdi" 
                            DataTextField="Nom_Tip" DataValueField="Num_Sol_Adi" Height="16px" 
                            Width="204px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td  >
                        <asp:ImageButton ID="ImageButton1" runat="server" SkinID="IBtnBuscar" />
                    </td>
               
                    <td  >
                        <asp:Label ID="LbCodCod" runat="server"></asp:Label>
                    </td>
               
                </tr>
                <tr>
                    <td colspan="8" style="height: 14px; text-align: center;">
                        <asp:Label ID="MsgResult" runat="server" Height="30px" Visible="False" 
                            Width="90%"></asp:Label>
                    </td>
                </tr>
                </table>
                <div style="height:200px; overflow:auto" >
                <table >
                <tr>
                    <td colspan="6">
                        <asp:DetailsView ID="DtPCon" runat="server" AutoGenerateRows="False" 
                            CellPadding="4" DataKeyNames="Cod_Tpro" Font-Size="Small" ForeColor="#333333" 
                            GridLines="None" Height="84px" Width="95%" EnableModelValidation="True">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <Fields>
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                                <asp:BoundField DataField="Numero" HeaderText="Número" SortExpression="Numero" >
                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Size="Medium" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OBJ_CON" HeaderText="Objeto"  SortExpression="OBJ_CON" />
                                <asp:BoundField DataField="CONTRATISTA" HeaderText="Contratista" SortExpression="CONTRATISTA" />
                                <asp:BoundField DataField="FEC_SUS_CON" HeaderText="Fecha de Suscripción" SortExpression="FEC_SUS_CON" DataFormatString="{0:d}"  />
                                
                                <asp:BoundField DataField="Valor_Total_Prop" DataFormatString="{0:c}" 
                                    HeaderText="Valor Total   "  >
                                <ItemStyle Font-Bold="True" Font-Size="Medium" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PLAZO_TOTAL" HeaderText="Plazo de Ejecución Total" />

                                <asp:BoundField DataField="VAL_CON" DataFormatString="{0:c}" HeaderText="Valor Inicial  "  />
                                <asp:BoundField DataField="PLA_EJE_CON" HeaderText="Plazo de Ejecución Inicial"  />

                                <asp:BoundField DataField="NRO_ADI" HeaderText="Cantidad de Adiciones " />
                                <asp:BoundField DataField="VAL_ADI" DataFormatString="{0:c}" HeaderText="Valor Adicionado " />
                                <asp:BoundField DataField="PLA_ADI" HeaderText="Plazo de Ejecución Adicional"  />

                                 <asp:BoundField DataField="Valor_Total_Doc" DataFormatString="{0:c}" HeaderText="Valor Total del Contrato/Convenio"  />

                                 <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Acta de Inicio" DataFormatString="{0:d}"  />
                                 <asp:BoundField DataField="fec_apr_pol" HeaderText="Fecha Aprobación de la Póliza" DataFormatString="{0:d}"  />
                                
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                <asp:BoundField DataField="Dependencia" HeaderText="Dependencia que Genera la Necesidad" SortExpression="Dependencia" />
                                <asp:BoundField DataField="DependenciaP" HeaderText="Dependencia a Cargo del Proceso" SortExpression="DependenciaP" />
                                <asp:BoundField DataField="EncargadoCont" HeaderText="Encargado del Contrato" />
                                <asp:BoundField DataField="Num_Sol_Adi" 
                                    HeaderText="Numero de Solicitud de Adición">
                                <ItemStyle Font-Size="Medium" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nom_Tip" HeaderText="Tipo de Solicitud" />
                                <asp:BoundField DataField="Fec_Recibido" 
                                    HeaderText="Fecha de recepcion de la Solicitud" />
                                <asp:BoundField DataField="EncargadoSol" 
                                    HeaderText="Encargado de la Solicitud" />
                            </Fields>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderTemplate>
                                INFORMACIÓN DETALLADA DEL CONTRATO
                            </HeaderTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:DetailsView> 
                <br />
                    </td>
                </tr>
            </table>
        
        </div>


                

    
       <asp:ObjectDataSource ID="ObjTiposCont" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Tipos"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjContratos" runat="server"  
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByPk" 
                            TypeName="Contratos">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" PropertyName="Text" 
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Vigencias"></asp:ObjectDataSource>
        
            <asp:ObjectDataSource ID="ObjSolAdi" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Sol_Adiciones" InsertMethod="Update">
                <InsertParameters>
                    <asp:Parameter Name="PK" Type="String" />
                    <asp:Parameter Name="Cod_Con" Type="String" />
                    <asp:Parameter Name="Tip_Adi" Type="String" />
                    <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
                    <asp:Parameter Name="OBSERVACION" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        
                <asp:DropDownList ID="CmbVigencia" runat="server" AutoPostBack="True" 
                    DataSourceID="ObjVigencias" DataTextField="Year_Vig" 
                    DataValueField="Year_Vig" Visible="False">
                </asp:DropDownList>
                        <asp:Label ID="Label3" runat="server" CssClass="Caption" Text="Vigencia" 
                            Visible="False"></asp:Label>
                