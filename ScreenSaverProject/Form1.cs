using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ScreenSaverProject
{
    public partial class FormScreenSaver : Form
    {
        List<Image> BGImages = new List<Image>();
        List<BritPic> BritPics = new List<BritPic>();
        Random rand = new Random();
        class BritPic
        {
            public int PicNum;
            public float X;
            public float Y;
            public float Speed;
        }
        public FormScreenSaver()
        {
            InitializeComponent();
        }
        

        private void FormScreenSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void FormScreenSaver_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("pics");
            
            foreach (string image in images)
            {
                BGImages.Add(new Bitmap(image));
            }

            for (int i = 0; i < 20; ++i)
            {
                BritPic pic = new BritPic();
                pic.PicNum = i % BGImages.Count;
                pic.X = rand.Next(0, Width);
                pic.Y = rand.Next(0, Height);

                //pic.Speed = rand.Next(100, 300) / 100.0f;

                BritPics.Add(pic);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void FormScreenSaver_Paint(object sender, PaintEventArgs e)
        {
            foreach (BritPic bp in BritPics)
            {
                e.Graphics.DrawImage(BGImages[bp.PicNum], bp.X, bp.Y);
                bp.X -= rand.Next(-100,100);

                if (bp.X < -250)
                {
                    bp.X = Width + rand.Next(30, 100);
                }
            }
        }
    }
}
