Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class RptSireci
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetInfSireci(ByVal Fec_ini As String, ByVal Fec_Fin As String) As DataTable
        Dim dataTb As New DataTable
        If Not String.IsNullOrEmpty(Fec_Fin) And Not String.IsNullOrEmpty(Fec_ini) Then
            Me.Conectar()
            Try
                querystring = "SELECT '1 ADMINISTRACIÓN CENTRAL' AS DEPENDENCIA,  numero AS NUMCTO, TRIM (contratista) AS NOMBRE, ide_con AS NIT,"
                querystring += "DECODE (validardigitochequeonit (ide_con), '0', '1 DV 0', '1', '2 DV 1', '2', '3 DV 2', '3', '4 DV 3', '4', '5 DV 4', '5', '6 DV 5','6', '7 DV 6','7', '8 DV 7', '8', '9 DV 8','9', '10 DV 9') AS DV,"
                querystring += " REPLACE (REPLACE (obj_con, CHR (13) || CHR (10), ' '), CHR (9),  ' ' ) AS OBJETO,"
                querystring += " CASE  WHEN nom_stip = 'PRESTACION DE SERVICIOS PROFESIONALES' THEN '1 PRESTACIÓN DE SERVICIOS PROFESIONALES'  WHEN nom_stip = 'APRENDIZAJE' THEN '4 CONTRATO DE APRENDIZAJE' WHEN nom_stip = 'PRESTACION DE SERVICIOS' AND per_apo = '1' THEN '2 PRESTACIÓN DE SERVICIOS DE APOYO A LA GESTIÓN'  Else '2 PRESTACIÓN DE SERVICIOS DE APOYO A LA GESTIÓN' END AS TIPO,"
                querystring += " ' ' AS SEGMENTO, TO_char(fec_sus_con , 'YYYY/MM/DD') AS FECSUSCRIPCION, TO_char(fechafinal , 'YYYY/MM/DD') AS FECHAFINAL,"
                querystring += " val_con AS VAL_INI_CON, VAL_ADI , VALOR_TOTAL_DOC AS VALOR_TOTAL,"
                querystring += " (Select Nvl(Sum(Val_Pago),0) Pago From EstContratos Where Cod_Con=c.Numero And Estado='AC')  AS VALOR_PAGADO,"
                querystring += " DECODE (sector, 'FUNCIONAMIENTO', '2 DE APOYO', '----- o -----', '----- o -----', '1 MISIONAL' ) AS FUNCION,"
                querystring += "DECODE (sector, 'FUNCIONAMIENTO', '2 FUNCIONAMIENTO','----- o -----', '----- o -----','1 INVERSIÓN') AS TIPOGASTO,"
                querystring += "'' AS OBSERVACION FROM vcontratos_sinc_p c WHERE (nom_stip LIKE '%PRESTACI%' OR nom_stip LIKE '%APRENDI%')  and (fec_sus_con between to_date('" + Fec_ini + "','dd/mm/yyyy') and to_date('" + Fec_Fin + "','dd/mm/yyyy'))"
                Me.CrearComando(querystring)
                dataTb = Me.EjecutarConsultaDataTable()
                Me.Desconectar()
            Catch ex As Exception
                Msg = ex.Message
            End Try
        Else

        End If
        Return dataTb
    End Function
End Class
