Imports QM.PDA.BO.Context


Namespace Splash


    Public Class SectionSplashScreen

#Region " Event Handlers "

        Private Sub SectionSplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Not CurrentQuestionnaire Is Nothing Then
                lblQuestionnaireName.Text = CurrentQuestionnaire.Name

                If Not CurrentSection Is Nothing Then
                    lblSectionName.Text = CurrentSection.Name
                    lblSectionShortName.Text = CurrentSection.ShortName
                End If
            End If

            If Not CurrentStudy Is Nothing Then lblVersion.Text = String.Format("({0})", CurrentStudy.Version)


            InputPanel.Enabled = False

        End Sub

#End Region

    End Class

End Namespace