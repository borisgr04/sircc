﻿Imports System.Data
Partial Class Contratos_GDocumentos_HEAD_ActaRecOferta
    Inherits PaginaComun

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Request.QueryString.Count > 0 Then
                Dim Direc As String = ""
                Dim NumFol As String = ""
                Dim Tel As String = ""
                Dim Ncont As String = ""
                Dim NomUsu As String = ""
                Dim NomCotista As String = ""
                Dim strPlantilla As String = ltPlantilla.Text
                Dim oC As New GProcesos
                Dim t As New Terceros
                Dim OAdj As New GPProponentes
                Dim oD As New Dependencias

                Ncont = Request.QueryString("Nro_Cto")
                hdNumero.Value = Ncont
                Dim dt As DataTable = oC.GetByPk(Ncont, "1")
                Dim dtCont As DataTable = OAdj.GetbyAdjudicado(Ncont, "1")

                If dt.Rows.Count = 0 Then
                    ltPlantilla.Text = "No se encontro número de proceso"

                ElseIf dtCont.Rows.Count = 0 Then
                    ltPlantilla.Text = "No se ha adjudicado el procesos"
                Else
                    Dim dtT As DataTable = t.GetByUser()
                    Dim dtDN As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_CON"))
                    Dim dtDD As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_PCON"))

                    If dtT.Rows.Count > 0 Then
                        NomUsu = dtT.Rows(0)("NOM_TER")
                    Else
                        NomUsu = "No hay usuario"

                    End If


                    strPlantilla = strPlantilla.Replace("{FOLIOS}", dtCont.Rows(0)("NUM_FOLIO"))
                    strPlantilla = strPlantilla.Replace("{FECHA_ENTREGA}", dtCont.Rows(0)("FEC_REG").ToShortDateString())
                    strPlantilla = strPlantilla.Replace("{HORA_ENTREGA}", dtCont.Rows(0)("FEC_REG").ToShortTimeString())
                    strPlantilla = strPlantilla.Replace("{NOM_CONTRATISTA}", dtCont.Rows(0)("RAZON_SOCIAL").ToUpper())

                    strPlantilla = strPlantilla.Replace("{OBJETO}", dt.Rows(0)("OBJ_CON").ToString())
                    strPlantilla = strPlantilla.Replace("{VALOR_A_CONTRATAR}", String.Format("{0:$#,###.##}", dt.Rows(0)("VAL_CON")))


                    strPlantilla = strPlantilla.Replace("{NOM_SUPERVISOR}", dtDN.Rows(0)("nom_ter").ToString())
                    strPlantilla = strPlantilla.Replace("{CAR_SUPERVISOR}", dtDN.Rows(0)("cargo_enc").ToString())
                    strPlantilla = strPlantilla.Replace("{DEP_SUPERVISOR}", dtDN.Rows(0)("NOM_DEP").ToString())
                    ltPlantilla.Text = strPlantilla

                End If
        End If
        End If
    End Sub
End Class