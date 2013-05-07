Imports System.Windows.Forms
Imports QM.PDA.BO.Context


''' <summary>
''' Inherits from BaseForm and adds the header. This is the 
''' template for all the screens in a questionnaire.
''' </summary>
''' <remarks><seealso cref="BaseForm"/></remarks>

Public Class BaseScreen

#Region " Properties "

    Protected Screen As BO.Screen

#End Region

#Region " Public Methods "

    Public Sub LoadScreen(ByVal screen As BO.Screen)

        ' Check if ScreenToShow is Nothing.
        If screen Is Nothing Then Throw New ArgumentNullException("screen", "A screen to load must be specified")

        ' Set the screen to show.
        Me.Screen = screen

        ' Make available the extra menu options
        Me.mnuChangeQuestionnaire.Enabled = True
        Me.mnuChangeSubject.Enabled = True


        ' Set the visibility of the navigation buttons.
        Me.btnBack.Enabled = Not screen.HideBack.GetValueOrDefault(False)
        Me.btnNext.Enabled = Not screen.HideNext.GetValueOrDefault(False)

    End Sub

#End Region

End Class