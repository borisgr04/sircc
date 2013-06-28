$(function () {
    $('#tb-consultaC').dataTable({
        "oLanguage": { "sSearch": "Buscar :" },
        "bJQueryUI": true,
        "bPaginate": false,
        "bInfo": false,
        "oLanguage": {
            "sUrl": "../../Styles/datatablesES.txt"
        }

    });
    $('#tb-consulta').dataTable({
        "oLanguage": { "sSearch": "Buscar el Contrato:" },
        "bJQueryUI": true,
        "bPaginate": true,
        "bInfo": true,
        "oLanguage": {
            "sUrl": "../../Styles/datatablesES.txt"
        },
        "sScrollY": 400,
        "sScrollX": 700,
        "sScrollXInner": "120%"
    });

    $(TxtNroCto).keypress(function (e) {
        if (e.which == 13) {
            numeroC();
        }
    });
    BtnConsCon.click(function () {
        return VerDependencia();
    });
    BtnCons.click(function () {
        return VerDependencia();

    });
    function VerDependencia() {
        if (HdUser.val() != "admin") {
            if (CmbDep.selectedIndex == -1) {
                alert("No tiene ninguna dependencia asignada, por favor comuniquese con el Administrador del Sistema!!!");
                return false;
            }
        }
        return true;
    }
    TxtNroCto.blur(function () {
        numeroC();
    });
    function numeroC() {
        var nro = 0;
        //var TxtNroCto = $get('<%=TxtNroCto.ClientID %>');
        //var CmbVig = $get('<%=CmbVig.ClientID %>');
        //var cboTipo = $get('<%=cboTipo.ClientID %>');
        if (TxtNroCto.value.length < 10) {
            nro = CmbVig.value + cboTipo.value + pad(TxtNroCto.val(), 4);
        }
        else {
            nro = TxtNroCto.val();
        }
        TxtNroCto.val(nro);
    }
    TxtIdeCon.blur(function () {
        //var TxtIdeCon = $get('<%=TxtIdeCon.ClientID %>');
        //var TxtCtotista = $get('<%=TxtCtotista.ClientID %>');
        if (TxtIdeCon.value.length > 0) {
            BuscarTercero(TxtIdeCon.val(), TxtCtotista);
        }

    });
    TxtIdeSup.blur(function () {
        //var TxtIdeSup = TxtIdeSup;
        //var TxtSupervisor = $get('<%=TxtSupervisor.ClientID %>');
        if (TxtIdeSup.value.length > 0) {
            BuscarTercero(TxtIdeSup.val(), TxtSupervisor);
        }
    });

    function BuscarTercero(ide_ter, txtNom) {
        var nombre = "";
        $.ajax({
            type: "POST",
            url: "CGesContratos.aspx/GetTercerosPk",
            data: "{ide_ter:'" + ide_ter + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d == "0") {
                    alert("Tercero no Encontrado");
                    txtNom.val("");
                } else {
                    txtNom.val(response.d);
                }

            },
            error: function (response) {
                if (response.length != 0)
                    alert(response);
            }
        });
        return nombre;
    }
});

function AbrirPagina(url) {
    self.location.href = url;
}
function pad(str, max) {
    return str.length < max ? pad("0" + str, max) : str;
}
function CerrarModal() {
    var modalPopup1 = $find(modal);
    limpiarGrid();
    modalPopup1.hide();
}
function AbrirModal() {
    var modalPopup1 = $find(modal);
    limpiarGrid();
    modalPopup1.show();
}
function limpiarGrid() {
    txtFiltro.val("");
    //__doPostBack('btnBuscar', '');
    __doPostBack(updatepanel, '');
}
function mpeShow(valor) {
    HdTipo.val(valor);
    $get('htitulo').innerHTML = "Consulta de " + valor;
    AbrirModal();
}
function GetSelectedRow(lnk) {
    var row = lnk.parentNode.parentNode;
    GetSelectedRowC(row);
    return false;
}
function GetSelectedRowC(row) {
    var codigo = row.cells[0].innerHTML;
    var nombre = trim(row.cells[1].innerHTML);
    var tip = HdTipo.val();
    //alert("Tipo:" + tip + " Id: " + codigo + " Nombre:" + nombre);
    mostrarDatos(tip, codigo, nombre);
    CerrarModal();
    return true;
}
function trim(myString) {
    return myString.replace(/^\s+/g, '').replace(/\s+$/g, '');
}

function mostrarDatos(tip, codigo, nombre) {
    if (tip == "Contratistas") {
        TxtCtotista.val(nombre);
        TxtIdeCon.val(codigo);
    }
    else {
        TxtSupervisor.val(nombre);
        TxtIdeSup.val(codigo);

    }
}
       