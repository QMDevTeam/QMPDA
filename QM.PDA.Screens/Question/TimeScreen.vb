

Namespace Question


    <CanValidateRange()> _
    Public Class TimeScreen

#Region " Properties "

        Protected Overrides ReadOnly Property InputValue() As System.IComparable
            Get
                ' Return a DateTime object with the time component and the SQL CE base date
                Return New DateTime(1900, 1, 1, dtpDateTime.Value.Hour, dtpDateTime.Value.Minute, 0)
            End Get
        End Property

#End Region

    End Class

End Namespace
