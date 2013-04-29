Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Public Class Sol_Adiciones
    Inherits BDDatos
    Private _Id As String
    Property Id() As Double
        Get
            Return _Id
        End Get
        Set(ByVal value As Double)
            _Id = value
        End Set
    End Property
    Sub New()
        Me.Vista = "SOL_ADICIONES"
        Me.Tabla = "SOL_ADICIONES"
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPk(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VSOLADIHREV where Num_Sol_Adi=:Num_Sol_Adi"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPk(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VCONTRATOS_SOLADI where Num_Sol_Adi=:Num_Sol_Adi And Numero=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetUltimo(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT NVL(MAX(NUM_SOL_ADI),0) FROM SOL_ADICIONES where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT Num_Sol_Adi, Num_Sol_Adi||' - '||Nom_Tip Nom_Tip FROM VSOLADICIONES where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsAC(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT Num_Sol_Adi, Num_Sol_Adi||' - '||Nom_Tip Nom_Tip FROM vsoladihrev where Cod_Con=:Cod_Con and concepto='A'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Cod_Con As String, ByVal Tip_Adi As String, ByVal FECHA_RECIBIDO As Date, ByVal OBSERVACION As String) As String
        Me.Conectar()
        Try
            Me.Id = GetID()
            querystring = "Insert Into Sol_Adiciones (Num_Sol_Adi, Cod_Con, Tip_Adi, Obser,FEC_RECIBIDO) Values(:Num_Sol_Adi, :Cod_Con, :Tip_Adi, :Obser, to_date(:FEC_RECIBIDO,'dd/mm/yyyy'))"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":FEC_RECIBIDO", FECHA_RECIBIDO.ToShortDateString)
            Me.AsignarParametroCadena(":Obser", OBSERVACION)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroCadena(":Tip_Adi", Tip_Adi)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Me.Id)
            Me.num_reg = Me.EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Me.Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Update(ByVal PK As String, ByVal Cod_Con As String, ByVal Tip_Adi As String, ByVal FECHA_RECIBIDO As Date, ByVal OBSERVACION As String) As String
        Me.Conectar()
        Try
            querystring = "Update Sol_Adiciones Set Cod_Con=:Cod_Con, Tip_Adi=:Tip_Adi, Obser=:Obser, FEC_RECIBIDO=to_date(:FEC_RECIBIDO,'dd/mm/yyyy') where Num_Sol_Adi=:PK"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":FEC_RECIBIDO", FECHA_RECIBIDO.ToShortDateString)
            Me.AsignarParametroCadena(":Obser", OBSERVACION)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroCadena(":Tip_Adi", Tip_Adi)
            Me.AsignarParametroCadena(":PK", PK)
            'Throw New Exception(_Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Me.Msg
    End Function
    Public Function Asignar_Usuario_Encargado(ByVal Num_Sol_Adi As String, ByVal ID_ABOG_ENC As String) As String
        Me.Conectar()
        If ID_ABOG_ENC.Trim.Length = 0 Then
            Me.Msg = "El funcionario no puede estar vacio"
            Me.lErrorG = True
            Return Msg
        End If
        Try
            Me.ComenzarTransaccion()
            querystring = "Update SOL_ADICIONES SET ID_ABOG_ENC=:ID_ABOG_ENC WHERE Num_Sol_Adi=:Num_Sol_Adi"

            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":ID_ABOG_ENC", ID_ABOG_ENC)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            'Throw New Exception(_Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        End Try
        Me.Desconectar()
        Return Me.Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function InsertHREV(ByVal NUM_SOL_ADI As String, ByVal FECHA_RECIBIDO As Date, ByVal OBSERVACION As String) As String
        Me.Conectar()
        Try
            querystring = "Insert Into HREVSOLADI (NUM_SOL_ADI, FECHA_RECIBIDO, OBSERVACION_RECIBIDO, FEC_ASIGNADO) Values(:NUM_SOL_ADI, to_date(:FECHA_RECIBIDO,'dd/mm/yyyy'), :OBSERVACION, SYSDATE)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":FECHA_RECIBIDO", FECHA_RECIBIDO.ToShortDateString)
            Me.AsignarParametroCadena(":OBSERVACION", OBSERVACION)
            Me.AsignarParametroCadena(":NUM_SOL_ADI", NUM_SOL_ADI)
            Me.num_reg = Me.EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Me.Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetvHUsuEncargados(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VHUSUENC_SOL_ADI Where Num_Sol_Adi=:Num_Sol_Adi Order by fec_reg desc "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByAbogxFec(ByVal RECIBIDO As String, ByVal Desde As Date, ByVal Hasta As Date, Optional ByVal Num_Sol_Adi As String = "") As DataTable
        Dim dataTb As DataTable = New DataTable
        Me.Conectar()
        Select Case RECIBIDO
            Case 1
                If String.IsNullOrEmpty(Num_Sol_Adi) Then
                    querystring = "SELECT * FROM VSOLADIHREV WHERE Recibido=:Recibido and Id_Abog_Enc=:Id_Abog_Enc And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":Recibido", "N")
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    dataTb = Me.EjecutarConsultaDataTable()
                Else
                    querystring = "SELECT * FROM VSOLADIHREV WHERE Recibido=:Recibido and Id_Abog_Enc=:Id_Abog_Enc And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Num_Sol_Adi Like :Cod_Sol"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":Recibido", "N")
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Num_Sol_Adi) + "%")
                    dataTb = Me.EjecutarConsultaDataTable()
                End If
            Case 2
                If String.IsNullOrEmpty(Num_Sol_Adi) Then
                    querystring = "SELECT * FROM VSOLADIHREV WHERE Recibido=:Recibido and Id_Abog_Enc=:Id_Abog_Enc And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":Recibido", "S")
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    dataTb = Me.EjecutarConsultaDataTable()
                Else
                    querystring = "SELECT * FROM VSOLADIHREV WHERE Recibido=:Recibido and Id_Abog_Enc=:Id_Abog_Enc And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Num_Sol_Adi Like :Cod_Sol"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":Recibido", "S")
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Num_Sol_Adi) + "%")
                    dataTb = Me.EjecutarConsultaDataTable()
                End If
            Case 3
                If String.IsNullOrEmpty(Num_Sol_Adi) Then
                    querystring = "SELECT * FROM VSOLADIHREV WHERE Id_Abog_Enc=:Id_Abog_Enc And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    dataTb = Me.EjecutarConsultaDataTable()
                Else
                    querystring = "SELECT * FROM VSOLADIHREV WHERE Id_Abog_Enc=:Id_Abog_Enc And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Num_Sol_Adi Like :Cod_Sol"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Num_Sol_Adi) + "%")
                    dataTb = Me.EjecutarConsultaDataTable()
                End If
        End Select
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function Recibir(ByVal Num_Sol_Adi As String, ByVal Observacion As String) As String
        If Observacion.Trim.Length = 0 Then
            Me.Msg = "La observacion no puede estar vacia"
            Me.lErrorG = True
            Return Msg
        End If
        Try
            Me.Conectar()
            Me.ComenzarTransaccion()
            querystring = "Update HREVSOLADI SET Fec_Rec_Abog=sysdate, Obs_Recibido_Abog=:Observacion, Recibido_Abog='S', Nit_Abog_Recibe=:ID_ABOG WHERE (Num_Sol_Adi=:Num_Sol_Adi AND ID_HREV=(SELECT MAX(ID_HREV) from HREVSOLADI where Num_Sol_Adi=:Num_Sol_Adi_PK1))"

            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Observacion", Observacion)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Num_Sol_Adi_PK1", Num_Sol_Adi)
            Me.AsignarParametroCadena(":ID_ABOG", Me.usuario)

            'Throw New Exception(_Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()

            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message + ex.StackTrace.ToString
            Me.CancelarTransaccion()
            Me.lErrorG = True
        End Try
        Me.Desconectar()
        Return Me.Msg
    End Function
    Public Overloads Function GetByPkAbog(ByVal Num_Sol_Adi As String, Optional ByVal connect As Boolean = True) As DataTable
        If connect Then
            Me.Conectar()
        End If
        querystring = "SELECT * FROM VSOLADIHREV where Num_Sol_Adi=:Num_Sol_Adi and Id_Abog_Enc=:Encargado and Recibido='S'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Me.AsignarParametroCadena(":Encargado", Me.usuario)
        'Throw New Exception(_Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        If connect Then
            Me.Desconectar()
        End If
        Return dataTb
    End Function
    Public Function Revision(ByVal Num_Sol_Adi_PK As String, ByVal Fecha_Revision As String, ByVal obs As String, ByVal concepto As String, ByVal id_Hrev As String, ByVal Cod_Con As String) As String
        'Dim proc As New PContratos
        Dim modi As New Modificaciones
        Try
            Me.Conectar()
            modi.Conexion = Me.Conexion
            Me.ComenzarTransaccion()
            querystring = "Update HREVSOLADI SET Fecha_Revisado=sysdate, Obs_Revisado=Obs_Revisado||' '||:OBS, Concepto_Revisado=:CONCEPTO, Recibido_Abog='S' WHERE Num_Sol_Adi=:Num_Sol_Adi_PK AND ID_HREV=:ID_HREV"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":OBS", obs)
            Me.AsignarParametroCadena(":CONCEPTO", concepto)
            Me.AsignarParametroCadena(":Num_Sol_Adi_PK", Num_Sol_Adi_PK)
            Me.AsignarParametroCadena(":ID_HREV", id_Hrev)
            Me.num_reg = Me.EjecutarComando()
            Me.Msg = " " + Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            If concepto = "A" Then
                Dim a As String
                a = modi.Aceptar_Solicitud(Cod_Con, Num_Sol_Adi_PK)
                If a = "1" Then
                    Me.Msg += " - Se generó el proceso para la solicitud, puede continuar su gestion con el mismo Número"
                ElseIf a = "2" Then
                    Throw New Exception("La solicitud no generó proceso consulte con el Administrador del Sistema")
                ElseIf a = "3" Then
                    Throw New Exception("Ocurrio un error de duplicación consulte con el Administrador del Sistema")
                ElseIf a = 4 Then
                    Throw New Exception("Ocurrio un error al aceptar la Solicitud")
                End If
            End If
            Me.ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg += "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        End Try
        Me.Desconectar()
        Return Me.Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetHrev(ByVal Num_Sol_Adi As String, Optional ByVal connect As Boolean = True) As DataTable
        'If connect Then
        Me.Conectar()
        'End If
        querystring = "SELECT * FROM VHREVSOLADI where Num_Sol_Adi=:Num_Sol_Adi"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        'If connect Then
        Me.Desconectar()
        'End If
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetID() As String
        querystring = "SELECT (NVL(MAX(to_number(NUM_SOL_ADI)),0)+1) Id FROM SOL_ADICIONES;"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Dim Ide As String = dataTb.Rows(0)("Id").ToString
        Return Ide
    End Function
End Class
