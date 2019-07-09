Imports System.Drawing.Imaging

Public Class FormMain
    Private g_ClassScanner As ClassScanner

    Private g_bIgnoreSelection As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        NumericUpDown_Threads.Minimum = 1
        NumericUpDown_Threads.Maximum = 64
        NumericUpDown_Threads.Value = Math.Max(Math.Min(Environment.ProcessorCount, NumericUpDown_Threads.Maximum), NumericUpDown_Threads.Minimum)
    End Sub

    Private Property m_PreviewImage As Image
        Get
            Return PictureBox_ImagePreview.Image
        End Get
        Set(value As Image)
            If (PictureBox_ImagePreview.Image IsNot Nothing) Then
                PictureBox_ImagePreview.Image.Dispose()
                PictureBox_ImagePreview.Image = Nothing
            End If

            PictureBox_ImagePreview.Image = value
        End Set
    End Property

    Private Sub Button_Select_Click(sender As Object, e As EventArgs) Handles Button_Select.Click
        Try
            If (g_ClassScanner Is Nothing OrElse Not g_ClassScanner.m_Scanning) Then
                Dim sDirectory As String
                Dim iQuality As Integer = CInt(NumericUpDown_JpgQuality.Value)
                Dim iThreads As Integer = CInt(NumericUpDown_Threads.Value)

                Using i As New FolderBrowserDialog
                    i.SelectedPath = TextBox_Path.Text

                    If (i.ShowDialog = DialogResult.OK) Then
                        sDirectory = i.SelectedPath
                        TextBox_Path.Text = sDirectory
                    Else
                        Return
                    End If
                End Using

                g_ClassScanner = New ClassScanner(Me, sDirectory, iQuality, iThreads)
                g_ClassScanner.Start()
            Else
                g_ClassScanner.Abort()

                ToolStripStatusLabel_Progress.Visible = False
                ToolStripProgressBar_Progress.Visible = False

                Button_Select.Text = "Select"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ListViewEx_Images_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx_Images.SelectedIndexChanged
        Try
            If (g_bIgnoreSelection) Then
                Return
            End If

            If (ListViewEx_Images.SelectedItems.Count <> 1) Then
                Return
            End If

            If (TypeOf ListViewEx_Images.SelectedItems(0) IsNot ClassListViewItemImage) Then
                Return
            End If

            Dim mSelectedItem = DirectCast(ListViewEx_Images.SelectedItems(0), ClassListViewItemImage)
            If (Not IO.File.Exists(mSelectedItem.m_ImageInfo.sFile)) Then
                Return
            End If

            m_PreviewImage = New Bitmap(mSelectedItem.m_ImageInfo.sFile)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ListViewEx_Images_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewEx_Images.MouseDoubleClick
        Try
            If (ListViewEx_Images.SelectedItems.Count <> 1) Then
                Return
            End If

            If (TypeOf ListViewEx_Images.SelectedItems(0) IsNot ClassListViewItemImage) Then
                Return
            End If

            Dim mSelectedItem = DirectCast(ListViewEx_Images.SelectedItems(0), ClassListViewItemImage)
            If (Not IO.File.Exists(mSelectedItem.m_ImageInfo.sFile)) Then
                Return
            End If

            Process.Start(mSelectedItem.m_ImageInfo.sFile)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripMenuItem_Open_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Open.Click
        Try
            If (ListViewEx_Images.SelectedItems.Count <> 1) Then
                Return
            End If

            If (TypeOf ListViewEx_Images.SelectedItems(0) IsNot ClassListViewItemImage) Then
                Return
            End If

            Dim mSelectedItem = DirectCast(ListViewEx_Images.SelectedItems(0), ClassListViewItemImage)
            If (Not IO.File.Exists(mSelectedItem.m_ImageInfo.sFile)) Then
                Return
            End If

            Process.Start(mSelectedItem.m_ImageInfo.sFile)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripMenuItem_OpenExplorer_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_OpenExplorer.Click
        Try
            If (ListViewEx_Images.SelectedItems.Count <> 1) Then
                Return
            End If

            If (TypeOf ListViewEx_Images.SelectedItems(0) IsNot ClassListViewItemImage) Then
                Return
            End If

            Dim mSelectedItem = DirectCast(ListViewEx_Images.SelectedItems(0), ClassListViewItemImage)
            If (Not IO.File.Exists(mSelectedItem.m_ImageInfo.sFile)) Then
                Return
            End If

            Process.Start("explorer.exe", String.Format("/select,{0}", mSelectedItem.m_ImageInfo.sFile))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripMenuItem_Convert_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Convert.Click
        Try
            If (MessageBox.Show(String.Format("Do you want to convert {0} files?", ListViewEx_Images.SelectedItems.Count), "Convert files", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            'Remove image from preview because the file will be in use 
            m_PreviewImage = Nothing

            Try
                g_bIgnoreSelection = True

                Try
                    ListViewEx_Images.BeginUpdate()

                    For Each mItem As ListViewItem In ListViewEx_Images.SelectedItems
                        If (TypeOf mItem IsNot ClassListViewItemImage) Then
                            Return
                        End If

                        Dim mSelectedItem = DirectCast(mItem, ClassListViewItemImage)
                        If (Not IO.File.Exists(mSelectedItem.m_ImageInfo.sFile)) Then
                            Return
                        End If

                        mSelectedItem.m_ImageInfo.ConvertToJPG(True)

                        ListViewEx_Images.Items.Remove(mItem)
                    Next
                Finally
                    ListViewEx_Images.EndUpdate()
                End Try
            Finally
                g_bIgnoreSelection = False
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripMenuItem_Remove_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Remove.Click
        Try
            If (MessageBox.Show(String.Format("Do you want to delete {0} files?", ListViewEx_Images.SelectedItems.Count), "Delete files", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            'Remove image from preview because the file will be in use
            m_PreviewImage = Nothing

            Try
                g_bIgnoreSelection = True

                Try
                    ListViewEx_Images.BeginUpdate()

                    For Each mItem As ListViewItem In ListViewEx_Images.SelectedItems
                        If (TypeOf mItem IsNot ClassListViewItemImage) Then
                            Return
                        End If

                        Dim mSelectedItem = DirectCast(mItem, ClassListViewItemImage)
                        If (Not IO.File.Exists(mSelectedItem.m_ImageInfo.sFile)) Then
                            Return
                        End If

                        IO.File.Delete(mSelectedItem.m_ImageInfo.sFile)

                        ListViewEx_Images.Items.Remove(mItem)
                    Next
                Finally
                    ListViewEx_Images.EndUpdate()
                End Try
            Finally
                g_bIgnoreSelection = False
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ContextMenuStrip_Images_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Images.Opening
        ToolStripMenuItem_Open.Enabled = (ListViewEx_Images.SelectedItems.Count = 1)
        ToolStripMenuItem_OpenExplorer.Enabled = (ListViewEx_Images.SelectedItems.Count = 1)
        ToolStripMenuItem_Convert.Enabled = (ListViewEx_Images.SelectedItems.Count > 0)
        ToolStripMenuItem_Remove.Enabled = (ListViewEx_Images.SelectedItems.Count > 0)
    End Sub

    Class ClassScanner
        Private g_fFormMain As FormMain

        Private g_mScannerThread As Threading.Thread

        Property m_Directory As String
        Property m_Quality As Integer
        Property m_Threads As Integer

        Private _lock As New Object

        Public Sub New(_FormMain As FormMain, _Directory As String, _Quality As Integer, _Threads As Integer)
            g_fFormMain = _FormMain
            m_Directory = _Directory
            m_Quality = _Quality
            m_Threads = _Threads
        End Sub

        Public Sub Start()
            If (m_Scanning) Then
                Return
            End If

            g_mScannerThread = New Threading.Thread(AddressOf ScannerThread) With {
                .IsBackground = True
            }
            g_mScannerThread.Start()
        End Sub

        Public Sub Abort()
            If (m_Scanning) Then
                g_mScannerThread.Abort()
                g_mScannerThread.Join()
                g_mScannerThread = Nothing
            End If
        End Sub

        ReadOnly Property m_Scanning As Boolean
            Get
                Return (g_mScannerThread IsNot Nothing AndAlso g_mScannerThread.IsAlive)
            End Get
        End Property

        Private Sub ScannerThread()
            Try
                Dim sDirectory As String = m_Directory
                Dim iQuality As Integer = m_Quality
                Dim iThreads As Integer = m_Threads

                g_fFormMain.BeginInvoke(Sub() g_fFormMain.Button_Select.Text = "Abort")

                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripStatusLabel_Progress.Text = "Searching files...")
                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripProgressBar_Progress.Minimum = 0)
                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripProgressBar_Progress.Maximum = 100)
                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripProgressBar_Progress.Value = 0)

                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripStatusLabel_Progress.Visible = True)
                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripProgressBar_Progress.Visible = True)

                Dim sFiles = IO.Directory.GetFiles(sDirectory, "*.*", IO.SearchOption.TopDirectoryOnly)
                Dim mPngInfo As New List(Of STRUC_IMAGE_INFO)
                Dim mThreads As New List(Of Threading.Thread)
                Dim mFilesThreads As New Queue(Of String)
                Dim mThreadInfo As New Dictionary(Of String, Object)

                mThreadInfo("Files") = 0
                mThreadInfo("TotalSpace") = 0
                mThreadInfo("JpgSpace") = 0

                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripProgressBar_Progress.Maximum = sFiles.Length)


                For i = 0 To sFiles.Length - 1
                    mFilesThreads.Enqueue(sFiles(i))
                Next

                For i = 0 To iThreads
                    Dim mData As New Dictionary(Of String, Object)
                    mData("FilesThreads") = mFilesThreads
                    mData("PngInfo") = mPngInfo
                    mData("Quality") = iQuality
                    mData("ThreadInfo") = mThreadInfo

                    Dim tThread As New Threading.Thread(AddressOf SubScanner) With {
                        .IsBackground = True
                    }
                    tThread.Start(mData)

                    mThreads.Add(tThread)
                Next

                Try
                    While True
                        Threading.Thread.Sleep(1000)

                        Dim iFiles As Integer

                        SyncLock _lock
                            iFiles = CInt(mThreadInfo("Files"))
                        End SyncLock

                        g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripProgressBar_Progress.Value = iFiles)
                        g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripStatusLabel_Progress.Text = String.Format("Analyzing files {0}/{1} {2}%...", iFiles, sFiles.Length, CInt(Math.Ceiling(iFiles / sFiles.Length * 100))))

                        For Each mThread In mThreads
                            If (mThread.IsAlive) Then
                                Continue While
                            End If
                        Next

                        Exit While
                    End While
                Catch ex As Threading.ThreadAbortException
                    For Each mThread In mThreads
                        mThread.Abort()
                    Next

                    For Each mThread In mThreads
                        mThread.Join()
                    Next

                    Throw
                End Try

                Dim iTotalSpace As Long = CLng(mThreadInfo("TotalSpace"))
                Dim iJpgSpace As Long = CLng(mThreadInfo("JpgSpace"))

                g_fFormMain.BeginInvoke(Sub()
                                            g_fFormMain.ListViewEx_Images.BeginUpdate()
                                            g_fFormMain.ListViewEx_Images.Items.Clear()

                                            For Each mItem In mPngInfo.ToArray
                                                g_fFormMain.ListViewEx_Images.Items.Add(New ClassListViewItemImage(mItem))
                                            Next

                                            g_fFormMain.ListViewEx_Images.EndUpdate()
                                        End Sub)

                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripProgressBar_Progress.Value = g_fFormMain.ToolStripProgressBar_Progress.Maximum)
                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripStatusLabel_Progress.Text = String.Format("Analysis Finished! Freeable space after converting all images: {0}", ClassHelpers.FormatBytes(iTotalSpace - iJpgSpace)))

                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripProgressBar_Progress.Visible = False)

                g_fFormMain.BeginInvoke(Sub() g_fFormMain.Button_Select.Text = "Select")
            Catch ex As Threading.ThreadAbortException
                Throw
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripStatusLabel_Progress.Visible = False)
                g_fFormMain.BeginInvoke(Sub() g_fFormMain.ToolStripProgressBar_Progress.Visible = False)

                g_fFormMain.BeginInvoke(Sub() g_fFormMain.Button_Select.Text = "Select")
            End Try
        End Sub

        Private Sub SubScanner(x As Object)
            Dim mData = DirectCast(x, Dictionary(Of String, Object))

            Dim mFilesThreads = DirectCast(mData("FilesThreads"), Queue(Of String))
            Dim mPngInfo = DirectCast(mData("PngInfo"), List(Of STRUC_IMAGE_INFO))
            Dim iQuality = DirectCast(mData("Quality"), Integer)
            Dim mThreadInfo = DirectCast(mData("ThreadInfo"), Dictionary(Of String, Object))

            Dim sFormats As String() = New String() {".bmp", ".gif", ".jpeg", ".jpg", ".png"}

            While True
                Try
                    Dim sFile As String

                    SyncLock _lock
                        If (mFilesThreads.Count < 1) Then
                            Exit While
                        End If

                        sFile = mFilesThreads.Dequeue()

                        mThreadInfo("Files") = CInt(mThreadInfo("Files")) + 1
                    End SyncLock

                    Dim sExt = IO.Path.GetExtension(sFile)
                    If (Array.IndexOf(sFormats, sExt.ToLower) = -1) Then
                        Continue While
                    End If

                    If (Not ClassHelpers.IsImagePng(sFile)) Then
                        Continue While
                    End If

                    Dim iRatio = ClassHelpers.GetRatioJpg(sFile, iQuality)
                    If (iRatio < 0.0) Then
                        Continue While
                    End If

                    Dim mFileInfo As New IO.FileInfo(sFile)

                    SyncLock _lock
                        mPngInfo.Add(New STRUC_IMAGE_INFO(sFile, iRatio, mFileInfo.Length, iQuality))

                        mThreadInfo("TotalSpace") = CLng(mThreadInfo("TotalSpace")) + mFileInfo.Length
                        mThreadInfo("JpgSpace") = CLng(mThreadInfo("JpgSpace")) + (mFileInfo.Length * iRatio)
                    End SyncLock
                Catch ex As Threading.ThreadAbortException
                    Throw
                Catch ex As Exception

                End Try
            End While
        End Sub
    End Class

    Class ClassListViewItemImage
        Inherits ListViewItem

        ReadOnly Property m_ImageInfo As STRUC_IMAGE_INFO

        Public Sub New(_ImageInfo As STRUC_IMAGE_INFO)
            MyBase.New(New String() {CStr(Math.Ceiling(_ImageInfo.iRatio * 100)), _ImageInfo.sFile, ClassHelpers.FormatBytes(_ImageInfo.iSize), ClassHelpers.FormatBytes(_ImageInfo.m_RatioSize), CStr(_ImageInfo.iQuality)})

            m_ImageInfo = _ImageInfo
        End Sub
    End Class

    Class ClassHelpers
        Public Shared Function FormatBytes(lBytes As Double) As String
            Try
                Dim aPosForm() As String = {"Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"}
                For i As Integer = aPosForm.Length - 1 To 0 Step -1
                    If lBytes > 1024 ^ i Then
                        lBytes = lBytes / (1024 ^ i)
                        Return lBytes.ToString("0.00") & " " & aPosForm(i)
                    End If
                Next i
            Catch : End Try
            Return lBytes.ToString("N") & " Bytes"
        End Function

        Public Shared Function IsImagePng(sFile As String) As Boolean
            Static iPngMagic As Byte() = New Byte() {137, 80, 78, 71}

            Dim iBuffer As Byte() = New Byte(iPngMagic.Length - 1) {}

            Using mFileStream As New IO.FileStream(sFile, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read, iBuffer.Length)
                Dim iRead = mFileStream.Read(iBuffer, 0, iBuffer.Length)

                If (iRead <> iPngMagic.Length) Then
                    Return False
                End If

                For i = 0 To iPngMagic.Length - 1
                    If (iBuffer(i) <> iPngMagic(i)) Then
                        Return False
                    End If
                Next
            End Using

            Return True
        End Function

        Public Shared Function GetRatioJpg(sFile As String, iQuality As Integer) As Double
            Using mFileStream As New IO.FileStream(sFile, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read, 1024 * 8)
                Using mBitmap As New Bitmap(mFileStream)
                    Dim mJpgEncoder = GetEncoder(ImageFormat.Jpeg)
                    If (mJpgEncoder Is Nothing) Then
                        Return -1.0
                    End If

                    Using mMemoryStream As New IO.MemoryStream()
                        Dim mEncodeParm = New EncoderParameters(1)
                        mEncodeParm.Param(0) = New EncoderParameter(Encoder.Quality, iQuality)

                        mBitmap.Save(mMemoryStream, mJpgEncoder, mEncodeParm)

                        Return (mMemoryStream.Length / mFileStream.Length)
                    End Using
                End Using
            End Using

            Return -1.0
        End Function

        Public Shared Function GetEncoder(format As ImageFormat) As ImageCodecInfo
            Dim mCodecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()

            For Each mCodec As ImageCodecInfo In mCodecs
                If (mCodec.FormatID = format.Guid) Then
                    Return mCodec
                End If
            Next

            Return Nothing
        End Function
    End Class

    Class STRUC_IMAGE_INFO
        Public sFile As String
        Public iRatio As Double
        Public iSize As Long
        Public iQuality As Integer

        Public Sub New(_File As String, _Ratio As Double, _Size As Long, _Quality As Integer)
            sFile = _File
            iRatio = _Ratio
            iSize = _Size
            iQuality = _Quality
        End Sub

        ReadOnly Property m_RatioSize As Long
            Get
                Return CLng(iSize * iRatio)
            End Get
        End Property

        Public Sub ConvertToJPG(bDeleteOld As Boolean)
            Dim sFileJpg As String = IO.Path.ChangeExtension(sFile, ".jpg")

            'Same name? Wot?
            If (sFileJpg.ToLower = sFile.ToLower) Then
                sFileJpg = IO.Path.Combine(IO.Path.GetDirectoryName(sFile), String.Format("{0} (1).jpg", IO.Path.GetFileNameWithoutExtension(sFile)))
            End If

            Using mFileStream As New IO.FileStream(sFile, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read, 1024 * 8)
                Using mBitmap As New Bitmap(mFileStream)
                    Dim mJpgEncoder = ClassHelpers.GetEncoder(ImageFormat.Jpeg)
                    If (mJpgEncoder Is Nothing) Then
                        Throw New ArgumentException("invalid jpg encoder")
                    End If

                    Using mFileJpgStream As New IO.FileStream(sFileJpg, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite, IO.FileShare.ReadWrite, 1024 * 8)
                        Dim mEncodeParm = New EncoderParameters(1)
                        mEncodeParm.Param(0) = New EncoderParameter(Encoder.Quality, iQuality)

                        mBitmap.Save(mFileJpgStream, mJpgEncoder, mEncodeParm)
                    End Using
                End Using
            End Using

            If (bDeleteOld) Then
                IO.File.Delete(sFile)
            End If
        End Sub
    End Class

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CleanUp()
    End Sub

    Private Sub CleanUp()
        If (g_ClassScanner IsNot Nothing) Then
            g_ClassScanner.Abort()
            g_ClassScanner = Nothing
        End If
    End Sub
End Class
