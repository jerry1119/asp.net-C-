using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 资料管理器
{
    public partial class AddNote : Form
    {
        private int noteId;
        private Action newMethod;

        public AddNote()
        {
            InitializeComponent();
        }
        //使用action委托将主窗体刷新方法传递过来
        public AddNote(int noteId, Action newMethod):this()//这里写个:this表示继承自构造函数addnote，在addnote执行完后就会执行这个方法
        {
            this.noteId = noteId;
            this.newMethod = newMethod;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.获取要插入的数据
            string nodeName = textBox1.Text.Trim();
            string nodeInfo = textBox2.Text.Trim();
            //2.插入数据
            //向数据库中插入空值，不能插入c#中的null，必须使用dbNull.value
            string sql = "insert into Category values(@tName,@tParentId,@tNote)";
            SqlParameter[] pars = {
                new SqlParameter("@tName",SqlDbType.NVarChar,100){ Value=nodeName},
                new SqlParameter("@tParentId",SqlDbType.Int){ Value = noteId},
                new SqlParameter("@tNote",SqlDbType.NVarChar,1000){ Value=nodeInfo}
            };
            int r = SqlHelper.ExcuteNoquery(sql, CommandType.Text, pars);
            if (r > 0)
            {
                MessageBox.Show("插入成功");
                this.newMethod();
                this.Close();
            }
            else
            {
                MessageBox.Show("添加失败");
            }
            
        }
         
    }
}
