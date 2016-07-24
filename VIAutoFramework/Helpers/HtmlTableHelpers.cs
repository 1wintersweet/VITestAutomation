using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIAutoFramework.Helpers
{
    /// <summary>
    /// Handle access to the HTML tables
    /// </summary>
    public class HtmlTableHelpers
    {
        private static List<TableDataCollection> _tableDataCollection;

        public static void ReadTable(IWebElement table)
        {
            //initialize the table
            _tableDataCollection = new List<TableDataCollection>();

            // Get all te columns from the table
            var columns = table.FindElements(By.TagName("th"));

            // get all the rows
            var rows = table.FindElements(By.TagName("tr"));

            // create row index
            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;

                var colData = row.FindElements(By.TagName("td"));

                //store data only if there is a value int he row
                if (colData.Count != 0)
                {
                    foreach (var colValue in colData)
                    {
                        _tableDataCollection.Add(new TableDataCollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = columns[colIndex].Text != "" ?
                                     columns[colIndex].Text : colIndex.ToString(),
                            ColumnValue = colValue.Text,
                            ColumnSpecialValues = GetControl(colValue)
                        });

                        // move to next column
                        colIndex++;
                    }
                    // move to next rolw
                    rowIndex++;
                }
            }
        }


        private static ColumnSpecialValue GetControl(IWebElement columnValue)
        {
            ColumnSpecialValue columnSpecialValue = null;
            // Check if the control has special tags like input/hyperlink etc.
            if (columnValue.FindElements(By.TagName("a")).Count> 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")), 
                      ControlType = "hyperlink"
                };
            }
            if (columnValue.FindElements(By.TagName("input")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };
            }
            return columnSpecialValue;
        }
        // 1. Controls column to operate
        // 2. which control in column to operate
        // 3. for which row
        // 4. for which column of the row (name of the employees etc)
        public static void PerformActionOnCell(string columnIndex, string refColumnName, string refColumnValue, string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _tableDataCollection
                            where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();

                // Need to operate on those controls
                if (controlToOperate != null && cell != null)
                {   
                    // Since based on the control type, the retriving of text changes
                    // created this kind of control
                    if (cell.ControlType == "hyperlink")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.Text == controlToOperate
                                               select c).SingleOrDefault();
                        //TODO: currently only click is supported
                        returnedControl?.Click();
                    }

                    if (cell.ControlType == "input")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.GetAttribute("value") == controlToOperate
                                               select c).SingleOrDefault();
                        // TODO, curently only click is supportd. 
                    }
                }
                else
                {
                    cell.ElementCollection?.First().Click();
                }
            }
        }

        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            // Dynmaic row
            foreach (var table in _tableDataCollection)
            {
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                {
                    yield return table.RowNumber;
                }
            }

        }
    }

    public class TableDataCollection
    {
        public int RowNumber { get; set; }

        public string ColumnName { get; set; }  

        public string ColumnValue { get; set; }

        public ColumnSpecialValue ColumnSpecialValues { get; set; }

    }

    public class ColumnSpecialValue
    {
        public IEnumerable<IWebElement> ElementCollection { get; set; } 

        public string ControlType { get; set; }
    }
}

