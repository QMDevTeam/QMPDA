<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Action
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Action))
        Me.rbCreateSubject = New System.Windows.Forms.RadioButton
        Me.rbModifySubject = New System.Windows.Forms.RadioButton
        Me.rbViewReports = New System.Windows.Forms.RadioButton
        Me.lblAction = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
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
        'rbCreateSubject
        '
        resources.ApplyResources(Me.rbCreateSubject, "rbCreateSubject")
        Me.rbCreateSubject.Name = "rbCreateSubject"
        '
        'rbModifySubject
        '
        resources.ApplyResources(Me.rbModifySubject, "rbModifySubject")
        Me.rbModifySubject.Name = "rbModifySubject"
        '
        'rbViewReports
        '
        resources.ApplyResources(Me.rbViewReports, "rbViewReports")
        Me.rbViewReports.Name = "rbViewReports"
        '
        'lblAction
        '
        resources.ApplyResources(Me.lblAction, "lblAction")
        Me.lblAction.Name = "lblAction"
        '
        'lblVersion
        '
        resources.ApplyResources(Me.lblVersion, "lblVersion")
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Name = "lblVersion"
        '
        'Action
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.lblAction)
        Me.Controls.Add(Me.rbCreateSubject)
        Me.Controls.Add(Me.rbModifySubject)
        Me.Controls.Add(Me.rbViewReports)
        Me.Controls.Add(Me.lblVersion)
        Me.Name = "Action"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.lblVersion, 0)
        Me.Controls.SetChildIndex(Me.rbViewReports, 0)
        Me.Controls.SetChildIndex(Me.rbModifySubject, 0)
        Me.Controls.SetChildIndex(Me.rbCreateSubject, 0)
        Me.Controls.SetChildIndex(Me.lblAction, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rbCreateSubject As System.Windows.Forms.RadioButton
    Friend WithEvents rbModifySubject As System.Windows.Forms.RadioButton
    Friend WithEvents rbViewReports As System.Windows.Forms.RadioButton
    Friend WithEvents lblAction As System.Windows.Forms.Label
    Private WithEvents lblVersion As System.Windows.Forms.Label

End Class
