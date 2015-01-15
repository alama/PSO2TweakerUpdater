Imports System.Net

Public Class Form1
    Dim FreedomURL As String = "http://162.243.211.123/freedom/"

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = True
        For Each p As Process In Process.GetProcesses
            If p.ProcessName = "PSO2 Tweaker" Then 'If you don't know what your program's process name is, simply run your program, run windows task manager, select 'processes' tab, scroll down untill you find your programs name.
                p.Kill()
            End If
        Next
        Application.DoEvents()
        Threading.Thread.Sleep(1000)
        IO.File.Delete("PSO2 Tweaker.exe")
        Dim t1 As New Threading.Thread(AddressOf UpdateTime)
        t1.IsBackground = True
        t1.Start()
    End Sub

    Private Sub UpdateTime()
        Dim justice As New Net.WebClient
        FreedomURL = justice.DownloadString("http://arks-layer.com/freedom.txt")
        If FreedomURL.Contains("freedom") = False Then
            FreedomURL = "http://162.243.211.123/freedom/"
        End If
        Dim client As New Net.WebClient
        client.DownloadFileAsync(New Uri(FreedomURL & "PSO2%20Tweaker.exe"), (Application.StartupPath & "\PSO2 Tweaker.exe"))
        AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
        AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted
    End Sub

    Private Sub client_DownloadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
        Process.Start("PSO2 Tweaker.exe")
        Application.Exit()
    End Sub

    Private Sub client_ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        If ProgressBarX1.InvokeRequired Then
            ProgressBarX1.Invoke(New Action(Of Object, DownloadProgressChangedEventArgs)(AddressOf client_ProgressChanged), sender, e)
        Else
            Dim totalSize As Long = e.TotalBytesToReceive
            Dim downloadedBytes As Long = e.BytesReceived
            Dim percentage As Integer = e.ProgressPercentage
            ProgressBarX1.Value = percentage
            ProgressBarX1.Text = "Downloaded " & downloadedBytes & "/" & totalSize & " (" & percentage & "%)"
        End If
    End Sub
End Class
