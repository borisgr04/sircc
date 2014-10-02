Imports Microsoft.VisualBasic

Public Class DocPContratosDAO
    Implements IMsg

    Dim _Msg As String
    Dim _lErrorG As Boolean

    Dim querystring As String
    Dim num_reg As Integer
    Public Property lErrorG As Boolean Implements IMsg.lErrorG
        Get
            Return _lErrorG
        End Get
        Set(value As Boolean)
            _lErrorG = value
        End Set
    End Property

    Public Property Msg As String Implements IMsg.Msg
        Get
            Return _Msg
        End Get
        Set(value As String)
            _Msg = value
        End Set
    End Property

    Private db As New BDDatosG

    Public Function Insert(doc As EDocumentoWPDto) As String
        Try
            db.Conectar()
            db.ComenzarTransaccion()
            Dim querystring As String

            querystring = "Insert Into DOCPCONTRATOS(MINUTA,NUM_PROC,MINUTABASE,MINUTAPDF,TIPDOCUMENTO, EDITABLE, NOMBRE,FEC_DOC)Values(:MINUTA,:NUM_PROC,:MINUTABASE,:MINUTAPDF,:TIPDOCUMENTO,:EDITABLE, :NOMBRE,:FEC_DOC)"
            'querystring = "Insert Into DOCPCONTRATOS(MINUTA,NUM_PROC,MINUTABASE,TIPDOCUMENTO, EDITABLE, NOMBRE,FEC_DOC)Values(:MINUTA,:NUM_PROC,:MINUTABASE,:TIPDOCUMENTO,:EDITABLE, :NOMBRE,:FEC_DOC)"
            db.CrearComando(querystring)
            db.AsignarParametroCadena(":NUM_PROC", doc.Num_Proc)
            db.AsignarParametroBLOB("MINUTA", doc.Minuta)
            db.AsignarParametroBLOB("MINUTABASE", doc.MinutaBase)
            db.AsignarParametroBLOB("MINUTAPDF", doc.MinutaPDF)
            db.AsignarParametroCadena(":TIPDOCUMENTO", doc.TipDocumento)
            db.AsignarParametroCadena(":EDITABLE", doc.Editable)
            db.AsignarParametroCadena(":NOMBRE", doc.Nombre)
            db.AsignarParametroFecha(":FEC_DOC", doc.Fec_Doc)

            Dim num_reg As Integer = db.EjecutarComando()
            db.ConfirmarTransaccion()
            Msg = "Se guardó el Registro " + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            db.CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message
        Finally
            db.Desconectar()
        End Try
        Return Msg
    End Function


    Public Function UpdateMinuta(doc As EDocumentoWPDto) As String

        db.Conectar()
        db.ComenzarTransaccion()
        Try
            querystring = "UPDATE DOCPCONTRATOS SET Minuta=:Minuta,MinutaPDF=:MinutaPDF WHERE ID=:Ide_pla And NUM_PROC=:NUM_PROC"
            db.CrearComando(querystring)
            db.AsignarParametroBLOB(":Minuta", doc.Minuta)
            db.AsignarParametroBLOB(":MinutaPDF", doc.MinutaPDF)
            db.AsignarParametroCadena(":NUM_PROC", doc.Num_Proc)
            db.AsignarParametroCad(":Ide_pla", doc.Id)

            num_reg = db.EjecutarComando()
            db.ConfirmarTransaccion()
            Msg = "Se realizó la operación " + num_reg.ToString + " - Fila. Tamaño del Archivo: " & FormatNumber(doc.Minuta.Length / 1024).ToString & " kb - "
            Me.lErrorG = False
        Catch ex As Exception
            db.CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function


End Class


