Imports Microsoft.VisualBasic
Imports System.ComponentModel

Public Class ActasParciales
    Inherits ActasSupervision

    Private _fec_act As Date?

    Public Sub New()
        Est_Fin = "02"
    End Sub

    Dim mFec_PFin As Date
    Property Fec_PFin As Date
        Get
            Return mFec_PFin
        End Get
        Set(ByVal value As Date)
            mFec_PFin = value
        End Set
    End Property
    Dim mFec_PIni As Date
    Property Fec_PIni As Date
        Get
            Return mFec_PIni
        End Get
        Set(ByVal value As Date)
            mFec_PIni = value
        End Set
    End Property
    Dim mVal_Pago As Decimal
    Property Val_Pago As Decimal
        Get
            Return mVal_Pago
        End Get
        Set(ByVal value As Decimal)
            mVal_Pago = value
        End Set
    End Property

    Dim mSaldo_Per As Decimal
    Property Saldo_Per As Decimal
        Get
            Return mSaldo_Per
        End Get
        Set(ByVal value As Decimal)
            mSaldo_Per = value
        End Set
    End Property

    Dim mPor_Eje_Fis As Decimal
    Property Por_Eje_Fis As Decimal
        Get
            Return mPor_Eje_Fis
        End Get
        Set(ByVal value As Decimal)
            mPor_Eje_Fis = value
        End Set
    End Property

    Dim mPor_Eje_Fis_Per As Decimal
    Property Por_Eje_Fis_Per As Decimal
        Get
            Return mPor_Eje_Fis_Per
        End Get
        Set(ByVal value As Decimal)
            mPor_Eje_Fis_Per = value
        End Set
    End Property

    Dim mNVisitas As Integer
    Property NVisitas As Integer
        Get
            Return mNVisitas
        End Get
        Set(ByVal value As Integer)
            mNVisitas = value
        End Set
    End Property

    Dim mNVis_Per As Integer
    Property NVis_Per As Integer
        Get
            Return mNVis_Per
        End Get
        Set(ByVal value As Integer)
            mNVis_Per = value
        End Set
    End Property

    Public Property Fec_Act As Date?
        Get
            Return _fec_act
        End Get
        Set(value As Date?)
            _fec_act = value
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
            querystring = "INSERT INTO EstContratos (cod_con,est_ini,est_fin,fec_pini,fec_ent,val_pago,nvisitas,por_eje_fis,estado,obs_est,usuario,fec_reg,autorizapago,nvis_per,Por_Eje_Fis_Per,Saldo_Per,Fec_Act) "
            querystring += " Values(:cod_con,:est_ini,:est_fin,to_date(:fec_pini,'dd/mm/yyyy'),to_date(:fec_ent,'dd/mm/yyyy'),:val_pago,:nvisitas,:por_eje_fis,:estado,:obs_est,user,sysdate,:autorizapago,:nvis_per,:Por_Eje_Fis_Per,:Saldo_Per,:Fec_Act)"
            CrearComando(querystring)

            AsignarParametroCadena(":cod_con", Cod_Con)
            'Datos del Acta
            AsignarParametroCadena(":est_ini", Est_Ini)
            AsignarParametroCadena(":est_fin", Est_Fin)
            'Perido del Informe
            AsignarParametroCadena(":fec_pini", Fec_PIni) ' Fecha Inicial del Periodo
            AsignarParametroCadena(":fec_ent", Fec_Ent) 'Fecha de Corte - Entrega del Acta
            'Financiero
            AsignarParametroDecimal(":val_pago", Me.Val_Pago)

            'Avance
            AsignarParametroEntero(":nvisitas", Me.NVisitas)
            AsignarParametroDecimal(":por_eje_fis", Me.Por_Eje_Fis)
            
            AsignarParametroCadena(":obs_est", Obs)
            AsignarParametroCadena(":estado", "BO") ' Se crea en Borrador

            AsignarParametroCadena(":autorizapago", "S") ' Autoriza Pago

            AsignarParametroEntero(":nvis_per", Me.NVis_Per)
            AsignarParametroDecimal(":Por_Eje_Fis_Per", Me.Por_Eje_Fis_Per)
            AsignarParametroDecimal(":Saldo_Per", Me.Saldo_Per)
            AsignarParametroCadena(":Fec_Act", Fec_Act) ' Fecha del Acta


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
    Public Overloads Function Update(ByVal ID As String) As String
        Try
            Me.Conectar()
            Me.ComenzarTransaccion()
            querystring = "UPDATE EstContratos SET fec_pini=to_date(:fec_pini,'dd/mm/yyyy'),fec_ent=to_date(:fec_ent,'dd/mm/yyyy'),obs_est=:obs_est,"
            querystring += "val_pago=:val_pago,nvisitas=to_number(:nvisitas),por_eje_fis=:por_eje_fis,nvis_per=:nvis_per,"
            querystring += "Por_Eje_Fis_Per=:Por_Eje_Fis_Per,Saldo_Per=:Saldo_Per,Fec_Act=to_date(:Fec_Act,'dd/mm/yyyy') WHERE ID=:ID"
            CrearComando(querystring)
            AsignarParametroCadena(":ID", ID)

            'Perido del Informe
            AsignarParametroCadena(":fec_pini", Fec_PIni) ' Fecha Inicial del Periodo
            AsignarParametroCadena(":fec_ent", fec_ent) 'Fecha de Corte - Entrega del Acta
            'Financiero
            AsignarParametroDecimal(":val_pago", Me.Val_Pago)
            'Avance
            AsignarParametroEntero(":nvisitas", Me.NVisitas)
            AsignarParametroDecimal(":por_eje_fis", Me.Por_Eje_Fis)

            AsignarParametroCadena(":obs_est", Obs)
            'AsignarParametroCadena(":estado", "BO") ' Se crea en Borrador

            'AsignarParametroCadena(":autorizapago", "S") ' Autoriza Pago

            AsignarParametroEntero(":nvis_per", Me.NVis_Per)
            AsignarParametroDecimal(":Por_Eje_Fis_Per", Me.Por_Eje_Fis_Per)
            AsignarParametroDecimal(":Saldo_Per", Me.Saldo_Per)

            AsignarParametroCadena(":Fec_Act", Fec_Act) ' Fecha del Acta
            num_reg = EjecutarComando()
            Msg = "Se Actualizo el registro del Acta/Documento  ID [" + ID + "]"
            Me.ConfirmarTransaccion()
            Msg = MsgOk + "<br>" + Msg
            lErrorG = False
        Catch ex As Exception
            Me.CancelarTransaccion()
            Msg = ex.Message + ex.StackTrace
            lErrorG = True
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function


End Class
