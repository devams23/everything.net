using System;
using System.Collections.Generic;
using System.Text;

// File created on 2025-01-29
namespace Day3_OOP.programs
{
    abstract class ReportGenerator
    {
        public abstract List<string> GenerateReport(DateOnly start, DateOnly end);

    }

    class PdfReportGenerator : ReportGenerator
    {
        public override List<string> GenerateReport(DateOnly start, DateOnly end)
        {
            Console.WriteLine($"Generating PDF report from {start} to {end}");
            return ["PDF Report Content" , "PDF Page1"];
        }
    }
    class ExcelReportGenerator : ReportGenerator
    {
        public override List<string> GenerateReport(DateOnly start, DateOnly end)
        {
            Console.WriteLine($"Generating Excel report from {start} to {end}");
            return ["Excel Report Content" , "Excel Sheet1"];
        }
    }

        class ReportGeneratorProgram
        {
            static void Main(string[] args)
            {
                ReportGenerator pdfGenerator = new PdfReportGenerator();
            // min and max values are for demonstration purposes,and can be replace with actual dates
            var pdfReport = pdfGenerator.GenerateReport(DateOnly.MinValue, DateOnly.MaxValue);

                ReportGenerator excelGenerator = new ExcelReportGenerator();
                excelGenerator.GenerateReport(DateOnly.MinValue, DateOnly.MaxValue);
        }
        
        }

}
