Imports System.Data
Partial Class Contratos_GDocumentos_HEAD_PresServProf_AutOrdGast
    Inherits PaginaComun

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Request.QueryString.Count > 0 Then
                Dim Ncont As String = ""
                Ncont = Request.QueryString("Nro_Cto")
                '//If Request.QueryString.Count > 0 Then

                'querystringSeguro = Me.GetRequest()
                'Ncont = querystringSeguro("Nro_Cto")
                hdNumero.Value = Ncont

                Dim NomUsu As String = ""
                Dim oC As New PContratos
                Dim oD As New Dependencias
                Dim t As New Terceros

                Dim dt As DataTable = oC.GetByPk(Ncont)
                If dt.Rows.Count = 0 Then
                    ltPlantilla.Text = "No se encontro número de proceso"
                Else
                    Dim dtDN As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_CON"))
                    Dim dtDD As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_PCON"))
                    Dim dtT As DataTable = t.GetByUser()

                    If dtT.Rows.Count > 0 Then
                        NomUsu = dtT.Rows(0)("NOM_TER")
                    Else
                        NomUsu = "No hay usuario"
                    End If


                    Dim strPlantilla As String = ltPlantilla.Text

                    Dim fecha As String = DateTime.Now.ToLongDateString()

                    strPlantilla = strPlantilla.Replace("{OBJETO}", dt.Rows(0)("OBJ_CON").ToString())
                    strPlantilla = strPlantilla.Replace("{NUMERO}", dt.Rows(0)("PRO_SEL_NRO").ToString())
                    strPlantilla = strPlantilla.Replace("{CLASE_CONTRATO}", dt.Rows(0)("TIPDOCUMENTO").ToString() + dt.Rows(0)("NOMSTIP").ToString())
                    strPlantilla = strPlantilla.Replace("{VALOR_A_CONTRATAR}", dt.Rows(0)("VAL_CON").ToString())
                    'strPlantilla = strPlantilla.Replace("{FECHA}", dt.Rows(0)("FEC_APR_POL").ToLongDateString())
                    strPlantilla = strPlantilla.Replace("{NOM_CONTRATISTA}", dt.Rows(0)("CONTRATISTA").ToString())

                    strPlantilla = strPlantilla.Replace("{NOM_SUPERVISOR}", dtDN.Rows(0)("nom_ter").ToString())
                    strPlantilla = strPlantilla.Replace("{CAR_SUPERVISOR}", dtDN.Rows(0)("cargo_enc").ToString())
                    strPlantilla = strPlantilla.Replace("{DEP_SUPERVISOR}", dtDN.Rows(0)("NOM_DEP").ToString())

                    strPlantilla = strPlantilla.Replace("{NOM_ENC_DEPENDENCIAD}", dtDD.Rows(0)("nom_ter").ToString())
                    strPlantilla = strPlantilla.Replace("{CAR_ENC_DEPENDENCIAD}", dtDD.Rows(0)("cargo_enc").ToString())


                    strPlantilla = strPlantilla.Replace("{NOM_USUARIO}", NomUsu)




                    ltPlantilla.Text = strPlantilla

                End If
            End If
            End If
    End Sub

End Class
