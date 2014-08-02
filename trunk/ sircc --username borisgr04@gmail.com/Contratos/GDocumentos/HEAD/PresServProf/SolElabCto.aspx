<%@ Page Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master"  AutoEventWireup="false" CodeFile="SolElabCto.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_SolElabCto" %>
<asp:content id="Content1" contentplaceholderid="head" runat="Server">
</asp:content>

<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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
            <p>
            Valledupar, <span id="FechaOficio"></span>
            </p>
            <br />
            <br />
            Señores<br />
            <b>OFICINA JURÍDICA</b><br />
            <b> Att: Dra. DINA MARGARITA ZABALETA MOLINA</b><br />
            Abogada Contratista<br />
            E.S.E. Hospital Eduardo Arredondo Daza<br />
            Ciudad
            <br />
            <br />
             <p style="text-align:right"><b>Ref.: Aceptación recomendación Acta de Verificación Documental.</b></p>
            <br />
            <br />
            En atención a la comunicación de fecha <span id="FechaOficio2"></span> en donde el Subdirector Administrativo de la E.S.E. recomienda contratar, {OBJETO} con <b>{NOM_CONTRATISTA}</b>, atentamente me permito comunicarle que esta gerencia aprueba y acepta la recomendación hecha por el mismo.
            <br />
            <br />
            Por lo anterior le solicito su oficiosidad para que se realicen los trámites pertinentes para la elaboración y legalización del contrato.
            <br />
            <br />
            Atentamente,
            <br />
            <br />
            <br />
            <br />
            <br />
            _______________________________________ <br />
            <b>LEONARDO JOSE MAYA AMAYA</b> <br />
            Gerente <br />

 </asp:Literal>
    </div>
    </form>


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

                    $("#FechaOficio2").text(fechaLarga);

                });

                $("#calendar").click(function () {
                    $("#txtFecha").focus();
                });
                /*
                .next().on(ace.click_event, function () {
                    $(this).prev().focus();
                })
                */




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

</asp:content>
