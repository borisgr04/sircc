Imports System.Data


Partial Class CtrlUsr_SelCampos_SelCamposC
    Inherits CtrlUsrComun

    Property Vista As String
        Get
            Return HdVista.Value
        End Get
        Set(ByVal value As String)
            HdVista.Value = value
            'CargarDatosListBox()
        End Set
    End Property

    ReadOnly Property ListaSelect As List(Of SelSelect)
        Get
            Return ObtenerSelect()
        End Get
    End Property

    Private Function ObtenerSelect() As List(Of SelSelect)
        Dim lstSelect As New List(Of SelSelect)
        LbCampos.Text = ""
        If Chk.Checked = True Then
            For i As Integer = 0 To ListBox2.Items.Count - 1
                Dim auxSelect As New SelSelect
                auxSelect.strSelect = "Select " + ListBox2.Items(i).Value + " As " + ListBox2.Items(i).Text + ", Count(*) Cantidad From " + HdVista.Value + " {filtro}  Group by " + ListBox2.Items(i).Value
                auxSelect.Titulo = " CONSOLIDADO DE " + ListBox2.Items(i).Text
                auxSelect.strSelectCount = "Select 'Total' As Total, Count(*) Cantidad From " + HdVista.Value + " {filtro}  "
                lstSelect.Add(auxSelect)
            Next
        Else
            Dim Campos As String = ""
            Dim sCampos As String = ""
            Dim tCampos As String = ""
            For i As Integer = 0 To ListBox2.Items.Count - 1
                Campos += IIf(String.IsNullOrEmpty(Campos), "", ",") + ListBox2.Items(i).Value + " As " + ListBox2.Items(i).Text
                sCampos += IIf(String.IsNullOrEmpty(sCampos), "", ",") + ListBox2.Items(i).Value
                tCampos += IIf(String.IsNullOrEmpty(tCampos), "", ",") + ListBox2.Items(i).Text

            Next
            If ListBox2.Items.Count > 0 Then
                Dim auxSelect As New SelSelect
                'auxSelect.strSelect = "Select " + Campos + ", Count(*) Cantidad ,Sum(Val_Apo_Gob) Valor_Aportes From " + HdVista.Value + " {filtro}  Group by " + sCampos
                auxSelect.strSelect = "Select " + Campos + ", Count(*) Cantidad ,SUM(Val_Con) Valor_Inicial,SUM(Val_Apo_Gob) Aportes_Propios,SUM(Val_Otros) Aportes_Otros,Sum(Val_Adi) Valor_Adicionado,Sum(Val_Adi+val_con) Valor_Total  From " + HdVista.Value + " {filtro}  Group by " + sCampos
                auxSelect.Titulo = " CONSOLIDADO POR ( " + tCampos + " )"
                'auxSelect.strSelectCount = "Select 'Total' As Total, Count(*) Cantidad,Sum(Val_Apo_Gob) Total_Aportes  From " + HdVista.Value + " {filtro}  "
                auxSelect.strSelectCount = "Select 'Total' As Total, Count(*) Cantidad,SUM(Val_Con) Valor_Inicial,SUM(Val_Apo_Gob) Aportes_Propios,SUM(Val_Otros) Aportes_Otros,Sum(Val_Adi) Valor_Adicionado,Sum(Val_Adi+val_con) Valor_Total   From " + HdVista.Value + " {filtro}  "
                lstSelect.Add(auxSelect)
            End If
        End If
        Return lstSelect
    End Function


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ObtenerSelect()
    End Sub

    Protected Sub BtnOrdenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOrdenas.Click
        Util.SortListBox(ListBox1)
        'SortListBox()

    End Sub
    Sub CargarDatosListBox()
        Dim obj As New PPlantillas_Campos
        Dim dt As DataTable = obj.GetRecords(HdVista.Value)
        ListBox1.Items.Clear()
        For Each row In dt.Rows
            ListBox1.Items.Add(New ListItem(row("Nom_Pla"), row("Nom_Cam")))
        Next
    End Sub

    Public Sub SortListBox()
        Dim t As New List(Of ListItem)
        Dim compare As New Comparison(Of ListItem)(AddressOf CompareListItems)
        'Iterate through each ListItem in the Listbox, and add them to the 'List' object  
        For Each lbItem As ListItem In ListBox1.Items
            t.Add(lbItem)
        Next
        'Sort the List 
        t.Sort(compare)
        'Clear the Listbox passed in, and add the sorted list from above  
        ListBox1.Items.Clear()
        ListBox1.Items.AddRange(t.ToArray())
    End Sub
    Public Shared Function CompareListItems(ByVal li1 As ListItem, ByVal li2 As ListItem) As Integer
        'Return the strings in order that have been compared:  
        Return [String].Compare(li1.Text, li2.Text)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'CargarDatosListBox()
        End If
    End Sub

    
End Class
