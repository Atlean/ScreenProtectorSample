using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenProtectorSample
{
    public partial class frmScSaver : Form
    {
        List<Image> BGImages = new List<Image>();
        List<Britpic> BritPics = new List<Britpic>();
        Random picturemove = new Random();  //Pictures will go somewhere randomly.
        class Britpic
        {
            public int picnumber;
            public float X;
            public float Y;
            public float speed;


        }

        public frmScSaver()
        {
            InitializeComponent();
        }

        private void frmScSaver_KeyDown(object sender, KeyEventArgs e) //from events dashboard
        {
            Close();
        }

        private void frmScSaver_Load(object sender, EventArgs e) //from events dashboard
        {
            string[] images = System.IO.Directory.GetFiles("cats"); //This file hold 10 of our pictures please go ScreenProtectorSample\bin\Debug\cats
            foreach (string items in images) 
            {
                BGImages.Add(new Bitmap(items));
            }
            for (int i = 0; i < 3000; i++) 
            { 
                Britpic multipicture = new Britpic();
                multipicture.picnumber=i % BGImages.Count; //numbers goes to between 0-9 with this code
                multipicture.X=picturemove.Next(0,Width);
                multipicture.Y=picturemove.Next(0,Height);
                BritPics.Add(multipicture);
            }

        }
        
        private void timer1_Tick (object sender, EventArgs e)
        {
            Refresh();
        }

        private void frmScSaver_Paint(object sender, PaintEventArgs e) //We will use e in here for draw our images.
        {
            foreach (Britpic itempics in BritPics) 
            {
                e.Graphics.DrawImage(BGImages[itempics.picnumber], itempics.X,itempics.Y);
                itempics.X -= 2;
                if (itempics.X < -250)
                {
                    itempics.X =Width + picturemove.Next(20,100);
                }
            }
        }
    }
}
