<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class BaseScreen
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
        Me.ScreenHeader = New QM.PDA.Screens.ScreenHeader
        Me.SuspendLayout()
        '
        'ScreenHeader
        '
        Me.ScreenHeader.Location = New System.Drawing.Point(0, 0)
        Me.ScreenHeader.Name = "ScreenHeader"
        Me.ScreenHeader.Size = New System.Drawing.Size(240, 48)
        Me.ScreenHeader.TabIndex = 5
        '
        'BaseScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.ScreenHeader)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "BaseScreen"
        Me.Text = "BaseScreen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ScreenHeader As ScreenHeader

End Class
