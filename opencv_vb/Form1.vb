Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Structure
Imports Emgu.Util
Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim inputImg As New Mat
        Dim grayImg As New Mat
        Dim binaryImg As New Mat
        Dim contours As New Emgu.CV.Util.VectorOfVectorOfPoint()
        Dim hier As New Mat()

        'inputImg = CvInvoke.Imread("F:/image/square.jpg")
        inputImg = CvInvoke.Imread("F:/image/Untitled.png")

        'Convert to gray
        CvInvoke.CvtColor(inputImg, grayImg, ColorConversion.Bgr2Gray)

        'Apply contour detection
        CvInvoke.Threshold(grayImg, binaryImg, 150, 255, ThresholdType.Binary)

        'Detect contours
        CvInvoke.FindContours(binaryImg, contours, hier, RetrType.Tree, ChainApproxMethod.ChainApproxSimple)
        CvInvoke.DrawContours(inputImg, contours, -1, New MCvScalar(0, 255, 0), 5)

        ' Detect the number of object
        Dim numberobj As Integer
        numberobj = contours.Size

        If (numberobj > 0) Then
            Label1.Text = "Object Detected"
            Label2.Text = numberobj.ToString()
        Else
            Label1.Text = "No Object Detected"
            Label2.Text = "0"
        End If

        ImageBox1.SizeMode = PictureBoxSizeMode.Zoom
        ImageBox1.Image = inputImg

    End Sub
End Class
