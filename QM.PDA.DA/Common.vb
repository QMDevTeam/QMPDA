Imports System.Text


''' <summary>
''' Provides general purpose data access functions and conection strings constants.
''' </summary>

Public Class Common


#Region " Properties "

    ' Global connections
    ' This method is more eficient in SQL CE
    Private Shared _securityDBConnection As SqlCeConnection
    Private Shared _configDBConnection As SqlCeConnection
    Private Shared _dataDBConnection As SqlCeConnection



    Friend Shared ReadOnly Property SecurityDBConnection() As SqlCeConnection
        Get
            If Not _securityDBConnection.State = ConnectionState.Open Then _securityDBConnection.Open()
            Return _securityDBConnection
        End Get
    End Property


    Friend Shared ReadOnly Property ConfigDBConnection() As SqlCeConnection
        Get
            If Not _configDBConnection.State = ConnectionState.Open Then _configDBConnection.Open()
            Return _configDBConnection
        End Get
    End Property


    Friend Shared ReadOnly Property DataDBConnection() As SqlCeConnection
        Get
            If Not _dataDBConnection.State = ConnectionState.Open Then _dataDBConnection.Open()
            Return _dataDBConnection
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Initializes the database connections to be used.
    ''' </summary>
    ''' <param name="securityFile">The path to the Security File.</param>
    ''' <param name="configFile">The path to the Configuration File.</param>
    ''' <param name="dataFile">The path to the Data File.</param>

    Public Shared Sub Init(ByVal securityFile As String, ByVal configFile As String, ByVal dataFile As String)

        ' Connection strings
        Dim securityDB As String = String.Format("Data Source={0}; Password=Qu3st10nn@1r3M0b1l3;", securityFile)
        Dim configDB As String = String.Format("Data Source={0}; Password=Qu3st10nn@1r3M0b1l3;", configFile)
        Dim dataDB As String = String.Format("Data Source={0}; Password=Qu3st10nn@1r3M0b1l3; Mode=Shared Read", dataFile)
        _securityDBConnection = New SqlCeConnection(securityDB)
        _configDBConnection = New SqlCeConnection(configDB)
        _dataDBConnection = New SqlCeConnection(dataDB)

    End Sub



    ''' <summary>
    ''' Gets the items in a Legal Value Table.
    ''' </summary>
    ''' <param name="table">The name of the Legal Value Table.</param>
    ''' <param name="value">The value of the item to retrieve.</param>
    ''' <returns>A <c>DataRow</c> with the Legal Value Table Item.</returns>

    Public Shared Function GetLegalValueTableItem(ByVal table As String, ByVal value As Integer) As DataRow

        Dim dataAdapter As New SqlCeDataAdapter("SELECT Value, [Order], Text, [Group] FROM LegalValue WHERE TableName = @TableName AND Value = @Value ORDER BY [Order]", ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = table
        dataAdapter.SelectCommand.Parameters.Add("@Value", SqlDbType.Int).Value = value
        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function



    ''' <summary>
    ''' Gets one item in a Legal Value Table.
    ''' </summary>
    ''' <param name="table">The name of the Legal Value Table.</param>
    ''' <param name="group">The group of items to retrieve.</param>
    ''' <returns>A <c>DataTable</c> with the Legal Value Table items.</returns>

    Public Shared Function GetLegalValueTableItems(ByVal table As String, Optional ByVal group As String = Nothing) As DataTable

        Dim whereClause As String = ""
        If Not String.IsNullOrEmpty(group) Then whereClause = String.Format("AND [GROUP] = '{0}'", group)

        Dim dataAdapter As New SqlCeDataAdapter(String.Format("SELECT Value, [Order], Text, [Group], ShortName FROM LegalValue WHERE TableName = @TableName {0} ORDER BY [Order]", whereClause), ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = table
        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        Return dataTable

    End Function



    ''' <summary>
    ''' Inserts a new item into a Legal Value Table.
    ''' </summary>
    ''' <param name="table">The name of the Legal Value Table.</param>
    ''' <param name="value">The Value for the new item.</param>
    ''' <param name="order">The Order for the new item.</param>
    ''' <param name="text">The Text for the new item.</param>
    ''' <param name="shortName">The Short Name for the new item.</param>
    ''' <param name="group">The Group for the new item.</param>

    Public Shared Sub InsertLegalValueTableItem(ByVal table As String, ByVal value As Integer, ByVal order As Integer, ByVal text As String, Optional ByVal shortName As String = Nothing, Optional ByVal group As String = Nothing)

        Dim command As New SqlCeCommand("INSERT INTO LegalValue VALUES (@TableName, @Value, @Order, @Text, @ShortName, @Group)", ConfigDBConnection)

        command.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = table
        command.Parameters.Add("@Value", SqlDbType.Int).Value = value
        command.Parameters.Add("@Order", SqlDbType.Int).Value = order
        command.Parameters.Add("@Text", SqlDbType.NVarChar).Value = text
        command.Parameters.Add("@ShortName", SqlDbType.NVarChar).Value = IIf(shortName Is Nothing, DBNull.Value, shortName)
        command.Parameters.Add("@Group", SqlDbType.NVarChar).Value = IIf(group Is Nothing, DBNull.Value, group)

        command.ExecuteNonQuery()

    End Sub

#End Region

End Class
