Imports System.Data
Partial Class Contratos_GDocumentos_SolicitudRPC
    Inherits PaginaComun
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Request.QueryString.Count > 0 Then
                Dim Ncont As String = ""
                querystringSeguro = Me.GetRequest()
                Ncont = querystringSeguro("Nro_Cto")
                hdNumero.Value = Ncont
                Dim oC As New Contratos
                Dim oD As New Dependencias
                Dim oCDP As New CDP_Contratos
                Dim t As New Terceros


             


                Dim dt As DataTable = oC.GetByPk(Ncont)
                Dim dtDN As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_CON"))
                Dim dtDD As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_PCON"))
                Dim strPlantilla As String = ltPlantilla.Text
                Dim fecha As String = DateTime.Now.ToLongDateString()

                Dim dtCDP As DataTable = oCDP.GetRecords(Ncont)
                If dtCDP.Rows.Count = 0 Then
                    strPlantilla = "El contrato no tiene CDP Asignado"
                Else
                   
                    strPlantilla = strPlantilla.Replace("{NUMERO}", dt.Rows(0)("Numero").ToString())
                    strPlantilla = strPlantilla.Replace("{VALOR_A_CONTRATAR}", String.Format("{0:$#,###.##}", dt.Rows(0)("VAL_CON")))
                    strPlantilla = strPlantilla.Replace("{VALOR_APORTE_GOB}", String.Format("{0:$0,00.00}", dt.Rows(0)("VAL_APO_GOB")))
                    strPlantilla = strPlantilla.Replace("{FECHA}", dt.Rows(0)("fec_sus_con").ToLongDateString())
                    strPlantilla = strPlantilla.Replace("{NOM_CONTRATISTA}", dt.Rows(0)("CONTRATISTA").ToString())
                    strPlantilla = strPlantilla.Replace("{DEPENDENCIA_DELEGADA}", dtDD.Rows(0)("NOM_DEP").ToString())


                    strPlantilla = strPlantilla.Replace("{NOM_ENC_DEPENDENCIAD}", dtDD.Rows(0)("nom_ter").ToString())
                    strPlantilla = strPlantilla.Replace("{CAR_ENC_DEPENDENCIAD}", dtDD.Rows(0)("cargo_enc").ToString())

                    Dim dtT As DataTable = t.GetByUser()
                    Dim NomUsu As String = ""
                    If dtT.Rows.Count > 0 Then
                        NomUsu = dtT.Rows(0)("NOM_TER")
                    End If
                    strPlantilla = strPlantilla.Replace("{NOM_USUARIO}", NomUsu)

                    Dim strTablaCDP As String = ""
                    For Each dtr As DataRow In dtCDP.Rows
                        strTablaCDP += String.Format("{0} del {1:d} -", dtr("NRO_CDP"), dtr("FEC_CDP"))
                    Next

                    strPlantilla = strPlantilla.Replace("{CDP} ", strTablaCDP)

                End If



                'strPlantilla = strPlantilla.Replace("{NOM_SUPERVISOR}", dtDN.Rows(0)("nom_ter").ToString())
                'strPlantilla = strPlantilla.Replace("{CAR_SUPERVISOR}", dtDS.Rows(0)("cargo_enc").ToString())
                'strPlantilla = strPlantilla.Replace("{DEP_SUPERVISOR}", dtDS.Rows(0)("NOM_DEP").ToString())
                ltPlantilla.Text = strPlantilla
                'GridView1.DataSource = dt
                'GridView1.DataBind()
            End If
        End If
    End Sub
    Protected Sub IBtnAtras_Click(sender As Object, e As ImageClickEventArgs) Handles IBtnAtras.Click
        Response.Redirect("/Contratos/GDocumentos/OficiosGral.aspx?Numero=" + hdNumero.Value)
    End Sub
End Class
