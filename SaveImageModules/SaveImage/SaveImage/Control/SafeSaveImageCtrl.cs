using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaveImage.Control
{
    [ToolboxItem(true)]
    public partial class SafeSaveImageCtrl : UserControl
    {
        private SafeSaveImageHelper mySafeSaveImage;
        public SafeSaveImageCtrl()
        {
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
                    chk_Type_bmp.Invoke(new Action(() =>
                    {
                        chk_Type_bmp.Checked = false;
                    }));
                    chk_Type_jpg.Invoke(new Action(() =>
                    {
                        chk_Type_jpg.Checked = false;
                    }));
                    break;
                case SaveImageType.BMP:
                    chk_Type_bmp.Invoke(new Action(() =>
                    {
                        chk_Type_bmp.Checked = true;
                    }));
                    chk_Type_jpg.Invoke(new Action(() =>
                    {
                        chk_Type_jpg.Checked = false;
                    }));
                    break;
                case SaveImageType.JPG:
                    chk_Type_bmp.Invoke(new Action(() =>
                    {
                        chk_Type_bmp.Checked = false;
                    }));
                    chk_Type_jpg.Invoke(new Action(() =>
                    {
                        chk_Type_jpg.Checked = true;
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
                case AutoDeleteImageModeEnum.TIME:
                    chk_DeleteMode_Time.Invoke(new Action(()=>
                    {
                        chk_DeleteMode_Time.Checked = true;
                    }));
                    break;
                case AutoDeleteImageModeEnum.CAPACITY:
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

        private void chk_Type_bmp_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Type_bmp.Checked)
            {
                chk_Type_jpg.Invoke(new Action(() =>
                {
                    chk_Type_jpg.Checked = false;
                }));
                mySafeSaveImage.SaveType = SaveImageType.BMP;
            }
            else
            {
                if (chk_Type_jpg.Checked == false)
                {
                    mySafeSaveImage.SaveType = SaveImageType.NONE;
                }
            }
        }

        private void chk_Type_jpg_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk_Type_bmp.Checked)
            {
                chk_Type_bmp.Invoke(new Action(() =>
                {
                    chk_Type_bmp.Checked = false;
                }));
                mySafeSaveImage.SaveType = SaveImageType.JPG;
            }
            else
            {
                if (chk_Type_bmp.Checked == false)
                {
                    mySafeSaveImage.SaveType = SaveImageType.NONE;
                }
            }
        }

        private void chk_DeleteMode_Time_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_DeleteMode_Time.Checked)
            {
                chk_DeleteMode_Capacity.Invoke(new Action(() =>
                {
                    chk_DeleteMode_Capacity.Checked = false;
                }));
                mySafeSaveImage.DeleteMode = AutoDeleteImageModeEnum.TIME;
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
                mySafeSaveImage.DeleteMode = AutoDeleteImageModeEnum.CAPACITY;
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
    }
}
