<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class CorrectDateTime
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CorrectDateTime))
        Me.lblIncorrectDateTimeMessage = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblCurrentDateTime = New System.Windows.Forms.Label
        Me.btnCorrectDateTime = New System.Windows.Forms.Button
        Me.btnDateTimeOK = New System.Windows.Forms.Button
        Me.lblLastBackupDateTime = New System.Windows.Forms.Label
        Me.pnlOverride = New System.Windows.Forms.Panel
        Me.btnOverrideContinue = New System.Windows.Forms.Button
        Me.txtOverrideCode = New System.Windows.Forms.TextBox
        Me.lblOverrideCode = New System.Windows.Forms.Label
        Me.lblOverrideNote = New System.Windows.Forms.Label
        Me.MainMenu = New System.Windows.Forms.MainMenu
        Me.Timer = New System.Windows.Forms.Timer
        Me.pnlOverride.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblIncorrectDateTimeMessage
        '
        resources.ApplyResources(Me.lblIncorrectDateTimeMessage, "lblIncorrectDateTimeMessage")
        Me.lblIncorrectDateTimeMessage.ForeColor = System.Drawing.Color.Red
        Me.lblIncorrectDateTimeMessage.Name = "lblIncorrectDateTimeMessage"
        '
        'lblVersion
        '
        resources.ApplyResources(Me.lblVersion, "lblVersion")
        Me.lblVersion.ForeColor = System.Drawing.Color.Red
        Me.lblVersion.Name = "lblVersion"
        '
        'lblCurrentDateTime
        '
        resources.ApplyResources(Me.lblCurrentDateTime, "lblCurrentDateTime")
        Me.lblCurrentDateTime.ForeColor = System.Drawing.Color.Blue
        Me.lblCurrentDateTime.Name = "lblCurrentDateTime"
        '
        'btnCorrectDateTime
        '
        resources.ApplyResources(Me.btnCorrectDateTime, "btnCorrectDateTime")
        Me.btnCorrectDateTime.Name = "btnCorrectDateTime"
        '
        'btnDateTimeOK
        '
        resources.ApplyResources(Me.btnDateTimeOK, "btnDateTimeOK")
        Me.btnDateTimeOK.Name = "btnDateTimeOK"
        '
        'lblLastBackupDateTime
        '
        resources.ApplyResources(Me.lblLastBackupDateTime, "lblLastBackupDateTime")
        Me.lblLastBackupDateTime.ForeColor = System.Drawing.Color.Red
        Me.lblLastBackupDateTime.Name = "lblLastBackupDateTime"
        '
        'pnlOverride
        '
        resources.ApplyResources(Me.pnlOverride, "pnlOverride")
        Me.pnlOverride.BackColor = System.Drawing.Color.Navy
        Me.pnlOverride.Controls.Add(Me.btnOverrideContinue)
        Me.pnlOverride.Controls.Add(Me.txtOverrideCode)
        Me.pnlOverride.Controls.Add(Me.lblOverrideCode)
        Me.pnlOverride.Controls.Add(Me.lblOverrideNote)
        Me.pnlOverride.Name = "pnlOverride"
        '
        'btnOverrideContinue
        '
        resources.ApplyResources(Me.btnOverrideContinue, "btnOverrideContinue")
        Me.btnOverrideContinue.Name = "btnOverrideContinue"
        '
        'txtOverrideCode
        '
        resources.ApplyResources(Me.txtOverrideCode, "txtOverrideCode")
        Me.txtOverrideCode.Name = "txtOverrideCode"
        '
        'lblOverrideCode
        '
        resources.ApplyResources(Me.lblOverrideCode, "lblOverrideCode")
        Me.lblOverrideCode.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblOverrideCode.Name = "lblOverrideCode"
        '
        'lblOverrideNote
        '
        resources.ApplyResources(Me.lblOverrideNote, "lblOverrideNote")
        Me.lblOverrideNote.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblOverrideNote.Name = "lblOverrideNote"
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 60000
        '
        'CorrectDateTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.ControlBox = False
        Me.Controls.Add(Me.lblLastBackupDateTime)
        Me.Controls.Add(Me.btnDateTimeOK)
        Me.Controls.Add(Me.btnCorrectDateTime)
        Me.Controls.Add(Me.lblCurrentDateTime)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblIncorrectDateTimeMessage)
        Me.Controls.Add(Me.pnlOverride)
        Me.Menu = Me.MainMenu
        Me.Name = "CorrectDateTime"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlOverride.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblIncorrectDateTimeMessage As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblCurrentDateTime As System.Windows.Forms.Label
    Friend WithEvents btnCorrectDateTime As System.Windows.Forms.Button
    Friend WithEvents btnDateTimeOK As System.Windows.Forms.Button
    Friend WithEvents lblLastBackupDateTime As System.Windows.Forms.Label
    Friend WithEvents pnlOverride As System.Windows.Forms.Panel
    Friend WithEvents lblOverrideNote As System.Windows.Forms.Label
    Friend WithEvents lblOverrideCode As System.Windows.Forms.Label
    Friend WithEvents txtOverrideCode As System.Windows.Forms.TextBox
    Friend WithEvents btnOverrideContinue As System.Windows.Forms.Button
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents Timer As System.Windows.Forms.Timer
End Class
