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
        <button onclick="window.print();" class="BtnImprimir">Imprimir</button>
        <div style="text-align: justify" contenteditable="true" class="hoja">
            <asp:Literal ID="ltPlantilla" runat="server">
                <table class="tbconborde" style="width:100%">
                <tr >
                    <td  rowspan="2">
                        <img src="../../imagenes/logoOficios.png" />
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
            <p>
            FECHA: {FECHA}
            </p>
            <br />
            <br />
            <p> DEPENDENCIA: {DEPENDENCIA_DELEGADA} </p>
            <br />
            <br />
             CONTRATISTA: {NOM_CONTRATISTA}
            <br />
            <br />
             NUMERO DEL CONTRATO: {NUMERO}
            <br />
            <br />
            Certificado(s) de disponiblidad Presupuestal : {CDP} 
            <br />
            <br />
            VALOR DEL CONTRATO: {VALOR_A_CONTRATAR}
            <br />
            <br />
             <p> FUNCIONARIO RESPONSABLE:{NOM_ENC_DEPENDENCIAD} </p>  
            
      
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
