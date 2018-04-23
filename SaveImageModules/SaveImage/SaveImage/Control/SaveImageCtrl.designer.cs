  partial class SaveImageCtrl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.tbx_SavePath = new System.Windows.Forms.TextBox();
            this.chk_IsSaveImage = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_ImageNmaeAddTime = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_Type_jpg = new System.Windows.Forms.CheckBox();
            this.chk_Type_bmp = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Browse);
            this.groupBox1.Controls.Add(this.tbx_SavePath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保存图像路径";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Browse.Location = new System.Drawing.Point(482, 22);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 32);
            this.btn_Browse.TabIndex = 1;
            this.btn_Browse.Text = "浏览";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // tbx_SavePath
            // 
            this.tbx_SavePath.BackColor = System.Drawing.Color.White;
            this.tbx_SavePath.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbx_SavePath.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_SavePath.Location = new System.Drawing.Point(3, 22);
            this.tbx_SavePath.Multiline = true;
            this.tbx_SavePath.Name = "tbx_SavePath";
            this.tbx_SavePath.ReadOnly = true;
            this.tbx_SavePath.Size = new System.Drawing.Size(473, 32);
            this.tbx_SavePath.TabIndex = 0;
            this.tbx_SavePath.Text = "C:\\Users\\Administrator\\Desktop\\SoftwareModulesAndComponents\\SaveImage";
            // 
            // chk_IsSaveImage
            // 
            this.chk_IsSaveImage.AutoSize = true;
            this.chk_IsSaveImage.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_IsSaveImage.Location = new System.Drawing.Point(6, 25);
            this.chk_IsSaveImage.Name = "chk_IsSaveImage";
            this.chk_IsSaveImage.Size = new System.Drawing.Size(112, 23);
            this.chk_IsSaveImage.TabIndex = 1;
            this.chk_IsSaveImage.Text = "是否保存图像";
            this.chk_IsSaveImage.UseVisualStyleBackColor = true;
            this.chk_IsSaveImage.CheckedChanged += new System.EventHandler(this.chk_IsSaveImage_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_ImageNmaeAddTime);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.chk_IsSaveImage);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 128);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保存图像设置";
            // 
            // chk_ImageNmaeAddTime
            // 
            this.chk_ImageNmaeAddTime.AutoSize = true;
            this.chk_ImageNmaeAddTime.Location = new System.Drawing.Point(149, 25);
            this.chk_ImageNmaeAddTime.Name = "chk_ImageNmaeAddTime";
            this.chk_ImageNmaeAddTime.Size = new System.Drawing.Size(168, 23);
            this.chk_ImageNmaeAddTime.TabIndex = 3;
            this.chk_ImageNmaeAddTime.Text = "图像名称加上时间后缀";
            this.chk_ImageNmaeAddTime.UseVisualStyleBackColor = true;
            this.chk_ImageNmaeAddTime.CheckedChanged += new System.EventHandler(this.chk_ImageNmaeAddTime_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chk_Type_jpg);
            this.groupBox3.Controls.Add(this.chk_Type_bmp);
            this.groupBox3.Location = new System.Drawing.Point(6, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 68);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图像类型";
            // 
            // chk_Type_jpg
            // 
            this.chk_Type_jpg.AutoSize = true;
            this.chk_Type_jpg.Location = new System.Drawing.Point(69, 39);
            this.chk_Type_jpg.Name = "chk_Type_jpg";
            this.chk_Type_jpg.Size = new System.Drawing.Size(51, 23);
            this.chk_Type_jpg.TabIndex = 1;
            this.chk_Type_jpg.Text = "JPG";
            this.chk_Type_jpg.UseVisualStyleBackColor = true;
            this.chk_Type_jpg.CheckStateChanged += new System.EventHandler(this.chk_Type_jpg_CheckStateChanged);
            // 
            // chk_Type_bmp
            // 
            this.chk_Type_bmp.AutoSize = true;
            this.chk_Type_bmp.Location = new System.Drawing.Point(6, 39);
            this.chk_Type_bmp.Name = "chk_Type_bmp";
            this.chk_Type_bmp.Size = new System.Drawing.Size(57, 23);
            this.chk_Type_bmp.TabIndex = 0;
            this.chk_Type_bmp.Text = "BMP";
            this.chk_Type_bmp.UseVisualStyleBackColor = true;
            this.chk_Type_bmp.CheckedChanged += new System.EventHandler(this.chk_Type_bmp_CheckedChanged);
            // 
            // SaveImageTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SaveImageTool";
            this.Size = new System.Drawing.Size(560, 185);
            this.Load += new System.EventHandler(this.SaveImageTool_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.TextBox tbx_SavePath;
        private System.Windows.Forms.CheckBox chk_IsSaveImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_ImageNmaeAddTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chk_Type_jpg;
        private System.Windows.Forms.CheckBox chk_Type_bmp;
    }
