<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GPRadicacion.aspx.vb" Inherits="Procesos_RadicarProc_GRadicacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
    
    <asp:UpdatePanel ID="UpdRad" runat="server">
        <ContentTemplate>
            <table style="width: 73%;">
                <tr>
                    <td style="width: 93px">
                        &nbsp;</td>
                    <td style="width: 180px">
                        &nbsp;</td>
                    <td style="width: 82px">
                        &nbsp;</td>
                    <td style="width: 26px">
                        &nbsp;</td>
                    <td style="width: 128px">
                        <asp:Label ID="Label10" runat="server" Text="Fecha de Radicacion"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 93px; height: 21px">
                        <asp:Label ID="Label1" runat="server" Text="Código del Proceso"></asp:Label>
                    </td>
                    <td style="height: 21px; width: 180px">
                        <asp:TextBox ID="TxtNumProc" runat="server" Width="177px" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td style="height: 21px; width: 82px">
                        <asp:DropDownList ID="CboGrupos" runat="server" AutoPostBack="True" 
                            DataSourceID="ObjGrupos" DataTextField="Grupos" DataValueField="Grupo">
                        </asp:DropDownList>
                    </td>
                    <td style="height: 21px; width: 26px;">
                        <asp:ImageButton ID="BtnBuscar" runat="server" SkinID="IBtnBuscar" />
                    </td>
                    <td style="height: 21px; width: 128px;">
                        <asp:TextBox ID="TxtFecRad" runat="server" Width="127px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender 
                        ID="FecRad" 
                        runat="server"
                        TargetControlID="TxtFecRad" 
                        Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <asp:FilteredTextBoxExtender 
                        ID="FilteredTextBoxExtender1" 
                        runat="server" 
                        TargetControlID="TxtFecRad" 
                        FilterType="Numbers, Custom" 
                        ValidChars="/">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td style="height: 21px">
                        <asp:ImageButton ID="BtnRadicar" runat="server" Height="32px" 
                            ImageUrl="~/images/Operaciones/sello.png" />
                    </td>
                </tr>
            </table>
            <table style="width: 73%;">
                <tr>
                    <td style="width: 139px">
                        <asp:Label ID="TxtTipDoc" runat="server" __designer:wfdid="w3" BackColor="Navy" 
                            Font-Bold="True" Font-Size="Medium" ForeColor="White" Width="147px"></asp:Label>
                    </td>
                    <td style="width: 140px">
                        <asp:Label ID="Label19" runat="server" CssClass="Caption" Font-Bold="True" 
                            Text="Ulitma Radicación"></asp:Label>
                    </td>
                    <td style="width: 161px">
                        <asp:Label ID="TxtUId" runat="server" __designer:wfdid="w3" BackColor="Navy" 
                            Font-Bold="True" Font-Size="Medium" ForeColor="White" Width="147px"></asp:Label>
                    </td>
                    <td style="width: 294px">
                        <asp:Label ID="TxtUFs" runat="server" __designer:wfdid="w3" BackColor="Navy" 
                            Font-Bold="True" Font-Size="Medium" ForeColor="White" Width="111%"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/Procesos/GRadicacion/MinProc.aspx" Target="_blank">Ver Minuta del Proceso</asp:HyperLink>
            &nbsp;<br />
            <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
                GridLines="None" HeaderText="Proceso Contractual" Height="50px" 
                Width="653px" DataSourceID="ObjPcont" EmptyDataText="No existe l Proceso">
                <AlternatingRowStyle BackColor="White" />
                <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                <EditRowStyle BackColor="#2461BF" />
                <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                <Fields>
                    <asp:BoundField DataField="Pro_Sel_Nro" HeaderText="Código">
                    <ItemStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vig_Con" HeaderText="Vigencia" />
                    <asp:BoundField DataField="Contratista" HeaderText="Contratista" />
                    <asp:BoundField DataField="Obj_Con" HeaderText="Objeto del Contrato" />
                    <asp:BoundField DataField="Pla_Eje_Con" 
                        HeaderText="Plazo de Ejecución" />
                    <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia de la Necesidad" />
                    <asp:BoundField DataField="Dep_Del" HeaderText="Dependencia a Cargo" />
                    <asp:BoundField DataField="Nom_TProc" HeaderText="Modalidad de Contratación" />
                    <asp:BoundField DataField="Nom_Tip" HeaderText="Documento Contractual" />
                    <asp:BoundField DataField="Lug_Eje" HeaderText="Lugar de ejecución" />
                    <asp:BoundField DataField="Val_Con" DataFormatString="{0:c}" 
                        HeaderText="Valor del Contrato" />
                    <asp:BoundField DataField="Val_Apo_Gob" HeaderText="Valor Aportes Propios" 
                        DataFormatString="{0:c}" />
                    <asp:BoundField DataField="Encargado" HeaderText="Encargado" />
                    <asp:BoundField DataField="Nom_Estado" HeaderText="Estado" />
                </Fields>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
            </asp:DetailsView>
            <br />
            Contratista(s)<asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Ide_Prop" 
                DataSourceID="ObjContratista" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                Width="589px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Identificación" SortExpression="Ide_Prop">
                        <ItemTemplate>
                            <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Ide_Prop") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre del Proponente" SortExpression="Nom_Ter">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Razon_Social") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de la Propuesta" SortExpression="Fec_Prop">
                        <ItemTemplate>
                            <asp:Label ID="LbEst" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Fec_Prop","{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor de la Propuesta" SortExpression="Val_Prop">
                        <ItemTemplate>
                            <asp:Label ID="LbVal" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Val_Prop","{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Adjudicado" SortExpression="Adjudicado">
                        <ItemTemplate>
                            <asp:Label ID="LbAdj" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Adjudicado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjContratista" runat="server" DeleteMethod="Delete" 
                InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetbyAdjuicado" TypeName="GPProponentes" UpdateMethod="Adjudicar">
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
                    <asp:ControlParameter ControlID="TxtNumProc" Name="Num_Proc" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" 
                        PropertyName="SelectedValue" Type="String" />
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
            <table style="width: 98%;">
                <tr>
                    <td style="height: 21px; width: 447px">
                    </td>
                    <td style="height: 21px; width: 56px;">
                        &nbsp;</td>
                    <td style="height: 21px; width: 440px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 447px" bgcolor="#003366">
                        <asp:Label ID="Label4" runat="server" CssClass="selectIndex" ForeColor="White" 
                            Text="Forma de Pago"></asp:Label>
                    </td>
                    <td style="width: 56px">
                        &nbsp;</td>
                    <td bgcolor="#003366" style="width: 440px">
                        <asp:Label ID="Label6" runat="server" CssClass="selectIndex" ForeColor="White" 
                            Text="Obligaciones"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 447px">
                        <div ID="DIV1" language="javascript" style="z-index: 101; overflow: auto; width: 439px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            title="Forma de Pago">
                            <asp:GridView ID="GrFPago" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="PagosParciales" 
                                EmptyDataText="No existen Pagos registrados para el proceso" 
                                EnableModelValidation="True" ShowFooter="True" SkinID="gridView" Width="483px">
                                <Columns>
                                    <asp:BoundField DataField="Nom_Pago" HeaderText="Tipo de Pago" />
                                    <asp:BoundField DataField="Valor_Pago" DataFormatString="{0:c}" 
                                        HeaderText="Valor del Pago">
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Porcentaje" DataFormatString="{0:p}" 
                                        HeaderText="Porcentaje">
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Condicion_Pago" HeaderText="Condicion de Pago" />
                                </Columns>
                            </asp:GridView>
                            <br />
                        </div>
                    </td>
                    <td style="width: 56px">
                        &nbsp;</td>
                    <td style="width: 440px">
                        <div ID="DIV5" language="javascript" style="z-index: 101; overflow: auto; width: 439px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            title="Obligaciones">
                            <asp:GridView ID="GrOblig" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="ObjPObligaciones" 
                                EmptyDataText="No existen Obligaciones registratas para el Proceso" 
                                EnableModelValidation="True" ShowFooter="True" SkinID="gridView" Width="441px">
                                <Columns>
                                    <asp:BoundField DataField="Des_Oblig" HeaderText="Obligaciones" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 447px">
                        &nbsp;</td>
                    <td style="width: 56px">
                        &nbsp;</td>
                    <td style="width: 440px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td bgcolor="#003366" style="width: 447px">
                        <asp:Label ID="Label9" runat="server" CssClass="selectIndex" ForeColor="White" 
                            Text="Proyectos"></asp:Label>
                    </td>
                    <td style="width: 56px">
                        &nbsp;</td>
                    <td bgcolor="#003366" style="width: 440px">
                        <asp:Label ID="Label3" runat="server" CssClass="selectIndex" ForeColor="White" 
                            Text="Certificados de Disponibilidad Presupuestal"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 447px">
                        <div ID="DIV3" language="javascript" style="z-index: 101; overflow: auto; width: 439px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            title="Proyectos">
                            <asp:GridView ID="GrProy" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="pproyectos" 
                                EmptyDataText="No existen Proyectos registrados para el proceso" 
                                EnableModelValidation="True" ShowFooter="True" SkinID="gridView" Width="486px">
                                <Columns>
                                    <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" />
                                    <asp:BoundField DataField="Nombre_Proyecto" HeaderText="Nombre del Proyecto" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                    <td style="width: 56px">
                        &nbsp;</td>
                    <td style="width: 440px">
                        <div ID="DIV4" language="javascript" style="z-index: 101; overflow: auto; width: 439px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            title="Certificados de Disponibilidad Presupuestal">
                            <asp:GridView ID="GrCDP" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="ObjCDP" 
                                EmptyDataText="No existen Certificados de Disponibilidad Presupestal registrados para el Proceso" 
                                EnableModelValidation="True" ShowFooter="True" SkinID="gridView" Width="441px">
                                <Columns>
                                    <asp:BoundField DataField="Nro_CDP" HeaderText="Nro. del Certificado" />
                                    <asp:BoundField DataField="Fec_CDP" HeaderText="Fecha del Certificado" />
                                    <asp:BoundField DataField="Val_CDP" DataFormatString="{0:c}" 
                                        HeaderText="Valor del Certificado">
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 447px">
                        &nbsp;</td>
                    <td style="width: 56px">
                        &nbsp;</td>
                    <td style="width: 440px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td bgcolor="#003366" style="width: 447px">
                        <asp:Label ID="Label8" runat="server" CssClass="selectIndex" ForeColor="White" 
                            Text="Rubros"></asp:Label>
                    </td>
                    <td style="width: 56px">
                        &nbsp;</td>
                    <td bgcolor="#003366" style="width: 440px">
                        <asp:Label ID="Label7" runat="server" CssClass="selectIndex" ForeColor="White" 
                            Text="Polizas"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 447px">
                        <div ID="DIV2" language="javascript" style="z-index: 101; overflow: auto; width: 439px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            title="Rubros">
                            <span>
                            <asp:GridView ID="GrRubros" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="Cod_Rub,Num_Pro" DataSourceID="Rubros" 
                                EmptyDataText="No existen Rubros registrados para el Proceso" 
                                EnableModelValidation="True" ShowFooter="True" SkinID="gridView" Width="486px">
                                <Columns>
                                    <asp:BoundField DataField="Cod_Rub" HeaderText="Código" />
                                    <asp:BoundField DataField="Val_Compromiso" DataFormatString="{0:c}" 
                                        HeaderText="Valor">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nro_Cdp" HeaderText="Certificado Presupuestal" />
                                </Columns>
                            </asp:GridView>
                            </span>
                        </div>
                    </td>
                    <td style="width: 56px">
                        &nbsp;</td>
                    <td style="width: 440px">
                        <div ID="DIV6" language="javascript" style="z-index: 101; overflow: auto; width: 439px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            title="Polizas">
                            <span>
                            <asp:GridView ID="GrvPpol" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="Cod_Pol,Num_Proc" DataSourceID="ppolizas" 
                                EmptyDataText="No existen Polizas registradas para el proceso" 
                                EnableModelValidation="True" ShowFooter="True" SkinID="gridView" Width="493px">
                                <Columns>
                                    <asp:BoundField DataField="Nom_Pol" HeaderText="Amparo" 
                                        SortExpression="Nom_Pol" />
                                    <asp:BoundField DataField="Por_SMMLV" HeaderText="% o SMMVL" 
                                        SortExpression="Por_SMMLV" />
                                    <asp:BoundField DataField="Nom_CalPol" HeaderText="Calcular a partir de" />
                                    <asp:BoundField DataField="Vigencia" HeaderText="Vigencia(días)" />
                                    <asp:BoundField DataField="Nom_CalVigPol" HeaderText="A partir de" />
                                    </Columns>
                            </asp:GridView>
                            </span>
                        </div>
                    </td>
                </tr>
            </table>
<br />
        </ContentTemplate>
    </asp:UpdatePanel>
<span>
                            <asp:ObjectDataSource ID="PagosParciales" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
                                TypeName="Pagos_Gprocesos">
                                <SelectParameters>



                                    <asp:ControlParameter ControlID="TxtNumProc" Name="Num_Proc" PropertyName="Text" 
                                        Type="String" />
                

                                    <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" 
                                        PropertyName="SelectedValue" Type="String">
                
                                    </asp:ControlParameter>
                
                                </SelectParameters>
                            </asp:ObjectDataSource>

                 
                            <asp:ObjectDataSource ID="pproyectos" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
                                TypeName="GPProyectos">
                                <SelectParameters>



                                    <asp:ControlParameter ControlID="TxtNumProc" Name="Num_Proc" PropertyName="Text" 
                                        Type="String" />
                

                                    <asp:ControlParameter ControlID="CboGrupos" Name="grupo" 
                                        PropertyName="SelectedValue" Type="String">
                
                                    </asp:ControlParameter>
                
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="Rubros" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
                                TypeName="RubrosPcontratos">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="TxtNumProc" Name="Num_Proc" PropertyName="Text" 
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ppolizas" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyTproc" 
                        TypeName="GPPolizas">
                        <SelectParameters>

                            <asp:ControlParameter ControlID="TxtNumProc" Name="Num_Proc" 
                                PropertyName="Text" Type="String">
                
                            </asp:ControlParameter>
                            <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" PropertyName="SelectedValue" 
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </span>
    <asp:ObjectDataSource ID="ObjPObligaciones" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="GPObligaciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtNumProc" Name="Num_PCon" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjCDP" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="CDP_GProcesos">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtNumProc" Name="Num_Pcon" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjPcont" runat="server" InsertMethod="InsertP" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetByPkRad" 
                TypeName="ConGProcesos">
                <InsertParameters>
                    <asp:Parameter Name="COD_TPRO" Type="String" />
                    <asp:Parameter Name="OBJ_CON" Type="String" />
                    <asp:Parameter Name="DEP_CON" Type="String" />
                    <asp:Parameter Name="DEP_PCON" Type="String" />
                    <asp:Parameter Name="VIG_CON" Type="Decimal" />
                    <asp:Parameter Name="TIP_CON" Type="String" />
                    <asp:Parameter Name="STIP_CON" Type="String" />
                    <asp:Parameter Name="FEC_RECIBIDO" Type="DateTime" />
                    <asp:Parameter Name="NUM_SOL" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtNumProc" Name="Num_PCon" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" 
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjGrupos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyProc" 
            TypeName="Grupos">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtNumProc" Name="Num_Proc" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    <br />
    <asp:Panel ID="PanelvConP" runat="server" BackColor="White" Width="900px" Height="500px">
            <asp:Panel ID="Panel6" runat="server" CssClass="BarTitleModal2" BorderColor="White" 
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
                            <asp:Button ID="BtnCerrar2" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
            <uc4:ConPContratos ID="ConPContratos1" runat="server" />
            
            </asp:Panel>
             </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Btn_Target2" runat="server"></asp:Button>
           <ajaxToolkit:ModalPopupExtender ID="ModalPopupConP" 
        runat="server"
        TargetControlID="Btn_Target2" 
        PopupControlID="PanelvConP" 
        CancelControlID="BtnCerrar2" 
        BackgroundCssClass="modalBackground"
        PopupDragHandleControlID="Panel4" 
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>   
</div>
</asp:Content>

