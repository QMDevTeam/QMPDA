Imports QM.PDA.BO.Context


''' <summary>
''' Displays all the available Questionnaire Instances and allows to add more.
''' </summary>

Public Class QuestionnaireInstance

#Region " Properties "

    Private _msbPendingItemsCap As String
    Private _msbPendingItemsMsg As String
    Private _modify As String

    Private Const _separation As Integer = 28
    Private Const _btnWidth As Integer = 62
    Private Const _lblWidth As Integer = 142
    Private Const _btnLeft As Integer = 144
    Private Const _lblLeft As Integer = 0
    Private _font As Drawing.Font = New Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Bold)

#End Region

#Region " Event Handlers "

    Private Sub QuestionnaireInstance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DrawList(False)

        ' Make available the extra menu options
        Me.mnuChangeQuestionnaire.Enabled = True
        Me.mnuChangeSubject.Enabled = True

        InputPanel.Enabled = False
        btnNext.Enabled = False
        btnBack.Text = "^^"

    End Sub



    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentQuestionnaire.CurrentInstanceID = CType(CType(sender, Button).Tag, BO.QuestionnaireInstance).InstanceID
        FormResult = FormResult.Next
        Me.Close()

    End Sub



    Private Sub btnVerify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerify.Click
        DrawList(True)
    End Sub



    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        CurrentQuestionnaire.CreateInstance()
        FormResult = FormResult.Next
        Me.Close()

    End Sub

#End Region

#Region " Public Methods "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(Me.GetType.Namespace & ".Resources", Me.GetType.Assembly)
        Me._msbPendingItemsCap = resources.GetString("questionnaireInstance_msbPendingItemsCap")
        Me._msbPendingItemsMsg = resources.GetString("questionnaireInstance_msbPendingItemsMsg")
        Me._modify = resources.GetString("questionnaireInstance_modify")

    End Sub

#End Region

#Region " Protected Methods "

    Protected Overrides Function CanGoBack() As Boolean

        If DrawList(True) Then

            Dim result As DialogResult = MessageBox.Show(_msbPendingItemsMsg, _msbPendingItemsCap, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            Return result = Windows.Forms.DialogResult.Yes
        Else
            Return True
        End If

    End Function



    Protected Overrides Function CanInterrupt() As Boolean
        Return CanGoBack()
    End Function

#End Region

#Region " Private Methods "

    Private Function DrawList(ByVal includeColorCodes As Boolean) As Boolean

        Cursor.Current = Cursors.WaitCursor
        pnlAnswerArea.SuspendLayout()

        Dim btnAction As Button
        Dim lblName As Label
        Dim yPosition As Integer = 0


        ' Clear the controls list
        Dim control As Control
        While pnlAnswerArea.Controls.Count > 2
            control = pnlAnswerArea.Controls(2)
            If TypeOf control Is Button Then RemoveHandler control.Click, AddressOf Button_Click
            control.Dispose()
        End While


        ' For each Instance, create a Label and a Button
        Dim pendingItem As Boolean = False
        For Each instance As BO.QuestionnaireInstance In CurrentQuestionnaire.Instances

            ' Create the Label
            lblName = New Label
            lblName.Text = instance.InstanceSecondaryID
            lblName.Font = _font
            lblName.Width = _lblWidth
            lblName.Height = _separation
            lblName.Top = yPosition
            lblName.Left = _lblLeft

            If includeColorCodes Then
                If instance.IsComplete Then
                    lblName.ForeColor = Color.LimeGreen
                Else
                    lblName.ForeColor = Color.Red
                    pendingItem = True
                End If
            End If

            ' Create the Button
            btnAction = New Button
            btnAction.Tag = instance
            btnAction.Text = Me._modify
            btnAction.Font = _font
            btnAction.Width = _btnWidth
            btnAction.Top = yPosition
            btnAction.Left = _btnLeft
            btnAction.BackColor = Color.Gold
            AddHandler btnAction.Click, AddressOf Button_Click

            ' Add them to the list
            pnlAnswerArea.Controls.Add(lblName)
            pnlAnswerArea.Controls.Add(btnAction)

            yPosition += _separation
        Next


        ' Relocate the Add and the Verify buttons
        btnVerify.Top = yPosition
        btnAdd.Top = yPosition


        pnlAnswerArea.ResumeLayout(False)
        Cursor.Current = Cursors.Default


        ' Inform if there are pending items
        Return pendingItem

    End Function

#End Region

End Class
