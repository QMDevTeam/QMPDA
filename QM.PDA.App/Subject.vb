Imports QM.PDA.BO.Context


Public Class Subject

#Region " Properties "

    Private Const _labelSeparation As Integer = 20
    Private Const _labelWidth As Integer = 220
    Private Const _labelHeight As Integer = 16

    Private _msbRequiredCap As String
    Private _msbRequiredMsg As String

    Private _subjectSecondaryIDField As String
    Private _subjectConfirmationFields As String
    Private _subjectAlternativeSearchField As String

#End Region

#Region " Event Handlers "

    Private Sub Subject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me._subjectSecondaryIDField = CurrentQuestionnaireSet.SubjectSecondaryIDField
        Me._subjectAlternativeSearchField = CurrentQuestionnaireSet.SubjectAlternativeSearchField
        Me._subjectConfirmationFields = CurrentQuestionnaireSet.SubjectConfirmationFields

        If CurrentStudy IsNot Nothing Then

            ' If an alternative search field wasn't defined, then hide the selection RadioButtons.
            If String.IsNullOrEmpty(Me._subjectAlternativeSearchField) Then
                rbSubjectWithID.Hide()
                rbSubjectWithoutID.Hide()
            End If

            ' Look for subjects with ID by default.
            rbSubjectWithID.Checked = True

        End If

    End Sub



    Private Sub RadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSubjectWithID.CheckedChanged, rbSubjectWithoutID.CheckedChanged
        If CType(sender, RadioButton).Checked Then FillSubjectList()
    End Sub



    Private Sub cmbSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubject.SelectedIndexChanged
        DisplayConfirmationFields()
    End Sub

#End Region

#Region " Public Methods "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(Me.GetType.Namespace & ".Resources", Me.GetType.Assembly)
        Me._msbRequiredCap = resources.GetString("subject_msbRequiredCap")
        Me._msbRequiredMsg = resources.GetString("subject_msbRequiredMsg")

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

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Fills the list with the Subjects in the Study.
    ''' </summary>

    Private Sub FillSubjectList()

        Cursor.Current = Cursors.WaitCursor
        'Application.DoEvents()

        If rbSubjectWithID.Checked Then
            cmbSubject.ValueMember = "SubjectID"
            cmbSubject.DisplayMember = "SASubjectID"
            cmbSubject.DataSource = CurrentQuestionnaireSet.GetSubjects(BO.Subject.SubjectCondition.WithSASubjectID, CurrentSite)
        End If

        If rbSubjectWithoutID.Checked Then
            cmbSubject.ValueMember = "SubjectID"
            cmbSubject.DisplayMember = Me._subjectAlternativeSearchField
            cmbSubject.DataSource = CurrentQuestionnaireSet.GetSubjects(BO.Subject.SubjectCondition.WithoutSASubjectID, CurrentSite)
        End If

        If cmbSubject.Items.Count = 0 Then ClearConfirmationFields()

        Cursor.Current = Cursors.Default
        Application.DoEvents()

    End Sub



    ''' <summary>
    ''' Displays the confirmation fields for the currently selected Subject.
    ''' </summary>

    Private Sub DisplayConfirmationFields()

        If Not String.IsNullOrEmpty(Me._subjectConfirmationFields) Then

            If Not cmbSubject.SelectedItem Is Nothing Then

                Dim subject As New BO.Subject(CType(cmbSubject.SelectedValue, Guid), CurrentQuestionnaireSet)
                Dim yPosition As Integer = 0
                Dim lblLabel As Label
                Dim variable As BO.Variable
                Dim legalValue As String

                ClearConfirmationFields()
                For Each confirmationField As String In Me._subjectConfirmationFields.Split(","c)
                    lblLabel = New Label()
                    lblLabel.Location = New Point(0, yPosition)
                    lblLabel.Size = New Size(_labelWidth, _labelHeight)
                    confirmationField = confirmationField.Trim
                    variable = New BO.Variable(confirmationField)

                    If Not String.IsNullOrEmpty(variable.LegalValueTable) AndAlso variable.DataType = "integer" AndAlso subject(confirmationField) IsNot Nothing Then
                        legalValue = BO.Common.GetLegalValueTableItem(variable.LegalValueTable, Integer.Parse(subject(confirmationField).ToString))("Text").ToString()
                        lblLabel.Text = String.Format("{0}: {1}", confirmationField, legalValue)
                    Else
                        lblLabel.Text = String.Format("{0}: {1}", confirmationField, subject(confirmationField))
                    End If
                    lblLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
                    pnlAnswerArea.Controls.Add(lblLabel)

                    yPosition += _labelSeparation
                Next
            End If
        End If

    End Sub



    ''' <summary>
    ''' Clears the Confirmation Fields in the Answer Area Panel.
    ''' </summary>

    Private Sub ClearConfirmationFields()

        For Each control As Control In pnlAnswerArea.Controls
            control.Dispose()
        Next

        pnlAnswerArea.Controls.Clear()

    End Sub



    ''' <summary>
    ''' Store the selected subject.
    ''' </summary>

    Private Sub StoreValue()

        ' If there is a Current Subject and the user selected exactly the same, do nothing
        If CurrentSubject IsNot Nothing AndAlso cmbSubject.SelectedValue IsNot Nothing AndAlso CurrentSubject.SubjectID = CType(cmbSubject.SelectedValue, Guid) Then Return

        ' If the user selected a Subject then set it as the Current Subject, else set Current Subject as Null.
        If cmbSubject.SelectedValue IsNot Nothing Then CurrentSubject = New BO.Subject(CType(cmbSubject.SelectedValue, Guid), CurrentQuestionnaireSet) Else CurrentStudy = Nothing

    End Sub



    ''' <summary>
    ''' Checks if there is a selected subject.
    ''' </summary>
    ''' <returns><c>True</c> if there's a selected subject, <c>False</c> otherwise.</returns>

    Private Function Validate() As Boolean

        If cmbSubject.SelectedItem Is Nothing Then
            MessageBox.Show(_msbRequiredMsg, _msbRequiredCap)
            Return False
        End If

        Return True

    End Function



    ''' <summary>
    ''' Checks if the parameter is parsable to integer.
    ''' </summary>
    ''' <param name="o">Object to parse.</param>
    ''' <returns>True if parsable.</returns>
    ''' <remarks></remarks>

    Private Shared Function isIngeger(ByVal o As Object) As Boolean

        Try

            Dim i As Integer = Integer.Parse(o.ToString)
            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

#End Region

End Class
