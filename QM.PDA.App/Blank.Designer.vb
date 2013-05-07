<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Blank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Blank))
        Me.lblWait = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblWait
        '
        resources.ApplyResources(Me.lblWait, "lblWait")
        Me.lblWait.ForeColor = System.Drawing.Color.Red
        Me.lblWait.Name = "lblWait"
        '
        'lblVersion
        '
        resources.ApplyResources(Me.lblVersion, "lblVersion")
        Me.lblVersion.ForeColor = System.Drawing.Color.Red
        Me.lblVersion.Name = "lblVersion"
        '
        'Blank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.ControlBox = False
        Me.Controls.Add(Me.lblWait)
        Me.Controls.Add(Me.lblVersion)
        Me.KeyPreview = True
        Me.Name = "Blank"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblWait As System.Windows.Forms.Label
    Private WithEvents lblVersion As System.Windows.Forms.Label
End Class
