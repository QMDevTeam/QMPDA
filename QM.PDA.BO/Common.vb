

''' <summary>
''' Provides general purpose data access functions and conection strings constants.
''' </summary>

Public Class Common

#Region " Public Methods "

    ''' <summary>
    ''' Gets the items in a Legal Value Table.
    ''' </summary>
    ''' <param name="table">The name of the Legal Value Table.</param>
    ''' <param name="value">The value of the item to retrieve.</param>
    ''' <returns>A <c>DataRow</c> with the Legal Value Table Item.</returns>

    Public Shared Function GetLegalValueTableItem(ByVal table As String, ByVal value As Integer) As DataRow

        Return DA.Common.GetLegalValueTableItem(table, value)

    End Function



    ''' <summary>
    ''' Gets one item in a Legal Value Table.
    ''' </summary>
    ''' <param name="table">The name of the Legal Value Table.</param>
    ''' <param name="group">The group of items to retrieve.</param>
    ''' <returns>A <c>DataTable</c> with the Legal Value Table items.</returns>

    Public Shared Function GetLegalValueTableItems(ByVal table As String, Optional ByVal group As String = Nothing) As DataTable

        Return DA.Common.GetLegalValueTableItems(table, group)

    End Function

#End Region

End Class
