<%@ Page Language="VB" AutoEventWireup="false" CodeFile="word.aspx.vb" Inherits="Publico_word" %>

<%@ Register src="../CtrlUsr/Progreso/Progress.ascx" tagname="Progress" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Button ID="Button1" runat="server" Text="Generar Minuta" />
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <asp:Button ID="Button2" runat="server" Text="Imprimir Documento" />
                <asp:Label ID="LbActualizar" runat="server"></asp:Label>
                <asp:Button ID="Btn3" runat="server" Text="Thread"></asp:Button>
                <asp:Timer ID="Timer1" runat="server">
                </asp:Timer>
            </ContentTemplate>
        
        </asp:UpdatePanel>
        
        <asp:UpdateProgress runat="server">
            <progresstemplate>
                <uc1:Progress ID="Progress1" runat="server" />
            </progresstemplate>

        </asp:UpdateProgress>

    </div>
    </form>
</body>
</html>
