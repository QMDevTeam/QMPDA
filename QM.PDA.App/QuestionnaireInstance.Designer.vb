<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuestionnaireInstance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QuestionnaireInstance))
        Me.ScreenHeader = New QM.PDA.Screens.ScreenHeader
        Me.btnVerify = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.pnlAnswerArea = New System.Windows.Forms.Panel
        Me.pnlAnswerArea.SuspendLayout()
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
        'btnVerify
        '
        resources.ApplyResources(Me.btnVerify, "btnVerify")
        Me.btnVerify.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnVerify.ForeColor = System.Drawing.Color.White
        Me.btnVerify.Name = "btnVerify"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.BackColor = System.Drawing.Color.LawnGreen
        Me.btnAdd.Name = "btnAdd"
        '
        'pnlAnswerArea
        '
        resources.ApplyResources(Me.pnlAnswerArea, "pnlAnswerArea")
        Me.pnlAnswerArea.Controls.Add(Me.btnVerify)
        Me.pnlAnswerArea.Controls.Add(Me.btnAdd)
        Me.pnlAnswerArea.Name = "pnlAnswerArea"
        '
        'QuestionnaireInstance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.ScreenHeader)
        Me.Controls.Add(Me.pnlAnswerArea)
        Me.Name = "QuestionnaireInstance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.pnlAnswerArea, 0)
        Me.Controls.SetChildIndex(Me.ScreenHeader, 0)
        Me.pnlAnswerArea.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ScreenHeader As Screens.ScreenHeader
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents pnlAnswerArea As System.Windows.Forms.Panel

End Class
