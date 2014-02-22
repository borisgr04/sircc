Imports System.Data
Partial Class Contratos_GDocumentos_SolicitudRPC
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim oC As New Contratos
        Dim oD As New Dependencias
        Dim oCDP As New CDP_Contratos
        Dim t As New Terceros


        Dim Numero As String = "2012020022"
        ' "2012020533"


        Dim dt As DataTable = oC.GetByPk(Numero)
        Dim dtDN As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_CON"))
        Dim dtDD As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_PCON"))
        Dim strPlantilla As String = ltPlantilla.Text
        Dim fecha As String = DateTime.Now.ToLongDateString()

        Dim dtCDP As DataTable = oCDP.GetRecords(Numero)
        If dtCDP.Rows.Count = 0 Then
            strPlantilla = "El contrato no tiene CDP Asignado"
        Else
            strPlantilla = strPlantilla.Replace("{NRO_CDP}", dtCDP.Rows(0)("NRO_CDP").ToString())
            strPlantilla = strPlantilla.Replace("{FEC_CDP}", dtCDP.Rows(0)("FEC_CDP").ToString())
            strPlantilla = strPlantilla.Replace("{OBJETO}", dt.Rows(0)("OBJ_CON").ToString())
            strPlantilla = strPlantilla.Replace("{NUMERO}", dt.Rows(0)("Numero").ToString())
            strPlantilla = strPlantilla.Replace("{CLASE_CONTRATO}", dt.Rows(0)("TIPO").ToString())
            strPlantilla = strPlantilla.Replace("{VALOR_A_CONTRATAR}", dt.Rows(0)("VAL_CON").ToString())
            strPlantilla = strPlantilla.Replace("{FECHA}", dt.Rows(0)("fec_sus_con").ToLongDateString())
            strPlantilla = strPlantilla.Replace("{NOM_CONTRATISTA}", dt.Rows(0)("CONTRATISTA").ToString())
            strPlantilla = strPlantilla.Replace("{DEPENDENCIA_DELEGADA}", dtDN.Rows(0)("NOM_DEP").ToString())


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
    End Sub
End Class
