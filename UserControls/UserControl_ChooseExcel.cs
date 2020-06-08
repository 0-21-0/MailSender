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
                dataGridView1.DataSource = null;
                //ReadExcel(strFileName);
                //var re = GetExcelTableByOleDB(ofd.FileName, ofd.SafeFileName);
                OpenExcel(strFileName);
            }
        }
        private object OpenExcel(string fileName)
        {
            var file = File.OpenRead(fileName);
            
            byte[] message = new byte[file.Length];
            file.Read(message, 0, (int)file.Length);
            MessageBox.Show(message.ToString());
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
        public DataTable GetExcelTableByOleDB(string strExcelPath, string tableName)
        {
            try
            {
                DataTable dtExcel = new DataTable();
                //数据表
                DataSet ds = new DataSet();
                //获取文件扩展名
                string strExtension = System.IO.Path.GetExtension(strExcelPath);
                string strFileName = System.IO.Path.GetFileName(strExcelPath);
                //Excel的连接
                OleDbConnection objConn = null;
                switch (strExtension)
                {
                    case ".xls":
                        objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strExcelPath + ";" + "Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1;\"");
                        break;
                    case ".xlsx":
                        objConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExcelPath + ";" + "Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1;\"");
                        break;
                    default:
                        objConn = null;
                        break;
                }
                if (objConn == null)
                {
                    return null;
                }
                objConn.Open();
                //获取Excel中所有Sheet表的信息
                //System.Data.DataTable schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                //获取Excel的第一个Sheet表名
                //string tableName = schemaTable.Rows[0][2].ToString().Trim();
                string strSql = "select * from [" + tableName + "]";
                //获取Excel指定Sheet表中的信息
                OleDbCommand objCmd = new OleDbCommand(strSql, objConn);
                OleDbDataAdapter myData = new OleDbDataAdapter(strSql, objConn);
                myData.Fill(ds, strExcelPath);//填充数据
                objConn.Close();
                //dtExcel即为excel文件中指定表中存储的信息
                dtExcel = ds.Tables[tableName];
                return dtExcel;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
