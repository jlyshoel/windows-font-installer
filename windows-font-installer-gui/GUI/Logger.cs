using System;
using System.Windows.Forms;

namespace JLyshoel.FontInstaller.GUI
{
    public class Logger
    {
        delegate void AddTextCallback(Form f, Control ctrl, string text);
        public static void AddText(Form form, Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                AddTextCallback d = new AddTextCallback(AddText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text += text + "\r\n";
            }
        }

        private readonly Form form;
        private readonly Control ctrl;
        public Logger(Form form, Control ctrl)
        {
            this.form = form;
            this.ctrl = ctrl;
        }

        public void AddText(string text)
        {
            AddText(form, ctrl, text);
        }

    }
}
