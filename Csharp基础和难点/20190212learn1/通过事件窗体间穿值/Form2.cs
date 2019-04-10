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
    public partial class Form2 : Form
    {
        
        private Action<string> form2_setValue;

        public Form2()
        {
            InitializeComponent();
        }

        

        public Form2(Action<string> form2_setValue):this()
        {
            this.form2_setValue = form2_setValue;
        }

        public event Action<string> setValue;
        
        private void button1_Click(object sender, EventArgs e)
        {
            //通过委托的方式
            this.form2_setValue(textBox1.Text);     
            //通过事件的方式
            if (setValue != null)
            {
                setValue(textBox1.Text);
            }
            else
            {
                MessageBox.Show("没人订阅这个事件");
            }
        }      
    }
}
