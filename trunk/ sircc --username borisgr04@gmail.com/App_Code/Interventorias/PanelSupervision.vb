Imports Microsoft.VisualBasic
Imports System.Data.Common
Imports System.ComponentModel
Imports System.Data


Public Class PanelSupervision
    Inherits BDDatos

    Sub New()
        Me.Tabla = ""
        Me.Vista = "" ' where estado="AC"
        Me.VistaDB = "" ' sin filtro
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal ide_int As String, ByVal vigencia As String) As DataTable
        Me.Conectar()

        querystring = "Select Numero,Contratista,Obj_Con,tipo, nom_stip,Fec_Sus_Con, Plazo_texto,Valor_Total_Doc,Estado,Val_Adi, Acta_Actual,Val_Con,Est_Con From vContratos_sinc_p"
        querystring += " Where  Numero In (Select Cod_Con from INTERVENTORES_CONTRATO where ide_int=:ide_int and Cod_Con like :VIGENCIA And Est_int='AC')"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ide_int", ide_int)
        Me.AsignarParametroCadena(":VIGENCIA", vigencia + "%")
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Filtro As String, ByVal ide_int As String, ByVal vigencia As String) As DataTable
        Me.Conectar()

        querystring = "Select Numero,Contratista,Obj_Con,tipo, nom_stip,Fec_Sus_Con, Plazo_texto,Valor_Total_Doc,Estado,Val_Adi, Acta_Actual,Val_Con,Est_Con From vContratos_sinc_p"
        querystring += " Where (Upper(Obj_Con) like :filtro OR Numero Like :filtro OR Contratista Like :filtro) And  Numero In (Select Cod_Con from INTERVENTORES_CONTRATO where ide_int=:ide_int and Cod_Con like :VIGENCIA And Est_int='AC')"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ide_int", ide_int)
        Me.AsignarParametroCadena(":filtro", "%" + UCase(Filtro) + "%")
        Me.AsignarParametroCadena(":filtro", "%" + UCase(Filtro) + "%")
        Me.AsignarParametroCadena(":filtro", "%" + UCase(Filtro) + "%")
        Me.AsignarParametroCadena(":VIGENCIA", vigencia + "%")
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
End Class
