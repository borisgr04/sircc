Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Polizas_Contrato
    Inherits BDDatos

    ''' <summary>
    ''' Consulta Listado de Impuestos de los Contratos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM Polizas_Contrato "
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
        querystring = "SELECT * FROM vPolizas_Contrato Where Cod_Con=:Cod_Con"
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
        Me.Desconectar()
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
            EjecutarComando()
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
    ''' <param name="cod_pol"></param>
    ''' <param name="id_pol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Delete(ByVal Cod_Con As String, ByVal COD_POL As String, ByVal ID_POL As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Polizas_Contrato WHERE COD_CON =:COD_CON AND COD_POL=TO_NUMBER(:COD_POL) And Id_Pol=To_Number(:ID_POL)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":COD_CON", Cod_Con)
            Me.AsignarParametroCadena(":COD_POL", COD_POL)
            Me.AsignarParametroCadena(":ID_POL", ID_POL)
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
    

    Public Function Insert(ByVal cod_con As String, ByVal cod_pol As String, ByVal cod_ase As String, ByVal nro_pol As String, ByVal val_pol As Long, ByVal fec_pol As Date, ByVal tip_pol As String) As String
        Conectar()
        Try
            ComenzarTransaccion()
            querystring = "INSERT INTO Polizas_Contrato(COD_CON,COD_POL,COD_ASE,VAL_POL,FEC_POL,NRO_POL,TIP_POL)VALUES(:COD_CON,TO_NUMBER(:COD_POL),TO_NUMBER(:COD_ASE),TO_NUMBER(:VAL_POL),TO_DATE(:FEC_POL,'dd/mm/yyyy'),:NRO_POL,:TIP_POL) "
            Me.CrearComando(querystring)
            AsignarParametroCadena(":COD_CON", cod_con)
            AsignarParametroCadena(":COD_POL", cod_pol)
            AsignarParametroCadena(":COD_ASE", cod_ase)
            AsignarParametroCadena(":FEC_POL", fec_pol)
            AsignarParametroCadena(":VAL_POL", val_pol)
            AsignarParametroCadena(":NRO_POL", nro_pol)
            AsignarParametroCadena(":TIP_POL", tip_pol)
            'Throw New Exception(vComando.CommandText)
            EjecutarComando()
            Msg = "Se Asignó Poliza a Contrato Nº" + cod_con
            ConfirmarTransaccion()
            Msg = MsgOk + "<br>" + Msg
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            lErrorG = True
        Finally
            Desconectar()
        End Try

        Return Msg
    End Function

End Class