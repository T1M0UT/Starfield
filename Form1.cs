using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Starfield
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Bitmap bitmap;
        private Pen pen;
        private Color starColor;
        private Star[] stars;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            bitmap = new Bitmap(picture.Width, picture.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.TranslateTransform(Width / 2, Height / 2); 
            pen = new Pen(Color.White);
            starColor = Color.White;
            Star.Setup(Width, Height);
            stars = new Star[2000];
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star();
            }
        }

        private void OnUpdate()
        {
            graphics.Clear(Color.Black);

            foreach(Star star in stars)
            {
                star.Update();
                star.Show(graphics, starColor);
            }

            picture.Image = bitmap;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            OnUpdate();
        }
    }
}
