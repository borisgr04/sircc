Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class AvisosAct
    Inherits PContratos


    ''' <summary>
    ''' Procesos para el Usuario Actual
    ''' </summary>
    ''' <returns>Tabla Estado, Cantidad </returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetMisProcesos(vigencia As String) As DataTable
        Me.Conectar()
        querystring = "Select nom_est Estado,count(*) Cantidad from vpcontratos where Vig_Con=:Vig_Con And usuencargado=:usuencargado group by nom_est Order by Count(*)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuencargado", Me.usuario)
        Me.AsignarParametroCadena(":Vig_Con", vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Get Procesos Asignados a Terceros
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxUsuario(ByVal Vigencia As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * From vPContratos2 Where UsuEncargado=:UsuEncargado And Vig_Con=:Vig_Con Order by fec_reg "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":UsuEncargado", usuario)
        Me.AsignarParametroCadena(":Vig_Con", Vigencia)
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
    Public Function GetMisProcbyEstado(ByVal Nom_Est As String, Vigencia As String) As DataTable
        Me.Conectar()
        If String.IsNullOrEmpty(Nom_Est) Then
            Dim queryString As String = "SELECT * FROM " + Vista + " Where Vig_Con=:Vig_Con And usuencargado=:usuencargado"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":usuencargado", Me.usuario)
            Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        Else
            Dim queryString As String = "SELECT * FROM " + Vista + " Where Vig_Con=:Vig_Con And Nom_Est=:Nom_Est And usuencargado=:usuencargado"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":usuencargado", Me.usuario)
            Me.AsignarParametroCadena(":Vig_Con", Vigencia)
            Me.AsignarParametroCadena(":Nom_Est", Nom_Est)
        End If
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

End Class
