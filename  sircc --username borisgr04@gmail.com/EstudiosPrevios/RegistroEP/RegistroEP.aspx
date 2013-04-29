<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RegistroEP.aspx.vb" Inherits="EstudiosPrevios_RegistroEP_RegistroEP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<style>
 .datatable TD TEXTAREA
 {
    border-style: none;
    border-color: inherit;
    border-width: 0px;    
    height:300px;
    width:90%;
 }
</style> <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="1" 
        MultiPageID="RadMultiPage1">
        <Tabs>
            <telerik:RadTab runat="server" Text="1. General" PageViewID="RdGeneral">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Selected="True"  PageViewID="RdNecesidad"
                Text="2.Necesidad y Justificación" SelectedIndex="3">
                <Tabs>
                    <telerik:RadTab runat="server" Text="2.1. La Necesidad" 
                        PageViewID="RdNecesidadDesc">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="2.2. Descripción Objeto " 
                        PageViewID="RdNecesidadDescObj">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" 
                        Text="2.3. Especificación del Objeto" PageViewID="RdNecesidadObj">
                        </telerik:RadTab>
                    <telerik:RadTab runat="server" 
                        Text="2.4. Condiciones de la Contratación" PageViewID="RdNecesidadCond" 
                        Selected="True">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="2.5. Objeto del contrato" 
                        PageViewID="RdNecesidadObjCon">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="4. Descripción financiera" PageViewID="RdDescripcionFinanciera">
            </telerik:RadTab>
            <telerik:RadTab runat="server" 
                Text="5. Evaluación " PageViewID="RdBasesEvaluacion">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="4">
        <telerik:RadPageView ID="RdGeneral" runat="server" Width="100%">
            <table class="datatable">
        <tr>
            <td colspan="3" style="font-weight: 700; text-align: center">
        
                Capítulo I: Descripción general</td>
            <td style="font-weight: 700; text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                1. Certificado de inclusión en el Banco de 
                Proyectos / Plan de Compras</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="50%"></asp:TextBox>
                
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="50%"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                2. Fecha de elaboración del estudio previo:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <telerik:RadDatePicker ID="RadDatePicker1" Runat="server">
                </telerik:RadDatePicker>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                3. Nombre del funcionario que diligencia el 
                estudio previo :</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TxtIdeFun" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtNomFunc" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
             4. Dependencia solicitante:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="CboDependencia" runat="server" DataSourceID="ObjDep" 
                    DataTextField="nom_dep" DataValueField="cod_dep">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                5. Tipo de Contrato:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" CssClass="txt" DataSourceID="ObjTiposCont"
                                                        DataTextField="Nom_Tip" DataValueField="Cod_Tip" Width="250px">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="cboStip" runat="server" CssClass="txt" DataSourceID="ObjSubTipos"
                                                        DataTextField="nom_stip" DataValueField="cod_stip" Width="250px">
                                                    </asp:DropDownList>
                
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RdNecesidad" runat="server" Width="100%">
         <table class="datatable">
        <tr>
            <td colspan="3">
                <b>
                TITULO II CAPÍTULO I 
                ARTÍCULO 2.1.1. NUMERAL 1 DECRETO 734 DE 
                2012 Descripción de la Necesidad</b></td>
        </tr>
        </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RdNecesidadDesc" runat="server" Width="100%">
        <table class="datatable">
        <tr>
            <td>
                6. Descripción de la Necesidad</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan=2>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RdNecesidadDescObj" runat="server" Width="100%">
        <table class="datatable">
        <tr>
            <td>
              7. Descripción del 
                objeto a contratar:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan=2>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RdNecesidadObjCon" runat="server" Width="100%">
        <table class="datatable">
         <tr>
            <td>
                8. Especificaciones del objeto a contratar:
                   </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        
        <tr>
            <td>
                8.1. Objeto del contrato:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan=2>
                <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
            </telerik:RadPageView>
        <telerik:RadPageView ID="RdNecesidadCond" runat="server" Width="100%">
        <table class="datatable">
        <tr>
            <td colspan="3">
            <strong>TITULO II CAPÍTULO I ARTÍCULO 2.1.1. NUMERAL 2 DECRETO 734 DE 2012 La 
                descripción del objeto a contratar, con sus especificaciones y la identificación 
                del contrato a celebrar</strong></td>
        </tr>
            <tr>
            <td>
                8.2. Condiciones de la Contratación:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan=2>
                <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan=2>
                8.2.1. Características del bien, obra o servicio a contratar (Especificaciones 
                Técnicas) </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                8.3. Plazo de ejecución del contrato:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                8.4. Lugar de ejecución del contrato:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                8.5. Obligaciones del contratista: </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                8.6. Obligaciones del Departamento </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                8.6. Obligaciones del Departamento </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    
        <tr>
            <td>
                9. Plazo de liquidación del contrato:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                10. Fundamentos Jurídicos de la modalidad de selección</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                SUPERVISÓN</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
            </telerik:RadPageView>
        <telerik:RadPageView ID="RdDescripcionFinanciera" runat="server" Width="100%">
            <table class="datatable">
        <tr>
            <td>
                <strong>Capítulo III: Descripción financiera</strong></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                12. Soporte técnico y económico del valor estimado del contrato</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                12.1 Presupuesto oficial ($):</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                12.2 Variables consideradas para calcular el presupuesto oficial:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                13. Forma de pago y requisitos:</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
            </telerik:RadPageView>
        <telerik:RadPageView ID="RdBasesEvaluacion" runat="server" Width="100%">
            
        <table class="datatable">
        <tr>
            <td>
                <strong>Capítulo IV: Bases para la Evaluación de Propuestas</strong></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                14. Justificación de los factores de selección</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <strong>14.1. Requisitos Habilitantes</strong></td>
            <td>
                &nbsp;</td>
            <td>
                |</td>
        </tr>
        <tr>
            <td>
                14.1. 1. Capacidad jurídica</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                14.1.2. Capacidad Financiera</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                14.1.3. Condiciones de experiencia</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                14.1.4. Capacidad residual de contratación </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                14.2. Factores de escogencia y calificación </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                15. Análisis de exigencias de garantías destinadas a amparar los perjuicios de 
                naturaleza contractual o extracontractual, derivados del cumplimiento del 
                ofrecimiento o del contrato, así como la pertinencia división de las mismas. </td>
        </tr>
        <tr>
            <td>
                NOMBRE: {RESPONSABLE} </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                CARGO: {CARGO_RESPONSABLE}</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Proyectó: {PROYECTO}</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                CARGO: {CARGO_APOYO_TECNICO}</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
            </telerik:RadPageView>
    </telerik:RadMultiPage>
    
    <asp:ObjectDataSource ID="ObjDep" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetRecords" TypeName="Dependencias"></asp:ObjectDataSource>
                                
    <asp:ObjectDataSource ID="ObjTiposCont" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetRecords" TypeName="Tipos"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjSubTipos" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetByTipo" TypeName="SubTipos">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="CboTip" Name="cod_tip" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>        
</asp:Content>

