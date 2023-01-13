using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dumb_Man_Computer
{
    public partial class graphicalOutput : Form
    {
        private PictureBox[] Pixels;
        public bool[] Values;
        public graphicalOutput()
        {
            InitializeComponent();
            Pixels = new PictureBox[400];
            Values = new bool[400];
        }

        public void RefreshForm(int width, int height, int pixelSize)
        {
            this.Width = pixelSize * (width);
            this.Height = pixelSize * (height);

            DeleteAllPixels();
            Pixels = new PictureBox[width * height];
            int index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    PictureBox pb = CreatePixel(x, y, pixelSize);
                    this.Controls.Add(pb);
                    Pixels[index] = pb;
                    index++;
                }
            }
            Values = new bool[width * height];
        }
        private void DeleteAllPixels()
        {
            foreach(PictureBox pb in Pixels)
            {
                this.Controls.Remove(pb);
            }
        }
        private PictureBox CreatePixel(int x, int y, int size)
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(x * size, y * size);
            pb.Size = new Size(size, size);
            pb.BackColor = Color.Black;
            return pb;
        }
        public void UpdatePixel(int pos)
        {
            Pixels[pos].BackColor = Values[pos] ? Color.White : Color.Black;
        }
    }
}
