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
        For i As Integer = 0 To ListBox2.Items.Count - 1
            Dim auxSelect As New SelSelect
            auxSelect.strSelect = "Select " + ListBox2.Items(i).Value + " As " + ListBox2.Items(i).Text + ", Count(*) Cantidad From " + HdVista.Value + " {filtro}  Group by " + ListBox2.Items(i).Value
            auxSelect.Titulo = " CONSOLIDADO DE " + ListBox2.Items(i).Text
            auxSelect.strSelectCount = "Select 'Total' As Total, Count(*) Cantidad From " + HdVista.Value + " {filtro}  "
            lstSelect.Add(auxSelect)
        Next
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
