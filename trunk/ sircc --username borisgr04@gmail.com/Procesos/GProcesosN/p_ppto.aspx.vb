
Partial Class Procesos_GProcesosN_p_ppto
    Inherits System.Web.UI.Page

    Protected Sub ObjGP_Ppto_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjGP_Ppto.Inserting
       
    End Sub

    Protected Sub RadGrid1_InsertCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.InsertCommand
        'ObjGP_Ppto.InsertParameters("Num_Proc").DefaultValue = "11"
        'ObjGP_Ppto.InsertParameters("Grupo").DefaultValue = "1"
        'ObjGP_Ppto.Insert()
        'Response.Write("SSS")
    End Sub

    Protected Sub RadGrid1_ItemInserted(ByVal source As Object, ByVal e As Telerik.Web.UI.GridInsertedEventArgs) Handles RadGrid1.ItemInserted
        If Not e.Exception Is Nothing Then
            e.ExceptionHandled = True
            e.KeepInInsertMode = True
            SetMessage("Product cannot be inserted. Reason: " + e.Exception.Message)
        Else
            SetMessage("New product is inserted!")
        End If
    End Sub

    Private Sub SetMessage(ByVal message As String)
        ' Response.Write(message)
    End Sub




End Class
