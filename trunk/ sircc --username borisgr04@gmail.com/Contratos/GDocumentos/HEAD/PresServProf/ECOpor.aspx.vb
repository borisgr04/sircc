
Imports System.Data
Partial Class Contratos_GDocumentos_HEAD_PresServProf_ECOpor
    Inherits PaginaComun

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Request.QueryString.Count > 0 Then
                Dim Direc As String = ""
                Dim Plazo As String = ""
                Dim Car_Fun As String = ""
                Dim Tel As String = ""
                Dim Ncont As String = ""
                Dim NomUsu As String = ""
                Dim NumCto As String = ""
                Dim NomCotista As String = ""
                Dim strPlantilla As String = ltPlantilla.Text
                Dim oC As New GProcesos
                Dim t As New Terceros
                Dim OAdj As New GPProponentes
                Dim oOblig As New GPObligaciones
                Dim oD As New Dependencias
                Dim oCont As New Contratos

                Ncont = Request.QueryString("Nro_Cto")
                hdNumero.Value = Ncont
                Dim dt As DataTable = oC.GetByPkC(Ncont, "1")
                Dim dtCto As DataTable = oCont.GetByNProc(Ncont)
               

                If dt.Rows.Count = 0 Then
                    ltPlantilla.Text = "No se encontro número de proceso"

                Else

                    Dim dtT As DataTable = t.GetByUser()
                    Dim dtCont As DataTable = OAdj.GetbyAdjudicado(Ncont, "1")
                    Dim dtOblig As DataTable = oOblig.GetRecords(Ncont, "1")
                    Dim dtDN As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_CON"))
                    Dim dtDD As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_PCON"))

                    If dtCont.Rows.Count > 0 Then
                        NomCotista = dtCont.Rows(0)("RAZON_SOCIAL")
                    Else
                        NomCotista = "No Se ha adjudicado el proceso"
                    End If
                   


                    'If dtOblig.Rows.Count > 0 Then
                    '    strPlantilla = strPlantilla.Replace("{OBLIGACIONES}", dtOblig.Rows(0)("DES_OBLIG").ToString())

                    'Else
                    'End If

                    If dtT.Rows.Count > 0 Then
                        NomUsu = dtT.Rows(0)("NOM_TER")
                        'Car_Fun = dtT.Rows(0)("CAR_FUN")
                    Else
                        NomUsu = "No hay usuario"

                    End If



                    strPlantilla = strPlantilla.Replace("{OBJETO}", dt.Rows(0)("OBJ_CON").ToString())
                    strPlantilla = strPlantilla.Replace("{SUBTIPO_CTO}", dt.Rows(0)("NOM_STIP").ToString())
                    strPlantilla = strPlantilla.Replace("{VALOR_LETRAS}", dt.Rows(0)("VALOR_LETRAS").ToString())
                    strPlantilla = strPlantilla.Replace("{NUMERO}", NumCto)
                    strPlantilla = strPlantilla.Replace("{CAR_FUN}", Car_Fun)
                    strPlantilla = strPlantilla.Replace("{PLAZO}", dt.Rows(0)("PLAZOC_EJECUCION").ToString())
                    strPlantilla = strPlantilla.Replace("{LUG_EJE}", dt.Rows(0)("LUG_EJE").ToString())
                    strPlantilla = strPlantilla.Replace("{NOM_CONTRATISTA}", dt.Rows(0)("NOM_CONTRATISTA").ToString())
                    strPlantilla = strPlantilla.Replace("{OBLIGACIONES}", dt.Rows(0)("OBLIG").ToString())
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

