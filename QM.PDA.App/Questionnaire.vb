Imports QM.PDA.BO.Context


''' <summary>
''' Displays all the available Questionnaries.
''' </summary>

Public Class Questionnaire

#Region " Properties "

    Private Const _separation As Integer = 28
    Private Const _btnWidth As Integer = 62
    Private Const _lblWidth As Integer = 142
    Private Const _btnLeft As Integer = 144
    Private Const _lblLeft As Integer = 0
    Private _font As Drawing.Font = New Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Bold)

    Private _noQuestionnaires As String
    Private _modify As String
    Private _create As String

    Public Questionnaires As List(Of BO.Questionnaire)

#End Region

#Region " Event Handlers "

    Private Sub Questionnaire_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim btnQuestionnaireAction As Button
        Dim lblQuestionnaireName As Label
        Dim yPosition As Integer = 0
        Dim drawShadow As Boolean = False


        ' If there are no Questionnaires, show the user a message.
        If Questionnaires.Count = 0 Then lblQuestionnaire.Text = Me._noQuestionnaires

        ' For each Questionnaire, create a Label and a Button
        Dim questionnaireHasRecord As Boolean
        For Each questionnaire As BO.Questionnaire In Questionnaires

            ' Check if the Questionnaire has a record only if it doesn't support Multiple Instances.
            ' This is to improve UI response.
            If questionnaire.MultipleInstances Then questionnaireHasRecord = False Else questionnaireHasRecord = questionnaire.HasRecord()

            ' Create the Label
            lblQuestionnaireName = New Label
            lblQuestionnaireName.Text = questionnaire.Name
            lblQuestionnaireName.Font = _font
            lblQuestionnaireName.Width = _lblWidth
            lblQuestionnaireName.Height = _separation
            lblQuestionnaireName.Top = yPosition
            lblQuestionnaireName.Left = _lblLeft
            If questionnaireHasRecord Then lblQuestionnaireName.ForeColor = CType(IIf(questionnaire.IsComplete, Color.LimeGreen, Color.Red), Color)

            ' Create the Button
            btnQuestionnaireAction = New Button()
            btnQuestionnaireAction.Tag = questionnaire
            btnQuestionnaireAction.Text = CStr(IIf(questionnaireHasRecord OrElse questionnaire.MultipleInstances, Me._modify, Me._create))
            '                                                             ^ This is to improve UI response.
            btnQuestionnaireAction.Font = _font
            btnQuestionnaireAction.Width = _btnWidth
            btnQuestionnaireAction.Top = yPosition
            btnQuestionnaireAction.Left = _btnLeft
            btnQuestionnaireAction.BackColor = CType(IIf(questionnaireHasRecord OrElse questionnaire.MultipleInstances, Color.Gold, Color.LawnGreen), Color)
            '                                                                                                          ^ This is to improve UI response.
            AddHandler btnQuestionnaireAction.Click, AddressOf Button_Click

            ' Add them to the list
            pnlAnswerArea.Controls.Add(lblQuestionnaireName)
            pnlAnswerArea.Controls.Add(btnQuestionnaireAction)

            yPosition += _separation
        Next


        ' Make available the extra menu options
        Me.mnuChangeSubject.Enabled = True

        InputPanel.Enabled = False
        btnNext.Enabled = False
        btnBack.Text = "^^"

    End Sub



    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentQuestionnaire = CType(CType(sender, Button).Tag, BO.Questionnaire)
        FormResult = FormResult.Next
        Me.Close()

    End Sub

#End Region


#Region " Public method "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(Me.GetType.Namespace & ".Resources", Me.GetType.Assembly)
        Me._noQuestionnaires = resources.GetString("questionnaire_noQuestionnaires")
        Me._modify = resources.GetString("questionnaire_modify")
        Me._create = resources.GetString("questionnaire_create")

    End Sub

#End Region

End Class
