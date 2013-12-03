<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Proyectos.aspx.vb" EnableEventValidation="false" Inherits="DatosBasicos_Proyectos_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">

    <script src="<%= ResolveUrl("~/Scripts/jquery-1.9.1.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery-ui-1.10.3.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery-ui.js") %>" type="text/javascript"></script>


    <script type='text/javascript'>
        $(function () {

            var cboTipPro = $('#<%=cboTipPro.ClientID %>');
            var Txt_comite = $('#<%=Txt_comite.ClientID %>');

            cboTipPro.change(function () {
                Txt_comite.val(cboTipPro.val() == "SGR" ? "ACTA N°:" : "COMITE N°: ");
                Txt_comite.focus();
            });

            $('#<%=TxtIdeTer.ClientID %>').blur(function () {
                var TxtIdeCon = $get('<%=TxtIdeTer.ClientID %>');
                var TxtCtotista = $get('<%=TxtNomTer.ClientID %>');
                if (TxtIdeCon.value.length > 0) {
                    BuscarTercero(TxtIdeCon.value, TxtCtotista);
                }
            });

            function BuscarTercero(ide_ter, txtNom) {
                var nombre = "";
                $.ajax({
                    type: "POST",
                    url: "Proyectos.aspx/GetTercerosPk",
                    data: "{ide_ter:'" + ide_ter + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d == "0") {
                            alert("Tercero no Encontrado");
                            txtNom.value = "";
                        } else {
                            txtNom.value = response.d;
                        }

                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
                return nombre;
            }

        });

    </script>


    <script type="text/javascript">

        function AportesTotalesT(sender, EventArgs) {

            var txtTotal = $find('<%=Me.TxtValTot.ClientID%>');
                var txtAportes = $find('<%=Me.TxtValProp.ClientID%>');
                var txtOtros = $find('<%=Me.TxtValOtros.ClientID%>');

                var valTotal = txtTotal.get_value();

                if (valTotal == 0) {
                    txtTotal.set_value(0);
                    valTotal = 0;
                }
                txtAportes.set_value(valTotal);
                txtOtros.set_value(0);
            }

            function AportesProp(sender, EventArgs) {
                var txtTotal = $find('<%=Me.TxtValTot.ClientID%>');
                var txtAportes = $find('<%=Me.TxtValProp.ClientID%>');
                var txtOtros = $find('<%=Me.TxtValOtros.ClientID%>');
                var valTotal = txtTotal.get_value();
                var valAportes = txtAportes.get_value();
                var valOtros = valTotal - valAportes;
                if (valOtros < 0) {
                    alert("El Valor de los Aportes no puede ser mayor que el Valor total");
                    txtAportes.set_value(valTotal);
                    txtOtros.set_value(0);
                    txtAportes.focus();
                }
                else {
                    txtOtros.set_value(valOtros);
                }
            }




    </script>

    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true">
        </ajaxToolkit:ToolkitScriptManager>
        &nbsp; &nbsp;
    <br />
        <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>--%>
&nbsp;
        <asp:Label ID="Tit" runat="server" Width="286px" CssClass="Titulo"
            Text="Proyectos"></asp:Label><br />
        <asp:Label ID="MsgResult" runat="server"
            SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
        <asp:HyperLink ID="hlReportes" runat="server"
            NavigateUrl="~/Reportes/PorProyectos/PorProyectos.aspx">Contratos por Proyectos</asp:HyperLink>
        <br />
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div>

                    <asp:Label ID="Label11" runat="server" Text="Vigencia"></asp:Label>
                    <asp:DropDownList ID="CmbVig" runat="server" DataSourceID="odsVigencias" DataTextField="YEAR_VIG"
                        DataValueField="YEAR_VIG">
                    </asp:DropDownList>
                    <asp:Label ID="Label12" runat="server" Text="Nombre/Número"></asp:Label>
                    <asp:TextBox ID="TxtBuscar" runat="server" Width="387px"></asp:TextBox>
                    <asp:Button ID="BtnBuscar" runat="server" ValidationGroup="NoValidar"
                        Text="Buscar" />
                </div>
                <br />
                <br />
                <asp:ImageButton ID="IbtnNuevo" runat="server" SkinID="IBtnNuevo"
                    ValidationGroup="NoValidar" />
                <br />
                <asp:GridView ID="GridView1" runat="server"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="Proyecto"
                    EmptyDataText="No se encontraron Registros en la Base de Datos"
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True"
                    Width="782px" AllowPaging="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Vigencia" SortExpression="Vigencia">
                            <FooterTemplate>
                                <asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="False"
                                    CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LbCod" runat="server" Text='<%# Bind("Vigencia") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Proyecto" SortExpression="Proyecto">
                            <FooterTemplate>
                                <%--<asp:ImageButton ID="lnkExportar" runat="server" CausesValidation="False" 
                                CommandName="Exportar" Height="32" ImageUrl="~/images/Operaciones/excel.png" 
                                Text="Exportar Datos a Excel" ToolTip="Exportar Datos a Excel" Width="32" />--%>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Lbcimp" runat="server" Text='<%# Bind("Proyecto") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre de Proyecto" SortExpression="Nombre_Proyecto">
                            <ItemTemplate>
                                <asp:Label ID="LbEst" runat="server" Text='<%# Bind("Nombre_Proyecto") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de Radicacion" SortExpression="Fecha_Rad">
                            <ItemTemplate>
                                <asp:Label ID="LbCodAux" runat="server" Text='<%# Bind("Fecha_Rad","{0:d}") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Documento Aprobación(Comite/Acta)"
                            SortExpression="Comite">
                            <ItemTemplate>
                                <asp:Label ID="LbCodFor" runat="server" Text='<%# Bind("Comite") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor" SortExpression="Valor">
                            <ItemTemplate>
                                <asp:Label ID="LbCodCon" runat="server" Text='<%# Bind("Valor") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                            <ItemTemplate>
                                <asp:Label ID="LbEstado" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Image" CommandName="Eliminar"
                            ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                        <asp:ButtonField ButtonType="Image" CommandName="Editar"
                            ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                        <asp:CommandField ButtonType="Image"
                            SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:LinkButton ID="lnkNuevo" runat="server"
                            CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>

                <asp:ObjectDataSource ID="ObjProyectos" runat="server" TypeName="Proyectos"
                    SelectMethod="GetProyectos"
                    OldValuesParameterFormatString="original_{0}" InsertMethod="Insert"
                    UpdateMethod="Update">

                    <SelectParameters>
                        <asp:ControlParameter ControlID="CmbVig" Name="Vigencia"
                            PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="TxtBuscar" Name="Proyecto" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>

                </asp:ObjectDataSource>

            </asp:View>
            <asp:View ID="View2" runat="server">
                <fieldset>
                    <legend>Datos del Proyecto</legend>
                    <table
                        align="center">
                        <tbody>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
                                </td>
                            </tr>
                            <tr>
                                <td style="WIDTH: 162px">
                                    <asp:Label ID="Label4" runat="server" Text="Vigencia"
                                        Width="143px"></asp:Label></td>
                                <td style="WIDTH: 513px">
                                    <asp:DropDownList ID="CmbVigP" runat="server" DataSourceID="odsVigencias"
                                        DataTextField="YEAR_VIG" DataValueField="YEAR_VIG">
                                    </asp:DropDownList>
                                </td>
                                <td style="WIDTH: 100px">
                                <tr>
                                    <td style="WIDTH: 162px; HEIGHT: 23px">
                                        <asp:Label ID="Label1" runat="server" Width="126px" Text="Proyecto"></asp:Label></td>
                                    <td style="WIDTH: 513px; HEIGHT: 23px">
                                        <asp:TextBox ID="txt_proy" runat="server" Width="229px"></asp:TextBox></td>
                                    <td style="WIDTH: 100px; HEIGHT: 23px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ControlToValidate="txtNomProy" ErrorMessage="Digite Codigo ">*</asp:RequiredFieldValidator></td>
                                </tr>
                            <tr>
                                <td style="WIDTH: 162px; HEIGHT: 18px">
                                    <asp:Label ID="Label5" runat="server" Text="Nombre del Proyecto"></asp:Label>
                                </td>
                                <td style="WIDTH: 513px; HEIGHT: 18px">
                                    <asp:TextBox ID="txtNomProy" runat="server" Width="433px" Height="69px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td style="WIDTH: 100px; HEIGHT: 18px">

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="txtNomProy" ErrorMessage="Digite Codigo ">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="WIDTH: 162px; HEIGHT: 19px">
                                    <asp:Label ID="Label6" runat="server" Text="Fecha de Radicacion"></asp:Label>
                                </td>
                                <td style="WIDTH: 513px; HEIGHT: 19px">
                                    <asp:TextBox ID="Txt_Fec_Rad" runat="server" Width="107px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"
                                        Format="dd/MM/yyyy" TargetControlID="Txt_Fec_Rad">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td style="WIDTH: 100px; HEIGHT: 19px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                        ControlToValidate="txtNomProy" ErrorMessage="Digite Codigo Impuesto">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="WIDTH: 162px; HEIGHT: 19px">Tipo Proyecto</td>
                                <td style="WIDTH: 513px; HEIGHT: 19px">
                                    <asp:DropDownList ID="cboTipPro" runat="server">
                                        <asp:ListItem Value="RP">RP - Recursos Propios</asp:ListItem>
                                        <asp:ListItem Value="SGR">SGR - Sistema General de Regalías</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="WIDTH: 100px; HEIGHT: 19px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="WIDTH: 162px">
                                    <asp:Label ID="LbDoc" runat="server" Text="Documento Soporte(Comite/Acta)"></asp:Label>
                                </td>
                                <td style="WIDTH: 513px">
                                    <asp:TextBox ID="Txt_comite" runat="server" Width="320px"></asp:TextBox>
                                </td>
                                <td style="WIDTH: 100px"></td>
                            </tr>
                            <tr>
                                <td style="WIDTH: 162px">
                                    <asp:Label ID="Label8" runat="server" Text="Valor"></asp:Label>
                                    &nbsp;Total</td>
                                <td style="WIDTH: 513px">
                                    <telerik:RadNumericTextBox ID="TxtValTot" runat="server" Culture="es-CO"
                                        Height="19px" Skin="Default" Value="0" Width="125px">
                                        <ClientEvents OnValueChanged="AportesTotalesT" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td style="WIDTH: 100px"></td>
                            </tr>
                            <tr>
                                <td style="WIDTH: 162px">Aportes Propios</td>
                                <td style="WIDTH: 513px">
                                    <telerik:RadNumericTextBox ID="TxtValProp" runat="server" Culture="es-CO" Height="19px"
                                        Skin="Default" Value="0" Width="125px">
                                        <ClientEvents OnValueChanged="AportesProp" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td style="WIDTH: 100px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="WIDTH: 162px">Aportes Otros</td>
                                <td style="WIDTH: 513px">
                                    <telerik:RadNumericTextBox ID="TxtValOtros" runat="server" Culture="es-CO" Height="19px"
                                        Skin="Default" Value="0" Width="125px" Enabled="false">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td style="WIDTH: 100px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="WIDTH: 162px">Aportante</td>
                                <td colspan="2">
                                    <asp:TextBox ID="TxtIdeTer" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" Text="..." />
                                    <asp:TextBox ID="TxtNomTer" runat="server" ReadOnly="True" Width="335px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="WIDTH: 162px">
                                    <asp:Label ID="Label10" runat="server" Text="Estado"></asp:Label>
                                </td>
                                <td style="WIDTH: 513px">
                                    <asp:DropDownList ID="Cmb_Estado" runat="server" Width="107px">
                                        <asp:ListItem Value="PRIORIZADO">PRIORIZADO</asp:ListItem>
                                        <asp:ListItem Value="EN EJECUCIÓN">EN EJECUCIÓN</asp:ListItem>
                                        <asp:ListItem Value="PRIORIZADO SIN RECURSOS">PRIORIZADO SIN RECURSOS</asp:ListItem>
                                        <asp:ListItem Value="REMITIDO A SECTORIAL">REMITIDO A SECTORIAL</asp:ListItem>
                                        <asp:ListItem Value="CONTRATADO">CONTRATADO</asp:ListItem>
                                        <asp:ListItem Value="EJECUTADO">EJECUTADO</asp:ListItem>
                                        <asp:ListItem Value="PRECONTRACTUAL">PRECONTRACTUAL</asp:ListItem>
                                        <asp:ListItem Value="VIABILIZADO SECTORIAL">VIABILIZADO SECTORIAL</asp:ListItem>
                                        <asp:ListItem Value="REFORMULADO">REFORMULADO</asp:ListItem>
                                        <asp:ListItem Value="LICITACION ADJUDICADA">LICITACION ADJUDICADA</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="WIDTH: 100px"></td>
                            </tr>
                            <tr>
                                <td style="TEXT-ALIGN: center" colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3" style="TEXT-ALIGN: center">
                                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar"></asp:Button>
                                    &#160;<asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click"
                                        Text="Eliminar"></asp:Button>
                                    <input id="BtnCancelar" type="button" value="Cancelar" />
                                    <asp:Button ID="BtnVolver" runat="server" Text="Volver" ValidationGroup="SIN" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="TEXT-ALIGN: center">&#160;</td>
                            </tr>
                        </tbody>
                    </table>

                </fieldset>
            </asp:View>
        </asp:MultiView>


    </div>
    <asp:ObjectDataSource ID="odsVigencias" runat="server" SelectMethod="GetRecords"
        TypeName="Vigencias" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
</asp:Content>

