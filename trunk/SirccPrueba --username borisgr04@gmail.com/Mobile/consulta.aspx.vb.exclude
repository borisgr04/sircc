Imports System.Data

Partial Class Mobile_Default
    Inherits System.Web.UI.MobileControls.MobilePage
    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.ActiveForm = Me.frmInput
    End Sub

    Protected Sub cmdBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim obj As New Contratos

        'Dim dt As DataTable = obj.GetRecords("dep_con='06'")
        Dim dt As DataTable = obj.GetByPk(txtCodigo.Text)
        If dt.Rows.Count > 0 Then
            'Me.ActiveForm = Me.frmInput
            Me.ActiveForm = Me.frmResult
            'Me.tvDetalle.Text = dt.Rows(0)("Obj_Con").ToString
            List1.DefaultCommand = "Numero"
            List1.MoreText = "Click para ver detalles"

            List1.DataSource = dt
            List1.DataBind()
        Else
            Me.ActiveForm = Me.frmError
        End If

      
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim objT As New Tipos
        'Me.SlTipo.DataSource = objT.GetRecords()
        'Me.SlTipo.DataTextField = "Nom_Tip"
        'Me.SlTipo.DataValueField = "Cod_Tip"
        'Me.SlTipo.DataBind()

        'Dim objV As New Vigencias
        'Me.SLVigencia.DataSource = objV.GetRecords()
        'Me.SLVigencia.DataTextField = "Year_Vig"
        'Me.SLVigencia.DataValueField = "Year_Vig"
        'Me.SLVigencia.DataBind()

    End Sub

    Protected Sub txtCodigo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged

    End Sub
End Class


