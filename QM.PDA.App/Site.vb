Imports QM.PDA.BO.Context


''' <summary>
''' Screen to select the Site where the User will work.
''' </summary>

Public Class Site

#Region " Properties "

    Private Const _radioButtonSeparation As Integer = 28
    Private Const _radioButtonwidth As Integer = 211
    Private _radioButtonFont As Drawing.Font = New Drawing.Font("Tahoma", 10, Drawing.FontStyle.Regular)

    Private _selectedValue As BO.Site
    Private _radioButtons As New List(Of RadioButton)

    Private _msbRequiredCap As String
    Private _msbRequiredMsg As String
    Private _noSites As String


    Public sites As List(Of BO.Site)

#End Region

#Region " Event Handlers "

    Private Sub Site_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' If there is already a Current Site, set it as the selected value.
        If CurrentSite IsNot Nothing Then
            _selectedValue = CurrentSite

        Else ' Else set the User's default site as the selected value.
            _selectedValue = CurrentUser.DefaultSite

        End If



        ' If there are no sites, show the user a message.
        If sites.Count = 0 Then lblSite.Text = Me._noSites

        ' Add each Site to the DropDownList
        For idx As Integer = 0 To sites.Count - 1
            cmbSites.Items.Add(sites(idx))
            If _selectedValue = sites(idx) Then cmbSites.SelectedIndex = idx
        Next

    End Sub



    Private Sub cmbSites_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSites.SelectedIndexChanged
        _selectedValue = CType(cmbSites.SelectedItem, BO.Site)
    End Sub

#End Region

#Region " Public Methods "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(Me.GetType.Namespace & ".Resources", Me.GetType.Assembly)
        Me._msbRequiredCap = resources.GetString("site_msbRequiredCap")
        Me._msbRequiredMsg = resources.GetString("site_msbRequiredMsg")
        Me._noSites = resources.GetString("site_noSites")

    End Sub

#End Region

#Region " Protected Methods "

    ''' <summary>
    ''' Check if it is possible to go to the next screen.
    ''' </summary>
    ''' <returns><c>True</c> if it is possible or <c>False</c> otherwise.</returns>

    Protected Overrides Function CanGoNext() As Boolean
        Return Validate()
    End Function



    ''' <summary>
    ''' Stores the value before going to the next screen.
    ''' </summary>

    Protected Overrides Sub GoNext()
        StoreValue()
    End Sub



    ''' <summary>
    ''' Stores the value before going to the previous screen.
    ''' </summary>

    Protected Overrides Sub GoBack()
        StoreValue()
    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Stores the selected site.
    ''' </summary>

    Private Sub StoreValue()

        ' If there is a Current Site and the user selected exactly the same, do nothing
        If CurrentSite IsNot Nothing AndAlso _selectedValue = CurrentSite Then Return

        ' If the user selected a Site then set it as the Current Site, else set Current Site as Null.
        If _selectedValue IsNot Nothing Then CurrentSite = _selectedValue Else CurrentSite = Nothing

    End Sub



    ''' <summary>
    ''' Checks if there is a selected site.
    ''' </summary>
    ''' <returns><c>True</c> if there's a selected site, <c>False</c> otherwise.</returns>

    Private Function Validate() As Boolean

        If _selectedValue Is Nothing Then
            MessageBox.Show(_msbRequiredMsg, _msbRequiredCap)
            Return False
        End If

        Return True

    End Function

#End Region

End Class