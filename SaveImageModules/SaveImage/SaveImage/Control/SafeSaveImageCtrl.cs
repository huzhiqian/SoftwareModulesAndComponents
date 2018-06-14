using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace SaveImage.Control
{
    [ToolboxItem(true)]
    public partial class SafeSaveImageCtrl : UserControl
    {
        private LanguageConstant uiLanguage = LanguageConstant.Chiness;
        private SafeSaveImageHelper mySafeSaveImage;
        public SafeSaveImageCtrl()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            InitializeComponent();
        }


        #region 属性

        /// <summary>
        /// 获取或设置保存图像的实例
        /// </summary>
        public SafeSaveImageHelper Subject
        {
            get { return this.mySafeSaveImage; }
            set
            {
                if (value != null)
                {
                    if (!object.ReferenceEquals(value, this.mySafeSaveImage))
                    {
                        mySafeSaveImage = value;

                    }
                    InitializeUI();
                }
 
            }
        }

        public LanguageConstant SetLanguage
        {
            set
            {
                if (value != uiLanguage)
                {
                    uiLanguage = value;
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    this.Controls.Clear();
                    InitializeComponent();
                }
            }
        }
        #endregion

        #region 初始化界面

        private void InitializeUI()
        {
            ShowSaveImagePath();
            ShowIsSaveImage();
            ShowIsAddTimeToImageName();
            ShowSaveImageType();
            ShowImageLifeSpan();
            ShowDiskCapacity();
            ShowDeleteMode();

            if (mySafeSaveImage.IsDBLinked)
            {
                label3.Invoke(new Action(()=>
                {
                    label3.BackColor = Color.Green;
                }));
            }
            else
            {
                label3.Invoke(new Action(() =>
                {
                    label3.BackColor = Color.Red;
                }));
            }
        }

        /// <summary>
        /// 显示保存图像的路径
        /// </summary>
        private void ShowSaveImagePath()
        {
            tbx_SavePath.Invoke(new Action(() =>
            {
                tbx_SavePath.Text = mySafeSaveImage.SavePath;
            }));
        }
        /// <summary>
        /// 显示是否保存图像
        /// </summary>
        private void ShowIsSaveImage()
        {
            chk_IsSaveImage.Invoke(new Action(() =>
            {
                chk_IsSaveImage.Checked = mySafeSaveImage.IsSaveImage;
            }));
        }
        /// <summary>
        /// 显示是否在图像名称中添加时间后缀
        /// </summary>
        private void ShowIsAddTimeToImageName()
        {
            chk_ImageNmaeAddTime.Invoke(new Action(() =>
            {
                chk_ImageNmaeAddTime.Checked = mySafeSaveImage.IsAddTimeToImageName;
            }));

        }
        /// <summary>
        /// 显示保存图像的格式
        /// </summary>
        private void ShowSaveImageType()
        {
            switch (mySafeSaveImage.SaveType)
            {
                case SaveImageType.NONE:
                    rad_Type_BMP.Invoke(new Action(() =>
                    {
                        rad_Type_BMP.Checked = false;
                    }));
                    rad_Type_JPG.Invoke(new Action(() =>
                    {
                        rad_Type_JPG.Checked = false;
                    }));
                    break;
                case SaveImageType.BMP:
                    rad_Type_BMP.Invoke(new Action(() =>
                    {
                        rad_Type_BMP.Checked = true;
                    }));
                    rad_Type_JPG.Invoke(new Action(() =>
                    {
                        rad_Type_JPG.Checked = false;
                    }));
                    break;
                case SaveImageType.JPG:
                    rad_Type_BMP.Invoke(new Action(() =>
                    {
                        rad_Type_BMP.Checked = false;
                    }));
                    rad_Type_JPG.Invoke(new Action(() =>
                    {
                        rad_Type_JPG.Checked = true;
                    }));
                    break;
                default:
                    break;
            }
        }

        private void ShowImageLifeSpan()
        {
            cmb_ImagelifeSpan.Invoke(new Action(()=>
            {
                cmb_ImagelifeSpan.Text = mySafeSaveImage.ImageLifeSpan.ToString();
            }));
        }

        private void ShowDiskCapacity()
        {
            cmb_DiskCapacity.Invoke(new Action(()=>
            {
                cmb_DiskCapacity.Text = mySafeSaveImage.DiskAllowsMinCapacity.ToString();
            }));
        }

        private void ShowDeleteMode()
        {
            switch (mySafeSaveImage.DeleteMode)
            {
                case AutoDeleteImageModeEnum.NONE:
                    break;
                case AutoDeleteImageModeEnum.TIMEANDSPACE:
                    chk_DeleteMode_Time.Invoke(new Action(()=>
                    {
                        chk_DeleteMode_Time.Checked = true;
                    }));
                    break;
                case AutoDeleteImageModeEnum.SPACE:
                    chk_DeleteMode_Capacity.Invoke(new Action(()=>
                    {
                        chk_DeleteMode_Capacity.Checked = true;
                    }));
                    break;
                default:
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 浏览我保存图像的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "选择保存图像的路径";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                mySafeSaveImage.SavePath = folderBrowserDialog.SelectedPath;
                ShowSaveImagePath();
            }
            folderBrowserDialog.Dispose();

        }

        /// <summary>
        /// 是是否保存图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_IsSaveImage_CheckedChanged(object sender, EventArgs e)
        {
            mySafeSaveImage.IsSaveImage = chk_IsSaveImage.Checked;
        }
        /// <summary>
        /// 是否在图像名称中添加时间后缀
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_ImageNmaeAddTime_CheckedChanged(object sender, EventArgs e)
        {
            mySafeSaveImage.IsAddTimeToImageName = chk_ImageNmaeAddTime.Checked;
        }

        private void chk_DeleteMode_Time_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_DeleteMode_Time.Checked)
            {
                chk_DeleteMode_Capacity.Invoke(new Action(() =>
                {
                    chk_DeleteMode_Capacity.Checked = false;
                }));
                mySafeSaveImage.DeleteMode = AutoDeleteImageModeEnum.TIMEANDSPACE;
            }
            else
            {
                if (chk_DeleteMode_Capacity.Checked == false)
                {
                    mySafeSaveImage.DeleteMode = AutoDeleteImageModeEnum.NONE;
                }
            }

        }

        private void chk_DeleteMode_Capacity_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_DeleteMode_Capacity.Checked)
            {
                chk_DeleteMode_Time.Invoke(new Action(() =>
                {
                    chk_DeleteMode_Time.Checked = false;
                }));
                mySafeSaveImage.DeleteMode = AutoDeleteImageModeEnum.SPACE;
            }
            else
            {
                if (chk_DeleteMode_Time.Checked == false)
                {
                    mySafeSaveImage.DeleteMode = AutoDeleteImageModeEnum.NONE;
                }
            }
        }

        private void cmb_DiskCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int diskCap = 0;
            if (int.TryParse(cmb_DiskCapacity.Text, out diskCap))
            {
                mySafeSaveImage.DiskAllowsMinCapacity = diskCap;
            }
            cmb_DiskCapacity.Invoke(new Action(()=>
            {
                cmb_DiskCapacity.Text = mySafeSaveImage.DiskAllowsMinCapacity.ToString();
            }));
               
        }

        private void cmb_ImagelifeSpan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int imageLifeSapn = 0;
            if (int.TryParse(cmb_ImagelifeSpan.Text, out imageLifeSapn))
            {
                mySafeSaveImage.ImageLifeSpan = imageLifeSapn;
            }
            cmb_DiskCapacity.Invoke(new Action(() =>
            {
                cmb_ImagelifeSpan.Text = mySafeSaveImage.ImageLifeSpan.ToString();
            }));
        }

        private void rad_Type_BMP_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_Type_BMP.Checked)
            {
                mySafeSaveImage.SaveType = SaveImageType.BMP;
            }
        }

        private void rad_Type_JPG_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_Type_JPG.Checked)
            {
                mySafeSaveImage.SaveType = SaveImageType.JPG;
            }
        }

        private void label3_DoubleClick(object sender, EventArgs e)
        {
            if (mySafeSaveImage.IsDBLinked)
            {
                if (MessageBox.Show("确定要清空数据库中所有数据吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    == DialogResult.OK)
                {
                    mySafeSaveImage.ClearDBInfo();
                }
            }
        }
    }
}
public enum LanguageConstant
{
    Chiness = 1,
    english = 2
}
