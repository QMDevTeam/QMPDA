

Namespace Info

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class SimpleInfoScreen
        Inherits BaseScreen

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
            Me.lblMessage = New System.Windows.Forms.Label
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'mnuChangeStudy
            '
            Me.mnuChangeStudy.Enabled = False
            '
            'lblMessage
            '
            Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblMessage.Location = New System.Drawing.Point(0, 0)
            Me.lblMessage.Name = "lblMessage"
            Me.lblMessage.Size = New System.Drawing.Size(185, 237)
            Me.lblMessage.Text = "lblMessage"
            '
            'Panel1
            '
            Me.Panel1.AutoScroll = True
            Me.Panel1.Controls.Add(Me.lblMessage)
            Me.Panel1.Location = New System.Drawing.Point(20, 54)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(220, 240)
            '
            'SimpleInfoScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = False
            Me.ClientSize = New System.Drawing.Size(240, 294)
            Me.Controls.Add(Me.Panel1)
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "SimpleInfoScreen"
            Me.Text = "SimpleInfoScreen"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lblMessage As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel

    End Class

End Namespace
