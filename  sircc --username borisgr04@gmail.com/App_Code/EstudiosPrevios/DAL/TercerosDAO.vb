Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class TercerosDAO
    Implements ITercerosDAO

    Dim ctx As New BDDatosG()

    Public Sub Delete(Id As Integer) Implements ITercerosDAO.Delete

    End Sub

    Public Function GetAll() As List(Of ETerceros) Implements ITercerosDAO.GetAll
        ctx.Conectar()
        ctx.CrearComando("Select * From Terceros")
        Dim dt As DataTable = ctx.EjecutarConsultaDataTable()
        Dim lst As List(Of ETerceros) = New List(Of ETerceros)
        For Each row In dt.Rows
            Try
                Dim e As New ETerceros
                e.Ape1_Ter = row("Ape1_Ter")
                e.Ape2_Ter = row("Ape2_Ter")
                e.Dep_Nec = row("Dep_Nec").ToString
                e.Dir_Ter = row("dir_ter")
                e.Dv_Ter = row("Dv_Ter").ToString
                e.Ema_Ter = row("ema_Ter")
                e.Estado = row("estado")
                'e.Exp_Ide = row("exp_ide")
                e.Ide_Ter = row("ide_ter")
                'e.Nom_Ter = row("nom_ter")
                'e.Nom1_Ter = row("nom1_ter")
                'e.Perfil = row("perfil")
                'e.Raz_Soc = row("raz_soc")
                e.Tel_Ter = row("Tel_Ter")
                e.Tip_Ide = row("tip_ide")
                e.Tipo = row("tipo")
                lst.Add(e)
            Catch ex As Exception
                lst.Add(New ETerceros)
            End Try
        Next
        Return lst
    End Function

    Public Function GetOne(Ide_Ter As Integer) As ETerceros Implements ITercerosDAO.GetOne
        Return New ETerceros()
    End Function

    Public Sub Insert(Bean As ETerceros) Implements ITercerosDAO.Insert

    End Sub

    Public Sub Update(Bean As ETerceros) Implements ITercerosDAO.Update

    End Sub
End Class
