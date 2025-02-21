
using HtmlRender.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;





namespace HtmlRender.Helpers
{
    public class PdfGenerator
    {
        static IContainer CellStyle(IContainer container) => container.PaddingVertical(5).AlignLeft();

        static TextStyle DefaultTextStyle => TextStyle.Default.FontSize(12).FontFamily("Arial");
        static TextStyle HeaderTextStyle => TextStyle.Default.FontSize(16).Bold().FontFamily("Arial");
        static TextStyle SmallTextStyle => TextStyle.Default.FontSize(10).FontFamily("Arial");
        static TextStyle TableTextStyle => TextStyle.Default.FontSize(12).FontFamily("Arial");
        static TextStyle DateTimePageStyle => TextStyle.Default.FontSize(10).FontFamily("Arial");







        public byte[] GenerateHelloWorldPdf()
        {

            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Inch);
                    page.DefaultTextStyle(x => x.FontSize(12));
                    page.Content().Text("Hello World").FontSize(20).Bold();
                });
            });



            var x = document.GeneratePdf(); // Returns PDF as byte array

            return x;
        }















        public byte[] GenerateDataReportPdf(List<EligibleForTesting> eligibleForTestingList, string dotNon, int testNumber)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Inch);
                    page.DefaultTextStyle(DefaultTextStyle);

                    // Header with report details and page number
                    page.Header()
                        .Column(column =>
                        {
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text("Report ID: CU 123").Style(SmallTextStyle);
                                row.RelativeItem().AlignCenter().Text($"Report {dotNon} Random Test Pool").Style(HeaderTextStyle);
                                row.RelativeItem().AlignRight().Text(text =>
                                {
                                    text.Span("Page No: ").Style(SmallTextStyle);
                                    text.CurrentPageNumber().Style(SmallTextStyle);
                                });

                                column.Item().AlignCenter().Text($"Test Number {testNumber}  Date: {DateTime.Now.ToString("f", CultureInfo.InvariantCulture)}").Style(SmallTextStyle);
                            });

                            // Content - Table
                            page.Content()
                        .Column(col =>
                        {
                            col.Item().PaddingVertical(10); // Adds spacing before the table

                            col.Item().Table(table =>
                            {
                                // Define Columns (gridless layout)
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(); // Test Number
                                    columns.RelativeColumn(); // Employee Name
                                    columns.RelativeColumn(); // Job Title
                                });

                                // Table Data
                                foreach (var item in eligibleForTestingList)
                                {
                                    table.Cell().Element(CellStyle).Text(item.TestNumber.ToString()).Style(TableTextStyle);
                                    table.Cell().Element(CellStyle).Text(item.EmployeeName).Style(TableTextStyle);
                                    table.Cell().Element(CellStyle).Text(item.JobTitle).Style(TableTextStyle);
                                }
                            });
                        });

                            // Footer - Page numbering
                            page.Footer()
                        .AlignRight()
                        .Text(text =>
                        {
                            text.Span("Page ").Style(SmallTextStyle);
                            text.CurrentPageNumber().Style(SmallTextStyle);
                            text.Span(" of ").Style(SmallTextStyle);
                            text.TotalPages().Style(SmallTextStyle);
                        });
                        });
                });

            });

                return document.GeneratePdf();

        }

































    }
}