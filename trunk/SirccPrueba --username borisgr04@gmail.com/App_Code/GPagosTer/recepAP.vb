Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class recepAP
    Inherits BDDatos



    ''' <summary>
    ''' Consulta de contratos por llave primaria, filtrando por dependencia necesidad asociada.
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByContratosPk(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vcontratos_sinc_p Where numero =:cod_con  "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", Cod_Con)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(obj As Int_GP_SEG_DOC) As String
        Try
            Conectar()
            ComenzarTransaccion()

            Me.num_reg = 0
            querystring = "Select Nvl(Max(Id),0)+1 As Id_max From Int_GP_SEG_DOC "
            Me.CrearComando(querystring)
            obj.Id_Doc = EjecutarEscalar()

            querystring = "Insert Into Int_GP_SEG_DOC (Id,Id_Doc, FEc_Reg, Est_ini, Est_Fin, Obs_Seg, UsAp, UsBd ) "
            querystring += " (:Id,:Id_Doc, :Fec_Reg, :Est_Ini, :Est_Fin, :Obs_Seg, :usap, sysdate )"
            Me.CrearComando(querystring)
            Me.AsignarParametroEntero(":Id", obj.Id)
            Me.AsignarParametroEntero(":Id_Doc", obj.Id_Doc)
            Me.AsignarParametroCadena(":Fec_Reg", obj.Fec_Reg)
            Me.AsignarParametroCadena(":Est_Ini", obj.Est_Ini)
            Me.AsignarParametroCadena(":Est_Fin", obj.Est_Fin)
            Me.AsignarParametroCadena(":Obs_Seg", obj.Obs_Seg)
            Me.AsignarParametroCadena(":usap", Me.usuario)
            Me.num_reg += Me.EjecutarComando()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"

            ConfirmarTransaccion()
            lErrorG = False
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message + ex.StackTrace
            CancelarTransaccion()
        Finally
            Desconectar()

        End Try
        Return Msg
    End Function
End Class
