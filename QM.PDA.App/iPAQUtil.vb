Imports System.Runtime.InteropServices
Imports System.Text


Public Class iPAQUtil

    <DllImport("iPAQUtil.dll", EntryPoint:="iPAQGetSerialNumber")> _
    Public Shared Function iPAQGetSerialNumber(ByVal SerialNumber As StringBuilder) As Boolean
    End Function

End Class
