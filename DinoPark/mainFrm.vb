Public Class mainFrm

    Dim charge As Decimal
    Private Sub mainFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DinoparkDataSet.employee' table. You can move, or remove it, as needed.
        Me.EmployeeTableAdapter.Fill(Me.DinoparkDataSet.employee)
        MsgBox(loginFrm.userName)
        lblName.Text = loginFrm.userName

        ' 3 kinds of ticketing
        ' for 5 years old is RM5
        ' for 10 years old is Rm10
        ' for 15 years old is RM15
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim age As Int16 = Val(txtAge.Text)
        checkCharge(age)
        checkTax(charge)
    End Sub

    Sub checkCharge(ByVal age)

        If age > 15 Then
            charge = 15
        ElseIf age > 10 Then
            charge = 10
        Else
            charge = 5
        End If
        MsgBox(charge)
    End Sub

    'create a VAT function
    Sub checkTax(ByVal charge)
        'total charge is x then need to add 5%
        Dim VAT As Decimal = 0.05 * charge
        MsgBox(VAT)
        MsgBox(VAT + charge)
    End Sub

    Private Sub CreateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateToolStripMenuItem.Click
        employeeFrm.Show()
    End Sub
End Class