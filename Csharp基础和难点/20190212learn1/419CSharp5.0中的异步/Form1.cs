using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _419CSharp5._0中的异步
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string text = await client.GetStringAsync("http://csharpindepth.com");
                label1.Text = text.Length.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
