Imports Microsoft.WindowsMobile.Samples.Location


''' <summary>
''' Screen to capture a GPS Reading.
''' </summary>

Public Class GPSReading

#Region " Properties "

    Private WithEvents _gpsDevice As New Gps
    Private _position As GpsPosition
    Private _deviceState As GpsDeviceState
    Private _updateDataHandler As EventHandler
    Private _invalidReading As String
    Private _moreSatellites As String

#End Region

#Region " Event Handlers "

    Private Sub SamplePointID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _gpsDevice.Open()
        _updateDataHandler = New EventHandler(AddressOf UpdateData)
        lblStatus.Show()

    End Sub



    Private Sub SamplePointID_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        _gpsDevice.Close()
    End Sub



    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub



    Private Sub _gpsDevice_DeviceStateChanged(ByVal sender As Object, ByVal args As DeviceStateChangedEventArgs) Handles _gpsDevice.DeviceStateChanged
        _deviceState = args.DeviceState
        Invoke(_updateDataHandler)
    End Sub



    Private Sub _gpsDevice_LocationChanged(ByVal sender As Object, ByVal args As LocationChangedEventArgs) Handles _gpsDevice.LocationChanged
        _position = args.Position
        Invoke(_updateDataHandler)
    End Sub

#End Region

#Region " Public Methods "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager("QM.PDA.Screens.Resources", Me.GetType.Assembly)
        Me._invalidReading = resources.GetString("gps_invalidReading")
        Me._moreSatellites = resources.GetString("gps_moreSatellites")

    End Sub

#End Region


#Region " Private Methods "

    Private Sub UpdateData(ByVal sender As Object, ByVal args As System.EventArgs)

        If _deviceState IsNot Nothing Then

            If _deviceState.DeviceState <> GpsServiceState.On Then
                lblStatus.Text = _deviceState.DeviceState.ToString
            Else
                lblStatus.Text = ""
            End If

        End If


        If _position IsNot Nothing Then

            If _position.LatitudeValid Then lblLatitudeValue.Text = _position.LatitudeInDegreesMinutesSeconds.ToString Else lblLatitudeValue.Text = ""
            If _position.LongitudeValid Then lblLongitudeValue.Text = _position.LongitudeInDegreesMinutesSeconds.ToString Else lblLongitudeValue.Text = ""
            If _position.PositionDilutionOfPrecisionValid Then lblPDOPValue.Text = _position.PositionDilutionOfPrecision.ToString Else lblPDOPValue.Text = ""
            If _position.HorizontalDilutionOfPrecisionValid Then lblHDOPValue.Text = _position.HorizontalDilutionOfPrecision.ToString Else lblHDOPValue.Text = ""
            If _position.SatelliteCountValid Then lblSatallitesValue.Text = _position.SatelliteCount.ToString Else lblSatallitesValue.Text = ""

            If Not _position.LatitudeValid AndAlso String.IsNullOrEmpty(lblStatus.Text) Then
                lblStatus.Text = Me._invalidReading

            ElseIf _position.SatelliteCountValid AndAlso _position.SatelliteCount = 0 Then
                lblStatus.Text = Me._moreSatellites

            End If

        End If

    End Sub

#End Region

End Class
