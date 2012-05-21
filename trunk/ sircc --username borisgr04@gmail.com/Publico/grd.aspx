<%@ Page Language="VB" AutoEventWireup="false" CodeFile="grd.aspx.vb" Inherits="Publico_grd" StyleSheetTheme="" EnableTheming="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/BlueTheme/site.css" rel="stylesheet" type="text/css" />
</head>
<body class="template">
  
    <form id="form1" runat="server">
    <div>
      <h1><span class="allcaps">Dynamic Data Site</span></h1>
    <div class="back">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" DataSourceID="ObjectDataSource1" CssClass="gridview" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                
            <asp:TemplateField HeaderText="Table Name" SortExpression="TableName">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("Tip_proc") %>'><%#Eval("Nom_Tproc") %></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        
            </Columns>
        </asp:GridView>

          <asp:DetailsView ID="DetailsView1" runat="server" 
            DataSourceID="ObjectDataSource1" OnItemDeleted="DetailsView1_ItemDeleted"
                CssClass="detailstable" FieldHeaderStyle-CssClass="bold" 
            EnableModelValidation="True" >
                <Fields>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="EditHyperLink" runat="server"
                                NavigateUrl='<%# 1 %>'
                                Text="Edit" />
                            <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="Delete" CausesValidation="false"
                                OnClientClick='return confirm("Are you sure you want to delete this item?");'
                                Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Cons_Proc" UpdateMethod="Update">
            <UpdateParameters>
                <asp:Parameter Name="Vigencia_PK" Type="String" />
                <asp:Parameter Name="Dep_Del_PK" Type="String" />
                <asp:Parameter Name="Cod_Tpro_PK" Type="String" />
                <asp:Parameter Name="Vigencia" Type="String" />
                <asp:Parameter Name="Dep_Del" Type="String" />
                <asp:Parameter Name="Cod_Tpro" Type="String" />
                <asp:Parameter Name="Inicial" Type="Int32" />
                <asp:Parameter Name="Siguiente" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
