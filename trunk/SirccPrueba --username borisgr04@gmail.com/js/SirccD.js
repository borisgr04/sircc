function AbrirSirccD(parametros, url) {
    var filename = "C:\\SirccD\\SirccD.exe";
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    if (fso.FileExists(filename)) {
        var oShell = new ActiveXObject("Shell.Application");
        var commandtoRun = filename;
        var commandParms = parametros;
        var rShell = oShell.ShellExecute(commandtoRun, commandParms, "", "open", "1");
        alert("Presione aceptar después que se halla generado el Documento, para actualizar la página");
        location.reload();
    }
    else {
        if (confirm("El Componente que permite la edición de la Minuta no esta instalado, Desea Instalarlo.")) {
            window.open(url);
            alert("Después de Instalado, intente de nuevo la operación ");
                
        }
    }

}