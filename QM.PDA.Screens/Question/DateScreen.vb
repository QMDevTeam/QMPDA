

Namespace Question


    <CanValidateRange()> _
    Public Class DateScreen

#Region " Properties "

        Protected Overrides ReadOnly Property InputValue() As System.IComparable
            Get
                ' Return a DateTime object with the date component only
                If HasValue Then Return New DateTime(dtpDateTime.Value.Year, dtpDateTime.Value.Month, dtpDateTime.Value.Day) Else Return Nothing
            End Get
        End Property

#End Region

    End Class

End Namespace
