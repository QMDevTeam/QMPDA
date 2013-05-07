<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class TimerScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimerScreen))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.uxMinutes = New System.Windows.Forms.NumericUpDown
        Me.uxHours = New System.Windows.Forms.NumericUpDown
        Me.uxSeconds = New System.Windows.Forms.NumericUpDown
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.btnStartStop = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.SuspendLayout()
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'uxMinutes
        '
        resources.ApplyResources(Me.uxMinutes, "uxMinutes")
        Me.uxMinutes.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.uxMinutes.Name = "uxMinutes"
        Me.uxMinutes.Value = New Decimal(New Integer() {59, 0, 0, 0})
        '
        'uxHours
        '
        resources.ApplyResources(Me.uxHours, "uxHours")
        Me.uxHours.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.uxHours.Name = "uxHours"
        Me.uxHours.Value = New Decimal(New Integer() {59, 0, 0, 0})
        '
        'uxSeconds
        '
        resources.ApplyResources(Me.uxSeconds, "uxSeconds")
        Me.uxSeconds.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.uxSeconds.Name = "uxSeconds"
        Me.uxSeconds.Value = New Decimal(New Integer() {59, 0, 0, 0})
        '
        'Timer1
        '
        '
        'btnStartStop
        '
        resources.ApplyResources(Me.btnStartStop, "btnStartStop")
        Me.btnStartStop.Name = "btnStartStop"
        '
        'btnReset
        '
        resources.ApplyResources(Me.btnReset, "btnReset")
        Me.btnReset.Name = "btnReset"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'TimerScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnStartStop)
        Me.Controls.Add(Me.uxSeconds)
        Me.Controls.Add(Me.uxHours)
        Me.Controls.Add(Me.uxMinutes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.KeyPreview = True
        Me.Menu = Me.mainMenu1
        Me.Name = "TimerScreen"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents uxMinutes As System.Windows.Forms.NumericUpDown
    Friend WithEvents uxHours As System.Windows.Forms.NumericUpDown
    Friend WithEvents uxSeconds As System.Windows.Forms.NumericUpDown
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnStartStop As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents mainMenu1 As System.Windows.Forms.MainMenu
End Class
