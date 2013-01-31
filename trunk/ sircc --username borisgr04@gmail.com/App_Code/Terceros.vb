Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel


<System.ComponentModel.DataObject()> _
Public Class Terceros
    Inherits BDDatos

    Public Sub New()
        Me.Tabla = "Terceros"
        Me.VistaDB = "vTercerosDB"
    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetIsAsig_Proc(Optional ByVal User As String = "") As Boolean
        If User = "" Then
            User = Me.usuario
        End If
        Me.Conectar()
        querystring = "SELECT Count(*) C FROM Hdep_Abogados Where Ide_Ter=:Ide_Ter And Estado='AC' And Asig_Proc='SI'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Ide_Ter", User)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return IIf(dataTb.Rows(0)("C") > 0, True, False)
    End Function

    '

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByUser(Optional ByVal User As String = "") As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado

        If User = "" Then
            User = Me.usuario
        End If
        'Me.Desconectar()
        Me.Conectar()
        querystring = "SELECT * FROM vTerceros WHERE Ide_Ter=:Ide_Ter"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Ide_Ter", User)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByIdeCSUT(ByVal Ide_ter As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vTerceros WHERE Ide_Ter=:Ide_Ter And ((tipo='CS') or (tipo='UT'))"

        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Ide_Ter", Ide_ter)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByIde(ByVal Ide_ter As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vTerceros WHERE Ide_Ter=:Ide_Ter"

        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Ide_Ter", Ide_ter)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByTipo(ByVal Tipo As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VTerceros WHERE Tipo=:Tipo"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Tipo", Tipo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)> _
    Public Overloads Function Delete(ByVal Ide_ter As String) As String

        Me.Conectar()
        Try

            querystring = "DELETE FROM Terceros WHERE Ide_Ter=:Ide_Ter"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena("Ide_Ter", Ide_ter)
            num_reg = Me.EjecutarComando()
            lErrorG = False
            Msg = MsgOk + +"Filas Afectadas [" + Me.num_reg.ToString + "]"
        Catch ex As Exception
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try

        Return Msg

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal busc As String, ByVal tipo As String) As DataTable

        Me.Conectar()
        '++++++++++ TIPO: 
        '** AR -> AGENTE RECAUDADOR
        '** RT -> RENTAS
        '** OT -> OTRO - PD o P
        '**
        Dim tp As String = "OT"
        If (tipo = "AR") Or (tipo = "RT") Then
            tp = tipo
        End If
        Dim queryString As String
        If busc <> "" Then
            busc = "%" + UCase(busc) + "%"
            queryString = "SELECT * FROM VTERCEROS WHERE (IDE_TER like :busc) OR (upper(NOM_TER) like :busc) "
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":busc", busc)
            Me.AsignarParametroCadena(":busc", busc)
        Else
            queryString = "SELECT * FROM VTERCEROS WHERE 1<>1"
            Me.CrearComando(queryString)
        End If

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetTercerosxDep(ByVal busc As String, ByVal cod_dep As String) As DataTable

        Me.Conectar()

        Dim queryString As String
        If busc <> "" Then
            busc = "%" + UCase(busc) + "%"
            queryString = "select * from vHDEP_SOLOABOGADOS WHERE ((IDE_TER like :busc) OR (upper(NOM_TER) like :busc)) and cod_dep=:cod_dep "
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":busc", busc)
            Me.AsignarParametroCadena(":busc", busc)
            Me.AsignarParametroCadena(":cod_dep", cod_dep)
        Else
            queryString = "select * from vHDEP_SOLOABOGADOS where cod_dep=:cod_dep"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":cod_dep", cod_dep)
        End If

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetTercerosxIde_Dep(ByVal ide_ter As String, ByVal cod_dep As String) As DataTable

        Me.Conectar()

        Dim queryString As String


        queryString = "select * from vHDEP_ABOGADOS WHERE IDE_TER like :ide_ter and cod_dep=:cod_dep "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":ide_ter", ide_ter)
        Me.AsignarParametroCadena(":cod_dep", cod_dep)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetTercerosxIde_DepAbo(ByVal ide_ter As String, ByVal cod_dep As String) As DataTable

        Me.Conectar()

        Dim queryString As String


        queryString = "select * from vHDEP_SOLOABOGADOS WHERE IDE_TER like :ide_ter and cod_dep=:cod_dep "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":ide_ter", ide_ter)
        Me.AsignarParametroCadena(":cod_dep", cod_dep)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal busc As String) As DataTable

        Me.Conectar()

        If busc <> "" Then
            busc = "%" + UCase(busc) + "%"
            querystring = "SELECT * FROM VTERCEROS WHERE (IDE_TER like :busc) OR (upper(NOM_TER) like :busc) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":busc", busc)
            Me.AsignarParametroCadena(":busc", busc)
        Else
            querystring = "SELECT * FROM VTERCEROS WHERE 1<>1"
            Me.CrearComando(querystring)
        End If

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsJQ(ByVal busc As String) As DataTable

        Me.Conectar()

        'busc = Left(busc, busc.IndexOf("-"))

        If busc <> "" Then
            busc = "%" + UCase(busc) + "%"
            querystring = "SELECT * FROM VTERCEROS WHERE (IDE_TER like :busc) OR (upper(NOM_TER) like :busc) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":busc", busc)
            Me.AsignarParametroCadena(":busc", busc)
        Else
            querystring = "SELECT * FROM VTERCEROS WHERE 1<>1"
            Me.CrearComando(querystring)
        End If

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    Public Function Insert(ByVal ide As String, ByVal ape1 As String, ByVal ape2 As String, ByVal nom1 As String, ByVal nom2 As String, ByVal dir As String, ByVal tel As String, ByVal ema As String, ByVal tip_ide As String, ByVal dv_ter As String, ByVal exp_ide As String, ByVal raz_soc As String, ByVal tipo As String) As String
        Try

            Me.Conectar()

            Me.ComenzarTransaccion()

            ape1 = UCase(ape1)
            ape2 = IIf(UCase(ape2) <> "", UCase(ape2), " ")
            nom1 = IIf(UCase(nom1) <> "", UCase(nom1), " ")
            nom2 = IIf(UCase(nom2) <> "", UCase(nom2), " ")

            dir = IIf(dir <> "", dir, "-")
            tel = IIf(tel <> "", tel, "-")
            ema = IIf(ema <> "", ema, "-")

            querystring = "INSERT INTO Terceros (ide_ter,ape1_ter,ape2_ter,nom1_ter,nom2_ter,dir_ter, tel_ter,ema_ter,tip_ide,dv_ter,exp_ide,raz_soc,tipo)VALUES(:ide_ter,:ape1_ter,:ape2_ter,:nom1_ter,:nom2_ter,:dir_ter, :tel_ter,:ema_ter,:tip_ide,:dv_ter,:exp_ide,:raz_soc,:tipo) "
            Me.CrearComando(querystring)

            Me.AsignarParametroCadena(":ide_ter", ide)
            Me.AsignarParametroCadena(":ape1_ter", ape1)
            Me.AsignarParametroCadena(":ape2_ter", ape2)
            Me.AsignarParametroCadena(":nom1_ter", nom1)
            Me.AsignarParametroCadena(":nom2_ter", nom2)
            Me.AsignarParametroCadena(":dir_ter", dir)
            Me.AsignarParametroCadena(":tel_ter", tel)
            Me.AsignarParametroCadena(":ema_ter", ema)
            'nuevos campos
            Me.AsignarParametroCadena(":tip_ide", tip_ide)
            Me.AsignarParametroCadena(":dv_ter", dv_ter)
            Me.AsignarParametroCadena(":exp_ide", exp_ide)
            Me.AsignarParametroCadena(":raz_soc", raz_soc)
            Me.AsignarParametroCadena(":tipo", tipo)


            Msg = MsgOk + "<br>" + "Se Agrego un Nuevo Tercero Nº " + ide

            Me.EjecutarComando()

            Me.ConfirmarTransaccion()
            lErrorG = False
        Catch ex As Exception
            Msg = ex.Message
            Me.CancelarTransaccion()
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try

        Return Msg
    End Function

    Public Function Update(ByVal ide_old As String, ByVal ide As String, ByVal ape1 As String, ByVal ape2 As String, ByVal nom1 As String, ByVal nom2 As String, ByVal dir As String, ByVal tel As String, ByVal ema As String, ByVal razsoc As String, ByVal DV_TER As String, ByVal EXP_IDE As String, ByVal TIP_IDE As String, ByVal tipo As String) As String

        Me.Conectar()

        Me.ComenzarTransaccion()

        ape1 = UCase(ape1)
        ape2 = IIf(UCase(ape2) <> "", UCase(ape2), " ")
        nom1 = IIf(UCase(nom1) <> "", UCase(nom1), " ")
        nom2 = IIf(UCase(nom2) <> "", UCase(nom2), " ")

        dir = IIf(dir <> "", dir, "-")
        tel = IIf(tel <> "", tel, "-")
        ema = IIf(ema <> "", ema, "-")

        querystring = "UPDATE Terceros SET ide_ter= '" + ide + "', ape1_ter= '" + ape1 + "', ape2_ter= '" + ape2 + "', nom1_ter= '" + nom1 + "', nom2_ter= '" + nom2 + "', dir_ter= '" + dir + "', tel_ter= '" + tel + "', ema_ter= '" + ema + "',raz_soc='" + razsoc + "',DV_TER='" + DV_TER + "',EXP_IDE='" + EXP_IDE + "',TIP_IDE='" + TIP_IDE + "',TIPO='" + tipo + "' WHERE ide_ter= '" + ide_old + "'"

        Me.CrearComando(querystring)
        Try
            Me.EjecutarComando()
            Msg = "Se Modificò Tercero Nº " + ide
            Me.ConfirmarTransaccion()
            lErrorG = False
            Msg = MsgOk + "<br>" + Msg
        Catch ex As Exception
            Msg = ex.Message
            Me.CancelarTransaccion()
            lErrorG = True
        End Try

        Return Msg

    End Function

    ''' ASIGNAR MIEMBROS A CONSORCIOS Y UNIONES TEMPORALES
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function AsignarAbogado(ByVal Id_Ter As String, ByVal Id_Miembro As String, ByVal Id_Estado As String) As String
        Me.Conectar()
        Try
            Dim queryString As String = "Insert Into CONSORCIOSUT(Id_Ter, Id_Miembro, Id_Estado)Values(:Id_Ter,:Id_Miembro, :Id_Estado)"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":Id_Ter", Id_Ter)
            Me.AsignarParametroCadena(":Id_Miembro", Id_Miembro)
            Me.AsignarParametroCadena(":Id_Estado", Id_Estado)
            Me.num_reg = EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error: " + ex.Message
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetConsorcios(ByVal busc As String, ByVal tipo As String) As DataTable

        Me.Conectar()
        '++++++++++ TIPO: 
        '** AR -> AGENTE RECAUDADOR
        '** RT -> RENTAS
        '** OT -> OTRO - PD o P
        '**
        Dim tp As String = "OT"
        If (tipo = "AR") Or (tipo = "RT") Then
            tp = tipo
        End If
        Dim queryString As String
        If busc <> "" Then
            busc = "%" + UCase(busc) + "%"
            queryString = "SELECT * FROM VTERCEROS WHERE ((IDE_TER like :busc) OR (upper(NOM_TER) like :busc)) and ((tipo='CS') or (tipo='UT')) "
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":busc", busc)
            Me.AsignarParametroCadena(":busc", busc)
        Else
            queryString = "SELECT * FROM VTERCEROS WHERE 1<>1"
            Me.CrearComando(queryString)
        End If

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    ''' <summary>
    ''' AUTOR: ERIC Y. MARTINEZ GONZALEZ
    ''' FUNCION QUE AUTORIZA UN USUARIO PARA ADMINISTRAR SIRCC DESKTOP
    ''' </summary>
    ''' <param name="Ide_Ter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AdminDesktop(ByVal Ide_Ter As String) As String
        Me.Conectar()
        Try
            Dim queryString As String = "Insert Into TERCEROSDESKTOP(Usuario, Administrador)Values(:Id_Ter,:Admin)"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":Id_Ter", Ide_Ter)
            Me.AsignarParametroCadena(":Admin", "AdminDesktop")
            Me.num_reg = EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error: " + ex.Message
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
End Class
