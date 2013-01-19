Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class genDocActas
    Inherits BDDatos

    Private mDoc_DOC As Byte()
    Private mDoc_PDF As Byte()
    Private mDoc_BAS As Byte()
    Private mide_Acta As String
    Dim mFec_Cre As Date

    Public Property Doc_Doc As Byte()
        Get
            Return mDoc_DOC
        End Get
        Set(ByVal value As Byte())
            mDoc_DOC = value
        End Set
    End Property

    Public Property Doc_PDF As Byte()
        Get
            Return mDoc_PDF
        End Get
        Set(ByVal value As Byte())
            mDoc_PDF = value
        End Set
    End Property

    Public Property Doc_BAS As Byte()
        Get
            Return mDoc_BAS
        End Get
        Set(ByVal value As Byte())
            mDoc_BAS = value
        End Set
    End Property

    Public Property Ide_Acta As String
        Get
            Return mide_Acta
        End Get
        Set(ByVal value As String)
            mide_Acta = value
        End Set
    End Property

    Public Property Fec_Cre As Date
        Get
            Return mFec_Cre
        End Get
        Set(ByVal value As Date)
            mFec_Cre = value
        End Set
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Protected Function GetPolizas(ByVal Cod_Con As String) As DataTable
        querystring = "select nom_ase Aseguradora,nro_pol ""N° Poliza"",nom_pol Amparo,val_pol ""Valor Asegurado"", To_Char(fec_ini,'dd/MON/yyyy') ||' al '||To_Char(fec_pol,'dd/MON/yyyy') Vigencia FROM vPolizas_Contrato WHERE Cod_Con= :id"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":id", Cod_Con)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPolizasP(ByVal Cod_Con As String) As DataTable
        Dim dataTb As DataTable
        Conectar()
        dataTb = GetPolizas(Cod_Con)
        Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Protected Function GetRp(ByVal Cod_Con As String) As DataTable
        querystring = "Select 'N° ' || NRO_Rp || '  por Valor de $' ||To_Char(Val_Rp,'999,999,999') || ' de Fecha ' || To_Char(Fec_Rp,'dd/MON/yyyy') RP FROM Rp_Contratos Where Cod_Con = :id "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":id", Cod_Con)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRpP(ByVal Cod_Con As String) As DataTable
        Dim dataTb As DataTable
        Conectar()
        dataTb = GetRp(Cod_Con)
        Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Protected Function GetCdp(ByVal Cod_Con As String) As DataTable
        querystring = "Select 'N° ' || NRO_CDP || '  por Valor de $' ||To_Char(Val_CDP,'999,999,999') || ' de Fecha ' || To_Char(Fec_CDP,'dd/MON/yyyy') CDP FROM CDP_Contratos Where Cod_Con = :id "
        'querystring = "Select NRO_Cdp ""N° CDP"",To_Char(Val_Cdp,'999,999,999') Valor, To_Char(Fec_Cdp,'dd/mm/yyyy') Fecha FROM Cdp_Contratos Where Cod_Con = :id "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":id", Cod_Con)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCdpP(ByVal Cod_Con As String) As DataTable
        Dim dataTb As DataTable
        Conectar()
        dataTb = GetCdp(Cod_Con)
        Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Protected Function GetRubros(ByVal Cod_Con As String) As DataTable
        querystring = "Select COD_RUB Rubro,Nom_Rub Descripcion,To_Char(VAL_COMPROMISO,'999,999,999') Valor FROM RUBROS_CONTRATOS Where COD_CON = :id "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":id", Cod_Con)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRubrosP(ByVal Cod_Con As String) As DataTable
        Dim dataTb As DataTable
        Conectar()
        dataTb = GetRubros(Cod_Con)
        Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function InsDocumento() As String
        Me.num_reg = 0
        querystring = "Update IntDocActas Set Estado='AN',Fec_Mod=sysdate, UsApMod=:usuario,UsBdMod=user Where Ide_Acta=:Ide_Acta "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Ide_Acta", Ide_Acta)
        Me.AsignarParametroCadena(":usuario", usuario)
        Me.num_reg = Me.EjecutarComando()
        querystring = "Insert Into IntDocActas (Ide_Acta, doc_pdf,doc_doc,doc_bas,Fec_Cre,Fec_Mod,UsAp)Values(:Ide_Acta, :doc_pdf,:doc_doc,:doc_bas,sysdate,sysdate,:usuario)  "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Ide_Acta", Ide_Acta)
        Me.AsignarParametroCadena(":usuario", usuario)
        Me.AsignarParametroBLOB(":doc_pdf", Doc_PDF)
        Me.AsignarParametroBLOB(":doc_doc", Doc_Doc)
        Me.AsignarParametroBLOB(":doc_bas", Doc_BAS)
        Me.num_reg += Me.EjecutarComando()
        Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Sub CargarDoc(ByVal Ide_Acta As String)
        Conectar()
        querystring = "Select * FROM IntDocActas Where Ide_Acta = :Ide_Acta And Estado='AC' "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Ide_Acta", Ide_Acta)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        If dataTb.Rows.Count > 0 Then
            Doc_Doc = DirectCast(dataTb.Rows(0)("Doc_Doc"), Byte())
            Doc_PDF = DirectCast(dataTb.Rows(0)("Doc_PDF"), Byte())
            Doc_BAS = DirectCast(dataTb.Rows(0)("Doc_Bas"), Byte())
            Fec_Cre = dataTb.Rows(0)("Fec_Cre")
        End If
    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetIdbyCod_con(ByVal cod_con As String) As String
        Dim id_cont1 As String
        Me.Conectar()
        querystring = "SELECT MAX(ID) as ID FROM VGESACTAS WHERE (NRO_CONTRATO = :cod_con)  and estado <>'AN'"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod_con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        id_cont1 = dataTb.Rows(0)("ID").ToString()
        Me.Desconectar()
        Return id_cont1
    End Function

End Class
