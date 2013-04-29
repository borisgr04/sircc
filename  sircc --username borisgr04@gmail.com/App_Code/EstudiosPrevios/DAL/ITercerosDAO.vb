Imports Microsoft.VisualBasic

Interface ITercerosDAO

    ''' <summary>
    ''' Procedimiento que elimina un bean
    ''' </summary>
    ''' <param name="Id">Id del bean a eliminar</param>
    ''' <remarks></remarks>
    Sub Delete(ByVal Id As Integer)

    ''' <summary>
    ''' Función que obtiene una lista de beans
    ''' </summary>
    ''' <returns>Retorna una lista generica de beans</returns>
    ''' <remarks></remarks>
    Function GetAll() As List(Of ETerceros)

    ''' <summary>
    ''' Función que obtiene un bean
    ''' </summary>
    ''' <param name="Id">Id del bean a retornar</param>
    ''' <returns>Retorna el bean correspondiente a la id pasada por parametro</returns>
    ''' <remarks></remarks>
    Function GetOne(ByVal Id As Integer) As ETerceros

    ''' <summary>
    ''' Procedimiento que inserta un bean
    ''' </summary>
    ''' <param name="Bean">Bean a insertar</param>
    ''' <remarks></remarks>
    Sub Insert(ByVal Bean As ETerceros)

    ''' <summary>
    ''' Procedimiento que actualiza un bean
    ''' </summary>
    ''' <param name="Bean">Bean a actualizar</param>
    ''' <remarks></remarks>
    Sub Update(ByVal Bean As ETerceros)

End Interface
