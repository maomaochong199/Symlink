using System.Windows.Forms;

namespace Symlink
{
    partial class Symlink
    {
        /// <summary>
        /// 必要的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private OpenFileDialog openFileDialog1;
        private TextBox textBox_Link;
        private Button button_BrowseLink;
        private Label label_Type;
        private ComboBox comboBox_Type;
        private Label label_Link;
        private Label label_Source;
        private TextBox textBox_Target;
        private Button button_BrowseTarget;
        private TextBox textBox_CMDCommand;
        private Label label_CMDCommand;
        private Button button_CreateLink;
        private SaveFileDialog saveFileDialog1;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_Link = new System.Windows.Forms.TextBox();
            this.button_BrowseLink = new System.Windows.Forms.Button();
            this.label_Type = new System.Windows.Forms.Label();
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.label_Link = new System.Windows.Forms.Label();
            this.label_Source = new System.Windows.Forms.Label();
            this.textBox_Target = new System.Windows.Forms.TextBox();
            this.button_BrowseTarget = new System.Windows.Forms.Button();
            this.textBox_CMDCommand = new System.Windows.Forms.TextBox();
            this.label_CMDCommand = new System.Windows.Forms.Label();
            this.button_CreateLink = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            //// 
            //this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            //// 
            //// openFileDialog1
            //// 
            //this.openFileDialog1.FileName = "openFileDialog1";
            //this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // textBox_Link
            // 
            this.textBox_Link.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Link.Location = new System.Drawing.Point(125, 93);
            this.textBox_Link.Multiline = true;
            this.textBox_Link.Name = "textBox_Link";
            this.textBox_Link.Size = new System.Drawing.Size(444, 56);
            this.textBox_Link.TabIndex = 0;
            // 
            // button_BrowseLink
            // 
            this.button_BrowseLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_BrowseLink.Location = new System.Drawing.Point(575, 110);
            this.button_BrowseLink.Name = "button_BrowseLink";
            this.button_BrowseLink.Size = new System.Drawing.Size(75, 21);
            this.button_BrowseLink.TabIndex = 1;
            this.button_BrowseLink.Text = "浏览";
            this.button_BrowseLink.UseVisualStyleBackColor = true;
            this.button_BrowseLink.Click += new System.EventHandler(this.button_BrowseLink_Click);
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(24, 9);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(82, 15);
            this.label_Type.TabIndex = 2;
            this.label_Type.Text = "链接类型：";
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Location = new System.Drawing.Point(125, 6);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(444, 20);
            this.comboBox_Type.TabIndex = 3;
            this.comboBox_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox_Type_SelectedIndexChanged);
            // 
            // label_Link
            // 
            this.label_Link.AutoSize = true;
            this.label_Link.Location = new System.Drawing.Point(12, 113);
            this.label_Link.Name = "label_Link";
            this.label_Link.Size = new System.Drawing.Size(120, 15);
            this.label_Link.TabIndex = 4;
            this.label_Link.Text = "链接/目标位置：";
            // 
            // label_Source
            // 
            this.label_Source.AutoSize = true;
            this.label_Source.Location = new System.Drawing.Point(18, 50);
            this.label_Source.Name = "label_Source";
            this.label_Source.Size = new System.Drawing.Size(105, 15);
            this.label_Source.TabIndex = 5;
            this.label_Source.Text = "目标/源位置：";
            // 
            // textBox_Target
            // 
            this.textBox_Target.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Target.Location = new System.Drawing.Point(125, 31);
            this.textBox_Target.Multiline = true;
            this.textBox_Target.Name = "textBox_Target";
            this.textBox_Target.Size = new System.Drawing.Size(444, 56);
            this.textBox_Target.TabIndex = 6;
            // 
            // button_BrowseTarget
            // 
            this.button_BrowseTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_BrowseTarget.Location = new System.Drawing.Point(573, 48);
            this.button_BrowseTarget.Name = "button_BrowseTarget";
            this.button_BrowseTarget.Size = new System.Drawing.Size(75, 21);
            this.button_BrowseTarget.TabIndex = 7;
            this.button_BrowseTarget.Text = "浏览";
            this.button_BrowseTarget.UseVisualStyleBackColor = true;
            this.button_BrowseTarget.Click += new System.EventHandler(this.button_BrowseTarget_Click);
            // 
            // textBox_CMDCommand
            // 
            this.textBox_CMDCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_CMDCommand.Location = new System.Drawing.Point(125, 154);
            this.textBox_CMDCommand.Multiline = true;
            this.textBox_CMDCommand.Name = "textBox_CMDCommand";
            this.textBox_CMDCommand.Size = new System.Drawing.Size(444, 95);
            this.textBox_CMDCommand.TabIndex = 8;
            this.textBox_CMDCommand.Click += new System.EventHandler(this.textBox_CMDCommand_Click);
            // 
            // label_CMDCommand
            // 
            this.label_CMDCommand.AutoSize = true;
            this.label_CMDCommand.Location = new System.Drawing.Point(24, 189);
            this.label_CMDCommand.Name = "label_CMDCommand";
            this.label_CMDCommand.Size = new System.Drawing.Size(84, 15);
            this.label_CMDCommand.TabIndex = 9;
            this.label_CMDCommand.Text = "CMD 命令：";
            // 
            // button_CreateLink
            // 
            this.button_CreateLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CreateLink.Location = new System.Drawing.Point(573, 189);
            this.button_CreateLink.Name = "button_CreateLink";
            this.button_CreateLink.Size = new System.Drawing.Size(75, 21);
            this.button_CreateLink.TabIndex = 10;
            this.button_CreateLink.Text = "创建链接";
            this.button_CreateLink.UseVisualStyleBackColor = true;
            this.button_CreateLink.Click += new System.EventHandler(this.button_CreateLink_Click);
            // 
            // saveFileDialog1
            // 
            //this.saveFileDialog1.OverwritePrompt = false;
            //this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // Symlink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 261);
            this.Controls.Add(this.button_CreateLink);
            this.Controls.Add(this.label_CMDCommand);
            this.Controls.Add(this.textBox_CMDCommand);
            this.Controls.Add(this.button_BrowseTarget);
            this.Controls.Add(this.textBox_Target);
            this.Controls.Add(this.label_Source);
            this.Controls.Add(this.label_Link);
            this.Controls.Add(this.comboBox_Type);
            this.Controls.Add(this.label_Type);
            this.Controls.Add(this.button_BrowseLink);
            this.Controls.Add(this.textBox_Link);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Symlink";
            this.Text = "软链接创建器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private FolderBrowserDialog folderBrowserDialog1;
    }
}
#endregion