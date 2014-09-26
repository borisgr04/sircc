Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System.Data.Common

<System.ComponentModel.DataObject()> _
Public Class EstContratos
    Inherits BDDatos


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal cod_con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT ESTADO_INICIAL, ESTADO_FINAL, FECHA, DOCUMENTO, USUARIO, NRO_CONTRATO, EXT , 0 DIAS_EJEC, OBSERVACION,ID,VALOR_PAGO,POR_EJE_FIS,Ult,ESTADO FROM VGESACTAS WHERE (NRO_CONTRATO = :cod_con)  and estado <>'AN'"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod_con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal cod_con As String, ByVal est_ini As String, ByVal est_fin As String, ByVal fec_ent As Date, ByVal tfil As String, ByVal obs As String, ByVal val_pago As Decimal, ByVal nvisitas As Integer, ByVal por_eje_fis As Decimal) As String

        Dim oCon As New Contratos

        Dim tbCon As New DataTable
        Dim fecsus As Date, fecentant As Date
        Dim estfinant As String
        Me.lErrorG = True
        Conectar()
        ComenzarTransaccion()
        oCon.Conexion = Me.Conexion
        ' VALIDACION DE FECHA DE SUSCRIPCION
        tbCon = oCon.GetByIde(cod_con)
        fecsus = CDate(tbCon.Rows(0)("fec_sus_con").ToString)
        If fecsus > fec_ent Then
            Msg = "La fecha del acta que está regitrando debe ser mayor a la fecha de suscripción del contrato, cuya fecha es " + fecsus.ToShortDateString
            Return Msg
            Exit Function
        End If

        ' VALIDACION DE FECHA DE SUSCRIPCION
        tbCon = Me.GetEstByIdep(cod_con)
        If tbCon.Rows.Count > 0 Then
            fecentant = CDate(tbCon.Rows(0)("fec_ent").ToString)
            If fecentant > fec_ent Then
                Msg = "La fecha de la nueva acta debe ser mayor a la fecha de la última acta registrada, cuya fecha es " + fecentant.ToShortDateString
                Return Msg
                Exit Function
            End If
            estfinant = tbCon.Rows(0)("est_fin").ToString
            If estfinant <> est_ini Then
                Msg = "El estado final de la última acta registrada, no coincide el estado inicial del acta que está agregando "
                Return Msg
                Exit Function
            End If
        End If

        Try
            querystring = "INSERT INTO EstContratos (cod_con,est_ini,est_fin,fec_ent,usuario,fec_reg,obs_est,val_pago,nvisitas,por_eje_fis) "
            ' querystring += " Values(:cod_con,:est_ini,:est_fin,to_date(:fec_ent,'dd/mm/yyyy'),user,sysdate,:obs_est,to_number(:val_pago),to_number(:nvisitas))"
            querystring += " Values(:cod_con,:est_ini,:est_fin,to_date(:fec_ent,'dd/mm/yyyy'),user,sysdate,:obs_est,:val_pago,to_number(:nvisitas),:por_eje_fis)"
            CrearComando(querystring)

            AsignarParametroCadena(":cod_con", cod_con)
            AsignarParametroCadena(":est_ini", est_ini)
            AsignarParametroCadena(":est_fin", est_fin)
            AsignarParametroCadena(":fec_ent", fec_ent)
            AsignarParametroCadena(":obs_est", obs)
            AsignarParametroDecimal(":val_pago", val_pago)
            AsignarParametroCadena(":nvisitas", nvisitas)
            AsignarParametroDecimal(":por_eje_fis", por_eje_fis)

            num_reg = EjecutarComando()


            querystring = "UPDATE Contratos Set est_con='" & est_fin & "' Where cod_con='" & cod_con & "'"
            CrearComando(querystring)

            num_reg = EjecutarComando()

            'f.InsAud(Me.dbConnection, t, "CONTRATOS", "REGISTRO DE ACTA/CAMBIO DE ESTADO", Me.usuario)
            ConfirmarTransaccion()
            Msg = MsgOk + " Código de Verficación: " + GetIdbyCod_con(cod_con)
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        Finally
            Desconectar()
        End Try


        Return Msg

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetIdbyCod_con(ByVal cod_con As String) As String
        Dim id_cont1 As String
        querystring = "SELECT MAX(ID) as ID FROM VGESACTAS WHERE (NRO_CONTRATO = :cod_con)  and estado <>'AN'"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod_con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        id_cont1 = dataTb.Rows(0)("ID")
        Return id_cont1
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetEstByIde(ByVal cod As String) As System.Data.DataTable
        Dim datat As New DataTable
        querystring = "select * from estcontratos where cod_con =:cod_con and estado<>'AN' Order By Id Desc"
        CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod)
        datat = EjecutarConsultaDataTable()
        Return datat
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetActasBorrador(ByVal cod As String) As Integer
        Conectar()
        Dim i As Integer = GetEnBorrador(cod)
        Desconectar()
        Return i
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Protected Function GetEnBorrador(ByVal cod As String) As Integer
        querystring = "select Count(*) from estcontratos where cod_con =:cod_con and estado='BO' "
        CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod)
        Return CInt(EjecutarEscalar())
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Protected Function GetEstByIdep(ByVal cod As String) As System.Data.DataTable
        Dim datat As New DataTable
        querystring = "select * from estcontratos where cod_con =:cod_con and estado<>'AN' Order By Id Desc"
        CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod)
        datat = EjecutarConsultaDataTable()
        Return datat
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyCod_Con(ByVal cod_con As String) As System.Data.DataTable
        Conectar()
        Dim datat As New DataTable
        querystring = "SELECT ESTADO_INICIAL, ESTADO_FINAL, FECHA, DOCUMENTO, USUARIO, NRO_CONTRATO, EXT , 0 DIAS_EJEC, OBSERVACION,ID,VALOR_PAGO,Ult,NRO_DOC,por_eje_fis,NVISITAS,ESTADO FROM VGESACTAS WHERE (NRO_CONTRATO = :cod_con)  and estado <>'AN' ORDER BY ID DESC"
        CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod_con)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        Return datat
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyID(ByVal ID As String) As System.Data.DataTable
        Conectar()
        Dim datat As New DataTable
        querystring = "SELECT ESTADO_INICIAL, ESTADO_FINAL, FECHA, DOCUMENTO, USUARIO, NRO_CONTRATO, EXT , 0 DIAS_EJEC, OBSERVACION,NRO_DOC,NVISITAS,VALOR_PAGO,por_eje_fis,ID FROM VGESACTAS WHERE (ID = :ID) "
        CrearComando(querystring)
        AsignarParametroCadena(":ID", ID)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        Return datat
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Private Function GetbyPkp(ByVal ID As String) As System.Data.DataTable
        Dim datat As New DataTable
        querystring = "SELECT * FROM VGESACTAS WHERE (ID = :ID) "
        CrearComando(querystring)
        AsignarParametroCadena(":ID", ID)
        datat = EjecutarConsultaDataTable()
        Return datat
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal ID As String) As System.Data.DataTable
        Dim datat As New DataTable
        Conectar()
        querystring = "SELECT * FROM VGESACTAS WHERE (ID = :ID) "
        CrearComando(querystring)
        AsignarParametroCadena(":ID", ID)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        Return datat
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Anular(ByVal ID As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()

            querystring = "UPDATE EstContratos SET estado='AN' WHERE ID=:ID"
            CrearComando(querystring)
            AsignarParametroCadena(":ID", ID)
            EjecutarComando()

            querystring = "Update contratos Set est_con=(SELECT est_ini FROM estcontratos WHERE ID = :ID) where cod_con= (SELECT cod_con FROM estcontratos WHERE ID = :ID)"
            CrearComando(querystring)
            AsignarParametroCadena(":ID", ID)
            AsignarParametroCadena(":ID", ID)
            num_reg = EjecutarComando()
            Msg = "Se Anuló el registro del Acta  ID [" + ID + "]"
            ' f.InsAud(BDDatos.dbConnection, t, "Contratos", Msg, usuario)
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
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal ID As String, ByVal fec_ent As Date, ByVal Obs As String, ByVal val_pago As Decimal, ByVal nvisitas As Integer, ByVal por_eje_fis As Decimal) As String

        Try
            Me.Conectar()
            Me.ComenzarTransaccion()

            querystring = "UPDATE EstContratos SET fec_ent=to_date(:fec_ent,'dd/mm/yyyy'),obs_est=:obs_est,val_pago=:val_pago,nvisitas=to_number(:nvisitas),por_eje_fis=:por_eje_fis WHERE ID=:ID"
            CrearComando(querystring)
            AsignarParametroCadena(":ID", ID)
            AsignarParametroCadena(":fec_ent", fec_ent)
            AsignarParametroCadena(":obs_est", Obs)
            AsignarParametroDecimal(":val_pago", val_pago)
            AsignarParametroCadena(":nvisitas", nvisitas)
            AsignarParametroDecimal(":por_eje_fis", por_eje_fis)


            num_reg = EjecutarComando()

            Msg = "Se Actualizo el registro del Acta/Documento  ID [" + ID + "]"
            ' f.InsAud(BDDatos.dbConnection, t, "Contratos", Msg, usuario)
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
