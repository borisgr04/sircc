Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Resources
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class CtrF20_2013
    Private ctx As New BDDatosG
    Private _Msg As String
    Property Msg As String
        Get
            Return _Msg
        End Get
        Set(value As String)
            _Msg = value
        End Set
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function getF20_1a(fec_ini As Date, fec_fin As Date) As DataTable
        Dim datat As New DataTable
        Dim querystring As String = "Select SQL From RPT_CONTROL Where IDE_RPT='F20_1A' And VIG_RPT='2013' And Est_Rpt='AC'"
        Try
            ctx.Conectar()
            ctx.CrearComando(querystring)

            datat = ctx.EjecutarConsultaDataTable()
            If datat.Rows.Count > 0 Then
                querystring = datat.Rows(0)("SQL").ToString()
                ctx.CrearComando(querystring)
                ctx.AsignarParametroCadena(":fec_ini", fec_ini)
                ctx.AsignarParametroCadena(":fec_fin", fec_fin)
                datat = ctx.EjecutarConsultaDataTable()
                Msg = "Filas :" + datat.Rows.Count.ToString
            End If
            ctx.Desconectar()
        Catch ex As Exception
            Msg = ex.Message
        End Try
        Return datat

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function getF20_1c(fec_ini As Date, fec_fin As Date) As DataTable
        Dim datat As New DataTable
        Dim querystring As String = "Select SQL From RPT_CONTROL Where IDE_RPT='F20_1C' And VIG_RPT='2013' And Est_Rpt='AC'"
        Try
            ctx.Conectar()
            ctx.CrearComando(querystring)

            datat = ctx.EjecutarConsultaDataTable()
            If datat.Rows.Count > 0 Then
                querystring = datat.Rows(0)("SQL").ToString()
                ctx.CrearComando(querystring)
                ctx.AsignarParametroCadena(":fec_ini", fec_ini)
                ctx.AsignarParametroCadena(":fec_fin", fec_fin)
                datat = ctx.EjecutarConsultaDataTable()
                Msg = "Filas :" + datat.Rows.Count.ToString
            End If
            ctx.Desconectar()
        Catch ex As Exception
            Msg = ex.Message
        End Try
        Return datat

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function getF20_1b(fec_ini As Date, fec_fin As Date) As DataTable

        Dim datat As New DataTable
        Dim querystring As String = "Select SQL From RPT_CONTROL Where IDE_RPT='F20_1B' And VIG_RPT='2013' And Est_Rpt='AC'"
        Try
            ctx.Conectar()
            ctx.CrearComando(querystring)
            datat = ctx.EjecutarConsultaDataTable()
            If datat.Rows.Count > 0 Then
                querystring = datat.Rows(0)("SQL").ToString()
                ctx.CrearComando(querystring)
                ctx.AsignarParametroCadena(":fec_ini", fec_ini)
                ctx.AsignarParametroCadena(":fec_fin", fec_fin)
                ctx.AsignarParametroCadena(":fec_ini", fec_ini)
                ctx.AsignarParametroCadena(":fec_fin", fec_fin)
                datat = ctx.EjecutarConsultaDataTable()
                Msg = "Filas :" + datat.Rows.Count.ToString
            End If
            ctx.Desconectar()
        Catch ex As Exception
            Msg = ex.Message
        End Try
        Return datat

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function getF20(ID As String, fec_ini As Date, fec_fin As Date) As DataTable

        Dim datat As New DataTable
        Dim querystring As String = "Select SQL From RPT_CONTROL Where IDE_RPT='F20_1B' And VIG_RPT='2013' And Est_Rpt='AC'"
        Try
            ctx.Conectar()
            ctx.CrearComando(querystring)
            datat = ctx.EjecutarConsultaDataTable()
            If datat.Rows.Count > 0 Then
                querystring = datat.Rows(0)("SQL").ToString()
                ctx.CrearComando(querystring)
                ctx.AsignarParametroCadena(":fec_ini", fec_ini)
                ctx.AsignarParametroCadena(":fec_fin", fec_fin)
                ctx.AsignarParametroCadena(":fec_ini", fec_ini)
                ctx.AsignarParametroCadena(":fec_fin", fec_fin)
                datat = ctx.EjecutarConsultaDataTable()
            End If
            ctx.Desconectar()
        Catch ex As Exception
            Msg = ex.Message
        End Try
        Return datat

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function getF20s(Est As String) As DataTable
        Dim datat As New DataTable
        Dim querystring As String = "Select * From RPT_CONTROL Where Est_Rpt='" + Est + "'"
        Try
            ctx.Conectar()
            ctx.CrearComando(querystring)
            datat = ctx.EjecutarConsultaDataTable()
            ctx.Desconectar()
        Catch ex As Exception
            Msg = ex.Message
        End Try
        Return datat

    End Function

End Class
