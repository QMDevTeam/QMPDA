Imports QM.PDA.BO.Context


''' <summary>
''' Displays all the available Sections.
''' </summary>

Public Class Section

#Region " Properties "

    Private Const _separation As Integer = 28
    Private Const _btnWidth As Integer = 62
    Private Const _lblWidth As Integer = 142
    Private Const _btnLeft As Integer = 144
    Private Const _lblLeft As Integer = 0
    Private _font As Drawing.Font = New Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Bold)
    Private _noSectionsCap As String
    Private _modifyCap As String
    Private _createCap As String

    Public Sections As List(Of BO.Section)

#End Region

#Region " Event Handlers "

    Private Sub Section_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim btnSectionAction As Button
        Dim lblSectionName As Label
        Dim yPosition As Integer = 0
        Dim drawShadow As Boolean = False


        ' If there are no Sections, show the user a message.
        If Sections.Count = 0 Then lblSection.Text = Me._noSectionsCap

        ' For each Section, create a Label and a Button
        Dim sectionHasRecord As Boolean
        For Each section As BO.Section In Sections

            sectionHasRecord = section.HasRecord

            ' Create the Label
            lblSectionName = New Label
            lblSectionName.Text = section.Name
            lblSectionName.Font = _font
            lblSectionName.Width = _lblWidth
            lblSectionName.Height = _separation
            lblSectionName.Top = yPosition
            lblSectionName.Left = _lblLeft
            If sectionHasRecord Then lblSectionName.ForeColor = CType(IIf(section.IsComplete, Color.LimeGreen, Color.Red), Color)

            ' Create the Button
            btnSectionAction = New Button
            btnSectionAction.Tag = section
            btnSectionAction.Text = CStr(IIf(sectionHasRecord, Me._modifyCap, Me._createCap))
            btnSectionAction.Font = _font
            btnSectionAction.Width = _btnWidth
            btnSectionAction.Top = yPosition
            btnSectionAction.Left = _btnLeft
            btnSectionAction.BackColor = CType(IIf(sectionHasRecord, Color.Gold, Color.LawnGreen), Color)
            AddHandler btnSectionAction.Click, AddressOf Button_Click

            ' Add them to the list
            pnlAnswerArea.Controls.Add(lblSectionName)
            pnlAnswerArea.Controls.Add(btnSectionAction)

            yPosition += _separation
        Next


        ' Make available the extra menu options
        Me.mnuChangeQuestionnaire.Enabled = True
        Me.mnuChangeSubject.Enabled = True

        InputPanel.Enabled = False
        btnNext.Enabled = False
        btnBack.Text = "^^"

    End Sub



    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentSection = CType(CType(sender, Button).Tag, BO.Section)
        FormResult = FormResult.Next
        Me.Close()

    End Sub

#End Region

#Region " Public Methods "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' dd any initialization after the InitializeComponent() call.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(Me.GetType.Namespace & ".Resources", Me.GetType.Assembly)
        Me._noSectionsCap = resources.GetString("section_noSectionCap")
        Me._modifyCap = resources.GetString("section_modifyCap")
        Me._createCap = resources.GetString("section_createCap")

    End Sub

#End Region

End Class
