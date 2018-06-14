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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SafeSaveImageCtrl));
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
            this.chk_IsSaveImage = new System.Windows.Forms.CheckBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbx_SavePath = new System.Windows.Forms.TextBox();
            this.rad_Type_BMP = new System.Windows.Forms.RadioButton();
            this.rad_Type_JPG = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmb_DiskCapacity);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmb_ImagelifeSpan);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.chk_ImageNmaeAddTime);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.chk_IsSaveImage);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // cmb_DiskCapacity
            // 
            this.cmb_DiskCapacity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DiskCapacity.FormattingEnabled = true;
            this.cmb_DiskCapacity.Items.AddRange(new object[] {
            resources.GetString("cmb_DiskCapacity.Items"),
            resources.GetString("cmb_DiskCapacity.Items1"),
            resources.GetString("cmb_DiskCapacity.Items2"),
            resources.GetString("cmb_DiskCapacity.Items3"),
            resources.GetString("cmb_DiskCapacity.Items4"),
            resources.GetString("cmb_DiskCapacity.Items5"),
            resources.GetString("cmb_DiskCapacity.Items6"),
            resources.GetString("cmb_DiskCapacity.Items7"),
            resources.GetString("cmb_DiskCapacity.Items8"),
            resources.GetString("cmb_DiskCapacity.Items9")});
            resources.ApplyResources(this.cmb_DiskCapacity, "cmb_DiskCapacity");
            this.cmb_DiskCapacity.Name = "cmb_DiskCapacity";
            this.cmb_DiskCapacity.SelectedIndexChanged += new System.EventHandler(this.cmb_DiskCapacity_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cmb_ImagelifeSpan
            // 
            this.cmb_ImagelifeSpan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ImagelifeSpan.FormattingEnabled = true;
            this.cmb_ImagelifeSpan.Items.AddRange(new object[] {
            resources.GetString("cmb_ImagelifeSpan.Items"),
            resources.GetString("cmb_ImagelifeSpan.Items1"),
            resources.GetString("cmb_ImagelifeSpan.Items2"),
            resources.GetString("cmb_ImagelifeSpan.Items3"),
            resources.GetString("cmb_ImagelifeSpan.Items4"),
            resources.GetString("cmb_ImagelifeSpan.Items5"),
            resources.GetString("cmb_ImagelifeSpan.Items6"),
            resources.GetString("cmb_ImagelifeSpan.Items7"),
            resources.GetString("cmb_ImagelifeSpan.Items8"),
            resources.GetString("cmb_ImagelifeSpan.Items9"),
            resources.GetString("cmb_ImagelifeSpan.Items10"),
            resources.GetString("cmb_ImagelifeSpan.Items11")});
            resources.ApplyResources(this.cmb_ImagelifeSpan, "cmb_ImagelifeSpan");
            this.cmb_ImagelifeSpan.Name = "cmb_ImagelifeSpan";
            this.cmb_ImagelifeSpan.SelectedIndexChanged += new System.EventHandler(this.cmb_ImagelifeSpan_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chk_DeleteMode_Capacity);
            this.groupBox4.Controls.Add(this.chk_DeleteMode_Time);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.groupBox4.UseCompatibleTextRendering = true;
            // 
            // chk_DeleteMode_Capacity
            // 
            resources.ApplyResources(this.chk_DeleteMode_Capacity, "chk_DeleteMode_Capacity");
            this.chk_DeleteMode_Capacity.Name = "chk_DeleteMode_Capacity";
            this.chk_DeleteMode_Capacity.UseVisualStyleBackColor = true;
            this.chk_DeleteMode_Capacity.CheckedChanged += new System.EventHandler(this.chk_DeleteMode_Capacity_CheckedChanged);
            // 
            // chk_DeleteMode_Time
            // 
            resources.ApplyResources(this.chk_DeleteMode_Time, "chk_DeleteMode_Time");
            this.chk_DeleteMode_Time.Name = "chk_DeleteMode_Time";
            this.chk_DeleteMode_Time.UseVisualStyleBackColor = true;
            this.chk_DeleteMode_Time.CheckedChanged += new System.EventHandler(this.chk_DeleteMode_Time_CheckedChanged);
            // 
            // chk_ImageNmaeAddTime
            // 
            resources.ApplyResources(this.chk_ImageNmaeAddTime, "chk_ImageNmaeAddTime");
            this.chk_ImageNmaeAddTime.Name = "chk_ImageNmaeAddTime";
            this.chk_ImageNmaeAddTime.UseVisualStyleBackColor = true;
            this.chk_ImageNmaeAddTime.CheckedChanged += new System.EventHandler(this.chk_ImageNmaeAddTime_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rad_Type_JPG);
            this.groupBox3.Controls.Add(this.rad_Type_BMP);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // chk_IsSaveImage
            // 
            resources.ApplyResources(this.chk_IsSaveImage, "chk_IsSaveImage");
            this.chk_IsSaveImage.Name = "chk_IsSaveImage";
            this.chk_IsSaveImage.UseVisualStyleBackColor = true;
            this.chk_IsSaveImage.CheckedChanged += new System.EventHandler(this.chk_IsSaveImage_CheckedChanged);
            // 
            // btn_Browse
            // 
            resources.ApplyResources(this.btn_Browse, "btn_Browse");
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btn_Browse);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbx_SavePath);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tbx_SavePath
            // 
            this.tbx_SavePath.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbx_SavePath, "tbx_SavePath");
            this.tbx_SavePath.Name = "tbx_SavePath";
            this.tbx_SavePath.ReadOnly = true;
            // 
            // rad_Type_BMP
            // 
            resources.ApplyResources(this.rad_Type_BMP, "rad_Type_BMP");
            this.rad_Type_BMP.Name = "rad_Type_BMP";
            this.rad_Type_BMP.TabStop = true;
            this.rad_Type_BMP.UseVisualStyleBackColor = true;
            this.rad_Type_BMP.CheckedChanged += new System.EventHandler(this.rad_Type_BMP_CheckedChanged);
            // 
            // rad_Type_JPG
            // 
            resources.ApplyResources(this.rad_Type_JPG, "rad_Type_JPG");
            this.rad_Type_JPG.Name = "rad_Type_JPG";
            this.rad_Type_JPG.TabStop = true;
            this.rad_Type_JPG.UseVisualStyleBackColor = true;
            this.rad_Type_JPG.CheckedChanged += new System.EventHandler(this.rad_Type_JPG_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // SafeSaveImageCtrl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SafeSaveImageCtrl";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_ImageNmaeAddTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chk_IsSaveImage;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_DiskCapacity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_ImagelifeSpan;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chk_DeleteMode_Capacity;
        private System.Windows.Forms.CheckBox chk_DeleteMode_Time;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbx_SavePath;
        private System.Windows.Forms.RadioButton rad_Type_JPG;
        private System.Windows.Forms.RadioButton rad_Type_BMP;
        private System.Windows.Forms.Label label3;
    }
}
