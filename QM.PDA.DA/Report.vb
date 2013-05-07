

''' <summary>
''' Provides data access to the QuestionnaireSet table in the configuration database.
''' </summary>


Public Class Report


    ''' <summary>
    ''' Gets all the records with the information of the report objets that applies to
    ''' the current site of the Study, if provided.
    ''' </summary>
    ''' <returns>A <c>SqlCeResultSet</c> with all the records found.</returns>

    Public Shared Function GetAllAvialible(Optional ByVal siteCode As String = Nothing) As List(Of Object())

        Dim query As String = "SELECT Report.* FROM Report"
        If Not String.IsNullOrEmpty(siteCode) Then query &= String.Format(" LEFT JOIN ReportSite ON ReportSite.ReportGuid = Report.ReportGuid WHERE ReportSite.SiteCode = '{0}' OR ReportSite.SiteCode IS NULL", siteCode)

        Dim command As New SqlCeCommand(query, Common.ConfigDBConnection)

        Dim resultSet As SqlCeResultSet = command.ExecuteResultSet(ResultSetOptions.None)
        Dim records As New List(Of Object())


        While resultSet.Read()
            Dim record(resultSet.FieldCount - 1) As Object
            resultSet.GetValues(record)
            records.Add(record)
        End While


        resultSet.Dispose()
        command.Dispose()

        Return records

    End Function


    ''' <summary>
    ''' Returns all the records with the information of the column objects that belong
    ''' to the specifided report.
    ''' </summary>
    ''' <param name="reportGuid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function GetAllColumns(ByVal reportGuid As Guid) As List(Of Object())

        Dim command As New SqlCeCommand(String.Format("SELECT * FROM ReportColumn WHERE ReportGuid = '{0}' --ORDER BY [Order]", reportGuid), Common.ConfigDBConnection)

        Dim resultSet As SqlCeResultSet = command.ExecuteResultSet(ResultSetOptions.None)
        Dim records As New List(Of Object())


        While resultSet.Read()
            Dim record(resultSet.FieldCount - 1) As Object
            resultSet.GetValues(record)
            records.Add(record)
        End While


        resultSet.Dispose()
        command.Dispose()

        Return records

    End Function


    ''' <summary>
    ''' Returns all the records with the information of the site codes that belong
    ''' to the specifided report.
    ''' </summary>
    ''' <param name="reportGuid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function GetAllSiteCodes(ByVal reportGuid As Guid) As List(Of Object())

        Dim command As New SqlCeCommand(String.Format("SELECT * FROM ReportSite WHERE ReportGuid = '{0}'", reportGuid), Common.ConfigDBConnection)

        Dim resultSet As SqlCeResultSet = command.ExecuteResultSet(ResultSetOptions.None)
        Dim records As New List(Of Object())


        While resultSet.Read()
            Dim record(resultSet.FieldCount - 1) As Object
            resultSet.GetValues(record)
            records.Add(record)
        End While


        resultSet.Dispose()
        command.Dispose()

        Return records

    End Function

End Class
