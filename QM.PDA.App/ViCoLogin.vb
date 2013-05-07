Imports QM.PDA.BO.Context


''' <summary>
''' Login screen
''' </summary>

Public Class ViCoLogin

#Region "Properties"

    Private _msbBlankNextMsg As String
    Private _msbValidNextMsg As String
    Private _exit As String

    Private _user As BO.User

#End Region

#Region " Event Handlers "

    Private Sub ViCoLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If CurrentStudy IsNot Nothing Then
            lblStudyName.Text = CurrentStudy.Name
            lblStudyName.Text &= String.Format("{0}({1})", vbCrLf, CurrentStudy.ShortName)
        End If

        cmbCode.DataSource = BO.User.GetAll
        cmbCode.DisplayMember = "PDAUserName"
        cmbCode.ValueMember = "PDAUserName"

        btnBack.Text = Me._exit

    End Sub



    Private Sub ViCoLogin_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Me.InputPanel.Enabled = False
    End Sub



    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        FormResult = FormResult.ExitApplication
        Me.Close()

    End Sub



    Private Sub txtContraseña_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContraseña.GotFocus
        Me.InputPanel.Enabled = True
    End Sub



    Private Sub txtContraseña_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContraseña.LostFocus
        Me.InputPanel.Enabled = False
    End Sub

#End Region

#Region " Public Methods "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(Me.GetType.Namespace & ".Resources", Me.GetType.Assembly)
        Me._msbBlankNextMsg = resources.GetString("vicoLogin_msbBlankNextMsg")
        Me._msbValidNextMsg = resources.GetString("vicoLogin_msbValidNextMsg")
        Me._exit = resources.GetString("vicoLogin_exit")

    End Sub

#End Region

#Region " Protected Methods "

    ''' <summary>
    ''' Checks the username and password
    ''' </summary>
    ''' <returns><c>True</c> if valid, <c>False</c> otherwise.</returns>

    Protected Overrides Function CanGoNext() As Boolean

        Dim code As String = CStr(cmbCode.SelectedValue)
        Dim password As String = txtContraseña.Text

        If code = "" Or password = "" Then
            MsgBox(_msbBlankNextMsg)
            Return False
        Else
            _user = BO.User.Login(code, password)
            If _user Is Nothing Then
                MsgBox(_msbValidNextMsg)
                Return False
            End If
        End If
        Return True

    End Function



    ''' <summary>
    ''' Set the current user
    ''' </summary>

    Protected Overrides Sub GoNext()
        CurrentUser = _user
    End Sub

#End Region

End Class