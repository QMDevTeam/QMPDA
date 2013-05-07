<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Section
    Inherits QM.PDA.Screens.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Section))
        Me.ScreenHeader = New QM.PDA.Screens.ScreenHeader
        Me.lblSection = New System.Windows.Forms.Label
        Me.pnlAnswerArea = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'btnNext
        '
        resources.ApplyResources(Me.btnNext, "btnNext")
        '
        'btnBack
        '
        resources.ApplyResources(Me.btnBack, "btnBack")
        '
        'mnuGPS
        '
        resources.ApplyResources(Me.mnuGPS, "mnuGPS")
        '
        'mnuTools
        '
        resources.ApplyResources(Me.mnuTools, "mnuTools")
        '
        'mnuToolsSeparator
        '
        resources.ApplyResources(Me.mnuToolsSeparator, "mnuToolsSeparator")
        '
        'mnuChangeSubject
        '
        resources.ApplyResources(Me.mnuChangeSubject, "mnuChangeSubject")
        '
        'mnuChangeQuestionnaire
        '
        resources.ApplyResources(Me.mnuChangeQuestionnaire, "mnuChangeQuestionnaire")
        '
        'mnuChangeStudy
        '
        resources.ApplyResources(Me.mnuChangeStudy, "mnuChangeStudy")
        '
        'mnuChangeBlockSeparator
        '
        resources.ApplyResources(Me.mnuChangeBlockSeparator, "mnuChangeBlockSeparator")
        '
        'mnuLogout
        '
        resources.ApplyResources(Me.mnuLogout, "mnuLogout")
        '
        'ScreenHeader
        '
        resources.ApplyResources(Me.ScreenHeader, "ScreenHeader")
        Me.ScreenHeader.Name = "ScreenHeader"
        '
        'lblSection
        '
        resources.ApplyResources(Me.lblSection, "lblSection")
        Me.lblSection.Name = "lblSection"
        '
        'pnlAnswerArea
        '
        resources.ApplyResources(Me.pnlAnswerArea, "pnlAnswerArea")
        Me.pnlAnswerArea.Name = "pnlAnswerArea"
        '
        'Section
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.ScreenHeader)
        Me.Controls.Add(Me.lblSection)
        Me.Controls.Add(Me.pnlAnswerArea)
        Me.Name = "Section"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.pnlAnswerArea, 0)
        Me.Controls.SetChildIndex(Me.lblSection, 0)
        Me.Controls.SetChildIndex(Me.ScreenHeader, 0)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ScreenHeader As Screens.ScreenHeader
    Private WithEvents lblSection As System.Windows.Forms.Label
    Friend WithEvents pnlAnswerArea As System.Windows.Forms.Panel

End Class
