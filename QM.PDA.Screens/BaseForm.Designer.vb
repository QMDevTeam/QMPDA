<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class BaseForm
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
    Private MainMenu As System.Windows.Forms.MainMenu
    Private MainContextMenu As System.Windows.Forms.ContextMenu
    Private WithEvents btnMainMenu As System.Windows.Forms.Button

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseForm))
        Me.MainMenu = New System.Windows.Forms.MainMenu
        Me.btnBack = New System.Windows.Forms.MenuItem
        Me.btnNext = New System.Windows.Forms.MenuItem
        Me.mnuGPS = New System.Windows.Forms.MenuItem
        Me.mnuTools = New System.Windows.Forms.MenuItem
        Me.mnuTimer = New System.Windows.Forms.MenuItem
        Me.mnuToolsSeparator = New System.Windows.Forms.MenuItem
        Me.mnuChangeSubject = New System.Windows.Forms.MenuItem
        Me.mnuChangeQuestionnaire = New System.Windows.Forms.MenuItem
        Me.mnuChangeStudy = New System.Windows.Forms.MenuItem
        Me.mnuChangeBlockSeparator = New System.Windows.Forms.MenuItem
        Me.mnuLogout = New System.Windows.Forms.MenuItem
        Me.InputPanel = New Microsoft.WindowsCE.Forms.InputPanel
        Me.btnMainMenu = New System.Windows.Forms.Button
        Me.MainContextMenu = New System.Windows.Forms.ContextMenu
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.Add(Me.btnBack)
        Me.MainMenu.MenuItems.Add(Me.btnNext)
        '
        'btnBack
        '
        resources.ApplyResources(Me.btnBack, "btnBack")
        '
        'btnNext
        '
        resources.ApplyResources(Me.btnNext, "btnNext")
        '
        'mnuGPS
        '
        resources.ApplyResources(Me.mnuGPS, "mnuGPS")
        '
        'mnuTools
        '
        resources.ApplyResources(Me.mnuTools, "mnuTools")
        Me.mnuTools.MenuItems.Add(Me.mnuGPS)
        Me.mnuTools.MenuItems.Add(Me.mnuTimer)
        '
        'mnuTimer
        '
        resources.ApplyResources(Me.mnuTimer, "mnuTimer")
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
        'btnMainMenu
        '
        resources.ApplyResources(Me.btnMainMenu, "btnMainMenu")
        Me.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMainMenu.ForeColor = System.Drawing.Color.White
        Me.btnMainMenu.Name = "btnMainMenu"
        '
        'MainContextMenu
        '
        Me.MainContextMenu.MenuItems.Add(Me.mnuTools)
        Me.MainContextMenu.MenuItems.Add(Me.mnuToolsSeparator)
        Me.MainContextMenu.MenuItems.Add(Me.mnuChangeSubject)
        Me.MainContextMenu.MenuItems.Add(Me.mnuChangeQuestionnaire)
        Me.MainContextMenu.MenuItems.Add(Me.mnuChangeStudy)
        Me.MainContextMenu.MenuItems.Add(Me.mnuChangeBlockSeparator)
        Me.MainContextMenu.MenuItems.Add(Me.mnuLogout)
        '
        'BaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnMainMenu)
        Me.Menu = Me.MainMenu
        Me.MinimizeBox = False
        Me.Name = "BaseForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents btnNext As System.Windows.Forms.MenuItem
    Protected WithEvents btnBack As System.Windows.Forms.MenuItem

    Protected WithEvents mnuGPS As Windows.Forms.MenuItem
    Protected WithEvents mnuTools As Windows.Forms.MenuItem
    Protected WithEvents mnuToolsSeparator As Windows.Forms.MenuItem

    Protected WithEvents mnuChangeSubject As Windows.Forms.MenuItem
    Protected WithEvents mnuChangeQuestionnaire As Windows.Forms.MenuItem
    Protected WithEvents mnuChangeStudy As Windows.Forms.MenuItem
    Protected WithEvents mnuChangeBlockSeparator As Windows.Forms.MenuItem
    Protected WithEvents mnuLogout As System.Windows.Forms.MenuItem
    Protected WithEvents InputPanel As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents mnuTimer As System.Windows.Forms.MenuItem
End Class
