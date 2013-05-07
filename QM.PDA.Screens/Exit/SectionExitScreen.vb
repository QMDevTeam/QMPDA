Imports QM.PDA.BO.Context


Namespace [Exit]

    Public Class SectionExitScreen

#Region " Properties "

        Private _endOfSection As String

#End Region

#Region " Event Handlers "

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me._endOfSection = lblMessage.Text

        End Sub

        Private Sub SectionExitScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If CurrentSection IsNot Nothing Then

                lblMessage.Text = Me._endOfSection & vbCrLf
                If Not String.IsNullOrEmpty(CurrentSection.Name) Then
                    lblMessage.Text &= CurrentSection.Name
                Else
                    lblMessage.Text &= CurrentQuestionnaire.Name
                End If

            End If

        End Sub

#End Region

    End Class

End Namespace
