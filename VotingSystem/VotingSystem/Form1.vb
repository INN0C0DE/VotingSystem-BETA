Public Class Form1

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If UN_TXT.Text = "admin" And PW_TXT.Text = "admin" Then
            MsgBox("LOGIN SUCCESSFULLY!", vbInformation, "STATUS:")
            UN_TXT.Clear()
            PW_TXT.Clear()
            Me.Hide()
            Form2.Show()

        Else
            MsgBox("INCORRECT USERNAME OR PASSWORD!", vbCritical, "STATUS:")
            UN_TXT.Clear()
            PW_TXT.Clear()
            UN_TXT.Focus()
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
