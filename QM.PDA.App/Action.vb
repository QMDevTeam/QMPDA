Imports QM.PDA.BO.Context


''' <summary>
''' Screen to select the Action that the User wants to perform.
''' </summary>

Public Class Action

#Region " Properties "

    Private _msbRequiredCap As String
    Private _msbRequiredMsg As String

    Private _selectedValue As Nullable(Of UserAction)

#End Region

#Region " Event Handlers "

    Private Sub rbCreateSubject_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCreateSubject.CheckedChanged
        _selectedValue = UserAction.CreateSubject
    End Sub



    Private Sub rbModifySubject_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbModifySubject.CheckedChanged
        _selectedValue = UserAction.ModifySubject
    End Sub



    Private Sub rbViewReports_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbViewReports.CheckedChanged
        _selectedValue = UserAction.ViewReport
    End Sub

#End Region

#Region " Public Methods "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Get the version of the Current Study
        lblVersion.Text = CurrentStudy.Version

        ' Decide wether to show the 'Ver REPORTES' option
        rbViewReports.Visible = CurrentStudy.Reports(CurrentSite.Code).Count > 0

        ' Get the messages in the current language.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(Me.GetType.Namespace & ".Resources", Me.GetType.Assembly)
        Me._msbRequiredCap = resources.GetString("action_msbRequiredCap")
        Me._msbRequiredMsg = resources.GetString("action_msbRequiredMsg")

    End Sub

#End Region

#Region " Protected Methods "

    ''' <summary>
    ''' Check if it is possible to go to the next screen.
    ''' </summary>
    ''' <returns><c>True</c> if it is possible, <c>False</c> otherwise.</returns>

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
    ''' Store the selected action.
    ''' </summary>

    Private Sub StoreValue()
        CurrentAction = _selectedValue
    End Sub



    ''' <summary>
    ''' Checks if there is a selected action.
    ''' </summary>
    ''' <returns><c>True</c> if there's a selected action, <c>False</c> otherwise.</returns>

    Private Function Validate() As Boolean

        If Not rbCreateSubject.Checked AndAlso Not rbModifySubject.Checked AndAlso Not rbViewReports.Checked Then
            MessageBox.Show(_msbRequiredMsg, _msbRequiredCap)
            Return False
        End If

        Return True

    End Function

#End Region

End Class
