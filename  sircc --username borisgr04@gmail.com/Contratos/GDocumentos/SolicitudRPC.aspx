<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SolicitudRPC.aspx.vb" Inherits="Contratos_GDocumentos_SolicitudRPC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="docEP.css" rel="stylesheet" />
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
                        SOLICITUD DE REGISTRO PRESUPUESTAL DE COMPROMISOS
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
            <p><b>FECHA:</b> {FECHA}</p>
            <br />
            <br />
            <p> <b>DEPENDENCIA:</b> {DEPENDENCIA_DELEGADA} </p>
            <br />
            <br />
             <p><b> FUNCIONARIO RESPONSABLE:</b> {NOM_ENC_DEPENDENCIAD} </p>
            <br />
            <br />
             <p> <b> CONTRATISTA:</b> {NOM_CONTRATISTA} </p> 
            <br />
            <br />
            <p><b> NUMERO DEL CONTRATO:</b> {NUMERO}</p> 
            <br />
            <br />
           <p> <b>CERTIFICADO(S) DE DISPONIBLIDAD PRESUPUESTAL:</b> {CDP} </p> 
            <br />
            <br />
           <p> <b>VALOR DEL CONTRATO:</b> {VALOR_A_CONTRATAR}</p> 
            <br />
            <br />
             <p> <b>FUNCIONARIO RESPONSABLE:</b> {NOM_ENC_DEPENDENCIAD} </p>  
        <br />    
        <br />
        <br />
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
        <br />
       
        
            </asp:Literal>


        </div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
</body>
</html>
