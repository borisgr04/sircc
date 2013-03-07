<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ModCrProponentes.ascx.vb" Inherits="CtrlUsr_CrProponentes_ModCrProponentes" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>


<style type="text/css">
    .style1
    {
        width: 529px;
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
            <asp:ValidationSummary id="ValidationSummary1" runat="server" Width="543px" SkinID="ValidationSummary1" 
                ValidationGroup="Guardar" DisplayMode="List"></asp:ValidationSummary> 

<TABLE style="WIDTH: 641px"><TBODY>
    <TR><TD class="style1">
        <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
        </TD>
        <TD style="WIDTH: 60px" colspan="7">
            &nbsp;</TD>
        <TD style="WIDTH: 46px" colspan="9">&nbsp;</TD>
        <td colspan="3" valign="middle">&nbsp;</td>
        <TD style="WIDTH: 100px">
            &nbsp;</TD></TR>
    <tr>
        <td class="style1">
            Tipo de Proponente</td>
        <td colspan="7" style="WIDTH: 60px">
            <asp:DropDownList ID="CboTipProp" runat="server" AutoPostBack="True" 
                Width="138px" AppendDataBoundItems="True" DataSourceID="ObjTipProp" 
                DataTextField="Nom_TipProp" DataValueField="Cod_TipProp">
                <asp:ListItem>SELECCIONE...</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                ControlToValidate="CboTipProp" 
                ErrorMessage="Debe seleccionar el tipo de proponente" 
                InitialValue="SELECCIONE..." ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td colspan="9" style="WIDTH: 46px">
            &nbsp;</td>
        <td colspan="3" valign="middle">
            &nbsp;</td>
        <td style="WIDTH: 100px">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Tipo Documento</td>
        <td style="WIDTH: 60px" colspan=7>
            <asp:DropDownList ID="CbTdoc" runat="server" AppendDataBoundItems="True" 
                DataSourceID="ObjTD" DataTextField="TDOC_NOM" DataValueField="TDOC_COD" 
                Width="210px">
                <asp:ListItem>SELECCIONE...</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="CbTdoc" ErrorMessage="Debe seleccionar el tipo de documento" 
                InitialValue="SELECCIONE..." ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td colspan="9" style="WIDTH: 46px">
            Número&nbsp; Identificación<asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                runat="server" ControlToValidate="TxtNit" ErrorMessage="Nit, Campo Requerido" 
                SetFocusOnError="True" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td colspan="3" valign="middle">
            <asp:TextBox ID="TxtNit" runat="server" AutoPostBack="True" Width="152px"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="TxtNit_FilteredTextBoxExtender" 
                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TxtNit" 
                ValidChars="">
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
        <TD style="WIDTH: 60px" colspan="20">
             <asp:TextBox ID="TxtLugExp" runat="server" Width="523px"></asp:TextBox>
             </TD>
    </TR>
    <tr>
        <td class="style1">
            Primer Apellido</td>
        <td style="WIDTH: 60px" colspan="7">
            <asp:TextBox ID="TxtApe1" runat="server" Width="210px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ControlToValidate="TxtApe1" Display="None" 
                ErrorMessage="Debe digitar el Primer Apellido" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td style="WIDTH: 46px" colspan="9">
            Segundo Apellido</td>
        <td colspan="4">
            <asp:TextBox ID="TxtApe2" runat="server" Width="189px"></asp:TextBox>
        </td>
    </tr>
    <TR><TD class="style1">Primer Nombre</TD>
        <TD colspan="7" style="WIDTH: 60px">
            <asp:TextBox ID="TxtNom1" runat="server" Width="210px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TxtNom1" Display="None" 
                ErrorMessage="Debe digita el Primer Nombre" ValidationGroup="GuardarP">*</asp:RequiredFieldValidator>
        </TD>
        <td colspan="9" style="WIDTH: 46px">
            Segundo Nombre</td>
        <td colspan="4">
            <asp:TextBox ID="TxtNom2" runat="server" Width="189px"></asp:TextBox>
        </td>
        </TR>
    <tr>
        <td class="style1">
            Razón Social</td>
        <td colspan="20">
            <asp:TextBox ID="TxtNom" runat="server" ValidationGroup="EditNew" Width="523px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Dirección</td>
        <td style="WIDTH: 60px" colspan="7">
            <asp:TextBox ID="TxtDir" runat="server" Width="189px"></asp:TextBox>
        </td>
        <td style="WIDTH: 46px" colspan="9">
            Municipio</td>
        <td colspan="4">
            <asp:TextBox ID="TxtMun" runat="server" Width="189px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            E-Mail</td>
        <td colspan="7" style="WIDTH: 60px">
            <asp:TextBox ID="TxtEma" runat="server" ValidationGroup="Guardar" Width="145px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TxtEma" Display="None" 
                ErrorMessage="Debe escribir un Email de la forma corre@dominio.com" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="Guardar">*</asp:RegularExpressionValidator>
        </td>
        <td colspan="9" style="WIDTH: 46px">
            Teléfono</td>
        <td colspan="4">
            <asp:TextBox ID="TxtTel" runat="server" Width="189px"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="TxtTel" ValidChars="," FilterType="Numbers, Custom">
            </ajaxToolkit:FilteredTextBoxExtender>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label18" runat="server" Text="Estado"></asp:Label>
        </td>
        <td colspan="7" style="WIDTH: 60px">
            <asp:DropDownList ID="CbEst" runat="server" Width="191px">
                <asp:ListItem Value="AC">Activo</asp:ListItem>
                <asp:ListItem Value="IN">Inactivo</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td colspan="9" style="WIDTH: 46px">
            <asp:Label ID="Label20" runat="server" Text="Fecha de la Propuesta"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="TxtFecProp" runat="server" ValidationGroup="Guardar"></asp:TextBox>
            <asp:CompareValidator ID="CvFecha" runat="server" 
                ControlToValidate="TxtFecProp" 
                ErrorMessage="La fecha de la propuesta debe ser anterior o igual a la fecha actual" 
                Operator="LessThanEqual" Type="Date" ValidationGroup="Guardar">*</asp:CompareValidator>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                Format="dd/MM/yyyy" TargetControlID="TxtFecProp">
            </ajaxToolkit:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="TxtFecProp" ErrorMessage="Fecha Obligatoria" 
                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <TR><TD class="style1">
        <asp:Label ID="Label27" runat="server" Text="Valor de la Propuesta"></asp:Label>
        </TD>
        <td colspan="7" style="WIDTH: 60px">
            <asp:TextBox ID="TxtValProp" runat="server"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                runat="server" FilterType="Numbers, Custom" TargetControlID="TxtValProp" ValidChars=".">
            </ajaxToolkit:FilteredTextBoxExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="TxtValProp" Display="None" 
                ErrorMessage="Debe digita el Valor de la Propuesta" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td colspan="9" style="WIDTH: 46px">
            <asp:Label ID="Label32" runat="server" Text="No. de Folios"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="TxtNumFolio" runat="server"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
                runat="server" FilterType="Numbers" TargetControlID="TxtNumFolio">
            </ajaxToolkit:FilteredTextBoxExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="TxtNumFolio" ErrorMessage="N° de Folios es Obligatorio" 
                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
    </TR>
    <tr>
        <td class="style1">
            Identificacion Representante Legal</td>
        <td colspan="5">
            <asp:TextBox ID="TxtIdRepLeg" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                ControlToValidate="TxtIdRepLeg" 
                ErrorMessage="Debe registrar la identificación del RepResentante Legal" 
                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
        <td colspan="5">
            Representante Legal</td>
        <td colspan="10">
            <asp:TextBox ID="TxtRepLeg" runat="server" Width="251px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                ControlToValidate="TxtRepLeg" 
                ErrorMessage="Debe diligenciar el nombre del Representante Legal" 
                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Observación</td>
        <td colspan="20">
            <asp:TextBox ID="TxtObs" runat="server" Height="65px" MaxLength="200" 
                TextMode="MultiLine" Width="513px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
        <td colspan="3">
            <asp:ImageButton ID="BtnAgregar" runat="server" CausesValidation="False" 
                CommandName="Nuevo" onclick="BtnAgregar_Click" SkinID="IBtnNuevo" />
        </td>
        <td colspan="2">
            <asp:ImageButton ID="BtnSave" runat="server" onclick="Btnsave_Click" 
                SkinID="IBtnGuardar" ValidationGroup="Guardar" />
        </td>
        <td colspan="3">
            &nbsp;</td>
        <td colspan="4">
            &nbsp;</td>
        <td colspan="2">
            <asp:ImageButton ID="BtnCancel" runat="server" CausesValidation="False" 
                onclick="BtnCancel_Click" SkinID="IBtnCancelar" />
        </td>
        <td colspan="3">
            <asp:ImageButton ID="BtnEliminar" runat="server" Height="32px" 
                ImageUrl="~/images/Operaciones/delete2.png" Visible="False" Width="32px" />
        </td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
        <td colspan="3">
            Nuevo</td>
        <td colspan="2">
            Guardar</td>
        <td colspan="3">
            &nbsp;</td>
        <td colspan="4">
            &nbsp;</td>
        <td colspan="2">
            Limpiar</td>
        <td colspan="3">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3" style="text-align: center;">
            &nbsp;</td>
        <td style="WIDTH: 117px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td colspan="9" style="TEXT-ALIGN: center; width: 117px;">
            &nbsp;</td>
        <td style="text-align: center; width: 117px;" colspan="2">
            &nbsp;</td>
        <td colspan="3" style="text-align: center; width: 268435408px;">
            &nbsp;</td>
        <td colspan="2" style="WIDTH: 192px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td colspan="1" style="TEXT-ALIGN: center; ">
            </td>
    </tr>
    <tr>
        <td colspan="3" style="text-align: center;">
            &nbsp;</td>
        <td colspan="3" style="WIDTH: 117px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="TEXT-ALIGN: center; width: 117px;" colspan="3">
            &nbsp;</td>
        <td colspan="3" style="text-align: center; width: 117px;">
            &nbsp;</td>
        <td colspan="3" style="text-align: center; width: 117px;">
            &nbsp;</td>
        <td colspan="3" style="WIDTH: 268435408px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td colspan="2" style="TEXT-ALIGN: center; width: 192px;">
            &nbsp;</td>
        <td colspan="1" style="TEXT-ALIGN: center">
            &nbsp;</td>
    </tr>
    </TBODY></TABLE>
           
<asp:ObjectDataSource id="ObjMUN" runat="server" TypeName="Municipios" SelectMethod="GetRecords"></asp:ObjectDataSource> <asp:ObjectDataSource id="ObjTTer" runat="server" TypeName="TTerc" SelectMethod="GetRecords"></asp:ObjectDataSource> 
                <asp:ObjectDataSource ID="ObjTD" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                    TypeName="TipIde"></asp:ObjectDataSource>
                <asp:ObjectDataSource id="ObjTusua" runat="server" TypeName="TipUsu" SelectMethod="GetRecords"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjTipProp" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="TipProponente"></asp:ObjectDataSource>
            <asp:HiddenField id="HOldNit" runat="server"></asp:HiddenField> <asp:HiddenField id="HoldTDoc" runat="server"></asp:HiddenField> <asp:HiddenField id="HoldDVer" runat="server"></asp:HiddenField>
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

