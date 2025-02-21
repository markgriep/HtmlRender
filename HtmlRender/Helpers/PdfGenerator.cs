
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



        public byte[] GenerateComplicatedPdf(List<EligibleForTesting> eligibleForTestingList)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Inch);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    // Header
                    page.Header()
                        .AlignLeft()
                        .Column(col =>
                        {
                            col.Item().Text("Eligible for Testing Report").FontSize(16).Bold();
                            col.Item().Text($"Generated: {DateTime.Now.ToString("f", CultureInfo.InvariantCulture)}").FontSize(10);
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
                                    table.Cell().Element(CellStyle).Text(item.TestNumber.ToString());
                                    table.Cell().Element(CellStyle).Text(item.EmployeeName);
                                    table.Cell().Element(CellStyle).Text(item.JobTitle);
                                }
                            });
                        });

                    // Footer - Page numbering
                    page.Footer().AlignCenter()
                        .Text(text =>
                        {
                            text.Span("Page ").FontSize(10);
                            text.CurrentPageNumber().FontSize(12);
                            text.Span(" of ").FontSize(10);
                            text.TotalPages().FontSize(12);
                        });


                    //page.Content().Text("Hello World").FontSize(20).Bold();



                });
            });

            return document.GeneratePdf();
        }

        // Table cell styling (no borders, left-aligned)
        static IContainer CellStyle(IContainer container) => container.PaddingVertical(5).AlignLeft();

    }
}