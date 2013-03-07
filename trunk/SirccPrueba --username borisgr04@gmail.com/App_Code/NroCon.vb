Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Public Class NroCon
    Inherits BDDatos
    Sub New()
        Me.Tabla = "NROCONVIG"
        Me.Vista = "NROCON"
        Me.VistaDB = "NROCON"
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByPK(ByVal Vig As String, ByVal Cod_Tip As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM NROCONVIG WHERE Year_Vig=:Vigencia And Cod_Tip=:Cod_Tip"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Vigencia", Vig)
        AsignarParametroCadena(":Cod_Tip", Cod_Tip)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function Insert(ByVal Año As String, ByVal CodTip As String, ByVal NumI As Integer, ByVal NumAct As Integer, ByVal porcentaje As Integer) As String
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "INSERT INTO NROCONVIG(YEAR_VIG,COD_TIP,NRO_INI_CON,NRO_ACT_CON,POR_ADI_VIG) VALUES(:YEAR_VIG,:COD_TIP,:NRO_INI_CON,:NRO_ACT_CON,:POR_ADI_VIG)"
            CrearComando(querystring)
            Me.AsignarParametroCadena(":YEAR_VIG", Año)
            Me.AsignarParametroCadena(":COD_TIP", CodTip)
            Me.AsignarParametroCadena(":NRO_INI_CON", NumI)
            Me.AsignarParametroCadena(":NRO_ACT_CON", NumAct)
            AsignarParametroCadena(":POR_ADI_VIG", porcentaje)
            Me.num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function Update(ByVal Pk As String, ByVal Pk1 As String, ByVal Año As String, ByVal CodTip As String, ByVal NumI As Integer, ByVal NumAct As Integer, ByVal porcentaje As Integer) As String
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "UPDATE NROCONVIG SET YEAR_VIG=:YEAR_VIG,COD_TIP=:COD_TIP,NRO_INI_CON=:NRO_INI_CON,NRO_ACT_CON=:NRO_ACT_CON, POR_ADI_VIG=:POR_ADI_VIG WHERE YEAR_VIG=:YEAR_VIG_PK AND COD_TIP=:COD_TIP_PK"
            CrearComando(querystring)
            Me.AsignarParametroCadena(":YEAR_VIG", Año)
            Me.AsignarParametroCadena(":COD_TIP", CodTip)
            Me.AsignarParametroCadena(":NRO_INI_CON", NumI)
            Me.AsignarParametroCadena(":NRO_ACT_CON", NumAct)
            AsignarParametroCadena(":POR_ADI_VIG", porcentaje)
            Me.AsignarParametroCadena(":YEAR_VIG_PK", Pk)
            Me.AsignarParametroCadena(":COD_TIP_PK", Pk1)
            'Throw New Exception(vComando.CommandText)
            Me.num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
End Class
