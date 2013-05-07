Imports System.Resources

Public Class LanguageManager

#Region " Properties "

    Private Shared cache As Dictionary(Of String, ResourceManager)

#End Region

#Region " Public methods "

    ''' <summary>
    ''' Returns the resource manager for the specifided assembly, creates it if needed.
    ''' </summary>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function CreateLanguageManager(ByVal type As Type) As ResourceManager

        Dim name As String = type.Assembly.GetName().Name

        If Not cache.ContainsKey(name) Then

            cache.Add(name, New ResourceManager(name & ".Resources", type.Assembly))

        End If

        Return cache(name)

    End Function

    Public Shared Sub ChangeLanguage(ByVal name As String)



    End Sub

#End Region

End Class
