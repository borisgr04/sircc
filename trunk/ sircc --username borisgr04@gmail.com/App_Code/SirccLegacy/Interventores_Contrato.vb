Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Interventores_Contrato
    Inherits BDDatos

    ''' <summary>
    ''' Consulta Listado de Impuestos de los Contratos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vInterventores_Contrato "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    'Public Function GetbyPk(ByVal Cod_Con As String, ByVal Nro_Cdp As String) As DataTable
    '    Me.Conectar()
    '    querystring = "SELECT * FROM Imp_Contratos Where Cod_Con=:Cod_Con And Nro_Cdp=:Nro_Cdp"
    '    Me.CrearComando(querystring)
    '    Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
    '    Me.AsignarParametroCadena(":Nro_Cdp", Nro_Cdp)
    '    Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
    '    Me.Desconectar()
    '    Return dataTb

    'End Function

    ''' <summary>
    ''' Consulta impuestos relacionados con un contrato/convenio
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        'querystring = "SELECT * FROM vInterventores_Contrato Where Cod_Con=:Cod_Con"
        querystring = " SELECT ic.ide_int ide_int, tr.nom_ter nom_ter, ic.est_int est_int,ic.obs_int obs_int,nom_tip ntip_int,ic.tip_int tip_int, ic.cod_con cod_con,cod_con_int "
        querystring += " FROM interventores_contrato ic "
        querystring += " INNER JOIN vterceros tr ON ic.ide_int = tr.ide_ter "
        querystring += " INNER JOIN tipo_interventor ti ON  ic.tip_int=ti.COD_TIP "
        querystring += " Where Cod_Con=:Cod_Con "

        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        'If Cod_Con <> "" Then
        ' Throw New Exception(Me.vComando.CommandText)
        'End If

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsAC(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        'querystring = "SELECT * FROM vInterventores_Contrato Where Cod_Con=:Cod_Con"
        querystring = " SELECT ic.ide_int ide_int, tr.nom_ter nom_ter, ic.est_int est_int,ic.obs_int obs_int,nom_tip ntip_int,ic.tip_int tip_int, ic.cod_con cod_con,cod_con_int "
        querystring += " FROM interventores_contrato ic "
        querystring += " INNER JOIN vterceros tr ON ic.ide_int = tr.ide_ter "
        querystring += " INNER JOIN tipo_interventor ti ON  ic.tip_int=ti.COD_TIP "
        querystring += " Where Cod_Con=:Cod_Con And Est_Int='AC'"

        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        'If Cod_Con <> "" Then
        ' Throw New Exception(Me.vComando.CommandText)
        'End If

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Function GetRegistros(Cod_Con As String) As List(Of EInterventores_Contrato)
        Dim dataTb As DataTable
        querystring = "Select * From Interventores_Contrato Where cod_con=:cod_con  "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", Cod_Con)
        dataTb = Me.EjecutarConsultaDataTable()
        Dim lsIC As New List(Of EInterventores_Contrato)
        For Each dtr As DataRow In dataTb.Rows
            Dim ic As New EInterventores_Contrato
            ic.Cod_Con = dtr("Cod_Con")
            ic.Est_Int = dtr("Est_Int")
            ic.Ide_Int = dtr("Ide_Int")
            ic.Obs_Int = dtr("Obs_Int")
            ic.Tip_Int = dtr("Tip_Int")
            lsIC.Add(ic)
        Next
        Return lsIC
    End Function
    ''' <summary>
    ''' Insertar Interventores al Contrato I->Externo, S-Supervisor/Interventor Externo
    ''' </summary>
    ''' <param name="cod_con"></param>
    ''' <param name="ide_int"></param>
    ''' <param name="est_int"></param>
    ''' <param name="obs_int"></param>
    ''' <param name="tip_int"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Insert(ByVal cod_con As String, ByVal ide_int As String, ByVal est_int As String, ByVal obs_int As String, ByVal tip_int As String, cod_con_int As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()

            '1. Consultar Listado de Interventores Relacionados
            Dim lsIC As List(Of EInterventores_Contrato) = GetRegistros(cod_con)
            '3. Consulta si ya esta realcionado el tercero
            If lsIC.Where(Function(t) t.Ide_Int = ide_int).Count() > 0 Then
                Throw New Exception("El Funcionario o Contratista ya se encuentra relacionado. Verifique")
            End If
            If tip_int = "I" Then
                '2. Validar Si es interventor o supervisor que sea solo Uno.
                If lsIC.Where(Function(t) t.Est_Int = "AC" And t.Tip_Int = "I").Count() > 0 Then
                    Throw New Exception("Solo puede existir un Interventor")
                End If
            End If
            If tip_int = "S" Then
                If lsIC.Where(Function(t) t.Est_Int = "AC" And t.Tip_Int = "S").Count() > 0 Then
                    Throw New Exception("Solo puede existir un Supervisor")
                End If
            End If
            querystring = "Insert Into Interventores_Contrato (cod_con, ide_int,est_int,obs_int,tip_int,cod_con_int)Values(:cod_con, :ide_int,:est_int,:obs_int,:tip_int,:cod_con_int)"
            Me.CrearComando(querystring)
            AsignarParametroCadena(":cod_con", cod_con)
            AsignarParametroCadena(":ide_int", ide_int)
            AsignarParametroCadena(":est_int", est_int)
            AsignarParametroCadena(":obs_int", obs_int)
            AsignarParametroCadena(":tip_int", tip_int)
            AsignarParametroCadena(":cod_con_int", cod_con_int)

            num_reg = EjecutarComando()

            'f.InsAud(Me.dbConnection, t, "Contratos", Msg, usuario)
            ConfirmarTransaccion()
            Msg = MsgOk + "<br>" + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            lErrorG = True
        End Try
        Me.Desconectar()
        Return Msg

    End Function
    Public Function Update(ByVal cod_con_old As String, ByVal ide_int_old As String, ByVal est_int_new As String, ByVal obs_int_new As String, ByVal tip_int_new As String) As String
        Me.Conectar()

        Try
            Me.ComenzarTransaccion()
            querystring = "Update Interventores_Contrato Set est_int=:est_int,obs_int=:obs_int Where cod_con=:cod_con And ide_int=:ide_int"
            Me.CrearComando(querystring)
            AsignarParametroCadena(":est_int", est_int_new)
            AsignarParametroCadena(":cod_con", cod_con_old)
            AsignarParametroCadena(":ide_int", ide_int_old)
            AsignarParametroCadena(":obs_int", obs_int_new)
            EjecutarComando()
            'f.InsAud(Me.dbConnection, t, "Contratos", Msg, usuario)
            ConfirmarTransaccion()
            Msg = MsgOk + "<br>" + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            lErrorG = True
        End Try
        Me.Desconectar()
        Return Msg

    End Function
    Function Delete(ByVal Cod_Con As String, ByVal Ide_Int As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Interventores_Contrato WHERE Cod_Con=:Cod_Con AND Ide_Int=:Ide_Int "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroCadena(":Ide_Int", Ide_Int)

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

End Class