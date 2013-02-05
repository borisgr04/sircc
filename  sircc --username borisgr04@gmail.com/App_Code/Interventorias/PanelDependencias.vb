Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Public Class PanelDependencias
    Inherits BDDatos

    Dim mCod_Contrato As String
    Property Fec_Fin As String
        Get
            Return mCod_Contrato
        End Get
        Set(ByVal value As String)
            mCod_Contrato = value
        End Set
    End Property

    Public Function GetContratosT(ByVal filtro As String) As DataTable
        Me.Conectar()

        querystring = "Select Numero,Contratista,Obj_Con,tipo, nom_stip,Fec_Sus_Con, Plazo_texto,Valor_Total_Doc,Estado,Val_Adi, Acta_Actual,Val_Con,Est_Con From vContratos_sinc_p"
        querystring += " Where  (Upper(Obj_Con) like :filtro OR Numero Like :filtro OR Contratista Like :filtro) and Interventoria In (select cod_dep from dependencia where ide_ter=:Usuario)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Usuario", Me.usuario)
        Me.AsignarParametroCadena(":filtro", "%" + UCase(filtro) + "%")
        Me.AsignarParametroCadena(":filtro", "%" + UCase(filtro) + "%")
        Me.AsignarParametroCadena(":filtro", "%" + UCase(filtro) + "%")
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetContratosDes(ByVal filtro As String) As DataTable
        Me.Conectar()

        querystring = "Select Numero,Contratista,Obj_Con,tipo, nom_stip,Fec_Sus_Con, Plazo_texto,Valor_Total_Doc,Estado,Val_Adi, Acta_Actual,Val_Con,Est_Con From vContratos_sinc_p"
        querystring += " Where  (Upper(Obj_Con) like :filtro OR Numero Like :filtro OR Contratista Like :filtro) and Interventoria In (select cod_dep from dependencia where ide_ter=:Usuario) and Numero in (select cod_con from interventores_contrato)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Usuario", Me.usuario)
        Me.AsignarParametroCadena(":filtro", "%" + UCase(filtro) + "%")
        Me.AsignarParametroCadena(":filtro", "%" + UCase(filtro) + "%")
        Me.AsignarParametroCadena(":filtro", "%" + UCase(filtro) + "%")
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetContratosSDes(ByVal filtro As String) As DataTable
        Me.Conectar()

        querystring = "Select Numero,Contratista,Obj_Con,tipo, nom_stip,Fec_Sus_Con, Plazo_texto,Valor_Total_Doc,Estado,Val_Adi, Acta_Actual,Val_Con,Est_Con From vContratos_sinc_p"
        querystring += " Where  (Upper(Obj_Con) like :filtro OR Numero Like :filtro OR Contratista Like :filtro) and Interventoria In (select cod_dep from dependencia where ide_ter=:Usuario) and Numero not in (select cod_con from interventores_contrato)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Usuario", Me.usuario)
        Me.AsignarParametroCadena(":filtro", "%" + UCase(filtro) + "%")
        Me.AsignarParametroCadena(":filtro", "%" + UCase(filtro) + "%")
        Me.AsignarParametroCadena(":filtro", "%" + UCase(filtro) + "%")
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetContratosDep(ByVal filtro As String, ByVal oper As String) As DataTable
        Select Case oper
            Case "Todos"
                Return GetContratosT(filtro)
            Case "Asignados"
                Return GetContratosDes(filtro)
            Case "Sin Asignar"
                Return GetContratosSDes(filtro)
        End Select
    End Function
End Class
