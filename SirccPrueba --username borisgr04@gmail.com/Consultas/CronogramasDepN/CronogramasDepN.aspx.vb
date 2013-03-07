
Partial Class Consultas_CronogramasDepN_Default
    Inherits PaginaComun


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'CCalenProgl1.Num_Proc = "GR-CCDD-0005-2011"
        'CCalenProgl1.MododeVista = CtrlUsr_CalenProg_CCalenProgl.BgrModoVista.VistaCalendario
        'CCalenProgl1.Actualizar_Crono()
        'CCalenProgl1.MostrarMododeVista = True
    End Sub

  
    Protected Sub FiltroPCon1_FiltrarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroPConN1.FiltrarClicked
        CCalenProgl1.Filtro = FiltroPConN1.Filtro

        CCalenProgl1.MododeVista = CtrlUsr_CalenProg_CCalenProgl.BgrModoVista.VistaCalendario
        CCalenProgl1.Actualizar_Crono()
        CCalenProgl1.MostrarMododeVista = True
    End Sub
End Class
