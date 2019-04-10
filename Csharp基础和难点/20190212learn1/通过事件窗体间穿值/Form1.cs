using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 通过事件窗体间穿值
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2(Form2_setValue); //通过委托的方式

            form2.setValue += Form2_setValue;//订阅子窗体的事件            
            form2.Show();
        }

        private void Form2_setValue(string obj)
        {
            textBox1.Text = obj;
        }
    }
}
