Imports System.Data

Partial Class Contratos_GDocumentos_Designacion
    Inherits PaginaComun


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Request.QueryString.Count > 0 Then
                    Dim Ncont As String = ""
                    querystringSeguro = Me.GetRequest()
                    Ncont = querystringSeguro("Nro_Cto")
                    hdNumero.Value = Ncont

                    Dim NomUsu As String = ""
                    Dim NOM_SUPERVISOR As String
                    Dim CAR_SUPERVISOR As String
                    Dim DEP_SUPERVISOR As String = ""
                    Dim NOM_ENC_DEPENDENCIAD As String
                    Dim CAR_ENC_DEPENDENCIAD As String

                    Dim oC As New Contratos
                    Dim oD As New Dependencias
                    Dim t As New Terceros
                    Dim int As New Interventores_Contrato

                    Dim dt As DataTable = oC.GetByPk(Ncont)
                    Dim dtDN As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_CON"))
                    Dim dtDD As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_PCON"))
                    Dim dtT As DataTable = t.GetByUser()
                    Dim dtInt As DataTable = int.GetRecordsAC(Ncont)


                    If dt.Rows.Count = 0 Then
                        ltPlantilla.Text = "No se encontro el número de Contrato"
                    Else


                        If dtInt.Rows.Count > 0 Then
                            NOM_SUPERVISOR = dtInt.Rows(0)("NOM_TER").ToString()
                            CAR_SUPERVISOR = "Profesional Universitario"
                            If dtDN.Rows.Count > 0 Then
                                DEP_SUPERVISOR = dtDN.Rows(0)("NOM_DEP").ToString()
                            End If
                        Else
                            If dtDN.Rows.Count > 0 Then
                                NOM_SUPERVISOR = dtDN.Rows(0)("nom_ter").ToString()
                                CAR_SUPERVISOR = dtDN.Rows(0)("cargo_enc").ToString()
                                DEP_SUPERVISOR = dtDN.Rows(0)("NOM_DEP").ToString()
                            Else
                                NOM_SUPERVISOR = "No se ha designado Supervisor"
                                CAR_SUPERVISOR = "No se ha designado Supervisor"
                                DEP_SUPERVISOR = "No se ha designado Supervisor"
                            End If

                        End If



                        If dtDN.Rows.Count > 0 Then
                            NOM_ENC_DEPENDENCIAD = dtDD.Rows(0)("nom_ter").ToString()
                            CAR_ENC_DEPENDENCIAD = dtDD.Rows(0)("cargo_enc").ToString()
                        Else
                            NOM_ENC_DEPENDENCIAD = "No hay encargado"
                            CAR_ENC_DEPENDENCIAD = "No hay encargado"

                        End If

                        If dtT.Rows.Count > 0 Then
                            NomUsu = dtT.Rows(0)("NOM_TER")
                        Else
                            NomUsu = "No hay usuario"
                        End If



                        Dim strPlantilla As String = ltPlantilla.Text

                        Dim fecha As String = DateTime.Now.ToLongDateString()

                        strPlantilla = strPlantilla.Replace("{OBJETO}", dt.Rows(0)("OBJ_CON").ToString())
                        strPlantilla = strPlantilla.Replace("{NUMERO}", dt.Rows(0)("Numero").ToString())
                        Dim Clase As String = dt.Rows(0)("TIPO").ToString() + " " + dt.Rows(0)("NOM_STIP").ToString()
                        strPlantilla = strPlantilla.Replace("{CLASE_CONTRATO}", StrConv(Clase, VbStrConv.ProperCase))
                        strPlantilla = strPlantilla.Replace("{VALOR_A_CONTRATAR}", dt.Rows(0)("VAL_CON").ToString())
                        strPlantilla = strPlantilla.Replace("{FECHA}", dt.Rows(0)("FEC_APR_POL").ToLongDateString())
                        strPlantilla = strPlantilla.Replace("{NOM_CONTRATISTA}", dt.Rows(0)("CONTRATISTA").ToString())

                        strPlantilla = strPlantilla.Replace("{NOM_SUPERVISOR}", NOM_SUPERVISOR)
                        strPlantilla = strPlantilla.Replace("{CAR_SUPERVISOR}", CAR_SUPERVISOR)
                        strPlantilla = strPlantilla.Replace("{DEP_SUPERVISOR}", DEP_SUPERVISOR)

                        strPlantilla = strPlantilla.Replace("{NOM_ENC_DEPENDENCIAD}", NOM_ENC_DEPENDENCIAD)
                        strPlantilla = strPlantilla.Replace("{CAR_ENC_DEPENDENCIAD}", CAR_ENC_DEPENDENCIAD)


                        strPlantilla = strPlantilla.Replace("{NOM_USUARIO}", StrConv(NomUsu, VbStrConv.ProperCase))



                        ltPlantilla.Text = strPlantilla '+ hdNumero.Value


                        End If


                End If
            End If

        Catch ex As Exception
            Me.MsgResult.Text = ex.Message + "..." + ex.StackTrace
            Me.MsgBox(Me.MsgResult, False)
        End Try
    End Sub

    Protected Sub IBtnAtras_Click(sender As Object, e As ImageClickEventArgs) Handles IBtnAtras.Click
        Response.Redirect("/Contratos/GDocumentos/OficiosGral.aspx?Numero=" + hdNumero.Value)
    End Sub
End Class
