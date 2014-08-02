<%@ Page Title="" Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="ActaVerDoc.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_ActaVerDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <asp:HiddenField ID="hdNumero" runat="server" />

        <div style="text-align: justify" contenteditable="true" class="hoja" id="HojaImpr">
            <asp:Literal ID="ltPlantilla" runat="server">
            <table style="  width:100%">
                <tr >
                    <td >
                        <img src="../../../../images/2014/LogoHEAD3.png" width="100" height="50" />
                    </td>
                    <td  style=" border-bottom:1px double #000000; font-size:9px; font-family:Verdana;  width:85%">
                        <b>EMPRESA SOCIAL DEL ESTADO<br />
                            HOSPITAL EDUARDO ARREDONDO DAZA<br />
                            NIT.824.000.725-0<br />
                        </b>
                    </td>
                </tr>
            </table>
            
            <br />
             <p style=" text-align:center"><b>ACTA DE VERIFICACIÓN DE  DOCUMENTAL</b><br /></p>
             <br />
            En la ciudad de Valledupar, el día <span id="FechaOficio"> </span>, en la Oficina de Subdirección Administrativa de la ESE Hospital Eduardo Arredondo Daza, se procede a verificar los documentos aportados dentro de la propuesta presentada por <b>{NOM_CONTRATISTA}</b>, para  {OBJETO}<br /><br />
           <table border="1" style= "margin: 0 auto; text-align:center; font-size:11px; font-family:Tahoma; width:60%" >
                <tr >
                    <td style=" width:5%" >
                        <b>No</b>
                    </td>
                    <td style=" width:45%"> 
                        <p>  <b>Requisitos</b> </p>
                    </td>
                    <td style="width:5%" >
                         <b>Si</b>
                    </td>
                    <td style=" width:5%" >
                        <b>No</b>
                    </td>
                </tr>
               <tr >
                    <td >
                        1
                    </td>
                    <td style="text-align:justify" >
                        Carta de presentación de la propuesta firmada por quien presenta la propuesta, indicando nombre y número de documento de identidad, manifestando que no está incurso en ninguna de las inhabilidades e incompatibilidades previstas en la Constitución y en la Ley para la presentación de la propuesta ni para la celebración del contrato, y en caso de sobrevenir alguna inhabilidad o incompatibilidad, se hará responsable frente al HOSPITAL EDUARDO ARREDONDO DAZA, y frente a terceros por los perjuicios que se ocasionen. La carta igualmente debe contener el nombre, la dirección, números telefónicos y fax y dirección de correo electrónico.
                    </td>
                    <td  >
                         x
                    </td>
                   <td  >
                         
                    </td>
                </tr>
               <tr >
                    <td >
                       2
                    </td>
                    <td  style="text-align:justify">
                        Formato único de hoja de vida  
                    </td>
                    <td  >
                         x
                    </td>
                   <td  >
                         
                    </td>
                </tr>
               <tr >
                    <td >
                       3
                    </td>
                    <td style="text-align:justify" >
                        Declaración de bienes y rentas de personal natural, debidamente diligenciado y firmado. 
                    </td>
                    <td  >
                        x
                    </td>
                   <td  >
                         
                    </td>
                </tr>
               <tr >
                    <td >
                       4
                    </td>
                    <td style="text-align:justify" >
                       Fotocopia de la cédula de ciudadanía. 
                    </td>
                    <td  >
                        x
                    </td>
                   <td  >
                         
                    </td>
                </tr>
                <tr >
                    <td >
                       5
                    </td>
                    <td style="text-align:justify" >
                       Tarjeta Profesional  
                    </td>
                    <td  >
                        x
                    </td>
                   <td  >
                         
                    </td>
                </tr>

               <tr >
                    <td >
                      6
                    </td>
                    <td style="text-align:justify" >
                      RUT – Registro Único Tributario, actualizado 
                    </td>
                    <td  >
                        x
                    </td>
                   <td  >
                         
                    </td>
                </tr>

               <tr >
                    <td >
                      7
                    </td>
                    <td style="text-align:justify" >
                      Certificado de antecedentes disciplinarios expedido por la Procuraduría General de la Nación, vigente. 
                    </td>
                    <td  >
                        x
                    </td>
                   <td  >
                         
                    </td>
                </tr>

                <tr >
                    <td >
                      8
                    </td>
                    <td style="text-align:justify" >
                      Certificado de antecedes fiscales expedido por la Contraloría General de la Nación, vigente. 
                    </td>
                    <td  >
                        x
                    </td>
                   <td  >
                         
                    </td>
                </tr>

               <tr >
                    <td >
                      9
                    </td>
                    <td style="text-align:justify" >
                      Certificado de antecedentes judiciales expedido por la Policía Nacional de Colombia, vigente
                    </td>
                    <td  >
                        x
                    </td>
                   <td  >
                         
                    </td>
                </tr>

               <tr >
                    <td >
                      10
                    </td>
                    <td style="text-align:justify" >
                      Paz y salvo de Industria y Comercio, vigente.
                    </td>
                    <td  >
                        x
                    </td>
                   <td  >
                         
                    </td>
                </tr>

               <tr >
                    <td >
                      11
                    </td>
                    <td style="text-align:justify" >
                    CERTIFICADOS DE ESTUDIO: Titulo Profesional, especialización en Ginecología y Obstetricia.
                    </td>
                    <td  >
                        x
                    </td>
                   <td  >
                         
                    </td>
                </tr>

               <tr >
                    <td >
                      12
                    </td>
                    <td style="text-align:justify" >
                     Certificaciones de experiencia laboral a través del desempeño de sus funciones o con la celebración de contratos suscritos, ejecutados y terminados con entidades públicas o privadas.
                    </td>
                    <td  >
                        x
                    </td>
                   <td  >
                         
                    </td>
                </tr>

               

            </table>
            <br />
            <br />
                Del análisis y revisión documental se tiene el siguiente grado de cumplimiento:
            <br />
            <br />
                <table border="1" style= "margin: 0 auto; text-align:center; font-size:11px; font-family:Tahoma; width:30%">
                    <tr>
                        <td><b>REQUISITOS</b></td>
                          <td><b>OFERENTE</b></td>
                          <td> <b>%</b></td>
                    </tr>
                    <tr>
                        <td>Cumplidos</td>
                          <td> 12</td>
                          <td> 100%</td>
                    </tr>
                     <tr>
                        <td>No Cumplidos</td>
                          <td> 0</td>
                          <td> 0%</td>
                    </tr>
                     
                    <tr>
                        <td><b>Total</b></td>
                          <td> 12</td>
                          <td> 100%</td>
                    </tr>

                </table>
                <br />
                <br />
            <b>OBSERVACIONES:</b> <br />
            Como puede advertirse, la propuesta presentada cumplió con la totalidad de los requisitos exigidos, por lo anterior, es viable la propuesta presentada por el(la) Contratista <b>{NOM_CONTRATISTA}</b> <br />
            <br />
           <b> 1.	VERIFICACIÓN ECONÓMICA</b><br />
            La Propuesta Económica del contratista<b> {NOM_CONTRATISTA}</b>, es por valor de {VALOR_A_CONTRATAR}, oferta que se ajusta al presupuesto de la entidad hospitalaria, por lo que se determina que es favorable y su calificación será CUMPLE. <br /><br />
           <b> 2.	VERIFICACION DE EXPERIENCIA</b><br /><br />
            <table border="1" style= "margin: 0 auto; text-align:center; font-size:11px; font-family:Tahoma; width:60%">
                <tr >
                    <td style="text-align:center; width:10%" >
                        <b>CARGO / OBJETO</b>
                    </td>
                    <td style="text-align:center; width:30%"> 
                        <p>  <b>ENTIDAD O CONTRATANTE</b> </p>
                    </td>
                    <td style="text-align:center; width:10%" >
                         <b>AÑO</b>
                    </td>
                    <td style="text-align:center; width:10%" >
                       <b> DOCUMENTO CON QUE SE ACREDITA LA EXPERIENCIA</b>
                    </td>
                </tr>
               <tr >
                    <td >
                        X
                    </td>
                    <td style="text-align:justify" >
                        XXXXX
                    </td>
                    <td  >
                         x
                    </td>
                   <td  >
                         
                    </td>
                </tr>
               <tr >
                    <td >
                       2
                    </td>
                    <td style="text-align:justify" >
                        xxxxxxx 
                    </td>
                    <td  >
                         x
                    </td>
                   <td  >
                         
                    </td>
                </tr>
               
            </table>
                <br />
                Calificación de experiencia:<b>CUMPLE.</b> <br />
                <p class="center"><b> RESUMEN DE FACTORES DE VERIFICACION</b></p><br />
                <table border="1" style= "margin: 0 auto; text-align:center; font-size:11px; font-family:Tahoma; width:30%">
                    <tr>
                        <td><b>RESUMEN VERIFICACIÓN</b></td>
                          <td><b>{NOM_CONTRATISTA}</b></td>
                          
                    </tr>
                    <tr>
                        <td><b>Verificación jurídica</b></td>
                          <td> HABILITADA</td>
                          
                    </tr>
                     <tr>
                        <td><b>Verificación experiencia</b></td>
                          <td> CUMPLE</td>
                          
                    </tr>
                     
                    <tr>
                        <td><b>Verificación económica</b></td>
                          <td> CUMPLE</td>
                          
                    </tr>
                    <tr>
                        <td><b>Valor de la oferta</b></td>
                          <td> {VALOR_A_CONTRATAR}</td>
                          
                    </tr>

                </table><br />
          <b> RECOMENDACIONES: </b>Revisada y analizada la oferta en su conjunto, se tiene que la misma se ajusta a los requerimientos de la institución hospitalaria, razón por la cual respetuosamente se le recomienda al señor Gerente, proceda a suscribir con <b>{NOM_CONTRATISTA}</b> .<br />
            <br />
                <br />

______________________________________<br />
<b>MARIANO SEBASTIAN OJEDA MARTÍNEZ</b><br />
Subdirector Administrativo<br />


               <p style="font-size:6px"> Anexo: fotocopia simple del contrato</p>
      </asp:Literal>
    </div>
    </form>
</asp:Content>

