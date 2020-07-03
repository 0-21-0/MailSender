using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Net;
using MailSender.UserControls;

namespace MailSender
{
    public partial class MainForm : Form
    {
        private readonly UserControl_ChooseExcel chooseExcel;
        private readonly UserControl_EditMail editMail;
        public MainForm()
        {
            InitializeComponent();
            chooseExcel = new UserControl_ChooseExcel();
            editMail = new UserControl_EditMail();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowUserControl(chooseExcel);
            //ShowUserControl(editMail);
        }

        private void ShowUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel_ContentShow.Controls.Clear();
            panel_ContentShow.Controls.Add(userControl);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show(panel_ContentShow.Size.ToString() + '\n' + panel_ContentShow.Controls[0].Size.ToString());
            
        }
    }
}
