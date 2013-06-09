Option Explicit On
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data


Public Class CContratos

    Private ctx As New BDDatosG

    Public Function GetRecords(cFil As vContratosInt) As DataTable
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

        If cFil.Objeto <> "" Then
            f = Util.AddFiltro(f, " Upper(Obj_Con) Like  '%" + cFil.Objeto.ToUpper + "%'")
        End If

        ctx.Conectar()
        Dim querystring As String = "Select Numero, Tipo,Obj_Con, Ide_Con, Contratista, Dependencia,Dependenciap,Estado,Fec_Sus_Con,Val_Apo_Gob,Val_otros,Id_Interventor, Nom_Interventor, Tip_Con, STip_Con,Dep_Con, DEp_pcon From vcontratos_Sinc_p Where " + f
        ctx.CrearComando(querystring)

        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function
End Class
