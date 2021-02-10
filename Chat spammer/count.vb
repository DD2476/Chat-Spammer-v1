Public Class count

    Dim mi As Integer
    Dim ma As Integer
    Dim i As Integer = 1
    Dim canExit As Boolean

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub spam_Tick(sender As Object, e As EventArgs) Handles spam.Tick

        If i < ma + 1 Then

            SendKeys.Send(i)

            If CheckBox1.Checked = True Then

                SendKeys.Send("{ENTER}")

            End If

            If CheckBox2.Checked = True Then

                SendKeys.Send(" ")

            End If

            i += 1

        End If

        If i = ma Then

            spam.Stop()

            Me.WindowState = FormWindowState.Normal

            min.Enabled = True
            max.Enabled = True
            TextBox1.Enabled = True

            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = True

        End If

    End Sub

    Private Sub always_Tick(sender As Object, e As EventArgs) Handles always.Tick

        mi = min.Text
        ma = max.Text + 1

        If TextBox1.Text <> "" Then

            spam.Interval = TextBox1.Text

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub count_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If canExit = False Then

            e.Cancel = True

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown

        If min.Text <> "" AndAlso max.Text <> "" AndAlso TextBox1.Text <> "" Then

            Me.WindowState = FormWindowState.Minimized

            min.Enabled = False
            max.Enabled = False

            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = False

            i = mi

            spam.Start()

        End If

    End Sub

    Private Sub Button2_MouseDown(sender As Object, e As MouseEventArgs) Handles Button2.MouseDown

        spam.Stop()

        min.Enabled = True
        max.Enabled = True
        TextBox1.Enabled = True

        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = True

    End Sub

    Private Sub Button3_MouseDown(sender As Object, e As MouseEventArgs) Handles Button3.MouseDown

        canExit = True

        Me.Close()

        start.Show()

    End Sub
End Class