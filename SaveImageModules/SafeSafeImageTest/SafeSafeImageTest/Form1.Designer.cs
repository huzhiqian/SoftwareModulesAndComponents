namespace SafeSafeImageTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.safeSaveImageCtrl1 = new SaveImage.Control.SafeSaveImageCtrl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(168, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 86);
            this.button1.TabIndex = 1;
            this.button1.Text = "开始测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // safeSaveImageCtrl1
            // 
            this.safeSaveImageCtrl1.Location = new System.Drawing.Point(3, 12);
            this.safeSaveImageCtrl1.Name = "safeSaveImageCtrl1";
            this.safeSaveImageCtrl1.Size = new System.Drawing.Size(560, 185);
            this.safeSaveImageCtrl1.Subject = null;
            this.safeSaveImageCtrl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 411);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.safeSaveImageCtrl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SaveImage.Control.SafeSaveImageCtrl safeSaveImageCtrl1;
        private System.Windows.Forms.Button button1;
    }
}

