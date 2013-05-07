Imports QM.PDA.BO.Context


Public Class ScreenHeader

    Private Enum CodeType
        VariableName
        ScreenNumber
    End Enum


    Private Shared _codeToShow As CodeType = CodeType.ScreenNumber


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub



    Private Sub ScreenHeader_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged

        ' Add any initialization after the InitializeComponent() call.
        lblTitle.Text = ""
        If CurrentStudy IsNot Nothing Then
            lblTitle.Text = CurrentStudy.ShortName

            If CurrentQuestionnaireSet IsNot Nothing Then
                lblTitle.Text &= " - " & CurrentQuestionnaireSet.ShortName

                If CurrentQuestionnaire IsNot Nothing Then
                    lblTitle.Text &= " - " & CurrentQuestionnaire.ShortName

                    If CurrentSection IsNot Nothing Then
                        If CurrentQuestionnaire.Sections.Count > 1 Then lblTitle.Text &= " - " & CurrentSection.ShortName
                    End If
                End If
            End If
        End If


        ' If this is not the QuestionnaireInstance screen...
        If Me.Parent.GetType.Name <> "QuestionnaireInstance" AndAlso CurrentQuestionnaire IsNot Nothing AndAlso CurrentQuestionnaire.MultipleInstances Then
            lblSubjectID.Text = CStr(CurrentQuestionnaire(CurrentQuestionnaire.InstanceSAIDField))
            lblSubjectID.Text &= " - " & CStr(CurrentQuestionnaire(CurrentQuestionnaire.InstanceSecondaryIDField))

        ElseIf CurrentSubject IsNot Nothing Then
            lblSubjectID.Text = CurrentSubject.SASubjectID
            lblSubjectID.Text &= " - " & CurrentSubject.SecondaryID

        Else
            lblSubjectID.Text = ""

        End If


        ShowCode()

    End Sub



    Private Sub ScreenHeader_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click

        Select Case _codeToShow
            Case CodeType.ScreenNumber : _codeToShow = CodeType.VariableName
            Case CodeType.VariableName : _codeToShow = CodeType.ScreenNumber
        End Select

        ShowCode()

    End Sub



    Private Sub ShowCode()

        Select Case True
            Case CurrentScreen Is Nothing : lblCode.Text = ""
            Case _codeToShow = CodeType.VariableName : lblCode.Text = CurrentScreen.VariableName
            Case _codeToShow = CodeType.ScreenNumber : lblCode.Text = CurrentScreen.Number
        End Select

    End Sub

End Class
