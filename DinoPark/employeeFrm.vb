Imports System.Data.SqlClient

Public Class employeeFrm
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        '1. connection string 
        Dim conString As String = "ServerZ4P5-KM172; Database=dinopark; User Id=sa;Password=p@ssw0rd"


        '2. SQL Query 
        Dim sqlQuery As String = "UPDATE employee SET firstname=@firstname,lastname=@lastname,empid=@empid WHERE empid=@user"

        '3. Instantiate connection and command object 
        Using conn As New SqlConnection(conString), sqlCmd As New SqlCommand(sqlQuery, conn)

            '4. Add parameter(s) 
            sqlCmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txtSearch.Text
            sqlCmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = txtFirst.Text
            sqlCmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = txtLast.Text
            sqlCmd.Parameters.Add("@empid", SqlDbType.VarChar).Value = txtEmp.Text

            '5. Open Coonection 
            conn.Open()


            '6. Delete 
            sqlCmd.ExecuteNonQuery()

            '7. Show message 
            MsgBox("Updated")
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        '1. connection string 
        Dim conString As String = "ServerZ4P5-KM172; Database=dinopark; User Id=sa;Password=p@ssw0rd"


        '2. SQL Query 
        Dim sqlQuery As String = "DELETE  FROM employee WHERE empid=@emp"

        '3. Instantiate connection and command object 
        Using conn As New SqlConnection(conString), sqlCmd As New SqlCommand(sqlQuery, conn)

            '4. Add any parameter 
            sqlCmd.Parameters.Add("@emp", SqlDbType.VarChar).Value = txtSearch.Text

            '5. Open Coonection 
            conn.Open()

            '6. Delete 
            sqlCmd.ExecuteNonQuery()

            '7. Show message 
            MsgBox("Deleted")
        End Using
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        '1. connection string 
        Dim conString As String = "Server=AZLAN-PC; Database=PMU; User Id=sa;Password=p@ssw0rd"

        '2. SQL Query 
        Dim sqlQuery As String = "SELECT * FROM dinopark WHERE username=@user"

        '3. Instantiate connection and command object 
        Using conn As New SqlConnection(conString), sqlCmd As New SqlCommand(sqlQuery, conn)

            '4. Add any parameter 
            sqlCmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txtSearch.Text

            '5. Open Coonection 
            conn.Open()

            '6. Use SQL Data Reader 
            Dim sqlDataReader As SqlDataReader = sqlCmd.ExecuteReader()

            If sqlDataReader.HasRows Then
                While sqlDataReader.Read()
                    txtFirst.Text = sqlDataReader.GetString(0)
                    txtLast.Text = sqlDataReader.GetString(1)
                    txtEmp.Text = sqlDataReader.GetString(2)
                End While
            End If
        End Using
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim connectionString As String = "Server=localhost;Database=JTMK;Trusted_Connection=True;"
        Dim sqlInsert As String = "INSERT INTO dinopark VALUES(@user,@firstname,@emp)"
        Using conn As New SqlConnection(connectionString), cmd As New SqlCommand(sqlInsert, conn)
            cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = txtFirst.Text
            cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = txtLast.Text
            cmd.Parameters.Add("@emp", SqlDbType.VarChar).Value = txtEmp.Text

            conn.Open()
            Dim RowAffected As Int16 = cmd.ExecuteNonQuery()
            MsgBox(CStr(RowAffected) + " berjaya masuk")
        End Using
    End Sub
End Class