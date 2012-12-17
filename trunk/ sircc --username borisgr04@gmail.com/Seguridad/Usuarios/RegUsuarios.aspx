<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="RegUsuarios.aspx.vb" Inherits="Seguridad_RegUsuarios" Title="Untitled Page"  UICulture="auto" Culture="auto"%>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<%@ Register src="../../CtrlUsr/AyudaIzq/ctrAyudIzql.ascx" tagname="ctrAyudIzql" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">

    <script type='text/javascript'>
    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        //label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
    }
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            //$addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);        
        }
        
        function showModalPopupViaClient(ev) {
            ev.preventDefault();
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.show();
        }
        
        function hideModalPopupViaClient(ev) {
            ev.preventDefault();        
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
        }
        
        function CerrarModalTercero(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }
        
        function ValidarUser()
        {
        __doPostBack("<%= BtnBuscarUser.ClientID %>","");
        }
          function enviar(tdoc,ced,dv,rsocial,tip_ter)
            {
                document.aspnetForm.<%=Me.TxtUsername.ClientID%>.value=tdoc;
                document.aspnetForm.<%=Me.TxtRazSoc.ClientID%>.value=ced;
                var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
                modalPopupBehavior2.hide();
            }
            //__doPostBack("= button.ClientID %>","");
            //__doPostBack("= CbCdec.ClientID %>","");
            
            
        
        
    </script>
    

    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    <uc2:ctrAyudIzql ID="ctrAyudIzql2" runat="server" Mensaje="&lt;br&gt;&lt;b&gt;      Importante!&lt;/b&gt;&lt;br/&gt;&lt;br&gt; &lt;b&gt; &lt;/b&gt; por Seguridad exige una contraseña segura.&lt;br/&gt; -&lt;b&gt; Caracteres Mínimos&lt;/b&gt; (6) seis - Letras o Números &lt;br/&gt;-&lt;b&gt; Caracteres Especiales Requeridos&lt;/b&gt; 1 (uno) Ejemplo @ ! . ' * + &lt;br/&gt;- &lt;b&gt;Cambie su Contraseña &lt;/b&gt; de manera periodica."  />
    <div class="demoarea">
        
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<TABLE style="WIDTH: 603px" cellPadding=2><TBODY><TR><TD colSpan=6>
    <asp:Label id="msgResult" runat="server" __designer:wfdid="w63" 
        SkinID="MsgResult" Visible="False"></asp:Label></TD></TR><TR>
    <TD colSpan=6><BR /><asp:ValidationSummary id="ValidationSummary1" runat="server" __designer:wfdid="w64"></asp:ValidationSummary></TD></TR><TR>
    <TD class="demoheading" colSpan=6>REGISTRO DE USUARIOS</TD></TR><TR>
    <TD colSpan=6>Digite el Numero de identifación del Usuario o Busquelo Haciendo clik en el Boton Buscar</TD></TR><TR><TD style="WIDTH: 84px"><asp:Label id="Label1" runat="server" __designer:wfdid="w65" Text="Usuario"></asp:Label></TD>
    <TD colSpan=5>
    <asp:TextBox id="TxtUsername" runat="server" Width="150px" 
        AutoPostBack="True"></asp:TextBox>&nbsp; 
    <asp:ImageButton id="ImageButton1" onclick="ImageButton1_Click" runat="server" 
        ToolTip="Boton Buscar" ValidationGroup="BusTer" 
        SkinID="IBtnBuscar" Height="22px" Width="25px"></asp:ImageButton> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUsername" ErrorMessage="Seleccione un Tercero">*</asp:RequiredFieldValidator> 
        <asp:CustomValidator id="CustomValidator1" runat="server" ControlToValidate="TxtUsername" ErrorMessage="El Usuario ya Existe" OnServerValidate="Validar_Usuario">*</asp:CustomValidator> <asp:TextBox id="TxtRazSoc" runat="server" Width="223px" __designer:wfdid="w70" Enabled="False"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 84px"><asp:Label id="Label2" runat="server" Text="Contraseña"></asp:Label></TD>
        <TD colspan=5><asp:TextBox id="TxtClave" runat="server" Width="150" TextMode="Password" autocomplete="off"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" __designer:wfdid="w73" ControlToValidate="TxtClave" ErrorMessage="Digite Contraseña">*</asp:RequiredFieldValidator> <BR /><asp:Label id="TxtClave_HelpLabel" runat="server" __designer:wfdid="w74"></asp:Label></TD></TR><TR><TD style="WIDTH: 84px"><asp:Label id="Label3" runat="server" Width="119px" __designer:wfdid="w75" Text="Confirmar Contraseña"></asp:Label></TD>
    <TD colspan=5><asp:TextBox id="TxtClave2" runat="server" Width="150"  TextMode="Password" autocomplete="off"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" __designer:wfdid="w77" ControlToValidate="TxtClave2" ErrorMessage="Confirme su Contraseña">*</asp:RequiredFieldValidator> <asp:CompareValidator id="CompareValidator1" runat="server" Width="13px" __designer:wfdid="w78" ControlToValidate="TxtClave2" ErrorMessage="Contraseñas deben Coincidir" ControlToCompare="TxtClave">*</asp:CompareValidator> <asp:Label id="TxtClave2_HelpLabel" runat="server" ></asp:Label></TD></TR><TR><TD style="WIDTH: 84px"></TD>
    <TD style="WIDTH: 134px; text-align: center;">
        <asp:ImageButton ID="BtnGuardar" runat="server" SkinID="IBtnGuardar" />
    </TD><TD style="WIDTH: 237px; text-align: center;">
        <asp:ImageButton ID="IBtnAuto" runat="server" SkinID="IBtnPanelUser" 
            ValidationGroup="no" />
    </TD>
    <td colspan="2" style="WIDTH: 237px">
        &nbsp;</td>
    <td style="WIDTH: 237px">
        &nbsp;</td>
    </TR>
    <tr>
        <td style="WIDTH: 84px">
            &nbsp;</td>
        <td style="WIDTH: 134px; text-align: center;">
            Guardar</td>
        <td style="WIDTH: 237px; text-align: center;">
            Autorizaciones</td>
        <td style="WIDTH: 237px">
            &nbsp;</td>
        <td colspan="2" style="WIDTH: 237px">
            &nbsp;</td>
    </tr>
    <tr><td colspan=6>&nbsp;
    <asp:Button style="DISPLAY: none" id="BtnBuscarUser" onclick="BtnBuscarUser_Click" runat="server" CausesValidation="False"></asp:Button></TD></TR></TBODY></TABLE>
   
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
        

<asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional"><contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server" __designer:wfdid="w104"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" __designer:wfdid="w105" TargetControlID="hiddenTargetControlForModalPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup2" runat="server" Width="625px" Height="229%" __designer:wfdid="w106" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Height="30px" __designer:wfdid="w107" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Buscar Tercero</DIV><DIV style="FLOAT: right" __designer:dtid="21955056773365768"><INPUT id="BtnCerrar" type=button value="X" __designer:dtid="21955056773365769" /></DIV></DIV></asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:consultater id="ConsultaTer1" runat="server" __designer:wfdid="w108" ret="DD" tipo=""></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel><br />
        &nbsp;&nbsp;<br />
        <br />
        
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="Loading">
                    <img alt="" src="../../images/loading.gif" title="" />
                    Cargando …
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>
