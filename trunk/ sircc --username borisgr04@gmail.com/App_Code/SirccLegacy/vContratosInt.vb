Imports Microsoft.VisualBasic

Public Class vContratosInt
    Public Property Numero() As String
        Get
            Return m_Numero
        End Get
        Set(value As String)
            m_Numero = value
        End Set
    End Property
    Private m_Numero As String
    Public Property Tipo() As String
        Get
            Return m_Tipo
        End Get
        Set(value As String)
            m_Tipo = value
        End Set
    End Property
    Private m_Tipo As String
    Public Property Objeto() As String
        Get
            Return m_Objeto
        End Get
        Set(value As String)
            m_Objeto = value
        End Set
    End Property
    Private m_Objeto As String
    Public Property Ide_Contratista() As String
        Get
            Return m_Ide_Contratista
        End Get
        Set(value As String)
            m_Ide_Contratista = value
        End Set
    End Property
    Private m_Ide_Contratista As String
    Public Property Contratista() As String
        Get
            Return m_Contratista
        End Get
        Set(value As String)
            m_Contratista = value
        End Set
    End Property
    Private m_Contratista As String
    Public Property Fecha_Suscripcion() As DateTime
        Get
            Return m_Fecha_Suscripcion
        End Get
        Set(value As DateTime)
            m_Fecha_Suscripcion = value
        End Set
    End Property
    Private m_Fecha_Suscripcion As DateTime
    Public Property Estado() As String
        Get
            Return m_Estado
        End Get
        Set(value As String)
            m_Estado = value
        End Set
    End Property
    Private m_Estado As String
    Public Property DependenciaNec() As String
        Get
            Return m_DependenciaNec
        End Get
        Set(value As String)
            m_DependenciaNec = value
        End Set
    End Property
    Private m_DependenciaNec As String
    Public Property DependenciaDel() As String
        Get
            Return m_DependenciaDel
        End Get
        Set(value As String)
            m_DependenciaDel = value
        End Set
    End Property
    Private m_DependenciaDel As String
    Public Property Ide_Interventor() As String
        Get
            Return m_Ide_Interventor
        End Get
        Set(value As String)
            m_Ide_Interventor = value
        End Set
    End Property
    Private m_Ide_Interventor As String
    Public Property Nom_Interventor() As String
        Get
            Return m_Nom_Interventor
        End Get
        Set(value As String)
            m_Nom_Interventor = value
        End Set
    End Property
    Private m_Nom_Interventor As String
    Public Property Vigencia() As Short
        Get
            Return m_Vigencia
        End Get
        Set(value As Short)
            m_Vigencia = value
        End Set
    End Property
    Private m_Vigencia As Short
    Public Property Dep_Nec() As String
        Get
            Return m_Dep_Nec
        End Get
        Set(value As String)
            m_Dep_Nec = value
        End Set
    End Property
    Private m_Dep_Nec As String
    Public Property Dep_Del() As String
        Get
            Return m_Dep_Del
        End Get
        Set(value As String)
            m_Dep_Del = value
        End Set
    End Property
    Private m_Dep_Del As String
    Public Property Cod_Tip() As String
        Get
            Return m_Cod_Tip
        End Get
        Set(value As String)
            m_Cod_Tip = value
        End Set
    End Property
    Private m_Cod_Tip As String
    Public Property Cod_STip() As String
        Get
            Return m_Cod_STip
        End Get
        Set(value As String)
            m_Cod_STip = value
        End Set
    End Property
    Private m_Cod_STip As String
    Public Property Valor_Contrato() As Decimal
        Get
            Return m_Valor_Contrato
        End Get
        Set(value As Decimal)
            m_Valor_Contrato = value
        End Set
    End Property
    Private m_Valor_Contrato As Decimal


    Public Property FilxFS() As Boolean
        Get
            Return m_FilxFS
        End Get
        Set(value As Boolean)
            m_FilxFS = value
        End Set
    End Property
    Private m_FilxFS As Boolean
    Public Property FS_Inicial() As DateTime
        Get
            Return m_FS_Inicial
        End Get
        Set(value As DateTime)
            m_FS_Inicial = value
        End Set
    End Property
    Private m_FS_Inicial As DateTime
    Public Property FS_Final() As DateTime
        Get
            Return m_FS_Final
        End Get
        Set(value As DateTime)
            m_FS_Final = value
        End Set
    End Property
    Private m_FS_Final As DateTime



End Class

