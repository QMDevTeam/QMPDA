

''' <summary>
''' Class with the information of a user
''' </summary>

Public Class User

#Region " Properties "

    Private _PDAUserName As String
    Private _name As String
    Private _roleName As String
    Private _defaultSiteID As Nullable(Of Integer)


    Private _defaultSite As Site



    Public ReadOnly Property PDAUserName() As String
        Get
            Return _PDAUserName
        End Get
    End Property


    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property


    Public ReadOnly Property RoleName() As String
        Get
            Return _roleName
        End Get
    End Property


    Public ReadOnly Property DefaultSite() As Site
        Get
            If _defaultSite IsNot Nothing Then Return _defaultSite
            If _defaultSiteID.HasValue AndAlso Site.Exists(_defaultSiteID.Value) Then _defaultSite = New Site(_defaultSiteID.Value)
            Return _defaultSite
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Gets a list of users
    ''' </summary>
    ''' <returns>A <c>List</c> of users</returns>

    Public Shared Function GetAll() As List(Of User)

        Dim list As New List(Of User)

        For Each row As DataRow In DA.Security.GetAll().Rows
            list.Add(New User(row))
        Next

        Return list

    End Function



    ''' <summary>
    ''' Get a user information from the security db
    ''' </summary>
    ''' <param name="PDAUserName">PDA user name</param>
    ''' <param name="PDAPassword">PDA password</param>
    ''' <returns>A <c>>User</c> if the person exist, <c>Nothing</c> otherwise</returns>

    Public Shared Function Login(ByVal PDAUserName As String, ByVal PDAPassword As String) As User

        Dim row As DataRow = DA.Security.GetUser(PDAUserName, PDAPassword)

        If row Is Nothing Then Return Nothing Else Return New User(row)

    End Function

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="row">DataRow with all the information</param>
    ''' <remarks></remarks>

    Private Sub New(ByVal row As DataRow)
        PopulateProperties(row)
    End Sub



    ''' <summary>
    ''' Sets the properties
    ''' </summary>
    ''' <param name="row">DataRow with all the information</param>

    Private Sub PopulateProperties(ByVal row As DataRow)

        _PDAUserName = CStr(row("PDAUserName"))
        _name = CStr(row("Name"))
        _roleName = CStr(row("RoleName"))

        'Nullables
        If TypeOf row("DefaultSiteID") Is DBNull Then _defaultSiteID = Nothing Else _defaultSiteID = CInt(row("DefaultSiteID"))

    End Sub

#End Region


End Class
