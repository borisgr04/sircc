Imports Microsoft.VisualBasic
Imports System.Data

Public Class GesCConsolidados
    Private ctx As New BDDatosG

    Public Function GetConsolidadTC(cFil As vContratosInt) As DataTable
        Dim f As String = cFil.Filtrar()
        ctx.Conectar()
        Dim querystring As String = "SELECT Lower(Estado) Estado, Count(*) Cantidad  FROM vcontratos_sinc_p  WHERE " + f + "   group by Estado "
        ctx.CrearComando(querystring)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function
    Public Function GetDetalleTotal(cFil As vContratosInt) As Integer
        Dim f As String = cFil.Filtrar()
        Dim querystring As New StringBuilder
        querystring.Append("SELECT Count(*) Cantidad FROM vcontratos_sinc_p ")
        querystring.Append(" where ")
        querystring.Append(f)
        ctx.Conectar()
        ctx.CrearComando(querystring.ToString)
        Dim c As Integer = CInt(ctx.EjecutarEscalar())
        ctx.Desconectar()
        Return c
    End Function
    Public Function GetDetalle(cFil As vContratosInt, Pagenum As Integer, Pagesize As Integer) As DataTable
        Dim f As String = cFil.Filtrar()
        ctx.Conectar()
        Dim querystring As New StringBuilder
        querystring.Append("SELECT numero,  to_char(fec_sus_con,'dd/mm/yyyy') fec_sus_con,")
        querystring.Append("To_Char(NVL(fechainicio, NVL(fec_apr_pol, fec_sus_con)),'dd/mm/yyyy') FechaInicio,")
        querystring.Append(" tiempoejecutado (numero) diasejecutados, plazo_total,")
        querystring.Append(" pla_eje_con, plazo_adicion_dias (numero) adicion,")
        querystring.Append(" suspencion (numero) suspension,")
        querystring.Append(" plazo_total+ suspencion (numero) total_dias,")
        querystring.Append(" Dependencia, estado,  vig_con,")
        querystring.Append(" contratista ")
        querystring.Append(" FROM vcontratos_sinc_p ")
        querystring.Append(" where ")
        querystring.Append(f)

        Dim queryM As New StringBuilder
        queryM.Append("Select * From (")
        queryM.Append(querystring)
        queryM.Append(")")
        queryM.Append("Where ROWNUM<" + ((Pagenum + 1) * Pagesize).ToString)
        queryM.Append(" Minus ")
        queryM.Append("Select * From (")
        queryM.Append(querystring)
        queryM.Append(")")
        queryM.Append("Where ROWNUM<" + (Pagenum * Pagesize).ToString)

        ctx.CrearComando(queryM.ToString)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        ' Create third column
        Dim FP = New DataColumn
        With FP
            .DataType = System.Type.GetType("System.String")
            .ColumnName = "FECHAFINALPROB"
        End With
        Dim FPxt = New DataColumn
        With FPxt
            .DataType = System.Type.GetType("System.Boolean")

            .ColumnName = "POR_TERMINAR"
        End With
        dataTb.Columns.Add(FP)
        dataTb.Columns.Add(FPxt)

        For Each dtr As DataRow In dataTb.Rows
            Try
                'dtr("FECHAFINALPROB") = CDate(dtr("FechaInicio")).AddDays(CInt(dtr("TOTAL_DIAS"))).ToShortDateString
                'dtr("POR_TERMINAR") = CDate(dtr("FechaInicio")).AddDays(CInt(dtr("TOTAL_DIAS"))) < Now.AddDays(10)
            Catch ex As Exception
                Dim m As String = ex.Message
            End Try
        Next

        Return dataTb
    End Function
    Public Function GetDetalleXML(cFil As vContratosInt, Pagenum As Integer, Pagesize As Integer) As String
        Dim lec As New List(Of cEstCan)
        Dim dataTb As DataTable = GetDetalle(cFil, Pagenum, Pagesize)
        Dim writer As New System.IO.StringWriter()
        dataTb.WriteXml(writer, XmlWriteMode.WriteSchema, False)
        Return writer.ToString()
    End Function

    Public Function GetDetalle(cFil As vContratosInt) As DataTable
        Dim f As String = cFil.Filtrar()
        ctx.Conectar()
        Dim querystring As New StringBuilder
        querystring.Append("SELECT numero,  to_char(fec_sus_con,'dd/mm/yyyy') fec_sus_con,")
        querystring.Append("To_Char(NVL(fechainicio, NVL(fec_apr_pol, fec_sus_con)),'dd/mm/yyyy') FechaInicio,")
        querystring.Append(" tiempoejecutado (numero) diasejecutados, plazo_total,")
        querystring.Append(" pla_eje_con, plazo_adicion_dias (numero) adicion,")
        querystring.Append(" suspencion (numero) suspension,")
        querystring.Append(" plazo_total+ suspencion (numero) total_dias,")
        querystring.Append(" Dependencia, estado,  vig_con,")
        querystring.Append(" contratista ")
        querystring.Append(" FROM vcontratos_sinc_p ")
        querystring.Append(" where ")
        querystring.Append(f)


        ctx.CrearComando(querystring.ToString)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        ' Create third column
        Dim FP = New DataColumn
        With FP
            .DataType = System.Type.GetType("System.String")
            .ColumnName = "FECHAFINALPROB"
        End With
        Dim FPxt = New DataColumn
        With FPxt
            .DataType = System.Type.GetType("System.Boolean")

            .ColumnName = "POR_TERMINAR"
        End With
        dataTb.Columns.Add(FP)
        dataTb.Columns.Add(FPxt)

        For Each dtr As DataRow In dataTb.Rows
            Try
                dtr("FECHAFINALPROB") = CDate(dtr("FechaInicio")).AddDays(CInt(dtr("TOTAL_DIAS"))).ToShortDateString
                dtr("POR_TERMINAR") = CDate(dtr("FechaInicio")).AddDays(CInt(dtr("TOTAL_DIAS"))) < Now.AddDays(10)
            Catch ex As Exception
                Dim m As String = ex.Message
            End Try
        Next

        Return dataTb
    End Function
   
    Public Function GetDetalleXML(cFil As vContratosInt) As String
        Dim lec As New List(Of cEstCan)
        Dim dataTb As DataTable = GetDetalle(cFil)
        Dim writer As New System.IO.StringWriter()
        dataTb.WriteXml(writer, XmlWriteMode.WriteSchema, False)
        Return writer.ToString()
    End Function

    Public Function GetConsolidadXML(cFil As vContratosInt) As String
        Dim lec As New List(Of cEstCan)
        Dim dataTb As DataTable = GetConsolidadTC(cFil)
        Dim writer As New System.IO.StringWriter()
        dataTb.WriteXml(writer, XmlWriteMode.WriteSchema, False)
        Return writer.ToString()
    End Function

    Public Function GetConsolidadC(cFil As vContratosInt) As List(Of cEstCan)
        Dim lec As New List(Of cEstCan)
        Dim dataTb As DataTable = GetConsolidadTC(cFil)
        For Each dtr As DataRow In dataTb.Rows
            lec.Add(mapearRow(dtr))
        Next
        Return lec
    End Function

    Private Function mapearRow(dtr As DataRow) As cEstCan
        Dim e As New cEstCan
        e.Estado = dtr("Estado")
        e.Cantidad = dtr("Cantidad")
        Return e
    End Function

End Class

Public Class cEstCan
    Dim mEstado As String
    Dim mCantidad As Integer
    Property Estado As String
        Get
            Return mEstado
        End Get
        Set(value As String)
            mEstado = value
        End Set
    End Property
    Property Cantidad As Integer
        Get
            Return mCantidad
        End Get
        Set(value As Integer)
            mCantidad = value
        End Set
    End Property
End Class
