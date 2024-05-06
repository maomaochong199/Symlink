using System;
using System.Diagnostics; // 用于执行CMD命令
using System.IO; // 用于检查文件是否存在
using System.Windows.Forms;

// 作者: Octanum
namespace Symlink
{
    public partial class Symlink : Form
    {
        public Symlink()
        {
            InitializeComponent();

            // 设置窗体和textBox_Link允许拖放
            this.AllowDrop = true;
            this.textBox_Link.AllowDrop = true;
            this.textBox_Target.AllowDrop = true;

            // 为textBox_Link和textBox_Target添加事件处理程序
            this.textBox_Link.DragEnter += new DragEventHandler(textBox_DragEnter);
            this.textBox_Link.DragDrop += new DragEventHandler(textBox_DragDrop);
            this.textBox_Target.DragEnter += new DragEventHandler(textBox_DragEnter);
            this.textBox_Target.DragDrop += new DragEventHandler(textBox_DragDrop);

        }

        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            // 检查拖动数据是否包含文件
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // 允许复制操作
            }
            else
            {
                e.Effect = DragDropEffects.None; // 不允许其他类型的拖动操作
            }
        }

        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            // 获取拖动的文件数组
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // 将第一个文件（或所有文件）的路径添加到文本框中
            if (files != null && files.Length > 0)
            {
                // 由于sender是object类型，我们需要将其转换为TextBox
                TextBox textBox = (TextBox)sender;
                textBox.Text = files[0]; // 只添加第一个文件路径

                // 如果需要添加所有文件的路径，可以使用以下代码：
                // string filePaths = string.Join(Environment.NewLine, files);
                // textBox.Text = filePaths;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // 设置所有选项
            comboBox_Type.Items.Add("文件软链接（默认）");
            comboBox_Type.Items.Add("目录软链接（/D）");
            comboBox_Type.Items.Add("文件硬链接（/H）");
            comboBox_Type.Items.Add("目录硬链接（/J）");

            // 强制用户选择索引0，防止不选择任何选项
            comboBox_Type.SelectedIndex = 0;

            UpdateCMDCommand();
        }

        private void comboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 为了避免用户混淆，切换选项后重置他们的选择
            // 这样可以避免目录和文件的混合
            textBox_Link.Text = "";
            textBox_Target.Text = "";

            UpdateCMDCommand();
        }

        private void button_BrowseLink_Click(object sender, EventArgs e)
        {
            if (comboBox_Type.SelectedIndex == 0 || comboBox_Type.SelectedIndex == 2) // 文件浏览/保存
            {
                DialogResult result = saveFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    textBox_Link.Text = saveFileDialog1.FileName;

                    UpdateCMDCommand();
                }
            }
            else // 文件夹浏览
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    textBox_Link.Text = folderBrowserDialog1.SelectedPath;

                    UpdateCMDCommand();
                }
            }
        }

        private void button_BrowseTarget_Click(object sender, EventArgs e)
        {
            if (comboBox_Type.SelectedIndex == 0 || comboBox_Type.SelectedIndex == 2) // 文件浏览
            {
                DialogResult result = openFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    textBox_Target.Text = openFileDialog1.FileName;

                    UpdateCMDCommand();
                }
            }
            else // 文件夹浏览
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    textBox_Target.Text = folderBrowserDialog1.SelectedPath;

                    UpdateCMDCommand();
                }
            }
        }

        private void button_CreateLink_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (textBox_Link.Text == "" || textBox_Target.Text == "") // 检查是否在未做任何操作的情况下点击了提交
            {
                error = true;
                MessageBox.Show("必须指定文件/目录。");
            }
            else if (textBox_Link.Text == textBox_Target.Text)
            {
                error = true;
                MessageBox.Show("链接不能与目标相同。");
            }
            else if (comboBox_Type.SelectedIndex == 0 || comboBox_Type.SelectedIndex == 2) // 文件链接
            {
                if (File.Exists(textBox_Link.Text)) // 这意味着用户可能想要用新的链接替换现有文件，但由于符号链接的安全性和限制，我们必须先删除它
                {
                    if (MessageBox.Show("替换 " + textBox_Link.Text + "?", "确认删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(textBox_Link.Text);
                    }
                    else
                    {
                        error = true;
                        MessageBox.Show("不替换 " + textBox_Link.Text + " 无法继续。");
                    }
                }

                if (!File.Exists(textBox_Target.Text)) // 检查目标文件是否存在
                {
                    error = true;
                    MessageBox.Show("您在“目标”文本框中指定的文件不存在。");
                }
            }
            else // 目录链接
            {
                if (Directory.Exists(textBox_Link.Text)) // 我们将替换用户可能创建的“新文件夹”
                {
                    if (MessageBox.Show("替换 " + textBox_Link.Text + "?", "确认删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Directory.Delete(textBox_Link.Text);
                    }
                    else
                    {
                        error = true;
                        MessageBox.Show("不替换 " + textBox_Link.Text + " 无法继续。");
                    }
                }

                if (!Directory.Exists(textBox_Target.Text)) // 检查目标目录是否存在
                {
                    error = true;
                    MessageBox.Show("您在“目标”文本框中指定的文件夹不存在。");
                }
            }


            // 如果没有错误，我们现在创建实际链接
            if (error == false)
            {
                // 创建一个新的进程对象
                Process processSymlink = new Process();
                // 创建进程启动信息对象
                ProcessStartInfo startInfoSymlink = new ProcessStartInfo();
                // 设置要运行的程序为cmd.exe
                startInfoSymlink.FileName = "cmd.exe";

                // 根据comboBox_Type的选择设置链接类型
                string linkType = " ";
                if (comboBox_Type.SelectedIndex == 0)
                    linkType = " ";
                else if (comboBox_Type.SelectedIndex == 1)
                    linkType = " /D ";
                else if (comboBox_Type.SelectedIndex == 2)
                    linkType = " /H ";
                else if (comboBox_Type.SelectedIndex == 3)
                    linkType = " /J ";

                // 构建命令行参数，/C表示执行完命令后关闭命令窗口
                startInfoSymlink.Arguments = "/C MKLINK" + linkType + "\"" + textBox_Link.Text + "\" \"" + textBox_Target.Text + "\"";
                // 设置不显示命令窗口
                startInfoSymlink.CreateNoWindow = true;
                // 设置不使用系统外壳程序执行命令
                startInfoSymlink.UseShellExecute = false;
                // 设置输出重定向，即使我们不输出内容，这样用户也不会看到它
                startInfoSymlink.RedirectStandardOutput = true;

                // 设置进程的启动信息
                processSymlink.StartInfo = startInfoSymlink;
                // 启动进程并执行命令
                processSymlink.Start();
            }
        }

        private void textBox_CMDCommand_Click(object sender, EventArgs e)
        {
            UpdateCMDCommand();
        }

        private void UpdateCMDCommand()
        {
            // 根据comboBox_Type的选择设置链接类型
            string linkType = " ";
            if (comboBox_Type.SelectedIndex == 0)
                linkType = " ";
            else if (comboBox_Type.SelectedIndex == 1)
                linkType = " /D ";
            else if (comboBox_Type.SelectedIndex == 2)
                linkType = " /H ";
            else if (comboBox_Type.SelectedIndex == 3)
                linkType = " /J ";

            // 更新textBox_CMDCommand文本框以显示MKLINK命令
            textBox_CMDCommand.Text = "MKLINK" + linkType + "\"" + textBox_Link.Text + "\" \"" + textBox_Target.Text + "\"";
        }

        //private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        //{

        //}

        //private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        //{

        //}

        //private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        //{

        //}





    }
}