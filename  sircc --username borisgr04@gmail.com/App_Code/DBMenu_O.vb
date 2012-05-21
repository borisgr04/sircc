Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel


<System.ComponentModel.DataObject()> _
Public Class DBMenu_O
    Inherits BDDatos

    Protected sPerfil As String
    Protected _Modulo As String

    Public Sub New()
        Me.Tabla = "MENU2"
        Me.Vista = "vMENU"
    End Sub
    'cargar -> Menu
    Public Overloads Sub cargarMenu(ByVal mn As Menu, ByVal Modulo As String)
        Me._Modulo = Modulo
        'Cargar Elementos Al Menu
        mn.Items.Clear()
        Dim dtMenuItems As New DataTable
        Dim queryString As String

        'Dim u As New Usuarios 'quitada el 21 de mayo por boris

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
                Dim mnuMenuItem As New MenuItem
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
    'No lo Utilizo
    Public Sub cargarMenuP(ByVal mn As Menu)
        'Cargar Elementos Al Menu
        mn.Items.Clear()
        Dim dtMenuItems As New DataTable
        Dim queryString As String

        'Dim u As New Usuarios

        'Conexion a la base de datos donde esta nuestra tabla Menú.
        Me.Conectar()
        'se invoca al procedimiento almacenado
        queryString = "Select * from " + Me.Vista + " WHERE MODULO='ADMIN' And Ppal='S' Order by menuid,posicion"
        Me.CrearComando(queryString)
        dtMenuItems = Me.EjecutarConsultaDataTable()
        'recorremos el datatable para agregar los elementos de que estaran en la cabecera del menú.
        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            'esta condicion indica q son elementos padre.
            If drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then
                Dim mnuMenuItem As New MenuItem
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

    'Menu No lo Utilizo
    Public Sub cargarElementos(ByVal mn As Menu)
        'Cargar Elementos Al Menu
        mn.Items.Clear()
        Dim dtMenuItems As New DataTable
        Dim queryString As String
        Dim u As New Usuarios
        Dim Perfil As String ' = 'u.GetPerfil(Membership.GetUser().UserName)
        Perfil = "admin"
        'Conexion a la base de datos donde esta nuestra tabla Menú.
        Me.Conectar()
        'se invoca al procedimiento almacenado
        'queryString = "select * from Menu Where Habilitado=1 and perfil=:perfil "
        'Where sisperfil=:perfil 
        queryString = "Select * from vMenu_Perfil Order by menuid,posicion"
        Me.CrearComando(queryString)
        'Me.AsignarParametroCadena(":perfil", Perfil)
        'llenamos el datatable
        dtMenuItems = Me.EjecutarConsultaDataTable()
        'recorremos el datatable para agregar los elementos de que estaran en la cabecera del menú.
        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            'esta condicion indica q son elementos padre.
            If drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then
                Dim mnuMenuItem As New MenuItem
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

    Public Sub cargarElementos(ByVal mn As Menu, ByVal perfil As String)
        'Cargar Elementos Al Menu

        mn.Items.Clear()
        Dim dtMenuItems As New DataTable
        Dim queryString As String
        'Conexion a la base de datos donde esta nuestra tabla Menú.
        Me.Conectar()
        'Dim daMenu As New OracleDataAdapter
        'se invoca al procedimiento almacenado
        'queryString = "select * from Menu Where Habilitado=1 and perfil=:perfil "
        queryString = "Select * from vMenu_Perfil Where sisperfil=:perfil  Order by menuid,posicion"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":perfil", perfil)
        'llenamos el datatable
        dtMenuItems = Me.EjecutarConsultaDataTable()
        'recorremos el datatable para agregar los elementos de que estaran en la cabecera del menú.
        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            'esta condicion indica q son elementos padre.
            If drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then
                Dim mnuMenuItem As New MenuItem
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
    'Agregar Items Menu 
    Protected Overloads Sub AddMenuItem(ByRef mnuMenuItem As MenuItem, ByVal dtMenuItems As DataTable)
        'recorremos cada elemento del datatable para poder determinar cuales son elementos hijos
        'del menuitem dado pasado como parametro ByRef.
        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            If drMenuItem("PadreId").ToString.Equals(mnuMenuItem.Value) AndAlso _
            Not drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then
                'VALIDAR LOS ROLES
                If Me.IsUserInRole(drMenuItem("ROLES").ToString) = True AndAlso drMenuItem("habilitado").ToString = "1" Then
                    Dim mnuNewMenuItem As New MenuItem
                    mnuNewMenuItem.Value = drMenuItem("MenuId").ToString
                    mnuNewMenuItem.Text = " " + drMenuItem("titulo").ToString '+ " <hr/>"
                    mnuNewMenuItem.ToolTip = drMenuItem("descripcion").ToString
                    mnuNewMenuItem.ImageUrl = drMenuItem("Icono").ToString
                    mnuNewMenuItem.NavigateUrl = drMenuItem("Url").ToString
                    mnuNewMenuItem.Target = drMenuItem("Target").ToString
                    'mnuNewMenuItem.Selectable = False
                    'Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                    mnuMenuItem.ChildItems.Add(mnuNewMenuItem)
                    'llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                    AddMenuItem(mnuNewMenuItem, dtMenuItems)
                End If
            End If
        Next
    End Sub

    'Cargar Elementos Al Treeview - Se utiliza en administrar perfiles
    Public Sub cargarElementos(ByRef tvw As TreeView, ByVal perfil As String, Optional ByVal Modulo As String = "ADMIN")
        Me._Modulo = Modulo
        tvw.Nodes.Clear()
        Dim dtMenuItems As New DataTable
        Dim queryString As String
        'Conexion a la base de datos donde esta nuestra tabla Menú.
        'Dim daMenu As New OracleDataAdapter
        Me.Conectar()
        'se invoca al procedimiento almacenado
        queryString = "select (select count(*) from vMenu_Perfil Where menuid=m.menuid AND sisperfil=:perfil And Modulo=:MODULO ) As Est, m.* From vmenu m where MODULO=:MODULO Order by menuid,posicion"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":perfil", perfil)
        Me.AsignarParametroCadena(":MODULO", Modulo)
        Me.AsignarParametroCadena(":MODULO", Modulo)
        'Llenamos el datatable
        dtMenuItems = Me.EjecutarConsultaDataTable()
        'recorremos el datatable para agregar los elementos de que estaran en la cabecera del menú.
        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            'esta condicion indica q son elementos padre.
            If drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then
                Dim mnuMenuItem As New TreeNode
                mnuMenuItem.Value = drMenuItem("MenuId").ToString
                mnuMenuItem.Text = drMenuItem("titulo").ToString
                mnuMenuItem.ToolTip = drMenuItem("descripcion").ToString
                mnuMenuItem.ImageUrl = drMenuItem("Icono").ToString
                ' mnuMenuItem.NavigateUrl = drMenuItem("Url").ToString
                mnuMenuItem.ShowCheckBox = False
                'agregamos el Ítem al menú
                tvw.Nodes.Add(mnuMenuItem)
                'hacemos un llamado al metodo recursivo encargado de generar el árbol del menú.
                AddMenuItem(mnuMenuItem, dtMenuItems)
            End If
        Next
        tvw.ExpandAll()
        Me.Desconectar()
    End Sub

    'Llenar hijos de Arbol, por Perfil 29 de nov de 2010
    Protected Overloads Sub AddMenuItem(ByRef mnuMenuItem As TreeNode, ByVal dtMenuItems As Data.DataTable)
        'recorremos cada elemento del datatable para poder determinar cuales son elementos hijos
        'del menuitem dado pasado como parametro ByRef.
        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            If drMenuItem("PadreId").ToString.Equals(mnuMenuItem.Value) AndAlso _
            Not drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then
                Dim mnuNewMenuItem As New TreeNode
                mnuNewMenuItem.Value = drMenuItem("MenuId").ToString
                mnuNewMenuItem.Text = drMenuItem("titulo").ToString
                mnuNewMenuItem.ToolTip = drMenuItem("descripcion").ToString
                'mnuNewMenuItem.Text = drMenuItem("est").ToString
                mnuNewMenuItem.ImageUrl = drMenuItem("Icono").ToString
                'mnuNewMenuItem.NavigateUrl = drMenuItem("Url").ToString
                mnuNewMenuItem.ShowCheckBox = True
                mnuNewMenuItem.Checked = IIf(drMenuItem("Est").ToString = "1", True, False)
                'mnuNewMenuItem.Selectable = False
                'Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                mnuMenuItem.ChildNodes.Add(mnuNewMenuItem)

                'llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                AddMenuItem(mnuNewMenuItem, dtMenuItems)
            End If
        Next
    End Sub


    'Cargar Elementos Al Treeview Por Usuario y por módulo
    'fecha mod . 29 de Noviembre de 2010
    'requiere adicionar el modulo a consultar.
    Public Sub GetOpcionesPorUser(ByRef tvw As TreeView, ByVal username As String, Optional ByVal Modulo As String = "ADMIN")
        Me._Modulo = Modulo
        tvw.Nodes.Clear()
        Dim dtMenuItems As New DataTable
        Dim queryString As String
        'Conexion a la base de datos donde esta nuestra tabla Menú.
        'Dim daMenu As New OracleDataAdapter
        Me.Conectar()
        'se invoca al procedimiento almacenado
        queryString = "Select * from " + Me.Vista + " Where MODULO='" + Modulo + "' Order by menuid,posicion"
        Me.CrearComando(queryString)
        'llenamos el datatable
        dtMenuItems = Me.EjecutarConsultaDataTable()
        'recorremos el datatable para agregar los elementos de que estaran en la cabecera del menú.
        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            'esta condicion indica q son elementos padre.
            If drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then
                Dim mnuMenuItem As New TreeNode
                mnuMenuItem.Value = drMenuItem("MenuId").ToString
                'mnuMenuItem.Value = drMenuItem("Roles").ToString
                mnuMenuItem.Text = drMenuItem("titulo").ToString
                mnuMenuItem.ToolTip = drMenuItem("descripcion").ToString
                mnuMenuItem.ImageUrl = drMenuItem("Icono").ToString
                ' mnuMenuItem.NavigateUrl = drMenuItem("Url").ToString
                mnuMenuItem.ShowCheckBox = False
                '                isUserInRoles(username, drMenuItem("Roles").ToString)
                'agregamos el Ítem al menú
                tvw.Nodes.Add(mnuMenuItem)
                'hacemos un llamado al metodo recursivo encargado de generar el árbol del menú.
                AddMenuItemPorUser(mnuMenuItem, dtMenuItems, username)
            End If
        Next
        tvw.ExpandAll()

        Me.Desconectar()
    End Sub

    Protected Sub AddMenuItemPorUser(ByRef mnuMenuItem As TreeNode, ByVal dtMenuItems As DataTable, ByVal username As String)
        'recorremos cada elemento del datatable para poder determinar cuales son elementos hijos
        'del menuitem dado pasado como parametro ByRef.

        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows

            If drMenuItem("PadreId").ToString.Equals(mnuMenuItem.Value) AndAlso _
            Not drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then
                Dim mnuNewMenuItem As New TreeNode
                mnuNewMenuItem.Value = drMenuItem("MenuId").ToString
                mnuNewMenuItem.Text = drMenuItem("titulo").ToString
                mnuNewMenuItem.ToolTip = drMenuItem("roles").ToString()
                'drMenuItem("descripcion").ToString()
                'mnuNewMenuItem.Text = drMenuItem("est").ToString
                mnuNewMenuItem.ImageUrl = drMenuItem("Icono").ToString
                'mnuNewMenuItem.NavigateUrl = drMenuItem("Url").ToString
                mnuNewMenuItem.ShowCheckBox = True
                'mnuNewMenuItem.Checked = IIf(drMenuItem("Est").ToString = "1", True, False)
                mnuNewMenuItem.Checked = isUserInRoles(username, drMenuItem("Roles").ToString)
                'mnuNewMenuItem.ToolTip = "Menu"
                'Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                mnuMenuItem.ChildNodes.Add(mnuNewMenuItem)
                'llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                AddMenuItemPorUser(mnuNewMenuItem, dtMenuItems, username)
            End If
        Next
    End Sub


    Public Function AgregarPerfil(ByVal Tvw As TreeView, ByVal nomper As String, ByVal modulo As String) As String
        Dim str As String = Me.Opciones_Seleccionadas(Tvw)
        Return Me.AgregarPerfil(str, nomper, modulo)
    End Function

    Private Function AgregarPerfil(ByVal lst As String, ByVal nomper As String, ByVal modulo As String) As String

        Me.Conectar()
        Me.ComenzarTransaccion()

        Dim vMenu(12) As String
        Dim k As Integer, nL As Integer
        vMenu = lst.Split(",")

        nL = lst.Split(",").Length
        Dim ra As Integer
        Try
            For k = 0 To nL - 1
                Me.CrearComando("ST_MENU_CREAR", CommandType.StoredProcedure)
                Me.AsignarParametroCad("inMNID", vMenu(k))
                Me.AsignarParametroCad("inNOMPER", nomper)
                Me.AsignarParametroCad("inModulo", modulo)

                ra += Me.EjecutarComando()
                
            Next k
            'Throw New Exception(Msg)
            Msg = "<br>" + "Se Agrego un Nuevo Perfil:  [" + nomper + "]:" + ra.ToString
            Me.ConfirmarTransaccion()
            Msg = MsgOk + Msg
            lErrorG = False
        Catch ex As Exception
            Msg = ex.Message
            Me.CancelarTransaccion()
            lErrorG = True
        End Try
        Me.Desconectar()
        Return Msg

    End Function

    Protected Function AgregarPerfil(ByVal lst As String, ByVal nomper As String, ByVal Modulo As String, ByVal t As Boolean) As String

        Dim vMenu(12) As String
        Dim k As Integer, nL As Integer
        vMenu = lst.Split(",")
        nL = lst.Split(",").Length
        Dim ra As Integer
            For k = 0 To nL - 1
                Me.CrearComando("ST_MENU_CREAR", CommandType.StoredProcedure)
                Me.AsignarParametroCad("inMNID", vMenu(k))
                Me.AsignarParametroCad("inNOMPER", nomper)
                Me.AsignarParametroCad("inModulo", Modulo)
                ra = Me.EjecutarComando()
            Next k
            Msg = "<br>" + "Se Agrego un Nuevo Perfil:  [" + nomper + "]:" + ra.ToString
            Msg = MsgOk + Msg
            lErrorG = False
        

        Return Msg


    End Function

    Protected Function IsUserInRole(ByVal sRoles As String) As Boolean
        Dim rol() As String = sRoles.Split(",")
        For i As Integer = 0 To rol.Length - 1
            If Roles.IsUserInRole(rol(i).ToString) = True Then
                Return True
            End If
        Next
        Return False
    End Function

    Protected Function UserInPerfil(ByVal UserName As String, ByVal Perfil As String) As String

        '  Dim queryString2 As String
        '  queryString2 = "(SELECT  Roles FROM vMenu Where (ApplicationId=(Select ApplicationId  From ORA_ASPNET_APPLICATIONS WHERE ApplicationName='" + Me.AppName + "')) And (MENUID ='" + vMenu(k) + "') AND (PERFIL='ADMIN'))"
        ' Dim dbCommand2 As New OracleCommand(queryString2, dbConnection)
        'Dim c As Object = dbCommand2.ExecuteScalar()
        'Roles.AddUserToRole(Me.usuario, Convert.ToString(c))
        Return ""
    End Function

    '------------------- SIN ACTUALIZAR
    Public Function Delete(ByVal nomper As String) As String

        Try
            Conectar()
            ComenzarTransaccion()

            querystring = "DELETE FROM Menu_Perfil WHERE perfil=:PERFIL"
            CrearComando(querystring)
            AsignarParametroCadena(":PERFIL", nomper)
            EjecutarComando()

            querystring = "DELETE FROM UserExt WHERE perfil=:PERFIL"
            CrearComando(querystring)
            AsignarParametroCadena(":PERFIL", nomper)
            EjecutarComando()

            Msg = "<br>" + "Se Eliminó Perfil  " + nomper
            ConfirmarTransaccion()
            Msg = MsgOk + Msg
            lErrorG = False
        Catch ex As Exception
            Msg = ex.Message
            CancelarTransaccion()
            lErrorG = True
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function

    Public Function ActualizarPerfil(ByVal Tvw As TreeView, ByVal nomper As String, ByVal Modulo As String) As String
        Dim str As String = Me.Opciones_Seleccionadas(Tvw)
        Return Me.ActualizarPerfil(str, nomper, Modulo)
    End Function

    Protected Function ActualizarPerfil(ByVal lst As String, ByVal nomper As String, ByVal Modulo As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            Dim queryString As String = "DELETE  FROM  Menu_Perfil WHERE Perfil=:Perfil And Modulo=:Modulo"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":Perfil", nomper)
            Me.AsignarParametroCadena(":Modulo", Modulo)

            Me.EjecutarComando()
            Me.AgregarPerfil(lst, nomper, Modulo)
            Msg = "<br>" + "Se Actualizó Perfil  [" + nomper + "]  Módulo [" + Modulo + "]"
            Me.ConfirmarTransaccion()
            Msg = MsgOk + Msg
            lErrorG = False
        Catch ex As Exception
            Msg = ex.Message
            Me.CancelarTransaccion()
            lErrorG = True
        End Try
        Me.Desconectar()
        Return Msg
    End Function

    Protected Function PagAut(ByVal perfil As String, ByVal nompag As String) As Boolean
        'Dim dataAdapter As New OracleDataAdapter
        'Dim datat As New Data.DataTable

        'Dim queryString As String = "select * from MENU m inner join pagaut pa ON m.menuid=pa.menuid Where lower(perfil)=lower(:perfil) and lower(nompag)=lower(:nompag)"
        'Dim dbCommand As New OracleCommand(queryString, dbConnection)

        'dbCommand.Parameters.Add("nompag", LCase(nompag))
        'dbCommand.Parameters.Add("perfil", LCase(perfil))

        'dataAdapter.SelectCommand = dbCommand
        'dataAdapter.Fill(datat)

        'Return IIf(datat.Rows.Count() > 0, True, False)
        'Me.dbConnection.Close()
        Return False
    End Function


    '--------------------------------------
    Protected Function Opciones_Seleccionadas(ByVal Tvw As TreeView) As String
        Dim str As String = ""
        If Tvw.CheckedNodes.Count > 0 Then
            Dim node As TreeNode
            For Each node In Tvw.CheckedNodes
                If str = "" Then
                    str = str + node.Value
                Else
                    str = str + "," + node.Value
                End If
            Next
            For Each node In Tvw.Nodes
                If node.ShowCheckBox.Value = False Then
                    str = str + "," + node.Value
                End If
            Next
        End If
        Return str
    End Function
    '--------------------
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSisPerfilesP() As DataTable
        Me.Conectar()
        Me.CrearComando("SELECT Perfil FROM vSisPerfil ")
        Dim data As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return data
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSisPerfilesU() As DataSet
        Me.Conectar()
        Me.CrearComando("SELECT Perfil FROM vSisPerfil ")
        Dim dataSet As DataSet = Me.EjecutarConsultaDataSet
        Me.Desconectar()
        Return dataSet
    End Function
    'Asignar Opciones a User
    Public Function AsigPermisosAUser(ByVal Tvw As TreeView, ByVal username As String) As String

        Try
            Dim Node As TreeNode
            For Each Node In Tvw.Nodes
                Me.AsigOpcionesAUser(Node, username)
            Next Node
            Msg = Me.MsgOk
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.lErrorG = True
        End Try

        Return Msg
    End Function

    Public Sub AsigOpcionesAUser(ByVal Tvw As TreeNode, ByVal username As String)
        Dim Node As TreeNode
        For Each Node In Tvw.ChildNodes
            AsigOpcionesAUser(Node, username)
            Dim roleName As String = Node.ToolTip
            If roleName <> "" Then
                If (Node.Checked = True) And (Roles.IsUserInRole(username, roleName) = False) Then
                    Roles.AddUserToRole(username, roleName)
                ElseIf (Node.Checked = False) And (Roles.IsUserInRole(username, roleName) = True) Then
                    Roles.RemoveUserFromRole(username, roleName)
                End If
            End If

        Next Node
    End Sub
    Public Function AsigOpcionesAUser(ByVal str As String, ByVal UserName As String) As String
        'Seleccionamos las Opciones de Este Perfil, en el Menu Ppal
        Dim u As New Usuarios
        Try
            Dim sRoles() As String = str.Split(",")
            If sRoles.Length > 0 Then
                Roles.AddUserToRoles(UserName, sRoles)
                'msg = u.AsigPerfil(UserName, Perfil)
                'If u.lErrorG = True Then
                'Roles.RemoveUserFromRoles(UserName, sRoles)
                'Else
                Msg = MsgOk
                'End If
            Else
                Msg = "No Roles"
            End If
        Catch ex As Exception
            Msg = ex.Message
        End Try
        Return Msg

    End Function

    Public Function AsigPerfilUser(ByVal Perfil As String, ByVal UserName As String) As String
        'Seleccionamos las Opciones de Este Perfil, en el Menu Ppal
        Dim u As New Usuarios
        Try
            Dim sRoles() As String = Me.GetRolesInPerfil(Perfil)
            If sRoles.Length > 0 Then
                'QUITAR TODOS LOS ROLES ACTUALES DEL USUARIO
                Dim sRUser() As String = Roles.GetRolesForUser(UserName)
                Roles.RemoveUserFromRoles(UserName, sRUser)
                'ASIGNAR ROLES DEL PERFIL
                Roles.AddUserToRoles(UserName, sRoles)
                'registrar perfil - username
                Msg = u.AsigPerfil(UserName, Perfil)

                If u.lErrorG = True Then
                    Roles.RemoveUserFromRoles(UserName, sRoles)
                    Throw New Exception(Msg)
                End If
                Msg = MsgOk + String.Format(" Roles Asignados [{0}]", sRoles.Length)
                lErrorG = False
            Else
                Msg = "No Hay Roles por Aplicar"
                lErrorG = False
            End If
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = False

        End Try
        Return Msg

    End Function
    Public Function DAsigPerfilUser(ByVal Perfil As String, ByVal UserName As String) As String
        'Seleccionamos las Opciones de Este Perfil, en el Menu Ppal
        Dim sRoles() As String = Me.GetRolesInPerfil(Perfil)
        Try

            If sRoles.Length > 0 Then
                Roles.RemoveUserFromRoles(UserName, sRoles)
                'Profile.SetPropertyValue("Nombre", "Boris González")
                'Profile.Save()
                Msg = "Se Quitó: Pero no se reinicio el perfil"
            Else
                Msg = "No Roles."
            End If

        Catch ex As Exception
            Msg = ex.Message
        End Try

        Return Msg

    End Function
    Protected Function isUserInRoles(ByVal username As String, ByVal sRoles As String) As Boolean
        Dim strRoles() As String = sRoles.Split(",")
        Dim i As Integer
        For i = 0 To strRoles.Length - 1
            If Roles.IsUserInRole(username, strRoles(i)) = True Then
                Return True
            End If
        Next
        Return False

    End Function
    'Retorna los Roles, que tiene esta Opción
    Protected Function GetRolesInOpcion(ByVal sRoles As String) As String()

        Dim strRoles() As String = sRoles.Split(",")
        Return strRoles

    End Function

    Protected Function GetRolesInPerfil(ByVal Perfil As String) As String()

        Dim queryString As String = "SELECT Roles FROM vMenu_Perfil Where SisPerfil='" + Perfil + "' And PadreID<>MenuID"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dtRoles As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()

        Dim sRoles(dtRoles.Rows.Count - 1) As String, strRoles As String = ""
        Dim k As Integer = 0
        If dtRoles.Rows.Count > 0 Then
            For i As Integer = 0 To dtRoles.Rows.Count - 1
                strRoles = IIf(strRoles = "", dtRoles.Rows(i)(0).ToString, strRoles + "," + dtRoles.Rows(i)(0).ToString)
                sRoles(k) = dtRoles.Rows(i)(0).ToString
                k = k + 1
            Next
        End If

        Return sRoles
    End Function

    Public Function GetUserInPerfil(ByVal Perfil As String) As DataSet
        Me.Conectar()

        Dim queryString As String = "SELECT USERNAME, TIPO_USUARIO FROM USEREXT WHERE PERFIL=:PERFIL  "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":PERFIL", Perfil)
        Dim dataSet As DataSet = Me.EjecutarConsultaDataSet
        Me.Desconectar()
        Return dataSet

    End Function

    Public Function GetUsers() As MembershipUserCollection

        Dim us As MembershipUserCollection
        us = Membership.GetAllUsers()
        Return us

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords() As DataTable
        Me.Conectar()
        Dim queryString As String = "Select * FRom " + Me.Vista + " Where Ppal='S'"
        Me.CrearComando(queryString)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Sub GenerarRoles()
        Dim sw As Boolean = True
        Me.Conectar()
        querystring = "SELECT * FROM   " + Me.Vista
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Dim strrole As String = ""
        Dim strrole2 As String = ""
        Dim CrearonRoles As Boolean = False
        For i As Integer = 0 To dataTb.Rows.Count - 1
            Dim rol As String = dataTb.Rows(i)("ROLES").ToString
            If (Roles.RoleExists(rol) = False) Then
                Roles.CreateRole(rol)
                Roles.AddUserToRole("admin", rol)
                strrole = strrole + rol + "<br>"
                CrearonRoles = True
            End If
        Next i
        If CrearonRoles Then
            Mail.EnviarAuto("Error:[Usuario Anónimo]" + Now.ToLongTimeString, "Roles Creados" + strrole)
        End If

    End Sub



End Class








