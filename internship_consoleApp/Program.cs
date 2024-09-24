using OfficeOpenXml;
using OfficeOpenXml.Style;

//install nuget package - EPPlus

string filePath = @"parent_child_relationship.xlsx";

using (var package = new ExcelPackage())
{
    // Add a worksheet
    var worksheet = package.Workbook.Worksheets.Add("Relationships");

    // Set headers
    worksheet.Cells[1, 1].Value = "Parent (i)";
    worksheet.Cells[1, 2].Value = "Child (j)";
    worksheet.Cells[1, 3].Value = "Child (k)";

    int row = 2;

    for (int i = 1; i < 10; i++)
    {
        for (int j = 11; j < 20; j++)
        {
            for (int k = 21; k <= 30; k++)
            {
                worksheet.Cells[row, 1].Value = i;
                worksheet.Cells[row, 2].Value = j;
                worksheet.Cells[row, 3].Value = k;

                row++;
            }
        }
    }

    // Format the header row
    using (var range = worksheet.Cells[1, 1, 1, 3])
    {
        range.Style.Font.Bold = true;
        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
    }

    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

    File.WriteAllBytes(filePath, package.GetAsByteArray());
}

Console.WriteLine("Excel file created successfully at: " + filePath);
