using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MailSender
{
    struct ControlDefultSize
    {
        internal double Left;
        internal double Top;
        internal double Width;
        internal double Height;
        internal float FontSize;
        //Control control;
    }
    /// <summary>
    /// 对传入的Form或者UserControl在Size更改时进行控件的缩放
    /// 对Form进行FontSize的更改，其中的控件进行Location、Size的更改
    /// 使用方法：在Control中定义本类变量，在构造函数中构造变量，在SizeChange事件中使用ZoomControl方法
    /// </summary>
    class AdaptWindowSizeTool
    {
        //Form adaptForm;
        //UserControl adaptUserControl;
        Control adaptControl;
        float defaultFontSize;
        double defaultWidth;
        double defaultHeight;
        double horizontalZoomRate;
        double verticalZoomRate;
        Dictionary<string, ControlDefultSize> subControlsDefultSize;
        public AdaptWindowSizeTool(Control control)
        {
            //adaptForm = form;
            adaptControl = control;
            defaultFontSize = control.Font.Size;
            defaultWidth = control.Width;
            defaultHeight = control.Height;
            subControlsDefultSize = new Dictionary<string, ControlDefultSize>();
            RecordSubControls(control);
        }

        //public AdaptWindowSizeTool(UserControl userControl)
        //{
        //    //adaptUserControl = userControl;
        //    adaptControl = userControl;
        //    defultFontSize = userControl.Font.Size;
        //    defultWidth = userControl.Width;
        //    defultHeight = userControl.Height;
        //    RecordControls();
        //}

        /// <summary>
        /// 将一个控件中的自控件信息加入到相关list中
        /// </summary>
        /// <param name="control"></param>
        private void RecordSubControls(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item.Name.Trim() != "")
                {
                    var record = new ControlDefultSize
                    {
                        Left = item.Left,
                        Top = item.Top,
                        Width = item.Width,
                        Height = item.Height
                    };
                    if (item.Font.Size != defaultFontSize)
                        record.FontSize = item.Font.Size;
                    else
                        record.FontSize = (float)-1;
                    subControlsDefultSize.Add(item.Name, record);
                }
                if (item.Controls.Count > 0)
                {
                    RecordSubControls(item);
                }
            }
        }

        /// <summary>
        /// 对页面control进行缩放
        /// </summary>
        /// <param name="control"></param>
        internal void ZoomControl(Control control)
        {
            if (control == adaptControl) Console.WriteLine("没必要传入参数");
            horizontalZoomRate = (double)control.Width / (double)defaultWidth;
            verticalZoomRate = (double)control.Height / (double)defaultHeight;
            ChangeControlFontSize(control, defaultFontSize);
            ZoomSubControls(control);
        }

        private void ChangeControlFontSize(Control control, float defaultFontSize)
        {
            double zoomRate = Math.Abs(1 - verticalZoomRate) > Math.Abs(1 - horizontalZoomRate) ? horizontalZoomRate : verticalZoomRate;//取变化率较小的维度的值
            double newFontSize = defaultFontSize * zoomRate;
            newFontSize = Math.Round(newFontSize, 2);
            newFontSize = Math.Round(newFontSize, 1);
            newFontSize = Math.Round(newFontSize);
            if ((int)newFontSize == 0) return;
            control.Font = new Font(control.Font.FontFamily, (int)newFontSize);
        }

        /// <summary>
        /// 将一个控件中的子控件缩放
        /// </summary>
        /// <param name="control"></param>
        private void ZoomSubControls(Control control)
        {
            ControlDefultSize record;
            foreach (Control item in control.Controls)
            {
                if (item.Name.Trim() != "")
                {
                    record = subControlsDefultSize[item.Name];
                    item.Left = (int)(record.Left * horizontalZoomRate);
                    item.Top = (int)(record.Top * verticalZoomRate);
                    item.Width = (int)(record.Width * horizontalZoomRate);
                    item.Height = (int)(record.Height * verticalZoomRate);
                    if (record.FontSize != (float)-1)
                    {
                        ChangeControlFontSize(item, record.FontSize);
                    }
                }
                if (item.Controls.Count > 0)
                {
                    ZoomSubControls(item);
                }
            }
        }
    }
}
