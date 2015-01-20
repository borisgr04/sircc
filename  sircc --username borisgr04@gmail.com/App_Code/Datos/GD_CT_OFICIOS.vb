Imports Microsoft.VisualBasic
Imports System.Data

Public Class GD_CT_OFICIOS_DTO
    Public ID As Integer
    Public FEC_OFI As Date
    Public COD_CON As String
    Public TIP_OFI As String
    Public EST_OFI As String
End Class

Public Class GD_CT_OFICIOS

    Private ctx As New BDDatosG
    Dim querystring As String
    Dim num_reg As Long

    ReadOnly Property lError As Boolean
        Get
            Return ctx.lErrorG
        End Get
    End Property
    Public Function Insert(dto As GD_CT_OFICIOS_DTO) As String

        ctx.Conectar()
        Try
            ctx.ComenzarTransaccion()

            Dim querystring As String = "select Max(ID) ID From GD_CT_OFICIOS"
            ctx.CrearComando(querystring)
            Try
                dto.ID = Convert.ToInt32(ctx.EjecutarEscalar()) + 1
            Catch ex As Exception
                dto.ID = 1
            End Try

            querystring = "INSERT INTO GD_CT_OFICIOS(ID, FEC_OFI, COD_CON,TIP_OFI,EST_OFI)VALUES(:ID, Sysdate, :COD_CON,:TIP_OFI,'AC') "
            ctx.CrearComando(querystring)
            ctx.AsignarParametroCadena(":ID", dto.ID)
            ctx.AsignarParametroCadena(":COD_CON", dto.COD_CON)
            ctx.AsignarParametroCadena(":TIP_OFI", dto.TIP_OFI)
            num_reg = ctx.EjecutarComando()
            ctx.ConfirmarTransaccion()
            ctx.Msg = "Se realizó la operación Satisfactoriamente - Filas Afectadas [" + Me.num_reg.ToString + "]"
            ctx.lErrorG = False
        Catch ex As Exception
            ctx.Msg = "Error:" + ex.Message
            ctx.CancelarTransaccion()
            ctx.lErrorG = True
        Finally
            ctx.Desconectar()
        End Try
        Return ctx.Msg
    End Function
End Class
