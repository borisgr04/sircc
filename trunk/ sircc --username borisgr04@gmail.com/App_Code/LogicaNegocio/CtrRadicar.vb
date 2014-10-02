Imports Microsoft.VisualBasic
Imports System.Data


Public Class CtrRadicar
    Implements IMsg

    Private ctx As New BDDatosG
    Dim _Msg As String
    Dim _lErrorG As Boolean

    Public Property lErrorG As Boolean Implements IMsg.lErrorG
        Get
            Return _lErrorG
        End Get
        Set(value As Boolean)
            _lErrorG = value
        End Set
    End Property

    Public Property Msg As String Implements IMsg.Msg
        Get
            Return _Msg
        End Get
        Set(value As String)
            _Msg = value
        End Set
    End Property


    Public Function GetProceso(Num_Proc As String, Grupo As String) As DataTable

        Dim p As New GProcesos
        Dim oConf As New ConfiguracionDAO

        Dim E As EConfiguracion = oConf.GetbyPk(Conf.Busc_Proc)
        If Not E Is Nothing Then
            If E.Valor = Conf.VBP_Todos Then
                Return p.GetByPk(Num_Proc, Grupo)

            Else 'If E.Valor = Conf.VBP_ADCE Then
                Return p.GetByPkCEAD(Num_Proc, Grupo)
            End If
        Else
            _Msg = "No Existe Configuración en el sistema para realizar esta busqueda."
            Return New DataTable()
        End If
        




    End Function

End Class
