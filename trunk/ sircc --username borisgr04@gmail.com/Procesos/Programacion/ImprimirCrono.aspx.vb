
Partial Class Procesos_Programacion_ImprimirCrono
    Inherits PaginaComun



    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CCalenProgl1.Filtro = String.Format("Pro_Sel_Nro='{0}'", Request("Num_Proc"))
        CCalenProgl1.MododeVista = CtrlUsr_CalenProg_CCalenProgl.BgrModoVista.VistaCalendario
        CCalenProgl1.Actualizar_Crono()
        CCalenProgl1.MostrarMododeVista = False
        Me.UpdPCon.Update()

    End Sub
End Class
