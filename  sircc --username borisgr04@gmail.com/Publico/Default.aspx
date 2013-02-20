<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Publico_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="demoarea">
            <asp:Label ID="LbNav" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Digite Numero"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="TextBox3" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:Button ID="Button1" runat="server" Text="Exportar" />
            <br />
            <br />
            <asp:Label ID="LbError" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:CheckBox ID="Chk1" runat="server" AutoPostBack="True" 
                Text="Configuración" />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Height="282px" TextMode="MultiLine" 
                Width="748px" Visible="False">select  Num_Egreso,Nit,Ben_Cheque,Nro_CtaBancaria,Cod_BAnco,VAl_Total,Val_Neto,Cta_BAnco,Cod_Banco_Nit,Tipo_Cta_BAnco,sec_operacion,
(Select Num_Orden From pct2013.morden where Num_Orden=sec_operacion) orden
  from pct2013.degreso de where Estado<>'AC' Num_Egreso BetWeen </asp:TextBox>
</div>
    </div>
    </form>
</body>
</html>
