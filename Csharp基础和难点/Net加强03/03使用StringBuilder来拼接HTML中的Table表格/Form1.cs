using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03使用StringBuilder来拼接HTML中的Table表格
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<table bgcolor = 'red' border = '1px' cellpadding = '0px' cellspacing = '0px'>");
            sb.Append("<tr>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("<td>我是被动态加载出来的</td>");
            sb.Append("</tr>");
         
            sb.Append("</table>");
            sb.Append("</body>");
            sb.Append("</html>");

            webBrowser1.DocumentText = sb.ToString();
        }
    }
}
