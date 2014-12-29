using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;
using System.IO;

namespace CWXT.CustomControls
{
    public partial class VerificationCode : EnterpriseWebsite.WebUI.ScrollPage
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //生成4位的验证码
            this.ValidateCode(this.Code = RndNum(4));
        }

        private string Code
        {
            set { this.Session["__VerificationCode"] = value; }
        }

        private void ValidateCode(string VNum)
        {
            Bitmap Img = null;
            Graphics g = null;
            MemoryStream ms = null;
            int gheight = VNum.Length * 14;
            Img = new Bitmap(gheight, 22);
            g = Graphics.FromImage(Img);

            #region Andy Modify 2007-3-23
            /* ******************************************************************** */
            /* Andy Modify 2007-3-23 */
            // 背景颜色
            g.Clear(System.Drawing.ColorTranslator.FromHtml("#eaeaea"));

            Random random = new Random();
            //画图片的背景噪音线
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(Img.Width);
                int x2 = random.Next(Img.Width);
                int y1 = random.Next(Img.Height);
                int y2 = random.Next(Img.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, Img.Width, Img.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(VNum, font, brush, 2, 2);

            //画图片的前景噪音点
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(Img.Width);
                int y = random.Next(Img.Height);

                Img.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            /* ******************************************************************** */

            //			//背景颜色
            //			g.Clear(System.Drawing.ColorTranslator.FromHtml("#eaeaea"));
            //
            //			//文字字体
            //			Font f=new Font("Arial Black",11);
            //
            //			//文字颜色
            //			SolidBrush s=new SolidBrush(Color.Black);
            //
            //			g.DrawString(VNum,f,s,(float)0.5,(float)0.5);
            #endregion

            ms = new MemoryStream();
            Img.Save(ms, ImageFormat.Jpeg);
            Response.ClearContent();
            Response.ContentType = "image/Jpeg";
            Response.BinaryWrite(ms.ToArray());

            g.Dispose();
            Img.Dispose();
            Response.End();
        }

        private string RndNum(int VcodeNum)
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            string[] VcArray = Vchar.Split(new Char[] { ',' });
            string VNum = "";
            int temp = -1;

            Random rand = new Random();

            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(35);
                if (temp != -1 && temp == t)
                {
                    return RndNum(VcodeNum);
                }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion
    }
}