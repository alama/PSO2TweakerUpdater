Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Threading

Public Class MainForm
    Private FreedomURL As String = Nothing

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThreadPool.QueueUserWorkItem(AddressOf UpdateTime, Nothing)
    End Sub

    Private Sub client_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs) Handles Client.DownloadStringCompleted
        FreedomURL = If(e.Result.Contains("freedom"), e.Result, "http://162.243.211.123/freedom/")
        Client.DownloadFileAsync(New Uri(FreedomURL & "PSO2%20Tweaker.exe"), (Application.StartupPath & "\PSO2 Tweaker.exe"))
    End Sub

    Private Sub client_DownloadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles Client.DownloadFileCompleted
        Process.Start("PSO2 Tweaker.exe")
        Application.Exit()
    End Sub

    Private Sub client_ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles Client.DownloadProgressChanged
        If FreedomURL IsNot Nothing Then
            ProgressBarX1.Value = e.ProgressPercentage
            ProgressBarX1.Text = "Downloaded " & e.BytesReceived & "/" & e.TotalBytesToReceive & " (" & e.ProgressPercentage & "%)"
        End If
    End Sub

    Private Sub UpdateTime(state As Object)
        For Each procs As Process In Process.GetProcessesByName("PSO2 Tweaker")
            procs.Kill()
        Next

        Thread.Sleep(1000)
        File.Delete("PSO2 Tweaker.exe")

        Me.Invoke(New Action(Of Uri)(AddressOf Client.DownloadStringAsync), New Uri("http://arks-layer.com/freedom.txt"))
    End Sub
End Class
