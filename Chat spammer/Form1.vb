Public Class Form1

    Dim canLeave As Boolean = False
    Dim a As Integer
    Dim b As Integer
    Dim act As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If canLeave = False Then

            e.Cancel = True

        Else



        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.Focus()

        canLeave = True

        start.Show()

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub always_Tick(sender As Object, e As EventArgs) Handles always.Tick

        If TextBox2.Text <> "" Then

            a = TextBox2.Text

        End If

        If TextBox3.Text > 0 Then

            spam.Interval = TextBox3.Text

        End If

        If act = True Then

            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False

        Else

            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True

        End If

    End Sub

    Private Sub spam_Tick(sender As Object, e As EventArgs) Handles spam.Tick

        If b < a Then

            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(TextBox1.Text)

            SendKeys.Send("^v")

            If CheckBox1.Checked = True Then

                SendKeys.Send("{ENTER}")

            End If

            If CheckBox2.Checked = True Then

                Threading.Thread.Sleep(spam.Interval)

                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(TextBox4.Text)

                SendKeys.Send("^v")

                If CheckBox1.Checked = True Then

                    SendKeys.Send("{ENTER}")

                End If

            End If

            b += 1

            Threading.Thread.Sleep(spam.Interval)

        Else

            spam.Stop()

        End If

    End Sub

    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown

        If TextBox1.Text <> "" AndAlso TextBox2.Text <> "" AndAlso TextBox3.Text <> "" Then

            act = True

            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = False

            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False

            spam.Start()

            Me.WindowState = FormWindowState.Minimized

        End If

    End Sub

    Private Sub Button2_MouseDown(sender As Object, e As MouseEventArgs) Handles Button2.MouseDown

        act = False

        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = True

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True

        If CheckBox2.Checked = True Then

            TextBox4.Enabled = True

        End If

        spam.Stop()

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        If CheckBox2.Checked = True Then

            TextBox4.Enabled = True

        Else

            TextBox4.Enabled = False

        End If

    End Sub

End Class
