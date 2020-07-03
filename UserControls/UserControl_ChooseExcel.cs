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
using unvell.ReoGrid;

namespace MailSender.UserControls
{
    public partial class UserControl_ChooseExcel : UserControl
    {
        private AdaptWindowSizeTool adaptTool;
        public string excelFullName;
        public UserControl_ChooseExcel()
        {
            InitializeComponent();
            adaptTool = new AdaptWindowSizeTool(this);
        }

        private void button_OpenExcel_Click(object sender, EventArgs e)
        {
            ChooseExcel(out excelFullName);
            if (excelFullName != null)
            {
                reoGridControl1.Load(excelFullName);
                var sheet = reoGridControl1.CurrentWorksheet;
                if (AutoGetDataTitleRowNumber() != 0)
                {

                }
                //textBox_SelectDataTitle.Text
                reoGridControl1.CurrentWorksheetChanged += ReoGridControl1_CurrentWorksheetChanged;
            }
        }

        private void ReoGridControl1_CurrentWorksheetChanged(object sender, EventArgs e)
        {
            ColWidthMatch(reoGridControl1.CurrentWorksheet);
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

        private void ColWidthMatch(Worksheet sheet)
        {
            int MaxColWidth;
            foreach (var columnHeader in sheet.ColumnHeaders)
            {
                MaxColWidth = columnHeader.Width;
                Cell cell = sheet.GetCell(0, columnHeader.Index);
                if (cell == null)
                    return;
                label_CellText.Font = new Font(cell.Style.FontName, cell.Style.FontSize);
                for (int i = 1; i < sheet.RowCount; i++)
                {
                    if (sheet[i, columnHeader.Index] == null)
                        continue;
                    label_CellText.Text = sheet[i, columnHeader.Index].ToString();
                    if (label_CellText.Width >= MaxColWidth)
                    {
                        MaxColWidth = label_CellText.Width;
                    }
                    else
                    {
                        break;
                    }
                }
                columnHeader.Width = (ushort)MaxColWidth;
            }
        }

        private void UserControl_ChooseExcel_SizeChanged(object sender, EventArgs e)
        {
            adaptTool.ZoomControl(this);
        }
    }
}
