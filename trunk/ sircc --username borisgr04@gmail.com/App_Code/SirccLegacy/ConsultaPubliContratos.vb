Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Public Class ConsultaPubliContratos
    Inherits BDDatos
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetContratos(ByVal Filtro As String) As DataTable
        Me.Conectar()
        ''solo muestra cuando no esta radicado
        Me.querystring = "SELECT c.*,Cant_Adicion(c.numero) nro_adi,Plazo_Adicion(c.numero) Pla_Adi,Valor_Adicion(c.numero) Val_Adi FROM vcontratos_Sinc_p c where " + Filtro + " And Est_Con <>'00' ORDER BY numero"
        CrearComando(querystring)
        'Throw New Exception(vComando.CommandText)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function

    Public Function GetId_Minuta(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT Id FROM Doc_Contratos Where Tip_Doc=:Doc_Minuta And Cod_Con=:Cod_Con"
        CrearComando(querystring)
        AsignarParametroCadena(":Doc_Minuta", Publico.Doc_Minuta)
        AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function

End Class
