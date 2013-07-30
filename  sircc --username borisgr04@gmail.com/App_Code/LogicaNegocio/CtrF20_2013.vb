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

    ' ''' <summary>
    ' ''' Genera el Formato 20
    ' ''' </summary>
    ' ''' <param name="fec_ini"></param>
    ' ''' <param name="fec_fin"></param>
    ' ''' <returns>
    ' ''' (N) Nit Sujeto Vigilado,(C) Nombre Sujeto Vigilado,(C) Número Del Contrato,(C) Prorroga,(D) Valor Total De Las Adicciones En Pesos,(F) Fecha Suscripción Del Acta De Liquidación (Aaaa/mm/dd),(C) Actualización En El Secop
    ' ''' </returns>
    ' ''' <remarks></remarks>
    'Public Function getF20_1bX(fec_ini As Date, fec_fin As Date) As DataTable

    '    Dim sb As New StringBuilder()
    '    sb.Append(" SELECT cod_con, CASE  WHEN pla_eje_adi > 0 THEN 'SI' ELSE 'NO' END prorrogas, val_adi val_adic, NVL (TO_CHAR (fecha_liq (cod_con), 'yyyy/mm/dd'), 'ND') fechaliq,  'NO' Secop ")
    '    sb.Append(" FROM adiciones  WHERE   (pla_eje_adi>0 or Val_Adi>0) ")
    '    sb.Append(" AND fec_sus_adi BETWEEN TO_DATE ('" + fec_ini.ToShortDateString + "', 'dd/mm/yyyy') AND TO_DATE ('" + fec_fin.ToShortDateString + "', 'dd/mm/yyyy')")
    '    sb.Append(" UNION")
    '    sb.Append(" SELECT cod_con, 'NO' Prorroga, 0 valor, NVL (TO_CHAR (fecha_liq (cod_con), 'yyyy/mm/dd'), 'ND') fechaliq,'NO' secop")
    '    sb.Append("  FROM adiciones ")
    '    sb.Append(" WHERE fecha_liq (cod_con) BETWEEN TO_DATE ('" + fec_ini.ToShortDateString + "', 'dd/mm/yyyy') AND TO_DATE ('" + fec_fin.ToShortDateString + "', 'dd/mm/yyyy')")

    '    ctx.Conectar()
    '    Dim querystring As String = sb.ToString()
    '    ctx.CrearComando(querystring)
    '    Dim datat As New DataTable
    '    datat = ctx.EjecutarConsultaDataTable()
    '    ctx.Desconectar()
    '    Return datat
    'End Function

    'Public Function getF20_1cX(fec_ini As Date, fec_fin As Date) As DataTable

    '    Dim sb As New StringBuilder()
    '    sb.Append(" SELECT c.ide_ter nit_csut, t.nom_ter nom_csut, id_miembros nit_integrante, nom_miembro nom_integrante, (Select Nit from Ctrl_Entidad) Nit_Entidad, cod_con ")
    '    sb.Append(" FROM vconsorciosutxc c INNER JOIN vterceros t ON t.ide_ter = c.ide_ter ")
    '    sb.Append(" WHERE cod_con IN (SELECT numero FROM vcontratos_sinc_p c WHERE fec_sus_con BETWEEN TO_DATE ('" + fec_ini.ToShortDateString + "', 'dd/mm/yyyy') AND TO_DATE ('" + fec_fin.ToShortDateString + "', 'dd/mm/yyyy'))")
    '    Dim querystring As String = sb.ToString()

    '    ctx.Conectar()
    '    ctx.CrearComando(querystring)
    '    Dim datat As New DataTable
    '    datat = ctx.EjecutarConsultaDataTable()
    '    ctx.Desconectar()
    '    Return datat

    'End Function
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
