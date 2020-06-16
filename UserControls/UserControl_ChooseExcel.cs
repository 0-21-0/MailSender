using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using OfficeOpenXml;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace MailSender.UserControls
{
    public partial class UserControl_ChooseExcel : UserControl
    {
        public string excelFullName;
        public UserControl_ChooseExcel()
        {
            InitializeComponent();
        }

        private void button_OpenExcel_Click(object sender, EventArgs e)
        {
            ChooseExcel(out excelFullName);
            if (excelFullName != null)
            {
                //var re = GetExcelTableByEPPuls(excelFullName);
                reoGridControl1.Load(excelFullName);
                var sheet = reoGridControl1.CurrentWorksheet;
                if (AutoGetDataTitleRowNumber() != 0)
                {

                }
                //textBox_SelectDataTitle.Text
                var temp = sheet.SelectionRange.Row.ToString();
                MessageBox.Show(temp);

            }
        }
        private void ChooseExcel(out string fileName)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                fileName = ofd.FileName;
            }
            else
            {
                fileName = null;
            }
        }
        private void GetExcelTableByNPOI(string excelPath)
        {
            IWorkbook workbook = null;
            string extension = System.IO.Path.GetExtension(excelPath);
            try
            {
                FileStream fs = File.OpenRead(excelPath);
                if (extension.Equals(".xls"))
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else
                {
                    workbook = new XSSFWorkbook(fs);
                }
                fs.Close();
                List<ISheet> sheets = new List<ISheet>();
                List<List<string>> values = new List<List<string>>();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public object GetExcelTableByEPPuls(string excelPath)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(excelPath)))
            {
                var r = richTextBox1;
                richTextBox1.Text = "";
                var d = package.Workbook.Worksheets[0];
                for(int i = 0; i < d.DataValidations.Count; i++)
                {

                }
            }
            object a = new object();
            return a;
        }

        private void textBox_SelectDataTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private int AutoGetDataTitleRowNumber()
        {
            var sheet = reoGridControl1.CurrentWorksheet;
            
            return 0;
        }
    }
}
