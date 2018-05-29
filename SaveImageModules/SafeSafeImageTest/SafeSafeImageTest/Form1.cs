using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaveImage;

namespace SafeSafeImageTest
{
    public partial class Form1 : Form
    {
        private SafeSaveImageHelper mySafeSaveImage;

        private Bitmap testImage;

        private System.Timers.Timer myTimer;
        public Form1()
        {
            InitializeComponent();
            mySafeSaveImage = new SafeSaveImageHelper(System.Environment.CurrentDirectory+@"\Config.ini", @"C:\Users\Administrator\Desktop\SoftwareModulesAndComponents\SaveImageModules\SafeSafeImageTest\SafeSafeImageTest\bin\Release\SaveImageDB.mdf");
            //testImage = new Bitmap(@"C:\Users\Administrator\Desktop\样品截图.PNG");
            myTimer = new System.Timers.Timer();
            myTimer.Interval = 500;
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(SaveImage);
            //SaveImage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            safeSaveImageCtrl1.Subject = mySafeSaveImage;
            safeSaveImageCtrl1.SetLanguage = LanguageConstant.Chiness;
            if (mySafeSaveImage.IsDBLinked)
                MessageBox.Show("123");
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开始测试")
            {
                button1.Text = "停止测试";
                myTimer.Start();
            }
            else
            {
                button1.Text = "开始测试";
                myTimer.Stop();
            }
        }

        private int imageName = 0;
        private void SaveImage(object sender,System.Timers.ElapsedEventArgs e)
        {
            try
            {
                imageName++;
                mySafeSaveImage.Save(testImage.Clone() as Bitmap, imageName.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
          

        }

        private void SaveImage()
        {
            mySafeSaveImage.SaveImageByFullName(testImage, "D:\\2018 - 05 - 23\\图片及数据\\111\\图片\\23671_20180523122417_44_0_85_73.bmp");
        }
    }
}
