Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common

Public Class GPProponentes
    Inherits BDDatos
    Private _CodAux As String
    Property CodAux() As String
        Get
            Return _CodAux
        End Get
        Set(ByVal value As String)
            _CodAux = value
        End Set
    End Property
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vgpproponentes"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Ide_Prop As String, ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vgpproponentes Where Num_Proc=:Num_Proc and ide_prop=:ide_prop And Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ide_prop", Ide_Prop)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyNum_Proc(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vgpproponentes Where Num_proc=:Num_Proc And Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyAdjuicado(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vgpproponentes Where Num_proc=:Num_Proc And Grupo=:Grupo And Adjudicado='S'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Modificado por Boirs el viernes 25 de febrero, se agrego campo digito de verificacion. Boris G
    ''' </summary>
    ''' <param name="Ide_Prop"></param>
    ''' <param name="Num_Proc"></param>
    ''' <param name="fec_prop"></param>
    ''' <param name="val_prop"></param>
    ''' <param name="Ape1_Prop"></param>
    ''' <param name="Dir_Prop"></param>
    ''' <param name="Tel_Prop"></param>
    ''' <param name="Email_Prop"></param>
    ''' <param name="Ape2_Prop"></param>
    ''' <param name="Nom1_Prop"></param>
    ''' <param name="Nom2_Prop"></param>
    ''' <param name="Razon_Social"></param>
    ''' <param name="Tip_Ide"></param>
    ''' <param name="Exp_Ide"></param>
    ''' <param name="Estado"></param>
    ''' <param name="Observacion"></param>
    ''' <param name="Num_Folio"></param>
    ''' <param name="dver"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal tipo As String, ByVal Ide_Prop As String, ByVal Num_Proc As String, ByVal fec_prop As Date, ByVal val_prop As Decimal, _
                            ByVal Ape1_Prop As String, ByVal Dir_Prop As String, ByVal Tel_Prop As String, ByVal Email_Prop As String, ByVal Ape2_Prop As String, ByVal Nom1_Prop As String, _
                             ByVal Nom2_Prop As String, ByVal Razon_Social As String, ByVal Tip_Ide As String, ByVal Exp_Ide As String, ByVal Estado As String, ByVal Observacion As String, ByVal Num_Folio As Integer, ByVal dver As String, ByVal id_rep_leg As String, ByVal nom_rep_leg As String, ByVal Municipio As String, ByVal Grupo As String, _
                              ByVal Num_Pol As String, ByVal Fecha_Inicial As String, ByVal Fecha_Final As String, ByVal Aseguradora As String, ByVal Valor As Decimal, ByVal Denominacion As String, ByVal Aportes As String) As String
        Me.Conectar()
        'Me.ComenzarTransaccion()
        Try
            If tipo = "PU" Then
                If Num_Pol <> "" Then
                    querystring = "INSERT INTO GPProponentes(Num_Proc, Ide_Prop, Ape1_Prop, Dir_Prop, Tel_Prop, Email_Prop, Ape2_Prop, Nom1_Prop, " & _
                                        "Nom2_Prop, Tip_Ide, Exp_Ide, Razon_Social, Estado, Observacion, fec_prop, val_prop, Num_Folio,dv_ter, Tipo, Id_Rep_Legal, Nom_Rep_Legal, Municipio, Grupo, Numpoliza, Fecha_Inicial, Fecha_Final, Aseguradora, Valor_Poliza,Denominacion,Aportes)VALUES(:Num_Proc, :Ide_Prop, :Ape1_Prop, :Dir_Prop, :Tel_Prop, :Email_Prop, :Ape2_Prop, :Nom1_Prop, " & _
                                        ":Nom2_Prop, :Tip_Ide, :Exp_Ide, :Razon_Social, :Estado, :Observacion,  :Fec_Prop, :Val_Prop, :Num_Folio,:dv_ter, :Tipo, :Id_Rep_Leg, :Nom_Rep_Leg, :Municipio, :Grupo, " & _
                                        ":Num_Pol, :Fecha_Inicial, :Fecha_Final, :Aseguradora, :Valor,:Denominacion,:Aportes)"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
                    Me.AsignarParametroCadena(":Ide_Prop", Ide_Prop)
                    Me.AsignarParametroFecha(":fec_Prop", fec_prop)
                    Me.AsignarParametroDecimal(":Val_Prop", val_prop)
                    Me.AsignarParametroCadena(":Ape1_Prop", Ape1_Prop)
                    Me.AsignarParametroCadena(":Dir_Prop", Dir_Prop)
                    Me.AsignarParametroCadena(":Tel_Prop", Tel_Prop)
                    Me.AsignarParametroCadena(":Email_Prop", Email_Prop)
                    Me.AsignarParametroCadena(":Ape2_Prop", Ape2_Prop)
                    Me.AsignarParametroCadena(":Nom1_Prop", Nom1_Prop)
                    Me.AsignarParametroCadena(":Nom2_Prop", Nom2_Prop)
                    Me.AsignarParametroCadena(":Tip_Ide", Tip_Ide)
                    Me.AsignarParametroCadena(":Exp_Ide", Exp_Ide)
                    Me.AsignarParametroCadena(":Razon_Social", Razon_Social)
                    Me.AsignarParametroCadena(":Estado", Estado)
                    Me.AsignarParametroCadena(":Observacion", Observacion)
                    Me.AsignarParametroInt(":Num_Folio", Num_Folio)
                    Me.AsignarParametroCadena(":Id_Rep_Leg", id_rep_leg)
                    Me.AsignarParametroCadena(":Nom_Rep_Leg", nom_rep_leg)
                    Me.AsignarParametroCadena(":Tipo", tipo)
                    dver = IIf(Tip_Ide = "NI", Util.ValidarDigitoVerificacion(Ide_Prop), "")
                    Me.AsignarParametroCadena(":dv_ter", dver)
                    Me.AsignarParametroCadena(":Municipio", Municipio)
                    Me.AsignarParametroCadena(":Grupo", Grupo)
                    Me.AsignarParametroCadena(":Num_Pol", Num_Pol)
                    Me.AsignarParametroFecha(":Fecha_Inicial", CDate(Fecha_Inicial))
                    Me.AsignarParametroFecha(":Fecha_Final", CDate(Fecha_Final))
                    Me.AsignarParametroCadena(":Aseguradora", Aseguradora)
                    Me.AsignarParametroDecimal(":Valor", Valor)


                    Me.AsignarParametroCadena(":Denominacion", Denominacion)
                    Me.AsignarParametroCLOB(":Aportes", Aportes)

                    Me.num_reg = Me.EjecutarComando()
                    'Me.ConfirmarTransaccion()
                    Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
                    Me.lErrorG = False
                Else
                    querystring = "INSERT INTO GPProponentes(Num_Proc, Ide_Prop, Ape1_Prop, Dir_Prop, Tel_Prop, Email_Prop, Ape2_Prop, Nom1_Prop, " & _
                                        "Nom2_Prop, Tip_Ide, Exp_Ide, Razon_Social, Estado, Observacion, fec_prop, val_prop, Num_Folio,dv_ter, Tipo, Id_Rep_Legal, Nom_Rep_Legal, Municipio, Grupo, Denominacion, Aportes)VALUES(:Num_Proc, :Ide_Prop, :Ape1_Prop, :Dir_Prop, :Tel_Prop, :Email_Prop, :Ape2_Prop, :Nom1_Prop, " & _
                                        ":Nom2_Prop, :Tip_Ide, :Exp_Ide, :Razon_Social, :Estado, :Observacion,  :Fec_Prop, :Val_Prop, :Num_Folio,:dv_ter, :Tipo, :Id_Rep_Leg, :Nom_Rep_Leg, :Municipio, :Grupo,:Denominacion, :Aportes)"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
                    Me.AsignarParametroCadena(":Ide_Prop", Ide_Prop)
                    Me.AsignarParametroFecha(":fec_Prop", fec_prop)
                    Me.AsignarParametroDecimal(":Val_Prop", val_prop)
                    Me.AsignarParametroCadena(":Ape1_Prop", Ape1_Prop)
                    Me.AsignarParametroCadena(":Dir_Prop", Dir_Prop)
                    Me.AsignarParametroCadena(":Tel_Prop", Tel_Prop)
                    Me.AsignarParametroCadena(":Email_Prop", Email_Prop)
                    Me.AsignarParametroCadena(":Ape2_Prop", Ape2_Prop)
                    Me.AsignarParametroCadena(":Nom1_Prop", Nom1_Prop)
                    Me.AsignarParametroCadena(":Nom2_Prop", Nom2_Prop)
                    Me.AsignarParametroCadena(":Tip_Ide", Tip_Ide)
                    Me.AsignarParametroCadena(":Exp_Ide", Exp_Ide)
                    Me.AsignarParametroCadena(":Razon_Social", Razon_Social)
                    Me.AsignarParametroCadena(":Estado", Estado)
                    Me.AsignarParametroCadena(":Observacion", Observacion)
                    Me.AsignarParametroInt(":Num_Folio", Num_Folio)
                    Me.AsignarParametroCadena(":Id_Rep_Leg", id_rep_leg)
                    Me.AsignarParametroCadena(":Nom_Rep_Leg", nom_rep_leg)
                    Me.AsignarParametroCadena(":Tipo", tipo)
                    Me.AsignarParametroCadena(":dv_ter", dver)
                    Me.AsignarParametroCadena(":Municipio", Municipio)
                    Me.AsignarParametroCadena(":Grupo", Grupo)

                    Me.AsignarParametroCadena(":Denominacion", Denominacion)
                    Me.AsignarParametroCLOB(":Aportes", Aportes)
                    Me.num_reg = Me.EjecutarComando()
                    'Me.ConfirmarTransaccion()
                    Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
                    Me.lErrorG = False
                End If
            Else
                If Num_Pol <> "" Then
                    CrearCodAux(tipo)
                    querystring = "INSERT INTO GPProponentes(Num_Proc, Ide_Prop, Ape1_Prop, Dir_Prop, Tel_Prop, Email_Prop, Ape2_Prop, Nom1_Prop, " & _
                                            "Nom2_Prop, Tip_Ide, Exp_Ide, Razon_Social, Estado, Observacion, fec_prop, val_prop, Num_Folio,dv_ter, Tipo, Id_Rep_Legal, Nom_Rep_Legal, Cod_Aux, Municipio, Grupo, Numpoliza, Fecha_Inicial, Fecha_Final, Aseguradora, Valor_Poliza,Denominacion,Aportes)VALUES(:Num_Proc, :Ide_Prop, :Ape1_Prop, :Dir_Prop, :Tel_Prop, :Email_Prop, :Ape2_Prop, :Nom1_Prop, " & _
                                            ":Nom2_Prop, :Tip_Ide, :Exp_Ide, :Razon_Social, :Estado, :Observacion,  :Fec_Prop, :Val_Prop, :Num_Folio,:dv_ter, :Tipo, :Id_Rep_Leg, :Nom_Rep_Leg, :Cod_Aux, :Municipio, :Grupo, " & _
                                            ":Num_Pol, :Fecha_Inicial, :Fecha_Final, :Aseguradora, :Valor,:Denominacion,:Aportes)"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
                    Me.AsignarParametroCadena(":Ide_Prop", CodAux)
                    Me.AsignarParametroFecha(":fec_Prop", fec_prop)
                    Me.AsignarParametroDecimal(":Val_Prop", val_prop)
                    Me.AsignarParametroCadena(":Ape1_Prop", Ape1_Prop)
                    Me.AsignarParametroCadena(":Dir_Prop", Dir_Prop)
                    Me.AsignarParametroCadena(":Tel_Prop", Tel_Prop)
                    Me.AsignarParametroCadena(":Email_Prop", Email_Prop)
                    Me.AsignarParametroCadena(":Ape2_Prop", Ape2_Prop)
                    Me.AsignarParametroCadena(":Nom1_Prop", Nom1_Prop)
                    Me.AsignarParametroCadena(":Nom2_Prop", Nom2_Prop)
                    Me.AsignarParametroCadena(":Tip_Ide", Tip_Ide)
                    Me.AsignarParametroCadena(":Exp_Ide", Exp_Ide)
                    Me.AsignarParametroCadena(":Razon_Social", Razon_Social)
                    Me.AsignarParametroCadena(":Estado", Estado)
                    Me.AsignarParametroCadena(":Observacion", Observacion)
                    Me.AsignarParametroInt(":Num_Folio", Num_Folio)
                    Me.AsignarParametroCadena(":Id_Rep_Leg", id_rep_leg)
                    Me.AsignarParametroCadena(":Nom_Rep_Leg", nom_rep_leg)
                    Me.AsignarParametroCadena(":Tipo", tipo)
                    Me.AsignarParametroCadena(":dv_ter", dver)
                    Me.AsignarParametroCadena(":Cod_Aux", CodAux)
                    Me.AsignarParametroCadena(":Municipio", Municipio)
                    Me.AsignarParametroCadena(":Grupo", Grupo)
                    Me.AsignarParametroCadena(":Num_Pol", Num_Pol)
                    Me.AsignarParametroFecha(":Fecha_Inicial", CDate(Fecha_Inicial))
                    Me.AsignarParametroFecha(":Fecha_Final", CDate(Fecha_Final))
                    Me.AsignarParametroCadena(":Aseguradora", Aseguradora)
                    Me.AsignarParametroDecimal(":Valor", Valor)
                    'Denominación
                    Me.AsignarParametroCadena(":Denominacion", Denominacion)
                    Me.AsignarParametroCLOB(":Aportes", Aportes)

                    Me.num_reg = Me.EjecutarComando()
                    'Me.ConfirmarTransaccion()
                    Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
                    Me.lErrorG = False
                Else
                    CrearCodAux(tipo)
                    querystring = "INSERT INTO GPProponentes(Num_Proc, Ide_Prop, Ape1_Prop, Dir_Prop, Tel_Prop, Email_Prop, Ape2_Prop, Nom1_Prop, " & _
                                            "Nom2_Prop, Tip_Ide, Exp_Ide, Razon_Social, Estado, Observacion, fec_prop, val_prop, Num_Folio,dv_ter, Tipo, Id_Rep_Legal, Nom_Rep_Legal, Cod_Aux, Municipio, Grupo, Denominacion, Aportes)VALUES(:Num_Proc, :Ide_Prop, :Ape1_Prop, :Dir_Prop, :Tel_Prop, :Email_Prop, :Ape2_Prop, :Nom1_Prop, " & _
                                            ":Nom2_Prop, :Tip_Ide, :Exp_Ide, :Razon_Social, :Estado, :Observacion,  :Fec_Prop, :Val_Prop, :Num_Folio,:dv_ter, :Tipo, :Id_Rep_Leg, :Nom_Rep_Leg, :Cod_Aux, :Municipio, :Grupo,:Denominacion, :Aportes)"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
                    Me.AsignarParametroCadena(":Ide_Prop", CodAux)
                    Me.AsignarParametroFecha(":fec_Prop", fec_prop)
                    Me.AsignarParametroDecimal(":Val_Prop", val_prop)
                    Me.AsignarParametroCadena(":Ape1_Prop", Ape1_Prop)
                    Me.AsignarParametroCadena(":Dir_Prop", Dir_Prop)
                    Me.AsignarParametroCadena(":Tel_Prop", Tel_Prop)
                    Me.AsignarParametroCadena(":Email_Prop", Email_Prop)
                    Me.AsignarParametroCadena(":Ape2_Prop", Ape2_Prop)
                    Me.AsignarParametroCadena(":Nom1_Prop", Nom1_Prop)
                    Me.AsignarParametroCadena(":Nom2_Prop", Nom2_Prop)
                    Me.AsignarParametroCadena(":Tip_Ide", Tip_Ide)
                    Me.AsignarParametroCadena(":Exp_Ide", Exp_Ide)
                    Me.AsignarParametroCadena(":Razon_Social", Razon_Social)
                    Me.AsignarParametroCadena(":Estado", Estado)
                    Me.AsignarParametroCadena(":Observacion", Observacion)
                    Me.AsignarParametroInt(":Num_Folio", Num_Folio)
                    Me.AsignarParametroCadena(":Id_Rep_Leg", id_rep_leg)
                    Me.AsignarParametroCadena(":Nom_Rep_Leg", nom_rep_leg)
                    Me.AsignarParametroCadena(":Tipo", tipo)
                    Me.AsignarParametroCadena(":dv_ter", dver)
                    Me.AsignarParametroCadena(":Cod_Aux", CodAux)
                    Me.AsignarParametroCadena(":Municipio", Municipio)
                    Me.AsignarParametroCadena(":Grupo", Grupo)

                    'Denominación
                    Me.AsignarParametroCadena(":Denominacion", Denominacion)
                    Me.AsignarParametroCLOB(":Aportes", Aportes)

                    Me.num_reg = Me.EjecutarComando()
                    'Me.ConfirmarTransaccion()
                    Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
                    Me.lErrorG = False
                End If
            End If
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            'Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ GONZALEZ
    ''' FECHA: 04 ABRIL DE 2011
    ''' MODIFICACION: SE AGREGA CODIGO PARA ELIMINAR LOS MIEMBROS 
    ''' DE UN PROPONENTE.
    ''' </summary>
    ''' <param name="Ide_Prop"></param>
    ''' <param name="Num_Proc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)> _
    Public Function Delete(ByVal Ide_Prop As String, ByVal Num_Proc As String, ByVal Grupo As String) As String
        Me.Conectar()
        querystring = "DELETE FROM ConsorciosUT WHERE Ide_Ter='" + Ide_Prop + "' "
        Me.CrearComando(querystring)
        EjecutarComando()
        Try
            querystring = "DELETE FROM GPProponentes WHERE Num_Proc=:Num_Proc AND Ide_Prop=:Ide_Prop And Grupo=:Grupo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
            Me.AsignarParametroCadena(":Ide_Prop", Ide_Prop)
            Me.AsignarParametroCadena(":Grupo", Grupo)
            Me.num_reg = Me.EjecutarComando()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    ''' <summary>
    ''' Modificado por Boirs el viernes 25 de febrero, se agrego campo digito de verificacion. Boris G
    ''' </summary>
    ''' <param name="Ide_Prop_PK"></param>
    ''' <param name="Ide_Prop"></param>
    ''' <param name="Num_Proc"></param>
    ''' <param name="fec_prop"></param>
    ''' <param name="val_prop"></param>
    ''' <param name="Ape1_Prop"></param>
    ''' <param name="Dir_Prop"></param>
    ''' <param name="Tel_Prop"></param>
    ''' <param name="Email_Prop"></param>
    ''' <param name="Ape2_Prop"></param>
    ''' <param name="Nom1_Prop"></param>
    ''' <param name="Nom2_Prop"></param>
    ''' <param name="Razon_Social"></param>
    ''' <param name="Tip_Ide"></param>
    ''' <param name="Exp_Ide"></param>
    ''' <param name="Estado"></param>
    ''' <param name="Observacion"></param>
    ''' <param name="Num_Folio"></param>
    ''' <param name="dver"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal Ide_Prop_PK As String, ByVal Ide_Prop As String, ByVal Num_Proc As String, ByVal fec_prop As Date, ByVal val_prop As Decimal, _
                            ByVal Ape1_Prop As String, ByVal Dir_Prop As String, ByVal Tel_Prop As String, ByVal Email_Prop As String, ByVal Ape2_Prop As String, ByVal Nom1_Prop As String, _
                             ByVal Nom2_Prop As String, ByVal Razon_Social As String, ByVal Tip_Ide As String, ByVal Exp_Ide As String, ByVal Estado As String, ByVal Observacion As String, ByVal Num_Folio As Integer, ByVal dver As String, ByVal id_rep_leg As String, ByVal nom_rep_leg As String, ByVal Municipio As String, ByVal Grupo As String, ByVal Denominacion As String, ByVal Aportes As String) As String
        Me.Conectar()
        Try
            'Me.ComenzarTransaccion()
            querystring = "UPDATE GPProponentes SET Ide_Prop=:Ide_Prop, fec_Prop=:fec_Prop, Val_Prop=:Val_Prop, Ape1_Prop=:Ape1_Prop, Dir_Prop=:Dir_Prop, Tel_Prop=:Tel_Prop, Email_Prop=:Email_Prop," & _
            " Ape2_Prop=:Ape2_Prop, Id_Rep_Legal=:Id_Rep_Leg, Nom_Rep_Legal=:Nom_Rep_Leg, Municipio=:Municipio, Nom1_Prop=:Nom1_Prop, Nom2_Prop=:Nom2_Prop, Tip_Ide=:Tip_Ide, Exp_Ide=:Exp_Ide, Razon_Social=:Razon_Social, Estado=:Estado, Observacion=:Observacion, Num_Folio=:Num_Folio, dv_ter=:dv_ter,Denominacion=:Denominacion, Aportes=:Aportes WHERE NUM_PROC=:Num_Proc AND IDE_PROP=:Ide_Prop_PK And Grupo=:Grupo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
            Me.AsignarParametroCadena(":Ide_Prop", Ide_Prop)
            Me.AsignarParametroFecha(":fec_Prop", fec_prop)
            Me.AsignarParametroDecimal(":Val_Prop", val_prop)
            Me.AsignarParametroCadena(":Ape1_Prop", Ape1_Prop)
            Me.AsignarParametroCadena(":Dir_Prop", Dir_Prop)
            Me.AsignarParametroCadena(":Tel_Prop", Tel_Prop)
            Me.AsignarParametroCadena(":Email_Prop", Email_Prop)
            Me.AsignarParametroCadena(":Ape2_Prop", Ape2_Prop)
            Me.AsignarParametroCadena(":Nom1_Prop", Nom1_Prop)
            Me.AsignarParametroCadena(":Nom2_Prop", Nom2_Prop)
            Me.AsignarParametroCadena(":Tip_Ide", Tip_Ide)
            Me.AsignarParametroCadena(":Exp_Ide", Exp_Ide)
            Me.AsignarParametroCadena(":Razon_Social", Razon_Social)
            Me.AsignarParametroCadena(":Estado", Estado)
            Me.AsignarParametroCadena(":Observacion", Observacion)
            Me.AsignarParametroInt(":Num_Folio", Num_Folio)
            Me.AsignarParametroCadena(":Ide_Prop_PK", Ide_Prop_PK)
            dver = IIf(Tip_Ide = "NI", Util.ValidarDigitoVerificacion(Ide_Prop), "")
            Me.AsignarParametroCadena(":dv_ter", dver)
            Me.AsignarParametroCadena(":Id_Rep_Leg", id_rep_leg)
            Me.AsignarParametroCadena(":Nom_Rep_Leg", nom_rep_leg)
            Me.AsignarParametroCadena(":Municipio", Municipio)
            Me.AsignarParametroCadena(":Grupo", Grupo)

            Me.AsignarParametroCadena(":Denominacion", Denominacion)
            Me.AsignarParametroCLOB(":Aportes", Aportes)
            'Throw New Exception(Me._Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            'Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            'Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 25 FEBRERO 2011
    ''' MODIFICACION:
    ''' SE MODIFICA LA FUNCION PARA ADJUDICAR
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="FECHA_ADJUDICACION"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Adjudicar(ByVal grid As GridView, ByVal NUM_PROC As String, ByVal FECHA_ADJUDICACION As Date, ByVal Grupo As String) As String
        Me.Conectar()
        querystring = "UPDATE GPProponentes SET ADJUDICADO='N' WHERE NUM_PROC='" + NUM_PROC + "' And Grupo='" + Grupo + "'"
        Me.CrearComando(querystring)
        EjecutarComando()
        Try
            'Me.ComenzarTransaccion()
            Dim cantidadFilas As Integer = grid.Rows.Count
            Dim NumAdj As Integer
            If (cantidadFilas > 0) Then
                Dim numFila As Integer = 0
                Do While (numFila <= cantidadFilas - 1)
                    Dim nuevoCheckBox As CheckBox = grid.Rows(numFila).FindControl("ChkProp")
                    Dim estaCheckeado As Boolean = nuevoCheckBox.Checked
                    If (estaCheckeado = True) Then
                        querystring = "UPDATE GPProponentes SET ADJUDICADO='S', FECHA_ADJUDICACION=to_date(:FECHA_ADJUDICACION,'dd/mm/yyyy') WHERE NUM_PROC=:NUM_PROC AND IDE_PROP=:IDE_PROP And Grupo=:Grupo"
                        Me.CrearComando(querystring)
                        Me.AsignarParametroCadena(":FECHA_ADJUDICACION", FECHA_ADJUDICACION)
                        Me.AsignarParametroCadena(":NUM_PROC", NUM_PROC)
                        Me.AsignarParametroCadena(":IDE_PROP", grid.DataKeys(numFila).Values(0).ToString)
                        Me.AsignarParametroCadena(":Grupo", Grupo)
                        EjecutarComando()
                        NumAdj += 1

                    End If
                    numFila = (numFila + 1)
                Loop
                If NumAdj = 0 Then
                    Msg = "Debe seleccionar al menos un proponente"
                    lErrorG = True
                Else
                    Msg = "Se adjudico con exito el Proceso a " & NumAdj & " Proponentes"
                    lErrorG = False
                End If
            End If
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            'Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Adjudicar(Ide_Prop As String, ByVal NUM_PROC As String, ByVal FECHA_ADJUDICACION As Date, ByVal Grupo As String) As String
        Me.Conectar()
        Me.ComenzarTransaccion()
        
        Try
            querystring = "UPDATE GPProponentes SET ADJUDICADO='N' WHERE NUM_PROC='" + NUM_PROC + "' And Grupo='" + Grupo + "'"
            Me.CrearComando(querystring)
            num_reg = EjecutarComando()

            querystring = "UPDATE GPProponentes SET ADJUDICADO='S', FECHA_ADJUDICACION=to_date(:FECHA_ADJUDICACION,'dd/mm/yyyy') WHERE NUM_PROC=:NUM_PROC AND IDE_PROP=:IDE_PROP And Grupo=:Grupo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":FECHA_ADJUDICACION", FECHA_ADJUDICACION)
            Me.AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            Me.AsignarParametroCadena(":IDE_PROP", Ide_Prop)
            Me.AsignarParametroCadena(":Grupo", Grupo)
            num_reg += EjecutarComando()


            querystring = "UPDATE gprocesos SET IDE_CON=:IDE_PROP WHERE PRO_SEL_NRO=:NUM_PROC And Grupo=:Grupo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            Me.AsignarParametroCadena(":IDE_PROP", Ide_Prop)
            Me.AsignarParametroCadena(":Grupo", Grupo)
            num_reg += EjecutarComando()

                
            Msg = "Se adjudico con exitó el Proceso al Proponente " & Ide_Prop + " Filas Afectadas:" + num_reg.ToString
            lErrorG = False

            ConfirmarTransaccion()
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ GONZALEZ
    ''' FECHA: 1 DE MARZO DE 2011
    ''' MODIFICACION:
    ''' SE CREA LA FUNCION ADJUDICARPCONT USADA PARA REGISTRAR EL NIT DEL CONTRATISTA
    ''' EN UN PROCESO(PCONTRATOS)
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="IDE_PROP"></param>
    ''' <remarks></remarks>
    Public Sub AdjudicarPcont(ByVal NUM_PROC As String, ByVal IDE_PROP As String)
        querystring = "UPDATE PContratos SET IDE_CON=:IDE_PROP WHERE PRO_SEL_NRO=:NUM_PROC"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        Me.AsignarParametroCadena(":IDE_PROP", IDE_PROP)
        Me.num_reg = Me.EjecutarComando()
    End Sub
    Private Sub CrearCodAux(ByVal Tipo As String)
        querystring = "CodAuxProp"
        CrearComando(querystring, CommandType.StoredProcedure)

        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("Tipo", Tipo)
        EjecutarComando()
        Me.CodAux = preturn.Value.ToString()
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyAdjudicado(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT PP.*, (SELECT CASE WHEN COUNT(*)=0 THEN '0' ELSE '1' END AS EST FROM GPPROPONENTES WHERE NUM_PROC=:Num_Proc AND ADJUDICADO='S' AND IDE_PROP=PP.IDE_PROP and Grupo=:Grupo) EST FROM VGPPROPONENTES PP WHERE PP.NUM_PROC=:Num_Proc1 And PP.Grupo=:Grupo1"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Num_Proc1", Num_Proc)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Me.AsignarParametroCadena(":Grupo1", Grupo)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class