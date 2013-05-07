Imports QM.PDA.BO.Context


''' <summary>
''' Screen to select the Questionnaire Set the User will work with.
''' </summary>

Public Class QuestionnaireSet

#Region " Properties "

    Private Const _radioButtonSeparation As Integer = 28
    Private Const _radioButtonwidth As Integer = 211
    Private _radioButtonFont As Drawing.Font = New Drawing.Font("Tahoma", 10, Drawing.FontStyle.Regular)

    Private _selectedValue As BO.QuestionnaireSet
    Private _radioButtons As New List(Of RadioButton)

    Private _msbRequiredCap As String
    Private _msbRequiredMsg As String
    Private _noQuestionnaireSetCap As String

    Public QuestionnaireSets As List(Of BO.QuestionnaireSet)

#End Region

#Region " Event Handlers "

    Private Sub QuestionnaireSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim radioButton As RadioButton
        Dim yPosition As Integer = 0


        ' If there is already a Current Questionnaire Set, set it as the selected value.
        If CurrentQuestionnaireSet IsNot Nothing Then _selectedValue = CurrentQuestionnaireSet


        ' If there are no Questionnaire Sets, show the user a message.
        If QuestionnaireSets.Count = 0 Then lblQuestionnaireSet.Text = Me._noQuestionnaireSetCap

        ' For each Questionnaire Set, create a Radio Button
        Dim questionnaireSetFound As Boolean = False
        For Each questionnaireSet As BO.QuestionnaireSet In QuestionnaireSets

            radioButton = New RadioButton
            radioButton.Text = questionnaireSet.Name
            radioButton.Tag = questionnaireSet
            radioButton.Font = _radioButtonFont
            radioButton.Top = yPosition
            radioButton.Left = 0
            radioButton.Width = _radioButtonwidth
            AddHandler radioButton.Click, AddressOf RadioButton_Click

            If _selectedValue = questionnaireSet Then
                radioButton.Checked = True
                questionnaireSetFound = True
            End If

            pnlAnswerArea.Controls.Add(radioButton)
            _radioButtons.Add(radioButton)
            yPosition += _radioButtonSeparation
        Next


        ' If there is a Current Questionnaire Set and it wasn't found in the list, set the Current Questionnaire Set to Null.
        If CurrentQuestionnaireSet IsNot Nothing AndAlso Not questionnaireSetFound Then
            CurrentQuestionnaireSet = Nothing
            _selectedValue = Nothing
        End If

        btnBack.Text = "^^"

    End Sub



    Private Sub RadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _selectedValue = CType(CType(sender, RadioButton).Tag, BO.QuestionnaireSet)
    End Sub



    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        FormResult = FormResult.ExitApplication
        Me.Close()

    End Sub

#End Region

#Region " Public Methods "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(Me.GetType.Namespace & ".Resources", Me.GetType.Assembly)
        Me._msbRequiredCap = resources.GetString("questionnaireSet_msbRequiredCap")
        Me._msbRequiredMsg = resources.GetString("questionnaireSet_msbRequiredMsg")
        Me._noQuestionnaireSetCap = resources.GetString("questionnaireSet_noQuestionnaireSetCap")

    End Sub

#End Region

#Region " Protected Methods "

    ''' <summary>
    ''' Check if it is possible to go to the next screen.
    ''' </summary>
    ''' <returns><c>True</c> if it is possible, <c>False</c> otherwise.</returns>

    Protected Overrides Function CanGoNext() As Boolean
        Return Validate()
    End Function



    ''' <summary>
    ''' Stores the value before going to the next screen.
    ''' </summary>

    Protected Overrides Sub GoNext()
        StoreValue()
    End Sub



    ''' <summary>
    ''' Stores the value before going to the previous screen.
    ''' </summary>

    Protected Overrides Sub GoBack()
        StoreValue()
    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Store the selected study.
    ''' </summary>

    Private Sub StoreValue()

        ' If there is a Current Questionnaire Set and the user selected exactly the same, do nothing
        If CurrentQuestionnaireSet IsNot Nothing AndAlso _selectedValue = CurrentQuestionnaireSet Then Return

        ' If the user selected a Questionnaire Set then set it as the Current Questionnaire Set, else set the Current Questionnaire Set as Null.
        CurrentQuestionnaireSet = _selectedValue

    End Sub



    ''' <summary>
    ''' Checks if there is a selected Questionnaire Set.
    ''' </summary>
    ''' <returns><c>True</c> if there's a selected Questionnaire Set, <c>False</c> otherwise.</returns>

    Private Function Validate() As Boolean

        If _selectedValue Is Nothing Then
            MessageBox.Show(_msbRequiredMsg, _msbRequiredCap)
            Return False
        End If

        Return True

    End Function

#End Region

End Class