Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

''Control del reporte cdp_dep_cant_valor enlazado con SIIAF, 
'' Requiere vista por cada nuevo año
<DataObjectAttribute()> _
Public Class Rpt_Cdp_Dep
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCdp_Dep_Clase(ByVal Vigencia As String, ByVal LstCdp As String) As DataTable
        Dim dataTb As New DataTable
        If Not String.IsNullOrEmpty(LstCdp) Then
            Me.Conectar() '
            If Vigencia = "2012" Then
                querystring = "Select * From VCDP_DEP_CLASE_2012 where nro_cdp In (" + LstCdp + ")"
            ElseIf Vigencia = "2013" Then
                querystring = "Select * From VCDP_DEP_CLASE_2013 where nro_cdp In (" + LstCdp + ")"
            End If

            Me.CrearComando(querystring)
            dataTb = Me.EjecutarConsultaDataTable()
            Me.Desconectar()
        End If
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCdp_Dep(ByVal Vigencia As String, ByVal LstCdp As String) As DataTable
        Dim dataTb As New DataTable
        If Not String.IsNullOrEmpty(LstCdp) Then
            'If CInt(Vigencia) >= 2012 Then
            Me.Conectar() '
            If Vigencia = "2012" Then
                querystring = "Select * From VCDP_DEP_CLASE_2012 where nro_cdp In (" + LstCdp + ")"
            ElseIf Vigencia = "2013" Then
                querystring = "Select * From VCDP_DEP_CLASE_2013 where nro_cdp In (" + LstCdp + ")"
            End If
            Me.CrearComando(querystring)
            dataTb = Me.EjecutarConsultaDataTable()
            Me.Desconectar()
        End If
        Return dataTb

    End Function


End Class
