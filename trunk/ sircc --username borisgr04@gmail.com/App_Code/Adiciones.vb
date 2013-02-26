Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
''' <summary>
''' Adiciones a Contratos y Convenios, 15 de enero d 2011, Boris G.
''' </summary>
''' <remarks></remarks>
<System.ComponentModel.DataObject()> _
 Public Class Adiciones
    Inherits BDDatos
    Dim nro As String
    ReadOnly Property Nro_Adi As String
        Get
            Return nro
        End Get
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function Delete(ByVal Nro_Adi As String) As String
        Try
            Conectar()
            querystring = "DELETE FROM ADICIONES WHERE Nro_Adi = :Nro_Adi "
            CrearComando(querystring)
            AsignarParametroCadena(":Nro_Adi", Nro_Adi)
            num_reg = EjecutarComando()
            Msg = MsgOk + " Filas Afectadas " + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try
        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsUlt(ByVal Cod_Con As String) As DataTable
        Conectar()
        querystring = "SELECT va.*,Decode(Substr(va.Nro_Adi,-2), (Select Max(Substr(Nro_Adi,-2)) From Adiciones Where Cod_Con=:COD_CON),1,0) Ult  FROM VADICIONES va WHERE COD_CON=:COD_CON Order by FEc_Sus_Adi"
        CrearComando(querystring)
        AsignarParametroCadena(":COD_CON", Cod_Con)
        AsignarParametroCadena(":COD_CON", Cod_Con)
        Dim data As DataTable = EjecutarConsultaDataTable()
        Desconectar()

        Return data
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Cod_Con As String) As DataTable
        Conectar()
        querystring = "SELECT * FROM VADICIONES Where COD_CON=:COD_CON ORDER BY NRO_ADI "
        CrearComando(querystring)
        AsignarParametroCadena(":COD_CON", Cod_Con)
        Dim data As DataTable = EjecutarConsultaDataTable()
        Desconectar()

        Return data
    End Function
    ''' <summary>
    ''' Retorna Informacion Consolidad de las Adiciones de un Contrato
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetConsolidado(ByVal Cod_Con As String) As DataTable
        Conectar()
        ''Total Adicionado', 'Plazo Total', '% Adición', COD_CON
        querystring = "SELECT * FROM VTADICION WHERE (COD_CON = :COD_CON) "
        CrearComando(querystring)
        AsignarParametroCadena(":COD_CON", Cod_Con)
        Dim data As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        Return data
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal codcon As String, ByVal fsus As Date, ByVal pla As Integer, ByVal valor As Decimal, ByVal tip As String, ByVal vigencia As String, ByVal OBSER As String) As String
        Select Case tip
            Case 1
                If (pla = 0) Or (valor = 0) Then
                    Msg = "Debe tener un plazo y valor de adición diferentes de 0"
                    Me.lErrorG = True
                    Return Msg
                    Exit Function
                End If
            Case 2
                If (valor = 0) Then
                    Msg = "Debe tener  valor de adición diferente de 0"
                    Me.lErrorG = True
                    Return Msg
                    Exit Function
                End If
            Case 3
                If (pla = 0) Then
                    Msg = "Debe tener Plazo de adición diferente de 0"
                    Me.lErrorG = True
                    Return Msg
                    Exit Function
                End If
        End Select
        Dim nVig As New Vigencias
        Dim oContrato As Contratos = New Contratos

        Conectar()
        nVig.Conexion = Me.Conexion
        oContrato.Conexion = Me.Conexion

        
        Dim tbCon As DataTable
        Dim tbVig As DataTable

        Dim año As Integer = 0
        Dim vadd As Double, cadd As Integer, vcon As Double
        Dim padi As Double
        Dim fecsus As Date, fecsusant As Date

        tbCon = oContrato.GetTablaByIde(codcon)

        vadd = GetValAdi(codcon) 'Val(tbCon.Rows(0)("val_adi").ToString)
        cadd = GetCanAdi(codcon) 'Val(tbCon.Rows(0)("can_adi").ToString)

        vcon = Val(tbCon.Rows(0)("val_con").ToString)
        año = Val(tbCon.Rows(0)("vig_con").ToString) ' Vigencia
        fecsus = CDate(tbCon.Rows(0)("fec_sus_con").ToString)


        tbVig = nVig.GetByIde(año)
        padi = Val(tbVig.Rows(0)("por_adi_vig").ToString)

        ' VALIDACION DE FECHA DE SUSCRIPCION

        If fecsus > fsus Then
            Msg = "La Fecha de Suscripción de la Adición debe ser mayor a la Fecha de Suscripción del Contrato"
            Me.lErrorG = True
            Return Msg
            Exit Function
        End If

        ' VALIDACION DE FECHA DE SUSCRIPCION
        tbCon = Me.GetAdiByIde(codcon)
        If tbCon.Rows.Count > 0 Then
            fecsusant = CDate(tbCon.Rows(0)("fec_sus_adi").ToString)
            If fecsusant > fsus Then
                Msg = "La Fecha de la Adición debe ser mayor a la Fecha de la Adición Anterior :" + fecsusant.ToShortDateString
                Me.lErrorG = True
                Return Msg
                Exit Function
            End If
        End If
        If (vadd + valor) > (vcon * padi / 100) Then
            Msg = Msg + "El Valor a Adicionar, supera el Porcentaje de Adición (" + padi.ToString + "%) equivalente a " + FormatCurrency((vcon * padi / 100).ToString) + " <br>" + "Valor Adicionado es " + FormatCurrency(vadd.ToString)
            Me.lErrorG = True
        Else
            'Desconectar()
            'Conectar()
            Try
                ComenzarTransaccion()
                cadd = cadd + 1
                nro = codcon + "-" + Right("00" + cadd.ToString, 2)

                querystring = "INSERT INTO Adiciones (COD_CON,FEC_SUS_ADI,PLA_EJE_ADI,VIG_ADI,VAL_ADI,NRO_ADI,TIP_ADI,OBSER)VALUES(:COD_CON,to_date(:FEC_SUS_ADI,'dd/mm/yyyy'),:PLA_EJE_ADI,:VIG_ADI,:VAL_ADI,:NRO_ADI,:TIP_ADI,:OBSER)"
                CrearComando(querystring)

                AsignarParametroCadena(":COD_CON", codcon)
                AsignarParametroCadena(":FEC_SUS_ADI", fsus)
                AsignarParametroCadena(":PLA_EJE_ADI", pla)
                AsignarParametroCadena(":VIG_ADI", vigencia) 'Vigencia en la cual se realiza la adición
                AsignarParametroCadena(":NRO_ADI", nro)
                AsignarParametroCadena(":TIP_ADI", tip)
                AsignarParametroCadena(":OBSER", OBSER)
                AsignarParametroDecimal(":VAL_ADI", valor)

                num_reg = EjecutarComando()

                If tip = 1 Or tip = 2 Or tip = 3 Then
                    querystring = "UPDATE Contratos Set Can_Adi=:Can_Adi,Val_Adi=:Val_Adi Where cod_con=:Cod_Con"
                    CrearComando(querystring)
                    AsignarParametroCadena(":Can_Adi", cadd)
                    AsignarParametroCadena(":Cod_Con", codcon)
                    AsignarParametroDecimal(":Val_Adi", vadd + valor)
                    'Throw New Exception(Me._Comando.CommandText)
                    EjecutarComando()
                End If


                Msg = "SE RADICO NUEVO DOCUMENTO A CONTRATO : " + codcon + "  Nº: <b>" + nro.ToString + "</b>"
                'f.InsAud(Me.dbConnection, "CONTRATOS", Msg, Me.usuario)
                ConfirmarTransaccion()
                Msg = MsgOk + "<br>" + Msg
                Me.lErrorG = False
            Catch ex As Exception
                CancelarTransaccion()
                Msg = ex.Message
                Me.lErrorG = True
            Finally
                Desconectar()
            End Try

        End If
        Return Msg

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Private Function GetAdiByIde(ByVal codcon As String) As DataTable

        Me.CrearComando("select * from Adiciones where cod_con =:cod_con Order By Nro_Adi desc")
        AsignarParametroCadena(":cod_con", codcon)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Return dataTb
    End Function


    ''' <summary>
    ''' Retorna los todos los registros de la tabla de la Base de datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overridable Function GetPk(Nro_Adi As String) As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista + " Where Nro_Adi=:Nro_Adi"
        Me.Conectar()
        Me.CrearComando(queryString)

        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function


    Private Function GetCanAdi(ByVal codcon As String) As Integer

        Me.CrearComando("select Nvl(Count(*),0) Cant from Adiciones where cod_con =:cod_con ")
        AsignarParametroCadena(":cod_con", codcon)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Return CInt(dataTb.Rows(0)("Cant").ToString)
    End Function

    Private Function GetValAdi(ByVal codcon As String) As Decimal

        Me.CrearComando("select Nvl(Sum(Val_Adi),0) Val_Adi from Adiciones where cod_con =:cod_con ")
        AsignarParametroCadena(":cod_con", codcon)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Return CDec(dataTb.Rows(0)("Val_Adi").ToString)
    End Function


End Class
