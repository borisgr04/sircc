Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Public Class DocPContratos
    Inherits BDDatos
    Sub New()
        Me.Vista = "VDOCPCONTRATOS"
        Me.Tabla = "DOCPCONTRATOS"
    End Sub

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

    Public Function Insert(ByVal NUM_PROC As String, ByVal MINUTA As Byte(), ByVal MINUTABASE As Byte(), ByVal TIPDOCUMENTO As String, ByVal EDITABLE As String, ByVal NOMBRE As String) As String
        Try
            Conectar()
            ComenzarTransaccion()
            querystring = "Insert Into DOCPCONTRATOS(MINUTA,NUM_PROC,MINUTABASE,TIPDOCUMENTO, EDITABLE, NOMBRE)Values(:MINUTA,:NUM_PROC,:MINUTABASE,:TIPDOCUMENTO,:EDITABLE, :NOMBRE)"
            CrearComando(querystring)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroBLOB("MINUTA", MINUTA)
            AsignarParametroBLOB("MINUTABASE", MINUTABASE)
            AsignarParametroCadena(":TIPDOCUMENTO", TIPDOCUMENTO)
            AsignarParametroCadena(":EDITABLE", EDITABLE)
            AsignarParametroCadena(":NOMBRE", NOMBRE)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = "Se guardo el Registro " + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try
        Return Msg
    End Function

    Public Function Insert(ByVal NUM_PROC As String, ByVal MINUTA As Byte(), ByVal MINUTABASE As Byte(), ByVal TIPDOCUMENTO As String, ByVal EDITABLE As String, ByVal NOMBRE As String, ByVal FEC_DOC As Date) As String
        Try
            Conectar()
            ComenzarTransaccion()
            querystring = "Insert Into DOCPCONTRATOS(MINUTA,NUM_PROC,MINUTABASE,TIPDOCUMENTO, EDITABLE, NOMBRE,FEC_DOC)Values(:MINUTA,:NUM_PROC,:MINUTABASE,:TIPDOCUMENTO,:EDITABLE, :NOMBRE,:FEC_DOC)"
            CrearComando(querystring)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroBLOB("MINUTA", MINUTA)
            AsignarParametroBLOB("MINUTABASE", MINUTABASE)
            AsignarParametroCadena(":TIPDOCUMENTO", TIPDOCUMENTO)
            AsignarParametroCadena(":EDITABLE", EDITABLE)
            AsignarParametroCadena(":NOMBRE", NOMBRE)
            AsignarParametroFecha(":FEC_DOC", FEC_DOC)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = "Se guardo el Registro " + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try
        Return Msg
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

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDocumento(ByVal NUM_PROC As String, ByVal ID As Integer) As Byte()
        Me.Conectar()
        querystring = "SELECT * FROM DOCPCONTRATOS Where NUM_PROC=:NUM_PROC And ID =:ID"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        AsignarParametroEntero(":ID", ID)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Dim Minuta As Byte() = DirectCast(dataTb.Rows(0)("Minuta"), Byte())
        Me.Desconectar()
        Return Minuta
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDocBase(ByVal NUM_PROC As String, ByVal ID As Integer) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM DOCPCONTRATOS Where NUM_PROC=:NUM_PROC And ID =:ID"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        AsignarParametroEntero(":ID", ID)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function Update(ByVal NUM_PROC As String, ByVal ID As Integer, ByVal dContent As [Byte]()) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE DOCPCONTRATOS SET MinutaBase=:PLANTILLA WHERE ID=:Ide_pla And NUM_PROC=:NUM_PROC"
            CrearComando(querystring)
            AsignarParametroBLOB(":PLANTILLA", dContent)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroCad(":Ide_pla", ID)
            num_reg = EjecutarComando()
            'Throw New Exception(Me.vComando.CommandText)
            ConfirmarTransaccion()
            Msg = MsgOk + " " + num_reg.ToString + " - Fila. Tamaño del Archivo: " & FormatNumber(dContent.Length / 1024).ToString & " kb - "
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function

    Public Function UpdateDoc(ByVal NUM_PROC As String, ByVal ID As Integer, ByVal dContent As [Byte]()) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE DOCPCONTRATOS SET Minuta=:PLANTILLA WHERE ID=:Ide_pla And NUM_PROC=:NUM_PROC"
            CrearComando(querystring)
            AsignarParametroBLOB(":PLANTILLA", dContent)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroCad(":Ide_pla", ID)
            num_reg = EjecutarComando()
            'Throw New Exception(Me.vComando.CommandText)
            ConfirmarTransaccion()
            Msg = MsgOk + " " + num_reg.ToString + " - Fila. Tamaño del Archivo: " & FormatNumber(dContent.Length / 1024).ToString & " kb - "
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function

    Public Function Regenerar(ByVal NUM_PROC As String, ByVal ID As Integer, ByVal dContent As [Byte]()) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE DOCPCONTRATOS SET Minuta=:PLANTILLA WHERE ID=:Ide_pla And NUM_PROC=:NUM_PROC"
            CrearComando(querystring)
            AsignarParametroBLOB(":PLANTILLA", dContent)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroCad(":Ide_pla", ID)
            num_reg = EjecutarComando()
            'Throw New Exception(Me.vComando.CommandText)
            ConfirmarTransaccion()
            Msg = MsgOk + "Tamaño del Archivo: " & FormatNumber(dContent.Length / 1024).ToString & " kb - "
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetExitsAC(ByVal NUM_PROC As String, ByVal TipoDocumento As String) As Boolean
        Me.Conectar()
        querystring = "SELECT Nvl(Count(*),0) Cant FROM " + Vista + " Where NUM_PROC=:NUM_PROC And Estado='AC' And TipDocumento=:TipoDocumento"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        AsignarParametroCadena(":TipoDocumento", TipoDocumento)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()

        Return IIf(dataTb.Rows(0)("Cant") > 0, True, False)

    End Function
    Public Function Anular(ByVal NUM_PROC As String, ByVal ID As Integer) As String
        Try
            Conectar()
            ComenzarTransaccion()
            querystring = "Update DOCPCONTRATOS Set Estado='AN' Where NUM_PROC=:NUM_PROC And ID=:ID"
            CrearComando(querystring)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroEntero(":ID", ID)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = MsgOk + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function

    Public Function Update(ByVal NUM_PROC As String, ByVal ID As Integer, ByVal Nombre As String, ByVal Fec_Doc As String) As String
        Try
            Conectar()
            ComenzarTransaccion()
            querystring = "Update DOCPCONTRATOS Set Fec_Doc=:Fec_Doc,Nombre=:Nombre Where NUM_PROC=:NUM_PROC And ID=:ID"
            CrearComando(querystring)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroEntero(":ID", ID)
            AsignarParametroCadena(":Nombre", Nombre)
            AsignarParametroFecha(":Fec_Doc", Fec_Doc)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = MsgOk + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPG(ByVal NUM_PROC As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Vista + " Where NUM_PROC=:NUM_PROC"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPlantillas(ByVal Tip_Doc As String) As DataTable
        Me.Conectar()
        If (Tip_Doc = "00") Or (String.IsNullOrEmpty(Tip_Doc)) Then
            querystring = "Select * From PPlantillas Where Tip_Pla='02' " 'And Cod_Stip='00'
            Me.CrearComando(querystring)
        Else
            querystring = "Select * From PPlantillas Where Tip_Pla='02' And (Cod_Stip=:Tip_Doc or Cod_Stip='00')"
            Me.CrearComando(querystring)
            AsignarParametroCadena(":Tip_Doc", Left(Tip_Doc, 2))
        End If

        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetDocs2(ByVal NUM_PROC As String) As DataTable
        Me.Conectar()

        querystring = "SELECT dc.num_proc, dc.ID, dc.fec_doc, dc.tipdocumento,"
        querystring += "dc.nombre,"
        querystring += " dc.fec_reg "
        querystring += " FROM docpcontratos dc LEFT JOIN vtip_doc td ON td.cod_tip = dc.tipdocumento  Where estado='AC' and NUM_PROC=:NUM_PROC"

        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

End Class
