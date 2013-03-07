<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CrTerceros.ascx.vb" Inherits="CtrlUsr_CrTerceros_CrTerceros" %>


<%-- <script type="text/javascript">
         
            
          function ColocarNit(){
            
                document.aspnetForm.<%=Me.TxtDVER.ClientID%>.value="";
                document.aspnetForm.<%=Me.TxtUsu.ClientID%>.value=document.aspnetForm.<%=Me.TxtNit.ClientID%>.value;
                if(document.aspnetForm.<%=Me.CbTdoc.ClientID%>.value=="NI")
                {
                    var dv=calcularDV(document.aspnetForm.<%=Me.TxtNit.ClientID%>.value);
                    document.aspnetForm.<%=Me.TxtDVER.ClientID%>.value=dv;
                    document.aspnetForm.<%=Me.TxtUsu.ClientID%>.value=document.aspnetForm.<%=Me.TxtUsu.ClientID%>.value;//+"-"+dv;
                }
            }

            function ArmarNombre(){
            
            var ape1=document.aspnetForm.<%=Me.TxtApe1.ClientID%>.value;
            var ape2=document.aspnetForm.<%=Me.TxtApe2.ClientID%>.value;
            var nom1=document.aspnetForm.<%=Me.TxtNom1.ClientID%>.value;
            var nom2=document.aspnetForm.<%=Me.TxtNom2.ClientID%>.value;
            document.aspnetForm.<%=Me.TxtNom.ClientID%>.value=ape1+" "+ape2+" "+nom1+" "+nom2;           
            
            }

            function SwNombre(){
            
            if(document.aspnetForm.<%=Me.CbTdoc.ClientID%>.value=="NI")
                {
                /*document.aspnetForm.<%=Me.TxtApe1.ClientID%>.disabled=true;
                document.aspnetForm.<%=Me.TxtApe2.ClientID%>.disabled=true;
                document.aspnetForm.<%=Me.TxtNom1.ClientID%>.disabled=true;
                document.aspnetForm.<%=Me.TxtNom2.ClientID%>.disabled=true;
                

                document.aspnetForm.<%=Me.TxtApe1.ClientID%>.value="";
                document.aspnetForm.<%=Me.TxtApe2.ClientID%>.value="";
                document.aspnetForm.<%=Me.TxtNom1.ClientID%>.value="";
                document.aspnetForm.<%=Me.TxtNom2.ClientID%>.value="";

                document.aspnetForm.<%=Me.TxtNom.ClientID%>.disabled=false;*/
                }
                else
                {
               /* document.aspnetForm.<%=Me.TxtApe1.ClientID%>.disabled=false;
                document.aspnetForm.<%=Me.TxtApe2.ClientID%>.disabled=false;
                document.aspnetForm.<%=Me.TxtNom1.ClientID%>.disabled=false;
                document.aspnetForm.<%=Me.TxtNom2.ClientID%>.disabled=false;

                document.aspnetForm.<%=Me.TxtNom.ClientID%>.disabled=true;*/
                }

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
            <asp:ValidationSummary id="ValidationSummary1" runat="server" Width="543px"  SkinID="ValidationSummary1"
                ValidationGroup="Guardar"></asp:ValidationSummary> 

<TABLE style="WIDTH: 641px"><TBODY>
    <TR><TD colSpan=12>
        <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
        </TD></TR>
    <TR><TD style="WIDTH: 108px">Tipo Documento</TD>
        <TD style="WIDTH: 60px" colspan="4">
            <asp:DropDownList ID="CbTdoc" runat="server" 
        DataSourceID="ObjTD" DataTextField="TDOC_NOM" DataValueField="TDOC_COD" 
        Width="210px" ></asp:DropDownList></TD>
        <TD style="WIDTH: 46px" colspan="4">Número&nbsp; Identificación<asp:RequiredFieldValidator 
        ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNit" 
        ErrorMessage="Nit, Campo Requerido" SetFocusOnError="True" 
        ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </TD>
        <td colspan="2" valign="middle"><asp:TextBox ID="TxtNit" runat="server" 
                Width="152px" AutoPostBack="True"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="TxtNit_FilteredTextBoxExtender" 
                                                runat="server" 
                                                Enabled="True" 
                                                TargetControlID="TxtNit" 
                                                FilterType="Numbers"
                                                ValidChars="">
                                            </ajaxToolkit:FilteredTextBoxExtender>
        </td>
        <TD style="WIDTH: 100px">
            <asp:TextBox ID="TxtDver" runat="server" 
        Enabled="False" Rows="1" Width="20px" ReadOnly="True"></asp:TextBox></TD></TR>
    <tr>
        <td style="WIDTH: 108px">
            Lugar de Expedición</td>
        <td style="WIDTH: 60px" colspan=11>
            <asp:TextBox ID="TxtLugExp" runat="server" Width="513px"></asp:TextBox>
        </td>
    </tr>
    <TR><TD style="WIDTH: 108px">Primer 
        Apellido</TD>
        <TD style="WIDTH: 60px" colspan="4">
             <asp:TextBox ID="TxtApe1" runat="server" Width="210px"></asp:TextBox>
             </TD>
        <td style="WIDTH: 46px" colspan="4">
            Segundo Apellido</td>
        <td colspan="3">
            <asp:TextBox ID="TxtApe2" runat="server" Width="190px"></asp:TextBox>
        </td>
    </TR>
    <tr>
        <td style="WIDTH: 108px">
            Primer Nombre</td>
        <td style="WIDTH: 60px" colspan="4">
            <asp:TextBox ID="TxtNom1" runat="server" Width="210px"></asp:TextBox>
        </td>
        <td style="WIDTH: 46px" colspan="4">
            Segundo Nombre</td>
        <td colspan="3">
            <asp:TextBox ID="TxtNom2" runat="server" Width="190px"></asp:TextBox>
        </td>
    </tr>
    <TR><TD style="WIDTH: 108px">Razón 
        Social</TD>
        <TD colspan="11">
            <asp:TextBox ID="TxtNom" runat="server" Width="516px" 
        ValidationGroup="EditNew"></asp:TextBox>
        </TD>
        </TR>
    <tr>
        <td style="WIDTH: 108px">
            Municipios</td>
        <td style="WIDTH: 60px" colspan="4">
            <asp:DropDownList ID="CbMun" runat="server" DataSourceID="ObjMUN" 
                DataTextField="NOM_MUN" DataValueField="COD_MUN" Width="214px">
            </asp:DropDownList>
        </td>
        <td style="WIDTH: 46px" colspan="4">
            Dirección</td>
        <td colspan="3">
            <asp:TextBox ID="TxtDir" runat="server" Width="190px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="WIDTH: 108px">
            E-Mail</td>
        <td style="WIDTH: 60px" colspan="4">
            <asp:TextBox ID="TxtEma" runat="server" ValidationGroup="Guardar" Width="145px"></asp:TextBox>
        </td>
        <td style="WIDTH: 46px" colspan="4">
            Teléfono</td>
        <td colspan="3">
            <asp:TextBox ID="TxtTel" runat="server" Width="189px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="WIDTH: 108px">
            Estado</td>
        <td style="WIDTH: 60px" colspan="4">
            <asp:DropDownList ID="CbEst" runat="server" Width="210px">
                <asp:ListItem Value="AC">Activo</asp:ListItem>
                <asp:ListItem Value="IN">Inactivo</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="WIDTH: 46px" colspan="4">
            Usuario</td>
        <td colspan="3">
            <asp:TextBox ID="TxtUsu" runat="server" Width="191px" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <TR><TD style="WIDTH: 108px">Tipo Terceros</TD>
        <TD colspan="4" style="WIDTH: 60px">
            <asp:DropDownList ID="CbTTcer" runat="server" DataSourceID="ObjTTer" 
                DataTextField="TAG_NOM" DataValueField="TAG_COD">
            </asp:DropDownList>
        </TD>
        <td colspan="4" style="WIDTH: 46px">
            Clase</td>
        <td colspan="3">
            <asp:DropDownList ID="Cmb_CLa" runat="server" Width="123px">
                <asp:ListItem Value="NI">NINGUNO</asp:ListItem>
                <asp:ListItem Value="CS">CONSORCIO</asp:ListItem>
                <asp:ListItem Value="UT">UNION TEMPORAL</asp:ListItem>
            </asp:DropDownList>
        </td>
        </TR>
    <TR><TD style="width: 108px;">
        Observación</TD>
        <td colspan="11">
            <asp:TextBox ID="TxtObs" runat="server" Height="65px" MaxLength="200" 
                TextMode="MultiLine" Width="513px"></asp:TextBox>
        </td>
    </TR>
    <tr>
        <td colspan="2" style="text-align: center;">
            &nbsp;</td>
        <td style="text-align: center; width: 117px;">
            &nbsp;</td>
        <td colspan="4" style="text-align: center; width: 117px;">
            <asp:ImageButton ID="BtnAgregar" runat="server" CausesValidation="False" 
                CommandName="Nuevo" onclick="BtnAgregar_Click" SkinID="IBtnNuevo" />
        </td>
        <td style="text-align: center; width: 117px;">
            <asp:ImageButton ID="BtnSave" runat="server" onclick="Btnsave_Click" 
                SkinID="IBtnGuardar" ValidationGroup="Guardar" />
        </td>
        <td colspan="2" style="text-align: center; width: 268435408px;">
            <asp:ImageButton ID="BtnCancel" runat="server" CausesValidation="False" 
                onclick="BtnCancel_Click" SkinID="IBtnCancelar" />
        </td>
        <td colspan="1" style="WIDTH: 192px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td colspan="1" style="TEXT-ALIGN: center">
            </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center;">
            &nbsp;</td>
        <td colspan="2" style="WIDTH: 117px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td colspan="2" style="TEXT-ALIGN: center; width: 117px;">
            Nuevo</td>
        <td colspan="2" style="text-align: center; width: 117px;">
            Guardar</td>
        <td colspan="2" style="text-align: center; width: 268435408px;">
            Limpiar</td>
        <td colspan="1" style="WIDTH: 192px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td colspan="1" style="TEXT-ALIGN: center">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="10" style="text-align: right;">
            &nbsp;</td>
        <td colspan="1" style="WIDTH: 192px; TEXT-ALIGN: left">
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
            &nbsp;<asp:HiddenField id="HOldNit" runat="server"></asp:HiddenField> <asp:HiddenField id="HoldTDoc" runat="server"></asp:HiddenField> <asp:HiddenField id="HoldDVer" runat="server"></asp:HiddenField>&nbsp;<BR />
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

