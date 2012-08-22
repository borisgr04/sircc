Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data


Public Class Alert_Contratos
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Tipo_Alerta As String, ByVal dias As Integer, ByVal Vigencia As String) As DataTable
        Me.Conectar()
        Dim dataTb As DataTable = New DataTable
        'Se valida con la fecha probable de finalización
        Select Case Tipo_Alerta
            Case "CxT"
                querystring = "SELECT * FROM vAlertContratos Where estado In ('EN EJECUCIÓN','SUSPENDIDO','SUSCRITO') And FECHAFINALPROB <= (sysdate+ :dias ) and vig_con = :vigencia "
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":dias", dias)
                Me.AsignarParametroCadena(":vigencia", Vigencia)
                dataTb = Me.EjecutarConsultaDataTable()
            Case "CxL"
                querystring = "SELECT * FROM vAlertContratos Where estado In ('TERMINADO') And (FECHAFINAL + 120) <= (sysdate+ :dias ) and vig_con = :vigencia "
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":dias", dias)
                Me.AsignarParametroCadena(":vigencia", Vigencia)
                dataTb = Me.EjecutarConsultaDataTable()
                'Case "PxV"
                '    querystring = "SELECT vpc.*,cod_con numero   FROM vpolizas_contrato VPC INNER JOIN   valertcontratos VA ON VA.numero=VPC.COD_CON AND estado NOT IN ('SUSCRITO','TERMINADO') AND vig_con = :vigencia WHERE fec_pol <= (SYSDATE + :dias)"
                '    'querystring = "Select * from vPolizas_Contrato where fec_pol <= (sysdate + :dias) and Cod_Con In (SELECT va.numero FROM valertcontratos va  WHERE va.estado not IN ('TERMINADO') and va.vig_con = :vigencia)"
                '    Me.CrearComando(querystring)
                '    'Throw New Exception(Me.querystring)
                '    Me.AsignarParametroCadena(":dias", dias)
                '    Me.AsignarParametroCadena(":vigencia", Vigencia)
                '    dataTb = Me.EjecutarConsultaDataTable()
        End Select



        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAlert_Polizas(ByVal dias As Integer, ByVal Vigencia As String) As DataTable
        Me.Conectar()
        Dim dataTb As DataTable = New DataTable
        'Se valida con la fecha probable de finalización
        querystring = "SELECT vpc.*,cod_con numero   FROM vpolizas_contrato VPC INNER JOIN   valertcontratos VA ON VA.numero=VPC.COD_CON AND estado NOT IN ('SUSCRITO','TERMINADO') AND vig_con = :vigencia WHERE fec_pol <= (SYSDATE + :dias)"
        'querystring = "Select * from vPolizas_Contrato where fec_pol <= (sysdate + :dias) and Cod_Con In (SELECT va.numero FROM valertcontratos va  WHERE va.estado not IN ('TERMINADO') and va.vig_con = :vigencia)"
        Me.CrearComando(querystring)
        'Throw New Exception(Me.querystring)
        Me.AsignarParametroCadena(":dias", dias)
        Me.AsignarParametroCadena(":vigencia", Vigencia)
        dataTb = Me.EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetExp_Alert(ByVal Tipo_Alerta As String, ByVal dias As Integer, ByVal Vigencia As String) As DataTable
        Me.Conectar()
        Dim dataTb As DataTable = New DataTable
        'Se valida con la fecha probable de finalización
        Msg = Tipo_Alerta
        Select Case Tipo_Alerta
            Case "CxT"
                querystring = "SELECT * FROM vContratos_Sinc Where Numero In (SELECT Numero FROM vAlertContratos Where estado In ('EN EJECUCIÓN','SUSPENDIDO','SUSCRITO') And FECHAFINALPROB <= (sysdate+ :dias ) and vig_con = :vigencia )"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":dias", dias)
                Me.AsignarParametroCadena(":vigencia", Vigencia)
                'Msg = Me.vComando.CommandText
                dataTb = Me.EjecutarConsultaDataTable()

            Case "CxL"
                querystring = "SELECT * FROM vContratos_Sinc Where Numero In (SELECT Numero FROM vAlertContratos Where estado In ('TERMINADO') And (FECHAFINAL + 120) <= (sysdate+ :dias ) and vig_con = :vigencia )"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":dias", dias)
                Me.AsignarParametroCadena(":vigencia", Vigencia)
                'Msg = Me.vComando.CommandText
                dataTb = Me.EjecutarConsultaDataTable()
                'Case "PxV"
                '    querystring = "SELECT vpc.*,cod_con numero   FROM vpolizas_contrato VPC INNER JOIN   valertcontratos VA ON VA.numero=VPC.COD_CON AND estado NOT IN ('SUSCRITO','TERMINADO') AND vig_con = :vigencia WHERE fec_pol <= (SYSDATE + :dias)"
                '    'querystring = "Select * from vPolizas_Contrato where fec_pol <= (sysdate + :dias) and Cod_Con In (SELECT va.numero FROM valertcontratos va  WHERE va.estado not IN ('TERMINADO') and va.vig_con = :vigencia)"
                '    Me.CrearComando(querystring)
                '    'Throw New Exception(Me.querystring)
                '    Me.AsignarParametroCadena(":dias", dias)
                '    Me.AsignarParametroCadena(":vigencia", Vigencia)
                '    dataTb = Me.EjecutarConsultaDataTable()
        End Select
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetExp_Alert_Polizas(ByVal dias As Integer, ByVal Vigencia As String) As DataTable
        Me.Conectar()
        Dim dataTb As DataTable = New DataTable
        'Se valida con la fecha probable de finalización
        querystring = "SELECT * FROM vContratos_Sinc Where Numero In (SELECT numero   FROM vpolizas_contrato VPC INNER JOIN   valertcontratos VA ON VA.numero=VPC.COD_CON AND estado NOT IN ('SUSCRITO','TERMINADO') AND vig_con = :vigencia WHERE fec_pol <= (SYSDATE + :dias))"
        'querystring = "Select * from vPolizas_Contrato where fec_pol <= (sysdate + :dias) and Cod_Con In (SELECT va.numero FROM valertcontratos va  WHERE va.estado not IN ('TERMINADO') and va.vig_con = :vigencia)"
        Me.CrearComando(querystring)
        'Throw New Exception(Me.querystring)
        Me.AsignarParametroCadena(":dias", dias)
        Me.AsignarParametroCadena(":vigencia", Vigencia)
        dataTb = Me.EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal numero As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vContratos_Sinc Where  numero =:numero "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":numero", numero)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

End Class


