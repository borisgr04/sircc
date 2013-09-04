Option Explicit On
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data



Public Class CContratos

    Private ctx As New BDDatosG
    Private cFil As vContratosInt

    Public Function GetRecordsC(cFil As vContratosInt) As DataTable
        Me.cFil = cFil
        Dim f As String = Filtrar()
        ctx.Conectar()
        Dim querystring As String = "SELECT Upper(Estado) Estado, Count(*) Cantidad  FROM vcontratos_sinc_p  WHERE " + f + "   group by Estado "
        ctx.CrearComando(querystring)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function

  

    Private Function Filtrar() As String
        Dim f As String = ""

        If Not String.IsNullOrEmpty(cFil.Cod_Tip) Then
            f = Util.AddFiltro(f, " Tip_Con= '" + cFil.Cod_Tip + "'")
        End If

        If cFil.Vigencia > 0 Then
            f = Util.AddFiltro(f, " Vig_Con= '" + cFil.Vigencia.ToString + "'")
        End If

        If cFil.Ide_Contratista <> "" Then
            f = Util.AddFiltro(f, " Ide_Con= '" + cFil.Ide_Contratista + "'")
        End If

        If cFil.Ide_Interventor <> "" Then
            f = Util.AddFiltro(f, " Id_Interventor= '" + cFil.Ide_Interventor + "'")
        End If

        If cFil.Numero <> "" Then
            f = Util.AddFiltro(f, " Numero= '" + cFil.Numero + "'")
        End If

        If cFil.Dep_Del <> "" Then
            f = Util.AddFiltro(f, " Dep_pCon= '" + cFil.Dep_Del + "'")
        End If

        If cFil.Dep_Nec <> "" Then
            f = Util.AddFiltro(f, " Dep_Con= '" + cFil.Dep_Nec + "'")
        End If

        If cFil.Estado <> "" Then
            f = Util.AddFiltro(f, " Estado= '" + cFil.Estado + "'")
        End If


        f = Util.AddFiltro(f, " Estado<> 'AN'")


        If cFil.Objeto <> "" Then
            f = Util.AddFiltro(f, " Upper(Obj_Con) Like  '%" + cFil.Objeto.ToUpper + "%'")
        End If

        Return f
    End Function
    Public Function GetRecords(cFil As vContratosInt) As DataTable
        Me.cFil = cFil
        Dim f As String = Filtrar()
        ctx.Conectar()
        Dim querystring As String = "Select Numero, Tipo,Obj_Con, Ide_Con, Trim(Contratista) Contratista, Dependencia,Dependenciap,Upper(Estado) Estado,Fec_Sus_Con,Val_Apo_Gob,Val_otros,Id_Interventor, Nom_Interventor, Tip_Con, STip_Con,Dep_Con, DEp_pcon From vcontratos_Sinc_p Where " + f
        ctx.CrearComando(querystring)

        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function

    Public Function GetbyCodCon(Cod_Con As String) As EContratos
        Dim c As EContratos = Nothing
        ctx.Conectar()
        Dim querystring As String = "select * from vcontratosma where numero=:numero"
        ctx.CrearComando(querystring)
        ctx.AsignarParametroCadena(":numero", Cod_Con)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        If dataTb.Rows.Count > 0 Then
            c = New EContratos
            c.Cod_Con = dataTb.Rows(0)("Numero")
            c.Nom_Ter = dataTb.Rows(0)("Contratista")
            c.Ide_Con = dataTb.Rows(0)("Ide_Con")
            c.Obj_Con = dataTb.Rows(0)("Obj_Con")
        End If
        Return c
    End Function

End Class
