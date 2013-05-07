Imports System.Drawing


Namespace Controls

    Public Class Label2

#Region "Properties"

        'Private fontEx As New OpenNETCF.Drawing.FontEx(Me.Font.Name, Me.Font.Size, Me.Font.Style)
        Private fontEx As OpenNETCF.Drawing.FontEx
        Private graphicsEx As OpenNETCF.Drawing.GraphicsEx = OpenNETCF.Drawing.GraphicsEx.FromControl(Me)



        Public Overrides Property Text() As String
            Get
                If Me.lblText IsNot Nothing Then Return Me.lblText.Text Else Return Nothing
            End Get
            Set(ByVal value As String)
                lblText.Text = value
            End Set
        End Property



        Public Overrides Property Font() As Font
            Get
                If Me.lblText IsNot Nothing Then Return Me.lblText.Font Else Return Nothing
            End Get
            Set(ByVal value As Font)
                Me.lblText.Font = value
                Me.fontEx = New OpenNETCF.Drawing.FontEx(value.Name, value.Size, value.Style)
            End Set
        End Property

#End Region

#Region "Event Handlers"

        Private Sub Label2_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
            Me.BackColor = Me.Parent.BackColor
        End Sub

#End Region

#Region "Public Methods"

        ''' <summary>
        ''' Resize the control to fit all the text in it.
        ''' </summary>
        ''' <remarks></remarks>

        Public Sub ResizeToFit()

            Me.lblText.Height = CInt(graphicsEx.MeasureString(Me.lblText.Text, fontEx, Me.lblText.Width - 2).Height + 2)
            Dim x As Integer = CInt(Me.CreateGraphics().MeasureString(Me.lblText.Text, Me.Font).Width)
            Me.Height = Me.lblText.Height

        End Sub

#End Region

    End Class

End Namespace