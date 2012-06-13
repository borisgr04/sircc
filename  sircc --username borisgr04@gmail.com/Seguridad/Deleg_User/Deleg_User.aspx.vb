Imports System.Data

Partial Class Seguridad_Deleg_User_Deleg_User
    Inherits PaginaComun

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click

    End Sub

    Protected Sub TxtUsername_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUsername.TextChanged
        Dim Obj As New Terceros
        Dim dt As DataTable = Obj.GetByIde(Me.TxtUsername.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtRazSoc.Text = dt.Rows(0)("Nom_Ter").ToString
            
        Else
            Me.TxtRazSoc.Text = ""
            Me.msgResult.Text = "El usuario debe estar registrado cómo Tercero"
        End If
        If Not Usuarios.IsUser(TxtUsername.Text) Then
            LbIsUser.Text = "No es usuario"
            LbIsUser.ForeColor = Drawing.Color.Red
        Else
            LbIsUser.Text = ""
        End If
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim ld As New List(Of UsuDel)
    
        For Each row In GridView1.Rows
            Dim u As New UsuDel
            u.IdeTer = TxtUsername.Text
            Dim AsigProc As String = Util.invSI_NO(DirectCast(row.FindControl("hdAsigProc"), HiddenField).Value)
            Dim Coord As String = Util.invSI_NO(DirectCast(row.FindControl("HdCoord"), HiddenField).Value)

            Dim estCheckBox As CheckBox = DirectCast(row.FindControl("ChkEst"), CheckBox)
            Dim est As String = DirectCast(row.FindControl("hdEst"), HiddenField).Value
            u.Id_Hdep = DirectCast(row.FindControl("hdId_Hdep"), HiddenField).Value
            u.Cod_Dep = DirectCast(row.FindControl("hdcod_dep"), HiddenField).Value
            u.AsigProc = Util.invSI_NO(DirectCast(row.FindControl("ChkAsigProc"), CheckBox).Checked)
            u.Coord = Util.invSI_NO(DirectCast(row.FindControl("ChkCoord"), CheckBox).Checked)
            u.NomDep = DirectCast(row.FindControl("LbNom"), Label).Text
            If (estCheckBox.Checked = True) Then 'Si agrego nueva seleccion
                If u.Id_Hdep = 0 Then
                    u.Accion = UsuDel.eAccion.Agregar
                    u.Estado = "AC"
                ElseIf (AsigProc <> u.AsigProc) Or (Coord <> u.Coord) Or (est = "IN") Then ''Si hubo cambio, actualizar
                    u.Accion = UsuDel.eAccion.Actualizar
                    u.Estado = "AC"
                End If
            ElseIf (estCheckBox.Checked = False) And (u.Id_Hdep <> 0) And (est = "AC") Then ' Si quito uno previamente seleccionado
                u.Accion = UsuDel.eAccion.Eliminar
                u.Estado = "IN"
            End If
            ld.Add(u)
        Next

        Dim objUsu As New UsuDel

        msgResult.Text = objUsu.InsertDel(TxtUsername.Text, ld)
        MsgBoxInfo(msgResult, False)
        GridView1.DataBind()



    End Sub


    Public Function MostrarBool(ByVal Valor As String) As Boolean
        If IsDBNull(Valor) Then
            Return False
        ElseIf (Valor = "SI") Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
