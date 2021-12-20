using System;
using System.Collections.Generic;
using System.IO;
using TemplateEngine.Docx;

namespace MyLibrary
{
    public sealed class ReportService
    {
        public void GenerateReport(MeasurementInfo measurementInfo, string output = "")
        {
            if (measurementInfo is null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(output))
            {
                output = Path.Combine(Directory.GetCurrentDirectory(), "Report.docx");
            }

            if (File.Exists(output))
            {
                File.Delete(output);
            }
            
            File.Copy(Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")), "Template2.docx"), output);

            List<TableRowContent> rows = new List<TableRowContent>();

            foreach (Measurement measurement in measurementInfo.Measurements)
            {
                rows.Add(new TableRowContent(new List<FieldContent>()
                {
                    new FieldContent("Measurement Order", measurement.MeasurementOrder.ToString()),
                    new FieldContent("Measurement DateTime", measurement.MeasurementDateTime.ToShortDateString() + " " + measurement.MeasurementDateTime.ToLongTimeString()),
                    new FieldContent("Load CPU", measurement.LoadCPU.ToString()),
                    new FieldContent("Load RAM", measurement.LoadRAM.ToString()),
                }));
            }

            var valuesToFill = new Content(
                TableContent.Create("Measurement Table", rows),
                new FieldContent("Measurement Duration", measurementInfo.MeasurementDuration),
                new FieldContent("Load CPU MAX", measurementInfo.LoadCpuMax.ToString()),
                new FieldContent("Load RAM MAX", measurementInfo.LoadRamMax.ToString()),
                new FieldContent("Load CPU AVE", measurementInfo.LoadCpuAve.ToString()),
                new FieldContent("Load RAM AVE", measurementInfo.LoadRamAve.ToString()),
                new FieldContent("Report Date", DateTime.Now.ToShortDateString())
            );

            using (var outputDocument =
                new TemplateProcessor(output)
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
        }
    }
}
