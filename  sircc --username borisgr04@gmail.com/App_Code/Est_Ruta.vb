Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Est_Ruta
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByEstIni(ByVal EST_INI As String) As DataTable
        Me.Conectar()
        

        querystring = "SELECT EST_INI, EST_FIN, NOM_EST FROM RUTAESTADOS WHERE (EST_INI = :EST_INI)"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":EST_INI", EST_INI)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByCodCon(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        Dim dataTb As DataTable
        querystring = "SELECT Anticipo,Est_Con FROM Contratos WHERE Cod_Con = :Cod_Con"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dtCont As DataTable = Me.EjecutarConsultaDataTable()
        If dtCont.Rows.Count > 0 Then
            If dtCont.Rows(0)("Est_Con") = "09" Then 'Si esta legalizado
                'Preguntar si tiene anticipo
                If dtCont.Rows(0)("Anticipo") = 1 Then
                    querystring = "SELECT EST_INI, EST_FIN, NOM_EST FROM RUTAESTADOS WHERE (EST_INI = '09') AND EST_FIN='08'"
                Else
                    querystring = "SELECT EST_INI, EST_FIN, NOM_EST FROM RUTAESTADOS WHERE (EST_INI = '09') AND EST_FIN<>'08'"
                End If
                Me.CrearComando(querystring)
            Else
                querystring = "SELECT EST_INI, EST_FIN, NOM_EST FROM RUTAESTADOS WHERE (EST_INI In SELECT Est_Con FROM Contratos WHERE Cod_Con = :Cod_Con)"
                Me.CrearComando(querystring)
                AsignarParametroCadena(":Cod_Con", Cod_Con)
            End If
            dataTb = Me.EjecutarConsultaDataTable()
        Else
            dataTb = New DataTable
        End If

        Me.Desconectar()
        Return dataTb
    End Function



End Class
