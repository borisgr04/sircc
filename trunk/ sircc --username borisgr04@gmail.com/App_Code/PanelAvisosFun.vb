Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class PanelAvisosFun
    Inherits PContratos
    ''' <summary>
    ''' Procesos para el Usuario Actual
    ''' </summary>
    ''' <returns>Tabla Estado, Cantidad </returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetMisProcesos() As DataTable
        Me.Conectar()
        querystring = "Select nom_est Estado,count(*) Cantidad from vpcontratos where Final='NO' And usuencargado=:usuencargado group by nom_est Order by Count(*)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuencargado", Me.usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' COnsulta de Estado para el Usuario Actual en el estado correpondienes
    ''' </summary>
    ''' <param name="Nom_Est"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMisProcbyEstado(ByVal Nom_Est As String) As DataTable
        querystring = "SELECT * FROM " + Vista + " Where Final='NO' And Nom_Est=:Nom_Est And usuencargado=:usuencargado"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":usuencargado", Me.usuario)
        Me.AsignarParametroCadena(":Nom_Est", Nom_Est)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

End Class
