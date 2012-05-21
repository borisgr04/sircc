﻿
Partial Class CtrlUsr_FiltroPCon_FiltroPConN
    Inherits CtrlUsrComun

#Region "Eventos del control"
    ''' <summary>
    ''' Evento Aceptar del Control
    ''' </summary>
    ''' <remarks></remarks>
    Public Event FiltrarClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        RaiseEvent FiltrarClicked(sender, New EventArgs())
    End Sub
#End Region

#Region "Propiedades del control"
    ''' <summary>
    ''' Establece o devuele el valor del filtro.  
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Filtro As String
        Set(ByVal value As String)
            ViewState("FiltroPCon_Filtro") = value
            Session("FiltroPCon_Filtro") = value
        End Set
        Get
            'ViewState("FiltroPCon_Filtro") 
            Return Session("FiltroPCon_Filtro")
        End Get
    End Property
#End Region

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        FiltrarD()
        OnClick(sender)
    End Sub

    Sub FiltrarD()
        Dim cFiltro As String = ""
        If (Me.ChkNProc.Checked = True) Then
            Me.TxtNProc.Text = UCase(Me.TxtNProc.Text)
            Util.AddFiltro(cFiltro, "UPPER(Pro_Sel_Nro) Like '%" + Me.TxtNProc.Text + "%'")
        End If
        If (Me.ChkTproc.Checked = True) Then
            Util.AddFiltro(cFiltro, "Cod_TPro = '" + Me.CboTproc.SelectedValue + "'")
        End If
        If (Me.ChkDep.Checked = True) Then
            Util.AddFiltro(cFiltro, "dep_con = '" + Me.cboDep.SelectedValue + "'")
        End If
        If (Me.ChkDepP.Checked = True) Then
            Util.AddFiltro(cFiltro, "dep_pcon = '" + Me.CboDepP.SelectedValue + "'")
        End If

        If (Me.ChkObj.Checked = True) Then
            Me.TxtObj.Text = UCase(Me.TxtObj.Text)
            Util.AddFiltro(cFiltro, "UPPER(Obj_Con) Like '%" + Me.TxtObj.Text + "%'")
        End If
        Me.Filtro = cFiltro
        'LbFiltro.Text = cFiltro

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Filtro = ""
        End If
    End Sub

    Protected Sub Filtrar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkNProc.CheckedChanged, ChkTproc.CheckedChanged, ChkDep.CheckedChanged, ChkDepP.CheckedChanged, ChkObj.CheckedChanged, TxtNProc.TextChanged, CboTproc.TextChanged, cboDep.TextChanged, CboDepP.TextChanged, TxtObj.TextChanged
        FiltrarD()
        OnClick(sender)
    End Sub
End Class
