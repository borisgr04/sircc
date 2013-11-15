Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Resources
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class ConsCronograma
    Private ctx As New BDDatosG
    Private mMsg As String
    Property Msg As String
        Get
            Return mMsg
        End Get
        Set(value As String)
            mMsg = value
        End Set
    End Property
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function getActividades2(Vigencia As String, TipProc As String, Clasificacion As String, Encargado As String) As DataTable

        Dim lst As New List(Of PCronogramaDTO)
        Dim datat As New DataTable
        Dim querystring As String
        querystring = "Select Cod_Act,Nom_Act Nom_Act,FechaI,FechaF,Est_Act,Est_Proc,Num_Proc,Pro_Sel_Nro, Obj_Con,Encargado, Nom_Est,genfechacrono (num_proc, cod_act) FechaCrono, obs_seg "
        querystring += " From vpcronogramaspanel where Num_Proc Like :Vigencia and cod_tpro=:TipProc And Final='NO'  " 'And Nom_Est='COMPLETADO' And Is_Final='NO'"

        If Clasificacion = "OB" Then
            querystring += " And  Obligatorio='SI'"
        ElseIf Clasificacion = "NT" Then
            querystring += " And  Notificar='SI'"
        ElseIf Clasificacion = "TD" Then
            'nada
        End If

        If Not String.IsNullOrEmpty(Encargado) Then
            querystring += " And  UsuEncargado='" + Encargado + "'"
        End If



        'Try
        ctx.Conectar()
        ctx.CrearComando(querystring)
        ctx.AsignarParametroCadena(":Vigencia", "%" + Vigencia)
        ctx.AsignarParametroCadena(":TipProc", TipProc)
        'Throw New Exception(ctx.getComando)
        datat = ctx.EjecutarConsultaDataTable()


        'Catch ex As Exception
        '    Msg = ex.Message
        'Finally
        'ctx.Desconectar()
        'End Try

        Return datat

    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function getActividades(Vigencia As String, TipProc As String) As List(Of PCronogramaDTO)

        Dim lst As New List(Of PCronogramaDTO)
        Dim datat As New DataTable
        Dim querystring As String = "Select Cod_Act,Nom_Act,FechaI,FechaF,Est_Act,Est_Proc From PCronogramas where Num_Proc Like :Vigencia and cod_tpro=:TipProc"
        Try
            ctx.Conectar()
            ctx.CrearComando(querystring)
            ctx.AsignarParametroCadena(":Vigencia", "%" + Vigencia)
            ctx.AsignarParametroCadena(":TipProc", TipProc)
            datat = ctx.EjecutarConsultaDataTable()
            For Each row As DataRow In datat.Rows
                lst.Add(MapearToObjet(row))
            Next
        Catch ex As Exception
            Msg = ex.Message
        Finally
            ctx.Desconectar()
        End Try

        Return lst

    End Function

    Private Function MapearToObjet(row As DataRow) As PCronogramaDTO
        Dim item As New PCronogramaDTO

        item.Cod_Act = row("Cod_Act")
        item.Nom_Act = row("Nom_Act")
        item.FechaI = row("FechaI")
        item.FechaF = row("FechaF")
        item.Est_Act = row("Est_Act")
        item.Est_Proc = row("Est_Proc")

        Return item
    End Function
    

End Class

Public Class PCronogramaDTO
    Private mCod_Act As String
    Private mNom_Act As String
    Private mFechaI As Date
    Private mFechaF As Date
    Private mEst_Act As String
    Private mEst_Proc As String

    Property Cod_Act As String
        Get
            Return mCod_Act
        End Get
        Set(value As String)
            mCod_Act = value
        End Set
    End Property
    Property Nom_Act As String
        Get
            Return mNom_Act
        End Get
        Set(value As String)
            mNom_Act = value
        End Set
    End Property
    Property FechaI As Date
        Get
            Return mFechaI
        End Get
        Set(value As Date)
            mFechaI = value
        End Set
    End Property
    Property FechaF As Date
        Get
            Return mFechaF
        End Get
        Set(value As Date)
            mFechaF = value
        End Set
    End Property
    Property Est_Act As String
        Get
            Return mEst_Act
        End Get
        Set(value As String)
            mEst_Act = value
        End Set
    End Property
    Property Est_Proc As String
        Get
            Return mEst_Proc
        End Get
        Set(value As String)
            mEst_Proc = value
        End Set
    End Property
End Class