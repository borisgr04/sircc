Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class HRSolProDAO
    Inherits BDDatos



    Public Sub New()

    End Sub

    Shared Instance As HRSolProDAO

    Public Shared Function GetInstance() As HRSolProDAO
        If Instance Is Nothing Then
            Instance = New HRSolProDAO
        End If
        Return Instance
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolPro(Cod_Sol As String) As DataTable
        'If Tipo.ToUpper() = "S" Then
        querystring = "SELECT Cod_Sol, Obj_Sol,Dep_Nec,Dep_Del,Nom_Tip,Nom_Stip,Nom_Tproc,Proceso FROM  vPSolicitudes Where Cod_Sol=:Codigo"
        'Else
        'querystring = "SELECT Cod_Sol, Obj_Sol,Dep_Nec,Dep_Del,Nom_Tip,Nom_Stip,Nom_Tproc,Proceso FROM  vPSolicitudes Where Proceso=:Codigo"
        'End If

        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Codigo", Cod_Sol)
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    Private Sub Delete(Cod_Sol As String, obj As HRSolPro)
        Me.querystring = " Delete From HRSolPro Where Cod_Sol=:Cod_Sol And  Cod_Tip = :Cod_Tip"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)
        Me.AsignarParametroCadena(":Cod_Tip", obj.Cod_Tip)
        num_reg += EjecutarComando()
    End Sub

    Private Sub Update(Cod_Sol As String, obj As HRSolPro)
        Me.querystring = " Update HRSolPro Set Fec_Doc=:Fec_Doc, Ide_Doc=:Ide_Doc,UsAp_M=:UsAp_M,UsBd=user,FecMod=sysdate Where Cod_Sol=:Cod_Sol And  Cod_Tip = :Cod_Tip"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)
        Me.AsignarParametroCadena(":Cod_Tip", obj.Cod_Tip)
        Me.AsignarParametroCadena(":Fec_Doc", obj.Fec_Doc)
        Me.AsignarParametroCadena(":Ide_Doc", obj.Ide_Doc)
        Me.AsignarParametroCadena(":UsAp_M", Me.usuario)
        num_reg += EjecutarComando()
    End Sub
    Private Sub Insertar(Cod_Sol As String, obj As HRSolPro)
        Dim datatb As DataTable
        Me.querystring = " Select * From HRSolPro Where Cod_Sol=:Cod_Sol And  Cod_Tip=:Cod_Tip"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", obj.Cod_Sol)
        Me.AsignarParametroCadena(":Cod_Tip", obj.Cod_Tip)
        datatb = EjecutarConsultaDataTable()
        If datatb.Rows.Count = 0 Then
            Me.querystring = " Insert Into HRSolPro (Cod_Sol, Cod_Tip, Fec_Doc, Ide_Doc, UsAp, UsBd, FecReg)"
            Me.querystring += " Values (:Cod_Sol, :Cod_Tip, :Fec_Doc, :Ide_Doc, :UsAp, user, sysdate)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Sol", obj.Cod_Sol)
            Me.AsignarParametroCadena(":Cod_Tip", obj.Cod_Tip)
            Me.AsignarParametroCadena(":Fec_Doc", obj.Fec_Doc)
            Me.AsignarParametroCadena(":Ide_Doc", obj.Ide_Doc)
            Me.AsignarParametroCadena(":UsAp", Me.usuario)
            num_reg += EjecutarComando()
            Msg += obj.Cod_Tip + "-"
            'Else
            'Msg += "No agrego" + " " + num_reg.ToString
        End If
    End Sub

    Public Function Insert(Cod_Sol As String, obj As HRSolPro) As String
        Try
            num_reg = 0
            Me.Conectar()
            Insertar(Cod_Sol, obj)
            lErrorG = False
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Function Actualizar(Cod_Sol As String, lstObj As List(Of HRSolPro)) As String
        Dim Cods(lstObj.Count) As String
        Try
            num_reg = 0
            Me.Conectar()
            Dim i As Integer = 0
            For Each obj In lstObj
                If obj.Oper = "D" Then
                    Delete(Cod_Sol, obj)
                Else
                    Update(Cod_Sol, obj)
                End If
            Next
            Msg = MsgOk + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function Insert(Cod_Sol As String, lstObj As List(Of HRSolPro)) As String
        Try
            num_reg = 0
            Me.Conectar()
            For Each obj In lstObj
                Insertar(Cod_Sol, obj)
            Next
            Msg = String.Format("Se Agregaron los documentos de codigo {0} - Filas Afectadas {1} ", Msg, num_reg)
            lErrorG = False
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

End Class
