using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenCBS.Extension.ExcelReports;
using OpenCBS.Shared.Settings;

namespace OpenCBS.ArchitectureV2.Accounting.Service
{
    public static class ReportService
    {
        public static List<Report> GetReports(string attacmentPoint)
        {
            var directory = TechnicalSettings.ReportPath;
            if (string.IsNullOrEmpty(directory))
            {
                directory = AppDomain.CurrentDomain.BaseDirectory;
                if (string.IsNullOrEmpty(directory)) return null;
            }
            directory = Path.Combine(directory, "Reports");
            directory = Path.Combine(directory, "Excel");
            if (!Directory.Exists(directory)) return null;

            return Directory.GetFiles(directory, "*.zip")
                            .Select(file => new Report(file))
                            .Where(report => report.AttachmentPoint == attacmentPoint)
                            .ToList();
        }

        public static void ShowReport(object report, Dictionary<string, object> parameters)
        {
            Initializer.ShowReport((Report) report, parameters);
        }
    }
}
