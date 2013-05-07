<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GPSReading
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GPSReading))
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.lblTitle = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.PictureBox
        Me.pnlInfo = New System.Windows.Forms.Panel
        Me.lblLatitude = New System.Windows.Forms.Label
        Me.lblLongitude = New System.Windows.Forms.Label
        Me.lblPDOP = New System.Windows.Forms.Label
        Me.lblHDOP = New System.Windows.Forms.Label
        Me.lblSatallites = New System.Windows.Forms.Label
        Me.lblLatitudeValue = New System.Windows.Forms.Label
        Me.lblLongitudeValue = New System.Windows.Forms.Label
        Me.lblPDOPValue = New System.Windows.Forms.Label
        Me.lblHDOPValue = New System.Windows.Forms.Label
        Me.lblSatallitesValue = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.pnlTitle.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        resources.ApplyResources(Me.pnlTitle, "pnlTitle")
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Controls.Add(Me.btnClose)
        Me.pnlTitle.Name = "pnlTitle"
        '
        'lblTitle
        '
        resources.ApplyResources(Me.lblTitle, "lblTitle")
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Name = "lblTitle"
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Name = "btnClose"
        '
        'pnlInfo
        '
        resources.ApplyResources(Me.pnlInfo, "pnlInfo")
        Me.pnlInfo.Controls.Add(Me.lblLatitude)
        Me.pnlInfo.Controls.Add(Me.lblLongitude)
        Me.pnlInfo.Controls.Add(Me.lblPDOP)
        Me.pnlInfo.Controls.Add(Me.lblHDOP)
        Me.pnlInfo.Controls.Add(Me.lblSatallites)
        Me.pnlInfo.Controls.Add(Me.lblLatitudeValue)
        Me.pnlInfo.Controls.Add(Me.lblLongitudeValue)
        Me.pnlInfo.Controls.Add(Me.lblPDOPValue)
        Me.pnlInfo.Controls.Add(Me.lblHDOPValue)
        Me.pnlInfo.Controls.Add(Me.lblSatallitesValue)
        Me.pnlInfo.Name = "pnlInfo"
        '
        'lblLatitude
        '
        resources.ApplyResources(Me.lblLatitude, "lblLatitude")
        Me.lblLatitude.Name = "lblLatitude"
        '
        'lblLongitude
        '
        resources.ApplyResources(Me.lblLongitude, "lblLongitude")
        Me.lblLongitude.Name = "lblLongitude"
        '
        'lblPDOP
        '
        resources.ApplyResources(Me.lblPDOP, "lblPDOP")
        Me.lblPDOP.Name = "lblPDOP"
        '
        'lblHDOP
        '
        resources.ApplyResources(Me.lblHDOP, "lblHDOP")
        Me.lblHDOP.Name = "lblHDOP"
        '
        'lblSatallites
        '
        resources.ApplyResources(Me.lblSatallites, "lblSatallites")
        Me.lblSatallites.Name = "lblSatallites"
        '
        'lblLatitudeValue
        '
        resources.ApplyResources(Me.lblLatitudeValue, "lblLatitudeValue")
        Me.lblLatitudeValue.Name = "lblLatitudeValue"
        '
        'lblLongitudeValue
        '
        resources.ApplyResources(Me.lblLongitudeValue, "lblLongitudeValue")
        Me.lblLongitudeValue.Name = "lblLongitudeValue"
        '
        'lblPDOPValue
        '
        resources.ApplyResources(Me.lblPDOPValue, "lblPDOPValue")
        Me.lblPDOPValue.Name = "lblPDOPValue"
        '
        'lblHDOPValue
        '
        resources.ApplyResources(Me.lblHDOPValue, "lblHDOPValue")
        Me.lblHDOPValue.Name = "lblHDOPValue"
        '
        'lblSatallitesValue
        '
        resources.ApplyResources(Me.lblSatallitesValue, "lblSatallitesValue")
        Me.lblSatallitesValue.Name = "lblSatallitesValue"
        '
        'lblStatus
        '
        resources.ApplyResources(Me.lblStatus, "lblStatus")
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Name = "lblStatus"
        '
        'GPSReading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.lblStatus)
        Me.MinimizeBox = False
        Me.Name = "GPSReading"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.PictureBox
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents lblLatitude As System.Windows.Forms.Label
    Friend WithEvents lblLongitude As System.Windows.Forms.Label
    Friend WithEvents lblPDOP As System.Windows.Forms.Label
    Friend WithEvents lblHDOP As System.Windows.Forms.Label
    Friend WithEvents lblSatallites As System.Windows.Forms.Label
    Friend WithEvents lblLatitudeValue As System.Windows.Forms.Label
    Friend WithEvents lblLongitudeValue As System.Windows.Forms.Label
    Friend WithEvents lblPDOPValue As System.Windows.Forms.Label
    Friend WithEvents lblHDOPValue As System.Windows.Forms.Label
    Friend WithEvents lblSatallitesValue As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label

End Class