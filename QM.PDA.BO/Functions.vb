

''' <summary>
''' Provides functions to be used by the custom code.
''' </summary>

Public Class Functions

    Public Shared Sub ClearSectionVariable(ByVal variableName As String)
        Context.CurrentSection(variableName) = Nothing
    End Sub


    Public Shared Sub ClearQuestionnaireVariable(ByVal variableName As String)
        Context.CurrentQuestionnaire(variableName) = Nothing
    End Sub


    Public Shared Sub ClearSubjectVariable(ByVal variableName As String)
        Context.CurrentSubject(variableName) = Nothing
    End Sub



    Public Shared Sub AssignSectionVariable(ByVal variableName As String, ByVal value As Object)
        Context.CurrentSection(variableName) = value
    End Sub


    Public Shared Sub AssignQuestionnaireVariable(ByVal variableName As String, ByVal value As Object)
        Context.CurrentQuestionnaire(variableName) = value
    End Sub


    Public Shared Sub AssignSubjectVariable(ByVal variableName As String, ByVal value As Object)
        Context.CurrentSubject(variableName) = value
    End Sub

End Class
