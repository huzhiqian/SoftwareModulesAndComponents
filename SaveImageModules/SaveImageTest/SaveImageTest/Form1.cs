using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaveImage;
using System.Threading;
using System.Threading.Tasks;
using HalconDotNet;


namespace SaveImageTest
{
    public partial class Form1 : Form
    {
        private ISaveImage mySaveImage;
        private SaveHalconImage saveHalconImage;

        //各种类型的图片
        private Bitmap myTestImage;
        private HObject ho_image; 

        private System.Timers.Timer _timer;

        public Form1()
        {
            InitializeComponent();
            mySaveImage = new CSaveImage();
            saveHalconImage = new SaveHalconImage();
            _timer = new System.Timers.Timer();
            _timer.Interval = 100;
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(SaveImageFun);
            HOperatorSet.GenEmptyObj(out ho_image);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process myProcess = Process.GetCurrentProcess();
            myProcess.PriorityClass = ProcessPriorityClass.AboveNormal;

            InitilizeSoftware();

        }

        private void InitilizeSoftware()
        {
            mySaveImage.IsAddTimeToImageName = false;

            saveImageCtrl1.Subject = saveHalconImage as CSaveImage;

            //读取图片
            string imagePath = System.Environment.CurrentDirectory + @"\Image\TestImage.bmp";
            //myTestImage = new Bitmap(imagePath);
            HTuple path = new HTuple(imagePath);
            try
            {
               
                ho_image.Dispose();
                HOperatorSet.ReadImage(out ho_image, path);
            }
            catch (HalconException hex)
            {

                throw;
            }

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开始测试")
            {
                button1.BackColor = Color.Green;
                button1.Text = "停止测试";
                _timer.Start();
            }
            else
            {
                button1.BackColor = Color.Red;
                button1.Text = "开始测试";
                _timer.Stop();
            }
        }

        static int SaveCount = 0;
        private void SaveImageFun(object sender, System.Timers.ElapsedEventArgs e)
        {
            SaveCount++;
            //mySaveImage.Save(myTestImage, SaveCount.ToString());    //保存bitmap类型图片

            saveHalconImage.SaveGreyImage(ho_image, SaveCount.ToString());
        }
    }
}
