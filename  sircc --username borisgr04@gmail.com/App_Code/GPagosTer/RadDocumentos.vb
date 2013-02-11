Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class RadDocumentos
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetEstados(ByVal Vig_Est As String) As DataTable
        Me.Conectar()
        querystring += " SELECT rut.vig_rut, rut.est_de, rut.est_para, rut.cla_rut, est.nom_est,est.cod_est FROM int_gp_rut_est rut INNER JOIN int_gp_est est ON est.cod_est = rut.est_para WHERE (rut.vig_rut, rut.id_rut) IN ( SELECT rol.vig_rut, rol.ID_ROL FROM int_gp_usu_rol rol WHERE rol.est_rol = 'AC' AND rol.usuario = :Usuario AND rol.vig_rut = :Vig_Est)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Vig_Est", Vig_Est)
        Me.AsignarParametroCadena(":Usuario", Me.usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    
        


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDocs(Vig_Est As String, ByVal Cla_Doc As String, Est_Para As String, Hecho As String, filtro As String) As DataTable
        Me.Conectar()
        querystring = " Select c.Numero,Id,c.Contratista,e.nom_est Documento,c.Obj_Con Objeto, ec.val_pago,c.NOM_INTERVENTOR Supervisor,c.Valor_Total_Doc Valor, c.VALOR_TOTAL_PROP Aportes_Propios "
        querystring += " From estcontratos ec "
        querystring += " Inner Join estados e On  e.cod_est=ec.est_fin  "
        querystring += " Inner Join vContratos_Sinc_p c On ec.cod_con=c.numero "
        querystring += " Where ec.Estado='AC' And Cla_Doc=:Cla_Doc "
        If Not String.IsNullOrEmpty(filtro) Then
            querystring += " And (c.Obj_Con like '%" + filtro + "%' Or to_char(Id)='" + filtro + "' )"
        End If
        If Hecho = "S" Then
            querystring += " And ec.EST_DOC=:est_para"
            Me.CrearComando(querystring)
            'Me.AsignarParametroCadena(":filtro", "%" + filtro + "%")
            'Me.AsignarParametroCadena(":filtro", filtro)
            Me.AsignarParametroCadena(":est_para", Est_Para)
            Me.AsignarParametroCadena(":Cla_Doc", Cla_Doc)
        Else
            querystring += " And ec.EST_DOC In (SELECT rut.est_de FROM int_gp_rut_est rut  WHERE rut.est_para=:est_para And rut.cla_rut='AP' AND Vig_Rut=:Vig_Est)"
            Me.CrearComando(querystring)
            'Me.AsignarParametroCadena(":filtro", "%" + filtro + "%")
            'Me.AsignarParametroCadena(":filtro", filtro)
            Me.AsignarParametroCadena(":Vig_Est", Vig_Est)
            Me.AsignarParametroCadena(":est_para", Est_Para)
            Me.AsignarParametroCadena(":Cla_Doc", Cla_Doc)
        End If
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function



End Class
