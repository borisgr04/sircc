Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Data

Partial Class Contratos_GesContratos_CGesContratos
    Inherits System.Web.UI.Page

    Protected Sub BtnCons_Click(sender As Object, e As System.EventArgs) Handles BtnCons.Click
        Dim vc As New vContratosInt()
        If ChkTipo.Checked Then
            vc.Cod_Tip = Me.cboTipo.SelectedValue
        End If
        If ChkSTipo.Checked Then
            vc.Cod_STip = Me.CboSubTipo.SelectedValue
        End If

        If ChkVigencia.Checked Then
            vc.Vigencia = Convert.ToInt16(Me.CmbVig.SelectedValue)
        End If
        If ChkEstado.Checked Then
            vc.Estado = CmbEst.SelectedValue
        End If
        vc.FilxFS = ChkFecha.Checked
        If vc.FilxFS Then
            vc.FS_Inicial = Convert.ToDateTime(Me.TxtFecIni.Text)
            vc.FS_Final = Convert.ToDateTime(Me.TxtFecFin.Text)
        End If
        If Me.ChkNContrato.Checked Then
            vc.Numero = TxtNroCto.Text
        End If
        If ChkContratista.Checked Then
            vc.Ide_Contratista = Me.TxtIdeCon.Text
        End If
        If Me.ChkSup.Checked Then
            vc.Ide_Interventor = Me.TxtIdeSup.Text
        End If
        If Me.ChkDepNec.Checked Then
            vc.Dep_Nec = CmbDep.SelectedValue
        End If
        If Me.ChkObj.Checked Then
            vc.Objeto = Me.TxtObjCont.Text
        End If
        Dim cc As New CContratos

        Me.ListView1.DataSource = cc.GetRecords(vc)
        Me.ListView1.DataBind()
        MultiView1.ActiveViewIndex = 1
    End Sub

    'Protected Sub BtnConsCon_Click(sender As Object, e As System.EventArgs) Handles BtnCons.Click, BtnConsCon.Click
    '    Dim vc As New vContratosInt()
    '    If ChkTipo.Checked Then
    '        vc.Cod_Tip = Me.cboTipo.SelectedValue
    '    End If
    '    If ChkSTipo.Checked Then
    '        vc.Cod_STip = Me.CboSubTipo.SelectedValue
    '    End If

    '    If ChkVigencia.Checked Then
    '        vc.Vigencia = Convert.ToInt16(Me.CmbVig.SelectedValue)
    '    End If
    '    If ChkEstado.Checked Then
    '        vc.Estado = CmbEst.SelectedValue
    '    End If
    '    vc.FilxFS = ChkFecha.Checked
    '    If vc.FilxFS Then
    '        vc.FS_Inicial = Convert.ToDateTime(Me.TxtFecIni.Text)
    '        vc.FS_Final = Convert.ToDateTime(Me.TxtFecFin.Text)
    '    End If
    '    If Me.ChkNContrato.Checked Then
    '        vc.Numero = TxtNroCto.Text
    '    End If
    '    If ChkContratista.Checked Then
    '        vc.Ide_Contratista = Me.TxtIdeCon.Text
    '    End If
    '    If Me.ChkSup.Checked Then
    '        vc.Ide_Interventor = Me.TxtIdeSup.Text
    '    End If
    '    If Me.ChkDepNec.Checked Then
    '        vc.Dep_Nec = CmbDep.SelectedValue
    '    End If
    '    If Me.ChkObj.Checked Then
    '        vc.Objeto = Me.TxtObjCont.Text
    '    End If
    '    Dim cc As New CContratos

    '    Me.ListView2.DataSource = cc.GetRecordsC(vc)
    '    Me.ListView2.DataBind()
    '    MultiView1.ActiveViewIndex = 2
    'End Sub

    Protected Sub LnBtFilt_Click(sender As Object, e As System.EventArgs) Handles LnBtFilt.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub ObjDtConsCont_Selecting(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjDtConsCont.Selecting

        'e.InputParameters("cFil") = vc

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click

    End Sub

    Protected Sub grdBusqueda_DataBound(sender As Object, e As System.EventArgs) Handles grdBusqueda.DataBound

    End Sub

    Protected Sub grdBusqueda_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBusqueda.RowDataBound

    End Sub

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Shared Function GetTercerosPk(ide_ter As String) As String
        Dim t As New Terceros
        Dim tb As DataTable = t.GetByIde(ide_ter)
        Return If(tb.Rows.Count = 0, "0", tb.Rows(0)("Nom_Ter"))
    End Function

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            HdUser.Value = Usuarios.UserName
        End If

    End Sub
End Class
