using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace ExcelReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = "";
            OpenFileDialog fdlg=new OpenFileDialog();
            fdlg.Title = "Excel File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
            }
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange= xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //dt.Column = colCount;
            dataGridView1.ColumnCount = colCount;
            dataGridView1.RowCount = rowCount;

            for (int i= 1; i <= rowCount; i++)
            {
                for (int j= 1; j <= colCount; j++)
                {
                    //write the value yo the Grid

                       if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        dataGridView1.Rows[i - 1].Cells[j - 1].Value = xlRange.Cells[i, j].Value2.ToString();
                    }
                    
                    //Check here again!
                }
            }
             
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            


        }
    }
}
