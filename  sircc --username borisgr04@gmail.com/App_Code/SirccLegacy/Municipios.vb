Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

'Clase para manejar la Tabla Municipios de la Base de datos
'Fecha Creaciòn: 23 Abril de 2012
'Autor: Boris Gonzalez
<System.ComponentModel.DataObject()> _
Public Class Municipios
    Inherits BDDatos

    Sub New()
        Me.Tabla = "Municipios"
        Me.VistaDB = "Municipios"

    End Sub
    ' Funciòn Insert: Agrega datos a la tabla Municipios
    Public Function Insert(ByVal MUN_COD As String, ByVal MUN_NOM As String) As String
        Me.Conectar()
        Try
            Me.CrearComando("INSERT INTO Municipios (COD_MUN,NOM_MUN)VALUES(:COD_MUN,:NOM_MUN)")
            AsignarParametroCadena(":COD_MUN", MUN_COD)
            AsignarParametroCadena(":NOM_MUN", MUN_NOM)
            num_reg = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    '' Funciòn Actualizar: Acatualiza Datos a la Tabla Municipios
    Public Function Update(ByVal MUN_COD_OR As String, ByVal MUN_COD As String, ByVal MUN_NOM As String) As String
        Me.Conectar()
        Try
            CrearComando("UPDATE Municipios SET COD_MUN='" + MUN_COD + "',NOM_MUN='" + MUN_NOM + "' WHERE COD_MUN='" + MUN_COD_OR + "' ")
            num_reg = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    ''Funciòn Delete: elimina datos a la tabla Municipios
    '' Parametros: Tcta_Codi : Còdigo
    Public Function Delete(ByVal MUN_COD As String) As String
        Me.Conectar()
        Try
            CrearComando("DELETE FROM Municipios WHERE COD_MUN='" + MUN_COD + "'")
            num_reg = EjecutarComando()
            Me.Msg = MsgOk + " # Registros Eliminados:" + num_reg.ToString

            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error :" '+ ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM Municipios ORDER BY COD_MUN"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    '
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
        Public Function GetbyPk(ByVal Cod As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM Municipios Where COD_MUN='" + Cod + "' "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
