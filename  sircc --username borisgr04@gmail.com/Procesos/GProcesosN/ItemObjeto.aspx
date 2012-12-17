<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ItemObjeto.aspx.vb" Inherits="Procesos_GProcesosN_ItemObjeto" %>

<%@ Register src="../../CtrlUsr/DetGProcesos/DetGProcesos.ascx" tagname="DetGProcesos" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    
    <uc1:DetGProcesos ID="DetPContrato1" runat="server" />
    
    &nbsp; &nbsp;
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" 
                Text="Items del Objeto"></asp:Label><br /><asp:Label id="MsgResult" 
                runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="IbtnNuevo" SkinID="IBtnNuevo" runat="server"  CausesValidation="False" CommandName="Nuevo"/> Nuevo Item
                <asp:GridView 
                id="grdInformes" runat="server" 
                AllowSorting="True" 
                DataSourceID="ObjPObjetos_Items" 
                ShowFooter="True" DataKeyNames="Id_Item" 
                AutoGenerateColumns="False" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" SkinID="gridView">
<Columns>
    <asp:TemplateField HeaderText="Item" SortExpression="Id_Item">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_Item") %>'></asp:Label>
        </ItemTemplate>
        
    </asp:TemplateField>
    <asp:BoundField DataField="Desc_Item" HeaderText="Descripción" 
        SortExpression="Desc_Item" >
    <ItemStyle Width="50%" />
    </asp:BoundField>

        <asp:BoundField DataField="Iva_Item"  
        HeaderText="% Iva" SortExpression="Iva_Item" />

    <asp:BoundField DataField="Can_Item" HeaderText="Cantidad" 
        SortExpression="Can_Item" >
        <HeaderStyle HorizontalAlign="Right" />
    </asp:BoundField>
    <asp:BoundField DataField="nom_Unidad" HeaderText="Unidad" 
        SortExpression="nom_Unidad"  />
    <asp:BoundField DataField="Val_Uni_Item" HeaderText="Valor Unitario" 
        SortExpression="Val_Uni_Item" DataFormatString="{0:c}" >
    
    <ItemStyle HorizontalAlign="Right" />
    </asp:BoundField>
    <asp:BoundField DataField="VAL_PARCIAL" DataFormatString="{0:c}" 
        HeaderText="Valor Total" SortExpression="VAL_PARCIAL">
    <ItemStyle HorizontalAlign="Right" />
    </asp:BoundField>
    
    <asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image"></asp:ButtonField>
    <asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image"></asp:ButtonField>
    <asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>

                    <EmptyDataTemplate>
                        Presiones el Boton Nuevo y Digite los Items del Objeto del Contrato
                    </EmptyDataTemplate>

</asp:GridView> 
            <br />
            <asp:ObjectDataSource id="ObjPObjetos_Items" runat="server" TypeName="PObjetos_Items" 
                SelectMethod="GetRecords" OldValuesParameterFormatString="original_{0}">
            </asp:ObjectDataSource>
</contenttemplate>
        
    </asp:UpdatePanel>&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button>

 <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" 
 PopupDragHandleControlID="programmaticPopupDragHandle2" 
 PopupControlID="programmaticPopup2" 
  DropShadow="True" BackgroundCssClass="modalBackground" 
  BehaviorID="programmaticModalPopupBehavior2"  CancelControlID="IbtnCancelar"
  RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp;&nbsp;
            <asp:Panel id="programmaticPopup2" runat="server" Width="661px" Height="449px" 
                CssClass="ModalPanel2">
                <asp:Panel id="programmaticPopupDragHandle2"
                 runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2" >
                 <div style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
                 <div style="FLOAT: left">
                            Item del Objeto del Contrato</DIV><DIV style="FLOAT: right">
                            </DIV></DIV></asp:Panel>
                            <asp:Panel id="area" runat="Server" ScrollBars="Auto">
                            
                                <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                                <br />
                    <table style="margin:0">
                    <tr>
                        <td style="width: 43px">
                            &nbsp;</td>
                        <td style="width: 102px">
                            &nbsp;</td>
                        <td colspan="5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 43px">
                            &nbsp;</td>
                        <td style="width: 102px">
                            <asp:Label ID="Label2" runat="server" Text="Item"></asp:Label>
                        </td>
                        <td colspan="5">
                            <asp:TextBox ID="TxtIde" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 43px">
                            &nbsp;</td>
                        <td style="width: 102px">
                            <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label>
                        </td>
                        <td colspan="5">
                            <asp:TextBox ID="TxtDes" runat="server" Height="53px" TextMode="MultiLine" 
                                Width="426px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="TxtDes" ErrorMessage="Digite Descrpción del Informe">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                                    <tr>
                                        <td style="width: 43px">
                                            &nbsp;</td>
                                        <td style="width: 102px">
                                            <asp:Label ID="Label11" runat="server" Text="Cantidad"></asp:Label>
                                        </td>
                                        <td colspan="5">
                                         
                            </telerik:RadNumericTextBox> <telerik:RadNumericTextBox ID="TxtCan" Runat="server" Culture="es-CO" Height="19px" Skin="Default" Value="0" Width="125px">
                            </telerik:RadNumericTextBox>
                                            <%--<asp:TextBox ID="TxtCan" runat="server"></asp:TextBox>--%>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 43px">
                                            &nbsp;</td>
                                        <td style="width: 102px">
                                            <asp:Label ID="Label8" runat="server" Text="Unidad"></asp:Label>
                                        </td>
                                        <td colspan="5">
                                            <asp:DropDownList ID="CboUnidad" runat="server" DataSourceID="ObjPUnidades" 
                                                DataTextField="Nom_Unidad" DataValueField="Cod_Unidad">
                                                <asp:ListItem Value="AC">Activa</asp:ListItem>
                                                <asp:ListItem Value="EN">Entregado</asp:ListItem>
                                                <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjPUnidades" runat="server" 
                                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                                TypeName="PUnidades"></asp:ObjectDataSource>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                    <tr>
                        <td style="width: 43px">
                            &nbsp;</td>
                        <td style="width: 102px">
                            <asp:Label ID="Label6" runat="server" Text="Valor Unitario"></asp:Label>
                        </td>
                        <td colspan="5">
                            <%--<asp:TextBox ID="TxtValUni" runat="server"></asp:TextBox>--%>
                            
                             <telerik:RadNumericTextBox ID="TxtValUni" Runat="server" Culture="es-CO" Height="19px" Skin="Default" Value="0" Width="125px">
                            </telerik:RadNumericTextBox>
                            
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="TxtValUni" 
                                ErrorMessage="Digite Fecha Final del Periodo del Informe">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 43px">
                            &nbsp;</td>
                        <td style="width: 102px">
                            <asp:Label ID="Label12" runat="server" Text="% Iva"></asp:Label>
                            &nbsp;Aplicado</td>
                        <td colspan="5">
                            <%--<asp:TextBox ID="TxtIva" runat="server"></asp:TextBox>--%>
                            <telerik:RadNumericTextBox ID="TxtIva" Runat="server" Culture="es-CO" Height="19px" Skin="Default" Value="0" Width="125px">
                            </telerik:RadNumericTextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="TxtIva" ErrorMessage="Fecha de Recordatorio">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                                    <tr>
                                        <td style="width: 43px">
                                            &nbsp;</td>
                                        <td style="width: 102px">
                                            &nbsp;</td>
                                        <td colspan="5">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                    <tr>
                        <td style="width: 43px">
                            &nbsp;</td>
                        <td style="width: 102px; text-align: center;">
                            <asp:ImageButton ID="IBtnGuardar" runat="server" SkinID="IBtnGuardar" />
                        </td>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="IBtnEliminar" runat="server" SkinID="IBtnEliminar" />
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="IBtnCancelar" runat="server" 
                                 SkinID="IBtnCancelar" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                        <tr>
                            <td style="width: 43px">
                                &nbsp;</td>
                            <td style="width: 102px; text-align: center;">
                                Guardar</td>
                            <td style="text-align: center">
                                &nbsp;</td>
                            <td style="text-align: center">
                                Elimnar</td>
                            <td style="text-align: center">
                                Cancelar</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                </TABLE>
                <br />
                </asp:Panel>
                &nbsp;<br /> </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
        
    </asp:UpdatePanel>

    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>

