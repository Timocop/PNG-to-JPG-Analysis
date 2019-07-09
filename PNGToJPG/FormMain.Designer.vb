<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing) Then
                CleanUp()
            End If

            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Button_Select = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown_Threads = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown_JpgQuality = New System.Windows.Forms.NumericUpDown()
        Me.TextBox_Path = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PictureBox_ImagePreview = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListViewEx_Images = New PNGToJPG.ClassListViewEx()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip_Images = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_Open = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_OpenExplorer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem_Convert = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Remove = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_Progress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar_Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown_Threads, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_JpgQuality, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox_ImagePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip_Images.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Select
        '
        Me.Button_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Select.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_Select.Location = New System.Drawing.Point(623, 21)
        Me.Button_Select.Name = "Button_Select"
        Me.Button_Select.Size = New System.Drawing.Size(86, 23)
        Me.Button_Select.TabIndex = 0
        Me.Button_Select.Text = "Select"
        Me.Button_Select.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown_Threads)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown_JpgQuality)
        Me.GroupBox1.Controls.Add(Me.TextBox_Path)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button_Select)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(715, 81)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Image directory"
        '
        'NumericUpDown_Threads
        '
        Me.NumericUpDown_Threads.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_Threads.Location = New System.Drawing.Point(643, 47)
        Me.NumericUpDown_Threads.Name = "NumericUpDown_Threads"
        Me.NumericUpDown_Threads.Size = New System.Drawing.Size(66, 22)
        Me.NumericUpDown_Threads.TabIndex = 3
        Me.NumericUpDown_Threads.Value = New Decimal(New Integer() {95, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(527, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Threads"
        '
        'NumericUpDown_JpgQuality
        '
        Me.NumericUpDown_JpgQuality.Location = New System.Drawing.Point(130, 47)
        Me.NumericUpDown_JpgQuality.Name = "NumericUpDown_JpgQuality"
        Me.NumericUpDown_JpgQuality.Size = New System.Drawing.Size(66, 22)
        Me.NumericUpDown_JpgQuality.TabIndex = 1
        Me.NumericUpDown_JpgQuality.Value = New Decimal(New Integer() {95, 0, 0, 0})
        '
        'TextBox_Path
        '
        Me.TextBox_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Path.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_Path.Location = New System.Drawing.Point(6, 26)
        Me.TextBox_Path.Name = "TextBox_Path"
        Me.TextBox_Path.ReadOnly = True
        Me.TextBox_Path.Size = New System.Drawing.Size(611, 15)
        Me.TextBox_Path.TabIndex = 1
        Me.TextBox_Path.Text = "Select directory"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "JPG quality"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PictureBox_ImagePreview)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(247, 377)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Image Preview"
        '
        'PictureBox_ImagePreview
        '
        Me.PictureBox_ImagePreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_ImagePreview.Location = New System.Drawing.Point(3, 18)
        Me.PictureBox_ImagePreview.Name = "PictureBox_ImagePreview"
        Me.PictureBox_ImagePreview.Size = New System.Drawing.Size(241, 356)
        Me.PictureBox_ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_ImagePreview.TabIndex = 0
        Me.PictureBox_ImagePreview.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 99)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListViewEx_Images)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Size = New System.Drawing.Size(715, 377)
        Me.SplitContainer1.SplitterDistance = 464
        Me.SplitContainer1.TabIndex = 4
        '
        'ListViewEx_Images
        '
        Me.ListViewEx_Images.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListViewEx_Images.ContextMenuStrip = Me.ContextMenuStrip_Images
        Me.ListViewEx_Images.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewEx_Images.Location = New System.Drawing.Point(0, 0)
        Me.ListViewEx_Images.m_SetSortingColumn = True
        Me.ListViewEx_Images.Name = "ListViewEx_Images"
        Me.ListViewEx_Images.Size = New System.Drawing.Size(464, 377)
        Me.ListViewEx_Images.TabIndex = 0
        Me.ListViewEx_Images.UseCompatibleStateImageBehavior = False
        Me.ListViewEx_Images.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Ratio %"
        Me.ColumnHeader1.Width = 75
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "File"
        Me.ColumnHeader2.Width = 250
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Size"
        Me.ColumnHeader3.Width = 75
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "JPG Size"
        Me.ColumnHeader4.Width = 75
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Quality"
        Me.ColumnHeader5.Width = 50
        '
        'ContextMenuStrip_Images
        '
        Me.ContextMenuStrip_Images.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Open, Me.ToolStripMenuItem_OpenExplorer, Me.ToolStripSeparator1, Me.ToolStripMenuItem_Convert, Me.ToolStripMenuItem_Remove})
        Me.ContextMenuStrip_Images.Name = "ContextMenuStrip_Images"
        Me.ContextMenuStrip_Images.Size = New System.Drawing.Size(181, 120)
        '
        'ToolStripMenuItem_Open
        '
        Me.ToolStripMenuItem_Open.Image = CType(resources.GetObject("ToolStripMenuItem_Open.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open"
        Me.ToolStripMenuItem_Open.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_Open.Text = "Open"
        '
        'ToolStripMenuItem_OpenExplorer
        '
        Me.ToolStripMenuItem_OpenExplorer.Name = "ToolStripMenuItem_OpenExplorer"
        Me.ToolStripMenuItem_OpenExplorer.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_OpenExplorer.Text = "Open in explorer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'ToolStripMenuItem_Convert
        '
        Me.ToolStripMenuItem_Convert.Image = CType(resources.GetObject("ToolStripMenuItem_Convert.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Convert.Name = "ToolStripMenuItem_Convert"
        Me.ToolStripMenuItem_Convert.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_Convert.Text = "Convert to JPG"
        '
        'ToolStripMenuItem_Remove
        '
        Me.ToolStripMenuItem_Remove.Image = CType(resources.GetObject("ToolStripMenuItem_Remove.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Remove.Name = "ToolStripMenuItem_Remove"
        Me.ToolStripMenuItem_Remove.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_Remove.Text = "Remove"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_Progress, Me.ToolStripProgressBar_Progress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 479)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(739, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel_Progress
        '
        Me.ToolStripStatusLabel_Progress.Name = "ToolStripStatusLabel_Progress"
        Me.ToolStripStatusLabel_Progress.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel_Progress.Text = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel_Progress.Visible = False
        '
        'ToolStripProgressBar_Progress
        '
        Me.ToolStripProgressBar_Progress.Name = "ToolStripProgressBar_Progress"
        Me.ToolStripProgressBar_Progress.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar_Progress.Visible = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 501)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PNG to JPG"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown_Threads, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_JpgQuality, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PictureBox_ImagePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip_Images.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Select As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox_Path As TextBox
    Friend WithEvents NumericUpDown_JpgQuality As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents PictureBox_ImagePreview As PictureBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ListViewEx_Images As ClassListViewEx
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel_Progress As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar_Progress As ToolStripProgressBar
    Friend WithEvents ContextMenuStrip_Images As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem_Open As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_OpenExplorer As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem_Convert As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Remove As ToolStripMenuItem
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents NumericUpDown_Threads As NumericUpDown
    Friend WithEvents Label2 As Label
End Class
