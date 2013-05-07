Imports System.Reflection


Public Class Blank

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Get the version of this tool
        lblVersion.Text = Assembly.GetExecutingAssembly.GetName.Version.ToString

    End Sub


    Private Sub Blank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Screens.CorrectDateTime.CheckDate()
    End Sub


    Public Sub Clear()
        lblWait.Hide()
        lblVersion.Hide()
    End Sub


    Public Sub ShowWaitMessage()
        lblWait.Show()
    End Sub


    Public Sub HideWaitMessage()
        lblWait.Hide()
    End Sub

End Class