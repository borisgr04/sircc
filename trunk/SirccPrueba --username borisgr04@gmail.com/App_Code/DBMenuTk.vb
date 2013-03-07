Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel


Public Class DBMenuTk
    Inherits DBMenu_O

    Public Overloads Sub cargarMenu(ByVal mn As Telerik.Web.UI.RadMenu, ByVal Modulo As String)

        Me._Modulo = Modulo
        'Cargar Elementos Al Menu
        mn.Items.Clear()
        Dim dtMenuItems As New DataTable
        Dim queryString As String
        Dim u As New Usuarios
        'Conexion a la base de datos donde esta nuestra tabla Menú.
        '        Me.Desconectar()
        Me.Conectar()
        'se invoca al procedimiento almacenado
        'queryString = "select * from Menu Where Habilitado=1 and perfil=:perfil "
        queryString = "Select * from " + Me.Vista + " WHERE MODULO='" + Modulo + "'  Order by menuid,posicion"
        'Throw New Exception(queryString)
        Me.CrearComando(queryString)
        'llenamos el datatable
        dtMenuItems = Me.EjecutarConsultaDataTable()
        'recorremos el datatable para agregar los elementos de que estaran en la cabecera del menú.
        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            'esta condicion indica q son elementos padre.
            If drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then
                Dim mnuMenuItem As New Telerik.Web.UI.RadMenuItem
                mnuMenuItem.Value = drMenuItem("MenuId").ToString
                mnuMenuItem.Text = drMenuItem("titulo").ToString
                mnuMenuItem.ImageUrl = drMenuItem("Icono").ToString
                ' mnuMenuItem.NavigateUrl = drMenuItem("Url").ToString
                'mnuMenuItem.ShowCheckBox = False
                mnuMenuItem.ToolTip = drMenuItem("descripcion").ToString
                'agregamos el Ítem al menú
                mn.Items.Add(mnuMenuItem)
                'hacemos un llamado al metodo recursivo encargado de generar el árbol del menú.
                AddMenuItem(mnuMenuItem, dtMenuItems)
            End If
        Next
        Me.Desconectar()
    End Sub

    Private Overloads Sub AddMenuItem(ByVal mnuMenuItem As Telerik.Web.UI.RadMenuItem, ByVal dtMenuItems As DataTable)
        'recorremos cada elemento del datatable para poder determinar cuales son elementos hijos
        'del menuitem dado pasado como parametro ByRef.
        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            If drMenuItem("PadreId").ToString.Equals(mnuMenuItem.Value) AndAlso _
            Not drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then
                'VALIDAR LOS ROLES
                If Me.IsUserInRole(drMenuItem("ROLES").ToString) = True AndAlso drMenuItem("habilitado").ToString = "1" Then
                    Dim mnuNewMenuItem As New Telerik.Web.UI.RadMenuItem
                    mnuNewMenuItem.Value = drMenuItem("MenuId").ToString
                    mnuNewMenuItem.Text = " " + drMenuItem("titulo").ToString '+ " <hr/>"
                    mnuNewMenuItem.ToolTip = drMenuItem("descripcion").ToString
                    mnuNewMenuItem.ImageUrl = drMenuItem("Icono").ToString
                    mnuNewMenuItem.NavigateUrl = drMenuItem("Url").ToString
                    mnuNewMenuItem.Target = drMenuItem("Target").ToString
                    'mnuNewMenuItem.Selectable = False
                    'Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                    mnuMenuItem.Items.Add(mnuNewMenuItem)
                    'llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                    AddMenuItem(mnuNewMenuItem, dtMenuItems)
                End If
            End If
        Next
    End Sub

End Class
