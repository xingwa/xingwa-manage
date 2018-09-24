using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace iform
{
    public class AppForm : xingwaWinFormUI.MainWinForm
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AppForm
            // 
            this.ClientSize = new System.Drawing.Size(746, 518);
            this.Name = "AppForm";
            this.ResumeLayout(false);

        }
    }
}
