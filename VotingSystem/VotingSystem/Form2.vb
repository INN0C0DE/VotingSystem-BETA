Imports MySql.Data.MySqlClient
Public Class Form2
    Dim CONNECT As MySqlConnection
    Dim CONSTRING As String = "data source = localhost; user = root; database = votingsystem_cruz"
    Dim CMD As MySqlCommand
    Dim CMD2 As MySqlCommand
    Dim CMD3 As MySqlCommand
    Dim DA As MySqlDataAdapter
    Dim DS As DataSet
    Dim itemcoll(999) As String
    Dim itemcoll1(999) As String

    Private Sub PLNTXT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PLNTXT.SelectedIndexChanged
        PLN2TXT.Text = PLNTXT.Text
    End Sub

    Private Sub PLN2TXT_TextChanged(sender As Object, e As EventArgs) Handles PLN2TXT.TextChanged
        If PLN2TXT.Text = "1" Then
            PLNAMETXT.Text = "Student Party list"
        ElseIf PLN2TXT.Text = "2" Then
            PLNAMETXT.Text = "Teachers Party list"
        ElseIf PLN2TXT.Text = "3" Then
            PLNAMETXT.Text = "IT Party list"
        Else
            PLNAMETXT.Text = ""
        End If
    End Sub

Public Sub LOADLV()
        Try
            ListView1.Items.Clear()
            CONNECT = New MySqlConnection(CONSTRING)
            CONNECT.Open()
            Dim sql As String = "select * from voters; select * from candidates"
            CMD = New MySqlCommand(sql, CONNECT)
            DA = New MySqlDataAdapter(CMD)
            DS = New DataSet
            DA.Fill(DS, "Tables")
            For a = 0 To DS.Tables(0).Rows.Count - 1
                For b = 0 To DS.Tables(0).Columns.Count - 1
                    itemcoll(b) = DS.Tables(0).Rows(a)(b).ToString
                Next
                Dim lvitm As New ListViewItem(itemcoll)
                ListView1.Items.Add(lvitm)
            Next
            For r = 0 To DS.Tables(1).Rows.Count - 1
                For c = 0 To DS.Tables(1).Columns.Count - 1
                    itemcoll1(c) = DS.Tables(1).Rows(r)(c).ToString
                Next
                Dim lvitms As New ListViewItem(itemcoll1)
                ListView1.Items.Add(lvitms)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CONNECT.Close()
    End Sub

    Public Sub ClearData()
        SNTXT.Clear()
        FNTXT.Clear()
        MNTXT.Clear()
        LNTXT.Clear()
        COURSETXT.Clear()
        YSTXT.Clear()
        EMAILTXT.Clear()
        CNTXT.Clear()
        CFNTXT.Clear()
        POSITION.Text = ""
        PLNTXT.Text = ""
        PLN2TXT.Clear()
        PLNAMETXT.Clear()


    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LOADLV()
    End Sub

    Private Sub ADD_BTN_Click(sender As Object, e As EventArgs) Handles ADD_BTN.Click
        Try
            CONNECT = New MySqlConnection(CONSTRING)
            CONNECT.Open()
            Dim SQL As String = "Insert into voters (Student_number, First_name, Middle_name, Last_name, Course, Year_Section, Email) values('" & SNTXT.Text & "','" & FNTXT.Text & "', '" & MNTXT.Text & "', '" & LNTXT.Text & "', '" & COURSETXT.Text & "', '" & YSTXT.Text & "','" & EMAILTXT.Text & "')"
            CMD = New MySqlCommand(SQL, CONNECT)

            Dim SQL2 As String = "Insert into candidates (Candidate_number, Full_name, Position, Partylist_number) values('" & CNTXT.Text & "','" & CFNTXT.Text & "', '" & POSITION.Text & "', '" & PLNTXT.Text & "')"
            CMD2 = New MySqlCommand(SQL2, CONNECT)

            CMD.ExecuteNonQuery()
            CMD2.ExecuteNonQuery()
            CONNECT.Close()
            MsgBox("VOTE ADDED!", vbInformation, "STATUS:")
            Call LOADLV()
            Call ClearData()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("YOU LOGGED OUT SUCCESSFULLY!", vbInformation, "STATUS:")
        Me.Hide()
        Form1.Show()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            SNTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text
            FNTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(1).Text
            MNTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text
            LNTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text
            COURSETXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(4).Text
            YSTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(5).Text
            EMAILTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(6).Text
            CNTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(7).Text
            CFNTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(8).Text
            POSITION.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(9).Text
            PLNTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(10).Text
        End If
    End Sub

    Private Sub DELETE_BTN_Click(sender As Object, e As EventArgs) Handles DELETE_BTN.Click
        Try
            CONNECT = New MySqlConnection(CONSTRING)
            CONNECT.Open()
            Dim SQL As String = "delete from voters WHERE Student_number = '" & SNTXT.Text & "'; delete from candidates WHERE Candidate_number = '" & CNTXT.Text & "'"
            CMD = New MySqlCommand(SQL, CONNECT)
            Dim p As Integer = CMD.ExecuteNonQuery
            If p <> 0 Then
                MsgBox("Record Deleted", vbInformation, "STATUS:")
            Else
                MsgBox("Record Cannot be Deleted", vbCritical, "STATUS:")
            End If
            Call LOADLV()
            CONNECT.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Call ClearData()
    End Sub
End Class