Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class ActasSupervision
    Inherits EstContratos

    Dim mEst_Fin As String
    Dim mCod_Con As String
    Dim mEst_Ini As String
    Dim mFec_Ent As Date
    Dim mObs As String
    Property Obs As String
        Get
            Return mObs
        End Get
        Set(ByVal value As String)
            mObs = value
        End Set
    End Property
    Property Fec_Ent As Date
        Get
            Return mFec_ent
        End Get
        Set(ByVal value As Date)
            mFec_ent = value
        End Set
    End Property
    Property Est_Fin As String
        Get
            Return mEst_Fin
        End Get
        Protected Set(ByVal value As String)
            mEst_Fin = value
        End Set
    End Property

    Property Est_Ini As String
        Get
            Return mEst_ini
        End Get
        Set(ByVal value As String)
            mEst_ini = value
        End Set
    End Property

    Property Cod_Con As String
        Get
            Return mCod_Con
        End Get
        Set(ByVal value As String)
            mCod_Con = value
        End Set
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Function GetContratosByIde(ByVal Cod_Con As String) As DataTable
        querystring = "SELECT * FROM Contratos Where Cod_Con =:cod_con"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", Cod_Con)
        Return EjecutarConsultaDataTable()
    End Function

    Sub FechaSugerida(ByVal Cod_Con As String, ByRef Fecha As Date, ByRef Clase As String)
        Conectar()
        Dim tbCon As New DataTable
        ' SI HAY UN ACTA, VALIDAR EL ACTA
        tbCon = Me.GetGEstByIdep(Cod_Con)
        If tbCon.Rows.Count > 0 Then
            Fecha = CDate(tbCon.Rows(0)("fec_ent").ToString)
            Clase = tbCon.Rows(0)("nom_est_fin").ToString
        Else
            tbCon = GetContratosByIde(Cod_Con)
            Fecha = CDate(tbCon.Rows(0)("fec_apr_pol").ToString)
            Clase = "Fecha de Legalización"
        End If
        Desconectar()
    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Protected Function GetGEstByIdep(ByVal cod As String) As System.Data.DataTable
        Dim datat As New DataTable
        querystring = "select ec.fec_ent,e.nom_est nom_est_fin from estcontratos ec inner join estados e on e.cod_est=ec.est_fin  where Cod_Con =:cod_con and ec.estado<>'AN' Order By Id Desc"
        CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod)
        datat = EjecutarConsultaDataTable()
        Return datat
    End Function

    Function IsValido() As Boolean
        Dim tbCon As New DataTable
        Dim fecsus As Date, fecentant As Date, fecaprpol As Date
        Dim estfinant As String
        Me.lErrorG = True
        '1. Validar si esta en Borrador un DOcumento
        If GetEnBorrador(Cod_Con) > 0 Then
            Msg = "Existe un Acta/Documento en Borrador, debe Confirmarlo para Continuar con otro Documento"
            Return False
        End If
        '2. Validar con el Ultimo Documento Activo
        tbCon = Me.GetEstByIdep(Cod_Con)
        If tbCon.Rows.Count > 0 Then
            fecentant = CDate(tbCon.Rows(0)("fec_ent").ToString)
            If fecentant > Fec_Ent Then
                Msg = "La Fecha de este Documento debe ser mayor o igual  a la Fecha del Documento Anterior :" + fecentant.ToShortDateString
                Return False
            End If
            estfinant = tbCon.Rows(0)("est_fin").ToString
            If estfinant <> Est_Ini Then
                Msg = "El Estado Final Actual no Coincide el Nuevo Estado Inicial " + estfinant + "-" + Est_Ini
                Return False
            End If
        End If
        '3.Validar con la fecha de Aprobación de la Poliza
        tbCon = GetContratosByIde(Cod_Con)
        fecaprpol = CDate(tbCon.Rows(0)("fec_apr_pol").ToString)
        If fecaprpol > Fec_Ent Then
            Msg = "La Fecha de este Documentos debe ser mayor o igual a la Fecha de Aprobación de la Póliza:" + fecaprpol
            Return False
        End If
        '4.Validar con Fecha de Suscripción, se supone cque nunca debe llegar aca, porq debe estar en estado Legalizado
        fecsus = CDate(tbCon.Rows(0)("fec_sus_con").ToString)
        If fecsus > Fec_Ent Then
            Msg = "La Fecha del Acta debe ser mayor a la Fecha de Suscripción:" + fecsus
            Return False
        End If
        Me.lErrorG = False
        Return True
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetValFecha(ByVal cod_con As String, ByVal fec_ent As Date) As Boolean
        Dim tbcon As DataTable
        Dim fecentant As Date
        tbcon = Me.GetEstByIde1(cod_con)
        If tbcon.Rows.Count > 0 Then
            fecentant = CDate(tbcon.Rows(0)("fec_ent").ToString)
            If fecentant > fec_ent Then
                Me.Msg = "La Fecha del Acta debe ser mayor a la Fecha del Acta Anterior :" + fecentant.ToShortDateString
                lErrorG = True
            Else
                lErrorG = False
            End If
        End If
        Return lErrorG
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetEstByIde1(ByVal cod As String) As System.Data.DataTable
        Me.Conectar()
        Dim datat As New DataTable
        querystring = "select * from estcontratos where cod_con =:cod_con and estado<>'AN' Order By Id Desc"
        CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod)
        datat = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return datat
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function ValActaEstado(ByVal ID As String) As String
        Me.Conectar()
        Try
            querystring = "UPDATE Contratos Set est_con='" + Est_Fin + "' Where cod_con=(Select Cod_Con From EstContratos Where ID=:ID)"
            CrearComando(querystring)
            AsignarParametroCadena(":ID", ID)
            EjecutarComando()

            querystring = "UPDATE EstContratos SET estado='AC' WHERE ID=:ID"
            CrearComando(querystring)
            AsignarParametroCadena(":ID", ID)
            EjecutarComando()
            num_reg = EjecutarComando()
            Msg = "Se Validó el registro del Acta  ID [" + ID + "]"
            Msg = MsgOk + "<br>" + Msg
            lErrorG = False
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = True
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function RevActaEstado(ByVal ID As String) As String
        Me.Conectar()
        Try
            'Revierte el Estado del Contrato.
            querystring = "Update contratos Set est_con=(SELECT est_ini FROM estcontratos WHERE ID = :ID) where cod_con= (SELECT cod_con FROM estcontratos WHERE ID = :ID)"
            CrearComando(querystring)
            AsignarParametroCadena(":ID", ID)
            AsignarParametroCadena(":ID", ID)
            num_reg = EjecutarComando()

            'Pone en Borrador el Documento
            querystring = "UPDATE EstContratos SET estado='BO' WHERE ID=:ID"
            CrearComando(querystring)
            AsignarParametroCadena(":ID", ID)
            EjecutarComando()
            num_reg = EjecutarComando()
            Msg = "Se Validó el registro del Acta  ID [" + ID + "]"
            Msg = MsgOk + "<br>" + Msg
            lErrorG = False
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = True
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetIdbyCod_con(ByVal cod_con As String) As String
        Dim id_cont1 As String
        Me.Conectar()
        querystring = "SELECT MAX(ID) as ID FROM VGESACTAS WHERE (NRO_CONTRATO = :cod_con)  and estado <>'AN'"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod_con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        id_cont1 = dataTb.Rows(0)("ID")
        Me.Desconectar()
        Return id_cont1
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function EstEsValido(ByVal est_ini As String) As Boolean
        Me.Conectar()
        querystring = "select est_ini from rutaestados where est_fin=:est_fin and est_ini=:est_ini"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":est_fin", Est_Fin)
        AsignarParametroCadena(":est_ini", est_ini)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetEsUlt(ByVal ID As String) As Boolean
        Conectar()
        Dim datat As New DataTable
        querystring = "SELECT Ult FROM VGESACTAS WHERE ID = :ID "
        CrearComando(querystring)
        AsignarParametroCadena(":ID", ID)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        If datat.Rows.Count > 0 Then
            If datat.Rows(0)("ult") = "OK" Then
                Return True
            End If
        End If
        Return False
    End Function

    ''' <summary>
    ''' Consulta de contratos por llave primaria, filtrando por dependencia necesidad asociada.
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkS(ByVal Cod_Con As String) As DataTable

        Me.Conectar()
        querystring = "SELECT * FROM vcontratos_sinc_p Where numero =:cod_con and Numero In (Select Cod_Con from INTERVENTORES_CONTRATO where ide_int=:ide_int And Est_int='AC') "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", Cod_Con)
        Me.AsignarParametroCadena(":ide_int", Me.usuario)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorCodCon(ByVal cod_con As String) As System.Data.DataTable
        Conectar()
        Dim datat As New DataTable
        querystring = "SELECT * FROM VGESACTAS WHERE (NRO_CONTRATO = :cod_con)  and estado <>'AN'"
        CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod_con)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        Return datat
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPlantillas(ByVal Est_Fin As String) As DataTable
        Me.Conectar()
        querystring = "Select * From PPlantillas Where Tip_Pla='04' And Cod_Stip=:Est_Fin"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Est_Fin", Est_Fin)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

End Class
