Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class CMinutas
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "CMinutas"
        Me.Vista = "CMinutas"
        'SELECT "COD_DEP", "NOM_DEP" FROM sircc.vdepdel ORDER BY "NOM_DEP"
        'SELECT "COD_DEP", "NOM_DEP" FROM "DEPENDENCIA" ORDER BY "NOM_DEP"

    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        querystring = "SELECT * FROM  " + Vista
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByPk(ByVal Pk1 As String) As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista + " WHERE cmin_Codi=:cmin_Codi"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":cmin_Codi", Pk1)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Codi As String) As DataTable
        Me.Conectar()
        Me.CrearComando("SELECT * FROM CMINUTAS WHERE CMIN_CODI=:CMIN_CODI")
        Me.AsignarParametroCadena(":CMIN_CODI", Codi)
        Dim dataTb As DataTable = New DataTable
        dataTb = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
   Public Function GetByCampo(ByVal Pk1 As String) As DataTable
        Dim queryString As String = "SELECT * FROM  Campos_Minuta WHERE Cod_Minuta=:Cod_Minuta"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Cod_Minuta", Pk1)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function UpdateMinuta(ByVal Codi As String, ByVal Body As String) As String
        Dim nr As Integer
        Me.Conectar()
        Try

            Body = Body.Replace("�", "&aacute;")
            Body = Body.Replace("�", "&eacute;")
            Body = Body.Replace("�", "&iacute;")
            Body = Body.Replace("�", "&oacute;")
            Body = Body.Replace("�", "&uacute;")

            Body = Body.Replace("�", "&Aacute;")
            Body = Body.Replace("�", "&Eacute;")
            Body = Body.Replace("�", "&Iacute;")
            Body = Body.Replace("�", "&Oacute;")
            Body = Body.Replace("�", "&Uacute;")


            Me.CrearComando("UPDATE CMINUTAS SET CMIN_BODY=:CMIN_BODY WHERE CMIN_CODI=:CMIN_CODI")
            Me.AsignarParametroCadena(":CMIN_CODI", Codi)
            Me.AsignarParametroCLOB("CMIN_BODY", Body)
            nr = Me.EjecutarComando()
            Me.lErrorG = False
            Msg = MsgOk
        Catch ex As Exception
            Me.lErrorG = True
            Msg = ex.Message
        End Try
        Me.Desconectar()
        Return Msg
    End Function

    Public Function Conver_HTML(ByVal txt As String) As String

        'Vocales Minusculas tildes
        txt = txt.Replace("�", "&aacute;")
        txt = txt.Replace("�", "&eacute;")
        txt = txt.Replace("�", "&iacute;")
        txt = txt.Replace("�", "&oacute;")
        txt = txt.Replace("�", "&uacute;")
        'Vocales Mayusculas tildes
        txt = txt.Replace("�", "&Aacute;")
        txt = txt.Replace("�", "&Eacute;")
        txt = txt.Replace("�", "&Iacute;")
        txt = txt.Replace("�", "&Oacute;")
        txt = txt.Replace("�", "&Uacute;")

        Return txt
    End Function

End Class



