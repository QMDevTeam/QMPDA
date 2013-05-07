Imports QM.PDA.BO
Imports QM.PDA.DA


Namespace Reports

    Public Class SimpleReport

#Region " Event Handlers "

        Private Sub ReporteSujetosPendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            lblTitle.Text = Context.CurrentReport.Name
            dgData.DataSource = Data.ExecuteQuery(Context.CurrentReport.Query)


            Dim tableStyle As New System.Windows.Forms.DataGridTableStyle()

            Dim column As BO.Report.Column
            Dim columnStyle As New System.Windows.Forms.DataGridTextBoxColumn

            For idx As Integer = 0 To Context.CurrentReport.Columns.Count - 1

                column = Context.CurrentReport.Columns(idx)
                columnStyle = New System.Windows.Forms.DataGridTextBoxColumn
                columnStyle.MappingName = column.Name
                columnStyle.HeaderText = column.HeaderText
                columnStyle.Width = column.Width
                If Not String.IsNullOrEmpty(column.Format) Then columnStyle.Format = column.Format
                tableStyle.GridColumnStyles.Add(columnStyle)

            Next

            If tableStyle.GridColumnStyles.Count > 0 Then dgData.TableStyles.Add(tableStyle)


            btnNext.Enabled = False

        End Sub



        Private Sub dgData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgData.Click

            If dgData.CurrentRowIndex >= 0 Then
                Try
                    Engine.SelectSubject(CType(CType(dgData.DataSource, System.Data.DataTable).Rows(dgData.CurrentRowIndex)("SubjectID"), Guid))
                    Me.DialogResult = Windows.Forms.DialogResult.Abort
                    Me.Close()
                Catch : End Try
            End If

        End Sub

#End Region

    End Class

End Namespace