Imports Microsoft.Win32


''' <summary>
''' Provides data access to the Study table in the configuration database.
''' </summary>

Public Class StudyTable

    ''' <summary>
    ''' Gets a single record with the information of the Study object.
    ''' </summary>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetSingle(ByVal configFile As String) As DataRow

        Dim connection As New SqlCeConnection(String.Format("Data Source={0}; Password=Qu3st10nn@1r3M0b1l3;", configFile))
        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM Study", connection)

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function

End Class




''' <summary>
''' Provides data access to the HKLM\Software\QM\Studies Registry Key
''' </summary>

Public Class StudyRegistry

    ''' <summary>
    ''' Gets a DataTable with the information of the Studies registered in the device Registry
    ''' </summary>
    ''' <returns>A <c>DataTable</c> with all the records found.</returns>

    Public Shared Function GetAll() As DataTable

        Dim studiesTable As New DataTable()
        studiesTable.Columns.Add("StudyID", GetType(String))
        studiesTable.Columns.Add("SecurityFile", GetType(String))
        studiesTable.Columns.Add("ConfigFile", GetType(String))
        studiesTable.Columns.Add("DataFile", GetType(String))
        studiesTable.Columns.Add("ReportsFile", GetType(String))

        Dim studiesRegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\QM\Studies")


        If studiesRegistryKey IsNot Nothing Then

            Dim studyRow As DataRow
            Dim studyKey As RegistryKey
            For Each studyKeyName As String In studiesRegistryKey.GetSubKeyNames()

                studyRow = studiesTable.NewRow
                studiesTable.Rows.Add(studyRow)
                studyKey = studiesRegistryKey.OpenSubKey(studyKeyName)

                studyRow("StudyID") = studyKeyName
                studyRow("SecurityFile") = studyKey.GetValue("SecurityFile", Nothing)
                studyRow("ConfigFile") = studyKey.GetValue("ConfigFile", Nothing)
                studyRow("DataFile") = studyKey.GetValue("DataFile", Nothing)
                studyRow("ReportsFile") = studyKey.GetValue("ReportsFile", Nothing)
            Next
        End If


        Return studiesTable

    End Function

End Class