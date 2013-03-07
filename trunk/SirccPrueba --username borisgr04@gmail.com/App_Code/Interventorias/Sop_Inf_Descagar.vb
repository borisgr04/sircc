Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports Ionic.Zip

Public Class Sop_Inf_Descagar
    Inherits BDDatos

    Private Ruta_Zip As String = Publico.Ruta_Doc
    Private vRuta_Zip As String = Publico.vRuta_Doc

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSoporte(ByVal Cod_Con As String, Num_Inf As String, Id As String) As ArchivosT
        Dim Arc As New ArchivosT
        Try
            Me.Conectar()
            querystring = "SELECT * FROM Int_InCo_Sop Where Cod_Con =:Cod_Con And Num_Inf =:Num_Inf And Sop_Est='AC' And Id =:ID "
            Me.CrearComando(querystring)
            AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroCadena(":Num_Inf", Num_Inf)
            Me.AsignarParametroCadena(":ID", Id)
            Dim dataTb As DataTable = EjecutarConsultaDataTable()
            If dataTb.Rows.Count > 0 Then
                Arc.SoporteB = DirectCast(dataTb.Rows(0)("Soporte"), Byte())
                Arc.NomArchivo = dataTb.Rows(0)("NomArc")
                Arc.Content = dataTb.Rows(0)("Content")
            End If
            lErrorG = False
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Arc
    End Function

    Public Function GetSoportes(ByVal cod_con As String, Num_Inf As String) As List(Of ArchivosT)
        Dim ByteZip() As Byte = {}

        'Establish the database connection
        Conectar()
        'define the sql to perform the database insert
        querystring = "SELECT * FROM Int_InCo_Sop Where Cod_Con =:Cod_Con And Num_Inf =:Num_Inf And Sop_Est='AC' "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Con", cod_con)
        Me.AsignarParametroCadena(":Num_Inf", Num_Inf)
        'Execute the SQL Statement
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Dim lstArc As New List(Of ArchivosT)
        For Each row In dataTb.Rows
            Dim Arc As New ArchivosT
            Arc.SoporteB = DirectCast(row("Soporte"), Byte())
            Arc.NomArchivo = row("NomArc")
            Arc.Content = row("Content")
            lstArc.Add(Arc)
        Next
        Return lstArc
    End Function

    Function GenZip(ByVal cod_con As String, Num_Inf As String) As ArchivosT
        Dim a As New ArchivosT
        a = GenerarZip.Generar_Zip_Byte(cod_con + "-" + Num_Inf, GetSoportes(cod_con, Num_Inf))
        Me.Msg = GenerarZip.msg
        Return a
    End Function

    Public Function Generar_Zip_Byte(ByVal cod_con As String, Num_Inf As String) As Byte()
        Dim ByteZip() As Byte = {}
        Try
            'Establish the database connection
            Conectar()
            'define the sql to perform the database insert
            querystring = "SELECT * FROM Int_InCo_Sop Where Cod_Con =:Cod_Con And Num_Inf =:Num_Inf And Sop_Est='AC' And Id =:ID "
            Me.CrearComando(querystring)
            AsignarParametroCadena(":Cod_Con", cod_con)
            Me.AsignarParametroCadena(":Num_Inf", Num_Inf)

            'Execute the SQL Statement
            Dim dt As DataTable = EjecutarConsultaDataTable()
            Dim RutaC As String = Me.Ruta_Zip + cod_con.Trim + "Inf" + Num_Inf.Trim + ".zip"
            Dim vRutaC As String = vRuta_Zip + cod_con.Trim + "Inf" + Num_Inf.Trim + ".zip"
            If File.Exists(RutaC) Then
                File.Delete(RutaC)
            End If
            Dim zip As New ZipFile()
            Dim i As Integer = 0
            For rg As Integer = 0 To dt.Rows.Count - 1
                i = i + 1
                Dim b() As Byte = DirectCast(dt.Rows(rg)("soporte"), Byte())
                zip.AddEntry(dt.Rows(rg)("NomArc"), b)
            Next
            zip.Comment = "Export De la base de datos SIRCC"
            Dim ms As New MemoryStream
            zip.Save(ms)
            ByteZip = ms.ToArray()
            Msg = "Se Generó El Paquete Comprimido (*.Zip) <br> <a href='" + vRutaC + "'  > Click Para Descargar</a> Generado a las: " + Now.ToString
            lErrorG = False
        Catch ex As Ionic.Zip.ZipException
            Msg = "zip:" + ex.Message
            lErrorG = True
        Catch ex As Exception
            Msg = "Ex:" + ex.Message
            lErrorG = True

        Finally
            'Close the database connection
            Desconectar()
        End Try

        Return ByteZip
    End Function


End Class
