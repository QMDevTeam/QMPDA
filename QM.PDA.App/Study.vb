Imports QM.PDA.BO.Context


''' <summary>
''' Screen to select the Study the User will work with.
''' </summary>

Public Class Study

#Region " Properties "

    Private Const _radioButtonSeparation As Integer = 28
    Private Const _radioButtonwidth As Integer = 211
    Private _radioButtonFont As Drawing.Font = New Drawing.Font("Tahoma", 10, Drawing.FontStyle.Regular)

    Private _selectedValue As BO.Study
    Private _radioButtons As New List(Of RadioButton)

    Private _msbRequiredCap As String
    Private _msbRequiredMsg As String
    Private _noStudies As String
    Private _exit As String


    Public studies As List(Of BO.Study)

#End Region

#Region " Event Handlers "

    Private Sub Study_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim radioButton As RadioButton
        Dim yPosition As Integer = 0



        ' If there is already a Current Study, set it as the selected value.
        If CurrentStudy IsNot Nothing Then _selectedValue = CurrentStudy



        ' If there are no Studies, show the user a message.
        If studies.Count = 0 Then lblStudy.Text = Me._noStudies

        ' For each Study, create a Radio Button
        Dim studyFound As Boolean = False
        For Each study As BO.Study In studies
            radioButton = New RadioButton
            radioButton.Text = study.Name
            radioButton.Tag = study
            radioButton.Font = _radioButtonFont
            radioButton.Top = yPosition
            radioButton.Left = 0
            radioButton.Width = _radioButtonwidth
            AddHandler radioButton.Click, AddressOf RadioButton_Click

            If _selectedValue = study Then
                radioButton.Checked = True
                studyFound = True
            End If

            pnlAnswerArea.Controls.Add(radioButton)
            _radioButtons.Add(radioButton)
            yPosition += _radioButtonSeparation
        Next


        ' If there is a Current Study and it wasn't found in the list, set the Current Study to Null.
        If CurrentStudy IsNot Nothing AndAlso Not studyFound Then
            CurrentStudy = Nothing
            _selectedValue = Nothing
        End If


        btnBack.Text = Me._exit

    End Sub



    Private Sub RadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _selectedValue = CType(CType(sender, RadioButton).Tag, BO.Study)
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
        Me._msbRequiredCap = resources.GetString("study_msbRequiredCap")
        Me._msbRequiredMsg = resources.GetString("study_msbRequiredMsg")
        Me._noStudies = resources.GetString("study_noStudies")
        Me._exit = resources.GetString("study_exit")

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

        ' If there is a Current Study and the user selected exactly the same, do nothing
        If CurrentStudy IsNot Nothing AndAlso _selectedValue = CurrentStudy Then Return

        ' If the user selected a Study then set it as the Current Study, else set Current Study as Null.
        CurrentStudy = _selectedValue

    End Sub



    ''' <summary>
    ''' Checks if there is a selected study.
    ''' </summary>
    ''' <returns><c>True</c> if there's a selected study, <c>False</c> otherwise.</returns>

    Private Function Validate() As Boolean

        If _selectedValue Is Nothing Then
            MessageBox.Show(_msbRequiredMsg, _msbRequiredCap)
            Return False
        End If

        Return True

    End Function

#End Region

End Class