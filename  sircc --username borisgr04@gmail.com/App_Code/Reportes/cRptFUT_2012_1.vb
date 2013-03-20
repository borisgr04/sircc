Imports Microsoft.VisualBasic
Imports System.Data

Public Class cRptFUT_2012_1
    Implements IReportes

    Dim mFiltro As String


  Public Property Filtro As String Implements IReportes.Filtro
        Get
            Return mFiltro
        End Get
        Set(value As String)
            mFiltro = value
        End Set
    End Property

    Public Function GenerarReporte() As String Implements IReportes.GenerarReporte
        Dim strSql As String
        strSql = " Select * From vFUT2012_01 "
        strSql += " WHERE numero LIKE '2012%' "
        'If (ChkFecSus.Checked = True) Then
        'strSql += " AND FEC_SUS_CON BETWEEN TO_DATE('" + CDate(TxtFecSus1.Text).ToShortDateString + "','dd/mm/yyyy') AND to_date('" + CDate(TxtFecSus2.Text).ToShortDateString + "','dd/mm/yyyy')"
        'End If
        If Not String.IsNullOrEmpty(Filtro) Then
            strSql += " And Numero In ( Select Numero FROM vcontratos_Sinc_p c  " + Filtro + " )"
        End If

        strSql += " And substr(trim(cod_rub),-2) In (Select Recursos from rec_reg WHERE VIGENCIA=2012 AND TIP_REC='REG')"
        'strSql += " AND valorxrp > 0"
        'strSql += " AND valregalias2012 (nro_rp, cod_rub)>0   "
        strSql += " ORDER BY numero"

        Return strSql
    End Function
End Class
