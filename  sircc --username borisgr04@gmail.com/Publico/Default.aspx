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
            <br />Vigencia
            <asp:TextBox ID="txtVig" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Digite Numero"></asp:Label>
            <asp:TextBox ID="txtei" runat="server"></asp:TextBox>
            
            <asp:TextBox ID="txtef" runat="server"></asp:TextBox>
            
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
            <asp:TextBox ID="txtScript" runat="server" Height="282px" TextMode="MultiLine" 
                Width="748px" Visible="True">
  Select distinct  
de.Num_egreso,
de.nit
, de.CLS_EGRESO
,de.Ben_cheque
,de.Nro_ctabancaria
,de.cod_banco
,de.cta_banco
,de.nro_cheque
,de.cod_banco_nit
,de.tipo_cta_banco,
mo.Val_Total, 
mo.Val_Neto,
mo.num_orden,
G.RUBRO, 
G.NOM_GASTO
From @v.Degreso de  
inner join @v.MOrden mo  On de.num_egreso= mo.num_egreso  
inner join @v.MEgreso me On de.num_egreso = me.num_egreso 
inner join @v.DOrden d On mo.num_orden= d.num_orden and d.vigencia=mo.vigencia
LEFT JOIN @v.ppto_gastos_v1 g
             ON g.cod_gasto = d.cod_gasto
           AND d.vigencia = g.vigencia
           AND d.cod_unidad = g.cod_unidad
           AND d.cod_recurso = g.cod_recurso
           AND g.vigencia = Mo.VIGENCIA
           
           WHERE DE.ESTADO<>'A' AND CLS_EGRESO='E' AND DE.NRO_CHEQUE IS NULL AND DE.CTA_BANCO IS NOT NULL
AND de.NUM_EGRESO BETWEEN @ei AND @ef
ORDER BY de.NUM_EGRESO ASC 


            </asp:TextBox>
</div>
    </div>
    </form>
</body>
</html>
