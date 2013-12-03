Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
''' <summary>
''' Gestión de Proyectos
''' Se agregaron campos de gestión de proyetco, valor aportes propios, aportantes(otros), tipo(sgr o rp), 
''' </summary>
''' <remarks></remarks>
<System.ComponentModel.DataObject()> _
Public Class Proyectos
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "Proyectos"
        Me.Vista = "Proyectos"
        
    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByTipo(ByVal Proyecto As String) As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista + " WHERE Proyecto=:Proyecto"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Proyecto", Proyecto)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 24 FEBRERO DE 2011
    ''' MODIFICACION:
    ''' SE CREA LA FUNCION GETPROYECTOS PARA IMPLEMENTAR EN EL CONTROL DE BUSQUEDA
    ''' DE PROYECTOS
    ''' </summary>
    ''' <param name="Proyecto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetProyectos(ByVal Proyecto As String) As DataTable
        Me.Conectar()
        If Not String.IsNullOrEmpty(Proyecto) Then
            querystring = "SELECT * FROM  " + Vista + " WHERE Proyecto LIKE :Proyecto or Upper(Nombre_Proyecto) LIKE :NomProyecto"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Proyecto", "%" + Proyecto + "%")
            Me.AsignarParametroCadena(":NomProyecto", "%" + UCase(Proyecto) + "%")
        Else
            querystring = "SELECT * FROM  " + Vista + " WHERE 1=0"
            Me.CrearComando(querystring)
        End If
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Vigencia As String, ByVal Proyecto As String, ByVal Nombre_Proyecto As String, ByVal Fecha_Rad As String, ByVal Comite As String, ByVal Valor As String, ByVal estado As String, IDE_APORTANTE As String, TIP_PRO As String, APORTES_PROPIOS As String) As String
        Me.Conectar()
        Try
            'Me.ComenzarTransaccion()
            querystring = "INSERT INTO proyectos(Vigencia, Proyecto, Nombre_Proyecto, Fecha_Rad, Comite, Valor, Estado,IDE_APORTANTE,TIP_PRO,APORTES_PROPIOS)VALUES(:Vigencia, :Proyecto, :Nombre_Proyecto,to_date(:Fecha_Rad,'dd/mm/yyyy'), :Comite, :Valor, :Estado,:IDE_APORTANTE,:TIP_PRO,:APORTES_PROPIOS) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Vigencia", Vigencia)
            Me.AsignarParametroCadena(":Proyecto", Proyecto)
            Me.AsignarParametroCadena(":Nombre_Proyecto", Nombre_Proyecto)
            Me.AsignarParametroCadena(":Fecha_Rad", CDate(Fecha_Rad).ToShortDateString)
            Me.AsignarParametroCadena(":Comite", Comite)
            Me.AsignarParametroCadena(":Valor", Valor)
            Me.AsignarParametroCadena(":Estado", estado)
            Me.AsignarParametroCadena(":IDE_APORTANTE", IDE_APORTANTE)
            Me.AsignarParametroCadena(":TIP_PRO", TIP_PRO)
            Me.AsignarParametroCadena(":APORTES_PROPIOS", APORTES_PROPIOS)


            Me.num_reg = Me.EjecutarComando()
            'Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            'Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal Proyecto_O As String, ByVal Vigencia As String, ByVal Proyecto As String, ByVal Nombre_Proyecto As String, ByVal Fecha_Rad As String, ByVal Comite As String, ByVal Valor As String, ByVal estado As String, IDE_APORTANTE As String, TIP_PRO As String, APORTES_PROPIOS As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE Proyectos SET Vigencia=:Vigencia, Proyecto=:Proyecto, Nombre_Proyecto=:Nombre_Proyecto, Fecha_Rad=to_date(:Fecha_Rad,'dd/mm/yyyy'), Comite=:Comite, Valor=:Valor, Estado=:Estado,IDE_APORTANTE=:IDE_APORTANTE,TIP_PRO=:TIP_PRO, APORTES_PROPIOS=:APORTES_PROPIOS WHERE Proyecto=:Proyecto_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Vigencia", Vigencia)
            Me.AsignarParametroCadena(":Proyecto", Proyecto)
            Me.AsignarParametroCadena(":Nombre_Proyecto", Nombre_Proyecto)
            Me.AsignarParametroCadena(":Fecha_Rad", CDate(Fecha_Rad).ToShortDateString)
            Me.AsignarParametroCadena(":Comite", Comite)
            Me.AsignarParametroCadena(":Valor", Valor)
            Me.AsignarParametroCadena(":Estado", estado)
            Me.AsignarParametroCadena(":IDE_APORTANTE", IDE_APORTANTE)
            Me.AsignarParametroCadena(":TIP_PRO", TIP_PRO)
            Me.AsignarParametroCadena(":APORTES_PROPIOS", APORTES_PROPIOS)


            Me.AsignarParametroCadena(":Proyecto_O", Proyecto_O)

            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Function Delete(ByVal Proyecto As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Proyectos WHERE Proyecto=:Proyecto"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Proyecto", Proyecto)

            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Proyecto As String) As DataTable
        querystring = "SELECT * FROM  " + Tabla + " Where Proyecto=:Proyecto"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Proyecto", Proyecto)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    ''' <summary>
    ''' Get Proyectos
    ''' </summary>
    ''' <param name="Proyecto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetProyectos(Vigencia As String, ByVal Proyecto As String) As DataTable
        Me.Conectar()
        If Not String.IsNullOrEmpty(Proyecto) Then
            querystring = "SELECT * FROM  " + Vista + " WHERE Vigencia=:Vigencia And (Proyecto LIKE :Proyecto or Upper(Nombre_Proyecto) LIKE :NomProyecto) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Vigencia", Vigencia)
            Me.AsignarParametroCadena(":Proyecto", "%" + Proyecto + "%")
            Me.AsignarParametroCadena(":NomProyecto", "%" + UCase(Proyecto) + "%")
        Else
            querystring = "SELECT * FROM  " + Vista + " WHERE Vigencia=:Vigencia"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Vigencia", Vigencia)
        End If
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    ''' <summary>
    ''' Get Proyectos
    ''' </summary>
    ''' <param name="Proyecto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetProyectosC(Vigencia As String, ByVal Proyecto As String) As DataTable
        Me.Conectar()



        If Not String.IsNullOrEmpty(Proyecto) Then
            querystring = "SELECT p.*, "
            querystring += " (Select Count(cp.Proyecto) from cproyectos cp where cp.Proyecto=p.Proyecto) CantxCont FROM  " + Vista + " p WHERE  Vigencia=:Vigencia And p.Proyecto LIKE :Proyecto or Upper(p.Nombre_Proyecto) LIKE :NomProyecto"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Vigencia", Vigencia)
            Me.AsignarParametroCadena(":Proyecto", "%" + Proyecto + "%")
            Me.AsignarParametroCadena(":NomProyecto", "%" + UCase(Proyecto) + "%")
        Else
            querystring = "SELECT p.*, "
            querystring += " (Select Count(cp.Proyecto) from cproyectos cp where cp.Proyecto=p.Proyecto) CantxCont FROM  " + Vista + " p WHERE  Vigencia=:Vigencia "

            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Vigencia", Vigencia)
        End If
        'Throw New Exception(Me.vComando.CommandText)

        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    




End Class