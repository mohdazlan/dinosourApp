Public Class loginFrm
    'Project 2
    'Mohd Azlan & Deacan
    '20DDT16F2002

    'This is a global variable
    Public Shared userName As String

    'This will cancel the login process
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUserName.Text = "Azlan" And txtPassword.Text = "admin" Then
            Me.Hide()
            userName = "Administrator"
            mainFrm.Show()
        ElseIf txtUserName.Text = "Jess" And txtPassword.Text = "user" Then
            Me.Hide()
            userName = "Standard User"
            mainFrm.Show()
        ElseIf txtUserName.Text = "Ali" And txtPassword.Text = "guest" Then
            Me.Hide()
            userName = "Guest"
            mainFrm.Show()
        Else
            MsgBox("Invalid Credentials")
        End If

    End Sub
End Class