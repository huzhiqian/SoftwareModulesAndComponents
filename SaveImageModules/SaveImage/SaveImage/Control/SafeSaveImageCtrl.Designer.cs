namespace SaveImage.Control
{
    partial class SafeSaveImageCtrl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_DiskCapacity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_ImagelifeSpan = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chk_DeleteMode_Capacity = new System.Windows.Forms.CheckBox();
            this.chk_DeleteMode_Time = new System.Windows.Forms.CheckBox();
            this.chk_ImageNmaeAddTime = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_Type_jpg = new System.Windows.Forms.CheckBox();
            this.chk_Type_bmp = new System.Windows.Forms.CheckBox();
            this.chk_IsSaveImage = new System.Windows.Forms.CheckBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.tbx_SavePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmb_DiskCapacity);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmb_ImagelifeSpan);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.chk_ImageNmaeAddTime);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.chk_IsSaveImage);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 128);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保存图像设置";
            // 
            // cmb_DiskCapacity
            // 
            this.cmb_DiskCapacity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DiskCapacity.FormattingEnabled = true;
            this.cmb_DiskCapacity.Items.AddRange(new object[] {
            "0.5",
            "1",
            "1.5",
            "2",
            "2.5",
            "3",
            "5",
            "10",
            "20"});
            this.cmb_DiskCapacity.Location = new System.Drawing.Point(162, 24);
            this.cmb_DiskCapacity.Name = "cmb_DiskCapacity";
            this.cmb_DiskCapacity.Size = new System.Drawing.Size(112, 27);
            this.cmb_DiskCapacity.TabIndex = 8;
            this.cmb_DiskCapacity.SelectedIndexChanged += new System.EventHandler(this.cmb_DiskCapacity_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "磁盘容量下限（GB）：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "图片存储时间（天）：";
            // 
            // cmb_ImagelifeSpan
            // 
            this.cmb_ImagelifeSpan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ImagelifeSpan.FormattingEnabled = true;
            this.cmb_ImagelifeSpan.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "30",
            "60",
            "120",
            "180",
            "240",
            "300"});
            this.cmb_ImagelifeSpan.Location = new System.Drawing.Point(442, 24);
            this.cmb_ImagelifeSpan.Name = "cmb_ImagelifeSpan";
            this.cmb_ImagelifeSpan.Size = new System.Drawing.Size(112, 27);
            this.cmb_ImagelifeSpan.TabIndex = 5;
            this.cmb_ImagelifeSpan.SelectedIndexChanged += new System.EventHandler(this.cmb_ImagelifeSpan_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chk_DeleteMode_Capacity);
            this.groupBox4.Controls.Add(this.chk_DeleteMode_Time);
            this.groupBox4.Location = new System.Drawing.Point(156, 54);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(181, 68);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "自动删图模式";
            this.groupBox4.UseCompatibleTextRendering = true;
            // 
            // chk_DeleteMode_Capacity
            // 
            this.chk_DeleteMode_Capacity.AutoSize = true;
            this.chk_DeleteMode_Capacity.Location = new System.Drawing.Point(107, 39);
            this.chk_DeleteMode_Capacity.Name = "chk_DeleteMode_Capacity";
            this.chk_DeleteMode_Capacity.Size = new System.Drawing.Size(56, 23);
            this.chk_DeleteMode_Capacity.TabIndex = 2;
            this.chk_DeleteMode_Capacity.Text = "容量";
            this.chk_DeleteMode_Capacity.UseVisualStyleBackColor = true;
            this.chk_DeleteMode_Capacity.CheckedChanged += new System.EventHandler(this.chk_DeleteMode_Capacity_CheckedChanged);
            // 
            // chk_DeleteMode_Time
            // 
            this.chk_DeleteMode_Time.AutoSize = true;
            this.chk_DeleteMode_Time.Location = new System.Drawing.Point(6, 39);
            this.chk_DeleteMode_Time.Name = "chk_DeleteMode_Time";
            this.chk_DeleteMode_Time.Size = new System.Drawing.Size(95, 23);
            this.chk_DeleteMode_Time.TabIndex = 1;
            this.chk_DeleteMode_Time.Text = "时间 | 容量";
            this.chk_DeleteMode_Time.UseVisualStyleBackColor = true;
            this.chk_DeleteMode_Time.CheckedChanged += new System.EventHandler(this.chk_DeleteMode_Time_CheckedChanged);
            // 
            // chk_ImageNmaeAddTime
            // 
            this.chk_ImageNmaeAddTime.AutoSize = true;
            this.chk_ImageNmaeAddTime.Location = new System.Drawing.Point(369, 95);
            this.chk_ImageNmaeAddTime.Name = "chk_ImageNmaeAddTime";
            this.chk_ImageNmaeAddTime.Size = new System.Drawing.Size(154, 23);
            this.chk_ImageNmaeAddTime.TabIndex = 3;
            this.chk_ImageNmaeAddTime.Text = "图像名添加时间后缀";
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
            this.chk_Type_jpg.CheckedChanged += new System.EventHandler(this.chk_Type_jpg_CheckStateChanged);
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
            // chk_IsSaveImage
            // 
            this.chk_IsSaveImage.AutoSize = true;
            this.chk_IsSaveImage.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_IsSaveImage.Location = new System.Drawing.Point(369, 66);
            this.chk_IsSaveImage.Name = "chk_IsSaveImage";
            this.chk_IsSaveImage.Size = new System.Drawing.Size(84, 23);
            this.chk_IsSaveImage.TabIndex = 1;
            this.chk_IsSaveImage.Text = "是否存图";
            this.chk_IsSaveImage.UseVisualStyleBackColor = true;
            this.chk_IsSaveImage.CheckedChanged += new System.EventHandler(this.chk_IsSaveImage_CheckedChanged);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Browse);
            this.groupBox1.Controls.Add(this.tbx_SavePath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 57);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保存图像路径";
            // 
            // SafeSaveImageCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SafeSaveImageCtrl";
            this.Size = new System.Drawing.Size(560, 185);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_ImageNmaeAddTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chk_Type_jpg;
        private System.Windows.Forms.CheckBox chk_Type_bmp;
        private System.Windows.Forms.CheckBox chk_IsSaveImage;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.TextBox tbx_SavePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_DiskCapacity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_ImagelifeSpan;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chk_DeleteMode_Capacity;
        private System.Windows.Forms.CheckBox chk_DeleteMode_Time;
    }
}
