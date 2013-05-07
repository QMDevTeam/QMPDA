<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Site
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Site))
        Me.lblSite = New System.Windows.Forms.Label
        Me.cmbSites = New System.Windows.Forms.ComboBox
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
        'lblSite
        '
        resources.ApplyResources(Me.lblSite, "lblSite")
        Me.lblSite.Name = "lblSite"
        '
        'cmbSites
        '
        resources.ApplyResources(Me.cmbSites, "cmbSites")
        Me.cmbSites.DisplayMember = "Name"
        Me.cmbSites.Name = "cmbSites"
        '
        'Site
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.lblSite)
        Me.Controls.Add(Me.cmbSites)
        Me.Name = "Site"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.cmbSites, 0)
        Me.Controls.SetChildIndex(Me.lblSite, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSite As System.Windows.Forms.Label
    Friend WithEvents cmbSites As System.Windows.Forms.ComboBox

End Class
