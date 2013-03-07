Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class Con_Documentos
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Id As String) As DataTable
        querystring = "SELECT * FROM  vdocpcontratostd Where Id=:Id"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Id", Id)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDocs(ByVal NUM_PROC As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vdocpcontratostd Where NUM_PROC=:NUM_PROC "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetSoportes(ByVal NUM_PROC As String) As List(Of ArchivosT)
        Dim ByteZip() As Byte = {}

        'Establish the database connection
        Conectar()
        'define the sql to perform the database insert
        querystring = "SELECT * FROM vdocpcontratostd Where NUM_PROC=:NUM_PROC "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        'Execute the SQL Statement
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Dim lstArc As New List(Of ArchivosT)
        For Each row In dataTb.Rows
            Dim Arc As New ArchivosT
            Arc.SoporteB = DirectCast(row("Minuta"), Byte())
            Arc.NomArchivo = row("Nombre") + ".doc"
            'Arc.Content = row("Content")
            lstArc.Add(Arc)
        Next
        Return lstArc
    End Function

    Function GenZip(ByVal Num_Proc As String) As ArchivosT
        Dim a As New ArchivosT
        a = GenerarZip.Generar_Zip_Byte(Num_Proc, GetSoportes(Num_Proc))
        Me.Msg = GenerarZip.Msg
        Return a
    End Function
End Class
