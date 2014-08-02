<%@ Page Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="ActaRecOferta.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_ActaRecOferta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <div class="row">
            <div class="form-group">
                <label class="col-sm-1 control-label no-padding-right" for="HApertura">Hora Ofico</label>
                <div class="col-sm-2">
                        <input id="HApertura" type="text" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-1 control-label no-padding-right" for="HCierre">Hora Cierre</label>
                <div class="col-sm-2">
                        <input id="HCierre" type="text" class="form-control" />
                </div>
            </div>
    </div>

   
   
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
    <asp:HiddenField ID="hdNumero" runat="server" />
   
    <div style="text-align: justify" contenteditable="true" class="hoja" id="HojaImpr" >
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
        <p class="txtcentrado">
            <b>ACTA DE RECEPCIÓN DE OFERTA</b>
        </p>
        <br />
        <br />
        En la ciudad de Valledupar, a los  <span id="FechaOficio"></span>, siendo las <span id="HoraOficio"></span>, en la oficina de Gerencia de la EMPRESA SOCIAL DEL ESTADO - HOSPITAL EDUARDO ARREDONDO DAZA, transcurrida la fecha y hora límite establecido para la presentación de la oferta dentro del proceso de contratación directa adelantado para la  {OBJETO}; se procede a dejar constancia de la propuesta presentada, luego de la apertura de su sobre, así:
            <br />
        <br />
        <table border="1" style= "margin: 0 auto; text-align:center; font-size:11px; font-family:Tahoma " >
            <tr>
                <td><b>Nro</b></td>
                <td><b>Fecha</b></td>
                <td><b>Hora</b> </td>
                <td><b>Proponente</b></td>
                <td><b>Valor de la oferta</b></td>
                <td><b>Folio</b></td>
                <td><b>SGP y AP</b></td>
            </tr>
            <tr>
                <td>1</td>
                <td>{FECHA_ENTREGA}</td>
                <td> {HORA_ENTREGA}</td>
                <td>{NOM_CONTRATISTA}</td>
                <td> {VALOR_A_CONTRATAR} </td>
                <td>{FOLIOS}</td>
                <td style="text-align:justify ">Aporta Comprobante de Pago de Planilla Única al Sistema de Seguridad Social Integral correspondiente a salud y riesgos laborales</td>
            </tr>

        </table>
        <br />
        No siendo otro el motivo de la presente diligencia, se procede a finalizar la misma siendo las <span id="HoraFinal"></span> 
        <br />
        <br />
        Atentamente,
            <br />
        <br />
        <br />
        <br />
        <br />
        __________________________
        <br />
        <B>OLGA LUCIA RASGO </B>
        <br />
        Secretaria Gerencia
        <br />


  </asp:Literal>
    </div>
</form >
    <script type="text/javascript">

        var Oficios = (function ($) {


            var imprSelec = function () {
                var ventimp = window.open(' ', 'popimpr');
                ventimp.document.write($("#muestra").text);
                ventimp.document.close(); ventimp.print();
                ventimp.close();
            };

            var _addHandlers = function () {
                
                $('.date-picker').datepicker({
                    autoclose: true,
                    todayHighlight: true,
                    format: 'mm/dd/yyyy',
                    startDate: '-3d'
                })
                .on('changeDate', function (ev) {

                    //alert("cambio" + dateData);

                    var meses = new Array("Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre");
                    var diasSemana = new Array("Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado");


                    var dateData = $(this).val();
                    var f = new Date(dateData);

                    //alert($("#txtFecha").val());
                    //var fechaLarga = f.getDate() + " de " + meses[f.getMonth()] + " de " + f.getFullYear();

                    var fechaLarga = (diasSemana[f.getDay()] + ", " + f.getDate() + " de " + meses[f.getMonth()] + " de " + f.getFullYear());

                    $("#FechaEntrega").text(fechaLarga);

                });

                $("#calendar").click(function () {
                    $("#txtFecha").focus();
                });
                


                $("#HCierre").blur(function () {
                    $("#HoraFinal").text($("#HCierre").val());

                });

                $("#HApertura").blur(function () {
                    $("#HoraOficio").text($("#HApertura").val());
                   
                });

                var getCodigoProceso = function () {
                    return "SASI-SGR-0009-2011";
                }
               
                $('#timepicker2').timepicker({
                    minuteStep: 1,
                    showSeconds: true,
                    showMeridian: false
                })
               .on('changeDate', function (ev) {
                   var h = $(this).val();
                   $("#HoraOficio").text(h);
                });

                $('#timepicker1').timepicker({
                    minuteStep: 1,
                    showSeconds: true,
                    showMeridian: false
                }).next().on(ace.click_event, function () {
                    $(this).prev().focus();
                });


                $('#timepicker3').timepicker({
                    minuteStep: 1,
                    showSeconds: true,
                    showMeridian: false
                }).next().on(ace.click_event, function () {
                    $(this).prev().focus();
                });
                
            };

            return {
                init: function () {
                    _addHandlers();
                }
            }

        }(jQuery));
        $(document).ready(function () {
            Oficios.init();
        });
</script>
</asp:Content>
