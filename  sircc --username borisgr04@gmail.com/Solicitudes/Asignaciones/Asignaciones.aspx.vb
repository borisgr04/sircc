﻿Imports System.Data
Partial Class Solicitudes_Asignaciones_Default
    Inherits PaginaComun

    Property EncargadoActual As String
        Get
            Return ViewState("EncargadoActual")
        End Get
        Set(ByVal value As String)
            ViewState("EncargadoActual") = value
        End Set
    End Property

    Sub Asignar()
        If TxtIde.Text <> EncargadoActual Then
            Dim obj As New PSolicitudes
            Me.MsgResult.Text = obj.Asignar_Usuario_Encargado(Me.DetPSolicitudesAll1.CodigoPContrato, Me.TxtIde.Text)
            Me.MsgBox(Me.MsgResult, obj.lErrorG)
            Me.DetPSolicitudesAll1.Buscar()
            Me.GridView1.DataBind()
            EncargadoActual = TxtIde.Text
        Else
            Me.MsgResult.Text = "Para Reasignar escoja un funcionario diferentes al Actual."
            MsgBoxAlert(MsgResult, True)

        End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Request.QueryString.Count > 0 Then
                querystringSeguro = Me.GetRequest()
                Me.DetPSolicitudesAll1.CodigoPContrato = querystringSeguro("Cod_Sol")
                Me.DetPSolicitudesAll1.Buscar()
                UpdAsig.Update()
                MsgBoxInfo(LbMsg, True)
            End If
        End If
    End Sub

    Sub Habilitar(ByVal V As Boolean)

        Me.IBtnAsignar.Enabled = V
        Me.BtnBuscar.Enabled = V
        Me.TxtIde.Enabled = V
    End Sub
    Protected Sub DetPSolicitudesAll1_OnAceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetPSolicitudesAll1.AceptarClicked
        Me.consultaterxDep1.Tipo = Me.DetPSolicitudesAll1.Dep_PCon
        Me.consultaterxDep1.DataBind()
        If DetPSolicitudesAll1.Concepto <> "P" Then
            Habilitar(False)
        Else
            Habilitar(True)
        End If

        ModalPopup.Hide()
        If Me.DetPSolicitudesAll1.Encontrado = True Then
            Me.Panel4.Visible = True
            Dim fa As String = DetPSolicitudesAll1.dtSolicitudes.Rows(0)("ID_ABOG_ENC").ToString
            If Not String.IsNullOrEmpty(fa) Then
                TxtIde.Text = fa
                EncargadoActual = fa
                MostrarI()
            Else
                TxtIde.Text = ""
                EncargadoActual = ""
            End If

        Else
            Me.Panel4.Visible = False
        End If
        UpdAsig.Update()

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub TxtIde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIde.TextChanged
        Mostrar()
    End Sub

    Sub Mostrar()
        Dim oTer As New Terceros
        Dim dt As DataTable = New DataTable
        dt = oTer.GetTercerosxIde_Dep(Me.TxtIde.Text, Me.DetPSolicitudesAll1.Dep_PCon)
        If dt.Rows.Count > 0 Then
            Me.TxtIde.Text = dt.Rows(0).Item("Ide_Ter").ToString
            Me.TxtNomTer.Text = dt.Rows(0).Item("Nom_Ter").ToString
        Else
            Me.ModalPopup.Show()
        End If
    End Sub


    Sub MostrarI()
        Dim oTer As New Terceros
        Dim dt As DataTable = New DataTable
        dt = oTer.GetTercerosxIde_Dep(Me.TxtIde.Text, Me.DetPSolicitudesAll1.Dep_PCon)
        If dt.Rows.Count > 0 Then
            Me.TxtIde.Text = dt.Rows(0).Item("Ide_Ter").ToString
            Me.TxtNomTer.Text = dt.Rows(0).Item("Nom_Ter").ToString
        Else
            Me.MsgResult.Text = "No hay Funcionario Encargado"
            Me.MsgBoxAlert(Me.MsgResult, True)
        End If
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MsgBoxLimpiar(MsgResult)
        Desactivar_Timer(Timer1)
    End Sub
    Protected Overloads Sub MsgBox(ByVal msg As Label, ByVal lError As Boolean)
        Activar_Timer(Timer1, lError)
        MyBase.MsgBox(msg, lError)
    End Sub
    Protected Overloads Sub MsgBoxAlert(ByVal msg As Label, ByVal lError As Boolean)
        Activar_Timer(Timer1, lError)
        MyBase.MsgBoxAlert(msg, lError)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAsignar.Click
        Asignar()
    End Sub

    Sub NuevaSol()
        Redireccionar_Pagina("/Solicitudes/NuevaSolicitud/NuevaSolicitud.aspx")
    End Sub
  

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Me.ModalPopup.Show()
    End Sub


End Class
