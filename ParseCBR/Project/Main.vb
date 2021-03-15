Imports System.Data.SqlClient

Public Class Main

    Private ConnectionString As String = "Data Source=Inc;Database=db;Integrated Security=False;User ID=user;Password=password;Connect Timeout=30;Encrypt=False;"

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetValDate(Now)
        Dim DT As DataTable = Execute("exec [p_get_valutes]", "DataTable")
        Valute.DisplayMember = "Valute"
        Valute.DataSource = DT
    End Sub
    Private Sub GetValDate(ByVal DateStr As Date)
        If Not Execute("select cast([dbo].[f_existsday] ('" & DateStr.ToString("MM/dd/yyyy") & "') as bit)", "Scalar") Then
            Dim ClsCBR As New ClsCBR
            Dim DTCBR As DataTable = ClsCBR.GetValCurs(DateStr.ToString("dd.MM.yyyy"))
            If DTCBR.Rows.Count > 0 Then
                Dim BulkCopy As SqlBulkCopy = New SqlBulkCopy(ConnectionString)
                BulkCopy.DestinationTableName = "[cbr_data]"
                BulkCopy.BulkCopyTimeout = 10000
                BulkCopy.WriteToServer(DTCBR)
            End If
        End If
    End Sub
    Private Function Execute(ByVal query As String, ByVal type As String) As Object
        Select Case type
            Case "Scalar"
                Using Connect As New SqlConnection(ConnectionString)
                    Connect.Open()
                    Using Command As New SqlCommand(query, Connect)
                        Try
                            Return Command.ExecuteScalar
                        Catch ex As Exception
                            MessageBox.Show(ex.Message & vbCrLf &
                                            "Событие: " & Reflection.MethodBase.GetCurrentMethod().Name & vbCrLf &
                                            "Время: " & Now.ToLocalTime,
                                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                    End Using
                End Using
            Case "DataTable"
                Using Connect As New SqlConnection(ConnectionString)
                    Connect.Open()
                    Using Command As New SqlCommand(query, Connect)
                        Try
                            Command.ExecuteNonQuery()
                            Dim DA As SqlDataAdapter = New SqlDataAdapter(Command)
                            Dim DT As DataTable = New DataTable
                            DA.Fill(DT)
                            Return DT
                        Catch ex As Exception
                            MessageBox.Show(ex.Message & vbCrLf &
                                            "Событие: " & Reflection.MethodBase.GetCurrentMethod().Name & vbCrLf &
                                            "Время: " & Now.ToLocalTime,
                                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                    End Using
                End Using
            Case Else
                Using Connect As New SqlConnection(ConnectionString)
                    Connect.Open()
                    Using Command As New SqlCommand(query, Connect)
                        Try
                            Command.ExecuteNonQuery()
                            Return True
                        Catch ex As Exception
                            MessageBox.Show(ex.Message & vbCrLf &
                                            "Событие: " & Reflection.MethodBase.GetCurrentMethod().Name & vbCrLf &
                                            "Время: " & Now.ToLocalTime,
                                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                    End Using
                End Using
        End Select
        Return Nothing
    End Function

    Private Sub Valute_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Valute.SelectedIndexChanged, ReqDate.ValueChanged
        Dim valutetext As String = Valute.Text
        Dim valutestr = valutetext.Split(New Char() {"[", "]"})(1)
        Dim reqdatestr As String = ReqDate.Value.ToString("MM/dd/yyyy")
        SetCurrentValue(reqdatestr, valutestr)
    End Sub
    Private Sub SetCurrentValue(ByVal reqdatestr As String, ByVal valutestr As String)
        Dim currvalue As String = GetCurrentRate(reqdatestr, valutestr)
        If currvalue.Length > 0 Then
            Value.Text = currvalue
        Else
            Value.Text = "Загрузка данных..."
            Update()
            GetValDate(ReqDate.Value)
            currvalue = GetCurrentRate(reqdatestr, valutestr)
            If currvalue.Length > 0 Then
                Value.Text = currvalue
            Else
                Value.Text = "Не удалось получить данные!"
            End If
        End If
    End Sub
    Private Function GetCurrentRate(ByVal reqdatestr As String, ByVal valutestr As String) As String
        Return Execute("select [dbo].[f_get_valute] ('" & reqdatestr & "','" & valutestr & "')", "Scalar").ToString
    End Function
End Class
