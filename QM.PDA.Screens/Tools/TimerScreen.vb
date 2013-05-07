Public Class TimerScreen


#Region "Properties"

    Private Shared _totalTimer As TimeSpan
    Private Shared _timeLeft As TimeSpan
    Private _lastTick As DateTime
    Private _start As String
    Private _stop As String
    Private _resume As String
#End Region



#Region "Event handlers"

    ''' <summary>
    ''' Call InitForm when the form is loaded.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub Timer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim arr As String() = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\QM", "Timer", TimeSpan.Zero).ToString.Split(":"c)
        _totalTimer = New TimeSpan(CInt(arr(0)), CInt(arr(1)), CInt(arr(2)))

        InitForm()

    End Sub


    ''' <summary>
    ''' Start/Stop button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub btnStartStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartStop.Click

        If Timer1.Enabled Then

            btnStartStop.Text = Me._resume
            btnReset.Enabled = True

        Else

            btnStartStop.Text = Me._stop
            DisableForm()
            Dim sound As New Sound("\QM\beep.wav")
            sound.Play()

        End If

        Timer1.Enabled = Not Timer1.Enabled

    End Sub


    ''' <summary>
    ''' Resets the screen and counters.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        InitForm()

    End Sub


    ''' <summary>
    ''' Calculates time left, refresh the screen.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim currentTick As DateTime = Now
        Dim timePassed As TimeSpan = currentTick.Subtract(_lastTick)

        If _timeLeft > timePassed Then
            _timeLeft = _timeLeft.Subtract(timePassed)
        Else
            _timeLeft = TimeSpan.Zero
        End If

        uxHours.Minimum = _timeLeft.Hours
        uxHours.Maximum = _timeLeft.Hours
        uxHours.Value = _timeLeft.Hours
        uxMinutes.Minimum = _timeLeft.Minutes
        uxMinutes.Maximum = _timeLeft.Minutes
        uxMinutes.Value = _timeLeft.Minutes
        uxSeconds.Minimum = _timeLeft.Seconds
        uxSeconds.Maximum = _timeLeft.Seconds
        uxSeconds.Value = _timeLeft.Seconds

        If _timeLeft = TimeSpan.Zero Then

            Dim sound As New Sound("\QM\alarm.wav")
            sound.Play()
            InitForm()

        End If

        _lastTick = currentTick

    End Sub


    ''' <summary>
    ''' When a parameter of the time changes, updates the timer counters.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub uxTimerPart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        _totalTimer = New TimeSpan(CInt(uxHours.Value), CInt(uxMinutes.Value), CInt(uxSeconds.Value))
        Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\QM", "Timer", _totalTimer.ToString)
        _timeLeft = _totalTimer

    End Sub


    ''' <summary>
    ''' If the timer is enabled, turns on the close flag.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub TimerScreen_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Timer1.Enabled = False

    End Sub

#End Region


#Region " Public Methods "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager("QM.PDA.Screens.Resources", Me.GetType.Assembly)
        Me._start = resources.GetString("timer_start")
        Me._stop = resources.GetString("timer_stop")
        Me._resume = resources.GetString("timer_resume")

    End Sub

#End Region


#Region "Private methods"


    ''' <summary>
    ''' Initalize the controls and counters.
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub InitForm()

        Timer1.Enabled = False
        btnReset.Enabled = True
        btnStartStop.Text = Me._start
        uxHours.ReadOnly = False
        uxHours.Minimum = 0
        uxHours.Maximum = 59
        uxMinutes.ReadOnly = False
        uxMinutes.Minimum = 0
        uxMinutes.Maximum = 59
        uxSeconds.ReadOnly = False
        uxSeconds.Minimum = 0
        uxSeconds.Maximum = 59
        _timeLeft = _totalTimer
        uxHours.Value = _totalTimer.Hours
        uxMinutes.Value = _totalTimer.Minutes
        uxSeconds.Value = _totalTimer.Seconds
        AddHandler uxHours.ValueChanged, AddressOf uxTimerPart_ValueChanged
        AddHandler uxMinutes.ValueChanged, AddressOf uxTimerPart_ValueChanged
        AddHandler uxSeconds.ValueChanged, AddressOf uxTimerPart_ValueChanged

    End Sub


    ''' <summary>
    ''' Disables controls in the screen while the timer is running.
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub DisableForm()

        btnReset.Enabled = False
        _lastTick = Now
        uxHours.ReadOnly = True
        uxMinutes.ReadOnly = True
        uxSeconds.ReadOnly = True
        RemoveHandler uxHours.ValueChanged, AddressOf uxTimerPart_ValueChanged
        RemoveHandler uxMinutes.ValueChanged, AddressOf uxTimerPart_ValueChanged
        RemoveHandler uxSeconds.ValueChanged, AddressOf uxTimerPart_ValueChanged

    End Sub


#End Region

End Class