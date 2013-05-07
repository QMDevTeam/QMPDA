

''' <summary>
''' Represents a Study.
''' </summary>

Public Class Study

#Region " Properties "

    Private _studyID As String
    Private _securityFile As String
    Private _configFile As String
    Private _dataFile As String

    Private _shortName As String
    Private _name As String
    Private _version As String
    Private _designerVersion As String
    Private _generatorVersion As String
    Private _creationDateTime As DateTime
    Private _lastModificationDateTime As DateTime
    Private _generationDateTime As DateTime


    Private _questionnaireSets As List(Of QuestionnaireSet)
    Private _reports As List(Of Report)
    Private _reportsSiteCode As String
    Private Shared _studiesList As List(Of Study)



    Friend ReadOnly Property SecurityFile() As String
        Get
            Return _securityFile
        End Get
    End Property


    Friend ReadOnly Property ConfigFile() As String
        Get
            Return _configFile
        End Get
    End Property


    Friend ReadOnly Property DataFile() As String
        Get
            Return _dataFile
        End Get
    End Property


    Public ReadOnly Property StudyID() As String
        Get
            Return _studyID
        End Get
    End Property


    Public ReadOnly Property ShortName() As String
        Get
            Return _shortName
        End Get
    End Property


    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property


    Public ReadOnly Property Version() As String
        Get
            Return _version
        End Get
    End Property


    Public ReadOnly Property DesignerVersion() As String
        Get
            Return _designerVersion
        End Get
    End Property


    Public ReadOnly Property GeneratorVersion() As String
        Get
            Return _generatorVersion
        End Get
    End Property


    Public ReadOnly Property CreationDateTime() As DateTime
        Get
            Return _creationDateTime
        End Get
    End Property


    Public ReadOnly Property LastModificationDateTime() As DateTime
        Get
            Return _lastModificationDateTime
        End Get
    End Property


    Public ReadOnly Property GenerationDateTime() As DateTime
        Get
            Return _generationDateTime
        End Get
    End Property


    Public ReadOnly Property QuestionnaireSets() As List(Of QuestionnaireSet)
        Get
            If _questionnaireSets Is Nothing Then _questionnaireSets = QuestionnaireSet.GetAll()
            Return _questionnaireSets
        End Get
    End Property


    Public ReadOnly Property Reports(Optional ByVal siteCode As String = Nothing) As List(Of Report)
        Get
            If _reportsSiteCode Is Nothing OrElse _reportsSiteCode <> siteCode Then
                _reports = Report.GetAll(siteCode)
                _reportsSiteCode = siteCode
            End If

            Return _reports
        End Get
    End Property

#End Region

#Region " Public Methods "

    Public Shared Function GetAll() As List(Of Study)

        If _studiesList Is Nothing Then

            _studiesList = New List(Of Study)

            For Each row As DataRow In DA.StudyRegistry.GetAll().Rows
                _studiesList.Add(New Study(row))
            Next
        End If


        Return _studiesList

    End Function



    Public Shared Operator =(ByVal operand1 As Study, ByVal operand2 As Study) As Boolean
        If operand1 Is Nothing OrElse operand2 Is Nothing Then Return False
        Return operand1.StudyID = operand2.StudyID
    End Operator



    Public Shared Operator <>(ByVal operand1 As Study, ByVal operand2 As Study) As Boolean
        If operand1 Is Nothing OrElse operand2 Is Nothing Then Return False
        Return operand1.StudyID <> operand2.StudyID
    End Operator

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Initializes a new instance of the Study class.
    ''' </summary>
    ''' <param name="registryRow">A <c>DataRow</c> with the Study properties from the Registry.</param>

    Private Sub New(ByVal registryRow As DataRow)

        ' Populate the properties from the Registry
        PopulateRegistryProperties(registryRow)

        ' Get and populate the properties from the Database
        PopulateDatabaseProperties(DA.StudyTable.GetSingle(Me._configFile))

    End Sub



    ''' <summary>
    ''' Sets the values for the properties of this instance of a Study.
    ''' </summary>
    ''' <param name="row">A <c>DataRow</c> with the Study properties from the Registry.</param>

    Private Sub PopulateRegistryProperties(ByVal row As DataRow)

        _studyID = CStr(row("StudyID"))
        _securityFile = CStr(row("SecurityFile"))
        _configFile = CStr(row("ConfigFile"))
        _dataFile = CStr(row("DataFile"))

    End Sub



    ''' <summary>
    ''' Sets the values for the properties of this instance of a Study.
    ''' </summary>
    ''' <param name="row">A <c>DataRow</c> with the Study properties from the Database.</param>

    Private Sub PopulateDatabaseProperties(ByVal row As DataRow)

        _shortName = CStr(row("ShortName"))
        _name = CStr(row("Name"))
        _version = CStr(row("Version"))
        _designerVersion = CStr(row("DesignerVersion"))
        _generatorVersion = CStr(row("GeneratorVersion"))
        _creationDateTime = CDate(row("CreationDateTime"))
        _lastModificationDateTime = CDate(row("LastModificationDateTime"))
        _generationDateTime = CDate(row("GenerationDateTime"))

    End Sub

#End Region

End Class