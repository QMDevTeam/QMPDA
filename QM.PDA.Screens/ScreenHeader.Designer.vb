<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ScreenHeader
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
        Me.lblTitle = New System.Windows.Forms.Label
        Me.pnlHeader = New System.Windows.Forms.Panel
        Me.lblSubjectID = New System.Windows.Forms.Label
        Me.lblCode = New System.Windows.Forms.Label
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(240, 13)
        Me.lblTitle.Text = "lblTitle"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.SystemColors.Info
        Me.pnlHeader.Controls.Add(Me.lblSubjectID)
        Me.pnlHeader.Location = New System.Drawing.Point(0, 13)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(240, 22)
        '
        'lblSubjectID
        '
        Me.lblSubjectID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSubjectID.ForeColor = System.Drawing.Color.Black
        Me.lblSubjectID.Location = New System.Drawing.Point(0, 3)
        Me.lblSubjectID.Name = "lblSubjectID"
        Me.lblSubjectID.Size = New System.Drawing.Size(1000, 14)
        Me.lblSubjectID.Text = "SubjectID"
        '
        'lblCode
        '
        Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblCode.ForeColor = System.Drawing.Color.Gray
        Me.lblCode.Location = New System.Drawing.Point(0, 35)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(240, 13)
        Me.lblCode.Text = "lblCode"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ScreenHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "ScreenHeader"
        Me.Size = New System.Drawing.Size(240, 48)
        Me.pnlHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents lblTitle As System.Windows.Forms.Label
    Protected WithEvents pnlHeader As System.Windows.Forms.Panel
    Protected WithEvents lblCode As System.Windows.Forms.Label
    Protected WithEvents lblSubjectID As System.Windows.Forms.Label

End Class
