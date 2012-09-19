Imports System.Data
Imports System.Drawing.Color
Imports System.Drawing.Imaging
Imports System.Drawing

Partial Class Reportes_Certificados_Certificados
    Inherits PaginaComun

    Dim oCert As New Cert_Contratos()

    Property lstContratosCVS As String
        Get
            Return ViewState("lstContratosCVS")
        End Get
        Set(ByVal value As String)
            ViewState("lstContratosCVS") = value
        End Set
    End Property

    Property lstContratos As String
        Get
            Return ViewState("lstContratos")
        End Get
        Set(ByVal value As String)
            ViewState("lstContratos") = value
        End Set
    End Property

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub



    Protected Sub TxtIde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIde.TextChanged

        Dim Obj As New Terceros
        Dim dt As DataTable = Obj.GetByIde(Me.TxtIde.Text)

        If dt.Rows.Count > 0 Then
            Me.TxtNom.Text = dt.Rows(0)("Nom_Ter").ToString
            MsgBoxLimpiar(Me.MsgResult)
        Else
            Me.TxtNom.Text = ""
            Me.MsgResult.Text = "El usuario debe estar registrado cómo Tercero"
            MsgBoxAlert(Me.MsgResult, True)
        End If
        grdContratos.DataBind()
        RdCert.SelectedValue = 0
        MultiView1.ActiveViewIndex = 0


    End Sub


    Sub GenerarCert()
        Me.lstContratos = ""
        For Each grdRows As GridViewRow In grdContratos.Rows
            Dim nuevoCheckBox As CheckBox = grdRows.FindControl("ChkSel")
            Dim estaCheckeado As Boolean = nuevoCheckBox.Checked
            If (estaCheckeado = True) Then
                lstContratos += IIf(String.IsNullOrEmpty(lstContratos), "", ",") + grdRows.Cells(2).Text
            End If
        Next
        lstContratosCVS = Util.FormatCVS(lstContratos)
        If Not String.IsNullOrEmpty(lstContratos) Then


            'SE INICIALIZAN LOS DATOS PAR CREAR EL REGISTRO DEL CERTIFICADO
            oCert.Ide_Con = TxtIde.Text
            oCert.Lst_Cont = lstContratos
            MsgResult.Text = oCert.GenCertificado() ' Crea el Certificado

            If Not oCert.lErrorG Then
                grdCert.DataBind()
                MultiView1.ActiveViewIndex = 1
                RdCert.SelectedValue = 1
                MsgResult.Text = "Se Generó Certificado N° " + oCert.Nro_Cert.ToString
            End If
            MsgBox(MsgResult, oCert.lErrorG)
        Else
            MsgResult.Text = "Seleccione al menos un contrato a Certificar."
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub


    Protected Sub RdCert_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdCert.SelectedIndexChanged
        MultiView1.ActiveViewIndex = RdCert.SelectedValue
    End Sub

    Protected Sub grdCert_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCert.SelectedIndexChanged
        Redireccionar_Pagina(String.Format("ashx/verCert.ashx?nro_cert={0}&vig_cert={1}&CVXX={2}", grdCert.SelectedRow.Cells(1).Text, grdCert.SelectedRow.Cells(0).Text, grdCert.SelectedRow.Cells(2).Text))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Creamos un objeto Bitmap y especificamos las dimensiones ancho y alto, sera como nuestro lienzo :)
        'Nota.- El color por defecto de un nuevo Bitmap es negro
        Dim objLienzo As Bitmap = New Bitmap(400, 100)
        'Creamos un objecto Graphics que nos permitira graficar sobre nnuestro anterior objeto Bitmap
        'establecemos que trabajara sobre nuestro lienzo
        Dim objGraficar As Graphics = Graphics.FromImage(objLienzo)
        'Creamos un objeto de tipo Color que contendra el color que usaremos como fondo(background)
        Dim objColor As System.Drawing.Color
        'De acuerco al item seleccionado en nuestro DropDownList establecemos el valor del fondo
        'Select Case ddlColores.SelectedItem.Value
        '   Case 1
        objColor = Color.Red
        '  Case 2
        objColor = Color.Yellow
        ' Case 3
        objColor = Color.Green
        'End Select
        'Creamos un objeto tipo Font el cual usaremos para establecer el tipo de fuente
        'que tendra nuestro texto, esto podriamos colocarlo en un DropDownList, pero 
        'ese creo que se dan cuenta como hacerlo asi que no perdamos mas tiempo
        Dim objFont As New Font("Verdana", 12)
        'Definimos las coordenadas que usaremos a la hora de pintar nuestro texto
        Dim objCoordenadas As New PointF(5, 5)
        'Creamos un objeto tipo SolidBrush para pintar el fondo de nuestra imagen
        Dim objPincelFondo As New SolidBrush(objColor)
        'Creamos otro objeto SolidBrush para pintar el texto introducido en el formulario
        'establecemos que el color del texto sera negro
        Dim objPincelTexto As New SolidBrush(Color.Black)

        '/--------------/
        '/ PINTAR FONDO /
        '/--------------/
        'Comenzamos a pintar el fondo de nuestra imagen
        'como pueden ver estamos usando el Pincel para el fondo 
        'y las dimensiones de nuestro lienzo
        objGraficar.FillRectangle(objPincelFondo, 0, 0, 400, 100)

        '/--------------/
        '/ PINTAR TEXTO /
        '/--------------/
        'Comenzamos a pintar el texto
        objGraficar.DrawString("PRUEBA", objFont, objPincelTexto, objCoordenadas)

        '/-------/
        '/ FINAL /
        '/-------/
        '/----------------------/
        '/ 1 Opcion - GUARDANDO /
        '/----------------------/
        'Ahora como ay tenemos nuestra imagen terminada solo nos queda guardarla
        'ahora tu puedes guardar tu imagen definiendo el tipo sea JPG, PNG, GIF, TIFF, etc
        'bueno eso dependera de ti, para tal accion debes colocar la extension del archivo y 
        'como segundo parametro usar ImageFormat y seleccionar el tipo de archivo a generar
        '--- Para usar esta opcion solo quita el comentario de la siguiente instruccion y comenta 
        'las lineas de la segunda opcion
        'objLienzo.Save(Server.MapPath("ImageByKev.jpg"), ImageFormat.Jpeg)
        '/--------------------------------/
        '/ 2 Opcion - MOSTRAR SIN GUARDAR /
        '/--------------------------------/
        Context.Response.ContentType = "image/jpeg"
        objLienzo.Save(Context.Response.OutputStream, ImageFormat.Jpeg)
    End Sub

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

    '    Dim obj As New BDDatos
    '    Dim ds As New DataSet

    '    ds.Tables.Add(obj.GetSelect("select * FROM cert_contratos").Copy)
    '    ds.Tables(0).TableName = "Certificado"
    '    ds.Tables.Add(obj.GetSelect("SELECT * FROM vLstContratos where Numero In ('2010020070','2011020023') ").Copy)
    '    ds.Tables(1).TableName = "LstContratos"
    '    Dim rpt As New ReportDocument
    '    rpt.Load("D:\x\SIRCC\SIRCCGoogleCode\CReport\CrystalReport3.rpt")
    '    rpt.SetDataSource(ds)
    '    rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, True, "rpt")
    '    'CrystalReportViewer1.ReportSource = rpt

    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub grdContratos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdContratos.SelectedIndexChanged
        Dim c As New Contratos
        TxtObj.Text = c.GetObjeto(grdContratos.SelectedValue)



    End Sub

    Protected Sub IBtnCert_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnCert.Click
        GenerarCert()
    End Sub
End Class

