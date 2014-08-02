<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GDProcesoN.aspx.vb" Inherits="Procesos_DocProceso_GDocProceso" %>

<%@ Register Src="../../CtrlUsr/Progreso/Progress.ascx" TagName="Progress" TagPrefix="uc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdMin" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="TxtDoc" runat="server" Width="100%"></asp:TextBox>
                    <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                    N° de Proces
                    <asp:TextBox ID="TxtNprocA" runat="server" AutoPostBack="True"></asp:TextBox>
                    Grupo<asp:DropDownList ID="CboGrupos" runat="server" DataSourceID="ObjGrupos" DataTextField="Grupos"
                    DataValueField="Grupo" AutoPostBack="True">
                      <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjGrupos" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetbyProc" TypeName="Grupos">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtNprocA" Name="Num_Proc" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                    <asp:Button ID="btnGenerarDoc" runat="server" Text="GenerarDoc" />

                    <br />
                    <asp:DropDownList ID="cboEtapas" runat="server" AutoPostBack="True" DataSourceID="ObjEtapa" DataTextField="NOM_ETA" DataValueField="COD_ETA">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjEtapa" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" TypeName="Etapas" UpdateMethod="Update">
                        <InsertParameters>
                            <asp:Parameter Name="Cod_Eta" Type="String" />
                            <asp:Parameter Name="Nom_Eta" Type="String" />
                            <asp:Parameter Name="Estado" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Cod_Eta_O" Type="String" />
                            <asp:Parameter Name="Cod_Eta" Type="String" />
                            <asp:Parameter Name="Nom_Eta" Type="String" />
                            <asp:Parameter Name="Estado" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:DropDownList ID="cboTipDoc" runat="server" DataSourceID="ObjTipDoc" DataTextField="DES_TIP" DataValueField="COD_TIP" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjTipDoc" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyEtapa" TypeName="Tip_Doc" UpdateMethod="Update">
                        <InsertParameters>
                            <asp:Parameter Name="Cod_Tip" Type="String" />
                            <asp:Parameter Name="Des_Tip" Type="String" />
                            <asp:Parameter Name="Est_Tip" Type="String" />
                            <asp:Parameter Name="Cod_Etapa" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="cboEtapas" Name="Cod_Eta" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Cod_Tip_O" Type="String" />
                            <asp:Parameter Name="Cod_Tip" Type="String" />
                            <asp:Parameter Name="Des_Tip" Type="String" />
                            <asp:Parameter Name="Est_Tip" Type="String" />
                            <asp:Parameter Name="Cod_Etapa" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>

                    <asp:DropDownList ID="CboPlantilla" runat="server" Height="21px" Width="226px" DataSourceID="ObjPlantillas"
                        DataTextField="Nom_Pla" DataValueField="Ide_Pla">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjPlantillas" runat="server"
                        SelectMethod="GetPreCon" TypeName="PPlantillas" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="cboTipDoc" Name="CODIGO" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <br />
                    <br />

                    <asp:TextBox ID="TxtLog" ReadOnly="true" Height="300" runat="server" Text="" TextMode="MultiLine"
                        Width="100%"></asp:TextBox>

                    <asp:GridView ID="GrdMin" runat="server" AutoGenerateColumns="False" DataSourceID="ObjPGContratosM"
                        EnableModelValidation="True" DataKeyNames="ID">
                        <Columns>
                            <asp:BoundField DataField="Fec_Reg" HeaderText="Fecha de Generación" />
                            <asp:CommandField SelectText="Ver" HeaderText="Ver .Doc" SelectImageUrl="~/images/2012/EditarM.png"
                                ShowSelectButton="True" ButtonType="Image" />
                            <asp:ButtonField ButtonType="Image" HeaderText="Ver PDF" ImageUrl="~/images/2013/pdf.png"
                                CommandName="pdf" Text="Ver PDF" />
                            <asp:ButtonField ButtonType="Image" HeaderText="Anular" ImageUrl="~/images/2012/AnularMinuta.png"
                                CommandName="Inhabilitar" Text="Anular" />

                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjPGContratosM" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetbyPG" TypeName="PGContratosM">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtNprocA" Name="NUM_PROC" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="CboGrupos" Name="GRUPO" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdPrgMin" runat="server" AssociatedUpdatePanelID="UpdMin">
                <ProgressTemplate>
                    <uc3:Progress ID="PrgMin" runat="server" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </form>
</body>
</html>
