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


            'If CInt(Vigencia) >= 2012 Then
            Me.Conectar() '

            querystring = "Select * From VCDP_DEP_CLASE_2012 where nro_cdp In (" + LstCdp + ")"
            'querystring = "Select * From VCDP_DEP_CLASE_2012 where nro_cdp=:nro_cdp "

            Me.CrearComando(querystring)
            'Me.AsignarParametroCadena(":nro_cdp", LstCdp)
            'Throw New Exception(Me.vComando.CommandText)
            dataTb = Me.EjecutarConsultaDataTable()
            Me.Desconectar()
        End If
        'End If
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCdp_Dep(ByVal Vigencia As String, ByVal LstCdp As String) As DataTable
        Dim dataTb As New DataTable
        If Not String.IsNullOrEmpty(LstCdp) Then
            'If CInt(Vigencia) >= 2012 Then
            Me.Conectar() '

            querystring = "Select * From VCDP_DEP_2012 where nro_cdp In (" + LstCdp + ")"
            'querystring = "Select * From VCDP_DEP_CLASE_2012 where nro_cdp=:nro_cdp "
            Me.CrearComando(querystring)
            'Me.AsignarParametroCadena(":nro_cdp", LstCdp)
            'Throw New Exception(Me.vComando.CommandText)
            dataTb = Me.EjecutarConsultaDataTable()
            Me.Desconectar()
        End If
        'End If
        Return dataTb

    End Function


End Class
