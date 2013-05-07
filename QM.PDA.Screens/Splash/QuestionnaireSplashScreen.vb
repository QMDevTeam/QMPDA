Imports QM.PDA.BO.Context


Namespace Splash


    Public Class QuestionnaireSplashScreen

#Region " Event Handlers "

        Private Sub QuestionnaireSplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Not CurrentStudy Is Nothing Then
                lblStudyShortName.Text = CurrentStudy.ShortName
                lblVersion.Text = String.Format("({0})", CurrentStudy.Version)

                If Not CurrentQuestionnaire Is Nothing Then
                    lblQuestionnaireName.Text = CurrentQuestionnaire.Name
                    lblQuestionnaireShortName.Text = CurrentQuestionnaire.ShortName
                End If

            End If


            InputPanel.Enabled = False

        End Sub

#End Region

    End Class

End Namespace