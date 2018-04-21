using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaveImage;

namespace SaveImageTest
{
    public partial class Form1 : Form
    {
        private SaveImageTool saveImateTool;

        private ISaveImage mySaveImage;
        public Form1()
        {
            InitializeComponent();
            mySaveImage = new SaveImage.SaveImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
