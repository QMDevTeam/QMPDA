

''' <summary>
''' Provides access to the current state of the application.
''' </summary>

Public Class Context

    Public Enum UserAction
        CreateSubject
        ModifySubject
        ViewReport
    End Enum


    Private Shared _currentStudy As Study


    Public Shared CurrentUser As User
    Public Shared CurrentAction As Nullable(Of UserAction)
    Public Shared CurrentSite As Site

    Public Shared CurrentSubject As Subject
    Public Shared CurrentQuestionnaireSet As QuestionnaireSet
    Public Shared CurrentQuestionnaire As Questionnaire
    Public Shared CurrentSection As Section
    Public Shared CurrentScreen As Screen

    Public Shared CurrentReport As Report

    Public Shared ScreenStack As New Stack(Of Screen)


    Public Shared PDASerialNumber As String
    Public Shared PDAName As String



    Public Shared Property CurrentStudy() As Study
        Get
            Return _currentStudy
        End Get
        Set(ByVal value As Study)
            _currentStudy = value
            If value IsNot Nothing Then DA.Common.Init(_currentStudy.SecurityFile, _currentStudy.ConfigFile, _currentStudy.DataFile)
        End Set
    End Property


    Public Shared ReadOnly Property ConditionsDotNETClassName() As String
        Get
            Return String.Format("{0}.QM.Conditions.{1}.{2}{3},{0}.QM", _currentStudy.ShortName, CurrentQuestionnaireSet.ShortName, CurrentQuestionnaire.ShortName, CurrentSection.ShortName)
        End Get
    End Property


    Public Shared ReadOnly Property ValidationsDotNETClassName() As String
        Get
            Return String.Format("{0}.QM.Validations.{1}.{2}{3},{0}.QM", _currentStudy.ShortName, CurrentQuestionnaireSet.ShortName, CurrentQuestionnaire.ShortName, CurrentSection.ShortName)
        End Get
    End Property


    Public Shared ReadOnly Property EventsDotNETClassName() As String
        Get
            Return String.Format("{0}.QM.Events.{1}.{2}{3},{0}.QM", _currentStudy.ShortName, CurrentQuestionnaireSet.ShortName, CurrentQuestionnaire.ShortName, CurrentSection.ShortName)
        End Get
    End Property


    Public Shared ReadOnly Property PreconditionsDotNETClassName() As String
        Get
            Return String.Format("{0}.QM.Preconditions,{0}.QM", _currentStudy.ShortName)
        End Get
    End Property


    Public Shared ReadOnly Property ConstructorsDotNETClassName() As String
        Get
            Return String.Format("{0}.QM.Constructors,{0}.QM", _currentStudy.ShortName)
        End Get
    End Property


    Public Shared ReadOnly Property MethodNameSufix() As String
        Get
            Return String.Format("_{0}", CurrentScreen.Number.Replace("."c, "_"c))
        End Get
    End Property

End Class
