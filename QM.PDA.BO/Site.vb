

''' <summary>
''' Class that handels the information from the sites
''' </summary>

Public Class Site

#Region " Properties "

    Private _siteID As Integer
    Private _name As String
    Private _code As String



    Public ReadOnly Property SiteID() As Integer
        Get
            Return _siteID
        End Get
    End Property


    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property


    Public ReadOnly Property Code() As String
        Get
            Return _code
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Construct when the site already exist
    ''' </summary>
    ''' <param name="siteID">The site id</param>

    Public Sub New(ByVal siteID As Integer)

        Dim row As DataRow = DA.Site.GetSingle(siteID)

        If row Is Nothing Then Throw New ApplicationException(String.Format("The Site with ID[{0}] does not exists", siteID))
        PopulateProperties(row)

    End Sub



    ''' <summary>
    ''' Indicates if a Site with the specified identifier exists.
    ''' </summary>
    ''' <param name="siteID">The site id</param>
    ''' <returns><c>True</c> if the a record exists, <c>False</c> otherwise.</returns>

    Public Shared Function Exists(ByVal siteID As Integer) As Boolean
        Return DA.Site.Exists(siteID)
    End Function



    Public Shared Function GetAll() As List(Of Site)

        Dim list As New List(Of Site)

        For Each row As DataRow In DA.Site.GetAll().Rows
            list.Add(New Site(row))
        Next

        Return list

    End Function



    Public Shared Operator =(ByVal operand1 As Site, ByVal operand2 As Site) As Boolean
        If operand1 Is Nothing OrElse operand2 Is Nothing Then Return False
        Return operand1.SiteID = operand2.SiteID
    End Operator



    Public Shared Operator <>(ByVal operand1 As Site, ByVal operand2 As Site) As Boolean
        If operand1 Is Nothing OrElse operand2 Is Nothing Then Return False
        Return operand1.SiteID <> operand2.SiteID
    End Operator

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="row">DataRow with the site's information</param>

    Private Sub New(ByVal row As DataRow)
        PopulateProperties(row)
    End Sub



    ''' <summary>
    ''' Sets the properties values
    ''' </summary>
    ''' <param name="row">DataRow with the information</param>

    Private Sub PopulateProperties(ByVal row As DataRow)

        _siteID = CInt(row("SiteID"))
        _name = CStr(row("Name"))
        _code = CStr(row("Code"))

    End Sub

#End Region

End Class