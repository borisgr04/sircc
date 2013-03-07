Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

<System.ComponentModel.DataObject()> _
Public Class Consultas
    Inherits BDDatos



    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetConsultaRp(ByVal Vigencia As String) As DataTable
        Me.Conectar()
        'querystring = "Select c.cod_con, SVal_Rp,val_apo_gob,(SVal_Rp-Val_apo_gob) Diferencia From (SELECT rp.cod_con, SUM (val_rp) SVal_Rp FROM rp_contratos rp WHERE vigencia = :Vig_Con GROUP BY rp.cod_con ) Rp2 Inner Join Contratos C  On Rp2.cod_con=C.Cod_Con And Vig_Con=:Vig_Con Where (SVal_Rp-Val_apo_gob)<>0"
        querystring = "Select c.numero , Val_Rp Valor_Rp, Val_Apo_Gob Valor_Contrato,(Val_Rp- Val_Apo_Gob) Diferencia, c.Obj_Con Objeto, Fec_Sus_con, COntratista  From ( "
        querystring += "SELECT   cod_con, SUM (val_compromiso) Val_Rp "
        querystring += "FROM Rubros_Contratos "
        querystring += "WHERE cod_con LIKE :Vig_Con||'%' "
        querystring += "GROUP BY cod_con "
        querystring += "ORDER BY cod_con "
        querystring += " ) Rp Inner Join vContratos_sinc C On C.numero=rp.cod_con And Vig_Con=:Vig_Con "
        querystring += "Where (Val_Rp- Val_Apo_Gob)<>0 Order by COd_Con "

        querystring = " SELECT  Tipo, c.numero,val_Rp Valor_Rp, cant_rp Cantidad_Rp,val_con valor_total, val_apo_gob valor_aportes, (val_rp - val_apo_gob) diferencia, "
        querystring += " obj_con Objeto, fec_sus_con Fecha_Suscripción, contratista "
        querystring += " FROM vcontratos_sinc c "
        querystring += " Left Join "
        querystring += " (SELECT   cod_con,  SUM (val_compromiso) val_rp, count(*) cant_rp "
        querystring += " FROM(Rubros_Contratos) "
        querystring += " WHERE cod_con LIKE :Vig_Con || '%' "
        querystring += " GROUP BY cod_con "
        querystring += " ORDER BY cod_con) rp ON c.numero = rp.cod_con AND vig_con = :Vig_Con "
        querystring += " WHERE ((val_rp - val_apo_gob) <> 0) Or (val_rp is null) And Vig_Con=:Vig_Con "
        querystring += " ORDER BY numero "


        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorTipo(ByVal fec_ini As Date, ByVal fec_fin As Date, ByVal dep_pcon As String) As DataTable
        Me.Conectar()
        'querystring = "SELECT   nom_tproc, COUNT (*) cantidad, SUM (valor_adicion (numero) + val_apo_gob) valor FROM vcontratosc2 WHERE  ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy')  and dep_pcon=:dep_pcon GROUP BY nom_tproc Order by nom_tproc desc"
        'querystring = "SELECT nom_tproc,COUNT(*) Cantidad,SUM(Val_Con) Valor_Inicial,SUM(Val_Apo_Gob) Aportes_Propios,SUM(Val_Otros) Aportes_Otros,Sum(Val_Adi) Valor_Adicionado,Sum(Val_Adi+val_con) Valor_Total FROM VCONTRATOSC_Adi01 WHERE ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy') And dep_pcon=:dep_pcon  GROUP BY nom_tproc Order by nom_tproc"
        querystring = "SELECT TIPO,COUNT(*) Cantidad,SUM(Val_Con) Valor_Inicial,SUM(Val_Apo_Gob) Aportes_Propios,SUM(Val_Otros) Aportes_Otros,Sum(Val_Adi) Valor_Adicionado,Sum(Val_Adi+val_con) Valor_Total FROM vcontratos_Sinc_p WHERE ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy') And dep_pcon=:dep_pcon GROUP BY Tipo Order by Tipo"
        Me.CrearComando(querystring)

        Me.AsignarParametroCadena(":fec_ini", fec_ini)
        Me.AsignarParametroCadena(":fec_fin", fec_fin)
        Me.AsignarParametroCadena(":dep_pcon", dep_pcon)
        '
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorTproc(ByVal fec_ini As Date, ByVal fec_fin As Date, ByVal dep_pcon As String) As DataTable
        Me.Conectar()
        'querystring = "SELECT   nom_tproc, COUNT (*) cantidad, SUM (valor_adicion (numero) + val_apo_gob) valor FROM vcontratosc2 WHERE  ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy')  and dep_pcon=:dep_pcon GROUP BY nom_tproc Order by nom_tproc desc"
        querystring = "SELECT nom_tproc,COUNT(*) Cantidad,SUM(Val_Con) Valor_Inicial,SUM(Val_Apo_Gob) Aportes_Propios,SUM(Val_Otros) Aportes_Otros,Sum(Val_Adi) Valor_Adicionado,Sum(Val_Adi+val_con) Valor_Total FROM vcontratos_Sinc_p WHERE ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy') And dep_pcon=:dep_pcon  GROUP BY nom_tproc Order by nom_tproc"
        Me.CrearComando(querystring)

        Me.AsignarParametroCadena(":fec_ini", fec_ini)
        Me.AsignarParametroCadena(":fec_fin", fec_fin)
        Me.AsignarParametroCadena(":dep_pcon", dep_pcon)
        '
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorTprocG(ByVal fec_ini As Date, ByVal fec_fin As Date) As DataTable
        Me.Conectar()
        'querystring = "SELECT   nom_tproc, COUNT (*) cantidad, SUM (valor_adicion (numero) + val_apo_gob) valor FROM vcontratosc2 WHERE  ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy')  and dep_pcon=:dep_pcon GROUP BY nom_tproc Order by nom_tproc desc"
        querystring = "SELECT nom_tproc,COUNT(*) Cantidad,SUM(Val_Con) Valor_Inicial,SUM(Val_Apo_Gob) Aportes_Propios,SUM(Val_Otros) Aportes_Otros,Sum(Val_Adi) Valor_Adicionado,Sum(Val_Adi+val_con) Valor_Total FROM vcontratos_Sinc_p WHERE ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy')  GROUP BY nom_tproc Order by nom_tproc"
        Me.CrearComando(querystring)

        Me.AsignarParametroCadena(":fec_ini", fec_ini)
        Me.AsignarParametroCadena(":fec_fin", fec_fin)

        '
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorDep(ByVal fec_ini As Date, ByVal fec_fin As Date, ByVal dep_pcon As String) As DataTable
        Me.Conectar()
        'querystring = "SELECT Dependencia, COUNT (*) cantidad, SUM (valor_adicion (numero) + val_apo_gob) valor FROM vcontratosc2 WHERE ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy') And dep_pcon=:dep_pcon GROUP BY dependencia Order by dependencia desc"
        querystring = "SELECT dependencia,COUNT(*) Cantidad,SUM(Val_Con) Valor_Inicial,SUM(Val_Apo_Gob) Aportes_Propios,SUM(Val_Otros) Aportes_Otros,Sum(Val_Adi) Valor_Adicionado,Sum(Val_Adi+val_con) Valor_Total FROM vcontratos_Sinc_p WHERE ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy') And dep_pcon=:dep_pcon  GROUP BY dependencia Order by dependencia"

        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":fec_ini", fec_ini)
        Me.AsignarParametroCadena(":fec_fin", fec_fin)
        Me.AsignarParametroCadena(":dep_pcon", dep_pcon)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorDel(ByVal fec_ini As Date, ByVal fec_fin As Date, ByVal Tipo As String) As DataTable
        Me.Conectar()
        'querystring = "SELECT   dependenciap, COUNT (*) cantidad,SUM (valor_adicion (numero) + val_apo_gob) valor    FROM vcontratosc2 WHERE ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy') GROUP BY dependenciap Order by dependenciap desc"
        Dim filtipo As String = ""
        'If Tipo <> "" Then
        filtipo = " And Tipo='" + Tipo + "'"
        'End If
        querystring = "SELECT dependenciap,COUNT(*) Cantidad,SUM(Val_Con) Valor_Inicial,SUM(Val_Apo_Gob) Aportes_Propios,SUM(Val_Otros) Aportes_Otros,Sum(Val_Adi) Valor_Adicionado,Sum(Val_Adi+val_con) Valor_Total FROM vcontratos_Sinc_p WHERE ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy') " + filtipo + " GROUP BY dependenciap Order by dependenciap"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":fec_ini", fec_ini)
        Me.AsignarParametroCadena(":fec_fin", fec_fin)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorTipo(ByVal fec_ini As Date, ByVal fec_fin As Date) As DataTable
        Me.Conectar()
        querystring = "SELECT TIPO,COUNT(*) Cantidad,SUM(Val_Con) Valor_Inicial,SUM(Val_Apo_Gob) Aportes_Propios,SUM(Val_Otros) Aportes_Otros,Sum(Val_Adi) Valor_Adicionado,Sum(Val_Adi+val_con) Valor_Total FROM vcontratos_Sinc_p WHERE ESTADO<>'Anulado' and fec_sus_con between to_date(:fec_ini,'dd/mm/yyyy') and to_date(:fec_fin,'dd/mm/yyyy')  GROUP BY Tipo Order by Tipo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":fec_ini", fec_ini)
        Me.AsignarParametroCadena(":fec_fin", fec_fin)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    'SELECT TIPO,COUNT(*),SUM(Val_Con) Valor_Total,SUM(Val_Apo_Gob) Aportes_Propios,SUM(Val_Otros) Aportes_Otros,Sum(Val_Adi) Valor_Adicionado FROM VCONTRATOSC_Adi01 GROUP BY TIPO
    'SELECT   dependenciap, COUNT (*) cantidad,SUM (valor_adicion (numero) + val_apo_gob) valor FROM vcontratosc2 WHERE vig_con = 2010  and ESTADO<>'Anulado' and fec_sus_con between '01/12/2010' and '31/12/2010' GROUP BY dependenciap Order by dependenciap desc

    
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPendietes() As DataTable
        Me.Conectar()

        querystring = "SELECT 1 ""Código"",'Actividades Pendientes para Hoy' Descrip,Count(*) Cantidad FROM vPCronoAvisosHoy Where usuencargado=:Usuario "
        querystring += "UNION "
        querystring += "SELECT 2 ""Código"", 'Actividades Atrasadas' Descrip,Count(*) Cantidad FROM vPCronoAvisos Where usuencargado=:Usuario "
        querystring += "UNION "
        querystring += "SELECT 3 ""Código"", 'Solicitudes por Recibir' Descrip,Count(*) Cantidad FROM vPSOLICITUDES WHERE Recibido='N' and Id_Abog_Enc=:Usuario "
        querystring += "UNION "
        querystring += "SELECT 4 ""Código"", 'Solicitudes por Revisar' Descrip,Count(*) From VPSolicitudes Where Recibido='S' And Concepto='P' And id_Abog_Enc=:Usuario "

        Me.CrearComando(querystring)

        Me.AsignarParametroCadena(":Usuario", usuario)
        Me.AsignarParametroCadena(":Usuario", usuario)
        Me.AsignarParametroCadena(":Usuario", usuario)
        Me.AsignarParametroCadena(":Usuario", usuario)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class