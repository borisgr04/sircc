'FILTRA POR DEPENDENCIA DELEGADA
Imports System.Data
Partial Class Interventorias_CtrlUsr_DetContratosI
    Inherits CtrlUsrComun

#Region "Propiedades del control"
    ''' <summary>
    ''' Valor Total Prop(Valor a pagar por parte de la Entidad
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Valor_Total_Prop As String
        Get
            If Me.dtContratos.Rows.Count > 0 Then
                Return Me.dtContratos.Rows(0).Item("Valor_Total_Prop").ToString
            Else
                Return 0
            End If
        End Get
    End Property
    Public Property dtContratos() As DataTable
        Set(ByVal value As DataTable)
            ViewState("dtPcon") = value
        End Set
        Get
            Return ViewState("dtPcon")
        End Get
    End Property
    ''' <summary>
    ''' Dependencia Delegada del Proceso de Contratación
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Dep_PCon As String
        Get
            If Me.dtContratos.Rows.Count > 0 Then
                Return Me.dtContratos.Rows(0).Item("Dep_PCon").ToString
            Else
                Return ""
            End If
        End Get
    End Property
    ''' <summary>
    ''' Estado actual del Contrato
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Estado As String
        Get
            If Me.dtContratos.Rows.Count > 0 Then
                Return Me.dtContratos.Rows(0).Item("Est_Con").ToString
            Else

                Return ""
            End If
        End Get
    End Property
    ''' <summary>
    ''' Dependencia que genera la Necesidad
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Dep_Con As String
        Get
            If Me.dtContratos.Rows.Count > 0 Then
                Return Me.dtContratos.Rows(0).Item("Dep_Con").ToString
            Else

                Return ""
            End If
        End Get
    End Property
    ''' <summary>
    ''' Tipo de Proceso
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TProc() As String
        Get
            Return Me.DtPCon.Rows(0).Cells(1).Text
        End Get
    End Property

    Public WriteOnly Property DataSource As Object
        Set(ByVal value As Object)
            DtPCon.DataSource = value
        End Set
    End Property

    Public Overrides Sub DataBind()
        DtPCon.DataBind()
    End Sub

#End Region

End Class
