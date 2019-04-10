using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 资料管理器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //从数据库中根据父节点读取所有类别,加载到treeview节点上
            NewMethod();
        }

        private void NewMethod()
        {
            this.treeView1.Nodes.Clear();
            LoadDataToTree(-1, treeView1.Nodes);
        }

        private void LoadDataToTree(int parentID, TreeNodeCollection nodes)
        {
            
            //根据父ID查询下面的数据
            List<Category> list =  GetDataByPID(parentID);
            //遍历数据把每个数据加载到treeview节点 nodes上
            foreach (var item in list)
            {
                TreeNode treeNode =  nodes.Add(item.tName);
                treeNode.Tag = item.tId;
                LoadDataToTree(item.tId, treeNode.Nodes);
            }
        }
        //根据父ID查询数据
        private List<Category> GetDataByPID(int parentID)
        {
            string sql = "select tId, tName from Category where  tParentId=@tParentId";
            SqlParameter par = new SqlParameter("@tParentId", SqlDbType.Int) { Value = parentID };
            List<Category> list = new List<Category>();
            using (SqlDataReader reader = SqlHelper.ExcuteReader(sql, CommandType.Text, par))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Category category = new Category();
                        category.tId = reader.GetInt32(0);
                        category.tName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        list.Add(category);
                    }
                }
            }
            return list;
        }
        //节点的双击时间
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //1.获取当前是点击的哪个节点
            //2.获取节点的id
            int categoryID = (int)e.Node.Tag;
            //根据id获取数据
            GetContentByTid(categoryID);
        }

        private void GetContentByTid(int Tid)
        {
            string sql = "select dId,dName from ContentInfo where dTId = @dTid";
            SqlParameter par = new SqlParameter("@dTid", SqlDbType.Int) { Value = Tid };
            List<ContentInfo> list = new List<ContentInfo>();
            using (SqlDataReader reader = SqlHelper.ExcuteReader(sql, CommandType.Text, par))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContentInfo content = new ContentInfo();
                        content.dId = reader.GetInt32(0);
                        content.dName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        list.Add(content);                      
                    }
                }
            }
            listBox1.DataSource = list;
        }
        //选择的标题的改变事件
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                //1.获取当前选中的item的id
                ContentInfo content = listBox1.SelectedItem as ContentInfo;
                int currentId = content.dId;
                //2.根据id查询出文章的内容
                this.richTextBox1.Text =  LoadContent(currentId);
            }
            
        }
        //根据文章id查询出内容
        private string LoadContent(int currentId)
        {
            string sql = "select dContent from ContentInfo where dId = @dId";
            SqlParameter par = new SqlParameter("@dId", SqlDbType.Int) { Value = currentId };
            object content = SqlHelper.ExcuteScaler(sql, CommandType.Text, par);
            return content==null?string.Empty:content.ToString(); //这里忘了判断是否为空了
        }
        //增加一级类别
        private void 添加父节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNote add = new AddNote(-1, NewMethod);
            add.Show();
        }
        //在当前节点增加子类别
        private void 添加子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                int noteId = (int)treeView1.SelectedNode.Tag;
                AddNote add = new AddNote(noteId,NewMethod);
                add.Show();
            }
            else
            {
                MessageBox.Show("请选择节点");
            }
        }

        private void vfdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //1、判断用户是否选择了类别
            if (treeView1.SelectedNode != null)
            {
                //2.获取选择的节点id
                int categoryId = (int)treeView1.SelectedNode.Tag;
                FolderBrowserDialog fbg = new FolderBrowserDialog();
                DialogResult result = fbg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //3.获取用户选择的路径
                    string filePath = fbg.SelectedPath;
                    string [] txtPaths  = Directory.GetFiles(filePath, "*.txt", SearchOption.AllDirectories);
                    foreach (var txtPath in txtPaths)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(txtPath);
                        string fileContent = File.ReadAllText(txtPath,Encoding.Default); //这里忘了设置编码格式了
                        //将文件导入sql
                        inportFile(categoryId,fileName,fileContent);
                    }
                    GetContentByTid(categoryId);
                }
            }
            else
            {
                MessageBox.Show("请选择类别");
            }
            
            
        }

        private void inportFile(int categoryId, string fileName, string fileContent)
        {
            string sql = "insert into ContentInfo values(@dTId, @dName, @dContent, @dInTime, @dEditeTime, @dIsDeleted)";
            SqlParameter[] pars = {
                new SqlParameter("@dTId",SqlDbType.Int){ Value = categoryId},
                new SqlParameter("@dName",SqlDbType.NVarChar,100){ Value = fileName},
                new SqlParameter("@dContent",SqlDbType.NVarChar){ Value = fileContent},
                new SqlParameter("@dInTime",SqlDbType.DateTime){ Value = DateTime.Now},
                new SqlParameter("@dEditeTime",SqlDbType.DateTime){ Value = DateTime.Now},
                new SqlParameter("@dIsDeleted",SqlDbType.Bit){ Value=false}
            };
            SqlHelper.ExcuteNoquery(sql, CommandType.Text, pars);
           
        }
    }
}
