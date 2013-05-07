Imports QM.PDA.BO.Context


''' <summary>
''' Evaluates the current screen to determinate
''' the previous or next screen.
''' </summary>

Public Class Engine

#Region " Properties "

    Private Shared _subjectSelectionPending As Boolean = False
    Private Shared _pendingSubjectID As Guid


    Public Shared ReadOnly Property SubjectSelectionPending() As Boolean
        Get
            Return _subjectSelectionPending
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Performes initialization tasks.
    ''' </summary>

    Public Shared Sub Start()

        ' Get the Start Screen of the Current Section
        CurrentScreen = CurrentSection.StartScreen

    End Sub



    ''' <summary>
    ''' Performes finalization tasks.
    ''' </summary>
    ''' <param name="sequenceInterrupted">Indicates if the sequence ended due to an interruption.</param>

    Public Shared Sub Finish(ByVal sequenceInterrupted As Boolean)

        ' If the sequence was not interrupted by the user...
        If Not sequenceInterrupted Then

            ' Clean the Screen stack
            ScreenStack.Clear()


        Else ' If the sequence was interrupted by the user...

            ' Store the contents of the Screen stack and clear it.
            StoreScreenStack()
            ScreenStack.Clear()

            ' Store the last Screen used
            CurrentSubject("SubjectLastScreenID") = CurrentScreen.ScreenID

        End If

        ' Clear the Screen object
        CurrentScreen = Nothing

    End Sub



    ''' <summary>
    ''' Sets the next <c>Screen</c>
    ''' </summary>

    Public Shared Sub GoToNextScreen()

        ScreenStack.Push(CurrentScreen)

        Dim nextScreen As Screen = GetNextScreen(CurrentScreen)

        If nextScreen Is Nothing Then
            CurrentScreen = Nothing
        Else
            If nextScreen.ScreenID = CurrentSection.ExitScreenID Then CurrentSection.IsComplete = True
            CurrentScreen = nextScreen
        End If

    End Sub



    ''' <summary>
    ''' Gets the previous <c>Screen</c>
    ''' </summary>

    Public Shared Sub GoToPreviousScreen()

        If ScreenStack.Count = 0 Then
            CurrentScreen = Nothing
        Else
            CurrentScreen = ScreenStack.Pop()
        End If

    End Sub



    Public Shared Sub SelectSubject(ByVal subjectID As Guid)
        _pendingSubjectID = subjectID
        _subjectSelectionPending = True
    End Sub



    Public Shared Sub ExecutePendingSubjectSelection()
        CurrentSubject = New BO.Subject(_pendingSubjectID, CurrentQuestionnaireSet)
        _subjectSelectionPending = False
    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Determinates the next screen transition
    ''' </summary>
    ''' <param name="Screen">The current <c>Screen</c>.</param>
    ''' <returns>A <c>Screen</c> if there is a suitable transition, <c>Nothing</c> otherwise.</returns>

    Private Shared Function GetNextScreen(ByVal Screen As Screen) As Screen

        ' Evaluate the condition of each transition in the ordered list.
        For Each transition As Transition In Screen.Transitions
            If transition.EvaluateCondition() Then
                transition.ExecuteOnTransitionProcedure()
                Return transition.DestinationScreen
            End If
        Next

        Return Nothing

    End Function



    ''' <summary>
    ''' Stores the contents of the Screen stack for the Current Subject
    ''' </summary>

    Private Shared Sub StoreScreenStack()

        Dim screenIDList As New Text.StringBuilder

        For Each screen As Screen In ScreenStack
            screenIDList.Append(screen.ScreenID & ",")
        Next

        CurrentSubject("SubjectStack") = screenIDList.ToString.TrimEnd(","c)

    End Sub

#End Region

End Class
