<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CrGPProponentes.ascx.vb" Inherits="CtrlUsr_CrProponentes_CrProponentes" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>


<style type="text/css">
    .style1
    {
        width: 529px;
    }
    .style5
    {
        width: 57px;
    }
    .style6
    {
        width: 60px;
    }
    .style10
    {
        width: 406px;
    }
    .style13
    {
        width: 40px;
        text-align: center;
    }
    .style14
    {
        width: 31px;
        text-align: center;
    }
    .style15
    {
        width: 4px;
        text-align: center;
    }
    .style16
    {
        width: 83px;
    }
    .style20
    {
    }
    .style23
    {
        width: 64px;
    }
    .style24
    {
        width: 82px;
    }
    .style25
    {
    }
    .style26
    {
        width: 68px;
    }
    .style27
    {
        width: 96px;
    }
    .style28
    {
        width: 361px;
    }
</style>


<%-- <script type="text/javascript">
         
            
          function ColocarNit(){
            
                document.aspnetForm.<%=Me.TxtDVER.ClientID%>.value="";

                if(document.aspnetForm.<%=Me.CbTdoc.ClientID%>.value=="NI")
                {
                    var dv=calcularDV(document.aspnetForm.<%=Me.TxtNit.ClientID%>.value);
                    document.aspnetForm.<%=Me.TxtDVER.ClientID%>.value=dv;

                }
            }

            function ArmarNombre(){
            
            var ape1=document.aspnetForm.<%=Me.TxtApe1.ClientID%>.value;
            var ape2=document.aspnetForm.<%=Me.TxtApe2.ClientID%>.value;
            var nom1=document.aspnetForm.<%=Me.TxtNom1.ClientID%>.value;
            var nom2=document.aspnetForm.<%=Me.TxtNom2.ClientID%>.value;
            document.aspnetForm.<%=Me.TxtNom.ClientID%>.value=ape1+" "+ape2+" "+nom1+" "+nom2;           
            
            }
   
        function zero_fill(i_valor, num_ceros) {
        relleno = ""
        i = 1
        salir = 0
        while ( ! salir ) {
        total_caracteres = i_valor.length + i
        if ( i > num_ceros || total_caracteres > num_ceros )
        salir = 1
        else
        relleno = relleno + "0"
        i++
        }

        i_valor = relleno + i_valor
        return i_valor
        }

        function calcularDV(i_rut) {
        var pesos = new Array(71,67,59,53,47,43,41,37,29,23,19,17,13,7,3); 
        rut_fmt = zero_fill(i_rut, 15)
        suma = 0
        for ( i=0; i<=14; i++ ) 
        suma += rut_fmt.substring(i, i+1) * pesos[i]
        resto = suma % 11
        if ( resto == 0 || resto == 1 )
        digitov = resto
        else
        digitov = 11 - resto

        return(digitov)
        }

       </script>--%>

       <div>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> 
            &nbsp;<asp:Label id="Tit" runat="server" CssClass="Titulo" Text="TERCEROS"></asp:Label>&nbsp; <BR />
            <asp:Label id="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>&nbsp; <BR />
            <asp:ValidationSummary id="ValidationSummary1" runat="server" Width="280px" SkinID="ValidationSummary1" 
                ValidationGroup="Guardar" DisplayMode="List"></asp:ValidationSummary> 

<TABLE style="WIDTH: 661px"><TBODY>
    <TR><TD class="style1">
        <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
        </TD>
        <TD style="WIDTH: 60px">
            &nbsp;</TD>
        <TD class="style28">&nbsp;</TD>
        <td valign="middle">&nbsp;</td>
        <TD style="WIDTH: 100px">
            &nbsp;</TD></TR>
    <tr>
        <td class="style1">
            Tipo de Proponente</td>
        <td style="WIDTH: 60px">
            <asp:DropDownList ID="CboTipProp" runat="server" AutoPostBack="True" 
                Width="138px" DataSourceID="ObjTipProp" 
                DataTextField="Nom_TipProp" DataValueField="Cod_TipProp">
                <asp:ListItem>SELECCIONE...</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="style28">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                ControlToValidate="CboTipProp" 
                ErrorMessage="Debe seleccionar el tipo de proponente" 
                InitialValue="SELECCIONE..." ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td valign="middle">
            &nbsp;</td>
        <td style="WIDTH: 100px">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Tipo Documento<asp:RequiredFieldValidator ID="RequiredFieldValidator16" 
                runat="server" ControlToValidate="CbTdoc" 
                ErrorMessage="Debe seleccionar el tipo de documento" 
                InitialValue="SELECCIONE..." ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td style="WIDTH: 60px">
            <asp:DropDownList ID="CbTdoc" runat="server" DataSourceID="ObjTD" 
                DataTextField="TDOC_NOM" DataValueField="TDOC_COD" Width="210px">
                <asp:ListItem>SELECCIONE...</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="style28">
            Número&nbsp; Identificación<asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                runat="server" ControlToValidate="TxtNit" ErrorMessage="Nit, Campo Requerido" 
                SetFocusOnError="True" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td valign="middle">
            <asp:TextBox ID="TxtNit" runat="server" Width="152px" AutoPostBack="True"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="TxtNit_FilteredTextBoxExtender" 
                runat="server" FilterType="Numbers" TargetControlID="TxtNit" 
                ValidChars="" Enabled="True">
            </ajaxToolkit:FilteredTextBoxExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TxtNit" Display="None" 
                ErrorMessage="Debe digitar la identificacion" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td style="WIDTH: 100px">
            <asp:TextBox ID="TxtDver" runat="server" Enabled="False" ReadOnly="True" 
                Rows="1" Width="20px"></asp:TextBox>
        </td>
    </tr>
    <TR><TD class="style1">Lugar de Expedición</TD>
        <TD style="WIDTH: 60px" colspan="4">
             <asp:TextBox ID="TxtLugExp" runat="server" Width="535px"></asp:TextBox>
             </TD>
    </TR>
    <tr>
        <td class="style1">
            Primer Apellido<asp:RequiredFieldValidator ID="RequiredFieldValidator17" 
                runat="server" ControlToValidate="TxtApe1" 
                ErrorMessage="Debe digitar el Primer Apellido" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td style="WIDTH: 60px">
            <asp:TextBox ID="TxtApe1" runat="server" Width="210px"></asp:TextBox>
        </td>
        <td class="style28">
            Segundo Apellido</td>
        <td colspan="2">
            <asp:TextBox ID="TxtApe2" runat="server" Width="189px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Primer Nombre<asp:RequiredFieldValidator ID="RequiredFieldValidator18" 
                runat="server" ControlToValidate="TxtNom1" Display="None" 
                ErrorMessage="Debe digita el Primer Nombre" ValidationGroup="GuardarP">*</asp:RequiredFieldValidator>
        </td>
        <td style="WIDTH: 60px">
            <asp:TextBox ID="TxtNom1" runat="server" Width="210px"></asp:TextBox>
        </td>
        <td class="style28">
            Segundo Nombre</td>
        <td colspan="2">
            <asp:TextBox ID="TxtNom2" runat="server" Width="189px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Razón Social</td>
        <td colspan="4">
            <asp:TextBox ID="TxtNom" runat="server" Width="535px" AutoPostBack="True" 
                ValidationGroup="EditNew"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                ControlToValidate="TxtNom" ErrorMessage="Debe diligenciar la Razon Social" 
                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <TR><TD class="style1">Dirección</TD>
        <TD style="WIDTH: 60px">
            <asp:TextBox ID="TxtDir" runat="server" Width="189px"></asp:TextBox>
        </TD>
        <td class="style28">
            Municipio/Dpto</td>
        <td colspan="2">
            <asp:TextBox ID="TxtMun" runat="server" Width="189px"></asp:TextBox>
        </td>
        </TR>
    <tr>
        <td class="style1">
            E-Mail<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                runat="server" ControlToValidate="TxtEma" Display="None" 
                ErrorMessage="Debe escribir un Email de la forma corre@dominio.com" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="Guardar">*</asp:RegularExpressionValidator>
        </td>
        <td style="WIDTH: 60px">
            <asp:TextBox ID="TxtEma" runat="server" Width="145px" ValidationGroup="Guardar"></asp:TextBox>
        </td>
        <td class="style28">
            Teléfono</td>
        <td colspan="2">
            <asp:TextBox ID="TxtTel" runat="server" Width="189px"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
                runat="server" FilterType="Numbers, Custom" TargetControlID="TxtTel" 
                ValidChars=",">
            </ajaxToolkit:FilteredTextBoxExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Identificacion Representante<asp:RequiredFieldValidator 
                ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxtIdRepLeg" 
                ErrorMessage="Debe diligenciar la identificación del Representante Legal" 
                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            &nbsp;Legal</td>
        <td style="WIDTH: 60px">
            <asp:TextBox ID="TxtIdRepLeg" runat="server"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" 
                runat="server" FilterType="Numbers" TargetControlID="TxtIdRepLeg">
            </ajaxToolkit:FilteredTextBoxExtender>
        </td>
        <td class="style28">
            Representante Legal<asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                runat="server" ControlToValidate="TxtRepLeg" 
                ErrorMessage="Debe diligenciar el nombre del Representante Legal" 
                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td colspan="2">
            <asp:TextBox ID="TxtRepLeg" runat="server" Width="189px" AutoPostBack="True" 
                Height="16px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label20" runat="server" Text="Fecha de la Propuesta"></asp:Label>
        </td>
        <td style="WIDTH: 60px">
            <asp:TextBox ID="TxtFecProp" runat="server" ValidationGroup="Guardar"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                Format="dd/MM/yyyy" TargetControlID="TxtFecProp">
            </ajaxToolkit:CalendarExtender>
        </td>
        <td class="style28">
            <asp:CompareValidator ID="CvFecha" runat="server" 
                ControlToValidate="TxtFecProp" 
                ErrorMessage="La fecha de la propuesta debe ser anterior o igual a la fecha actual" 
                Operator="LessThanEqual" Type="Date" ValidationGroup="Guardar">*</asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                runat="server" ControlToValidate="TxtFecProp" 
                ErrorMessage="Fecha Obligatoria" 
                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label27" runat="server" Text="Valor de la Propuesta "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                ControlToValidate="TxtValProp" Display="None" 
                ErrorMessage="Debe digita el Valor de la Propuesta" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td style="WIDTH: 60px">
            <asp:TextBox ID="TxtValProp" runat="server"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                runat="server" FilterType="Numbers, Custom" TargetControlID="TxtValProp" 
                ValidChars=".">
            </ajaxToolkit:FilteredTextBoxExtender>
        </td>
        <td class="style28">
            <asp:Label ID="Label32" runat="server" Text="No. de Folios"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                ControlToValidate="TxtNumFolio" ErrorMessage="N° de Folios es Obligatorio" 
                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td colspan="2">
            <asp:TextBox ID="TxtNumFolio" runat="server"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
                runat="server" FilterType="Numbers" TargetControlID="TxtNumFolio">
            </ajaxToolkit:FilteredTextBoxExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Observación</td>
        <td colspan="4">
            <asp:TextBox ID="TxtObs" runat="server" Height="65px" MaxLength="200" 
                TextMode="MultiLine" Width="550px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label34" runat="server" 
                Text="En que consisten los Aportes (Caso de Convenios)"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="TxtAportes" runat="server" Height="65px" MaxLength="200" 
                TextMode="MultiLine" Width="550px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label33" runat="server" Text="Denominación"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="TxtDenominacion" runat="server" Width="200px">CONTRATISTA</asp:TextBox>
        </td>
    </tr>
    </TBODY></TABLE>
           
            <table style="width: 86%;">
                <tr>
                    <td class="style25" colspan="2">
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                            Text="Poliza de Seriedad de la Oferta" />
                    </td>
                    <td class="style26">
                        &nbsp;</td>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style23">
                        &nbsp;</td>
                    <td class="style6">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style27">
                        No. de Poliza</td>
                    <td class="style24">
                        <asp:TextBox ID="TxtNumPol" runat="server" AutoPostBack="True" Width="76px"></asp:TextBox>
                    </td>
                    <td class="style26">
                        Fecha Inicial
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                            ControlToValidate="TxtFecIni" ErrorMessage="Debe seleccionar o escribir una fecha" 
                            ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style16">
                        <asp:TextBox ID="TxtFecIni" runat="server" Width="76px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalFecIni" runat="server" Format="dd/MM/yyyy" 
                            TargetControlID="TxtFecIni">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                    <td class="style5">
                        Fecha Final</td>
                    <td class="style23">
                        <asp:TextBox ID="TxtFecFin" runat="server" Width="76px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                            Format="dd/MM/yyyy" TargetControlID="TxtFecFin">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                    <td class="style6">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="TxtFecIni" ControlToValidate="TxtFecFin" 
                            ErrorMessage="La Fecha Final debe ser Superior a la Fecha Inicial" 
                            Operator="GreaterThan" Type="Date" ValidationGroup="Guardar">*</asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                            ControlToValidate="TxtFecFin" ErrorMessage="Debe seleccionar o escribir una fecha" 
                            ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style27">
                        Valor de&nbsp; la Poliza
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                            ControlToValidate="TxtValPol" ErrorMessage="ionar o escribir una fecha" 
                            ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style24">
                        <asp:TextBox ID="TxtValPol" runat="server" Width="76px"></asp:TextBox>
                    </td>
                    <td class="style26">
                        Aseguradora</td>
                    <td class="style20" colspan="4">
                        <asp:DropDownList ID="CboAseguradora" runat="server" 
                            DataSourceID="ObjAseguradora" DataTextField="Nom_Ase" DataValueField="Cod_Ase" 
                            Height="19px" Width="280px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <table style="width: 84%;">
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style10" colspan="3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style15">
                        <asp:ImageButton ID="BtnAgregar" runat="server" CausesValidation="False" 
                            CommandName="Nuevo" onclick="BtnAgregar_Click" SkinID="IBtnNuevo" />
                    </td>
                    <td class="style14">
                        &nbsp;<asp:ImageButton ID="BtnSave" runat="server" onclick="Btnsave_Click" 
                            SkinID="IBtnGuardar" ValidationGroup="Guardar" />
                    </td>
                    <td class="style13">
                        <asp:ImageButton ID="BtnCancel" runat="server" CausesValidation="False" 
                            onclick="BtnCancel_Click" SkinID="IBtnCancelar" />
                    </td>
                    <td>
                        <asp:ImageButton ID="BtnEliminar" runat="server" Height="32px" 
                            ImageUrl="~/images/Operaciones/delete2.png" Visible="False" Width="32px" />
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style15">
                        Nuevo</td>
                    <td class="style14">
                        Guardar</td>
                    <td class="style13">
                        Limpiar</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
           
<asp:ObjectDataSource id="ObjMUN" runat="server" TypeName="Municipios" SelectMethod="GetRecords"></asp:ObjectDataSource> <asp:ObjectDataSource id="ObjTTer" runat="server" TypeName="TTerc" SelectMethod="GetRecords"></asp:ObjectDataSource> 
                <asp:ObjectDataSource ID="ObjTD" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                    TypeName="TipIde"></asp:ObjectDataSource>
                <asp:ObjectDataSource id="ObjTusua" runat="server" TypeName="TipUsu" SelectMethod="GetRecords"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjTipProp" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="TipProponente"></asp:ObjectDataSource>
            <asp:HiddenField id="HOldNit" runat="server"></asp:HiddenField> <asp:HiddenField id="HoldTDoc" runat="server"></asp:HiddenField> <asp:HiddenField id="HoldDVer" runat="server"></asp:HiddenField>
            <asp:ObjectDataSource ID="ObjAseguradora" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Aseguradoras" UpdateMethod="Update">
                <UpdateParameters>
                    <asp:Parameter Name="Cod_Ase_O" Type="String" />
                    <asp:Parameter Name="Cod_Ase" Type="String" />
                    <asp:Parameter Name="Nom_Ase" Type="String" />
                    <asp:Parameter Name="estado" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <br />
</ContentTemplate>

        </asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="Loading">
            <asp:Image SkinID="ImgProgress" runat="server" ID="ImgAjax"/> Cargando …
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
    </div>

