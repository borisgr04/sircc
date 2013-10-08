<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConMiembros.ascx.vb" Inherits="CtrlUsr_ConsorciosUT_ConMiembros" %>
<fieldset>
<legend>
Miembros de Consorcio o Union Temporal.
</legend>
                <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" 
                EnableModelValidation="True" 
                Height="130px" Width="574px" 
                AllowSorting="True" CellPadding="4" DataKeyNames="Id_Miembros" 
                    EmptyDataText="No se encontraron miembros Asociados al Consorcios y/o Unión Temporal" 
                    ShowFooter="True" DataSourceID="ObjMiembros">
                    <Columns>
                        <asp:BoundField DataField="Id_Miembros" HeaderText="Identificación" />
                        <asp:BoundField DataField="Nom_Miembro" HeaderText="Nombre" />
                        <asp:BoundField DataField="Porc_Part" HeaderText="% Participación" />
                        <asp:BoundField DataField="Id_Estado" HeaderText="Estado" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjMiembros" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyTer" 
                    TypeName="ConsorciosxC" >
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HdIde_Ter" Name="IDE_TER" PropertyName="value" 
                            Type="String" />
                    </SelectParameters>
                    
                </asp:ObjectDataSource>
                <asp:HiddenField ID="HdIde_Ter" runat="server" />


</fieldset>