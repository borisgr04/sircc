<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Designacion.aspx.vb" Inherits="Contratos_GDocumentos_Designacion" %>

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
                          CONTRATO N°  
                    </th>
                </tr>
                <tr >
                    <th>
                          {NUMERO}</th>
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
            Por medio de la presente, me permito comunicarle que el cargo que usted ocupa ha sido designado como Supervisor del <b>{CLASE_CONTRATO}</b>: No <b>{NUMERO}</b> suscrito con: <b>{NOM_CONTRATISTA}</b>, cuyo Objeto consiste en: <b>{OBJETO}</b>.</p>
        <br />
        <p>
            Para la eficaz realización de la actividad que se le encomienda deberá dar cumplimiento a lo dispuesto en el Manual de Interventoría Departamental, adoptado mediante Resolución No. 000124 del 23 de mayo de 2013, verificando entre otras el cumplimiento de las obligaciones por parte del contratista, proyectar y suscribir actas e informes de ejecución, verificar y dejar constancia del pago de aportes parafiscales y el cumplimiento de obligaciones con el sistema de salud integral,  liquidación del contrato.
        </p>
        <br />
        Atentamente,
        <br />
        <br />
        <br />
         <b>{NOM_ENC_DEPENDENCIAD}</b><br />
            {CAR_ENC_DEPENDENCIAD}<br />
            Gobernación del Cesar<br />
        <br />
        <br />
        Proyecto: {NOM_USUARIO}. <br />
        <br />
        Adjunto: CD con  la información del Contrato en mención
        <br />
        <br />
        </asp:Literal>
            

        </div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
</body>
</html>
