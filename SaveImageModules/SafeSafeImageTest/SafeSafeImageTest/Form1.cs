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
            mySafeSaveImage = new SafeSaveImageHelper(System.Environment.CurrentDirectory+@"\Config.ini");
            //testImage = new Bitmap(@"C:\Users\Administrator\Desktop\NO6308T357.bmp");
            myTimer = new System.Timers.Timer();
            myTimer.Interval = 500;
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(SaveImage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            safeSaveImageCtrl1.Subject = mySafeSaveImage;
           
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
    }
}
