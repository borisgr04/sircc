Imports System.Data

Partial Class Contratos_GDocumentos_Designacion
    Inherits PaginaComun


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString.Count > 0 Then
                querystringSeguro = Me.GetRequest()
                Dim Ncont As String = ""
                Dim NAdic As String = ""

                Ncont = querystringSeguro("Nro_Cto")
                NAdic = querystringSeguro("Nro_Adi")
                hdNumero.Value = Ncont

                Dim oC As New Contratos
                Dim oSubTip As New SubTipos
                Dim oD As New Dependencias
                Dim oCDP As New CDP_Contratos
                Dim oAddCto As New AdicionesOficios
                Dim t As New Terceros


                Dim dt As DataTable = oC.GetByPk(Ncont)
                Dim dtDN As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_CON"))
                Dim dtDD As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_PCON"))
                Dim dtCDP As DataTable = oCDP.GetRecords(Ncont)
                Dim dtAddCto As DataTable = oAddCto.GetPk(NAdic)
                Dim strPlantilla As String = ltPlantilla.Text
                Dim fecha As String = DateTime.Now.ToLongDateString()

                If dtCDP.Rows.Count = 0 Then
                    strPlantilla = "El contrato no tiene CDP Asignado"
                ElseIf dt.Rows.Count = 0 Or dtAddCto.Rows.Count = 0 Then
                    ltPlantilla.Text = "No se encontro número de Contrato o la adición"
                Else
                   
                    Dim dtSubTip As DataTable = oSubTip.GetbyPk(dt.Rows(0)("STIP_CON").ToString())
                    Dim NomSubTip As String = ""
                    If dtSubTip.Rows.Count > 0 Then
                        NomSubTip = dtSubTip.Rows(0)("NOM_STIP")
                    End If

                    strPlantilla = strPlantilla.Replace("{OBJETO}", dt.Rows(0)("OBJ_CON").ToString())
                    strPlantilla = strPlantilla.Replace("{NUMERO}", dtAddCto.Rows(0)("NRO_ADI").ToString())
                    strPlantilla = strPlantilla.Replace("{CLASE_CONTRATO}", dt.Rows(0)("NOM_STIP").ToString())
                    strPlantilla = strPlantilla.Replace("{FECHA}", dtAddCto.Rows(0)("fec_sus_adi").ToLongDateString())
                    strPlantilla = strPlantilla.Replace("{NOM_CONTRATISTA}", dt.Rows(0)("CONTRATISTA").ToString())

                    strPlantilla = strPlantilla.Replace("{NOM_SUPERVISOR}", dtDN.Rows(0)("nom_ter").ToString())
                    strPlantilla = strPlantilla.Replace("{CAR_SUPERVISOR}", dtDN.Rows(0)("cargo_enc").ToString())
                    strPlantilla = strPlantilla.Replace("{DEP_SUPERVISOR}", dtDN.Rows(0)("NOM_DEP").ToString())

                    strPlantilla = strPlantilla.Replace("{NOM_ENC_DEPENDENCIAD}", dtDD.Rows(0)("nom_ter").ToString())
                    strPlantilla = strPlantilla.Replace("{CAR_ENC_DEPENDENCIAD}", dtDD.Rows(0)("cargo_enc").ToString())

                    Dim dtT As DataTable = t.GetByUser()
                    Dim NomUsu As String = ""
                    If dtT.Rows.Count > 0 Then
                        NomUsu = dtT.Rows(0)("NOM_TER")
                    End If
                    strPlantilla = strPlantilla.Replace("{NOM_USUARIO}", NomUsu)

                   



                End If
                ltPlantilla.Text = strPlantilla

            End If
        End If
    End Sub

    Protected Sub IBtnAtras_Click(sender As Object, e As ImageClickEventArgs) Handles IBtnAtras.Click
        Response.Redirect("/Contratos/GDocumentos/OficiosAdiciones.aspx?Numero=" + hdNumero.Value)
    End Sub
End Class
