Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class CtrGenDocContratos
    Private ctx As New BDDatosG

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetContratos(ByVal cod_con As String) As DataTable
        ctx.Conectar()
        Dim querystring As String
        querystring = " select NUMERO, OBJ_CON , CONTRATISTA, IDCONTRATISTA,TIPOIDENTIFICACION, DEPENDENCIA, FECHAINICIO, FECHAFINAL, FEC_SUS_CON,  NOM_INTERVENTOR, PLAZO_TOTAL, VALOR_LETRAS, VALOR_TOTAL_DOC, EXP_IDE from VCONTRATOS_PLANTILLAS where NUMERO = :cod_con "
        ctx.CrearComando(querystring)
        ctx.AsignarParametroCadena(":cod_con", cod_con)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function

    
End Class
