Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class HRevisiones
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetHrev(ByVal Cod_Sol As String, Optional ByVal connect As Boolean = True) As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        'If connect Then
        Me.Conectar()
        'End If
        querystring = "SELECT * FROM vhrevisado where Cod_Sol=:Cod_Sol"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        'If connect Then
        Me.Desconectar()
        'End If

        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPk(ByVal Cod_Sol As String) As DataTable


        Me.Conectar()

        querystring = "SELECT * FROM VPSolicitudes where Cod_Sol=:Cod_Sol And dep_pSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo )"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)
        Me.AsignarParametroCadena(":ide_ter_abo", Me.usuario)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()


        Return dataTb

    End Function
End Class
