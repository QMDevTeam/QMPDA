

Namespace Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class Label2
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.lblText = New System.Windows.Forms.Label
            Me.SuspendLayout()
            '
            'lblText
            '
            Me.lblText.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblText.Location = New System.Drawing.Point(0, 0)
            Me.lblText.Name = "lblText"
            Me.lblText.Size = New System.Drawing.Size(100, 20)
            Me.lblText.Text = "Label1"
            '
            'Label2
            '
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
            Me.Controls.Add(Me.lblText)
            Me.Name = "Label2"
            Me.Size = New System.Drawing.Size(100, 20)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lblText As System.Windows.Forms.Label

    End Class

End Namespace