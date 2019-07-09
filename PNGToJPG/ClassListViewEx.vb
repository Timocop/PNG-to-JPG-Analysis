Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class ClassListViewEx
    Inherits ListView

    Public Sub New()
        Me.DoubleBuffered = True
    End Sub

#Region "Sorting"
    Private g_bSortingColumnEnabled As Boolean = False

    Public Class ListViewColumnSorter
        Implements IComparer

        Private ColumnToSort As Integer
        Private OrderOfSort As SortOrder

        Public Sub New()
            ColumnToSort = 0
            OrderOfSort = SortOrder.None
        End Sub
        Public Sub New(x As Integer, y As SortOrder)
            ColumnToSort = x
            OrderOfSort = y
        End Sub

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Dim listViewItem As ListViewItem = CType(x, ListViewItem)
            Dim listViewItem2 As ListViewItem = CType(y, ListViewItem)
            Dim sText1 As String = ""
            Dim sText2 As String = ""

            If (listViewItem.SubItems.Count > Me.ColumnToSort) Then
                sText1 = listViewItem.SubItems(Me.ColumnToSort).Text
            End If

            If (listViewItem2.SubItems.Count > Me.ColumnToSort) Then
                sText2 = listViewItem2.SubItems(Me.ColumnToSort).Text
            End If

            Select Case Me.OrderOfSort
                Case SortOrder.Ascending
                    Dim iDbl1 As Double
                    Dim iDbl2 As Double

                    If (Double.TryParse(sText1, iDbl1) AndAlso Double.TryParse(sText2, iDbl2)) Then
                        Return (iDbl1.CompareTo(iDbl2))
                    Else
                        Dim dDate1 As Date
                        Dim dDate2 As Date

                        If (Date.TryParse(sText1, dDate1) AndAlso Date.TryParse(sText2, dDate2)) Then
                            Return (dDate1.CompareTo(dDate2))
                        Else
                            Return (String.Compare(sText1, sText2))
                        End If
                    End If

                Case SortOrder.Descending
                    Dim iDbl1 As Double
                    Dim iDbl2 As Double

                    If (Double.TryParse(sText1, iDbl1) AndAlso Double.TryParse(sText2, iDbl2)) Then
                        Return -(iDbl1.CompareTo(iDbl2))
                    Else
                        Dim dDate1 As Date
                        Dim dDate2 As Date

                        If (Date.TryParse(sText1, dDate1) AndAlso Date.TryParse(sText2, dDate2)) Then
                            Return -(dDate1.CompareTo(dDate2))
                        Else
                            Return -(String.Compare(sText1, sText2))
                        End If
                    End If

                Case Else
                    Return 0
            End Select
        End Function

        Public Property m_SortColumn() As Integer
            Get
                Return ColumnToSort
            End Get
            Set(value As Integer)
                ColumnToSort = value
            End Set
        End Property

        Public Property m_Order() As SortOrder
            Get
                Return OrderOfSort
            End Get
            Set(value As SortOrder)
                OrderOfSort = value
            End Set
        End Property
    End Class

    Public Property m_SetSortingColumn As Boolean
        Get
            Return g_bSortingColumnEnabled
        End Get
        Set(value As Boolean)
            If (Not value) Then
                If Me.g_mSortingColumn IsNot Nothing Then
                    Me.g_mSortingColumn.Text = Me.g_mSortingColumn.Text.Substring(2)
                End If

                Me.g_mSortingColumn = Nothing

                Me.ListViewItemSorter = Nothing
                Me.Sort()
            End If

            g_bSortingColumnEnabled = value
        End Set
    End Property

    Private g_mSortingColumn As ColumnHeader
    Private g_sAscChar As String = "+ "
    Private g_sDesChar As String = "- "

    Private Sub SortingListView_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles Me.ColumnClick
        ToggleSortColumn(e.Column)
    End Sub

    Public Sub ToggleSortColumn(iIndex As Integer)
        If (Not g_bSortingColumnEnabled) Then
            Return
        End If

        Dim columnHeader As ColumnHeader = Me.Columns(iIndex)
        Dim sortOrder As SortOrder
        If Me.g_mSortingColumn Is Nothing Then
            sortOrder = SortOrder.Ascending
        Else
            If columnHeader.Equals(Me.g_mSortingColumn) Then
                If Me.g_mSortingColumn.Text.StartsWith(Me.g_sAscChar) Then
                    sortOrder = SortOrder.Descending
                Else
                    sortOrder = SortOrder.Ascending
                End If
            Else
                sortOrder = SortOrder.Ascending
            End If

            If Me.g_mSortingColumn.Text.StartsWith(Me.g_sAscChar) Then
                Me.g_mSortingColumn.Text = Me.g_mSortingColumn.Text.Substring(Me.g_sAscChar.Length)
            ElseIf Me.g_mSortingColumn.Text.StartsWith(Me.g_sDesChar) Then
                Me.g_mSortingColumn.Text = Me.g_mSortingColumn.Text.Substring(Me.g_sDesChar.Length)
            End If
        End If
        Me.g_mSortingColumn = columnHeader

        If (sortOrder = SortOrder.Ascending) Then
            Me.g_mSortingColumn.Text = Me.g_sAscChar & Me.g_mSortingColumn.Text
        Else
            Me.g_mSortingColumn.Text = Me.g_sDesChar & Me.g_mSortingColumn.Text
        End If

        Me.ListViewItemSorter = New ListViewColumnSorter(iIndex, sortOrder)
        Me.Sort()
    End Sub

#End Region

End Class
