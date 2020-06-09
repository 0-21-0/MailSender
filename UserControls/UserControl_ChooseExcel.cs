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

namespace MailSender.UserControls
{
    public partial class UserControl_ChooseExcel : UserControl
    {
        public UserControl_ChooseExcel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button_OpenExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string strFileName = ofd.FileName;
                //其他代码
                //dataGridView1.DataSource = null;
                //ReadExcel(strFileName);
                var re = GetExcelTableByOleDB(ofd.FileName, ofd.SafeFileName);
                //OpenExcel(strFileName);
            }
        }
        private object OpenExcel(string fileName)
        {
            var file = File.OpenRead(fileName);
            
            byte[] message = new byte[file.Length];
            file.Read(message, 0, (int)file.Length);
            MessageBox.Show(Encoding.Unicode.GetString(message));
            file.Close();
            return fileName;
        }
        private DataSet ReadExcel(string pFileName)
        {
            if (pFileName.Equals(""))
            {
                return null;
            }

            string vConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=Excel 8.0;", pFileName);
            OleDbDataAdapter vExcelAdapter = new OleDbDataAdapter("SELECT *  FROM [Sheet1$]", vConn);
            DataSet vData = new DataSet();
            try
            {
                vExcelAdapter.Fill(vData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return vData;
        }
        public object GetExcelTableByOleDB(string strExcelPath, string tableName)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(strExcelPath)))
            {
                var r = richTextBox1;
                richTextBox1.Text = "";
                var d = package.Workbook.Worksheets[0].Cells;
                int rows = d.Rows;
                var f = d.DataValidation;
                MessageBox.Show(f.ToString());
                int columns = d.Columns;
                for(int i = 1; i<= 3; i++)
                {
                    for(int j = 1; j<=4; j++)
                    {
                        var call = d[i, j];
                        r.Text += call.Value;
                        r.Text += " ";
                    }
                    r.Text += "\n";
                }
                //r.Text += d[d.End.Column,d.End.Row].Value;
                //for(int i = 0; i < b.Index; i++)
                //{
                //    var col = b.Column(i);
                //    richTextBox1.Text += col.ToString() + "\n";
                //}
                
                //r.Text += b.Cells.FullAddress;
            }
            object a = new object();
            return a;
        }
    }
}
