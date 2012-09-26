Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class RptEstMes
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMesDepClase(ByVal Vigencia As String) As DataTable

        Dim dataTb As New DataTable
        Me.Conectar() '
        querystring = "SELECT to_char(fec_sus_con,'mm')||'-'||to_char(fec_sus_con,'Month','NLS_DATE_LANGUAGE = SPANISH')Mes,dependencia,tipo||'-'||Nom_Stip Clase, Count(*) Cantidad, Sum(Valor_Total_Prop) Valor "
        querystring += "FROM vcontratos_sinc_p "
        querystring += "WHERE vig_con = :vig_con "
        querystring += " Group by to_char(fec_sus_con,'mm')||'-'||to_char(fec_sus_con,'Month','NLS_DATE_LANGUAGE = SPANISH'),dependencia,tipo||'-'||Nom_Stip "
        querystring += " Order by to_char(fec_sus_con,'mm')||'-'||to_char(fec_sus_con,'Month','NLS_DATE_LANGUAGE = SPANISH'),dependencia,tipo||'-'||Nom_Stip "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":vig_con", Vigencia)
        dataTb = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMesDepMod(ByVal Vigencia As String) As DataTable

        Dim dataTb As New DataTable
        Me.Conectar() '
        querystring = "SELECT to_char(fec_sus_con,'mm')||'-'||to_char(fec_sus_con,'Month','NLS_DATE_LANGUAGE = SPANISH')Mes,dependencia,Nom_TProc Modalidad, Count(*) Cantidad, Sum(Valor_Total_Prop) Valor "
        querystring += "   FROM vcontratos_sinc_p "
        querystring += "WHERE vig_con = :vig_con "
        querystring += " Group by to_char(fec_sus_con,'mm')||'-'||to_char(fec_sus_con,'Month','NLS_DATE_LANGUAGE = SPANISH'),dependencia,Nom_TProc "
        querystring += " Order by to_char(fec_sus_con,'mm')||'-'||to_char(fec_sus_con,'Month','NLS_DATE_LANGUAGE = SPANISH'),dependencia,Nom_TProc "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":vig_con", Vigencia)
        dataTb = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMesDep(ByVal Vigencia As String) As DataTable

        Dim dataTb As New DataTable
        Me.Conectar() '
        querystring = "SELECT to_char(fec_sus_con,'mm')||'-'||to_char(fec_sus_con,'Month','NLS_DATE_LANGUAGE = SPANISH')Mes,dependencia, Count(*) Cant, Sum(Valor_Total_Prop) Valor "
        querystring += "   FROM vcontratos_sinc_p "
        querystring += "WHERE vig_con = :vig_con "
        querystring += " Group by to_char(fec_sus_con,'mm')||'-'||to_char(fec_sus_con,'Month','NLS_DATE_LANGUAGE = SPANISH'),dependencia "
        querystring += " Order by to_char(fec_sus_con,'mm')||'-'||to_char(fec_sus_con,'Month','NLS_DATE_LANGUAGE = SPANISH'),dependencia "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":vig_con", Vigencia)
        dataTb = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
End Class
