Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel

Public Class ContratosA
    Inherits Contratos
    Private _ResPRad As String
    Property ResPRad() As String
        Get
            Return _ResPRad
        End Get
        Set(ByVal value As String)
            _ResPRad = value
        End Set
    End Property
    Public Sub RadicarA(ByVal Num_Proc As String, ByVal fec_Rad As Date)
        Me.Conectar()
        querystring = "PRADICACION"
        CrearComando(querystring, CommandType.StoredProcedure)

        Dim preturn As DbParameter = AsignarParametroReturn(100)
        AsignarParametroCad("Num_Proc", Num_Proc)
        'Throw New Exception(fec_Rad.ToShortDateString)
        AsignarParametroCad("Fec_Rad", fec_Rad.ToShortDateString)
        EjecutarComando()
        Me.ResPRad = preturn.Value.ToString().Replace(Publico.NoPunto_Dec, Publico.Punto_Dec)
        Me.Desconectar()
    End Sub
    Public Function Asignar_Encargado(ByVal PRO_SEL_NRO_PK As String, ByVal USUENCARGADO As String) As String
        Me.Conectar()
        Try
            Asignar_EncargadoP(PRO_SEL_NRO_PK, USUENCARGADO)
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        End Try
        Me.Desconectar()
        Return Me.Msg
    End Function
    Public Sub Asignar_EncargadoP(ByVal COD_CON As String, ByVal ENCARGADO As String)
        If ENCARGADO.Trim.Length = 0 Then
            Throw New Exception("El funcionario no puede estar vacio")
        End If
        querystring = "Update CONTRATOS SET ENCARGADO=:ENCARGADO WHERE COD_CON=:COD_CON"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ENCARGADO", ENCARGADO)
        Me.AsignarParametroCadena(":COD_CON", COD_CON)
        Me.num_reg = Me.EjecutarComando()
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetvHUsuEncargados(ByVal Cod_Con As String) As DataTable
        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vhusuenc_con Where Cod_Con=:Cod_Con Order by fec_reg desc "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
