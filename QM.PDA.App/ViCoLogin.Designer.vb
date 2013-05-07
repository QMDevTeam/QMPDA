<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ViCoLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViCoLogin))
        Me.lblOrganizationName = New System.Windows.Forms.Label
        Me.lblProgramName = New System.Windows.Forms.Label
        Me.lblStudyName = New System.Windows.Forms.Label
        Me.lblScreenName = New System.Windows.Forms.Label
        Me.lblScreenDescription = New System.Windows.Forms.Label
        Me.lblCódigo = New System.Windows.Forms.Label
        Me.lblContraseña = New System.Windows.Forms.Label
        Me.cmbCode = New System.Windows.Forms.ComboBox
        Me.txtContraseña = New System.Windows.Forms.TextBox
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
        'lblOrganizationName
        '
        resources.ApplyResources(Me.lblOrganizationName, "lblOrganizationName")
        Me.lblOrganizationName.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblOrganizationName.Name = "lblOrganizationName"
        '
        'lblProgramName
        '
        resources.ApplyResources(Me.lblProgramName, "lblProgramName")
        Me.lblProgramName.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblProgramName.Name = "lblProgramName"
        '
        'lblStudyName
        '
        resources.ApplyResources(Me.lblStudyName, "lblStudyName")
        Me.lblStudyName.Name = "lblStudyName"
        '
        'lblScreenName
        '
        resources.ApplyResources(Me.lblScreenName, "lblScreenName")
        Me.lblScreenName.ForeColor = System.Drawing.Color.Red
        Me.lblScreenName.Name = "lblScreenName"
        '
        'lblScreenDescription
        '
        resources.ApplyResources(Me.lblScreenDescription, "lblScreenDescription")
        Me.lblScreenDescription.Name = "lblScreenDescription"
        '
        'lblCódigo
        '
        resources.ApplyResources(Me.lblCódigo, "lblCódigo")
        Me.lblCódigo.Name = "lblCódigo"
        '
        'lblContraseña
        '
        resources.ApplyResources(Me.lblContraseña, "lblContraseña")
        Me.lblContraseña.Name = "lblContraseña"
        '
        'cmbCode
        '
        resources.ApplyResources(Me.cmbCode, "cmbCode")
        Me.cmbCode.Name = "cmbCode"
        '
        'txtContraseña
        '
        resources.ApplyResources(Me.txtContraseña, "txtContraseña")
        Me.txtContraseña.HideSelection = False
        Me.txtContraseña.Name = "txtContraseña"
        '
        'ViCoLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.cmbCode)
        Me.Controls.Add(Me.lblContraseña)
        Me.Controls.Add(Me.lblCódigo)
        Me.Controls.Add(Me.lblScreenDescription)
        Me.Controls.Add(Me.lblScreenName)
        Me.Controls.Add(Me.lblStudyName)
        Me.Controls.Add(Me.lblProgramName)
        Me.Controls.Add(Me.lblOrganizationName)
        Me.Name = "ViCoLogin"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.lblOrganizationName, 0)
        Me.Controls.SetChildIndex(Me.lblProgramName, 0)
        Me.Controls.SetChildIndex(Me.lblStudyName, 0)
        Me.Controls.SetChildIndex(Me.lblScreenName, 0)
        Me.Controls.SetChildIndex(Me.lblScreenDescription, 0)
        Me.Controls.SetChildIndex(Me.lblCódigo, 0)
        Me.Controls.SetChildIndex(Me.lblContraseña, 0)
        Me.Controls.SetChildIndex(Me.cmbCode, 0)
        Me.Controls.SetChildIndex(Me.txtContraseña, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblOrganizationName As System.Windows.Forms.Label
    Friend WithEvents lblProgramName As System.Windows.Forms.Label
    Friend WithEvents lblStudyName As System.Windows.Forms.Label
    Friend WithEvents lblScreenName As System.Windows.Forms.Label
    Friend WithEvents lblScreenDescription As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents lblContraseña As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
End Class
