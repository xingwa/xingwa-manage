using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace digFaimilys
{
    public partial class MainApp : iform.AppForm
    {
        public MainApp()
        {
            InitializeComponent();
            CefSettings settings = new CefSettings();
            settings.Locale = "zh-CN";
            settings.AcceptLanguageList = "zh-CN";
            Cef.Initialize(settings);
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            this.CloseNormlBack = photoApp.Properties.Resources.btn_close_disable;
            this.MiniNormlBack = photoApp.Properties.Resources.btn_mini_normal;

            this.BorderPalace = photoApp.Properties.Resources.BackPalace;
            this.SysBottomNorml = photoApp.Properties.Resources.btn_set_normal;

            this.BackColor = ColorTranslator.FromHtml("#EBF2F9");


            int y = 0;
            int z = 0;
            for (int i = 1; i <= 20; i++)
            {
                xingwaWinFormUI.SkinControl.SkinPanel imgIcoDiv = new xingwaWinFormUI.SkinControl.SkinPanel();
                imgIcoDiv.BackColor = System.Drawing.Color.Gray;
                imgIcoDiv.ControlState = xingwaWinFormUI.SkinClass.ControlState.Normal;
                imgIcoDiv.DownBack = null;
                imgIcoDiv.Location = new System.Drawing.Point(0, 0);
                imgIcoDiv.MouseBack = null;
                imgIcoDiv.Name = "imgIco";
                imgIcoDiv.Tag = i;
                imgIcoDiv.NormlBack = null;
                imgIcoDiv.Radius = 2;
                imgIcoDiv.Size = new System.Drawing.Size(55, 45);
                imgIcoDiv.TabIndex = 1;
                imgIcoDiv.Click += ImgIcoDiv_Click;
                // 
                // labelText
                // 
                xingwaWinFormUI.SkinControl.SkinLabel labelTextFont = new xingwaWinFormUI.SkinControl.SkinLabel();
                labelTextFont.AutoSize = true;
                labelTextFont.BackColor = System.Drawing.Color.Transparent;
                labelTextFont.BorderColor = System.Drawing.Color.Transparent;
                labelTextFont.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                labelTextFont.Location = new System.Drawing.Point(0, 50);
                labelTextFont.Name = "labelText";
                labelTextFont.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                labelTextFont.Size = new System.Drawing.Size(55, 15);
                labelTextFont.TabIndex = 2;
                labelTextFont.Text = "数字家"+i;



                xingwaWinFormUI.SkinControl.SkinPanel icoDiv = new xingwaWinFormUI.SkinControl.SkinPanel();
                icoDiv.BackColor = System.Drawing.Color.Transparent;
                icoDiv.Controls.Add(labelTextFont);
                icoDiv.Controls.Add(imgIcoDiv);
                icoDiv.ControlState = xingwaWinFormUI.SkinClass.ControlState.Normal;
                icoDiv.DownBack = null;
                z++;
                if (z % 5 == 0)
                {
                    y++;
                    icoDiv.Location = new System.Drawing.Point(12 , 12 + y * 80);
                    z = 1;
                }
                else
                {
                    icoDiv.Location = new System.Drawing.Point(12 + (z -1) * 65, 12 + y * 80);
                }
               
                icoDiv.MouseBack = null;
                icoDiv.Name = "ico";
                icoDiv.NormlBack = null;
                icoDiv.Size = new System.Drawing.Size(55, 75);
                icoDiv.TabIndex = 0;

                this.tagIco.Controls.Add(icoDiv);



            }

        }

        private void ImgIcoDiv_Click(object sender, EventArgs e)
        {
            xingwaWinFormUI.SkinControl.SkinPanel obj = (xingwaWinFormUI.SkinControl.SkinPanel)sender;
            if ( int.Parse( obj.Tag.ToString()) == 2)
            {

                try
                {
                  //  Cef.Shutdown();
                }
                catch (Exception)
                {

                   // throw;
                }

              

                 ChromiumWebBrowser CWebBrowser  =  new ChromiumWebBrowser(null); ;

      

                string dllPath = "managementBackend.dll";
                Assembly assembly = Assembly.LoadFile(Environment.CurrentDirectory + "\\" + dllPath);
                Type type = assembly.GetType("managementBackend.backend");
                object o = Activator.CreateInstance(type);
                MethodInfo method = type.GetMethod("winformShow");
                object[] objs = { CWebBrowser };
                method.Invoke(o, objs);


                //                assembly asm = assembly.loadfrom(appdomain.currentdomain.basedirectory + "/declaredll/yundoutaxlib.dll");////我们要调用的dll文件路径
                //                                                                                                                         //加载dll后,需要使用dll中某类.
                //                type t = asm.gettype("namespace.classname");//获取类名，必须 命名空间+类名  

                //                //实例化类型
                //                object o = activator.createinstance(t);

                //                //得到要调用的某类型的方法
                //                methodinfo method = t.getmethod("functionname");//functionname:方法名字

                //                object[] obj =
                //                {
                //     parameters[0].taxpayername,
                //     parameters[0].taxpayertaxcode,
                //     parameters[0].capassword
                //};
                //                //对方法进行调用
                //                var keydata = method.invoke(o, obj);//param为方法参数object数组


            }
        }
    }
}
