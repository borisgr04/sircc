Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class EdContratos
    Inherits BDDatos

    Dim mCC_ant As String = ""
    Dim mCC_sig As String = ""
    Dim mCod_Con As String
    Dim mFS_ant, mFS_sig As String
    Private _vigencia As String

    Sub New()

    End Sub

    Sub New(iCod_Con As String)
        Me.Cod_Con = iCod_Con
    End Sub
    Property Cod_Con As String
        Get
            Return mCod_Con
        End Get
        Set(value As String)
            mCod_Con = value
        End Set
    End Property
    Property CC_ant As String
        Get
            Return mCC_ant
        End Get
        Private Set(value As String)
            mCC_ant = value
        End Set
    End Property

    Property CC_Sig As String
        Get
            Return mCC_sig
        End Get
        Private Set(value As String)
            mCC_sig = value
        End Set
    End Property

    Property Fs_sig As String
        Get
            Return mFS_sig
        End Get
        Private Set(value As String)
            mFS_sig = value
        End Set
    End Property

    Property Fs_ant As String
        Get
            Return mFS_ant
        End Get
        Private Set(value As String)
            mFS_ant = value
        End Set
    End Property

    Private ReadOnly Property vigencia As String
        Get
            Return Left(Cod_Con, 4)
        End Get

    End Property

    Public Function GetContrato(Cod_Con As String) As DataTable
        querystring = "SELECT Fec_Sus_Con FROM Contratos Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Return dt
    End Function

    Private Sub UpdContrato(Fec_Sus_Con As Date)
        querystring = "Update Contratos Set Fec_Sus_Con=To_date(:Fec_Sus_Con,'dd/mm/yyyy')  Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Fec_Sus_Con", Fec_Sus_Con.ToShortDateString)
        AsignarParametroCadena(":Cod_Con", Cod_Con)
        num_reg = EjecutarComando()
    End Sub

    Public Function Mod_Fec_Sus_Con(Cod_Con As String, Fec_Sus_Con_New As Date) As String
        Dim vg As String = Left(Cod_Con, 4)
        If CInt(vg) <> Fec_Sus_Con_New.Year Then
            Msg = String.Format("La Fecha debe Pertener a la Vigencia del Contrato ", vg.ToString)
            lErrorG = True
            Return Msg
        End If
        Try
            Conectar()
            ComenzarTransaccion()
            If (cargarRefP(Fec_Sus_Con_New)) Then
                UpdContrato(Fec_Sus_Con_New)
                ConfirmarTransaccion()
                Msg = MsgOk
                lErrorG = False
            Else
                Throw New Exception(Me.Msg)
            End If
        Catch ex As Exception
            Msg = ex.Message + ex.StackTrace
            lErrorG = True
            CancelarTransaccion()
        Finally
            If Me.Conexion.State = ConnectionState.Open Then
                Desconectar()
            End If
        End Try
        Return Msg
    End Function
    Public Sub cargarRef(Fec_Sus_Con_New As Date)
        Conectar()
        cargarRefP(Fec_Sus_Con_New)
        Desconectar()
    End Sub


    Private Function cargarRefP(Fec_Sus_Con_New As Date) As Boolean
        NumeroRef()
        Dim dt As DataTable
        dt = GetContrato(CC_ant)
        If dt.Rows.Count > 0 Then
            Fs_ant = dt.Rows(0)("Fec_Sus_Con")
            If Fec_Sus_Con_New < Fs_ant Then
                Msg = String.Format("La Nueva Fecha no puede ser Inferior a la Fecha del Contrato Anterior {0} .", CDate(Fs_ant).ToShortDateString)
                Return False
            End If
        Else
            Fs_ant = "01/01/" + vigencia
        End If
        dt = GetContrato(CC_Sig)
        If dt.Rows.Count > 0 Then
            Fs_sig = dt.Rows(0)("Fec_Sus_Con")
            If Fec_Sus_Con_New > Fs_sig Then
                Msg = (String.Format("La Nueva Fecha no puede ser Superior a la Fecha del Siguiente Contrato  {0} .", CDate(Fs_sig).ToShortDateString))
                Return False
            End If
        Else
            Fs_sig = "31/12/" + vigencia
        End If
        Return True
    End Function

    Sub NumeroRef()
        Dim Nro As Integer = Right(Cod_Con, 4)
        CC_ant = Left(Cod_Con, 6) + (Nro - 1).ToString.PadLeft(4, "0")
        CC_Sig = Left(Cod_Con, 6) + (Nro + 1).ToString.PadLeft(4, "0")
    End Sub
End Class
