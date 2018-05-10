using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaveImage;

[ToolboxItem(true)]
public partial class SaveImageCtrl : UserControl
{
    private CSaveImage mySaveImage;

    public SaveImageCtrl()
    {
        InitializeComponent();
    }
 

    #region 属性

    /// <summary>
    /// 获取或设置保存图像的实例
    /// </summary>
    public  CSaveImage Subject
    {
        get { return this.mySaveImage; }
        set
        {
            if (!object.ReferenceEquals(value, this.mySaveImage))
            {
                mySaveImage = value;
               
            }
            InitializeUI();
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
    }

    /// <summary>
    /// 显示保存图像的路径
    /// </summary>
    private void ShowSaveImagePath()
    {
        tbx_SavePath.Invoke(new Action(() =>
        {
            tbx_SavePath.Text = mySaveImage.SavePath;
        }));
    }
    /// <summary>
    /// 显示是否保存图像
    /// </summary>
    private void ShowIsSaveImage()
    {
        chk_IsSaveImage.Invoke(new Action(() =>
            {
                chk_IsSaveImage.Checked = mySaveImage.IsSaveImage;
            }));
    }
    /// <summary>
    /// 显示是否在图像名称中添加时间后缀
    /// </summary>
    private void ShowIsAddTimeToImageName()
    {
        chk_ImageNmaeAddTime.Invoke(new Action(() =>
            {
                chk_ImageNmaeAddTime.Checked = mySaveImage.IsAddTimeToImageName;
            }));

    }
    /// <summary>
    /// 显示保存图像的格式
    /// </summary>
    private void ShowSaveImageType()
    {
        switch (mySaveImage.SaveType)
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
            mySaveImage.SavePath = folderBrowserDialog.SelectedPath;
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
        mySaveImage.IsSaveImage = chk_IsSaveImage.Checked;
    }
    /// <summary>
    /// 是否在图像名称中添加时间后缀
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void chk_ImageNmaeAddTime_CheckedChanged(object sender, EventArgs e)
    {
        mySaveImage.IsAddTimeToImageName = chk_ImageNmaeAddTime.Checked;
    }

    private void chk_Type_bmp_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_Type_bmp.Checked)
        {
            chk_Type_jpg.Invoke(new Action(() =>
            {
                chk_Type_jpg.Checked = false;
            }));
            mySaveImage.SaveType = SaveImageType.BMP;
        }
        else
        {
            if (chk_Type_jpg.Checked == false)
            {
                mySaveImage.SaveType = SaveImageType.NONE;
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
            mySaveImage.SaveType = SaveImageType.JPG;
        }
        else
        {
            if (chk_Type_bmp.Checked == false)
            {
                mySaveImage.SaveType = SaveImageType.NONE;
            }
        }
    }
}
