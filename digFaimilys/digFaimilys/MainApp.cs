using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace digFaimilys
{
    public partial class MainApp : iform.AppForm
    {
        public MainApp()
        {
            InitializeComponent();
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
                imgIcoDiv.NormlBack = null;
                imgIcoDiv.Radius = 2;
                imgIcoDiv.Size = new System.Drawing.Size(55, 45);
                imgIcoDiv.TabIndex = 1;
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
    }
}
