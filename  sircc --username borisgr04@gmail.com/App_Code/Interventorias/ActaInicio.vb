Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data.Common
Imports System.Data


Public Class ActaInicio
    Inherits ActasSupervision


    Public Sub New()
        Est_Fin = "01"
    End Sub

    Dim mFec_Fin As Date
    Property Fec_Fin As Date
        Get
            Return mFec_Fin
        End Get
        Set(ByVal value As Date)
            mFec_Fin = value
        End Set
    End Property

    ''' <summary>
    ''' Inicializar Minimo, Cod_Con, Est_ini, Fec_Ent, Obs
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Insert() As String
        Conectar()
        ComenzarTransaccion()
        ' VALIDACION DE FECHA DE SUSCRIPCION
        If IsValido() Then
            'Try
            querystring = "INSERT INTO EstContratos (cod_con,est_ini,est_fin,fec_ent,usuario,fec_reg,obs_est,val_pago,nvisitas,por_eje_fis,estado,fec_fin) "
            querystring += " Values(:cod_con,:est_ini,:est_fin,to_date(:fec_ent,'dd/mm/yyyy'),user,sysdate,:obs_est,:val_pago,to_number(:nvisitas),:por_eje_fis,:estado,to_date(:fec_fin,'dd/mm/yyyy')) "
            CrearComando(querystring)
            AsignarParametroCadena(":cod_con", Cod_Con)
            AsignarParametroCadena(":est_ini", Est_Ini)
            AsignarParametroCadena(":est_fin", Est_Fin)
            AsignarParametroCadena(":fec_ent", Fec_Ent)
            AsignarParametroCadena(":obs_est", Obs)
            AsignarParametroDecimal(":val_pago", 0)
            AsignarParametroCadena(":nvisitas", 0)
            AsignarParametroCadena(":estado", "BO")
            AsignarParametroDecimal(":por_eje_fis", 0)
            AsignarParametroCadena(":fec_fin", Fec_Fin)
            num_reg = EjecutarComando()

            ConfirmarTransaccion()
            Msg = MsgOk
            Me.lErrorG = False
            'Catch ex As Exception
            '    CancelarTransaccion()
            '    Msg = ex.Message
            '    Me.lErrorG = True
            'Finally
            Desconectar()
            'End Try
        End If
        Return Msg


    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Overloads Function Update(ByVal ID As String, ByVal fec_ent As Date, ByVal Obs As String, ByVal fec_fin As Date) As String
        Try
            Me.Conectar()
            Me.ComenzarTransaccion()
            querystring = "UPDATE EstContratos SET fec_fin=to_date(:fec_fin,'dd/mm/yyyy'),fec_ent=to_date(:fec_ent,'dd/mm/yyyy'),obs_est=:obs_est,val_pago=:val_pago,nvisitas=to_number(:nvisitas),por_eje_fis=:por_eje_fis WHERE ID=:ID"
            CrearComando(querystring)
            AsignarParametroCadena(":ID", ID)
            AsignarParametroCadena(":fec_ent", fec_ent)
            AsignarParametroCadena(":obs_est", Obs)
            AsignarParametroCadena(":fec_fin", fec_fin)
            AsignarParametroDecimal(":val_pago", 0)
            AsignarParametroCadena(":nvisitas", 0)
            AsignarParametroDecimal(":por_eje_fis", 0)
            num_reg = EjecutarComando()
            Msg = "Se Actualizo el registro del Acta/Documento  ID [" + ID + "]"
            Me.ConfirmarTransaccion()
            Msg = MsgOk + "<br>" + Msg
            lErrorG = False
        Catch ex As Exception
            Me.CancelarTransaccion()
            Msg = ex.Message
            lErrorG = True
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function



End Class


