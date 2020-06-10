namespace MailSender.UserControls
{
    partial class UserControl_ChooseExcel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.button_RestoreExcel = new System.Windows.Forms.Button();
            this.button_SaveExcel = new System.Windows.Forms.Button();
            this.button_OpenExcel = new System.Windows.Forms.Button();
            this.reoGridControl1 = new unvell.ReoGrid.ReoGridControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1055, 542);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 35);
            this.button4.TabIndex = 2;
            this.button4.Text = "编辑邮件";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_RestoreExcel
            // 
            this.button_RestoreExcel.Location = new System.Drawing.Point(318, 17);
            this.button_RestoreExcel.Name = "button_RestoreExcel";
            this.button_RestoreExcel.Size = new System.Drawing.Size(123, 35);
            this.button_RestoreExcel.TabIndex = 3;
            this.button_RestoreExcel.Text = "还原修改";
            this.button_RestoreExcel.UseVisualStyleBackColor = true;
            // 
            // button_SaveExcel
            // 
            this.button_SaveExcel.Location = new System.Drawing.Point(174, 17);
            this.button_SaveExcel.Name = "button_SaveExcel";
            this.button_SaveExcel.Size = new System.Drawing.Size(123, 35);
            this.button_SaveExcel.TabIndex = 4;
            this.button_SaveExcel.Text = "保存修改";
            this.button_SaveExcel.UseVisualStyleBackColor = true;
            this.button_SaveExcel.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_OpenExcel
            // 
            this.button_OpenExcel.Location = new System.Drawing.Point(22, 17);
            this.button_OpenExcel.Name = "button_OpenExcel";
            this.button_OpenExcel.Size = new System.Drawing.Size(123, 35);
            this.button_OpenExcel.TabIndex = 5;
            this.button_OpenExcel.Text = "打开Excel";
            this.button_OpenExcel.UseVisualStyleBackColor = true;
            this.button_OpenExcel.Click += new System.EventHandler(this.button_OpenExcel_Click);
            // 
            // reoGridControl1
            // 
            this.reoGridControl1.BackColor = System.Drawing.Color.White;
            this.reoGridControl1.ColumnHeaderContextMenuStrip = null;
            this.reoGridControl1.LeadHeaderContextMenuStrip = null;
            this.reoGridControl1.Location = new System.Drawing.Point(22, 70);
            this.reoGridControl1.Name = "reoGridControl1";
            this.reoGridControl1.RowHeaderContextMenuStrip = null;
            this.reoGridControl1.Script = null;
            this.reoGridControl1.SheetTabContextMenuStrip = null;
            this.reoGridControl1.SheetTabNewButtonVisible = true;
            this.reoGridControl1.SheetTabVisible = true;
            this.reoGridControl1.SheetTabWidth = 60;
            this.reoGridControl1.ShowScrollEndSpacing = true;
            this.reoGridControl1.Size = new System.Drawing.Size(1156, 457);
            this.reoGridControl1.TabIndex = 8;
            this.reoGridControl1.Text = "reoGridControl1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(22, 70);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1156, 457);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // UserControl_ChooseExcel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.reoGridControl1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button_RestoreExcel);
            this.Controls.Add(this.button_SaveExcel);
            this.Controls.Add(this.button_OpenExcel);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "UserControl_ChooseExcel";
            this.Size = new System.Drawing.Size(1200, 600);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_RestoreExcel;
        private System.Windows.Forms.Button button_SaveExcel;
        private System.Windows.Forms.Button button_OpenExcel;
        private unvell.ReoGrid.ReoGridControl reoGridControl1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
