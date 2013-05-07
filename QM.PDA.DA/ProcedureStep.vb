

''' <summary>
''' Provides data access to the ProcedureStep table in the configuration database.
''' </summary>

Public Class ProcedureStep

    ''' <summary>
    ''' Gets a single record with the information of the ProcedureStep object specified.
    ''' </summary>
    ''' <param name="procedureID">The unique identifier of the object in the database.</param>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetAll(ByVal procedureID As Integer) As DataTable

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM ProcedureStep WHERE ProcedureID = @ProcedureID ORDER BY [Order]", Common.ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@ProcedureID", SqlDbType.Int).Value = procedureID

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        Return dataTable

    End Function

End Class