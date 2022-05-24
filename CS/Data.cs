﻿using System.Data;
using DevExpress.Xpf.PivotGrid;

namespace DXPivotGrid_SplittingCells {
    public static class PivotHelper {
        public const string Employee = "Employee";
        public const string Widget = "Widget";
        public const string Month = "Month";
        public const string RetailPrice = "Retail Price";
        public const string WholesalePrice = "Wholesale Price";
        public const string Quantity = "Quantity";
        public const string Remains = "Remains";

        public const string EmployeeA = "Employee A";
        public const string EmployeeB = "Employee B";
        public const string WidgetA = "Widget A";
        public const string WidgetB = "Widget B";
        public const string WidgetC = "Widget C";

        public static void FillPivot(PivotGridControl pivot) {
            pivot.Fields.AddDataSourceColumn(Employee, FieldArea.RowArea);
            pivot.Fields.AddDataSourceColumn(Widget, FieldArea.RowArea);
            pivot.Fields.AddDataSourceColumn(Month, FieldArea.ColumnArea).AreaIndex = 0;
            pivot.Fields.AddDataSourceColumn(RetailPrice, FieldArea.DataArea);
            pivot.Fields.AddDataSourceColumn(WholesalePrice, FieldArea.DataArea);
            pivot.Fields.AddDataSourceColumn(Quantity, FieldArea.DataArea);
            foreach (PivotGridField field in pivot.Fields) {
                field.AllowedAreas = GetAllowedArea(field.Area);
            }
            pivot.RowTotalsLocation = FieldRowTotalsLocation.Far;
            pivot.ColumnTotalsLocation = FieldColumnTotalsLocation.Far;
            pivot.DataFieldArea = DataFieldArea.ColumnArea;
            pivot.DataFieldAreaIndex = 1;
        }
        static FieldAllowedAreas GetAllowedArea(FieldArea area) {
            switch (area) {
                case FieldArea.ColumnArea:
                    return FieldAllowedAreas.ColumnArea;
                case FieldArea.RowArea:
                    return FieldAllowedAreas.RowArea;
                case FieldArea.DataArea:
                    return FieldAllowedAreas.DataArea;
                case FieldArea.FilterArea:
                    return FieldAllowedAreas.FilterArea;
                default:
                    return FieldAllowedAreas.All;
            }
        }
        public static DataTable GetDataTable() {
            DataTable table = new DataTable();
            table.Columns.Add(Employee, typeof(string));
            table.Columns.Add(Widget, typeof(string));
            table.Columns.Add(Month, typeof(int));
            table.Columns.Add(RetailPrice, typeof(double));
            table.Columns.Add(WholesalePrice, typeof(double));
            table.Columns.Add(Quantity, typeof(int));
            table.Columns.Add(Remains, typeof(int));
            table.Rows.Add(EmployeeA, WidgetA, 6, 45.6, 40, 3);
            table.Rows.Add(EmployeeA, WidgetA, 7, 38.9, 30, 6);
            table.Rows.Add(EmployeeA, WidgetB, 6, 24.7, 20, 7);
            table.Rows.Add(EmployeeA, WidgetB, 7, 8.3, 7.5, 5);
            table.Rows.Add(EmployeeA, WidgetC, 6, 10.0, 9, 4);
            table.Rows.Add(EmployeeA, WidgetC, 7, 20.0, 18.5, 5);
            table.Rows.Add(EmployeeB, WidgetA, 6, 77.8, 70, 2);
            table.Rows.Add(EmployeeB, WidgetA, 7, 32.5, 30, 1);
            table.Rows.Add(EmployeeB, WidgetB, 6, 12, 11, 10);
            table.Rows.Add(EmployeeB, WidgetB, 7, 6.7, 5.5, 4);
            table.Rows.Add(EmployeeB, WidgetC, 6, 30.0, 28.7, 6);
            table.Rows.Add(EmployeeB, WidgetC, 7, 40.0, 38.3, 7);
            return table;
        }
    }
}
