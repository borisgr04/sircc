Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Public Class ContratosACargo
    Inherits BDDatos
    Private _Num_PSol As String
    Property Num_PSol() As String
        Get
            Return _Num_PSol
        End Get
        Set(ByVal value As String)
            _Num_PSol = value
        End Set
    End Property

    Public Sub New()
        Me.Tabla = "PSolicitudes"
        Me.Vista = "VPSolicitudes"
    End Sub
    ''' <summary>
    '''  Retorna las solicitudes a cargo del usuario actual dependenciendo de su estado de RECIBIDO, en un periodio de fecha
    ''' </summary>
    ''' <param name="RECIBIDO">SI (S) o (NO)</param>
    ''' <param name="Desde">Fecha Inicial del Periodo</param>
    ''' <param name="Hasta">Fecha Final del Periodo</param>
    ''' <param name="Cod_Sol">Es opcional, para buscar una solicitud,se puede emplear % para aplicar el LIke</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByAbogxFec(ByVal RECIBIDO As String, ByVal Desde As Date, ByVal Hasta As Date, Optional ByVal Cod_Sol As String = "", Optional ByVal Concepto As String = "") As DataTable

        Me.Num_PSol = Num_PSol
        Me.Conectar()
        If String.IsNullOrEmpty(Cod_Sol) Then
            querystring = "SELECT * FROM VPSOLICITUDESHREV WHERE Recibido=:Recibido and Id_Abog_Enc=:Id_Abog_Enc And FECHA_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Concepto Like :Concepto"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
            Me.AsignarParametroCadena(":Recibido", RECIBIDO)
            Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
            Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
            Me.AsignarParametroCadena(":Concepto", "%" + UCase(Concepto) + "%")
        Else
            querystring = "SELECT * FROM VPSOLICITUDESHREV WHERE Recibido=:Recibido and Id_Abog_Enc=:Id_Abog_Enc And FECHA_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Cod_Sol Like :Cod_Sol And Concepto Like :Concepto"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
            Me.AsignarParametroCadena(":Recibido", RECIBIDO)
            Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
            Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
            Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Cod_Sol) + "%")
            Me.AsignarParametroCadena(":Concepto", "%" + UCase(Concepto) + "%")
            '
        End If
        'Throw New Exception(Me.vComando.CommandText)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataTb
    End Function
End Class
