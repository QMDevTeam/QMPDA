<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Subject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Subject))
        Me.lblSubject = New System.Windows.Forms.Label
        Me.rbSubjectWithID = New System.Windows.Forms.RadioButton
        Me.rbSubjectWithoutID = New System.Windows.Forms.RadioButton
        Me.cmbSubject = New System.Windows.Forms.ComboBox
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
        'lblSubject
        '
        resources.ApplyResources(Me.lblSubject, "lblSubject")
        Me.lblSubject.Name = "lblSubject"
        '
        'rbSubjectWithID
        '
        resources.ApplyResources(Me.rbSubjectWithID, "rbSubjectWithID")
        Me.rbSubjectWithID.Name = "rbSubjectWithID"
        '
        'rbSubjectWithoutID
        '
        resources.ApplyResources(Me.rbSubjectWithoutID, "rbSubjectWithoutID")
        Me.rbSubjectWithoutID.Name = "rbSubjectWithoutID"
        '
        'cmbSubject
        '
        resources.ApplyResources(Me.cmbSubject, "cmbSubject")
        Me.cmbSubject.Name = "cmbSubject"
        '
        'pnlAnswerArea
        '
        resources.ApplyResources(Me.pnlAnswerArea, "pnlAnswerArea")
        Me.pnlAnswerArea.Name = "pnlAnswerArea"
        '
        'Subject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.rbSubjectWithID)
        Me.Controls.Add(Me.rbSubjectWithoutID)
        Me.Controls.Add(Me.cmbSubject)
        Me.Controls.Add(Me.pnlAnswerArea)
        Me.Name = "Subject"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.pnlAnswerArea, 0)
        Me.Controls.SetChildIndex(Me.cmbSubject, 0)
        Me.Controls.SetChildIndex(Me.rbSubjectWithoutID, 0)
        Me.Controls.SetChildIndex(Me.rbSubjectWithID, 0)
        Me.Controls.SetChildIndex(Me.lblSubject, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents rbSubjectWithID As System.Windows.Forms.RadioButton
    Friend WithEvents rbSubjectWithoutID As System.Windows.Forms.RadioButton
    Friend WithEvents cmbSubject As System.Windows.Forms.ComboBox
    Friend WithEvents pnlAnswerArea As System.Windows.Forms.Panel

End Class
