using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIAutoFramework.Helpers
{
   public class ExcelHelpers
    {
        //
        public static List<Datacollection> _dataCol = new List<Datacollection>();
        /// <summary>
        /// Storing all the excel values in to the in memory collection
        /// </summary>
        /// <param name="fileName"></param>
        public static void PopulateInCollectin(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);
            // Iterate through the rows and columns of the table
            for (int row = 1; row < table.Rows.Count-1; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()

                    };
                    // Add all the details for each row
                     _dataCol.Add(dtTable);
                }
                
            }
        }
        /// <summary>
        /// read all the data from excel sheet
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static DataTable ExcelToDataTable(string fileName)
        {
            //Open file and returns as stream
            FileStream fstream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            // create openxmlread via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fstream);
            // Set the first row as column
            excelReader.IsFirstRowAsColumnNames = true;
            // return as Dataset
            DataSet result = excelReader.AsDataSet();
            // Get all the tables
            DataTableCollection table = result.Tables;
            //Store it in the DataTable
            DataTable resultTable = table["Sheet1"];

            return resultTable;
        }    
        
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                // retrieving data using LINQ to reduec much of the iterations
                string data = (from colData in _dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                return data.ToString();
                
            } catch (Exception e)
            {
                return null;
            }
        }   
    }

    // a quick custom class all the data will be stored in the memory
    public class Datacollection
    {
        public int rowNumber{ get; set; }

        public string colName  { get; set; }

        public string  colValue{ get; set; }
    }
}
