

''' <summary>
''' Represents a Report.
''' </summary>

Public Class Report

#Region " Properties "

    Private _guid As Guid
    Private _name As String
    Private _formTypeName As String
    Private _sites As New List(Of String)
    Private _query As String
    Private _columns As New List(Of Column)
    Private _reportType As Integer



    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property



    Public ReadOnly Property FormTypeName() As String
        Get
            Return _formTypeName
        End Get
    End Property



    Public ReadOnly Property Sites() As List(Of String)
        Get
            Return _sites
        End Get
    End Property



    Public ReadOnly Property Query() As String
        Get
            Return _query
        End Get
    End Property



    Public ReadOnly Property Columns() As List(Of Column)
        Get
            Return _columns
        End Get
    End Property



    Public ReadOnly Property ReportType() As Integer
        Get
            Return _reportType
        End Get
    End Property


#End Region

#Region " Public Methods "

    Public Overrides Function ToString() As String
        Return _name
    End Function


    Public Shared Function GetAll(Optional ByVal siteCode As String = Nothing) As List(Of Report)

        Dim list As New List(Of Report)
        Dim reports As List(Of Object()) = DA.Report.GetAllAvialible(siteCode)

        ' Look for the report definition file.
        If reports.Count > 0 Then

            Dim report As Report

            For Each properties As Object() In reports

                report = New Report(properties)
                list.Add(report)

            Next

        End If

        Return list

    End Function

#End Region



#Region " Private Methods "

    Private Sub New(ByVal properties As Object())

        Me._guid = CType(properties(0), Guid)
        Me._name = CStr(properties(1))
        Me._reportType = CInt(properties(2))

        If CInt(properties(2)) = 1 Then
            ' Standard report.
            Me._query = CStr(properties(4))
            Me.GetColumns()

        ElseIf CInt(properties(2)) = 2 Then
            ' Custom report.
            Me._formTypeName = CStr(properties(3))

        End If

        Me.GetSiteCodes()

    End Sub


    Private Sub GetColumns()

        Me._columns = New List(Of Column)
        Dim column As Column
        For Each properties As Object() In DA.Report.GetAllColumns(Me._guid)
            column = New Column()
            column.Name = CStr(properties(2))
            column.HeaderText = CStr(properties(3))
            column.Width = CInt(properties(4))
            If Not DBNull.Value.Equals(properties(5)) Then column.Format = CStr(properties(5))
            Me.Columns.Add(column)
        Next

    End Sub


    Private Sub GetSiteCodes()

        Me._sites = New List(Of String)
        For Each properties As Object() In DA.Report.GetAllSiteCodes(Me._guid)
            Me._sites.Add(CStr(properties(1)))
        Next

    End Sub

#End Region



#Region " Classes "

    Public Class Column

        Public Name As String
        Public HeaderText As String
        Public Width As Integer
        Public Format As String

    End Class

#End Region

End Class
