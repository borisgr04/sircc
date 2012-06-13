Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<DataObject()> _
Public Class UsuDel 
    Inherits Usuarios
    Enum eAccion
        Nada
        Agregar
        Actualizar
        Eliminar
    End Enum
    Private Accionvalue As String
    <DataObjectField(True, True)> _
    Public Property Accion() As eAccion
        Get
            Return Accionvalue
        End Get
        Set(ByVal value As eAccion)
            Accionvalue = value
        End Set
    End Property

    Private Id_HdepValue As String
    <DataObjectField(True, True)> _
    Public Property Id_Hdep() As String
        Get
            Return Id_HdepValue
        End Get
        Set(ByVal value As String)
            Id_HdepValue = value
        End Set
    End Property

    Private CoordValue As String
    <DataObjectField(True, True)> _
    Public Property Coord() As String
        Get
            Return CoordValue
        End Get
        Set(ByVal value As String)
            CoordValue = value
        End Set
    End Property

    Private NomDepValue As String
    <DataObjectField(True, True)> _
    Public Property NomDep() As String
        Get
            Return NomDepValue
        End Get
        Set(ByVal value As String)
            NomDepValue = value
        End Set
    End Property

    Private AsigProcValue As String
    <DataObjectField(True, True)> _
    Public Property AsigProc() As String
        Get
            Return AsigProcValue
        End Get
        Set(ByVal value As String)
            AsigProcValue = value
        End Set
    End Property

    Private IdeTerValue As String
    <DataObjectField(True, True)> _
    Public Property IdeTer() As String
        Get
            Return IdeTerValue
        End Get
        Set(ByVal value As String)
            IdeTerValue = value
        End Set
    End Property

    Private CodDepValue As String
    <DataObjectField(True, True)> _
    Public Property Cod_Dep() As String
        Get
            Return CodDepValue
        End Get
        Set(ByVal value As String)
            CodDepValue = value
        End Set
    End Property

    Private EstadoValue As String
    <DataObjectField(False, False)> _
    Public Property Estado() As String
        Get
            Return EstadoValue
        End Get
        Set(ByVal value As String)
            EstadoValue = value
        End Set
    End Property


    ''' <summary>
    ''' Consulta de las dependencias y resalta las asignadas al usuario especifico
    ''' </summary>
    ''' <param name="IDE_TER"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDepDel(ByVal IDE_TER As String) As DataTable
        Conectar()
        querystring = "SELECT dd.cod_dep, nom_dep, norma_del, (CASE WHEN (Nvl(da.estado,'IN') = 'IN') THEN '0' ELSE '1' END )  EST,  Nvl(asig_proc,'NO') asig_proc,Nvl(coordinador,'NO') coordinador,nvl(id_hdep,0) id_hdep,Nvl(da.estado,'IN') estado FROM vdepdel dd left join hdep_abogados da on dd.cod_dep=da.cod_dep and da.ide_ter=:IDE_TER Order by Cod_dep"
        CrearComando(querystring)
        AsignarParametroCadena(":IDE_TER", IDE_TER)
        Dim datatb As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        Return datatb
    End Function

    ''' <summary>
    ''' Consulta de las dependencias y resalta las asignadas al usuario especifico
    ''' </summary>
    ''' <param name="IDE_TER"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function InsertDel(ByVal ide_ter As String, ByVal lud As List(Of UsuDel)) As String
        Dim objD As New Dependencias
        lErrorG = True
        Msg = ""
        objD.Conectar()
        For Each u In lud
            Select Case u.Accion
                Case eAccion.Agregar
                    Msg += objD.AsignarAbogado(u.Cod_Dep, u.IdeTer, u.AsigProc, u.Coord, False) + " Asignó Dependencia " + u.NomDep + "<br>"
                Case eAccion.Actualizar
                    Msg += objD.Update(u.Id_Hdep, u.AsigProc, u.Coord, False) + " Actualizó Dependencia " + u.NomDep + "<br>"
                Case eAccion.Eliminar
                    Msg += objD.DAsignarAbogado(u.Id_Hdep, False) + " Se desasignó " + u.NomDep + "</br>"
            End Select
        Next
        objD.Desconectar()
        Return Msg
    End Function

End Class

