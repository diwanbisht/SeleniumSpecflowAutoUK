using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NPOI.SS.UserModel;
using NUnit.Framework;

namespace SeleniumSpecfowAuto.TestData
{
    public class ExcelReaderHelper
    {
       
        public Dictionary<String, String> ReadExcelRowByRow(int rowNumber)
        {
            string fname = @"C:\Users\acbio\source\repos\SeleniumSpecfowAuto\TestData\TestDataSet.xlsx";
            IWorkbook workbook = WorkbookFactory.Create(new FileStream(Path.GetFullPath(fname), FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

            Dictionary<String, String> ReadExcelDataValue = new Dictionary<string, string>();

            ISheet worSheet = workbook.GetSheetAt(0);
           
            int RowCount = worSheet.LastRowNum;
            int ColumnsCount = worSheet.GetRow(0).PhysicalNumberOfCells;

            string ColumnValue = "";
            string RowValue = "";

            DataFormatter formatter = new DataFormatter();//Formatter will work fine for cell value.

            for (int ColumnIndex = 0; ColumnIndex < ColumnsCount; ColumnIndex++) //Loop the records upto filled row  
            {
                if (worSheet.GetRow(ColumnsCount) != null)  //null is when the row only contains empty cells   
                {
                    ColumnValue = worSheet.GetRow(0).GetCell(ColumnIndex).StringCellValue; //Here for sample , I just save the value in "value" field, Here you can write your custom logics...  
                    RowValue = formatter.FormatCellValue(worSheet.GetRow(rowNumber).GetCell(ColumnIndex));

                }

                ReadExcelDataValue.Add(ColumnValue, RowValue);
                // Console.WriteLine(rowNumber +  "   "+  "ColoumnValue" + " = " +   ColumnValue +   "   "+ "Row Value = " + RowValue);
                Console.WriteLine();


            }

            return ReadExcelDataValue;
        }

        [Test]
        public void ReadExlerRowbyrowTest()
        {
            ExcelReaderHelper readDictionary = new ExcelReaderHelper();
            for (int i = 2; i <= 9; i++)
            {

                Dictionary<String, String> dicValues = readDictionary.ReadExcelRowByRow(i);

                Console.WriteLine("Value of i is " + i + "= Coloumn = " + dicValues["UserName"].ToString());
                Console.WriteLine("Value of i is " + i + "= Coloumn = " + dicValues["Password"].ToString());
                Console.WriteLine("Value of i is " + i + "= Coloumn = " + dicValues["Baseurl"].ToString());



                string UserName = dicValues["UserName"];
                string Password = dicValues["Password"];
                string Email = dicValues["Baseurl"];

                Console.WriteLine(UserName + "     " + Password + "     " + Email);

            }


        }
    }
}