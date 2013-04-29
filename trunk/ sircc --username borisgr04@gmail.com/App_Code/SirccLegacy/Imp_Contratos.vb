Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

<System.ComponentModel.DataObject()> _
Public Class Imp_Contratos
    Inherits BDDatos

    ''' <summary>
    ''' Consulta Listado de Impuestos de los Contratos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vImp_Contratos "
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
        querystring = "SELECT * FROM vimp_contratos Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Insertar impuesto a un contrato (cod_con)
    ''' </summary>
    ''' <param name="cod_con"></param>
    ''' <param name="nro_imp"></param>
    ''' <param name="nro_com"></param>
    ''' <param name="vig_liq"></param>
    ''' <param name="val_imp"></param>
    ''' <param name="doc_sop"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Insert(ByVal cod_con As String, ByVal nro_imp As String, ByVal nro_com As String, ByVal vig_liq As String, ByVal val_imp As String, ByVal doc_sop As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Imp_Contratos(COD_CON,NRO_IMP,NRO_COM,VIG_LIQ,VAL_IMP,COD_SOP)VALUES(:COD_CON,to_number(:NRO_IMP),:NRO_COM,to_number(:VIG_LIQ),to_number(:VAL_IMP),:COD_SOP) "
            Me.CrearComando(querystring)
            AsignarParametroCadena(":COD_CON", cod_con)
            AsignarParametroCadena(":NRO_IMP", nro_imp)
            AsignarParametroCadena(":NRO_COM", nro_com)
            AsignarParametroCadena(":VIG_LIQ", vig_liq)
            AsignarParametroCadena(":VAL_IMP", val_imp)
            AsignarParametroCadena(":COD_SOP", doc_sop)
            'Throw New Exception(Me._Comando.CommandText)
            num_reg = EjecutarComando()
            Msg = "Se Asignó Imp Nº" + nro_imp + " Al Contrato N°" + cod_con

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
    ''' <summary>
    ''' Eliminación del Imp_Contratos
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <param name="Nro_imp"></param>
    ''' <param name="Cod_Sop"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Delete(ByVal Cod_Con As String, ByVal Nro_imp As String, ByVal Cod_Sop As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM imp_contratos WHERE Cod_Con=:Cod_Con AND NRO_IMP=:NRO_IMP AND Cod_Sop=:Cod_Sop "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroCadena(":NRO_IMP", Nro_imp)
            Me.AsignarParametroCadena(":Cod_Sop", Cod_Sop)
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