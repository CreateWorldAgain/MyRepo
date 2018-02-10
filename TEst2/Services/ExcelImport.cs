using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEst2.Models;
using TEst2.Models.ViewModels;

namespace TEst2.Services
{

    public class ImportFile
    {
        static public string ImportExcel(string fileName, AppDbContext db, ILogger logger, string userId, bool moveToArhive=true)
        {
            string error = "";
            int rowNumber = 0; // номер строки в которой произошла ошибка при импорте

            FileInfo file = new FileInfo(fileName);
            try
            {
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    var fileInfo = new ImportFileInfo
                    {
                        FileName=fileName,
                        ImportDate=DateTime.Now,
                        DateFile=File.GetLastWriteTime(fileName),
                        UserId=userId
                    };

                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        rowNumber = row;

                        if (worksheet.Cells[row, 1].Value == null)
                            continue;
                                               
                        if (worksheet.Cells[row, 3].Value == null)
                            continue;

                        if (worksheet.Cells[row, 4].Value == null)
                            continue;

                        if (worksheet.Cells[row, 1].Value.ToString().Equals(""))
                            continue;

                        if (worksheet.Cells[row, 2].Value == null)
                            throw new Exception("Model/PartNumber is null");

                        var serial = new SerialInfo
                        {
                            SerialNumber = worksheet.Cells[row, 1].Value.ToString(),
                            Model = worksheet.Cells[row, 2].Value.ToString(),
                            Reference1 = worksheet.Cells[row, 3].Value.ToString(),
                            Reference2 = worksheet.Cells[row, 4].Value.ToString(),
                            Date = Convert.ToDateTime(worksheet.Cells[row, 5].Value),
                            ImportFileInfo= fileInfo
                        };

                        db.SerialInfo.Add(serial);
                    }

                    db.SaveChanges();
                    
                    // кладем файл в папку с архивом
                    if (moveToArhive)
                    { 

                        string sourcePath = @"C:\Temp";
                        string targetPath = @"C:\Temp\archive";
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        if (Directory.Exists(sourcePath))
                        {
                            string[] files = Directory.GetFiles(sourcePath);

                         
                            foreach (string s in files)
                            {
                                fileName = Path.GetFileName(s);
                                string destFile = Path.Combine(targetPath, fileName);
                                File.Copy(s, destFile, true);
                            }
                        }
                        else
                        {
                            error = "Source path does not exist!";                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                error=$"Import error. Row: {rowNumber}. Error text: {ex.Message}";
            }

            return error;
        }
        static public string ImportXml(string fileName, AppDbContext db, ILogger logger, string userId, bool moveToArhive = true)
        {
            string error = "";
            
            
            return error;
        }
    }
}
