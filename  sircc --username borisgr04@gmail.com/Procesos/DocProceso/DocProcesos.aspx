<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="DocProcesos.aspx.vb" Inherits="Procesos_DocProceso_DocProcesos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <script src="../../Scripts/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8rc3.custom.min.js" type="text/javascript"></script>
    <link href="../../Styles/Estyle.css" rel="stylesheet" type="text/css" />
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true"
        EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    <script type="text/javascript">

        function ValId(){
                    var Id=document.aspnetForm.<%=Me.TxtId.ClientID%>.value; 
                    if(Id =="" )
                    {
                    alert("Debe Seleccionar un Documento");
                    return;
                    }
            }
            function OpenSirccD(oper){
                if (navigator.userAgent.indexOf('MSIE') !=-1) {

                    var proceso=document.aspnetForm.<%=Me.TxtNProceso.ClientID%>.value;
                    var usuario=document.aspnetForm.<%=Me.HdUsuario.ClientID%>.value; 
                    var des_doc=document.aspnetForm.<%=Me.TxtDoc.ClientID%>.value; 
                    
                    var tip_doc=String(des_doc).substring(0,2);
                    var tip_doc=String(des_doc).substring(0,2);
                    var fec_doc=document.aspnetForm.<%=Me.TxtFec.ClientID%>.value; 
                    var nom=document.aspnetForm.<%=Me.TxtNom.ClientID%>.value; 
                    if (oper=="pnd"){
                    document.aspnetForm.<%=Me.TxtId.ClientID%>.value="";
                    }
                    var id_doc=document.aspnetForm.<%=Me.TxtId.ClientID%>.value; 
                    if(des_doc =="" )
                    {
                    alert("Seleccione el Tipo de Documento");
                    document.aspnetForm.<%=Me.TxtDoc.ClientID%>.focus();
                    return;
                    }
                    if( nom == "" ){
                       
                        if (!confirm('No digito Nombre, El Sistema le asignará automaticamente?')){
                        return;
                        }
                        var iLen = String(des_doc).length;
                        nom= String(des_doc).substring(3, iLen);
                        document.aspnetForm.<%=Me.TxtNom.ClientID%>.value=nom;
                        
                    }
                     if( fec_doc == ""){
                        var f=new Date();
                        if (!confirm('No digito fecha, quiere que el Sistema asigne la fecha automaticamente?')){
                        return;
                        }
                        fec_doc=f.getDate()+"/"+f.getMonth()+"/"+f.getFullYear() ;
                        document.aspnetForm.<%=Me.TxtFec.ClientID%>.value=fec_doc;
                        
                    }
                    
                    var oShell = new ActiveXObject("Shell.Application");
                    var commandtoRun = "C:\\SirccD\\SirccD.exe";
                    if(id_doc==null && oper!="pnd"){
                        alert('Debe haber seleccionado un Documento existente, para esta operación');
                        return ;
                    }
                    
                    var commandParms = usuario +";"+oper+ ";" + proceso + ";" + tip_doc+";"+id_doc+";"+fec_doc+";"+nom ;
                    //alert(commandParms ); 
                    oShell.ShellExecute(commandtoRun, commandParms, "", "open", "1");
                    
                    alert("Presione aceptar después que se halla generado el Documento, para actualizar la página");
                    
                    location.reload();
                    
                    
                }
                else{
                   alert('El Navegador no es Compatible con la Operación. Por Favor abrá manualmente SIRCCD, y Seleccione el Numero del Proceso');
               } 
                
            }
        
            $(function () {
                $("#<%= TxtDoc.ClientID  %>").autocomplete({
                    delay: 1,
                    minLength: 1,
                    source: function (request, response) {
                        PageMethods.ObtieneNombres(request.term,
                            function (data) {
                                var nombres = (typeof data) == 'string' ? eval('(' + data + ')') : data;
                                response(nombres);
                            },
                            fnLlamadaError);
                    }

                });
            });

            function fnLlamadaError(excepcion) { alert('Ha ocurrido un error al traer los nombres: ' + excepcion.get_message()); }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HdUsuario" runat="server" />
            <asp:Label ID="Label2" runat="server" CssClass="Titulo" Text="Documentos Precontractuales"></asp:Label>
            <br />
            <table>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 134px">
                        N° Proceso
                    </td>
                    <td>
                        <asp:TextBox ID="txtNProceso" runat="server" Enabled="false" Text="CD3-EAD-0002-2012"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 134px">
                        Objeto
                    </td>
                    <td>
                        <asp:Label ID="LbObjeto0" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="MsgResult" runat="server" Height="30px" SkinID="MsgResult" Visible="False"
                            Width="90%"></asp:Label>
                    </td>
                </tr>
            </table>
            
            <br />

            <table>
            <tr>
            <td > 
            <fieldset style="padding:20px;height:400px">
                <legend>
                    <asp:Label ID="Label1" runat="server" CssClass="SubTitulo" Text="Datos del Documento"></asp:Label>
                </legend>
                <table id="TABLE1">
                    <tr>
                        <td colspan="9">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px" colspan="2">
                            Id
                        </td>
                        <td colspan="7" style="height: 21px">
                            <asp:TextBox ID="TxtId" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px" colspan="2">
                            Tipo de Documento
                        </td>
                        <td colspan="7" style="height: 21px">
                            <asp:TextBox ID="TxtDoc" runat="server" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px" colspan="2">
                            Descripcion
                        </td>
                        <td colspan="7" style="height: 18px">
                            <asp:TextBox ID="TxtNom" runat="server" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px" colspan="2">
                            Fecha Documento
                        </td>
                        <td colspan="7" style="height: 21px">
                            <asp:TextBox ID="TxtFec" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="TxtFec_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="TxtFec">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 32px; height: 21px">
                            &nbsp;
                        </td>
                        <td style="width: 60px; height: 21px">
                            &nbsp;
                        </td>
                        <td style="height: 21px" colspan="7">
                            &nbsp;
                        </td>
                    </tr>
                    <asp:Label runat="server" Text="&nbsp;" ID="uploadResult" />
                    <tr>
                        <td style="width: 32px; height: 21px">
                            &nbsp;
                        </td>
                        <td style="width: 60px; height: 21px; text-align: center;">
                            <asp:ImageButton ID="IBtnGenDoc" runat="server" OnClientClick="javascript:OpenSirccD('pnd')"
                                SkinID="IBtnMinuta" />
                        </td>
                        <td style="height: 21px; text-align: center; width: 58px;">
                            <asp:ImageButton ID="IBtnEditarB" runat="server" Enabled="False" OnClientClick="javascript:OpenSirccD('pep')"
                                SkinID="IBtnEditBase" />
                        </td>
                        <td style="height: 21px; text-align: center; width: 69px;">
                            <asp:ImageButton ID="IBtnEditarD" runat="server" Enabled="False" OnClientClick="javascript:OpenSirccD('ped')"
                                SkinID="IBtnEditMin" />
                        </td>
                        <td style="height: 21px; text-align: center; width: 66px;">
                            <asp:ImageButton ID="IBtnRegenerar" runat="server" Enabled="False" OnClientClick="javascript:OpenSirccD('psd')"
                                SkinID="IBtnSincronizar" />
                        </td>
                        <td style="width: 61px; height: 21px; text-align: center;">
                            <asp:ImageButton ID="IBtnAnular" runat="server" Enabled="False" SkinID="IBtnAnularM" />
                        </td>
                        <td style="width: 36px; height: 21px; text-align: center;">
                            &nbsp;
                        </td>
                        <td style="width: 76px; height: 21px; text-align: center;">
                            <asp:ImageButton ID="IBtnGuardar" runat="server" Enabled="False" SkinID="IBtnGuardar"
                                OnClientClick="javascript:ValId();" ToolTip="Actualiza Descripción y Fecha" />
                        </td>
                        <td style="width: 13px; height: 21px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 32px; height: 21px">
                            &nbsp;
                        </td>
                        <td style="width: 60px; height: 21px; text-align: center;">
                            Nuevo Documento
                        </td>
                        <td style="height: 21px; text-align: center; width: 58px;">
                            Editar
                            <br />
                            Plantilla
                        </td>
                        <td style="height: 21px; width: 69px; text-align: center;">
                            Editar Documento
                        </td>
                        <td style="height: 21px; width: 66px; text-align: center;">
                            Sincronizar Datos
                        </td>
                        <td style="width: 61px; height: 21px; text-align: center;">
                            Anular
                            <br />
                            Documento
                        </td>
                        <td style="width: 36px; height: 21px; text-align: center;">
                            &nbsp;
                        </td>
                        <td style="width: 76px; height: 21px; text-align: center;">
                            Guardar<br />
                            Datos
                        </td>
                        <td style="width: 13px; height: 21px; text-align: center;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px; width: 32px;">
                            &nbsp;
                        </td>
                        <td colspan="8" style="height: 21px">
                            <asp:ObjectDataSource ID="ObjDocPContratos" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetDocs" TypeName="DocPContratos">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtNProceso" Name="NUM_PROC" PropertyName="Text"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px; width: 32px;">
                            &nbsp;
                        </td>
                        <td colspan="8" style="height: 21px">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </fieldset></td>
            
            <td style="vertical-align:top; "">
            <fieldset style="height:400px; padding:20px;overflow:auto; ">
            <legend >
            <asp:Label ID="Label3" runat="server" CssClass="SubTitulo" Text="Listado Documento"></asp:Label>
            </legend>
            Selecciones Documentos para Editarlo.
            <asp:GridView ID="grdDocP" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                DataSourceID="ObjDocPContratos" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" SortExpression="ID" />
                    <asp:BoundField DataField="NOM_ETA" HeaderText="Etapa" SortExpression="NOM_ETA" />
                    <asp:BoundField DataField="DES_TIP" HeaderText="Documento" SortExpression="DES_TIP" />
                    <asp:BoundField DataField="Nombre" HeaderText="Descripción" SortExpression="Nombre" />
                    <asp:BoundField DataField="Fec_Doc" DataFormatString="{0:d}" HeaderText="Fecha Doc"
                        SortExpression="Fec_Doc" />
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/2012/select.png" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            </fieldset>
            </td>
            </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
