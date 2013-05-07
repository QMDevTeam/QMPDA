

Namespace Question

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DateTimeScreen
        Inherits PDA.Screens.Question.QuestionScreen

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DateTimeScreen))
            Me.dtpDateTime = New OpenNETCF.Windows.Forms.DateTimePicker2
            Me.pnlDateTime = New System.Windows.Forms.Panel
            Me.pbxClear = New System.Windows.Forms.PictureBox
            Me.lblBtn7 = New System.Windows.Forms.Label
            Me.lblBtn8 = New System.Windows.Forms.Label
            Me.lblBtn9 = New System.Windows.Forms.Label
            Me.lblBtn4 = New System.Windows.Forms.Label
            Me.lblBtn5 = New System.Windows.Forms.Label
            Me.lblBtn6 = New System.Windows.Forms.Label
            Me.lblBtn1 = New System.Windows.Forms.Label
            Me.lblBtn2 = New System.Windows.Forms.Label
            Me.lblBtn3 = New System.Windows.Forms.Label
            Me.lblBtn0 = New System.Windows.Forms.Label
            Me.pnlAnswerArea.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlAnswerArea
            '
            Me.pnlAnswerArea.Controls.Add(Me.lblBtn0)
            Me.pnlAnswerArea.Controls.Add(Me.lblBtn3)
            Me.pnlAnswerArea.Controls.Add(Me.lblBtn6)
            Me.pnlAnswerArea.Controls.Add(Me.lblBtn9)
            Me.pnlAnswerArea.Controls.Add(Me.lblBtn2)
            Me.pnlAnswerArea.Controls.Add(Me.lblBtn5)
            Me.pnlAnswerArea.Controls.Add(Me.lblBtn8)
            Me.pnlAnswerArea.Controls.Add(Me.lblBtn1)
            Me.pnlAnswerArea.Controls.Add(Me.lblBtn4)
            Me.pnlAnswerArea.Controls.Add(Me.lblBtn7)
            Me.pnlAnswerArea.Controls.Add(Me.pnlDateTime)
            Me.pnlAnswerArea.Controls.Add(Me.dtpDateTime)
            Me.pnlAnswerArea.Controls.Add(Me.pbxClear)
            '
            'btnHelp
            '
            Me.btnHelp.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
            '
            'mnuChangeStudy
            '
            Me.mnuChangeStudy.Enabled = False
            '
            'dtpDateTime
            '
            Me.dtpDateTime.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
            Me.dtpDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
            Me.dtpDateTime.Location = New System.Drawing.Point(0, 0)
            Me.dtpDateTime.Name = "dtpDateTime"
            Me.dtpDateTime.Size = New System.Drawing.Size(194, 26)
            Me.dtpDateTime.TabIndex = 0
            '
            'pnlDateTime
            '
            Me.pnlDateTime.Location = New System.Drawing.Point(1, 1)
            Me.pnlDateTime.Name = "pnlDateTime"
            Me.pnlDateTime.Size = New System.Drawing.Size(178, 24)
            '
            'pbxClear
            '
            Me.pbxClear.BackColor = System.Drawing.SystemColors.Control
            Me.pbxClear.Image = CType(resources.GetObject("pbxClear.Image"), System.Drawing.Image)
            Me.pbxClear.Location = New System.Drawing.Point(193, 0)
            Me.pbxClear.Name = "pbxClear"
            Me.pbxClear.Size = New System.Drawing.Size(26, 26)
            Me.pbxClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            '
            'lblBtn7
            '
            Me.lblBtn7.BackColor = System.Drawing.SystemColors.Control
            Me.lblBtn7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBtn7.Location = New System.Drawing.Point(58, 28)
            Me.lblBtn7.Name = "lblBtn7"
            Me.lblBtn7.Size = New System.Drawing.Size(30, 20)
            Me.lblBtn7.Text = "7"
            Me.lblBtn7.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblBtn8
            '
            Me.lblBtn8.BackColor = System.Drawing.SystemColors.Control
            Me.lblBtn8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBtn8.Location = New System.Drawing.Point(90, 28)
            Me.lblBtn8.Name = "lblBtn8"
            Me.lblBtn8.Size = New System.Drawing.Size(30, 20)
            Me.lblBtn8.Text = "8"
            Me.lblBtn8.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblBtn9
            '
            Me.lblBtn9.BackColor = System.Drawing.SystemColors.Control
            Me.lblBtn9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBtn9.Location = New System.Drawing.Point(122, 28)
            Me.lblBtn9.Name = "lblBtn9"
            Me.lblBtn9.Size = New System.Drawing.Size(30, 20)
            Me.lblBtn9.Text = "9"
            Me.lblBtn9.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblBtn4
            '
            Me.lblBtn4.BackColor = System.Drawing.SystemColors.Control
            Me.lblBtn4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBtn4.Location = New System.Drawing.Point(58, 50)
            Me.lblBtn4.Name = "lblBtn4"
            Me.lblBtn4.Size = New System.Drawing.Size(30, 20)
            Me.lblBtn4.Text = "4"
            Me.lblBtn4.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblBtn5
            '
            Me.lblBtn5.BackColor = System.Drawing.SystemColors.Control
            Me.lblBtn5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBtn5.Location = New System.Drawing.Point(90, 50)
            Me.lblBtn5.Name = "lblBtn5"
            Me.lblBtn5.Size = New System.Drawing.Size(30, 20)
            Me.lblBtn5.Text = "5"
            Me.lblBtn5.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblBtn6
            '
            Me.lblBtn6.BackColor = System.Drawing.SystemColors.Control
            Me.lblBtn6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBtn6.Location = New System.Drawing.Point(122, 50)
            Me.lblBtn6.Name = "lblBtn6"
            Me.lblBtn6.Size = New System.Drawing.Size(30, 20)
            Me.lblBtn6.Text = "6"
            Me.lblBtn6.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblBtn1
            '
            Me.lblBtn1.BackColor = System.Drawing.SystemColors.Control
            Me.lblBtn1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBtn1.Location = New System.Drawing.Point(58, 72)
            Me.lblBtn1.Name = "lblBtn1"
            Me.lblBtn1.Size = New System.Drawing.Size(30, 20)
            Me.lblBtn1.Text = "1"
            Me.lblBtn1.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblBtn2
            '
            Me.lblBtn2.BackColor = System.Drawing.SystemColors.Control
            Me.lblBtn2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBtn2.Location = New System.Drawing.Point(90, 72)
            Me.lblBtn2.Name = "lblBtn2"
            Me.lblBtn2.Size = New System.Drawing.Size(30, 20)
            Me.lblBtn2.Text = "2"
            Me.lblBtn2.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblBtn3
            '
            Me.lblBtn3.BackColor = System.Drawing.SystemColors.Control
            Me.lblBtn3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBtn3.Location = New System.Drawing.Point(122, 72)
            Me.lblBtn3.Name = "lblBtn3"
            Me.lblBtn3.Size = New System.Drawing.Size(30, 20)
            Me.lblBtn3.Text = "3"
            Me.lblBtn3.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblBtn0
            '
            Me.lblBtn0.BackColor = System.Drawing.SystemColors.Control
            Me.lblBtn0.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblBtn0.Location = New System.Drawing.Point(90, 94)
            Me.lblBtn0.Name = "lblBtn0"
            Me.lblBtn0.Size = New System.Drawing.Size(30, 20)
            Me.lblBtn0.Text = "0"
            Me.lblBtn0.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'DateTimeScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(240, 294)
            Me.KeyPreview = True
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "DateTimeScreen"
            Me.Text = "DateTimeScreen"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.pnlAnswerArea.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lblBtn7 As System.Windows.Forms.Label
        Friend WithEvents lblBtn0 As System.Windows.Forms.Label
        Friend WithEvents lblBtn3 As System.Windows.Forms.Label
        Friend WithEvents lblBtn6 As System.Windows.Forms.Label
        Friend WithEvents lblBtn9 As System.Windows.Forms.Label
        Friend WithEvents lblBtn2 As System.Windows.Forms.Label
        Friend WithEvents lblBtn5 As System.Windows.Forms.Label
        Friend WithEvents lblBtn8 As System.Windows.Forms.Label
        Friend WithEvents lblBtn1 As System.Windows.Forms.Label
        Friend WithEvents lblBtn4 As System.Windows.Forms.Label
        Protected WithEvents dtpDateTime As OpenNETCF.Windows.Forms.DateTimePicker2
        Protected WithEvents pnlDateTime As System.Windows.Forms.Panel
        Protected WithEvents pbxClear As System.Windows.Forms.PictureBox

    End Class

End Namespace