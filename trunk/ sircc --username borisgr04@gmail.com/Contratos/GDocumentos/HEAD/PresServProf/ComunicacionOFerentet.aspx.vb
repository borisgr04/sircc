Imports System.Data
Partial Class Contratos_GDocumentos_HEAD_PresServProf_ComunicacionOFerentet
    Inherits PaginaComun

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Request.QueryString.Count > 0 Then
                Dim Direc As String = ""
                Dim Plazo As String = ""
                Dim Tel As String = ""
                Dim Ncont As String = ""
                Dim NomUsu As String = ""
                Dim NomCotista As String = ""
                Dim strPlantilla As String = ltPlantilla.Text
                Dim oC As New GProcesos
                Dim t As New Terceros
                Dim OAdj As New GPProponentes

                Ncont = Request.QueryString("Nro_Cto")
                hdNumero.Value = Ncont
                Dim dt As DataTable = oC.GetByPk(Ncont, "1")

                If dt.Rows.Count = 0 Then
                    ltPlantilla.Text = "No se encontro número de proceso"

                Else

                    Dim dtT As DataTable = t.GetByUser()
                    Dim dtCont As DataTable = OAdj.GetbyAdjudicado(Ncont, "1")


                    If dtCont.Rows.Count > 0 Then
                        NomCotista = dtCont.Rows(0)("RAZON_SOCIAL")
                        Direc = dtCont.Rows(0)("DIR_PROP")
                        tel = dtCont.Rows(0)("TEL_PROP")
                    Else
                        NomCotista = "No Se ha adjudicado el proceso"
                    End If
                    If dtT.Rows.Count > 0 Then
                        NomUsu = dtT.Rows(0)("NOM_TER")
                    Else
                        NomUsu = "No hay usuario"

                    End If

                    If dt.Rows(0)("TIPO_PLAZO").ToString() = "M" Then
                        Plazo = dt.Rows(0)("PLA_EJE_CON").ToString() + " Meses"
                    ElseIf dt.Rows(0)("TIPO_PLAZO").ToString() = "D" Then
                        Plazo = dt.Rows(0)("PLA_EJE_CON").ToString() + " Dias"
                    ElseIf dt.Rows(0)("TIPO_PLAZO").ToString() = "A" Then
                        Plazo = dt.Rows(0)("PLA_EJE_CON").ToString() + " Años"
                    Else
                        Plazo = "No se ha especificado el Plazo de ejecución"
                    End If
                    If dt.Rows(0)("TIPO_PLAZO2").ToString() <> "" Then
                        If dt.Rows(0)("TIPO_PLAZO2").ToString() = "M" Then
                            Plazo += " y " + dt.Rows(0)("PLAZO2_EJE_CON").ToString() + " Meses"
                        ElseIf dt.Rows(0)("TIPO_PLAZO2").ToString() = "D" Then
                            Plazo += " y " + dt.Rows(0)("PLAZO2_EJE_CON").ToString() + " Dias"
                        ElseIf dt.Rows(0)("TIPO_PLAZO2").ToString() = "A" Then
                            Plazo += " y " + dt.Rows(0)("PLAZO2_EJE_CON").ToString() + " Años"
                        End If

                    End If
                    strPlantilla = strPlantilla.Replace("{OBJETO}", dt.Rows(0)("OBJ_CON").ToString())
                    strPlantilla = strPlantilla.Replace("{NOM_CONTRATISTA}", NomCotista.ToUpper())
                    strPlantilla = strPlantilla.Replace("{DIRECCION}", Direc)
                    strPlantilla = strPlantilla.Replace("{TELEFONO}", Tel)
                    strPlantilla = strPlantilla.Replace("{VALOR_A_CONTRATAR}", String.Format("{0:$#,###.##}", dt.Rows(0)("VAL_CON")))
                    strPlantilla = strPlantilla.Replace("{PLAZO}", Plazo)

                    ltPlantilla.Text = strPlantilla

                    End If
            End If
            End If
    End Sub

End Class
