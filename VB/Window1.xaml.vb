Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports DevExpress.XtraPivotGrid.Data

Namespace DXPivotGrid_SplittingCells

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            AddHandler Me.pivotGrid.CustomFieldValueCells, New PivotCustomFieldValueCellsEventHandler(AddressOf pivotGrid_CustomFieldValueCells)
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            PivotHelper.FillPivot(Me.pivotGrid)
            Me.pivotGrid.DataSource = GetDataTable()
            Me.pivotGrid.BestFit()
        End Sub

        Private Sub pivotGrid_CustomFieldValueCells(ByVal sender As Object, ByVal e As PivotCustomFieldValueCellsEventArgs)
            If Me.pivotGrid.DataSource Is Nothing Then Return
            If Me.rbDefault.IsChecked = True Then Return
            ' Creates a predicate that returns true for the Grand Total
            ' headers, and false for any other column/row header.
            ' Only cells that match this predicate are split.
            Dim condition As Predicate(Of FieldValueCell) = New Predicate(Of FieldValueCell)(Function(ByVal matchCell) matchCell.ValueType = FieldValueType.GrandTotal AndAlso matchCell.Field Is Nothing)
            ' Creates a list of cell definitions that represent newly created cells.
            ' Two definitions are added to the list. The first one identifies
            ' the Price cell, which has two nested cells (the Retail Price and Wholesale Price
            ' data field headers). The second one identifies the Count cell with 
            ' one nested cell (the Quantity data field header).
            Dim cells As List(Of FieldValueSplitData) = New List(Of FieldValueSplitData)(2)
            cells.Add(New FieldValueSplitData("Price", 2))
            cells.Add(New FieldValueSplitData("Count", 1))
            ' Performs splitting.
            e.Split(True, condition, cells)
        End Sub

        Private Sub pivotGrid_FieldValueDisplayText(ByVal sender As Object, ByVal e As PivotFieldDisplayTextEventArgs)
            If e.Field Is Me.pivotGrid.Fields(Month) Then
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(e.Value))
            End If
        End Sub

        Private Sub rbDefault_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.pivotGrid.LayoutChanged()
        End Sub
    End Class
End Namespace
