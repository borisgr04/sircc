Imports System.Data

Partial Class Contratos_GDocumentos_Designacion
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim oC As New Contratos
        Dim oD As New Dependencias

        Dim t As New Terceros





        Dim dt As DataTable = oC.GetByPk("2012020533")
        Dim dtDN As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_CON"))
        Dim dtDD As DataTable = oD.GetbyPK(dt.Rows(0)("DEP_PCON"))
        Dim dtT As DataTable = t.GetByUser()
        Dim NomUsu As String = ""
        If dtT.Rows.Count > 0 Then
            NomUsu = dtT.Rows(0)("NOM_TER")
        End If


        Dim strPlantilla As String = ltPlantilla.Text

        Dim fecha As String = DateTime.Now.ToLongDateString()

        strPlantilla = strPlantilla.Replace("{OBJETO}", dt.Rows(0)("OBJ_CON").ToString())
        strPlantilla = strPlantilla.Replace("{NUMERO}", dt.Rows(0)("Numero").ToString())
        strPlantilla = strPlantilla.Replace("{CLASE_CONTRATO}", dt.Rows(0)("TIPO").ToString())
        strPlantilla = strPlantilla.Replace("{VALOR_A_CONTRATAR}", dt.Rows(0)("VAL_CON").ToString())
        strPlantilla = strPlantilla.Replace("{FECHA}", fecha)
        strPlantilla = strPlantilla.Replace("{NOM_CONTRATISTA}", dt.Rows(0)("CONTRATISTA").ToString())

        strPlantilla = strPlantilla.Replace("{NOM_SUPERVISOR}", dtDN.Rows(0)("nom_ter").ToString())
        strPlantilla = strPlantilla.Replace("{CAR_SUPERVISOR}", dtDN.Rows(0)("cargo_enc").ToString())
        strPlantilla = strPlantilla.Replace("{DEP_SUPERVISOR}", dtDN.Rows(0)("NOM_DEP").ToString())

        strPlantilla = strPlantilla.Replace("{NOM_ENC_DEPENDENCIAD}", dtDD.Rows(0)("nom_ter").ToString())
        strPlantilla = strPlantilla.Replace("{CAR_ENC_DEPENDENCIAD}", dtDD.Rows(0)("cargo_enc").ToString())


        strPlantilla = strPlantilla.Replace("{NOM_USUARIO}", NomUsu)



        ltPlantilla.Text = strPlantilla


        'GridView1.DataSource = dt
        'GridView1.DataBind()
    End Sub
End Class
