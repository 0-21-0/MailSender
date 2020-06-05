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

namespace MailSender
{
    public partial class MainForm : Form
    {
        //private readonly string uid = "468335336";
        //private readonly string pwd = "stwosfqbtbdgbjae";
        private readonly string uid = "accept_963211782";     
        private readonly string pwd = "PHHSMSAFITPIGIBO";
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MailAddress from = new MailAddress("468335336@qq.com");
            MailAddress from = new MailAddress("accept_963211782@163.com");
            MailAddress to = new MailAddress("963211782@qq.com");
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = "Test";//邮件主题
            mailMessage.Body = "Hello, world!!";//邮件正文  

            //添加附件  

            //string file1 = "test.txt";
            //Attachment attachment1 = new Attachment(file1, MediaTypeNames.Text.Plain);
            ////为附件天剑时间信息  
            //ContentDisposition disposition1 = attachment1.ContentDisposition;
            //disposition1.CreationDate = File.GetCreationTime(file1);
            //disposition1.ModificationDate = File.GetLastWriteTime(file1);
            //disposition1.ReadDate = File.GetLastAccessTime(file1);
            //mailMessage.Attachments.Add(attachment1);

            //string file2 = "test.doc";
            //Attachment attachment2 = new Attachment(file2);
            ////为附件添加时间信息  
            //ContentDisposition disposition2 = attachment2.ContentDisposition;
            //disposition2.CreationDate = File.GetCreationTime(file2);
            //disposition2.ModificationDate = File.GetLastWriteTime(file2);
            //disposition2.ReadDate = File.GetLastAccessTime(file2);
            //mailMessage.Attachments.Add(attachment2);

            //实例化SmtpClient  
            //SmtpClient smtpClient = new SmtpClient("smtp.qq.com", 25);
            SmtpClient smtpClient = new SmtpClient("smtp.163.com", 25);
            //设置验证发件人身份的凭据  
            var aa = smtpClient.Credentials = new NetworkCredential(uid, pwd);

            //发送  
            smtpClient.Send(mailMessage);

            //Console.WriteLine("OK - [{0}]", i);
        }
    }
}
