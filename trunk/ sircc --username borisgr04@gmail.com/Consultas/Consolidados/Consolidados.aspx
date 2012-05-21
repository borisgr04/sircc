<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Consolidados.aspx.vb" Inherits="Consultas_Consolidados_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
 <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(IniciaRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(EndRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(FinRequest);
             
            var _Instance = Sys.WebForms.PageRequestManager.getInstance();
            
    
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
            function BeginRequest(sender, art) {
                // COMIENZO DEL REQUEST
                //document.getElementById("Progreso").style.visibility = 'visible';
            }

            function EndRequest(sender, art)
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


       </script>

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

    <table style="width: 100%">
        <tr>
            <td style="width: 168px">
                <asp:Label ID="Label3" runat="server" Text="Fecha Inicio"></asp:Label>
            </td>
            <td style="width: 161px">
                <asp:Label ID="Label4" runat="server" Text="Fecha Final"></asp:Label>
            </td>
            <td style="width: 153px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 168px">
                <asp:TextBox ID="TxtFecIni" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TxtFecIni_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtFecIni">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="width: 161px">
                <asp:TextBox ID="TxtFecFin" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TxtFecFin_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtFecFin">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="width: 153px">
                &nbsp;</td>
            <td>
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar"   />
            </td>
        </tr>
        <tr>
            <td style="width: 168px">
                &nbsp;</td>
            <td style="width: 161px">
                &nbsp;</td>
            <td style="width: 153px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:RadioButtonList ID="optVista" runat="server" AutoPostBack="True" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">Global</asp:ListItem>
                    <asp:ListItem Value="1">Por Dependencia</asp:ListItem>
                </asp:RadioButtonList>
    
            </td>
        </tr>
        </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            Por Tipo<asp:GridView ID="grdTipos" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjTipos" EnableModelValidation="True" ShowFooter="True" 
                Width="100%" DataKeyNames="Tipo">
                <Columns>
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                    <asp:TemplateField HeaderText="Cantidad" SortExpression="cantidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbCantidad2" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Total" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("valor_total") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor2" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label114" runat="server" 
                                Text='<%# Bind("valor_total", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Inicial" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("valor_inicial") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor3" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label113" runat="server" 
                                Text='<%# Bind("valor_inicial", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Propios" 
                        SortExpression="Aportes_Propios">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" 
                                Text='<%# Bind("Aportes_Propios") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor4" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label111" runat="server" 
                                Text='<%# Bind("Aportes_Propios", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Otros" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Aportes_Otros") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor5" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label112" runat="server" 
                                Text='<%# Bind("Aportes_Otros", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Adicionado" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox12" runat="server" 
                                Text='<%# Bind("Valor_Adicionado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor6" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" 
                                Text='<%# Bind("Valor_Adicionado", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            Por Dependencia<br />
            <asp:GridView ID="grdDepDel" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjPorDeL" EnableModelValidation="True" ShowFooter="True" 
                Width="100%" DataKeyNames="dependenciap">
                <Columns>
                    
                    <asp:BoundField DataField="Dependenciap" HeaderText="Dependencia" SortExpression="Dependenciap" />
                    <asp:TemplateField HeaderText="Cantidad" SortExpression="cantidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbCantidad3" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label115" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Total" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("valor_total") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor7" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label116" runat="server" 
                                Text='<%# Bind("valor_total", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Inicial" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("valor_inicial") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor8" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label117" runat="server" 
                                Text='<%# Bind("valor_inicial", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Propios" 
                        SortExpression="Aportes_Propios">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox16" runat="server" 
                                Text='<%# Bind("Aportes_Propios") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor9" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label118" runat="server" 
                                Text='<%# Bind("Aportes_Propios", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Otros" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("Aportes_Otros") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor10" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label119" runat="server" 
                                Text='<%# Bind("Aportes_Otros", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Adicionado" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox18" runat="server" 
                                Text='<%# Bind("Valor_Adicionado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor11" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label120" runat="server" 
                                Text='<%# Bind("Valor_Adicionado", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            Modalidad de Contratación<asp:GridView ID="grdModalidadG" runat="server" 
                AutoGenerateColumns="False" DataKeyNames="nom_tproc" DataSourceID="ObjPorTprocG" 
                EnableModelValidation="True" ShowFooter="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="nom_tproc" HeaderText="Modalidad" 
                        SortExpression="nom_tproc" />
                    <asp:TemplateField HeaderText="Cantidad" SortExpression="cantidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox37" runat="server" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbCantidad7" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label139" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Total" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox38" runat="server" Text='<%# Bind("valor_total") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor27" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label140" runat="server" 
                                Text='<%# Bind("valor_total", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Inicial" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox39" runat="server" Text='<%# Bind("valor_inicial") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor28" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label141" runat="server" 
                                Text='<%# Bind("valor_inicial", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Propios" 
                        SortExpression="Aportes_Propios">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox40" runat="server" 
                                Text='<%# Bind("Aportes_Propios") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor29" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label142" runat="server" 
                                Text='<%# Bind("Aportes_Propios", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Otros" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox41" runat="server" Text='<%# Bind("Aportes_Otros") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor30" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label143" runat="server" 
                                Text='<%# Bind("Aportes_Otros", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Adicionado" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox42" runat="server" 
                                Text='<%# Bind("Valor_Adicionado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor31" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label144" runat="server" 
                                Text='<%# Bind("Valor_Adicionado", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:DropDownList ID="CboDepP" runat="server" CssClass="txt" 
                DataSourceID="ObjDepDel" DataTextField="NOM_DEP" DataValueField="COD_DEP" 
                AutoPostBack="True">
                <asp:ListItem>-------------o-----------------</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Tipo<asp:GridView ID="grdTiposD" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="Tipo" DataSourceID="ObjTiposD" EnableModelValidation="True" 
                ShowFooter="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                    <asp:TemplateField HeaderText="Cantidad" SortExpression="cantidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbCantidad6" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label133" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Total" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox32" runat="server" Text='<%# Bind("valor_total") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor22" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label134" runat="server" 
                                Text='<%# Bind("valor_total", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Inicial" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox33" runat="server" Text='<%# Bind("valor_inicial") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor23" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label135" runat="server" 
                                Text='<%# Bind("valor_inicial", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Propios" 
                        SortExpression="Aportes_Propios">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox34" runat="server" 
                                Text='<%# Bind("Aportes_Propios") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor24" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label136" runat="server" 
                                Text='<%# Bind("Aportes_Propios", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Otros" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox35" runat="server" Text='<%# Bind("Aportes_Otros") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor25" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label137" runat="server" 
                                Text='<%# Bind("Aportes_Otros", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Adicionado" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox36" runat="server" 
                                Text='<%# Bind("Valor_Adicionado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor26" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label138" runat="server" 
                                Text='<%# Bind("Valor_Adicionado", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            Dependencia<asp:GridView ID="grdDepNec" runat="server" 
                AutoGenerateColumns="False" 
                EnableModelValidation="True" ShowFooter="True" Width="100%" 
                DataKeyNames="dependencia" DataSourceID="ObjPorDep">
                <Columns>
                    <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" 
                        SortExpression="Dependencia" />
                    <asp:TemplateField HeaderText="Cantidad" SortExpression="cantidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbCantidad4" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label121" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Total" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("valor_total") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor12" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label122" runat="server" 
                                Text='<%# Bind("valor_total", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Inicial" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("valor_inicial") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor13" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label123" runat="server" 
                                Text='<%# Bind("valor_inicial", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Propios" 
                        SortExpression="Aportes_Propios">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox22" runat="server" 
                                Text='<%# Bind("Aportes_Propios") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor14" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label124" runat="server" 
                                Text='<%# Bind("Aportes_Propios", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Otros" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox23" runat="server" Text='<%# Bind("Aportes_Otros") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor15" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label125" runat="server" 
                                Text='<%# Bind("Aportes_Otros", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Adicionado" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox24" runat="server" 
                                Text='<%# Bind("Valor_Adicionado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor16" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label126" runat="server" 
                                Text='<%# Bind("Valor_Adicionado", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            Modalidad de Contratación<asp:GridView ID="grdModalidad" runat="server" 
                AutoGenerateColumns="False" DataKeyNames="nom_tproc" DataSourceID="ObjPorTproc" 
                EnableModelValidation="True" ShowFooter="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="nom_tproc" HeaderText="Modalidad" SortExpression="nom_tproc" />
                    <asp:TemplateField HeaderText="Cantidad" SortExpression="cantidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox25" runat="server" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbCantidad5" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label127" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Total" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox26" runat="server" Text='<%# Bind("valor_total") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor17" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label128" runat="server" 
                                Text='<%# Bind("valor_total", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Inicial" SortExpression="valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox27" runat="server" Text='<%# Bind("valor_inicial") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor18" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label129" runat="server" 
                                Text='<%# Bind("valor_inicial", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Propios" 
                        SortExpression="Aportes_Propios">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox28" runat="server" 
                                Text='<%# Bind("Aportes_Propios") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor19" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label130" runat="server" 
                                Text='<%# Bind("Aportes_Propios", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aportes Otros" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox29" runat="server" Text='<%# Bind("Aportes_Otros") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor20" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label131" runat="server" 
                                Text='<%# Bind("Aportes_Otros", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Adicionado" SortExpression="Aportes_Otros">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox30" runat="server" 
                                Text='<%# Bind("Valor_Adicionado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbValor21" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label132" runat="server" 
                                Text='<%# Bind("Valor_Adicionado", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <br />
        </asp:View>
    </asp:MultiView>
    <asp:ObjectDataSource ID="ObjPorTproc" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorTproc" 
        TypeName="Consultas">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFecIni" DefaultValue="" Name="fec_ini" 
                PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="TxtFecFin" DefaultValue="" Name="fec_fin" 
                PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="CboDepP" DefaultValue="" Name="dep_pcon" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjPorTprocG" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorTprocG" 
        TypeName="Consultas">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFecIni" DefaultValue="" Name="fec_ini" 
                PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="TxtFecFin" DefaultValue="" Name="fec_fin" 
                PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjPorDep" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorDep" 
        TypeName="Consultas">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFecIni" DefaultValue="" Name="fec_ini" 
                PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="TxtFecFin" DefaultValue="" Name="fec_fin" 
                PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="CboDepP" DefaultValue="" Name="dep_pcon" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjDepDel" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelbyUser" 
            TypeName="Dependencias" >
            </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjPorDeL" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorDel" 
        TypeName="Consultas">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFecIni" DefaultValue="" Name="fec_ini" 
                PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="TxtFecFin" DefaultValue="" Name="fec_fin" 
                PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="grdTipos" Name="Tipo" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjTipos" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorTipo" 
        TypeName="Consultas">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFecIni" DefaultValue="" Name="fec_ini" 
                PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="TxtFecFin" DefaultValue="" Name="fec_fin" 
                PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjTiposD" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorTipo" 
        TypeName="Consultas">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFecIni" DefaultValue="" Name="fec_ini" 
                PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="TxtFecFin" DefaultValue="" Name="fec_fin" 
                PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="CboDepP" Name="dep_pcon" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</div>
</asp:Content>

