using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_ball_peoj
{
    public class Ball
    {
        public int x { get; set; }
        public int y { get; set; }
        public int moveX { get; set; }
        public int moveY { get; set; }
        public Point Point { get; set; }
        public PictureBox PictureBox { get; set; }

        public Ball(int x, int y, int moveX, int moveY)
        {
            PictureBox = new PictureBox();
            PictureBox.Image = Image.FromFile(@"C:\Users\einat\source\repos\pinkBall.jpg");
            PictureBox.Height = 60;
            PictureBox.Width = 60;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            this.x = x;
            this.y = y;
            this.moveX = moveX;
            this.moveY = moveY;

            Point = new Point(x, y);
            PictureBox.Location = Point;

        }
    }
}
