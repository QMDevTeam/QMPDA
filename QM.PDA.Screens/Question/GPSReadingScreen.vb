Imports Microsoft.WindowsMobile.Samples.Location
Imports QM.PDA.BO.Context


Namespace Question

    ''' <summary>
    ''' Screen to capture a GPS Reading.
    ''' </summary>

    Public Class GPSReadingScreen

#Region " Properties "

        Private Const _GPSDecimalLatitudeVariableNamePostfix As String = "DecLat"      'float
        Private Const _GPSDecimalLongitudeVariableNamePostfix As String = "DecLon"     'float
        Private Const _GPSLatitudeVariableNamePostfix As String = "Lat"                'nvarchar(50)
        Private Const _GPSLongitudeVariableNamePostfix As String = "Lon"               'nvarchar(50)
        Private Const _GPSPDOPVariableNamePostfix As String = "PDOP"                   'float
        Private Const _GPSHDOPVariableNamePostfix As String = "HDOP"                   'float
        Private Const _GPSSatallitesVariableNamePostfix As String = "Sat"              'integer

        Private _invalidReading As String
        Private _moreSatellites As String

        Private _gpsDevice As Gps
        Private _position As GpsPosition
        Private _deviceState As GpsDeviceState
        Private _updateDataHandler As EventHandler

        Private _decimalLatitude As Nullable(Of Double)
        Private _decimalLongitude As Nullable(Of Double)



        Protected Overrides ReadOnly Property HasValue() As Boolean
            Get
                Return True
            End Get
        End Property


        Protected Overrides ReadOnly Property InputValue() As System.IComparable
            Get
                Return String.Empty
            End Get
        End Property


        Protected Overrides ReadOnly Property OriginalValueChanged() As Boolean
            Get
                Return True
            End Get
        End Property


#End Region

#Region " Event Handlers "

        Private Sub SamplePointID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Screen IsNot Nothing Then

                Dim DecLat As String = Screen.VariableName & "DecLat"   'float
                Dim DecLon As String = Screen.VariableName & "DecLon"   'float
                Dim Lat As String = Screen.VariableName & "Lat"         'nvarchar(50)
                Dim Lon As String = Screen.VariableName & "Lon"         'nvarchar(50)
                Dim PDOP As String = Screen.VariableName & "PDOP"       'float
                Dim HDOP As String = Screen.VariableName & "HDOP"       'float
                Dim Sat As String = Screen.VariableName & "Sat"         'integer

                Select Case Screen.VariableScope
                    Case BO.Screen.VariableScopeType.Subject
                        If CurrentSubject(DecLat) Is Nothing Then _decimalLatitude = Nothing Else _decimalLatitude = CDbl(CurrentSubject(DecLat))
                        If CurrentSubject(DecLon) Is Nothing Then _decimalLongitude = Nothing Else _decimalLongitude = CDbl(CurrentSubject(DecLon))
                        lblLatitudeValue.Text = CStr(CurrentSubject(Lat))
                        lblLongitudeValue.Text = CStr(CurrentSubject(Lon))
                        lblPDOPValue.Text = CStr(CurrentSubject(PDOP))
                        lblHDOPValue.Text = CStr(CurrentSubject(HDOP))
                        lblSatallitesValue.Text = CStr(CurrentSubject(Sat))

                    Case BO.Screen.VariableScopeType.Questionnaire
                        If CurrentQuestionnaire(DecLat) Is Nothing Then _decimalLatitude = Nothing Else _decimalLatitude = CDbl(CurrentQuestionnaire(DecLat))
                        If CurrentQuestionnaire(DecLon) Is Nothing Then _decimalLongitude = Nothing Else _decimalLongitude = CDbl(CurrentQuestionnaire(DecLon))
                        lblLatitudeValue.Text = CStr(CurrentQuestionnaire(Lat))
                        lblLongitudeValue.Text = CStr(CurrentQuestionnaire(Lon))
                        lblPDOPValue.Text = CStr(CurrentQuestionnaire(PDOP))
                        lblHDOPValue.Text = CStr(CurrentQuestionnaire(HDOP))
                        lblSatallitesValue.Text = CStr(CurrentQuestionnaire(Sat))

                    Case BO.Screen.VariableScopeType.Section
                        If CurrentSection(DecLat) Is Nothing Then _decimalLatitude = Nothing Else _decimalLatitude = CDbl(CurrentSection(DecLat))
                        If CurrentSection(DecLon) Is Nothing Then _decimalLongitude = Nothing Else _decimalLongitude = CDbl(CurrentSection(DecLon))
                        lblLatitudeValue.Text = CStr(CurrentSection(Lat))
                        lblLongitudeValue.Text = CStr(CurrentSection(Lon))
                        lblPDOPValue.Text = CStr(CurrentSection(PDOP))
                        lblHDOPValue.Text = CStr(CurrentSection(HDOP))
                        lblSatallitesValue.Text = CStr(CurrentSection(Sat))

                End Select

            End If

        End Sub



        Private Sub SamplePointID_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

            If _gpsDevice IsNot Nothing Then
                RemoveHandler _gpsDevice.DeviceStateChanged, AddressOf _gpsDevice_DeviceStateChanged
                RemoveHandler _gpsDevice.LocationChanged, AddressOf _gpsDevice_LocationChanged

                _gpsDevice.Close()
                _gpsDevice = Nothing
            End If

        End Sub



        Private Sub btnTakeReading_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTakeReading.Click

            _gpsDevice = New Gps()

            AddHandler _gpsDevice.DeviceStateChanged, AddressOf _gpsDevice_DeviceStateChanged
            AddHandler _gpsDevice.LocationChanged, AddressOf _gpsDevice_LocationChanged
            _updateDataHandler = New EventHandler(AddressOf UpdateData)
            _gpsDevice.Open()

            btnTakeReading.Hide()
            lblStatus.Show()

        End Sub



        Private Sub _gpsDevice_DeviceStateChanged(ByVal sender As Object, ByVal args As DeviceStateChangedEventArgs)
            _deviceState = args.DeviceState
            Invoke(_updateDataHandler)
        End Sub



        Private Sub _gpsDevice_LocationChanged(ByVal sender As Object, ByVal args As LocationChangedEventArgs)
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

#Region " Protected Methods "

        Protected Overrides Sub StoreValue()

            Dim DecLat As String = Screen.VariableName & "DecLat"   'float
            Dim DecLon As String = Screen.VariableName & "DecLon"   'float
            Dim Lat As String = Screen.VariableName & "Lat"         'nvarchar(50)
            Dim Lon As String = Screen.VariableName & "Lon"         'nvarchar(50)
            Dim PDOP As String = Screen.VariableName & "PDOP"       'float
            Dim HDOP As String = Screen.VariableName & "HDOP"       'float
            Dim Sat As String = Screen.VariableName & "Sat"         'integer

            Select Case Screen.VariableScope
                Case BO.Screen.VariableScopeType.Subject
                    If _decimalLatitude.HasValue Then CurrentSubject(DecLat) = _decimalLatitude Else CurrentSubject(DecLat) = Nothing
                    If _decimalLongitude.HasValue Then CurrentSubject(DecLon) = _decimalLongitude Else CurrentSubject(DecLon) = Nothing
                    CurrentSubject(Lat) = lblLatitudeValue.Text
                    CurrentSubject(Lon) = lblLongitudeValue.Text
                    If String.IsNullOrEmpty(lblPDOPValue.Text) Then CurrentSubject(PDOP) = Nothing Else CurrentSubject(PDOP) = Double.Parse(lblPDOPValue.Text)
                    If String.IsNullOrEmpty(lblHDOPValue.Text) Then CurrentSubject(HDOP) = Nothing Else CurrentSubject(HDOP) = Double.Parse(lblHDOPValue.Text)
                    If String.IsNullOrEmpty(lblSatallitesValue.Text) Then CurrentSubject(Sat) = Nothing Else CurrentSubject(Sat) = Integer.Parse(lblSatallitesValue.Text)

                Case BO.Screen.VariableScopeType.Questionnaire
                    If _decimalLatitude.HasValue Then CurrentQuestionnaire(DecLat) = _decimalLatitude Else CurrentQuestionnaire(DecLat) = Nothing
                    If _decimalLongitude.HasValue Then CurrentQuestionnaire(DecLon) = _decimalLongitude Else CurrentQuestionnaire(DecLon) = Nothing
                    CurrentQuestionnaire(Lat) = lblLatitudeValue.Text
                    CurrentQuestionnaire(Lon) = lblLongitudeValue.Text
                    If String.IsNullOrEmpty(lblPDOPValue.Text) Then CurrentQuestionnaire(PDOP) = Nothing Else CurrentQuestionnaire(PDOP) = Double.Parse(lblPDOPValue.Text)
                    If String.IsNullOrEmpty(lblHDOPValue.Text) Then CurrentQuestionnaire(HDOP) = Nothing Else CurrentQuestionnaire(HDOP) = Double.Parse(lblHDOPValue.Text)
                    If String.IsNullOrEmpty(lblSatallitesValue.Text) Then CurrentQuestionnaire(Sat) = Nothing Else CurrentQuestionnaire(Sat) = Integer.Parse(lblSatallitesValue.Text)

                Case BO.Screen.VariableScopeType.Section
                    If _decimalLatitude.HasValue Then CurrentSection(DecLat) = _decimalLatitude Else CurrentSection(DecLat) = Nothing
                    If _decimalLongitude.HasValue Then CurrentSection(DecLon) = _decimalLongitude Else CurrentSection(DecLon) = Nothing
                    CurrentSection(Lat) = lblLatitudeValue.Text
                    CurrentSection(Lon) = lblLongitudeValue.Text
                    If String.IsNullOrEmpty(lblPDOPValue.Text) Then CurrentSection(PDOP) = Nothing Else CurrentSection(PDOP) = Double.Parse(lblPDOPValue.Text)
                    If String.IsNullOrEmpty(lblHDOPValue.Text) Then CurrentSection(HDOP) = Nothing Else CurrentSection(HDOP) = Double.Parse(lblHDOPValue.Text)
                    If String.IsNullOrEmpty(lblSatallitesValue.Text) Then CurrentSection(Sat) = Nothing Else CurrentSection(Sat) = Integer.Parse(lblSatallitesValue.Text)

            End Select

        End Sub

#End Region

#Region " Private Methods "

        Private Sub UpdateData(ByVal sender As Object, ByVal args As System.EventArgs)

            If _deviceState IsNot Nothing Then

                If _deviceState.DeviceState <> GpsServiceState.On Then
                    lblStatus.Text = _deviceState.DeviceState.ToString
                Else
                    lblStatus.Text = String.Empty
                End If

            End If


            If _position IsNot Nothing Then

                If _position.LatitudeValid Then _decimalLatitude = _position.Latitude Else _decimalLatitude = Nothing
                If _position.LongitudeValid Then _decimalLongitude = _position.Longitude Else _decimalLongitude = Nothing
                If _position.LatitudeValid Then lblLatitudeValue.Text = _position.LatitudeInDegreesMinutesSeconds.ToString Else lblLatitudeValue.Text = String.Empty
                If _position.LongitudeValid Then lblLongitudeValue.Text = _position.LongitudeInDegreesMinutesSeconds.ToString Else lblLongitudeValue.Text = String.Empty
                If _position.PositionDilutionOfPrecisionValid Then lblPDOPValue.Text = _position.PositionDilutionOfPrecision.ToString Else lblPDOPValue.Text = String.Empty
                If _position.HorizontalDilutionOfPrecisionValid Then lblHDOPValue.Text = _position.HorizontalDilutionOfPrecision.ToString Else lblHDOPValue.Text = String.Empty
                If _position.SatelliteCountValid Then lblSatallitesValue.Text = _position.SatelliteCount.ToString Else lblSatallitesValue.Text = String.Empty

                If Not _position.LatitudeValid AndAlso String.IsNullOrEmpty(lblStatus.Text) Then
                    lblStatus.Text = Me._invalidReading

                ElseIf _position.SatelliteCountValid AndAlso _position.SatelliteCount = 0 Then
                    lblStatus.Text = Me._moreSatellites

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace
