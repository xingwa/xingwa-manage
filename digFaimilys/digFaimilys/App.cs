using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace digFaimilys
{
    public partial class App :iform.AppForm
    {
        public App()
        {
            InitializeComponent();

        }

        private void App_Load(object sender, EventArgs e)
        {
           
          //   MessageBox.Show(photoApp.photo.GetBitmap("btn_close_disable.png").ToString());
           this.CloseNormlBack = photoApp.Properties.Resources.btn_close_disable;
           this.MiniNormlBack = photoApp.Properties.Resources.btn_mini_normal;

            
            this.BackgroundImage = photoApp.Properties.Resources.login_ui;
            this.BorderPalace = photoApp.Properties.Resources.BackPalace;
            this.SysBottomNorml = photoApp.Properties.Resources.btn_set_normal;

            this.BackColor = ColorTranslator.FromHtml("#EBF2F9");

            //this.TransparencyKey = ColorTranslator.FromHtml("#069DD6");

        }

        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(App));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);


            }
            foreach (Control ctl in this.btnDiv.Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }

           
            res.ApplyResources(this.proxySettings, this.proxySettings.Name);
            res.ApplyResources(this.doNotUseAProxy, this.doNotUseAProxy.Name);
            res.ApplyResources(this.browserAgent, this.browserAgent.Name);
            res.ApplyResources(this.serverAgent, this.serverAgent.Name);


            this.ResumeLayout(false);
            this.PerformLayout();
            res.ApplyResources(this, "$this");
        }

     

        private void App_SysBottomClick(object sender)
        {
            this.multiLanguage.Show(MousePosition.X, MousePosition.Y);
        }

     

        private void china_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("zh-CN");
            ApplyResource();

        }

        private void taiwan_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("zh-TW");
            ApplyResource();
            this.taiwan.Checked = true;
        }

        private void english_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en");
            ApplyResource();
            this.english.Checked = true;
        }

        private void ja_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ja");
            ApplyResource();
        }

        private void ko_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ko");
            ApplyResource();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // workfere.HttpRequestClient.HttpRequestClient httpRequestClient = new workfere.HttpRequestClient.HttpRequestClient();
            //string conent= httpRequestClient.httpGet("https://www.cnblogs.com/zetee/p/7064915.html", "");
            // MessageBox.Show(conent);
            MainApp mainApp = new MainApp();
            mainApp.Show();

        }

        private void btn_login_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
