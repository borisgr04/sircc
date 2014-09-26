<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DesignacionAdicion.aspx.vb" Inherits="Contratos_GDocumentos_DesignacionAdicion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="docEP.css" rel="stylesheet" />
    <style>
        
        .auto-style1 {
            width: 60px;
        }
        .auto-style2 {
            width: 48px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div "width:100%" class="BtnImprimir">
            <asp:HiddenField ID="hdNumero" runat="server" />
            <%--<button onclick="window.print();" class="BtnImprimir" >Imprimir</button>--%>
           <table >
               <tr>
                    <td class="auto-style1"> <asp:ImageButton ID="IBtnImp"  runat="server" Height="32px" Width="32px"  OnClientClick="window.print();" SkinID="IBtnImp" /></td>
                    
                    <td class="auto-style2"><asp:ImageButton ID="IBtnAtras" runat="server" Height="32px" Width="33px"  SkinID="IBtnAtras" /></td>
                   </tr>
               <tr >
                   <td class="auto-style1"><b>Imprimir</b> </td>
                   <td class="auto-style2" ><b>Atras</b></td>

               </tr>
           </table>     
            
        </div>
        <div style="text-align: justify" contenteditable="true" class="hoja">
            <asp:Literal ID="ltPlantilla" runat="server">
                <table class="tbconborde" style="width:100%">
                <tr >
                    <td  rowspan="2">
                        <img src="../../images/2014/logoOficios.png" />
                        <%--<img alt="" src="/ashx/ashxImg.ashx" width="60px" height="60px" />--%>
                    </td>
                    <th rowspan="2">
                        DESIGNACIÓN DE SUPERVISIÓN Y/O INTERVENTORIA
                    </th>
                    <th style="width:20%">
                         MODIFICATORIO N°  
                    </th>
                </tr>
                <tr >
                    <th>
                          {NUMERO}

                    </th>
                </tr>
                
            </table>
            <br />
            <p>
            Valledupar, {FECHA}
            </p>
            <br />
            <br />
            Doctor<br />
            <b>{NOM_SUPERVISOR}</b><br />
            <b>{CAR_SUPERVISOR}</b><br />
            <b>{DEP_SUPERVISOR}</b><br />
            Gobernación Departamento del Cesar<br />
            Valledupar <br />
            <br />
        <br />
        Cordial Saludo:
        <br />
        <br />
        <p>
            Por medio de la presente, me permito enviarle información del modifcatorio con su respectiva aprobación de poliza del contrato de {CLASE_CONTRATO} No <b>{NUMERO}</b> suscrito con: <b>{NOM_CONTRATISTA}</b>, cuyo Objeto consiste en: <b>{OBJETO}</b>.</p>
        <br />
        <br />
        Atentamente,
        <br />
        <br />
        <br />
           <b>{NOM_ENC_DEPENDENCIAD}</b><br />
            {CAR_ENC_DEPENDENCIAD}  Gobernación del Cesar<br />
        <br />
        <br />
       <p class="txtsize"> Proyecto: {NOM_USUARIO}. </p><br />
       <p class="txtsize"> Adjunto: CD con información del contaro en meción </p><br />
        <br />
        <br />
        
        </asp:Literal>
            

        </div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
</body>
</html>
