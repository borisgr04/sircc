<%@ Page Language="VB" 
MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Terceros.aspx.vb" 
Inherits="DatosBasicos_Terceros_Terceros" title="Untitled Page" EnableEventValidation="False"   %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server"><div class="demoarea">
    <div class="demoarea">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
                
         <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(IniciaRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(EndRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(FinRequest);
             
            var _Instance = Sys.WebForms.PageRequestManager.getInstance();
            
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


            function IniciaRequest(sender,arg)
            {

            // INICIALIZACION DEL REQUEST
                if (_Instance.get_isInAsyncPostBack()) 
                    {
                        //window.alert("Existe un proceso en marcha. Espere<"+sender._postBackSettings.sourceElement.id);
                        window.alert("Existe un proceso en marcha. Espere");
                        arg.set_cancel(true);
                    }
              
             // RATON A PENSAR
                switch(sender._postBackSettings.sourceElement.id)
                {
                //window.alert(sender._postBackSettings.sourceElement.id);
                case 'ctl00_SampleContent_BtnSave':
                    $get('ctl00_SampleContent_UpdatePanel1').style.cursor = 'wait';
                }
                
                // DESHABILITA CONTROL QUE HA INICIADO EL REQUEST
                $get(sender._postBackSettings.sourceElement.id).disabled = true;
            }

            function BeginRequest(sender,art)
            {
            // COMIENZO DEL REQUEST
                //document.getElementById("Progreso").style.visibility = 'visible';
            }  
    
            function EndRequest(sender,art)    
            // FIN DEL REQUEST
            {
                //document.getElementById("Progreso").style.visibility = 'hidden';
            }
            
            function FinRequest(sender,arg)
            // FIN DE REQUEST
            {
             $get('ctl00_SampleContent_UpdatePanel1').style.cursor = 'auto';
            // RATON NORMAL
                if((sender._postBackSettings.sourceElement.id!="ctl00_SampleContent_BtnCancel") && (sender._postBackSettings.sourceElement.id!="ctl00_SampleContent_BtnSave"))
                {
                    switch(sender._postBackSettings.sourceElement.id)
                    {
                    case 'ctl00_SampleContent_BtnSave':
                        $get('ctl00_SampleContent_UpdatePanel1').style.cursor = 'auto';
                    }
                    // HABILITA CONTROL QUE HA INICIO EL REQUEST
                    $get(sender._postBackSettings.sourceElement.id).disabled = false;
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

       </script>

        
        


       
        
       <br />
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> 
            &nbsp;<asp:Label id="Tit" runat="server" CssClass="Titulo" Text="TERCEROS"></asp:Label>&nbsp; <BR />
            <asp:Label id="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>&nbsp; <BR />
            <asp:ValidationSummary id="ValidationSummary1" runat="server" Width="543px" 
                Height="80px" ValidationGroup="Guardar" SkinID="ValidationSummary1"></asp:ValidationSummary> <asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label><BR /><asp:MultiView id="MultiView1" runat="server" ActiveViewIndex="1"><asp:View id="View1" runat="server">


<TABLE style="WIDTH: 641px"><TBODY>
    <TR><TD colSpan=11>&nbsp;</TD></TR>
    <TR><TD style="WIDTH: 108px">Tipo Documento</TD>
        <TD style="WIDTH: 60px" colspan="5">
            <asp:DropDownList ID="CbTdoc" runat="server" 
        DataSourceID="ObjTD" DataTextField="TDOC_NOM" DataValueField="TDOC_COD" 
        Width="210px" ></asp:DropDownList></TD>
        <TD style="WIDTH: 46px" colspan="2">Número&nbsp; Identificación<asp:RequiredFieldValidator 
        ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNit" 
        ErrorMessage="Nit, Campo Requerido" SetFocusOnError="True" 
        ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </TD>
        <td colspan="2" valign="middle"><asp:TextBox ID="TxtNit" runat="server" Width="152px"></asp:TextBox>
        </td>
        <TD style="WIDTH: 38px">
            <asp:TextBox ID="TxtDver" runat="server" 
        Enabled="False" Rows="1" Width="20px" ReadOnly="True"></asp:TextBox></TD></TR>
    <tr>
        <td style="WIDTH: 108px">
            Lugar de Expedición</td>
        <td colspan=10>
            <asp:TextBox ID="TxtLugExp" runat="server" Width="95%"></asp:TextBox>
        </td>
    </tr>
    <TR><TD style="WIDTH: 108px">Primer 
        Apellido</TD>
        <TD style="WIDTH: 60px" colspan="5">
             <asp:TextBox ID="TxtApe1" runat="server" Width="210px"></asp:TextBox>
             </TD>
        <td style="WIDTH: 46px" colspan="2">
            Segundo Apellido</td>
        <td colspan="3">
            <asp:TextBox ID="TxtApe2" runat="server"></asp:TextBox>
        </td>
    </TR>
    <tr>
        <td style="WIDTH: 108px">
            Primer Nombre</td>
        <td style="WIDTH: 60px" colspan="5">
            <asp:TextBox ID="TxtNom1" runat="server" Width="210px"></asp:TextBox>
        </td>
        <td style="WIDTH: 46px" colspan="2">
            Segundo Nombre</td>
        <td colspan="3">
            <asp:TextBox ID="TxtNom2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <TR><TD style="WIDTH: 108px">Razón 
        Social</TD>
        <TD colspan="10">
            <asp:TextBox ID="TxtNom" runat="server" Width="95%" 
        ValidationGroup="EditNew"></asp:TextBox>
        </TD>
        </TR>
    <tr>
        <td style="WIDTH: 108px">
            Dirección</td>
        <td colspan="10">
            <asp:TextBox ID="TxtDir" runat="server" Width="90%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="WIDTH: 108px">
            E-Mail</td>
        <td style="WIDTH: 60px" colspan="5">
            <asp:TextBox ID="TxtEma" runat="server" ValidationGroup="Guardar" Width="201px"></asp:TextBox>
        </td>
        <td style="WIDTH: 46px" colspan="2">
            Teléfono</td>
        <td colspan="3">
            <asp:TextBox ID="TxtTel" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="WIDTH: 108px">
            Estado</td>
        <td style="WIDTH: 60px" colspan="5">
            <asp:DropDownList ID="CbEst" runat="server" Width="210px">
                <asp:ListItem Value="AC">Activo</asp:ListItem>
                <asp:ListItem Value="IN">Inactivo</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="WIDTH: 46px" colspan="2">
            Usuario</td>
        <td colspan="3">
            <asp:TextBox ID="TxtUsu" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <TR><TD style="WIDTH: 108px">Tipo 
        Terceros</TD>
        <TD colspan="2">
            <asp:DropDownList ID="CbTTcer" runat="server" DataSourceID="ObjTTer" 
        DataTextField="TAG_NOM" DataValueField="TAG_COD" Width="129px">
            </asp:DropDownList>
        </TD>
        <td colspan="2">
            &nbsp;</td>
        <td colspan="3">
            Clasificación</td>
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
        <td colspan="10">
            <asp:TextBox ID="TxtObs" runat="server" Height="65px" MaxLength="200" 
                TextMode="MultiLine" Width="90%"></asp:TextBox>
        </td>
    </TR>
    <tr>
        <td colspan="2" style="text-align: center;">
            <div ID="Guardar">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;</div>
        </td>
        <td style="text-align: center;" colspan="2">
            &#160;</td>
        <td style="text-align: center;">
            &#160;</td>
        <td colspan="2" style="text-align: center; width: 117px;">
            <asp:ImageButton ID="BtnSave" runat="server" onclick="Btnsave_Click" 
                SkinID="IBtnGuardar" ValidationGroup="Guardar" />
        </td>
        <td colspan="2" style="text-align: center; width: 268435408px;">
            <asp:ImageButton ID="BtnCancel" runat="server" CausesValidation="False" 
                onclick="BtnCancel_Click" SkinID="IBtnCancelar" />
        </td>
        <td colspan="1" style="WIDTH: 192px; TEXT-ALIGN: center">
            <div ID="Cancelar">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
        </td>
        <td colspan="1" style="TEXT-ALIGN: center; width: 38px;">
            </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center;">
            &nbsp;</td>
        <td colspan="2" style="TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="TEXT-ALIGN: center; ">
            &nbsp;</td>
        <td colspan="2" style="text-align: center; width: 117px;">
            Guardar</td>
        <td colspan="2" style="text-align: center; width: 268435408px;">
            Cancelar</td>
        <td colspan="1" style="WIDTH: 192px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td colspan="1" style="TEXT-ALIGN: center; width: 38px;">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="9" style="text-align: right;">
            &nbsp;</td>
        <td colspan="1" style="WIDTH: 192px; TEXT-ALIGN: left">
            <asp:DropDownList ID="CbMun" runat="server" DataSourceID="ObjMUN" 
                DataTextField="NOM_MUN" DataValueField="COD_MUN" Visible="False" Width="214px">
            </asp:DropDownList>
        </td>
        <td colspan="1" style="TEXT-ALIGN: center; width: 38px;">
            &nbsp;</td>
    </tr>
    </TBODY></TABLE>
                            

<asp:ObjectDataSource id="ObjMUN" runat="server" TypeName="Municipios" SelectMethod="GetRecords"></asp:ObjectDataSource> <asp:ObjectDataSource id="ObjTTer" runat="server" TypeName="TTerc" SelectMethod="GetRecords"></asp:ObjectDataSource> 
                <asp:ObjectDataSource ID="ObjTD" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                    TypeName="TipIde"></asp:ObjectDataSource>
                <asp:ObjectDataSource id="ObjTusua" runat="server" TypeName="TipUsu" SelectMethod="GetRecords"></asp:ObjectDataSource>&nbsp;&nbsp; <ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Maximo 200 Caracteres" runat="server" TargetControlID="TxtObs" WatermarkCssClass="watermarked"></ajaxToolkit:TextBoxWatermarkExtender></asp:View>&nbsp;&nbsp; <asp:View id="View2" runat="server">
                <br />
                </asp:View></asp:MultiView> <BR />&nbsp;&nbsp;<TABLE 
                style="WIDTH: 573px; HEIGHT: 10px">
                <tbody>
                    <tr>
                        <td style="WIDTH: 100px">
                            Nit/Nombre</td>
                        <td colspan="1" style="WIDTH: 290px">
                            <asp:TextBox ID="TxtFilNom" runat="server" Width="277px">
                            </asp:TextBox>
                        </td>
                        <td colspan="1" style="WIDTH: 53px">
                            <asp:ImageButton ID="BtnBuscar" runat="server" accessKey="b" 
                                AlternateText="Buscar" CausesValidation="False" CommandName="Buscar" 
                                ImageUrl="~/images/Operaciones/search2.png" onclick="BtnBuscar_Click" />
                        </td>
                        <td style="WIDTH: 49px">
                            &nbsp;<asp:ImageButton ID="BtnAgregar" runat="server" CausesValidation="False" 
                                CommandName="Nuevo" ImageUrl="~/images/Operaciones/New1.png" 
                                onclick="BtnAgregar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 100px">
                        </td>
                        <td colspan="1" style="WIDTH: 290px">
                        </td>
                        <td colspan="1" style="WIDTH: 53px">
                            Buscar</td>
                        <td style="WIDTH: 49px">
                            Nuevo</td>
                    </tr>
                </tbody>
            </TABLE>
            &nbsp; <DIV id="Div1">
    
                <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="ide_ter" DataSourceID="ObjTerceros" 
                    EnableModelValidation="True" OnRowCommand="GridView1_RowCommand" 
                    OnRowDataBound="GridView1_RowDataBound" 
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                    Width="670px">
                    <Columns>
                        <asp:TemplateField HeaderText="Tipo Identificación" SortExpression="tip_ide">
                            <ItemTemplate>
                                <asp:Label ID="LbNom" runat="server" Text='<%# Bind("tip_ide") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nit" SortExpression="TER_NIT"><FooterTemplate>
                            <asp:ImageButton id="lnkExportar" runat="server" Text="Exportar Datos a Excel" __designer:wfdid="w10" CausesValidation="False" CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png" Height="32" Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton> 
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LbUni1" runat="server" Text='<%# Bind("ide_ter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre" SortExpression="TER_NOM">
                            <ItemTemplate>
                                <asp:Label ID="LbUni2" runat="server" Text='<%# Bind("nom_ter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono" SortExpression="TER_TEL">
                            <ItemTemplate>
                                <asp:Label ID="LbNor" runat="server" Text='<%# Bind("TEL_ter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Observación" SortExpression="TER_OBS">
                            <ItemTemplate>
                                <asp:Label ID="LbObs" runat="server" Text='<%# Bind("dir_ter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="BtnEdit" runat="server" 
                                    CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))%>' 
                                    CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" 
                                    tooltip="Editar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="BtnElim" runat="server" 
                                    CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))%>' 
                                    CommandName="Eliminar" ImageUrl="~/images/Operaciones/Delete2.png" 
                                    tooltip="Eliminar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="BtnSel" runat="server" 
                                    CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))%>' 
                                    CommandName="Seleccionar" ImageUrl="~/images/Operaciones/Select.png" 
                                    tooltip="Seleccionar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <BR />
                        <asp:Label ID="Label1" runat="server" CssClass="NoData" 
                            Text="No se encontraron registros" Width="166px"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
    
                <br />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="ide_ter" EnableModelValidation="True" 
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" 
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                    Width="670px">
                    <Columns>
                        <asp:TemplateField HeaderText="Tipo Identificación" SortExpression="tip_ide">
                            <ItemTemplate>
                                <asp:Label ID="LbNom0" runat="server" Text='<%# Bind("tip_ide") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nit" SortExpression="TER_NIT">
                            <ItemTemplate>
                                <asp:Label ID="LbUni3" runat="server" Text='<%# Bind("ide_ter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre" SortExpression="TER_NOM">
                            <ItemTemplate>
                                <asp:Label ID="LbUni4" runat="server" Text='<%# Bind("nom_ter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono" SortExpression="TER_TEL">
                            <ItemTemplate>
                                <asp:Label ID="LbNor0" runat="server" Text='<%# Bind("TEL_ter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Dir_Ter" HeaderText="Dirección" />
                        <asp:BoundField DataField="Ema_Ter" HeaderText="Correo" />
                        <asp:TemplateField HeaderText="Observación" SortExpression="TER_OBS">
                            <ItemTemplate>
                                <asp:Label ID="LbObs0" runat="server" Text='<%# Bind("dir_ter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       </Columns>
                    <EmptyDataTemplate>
                        <BR />
                        <asp:Label ID="Label2" runat="server" CssClass="NoData" 
                            Text="No se encontraron registros" Width="166px"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
    
            </DIV><BR /><DIV id="GRID">
            <asp:ObjectDataSource id="ObjTerceros" runat="server" TypeName="Terceros" SelectMethod="GetRecords" OldValuesParameterFormatString="original_{0}"><SelectParameters>
<asp:ControlParameter ControlID="TxtFilNom" PropertyName="Text" Name="busc" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> </DIV>&nbsp;&nbsp;&nbsp;
            <asp:HiddenField id="HOldNit" runat="server"></asp:HiddenField> <asp:HiddenField id="HoldTDoc" runat="server"></asp:HiddenField> <asp:HiddenField id="HoldDVer" runat="server"></asp:HiddenField><BR />&nbsp; <BR />
</ContentTemplate>

             <Triggers>
                 <asp:PostBackTrigger ControlID="Gridview1" />
             </Triggers>

        </asp:UpdatePanel>
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="Loading">
            <asp:Image SkinID="ImgProgress" runat="server" ID="ImgAjax"/> Cargando …
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    </div>
</asp:Content>

