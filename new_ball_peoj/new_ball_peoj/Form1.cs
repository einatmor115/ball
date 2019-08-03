using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_ball_peoj
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<Ball> balls = new List<Ball>();
        int CountBalls = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            delete(sender);
        }

        private void delete(object p)
        {
            CountBalls--;
            PictureBox pic = (PictureBox)p;
            Controls.Remove(pic);
            pic.Dispose();
            pic.Visible = false;

        }

        public Ball AddNewBall()
        {
            CountBalls++;
            int x2 = rnd.Next(1, ClientSize.Width - pink_ball.Width);
            int y2 = rnd.Next(1, ClientSize.Height - pink_ball.Height);

            int[] XYArray = new int[] { 1, -1 };
            int dx = XYArray[rnd.Next(0, XYArray.Length)];
            int dy = XYArray[rnd.Next(0, XYArray.Length)];

            Ball B = new Ball(x2, y2, dx, dy);

            this.Controls.Add(B.PictureBox);
            B.PictureBox.Click += pictureBox_Click;
            balls.Add(B);
            return B;
        }

        private void checkSides(List<Ball> balls)
        {
                for (int i = 0; i < balls.Count; i++)
                {
                    for (int j = 0; j < balls.Count; i++)
                    {
                        if (balls[i] == balls[j])
                        {
                            continue;
                        }

                        if (balls[i].PictureBox.Location.X + balls[i].PictureBox.Width > balls[j].PictureBox.Location.X)
                        {
                            balls[i].moveX = -1;
                        }

                        if (balls[i].PictureBox.Location.X < balls[j].PictureBox.Location.X)
                        {
                            balls[i].moveX = 1;
                        }

                        if (balls[i].PictureBox.Location.Y + balls[i].PictureBox.Height < balls[j].PictureBox.Location.Y)
                        {
                            balls[i].moveY = 1;
                        }

                        if (balls[i].PictureBox.Location.Y > balls[j].PictureBox.Location.Y)
                        {
                            balls[i].moveY = -1;
                        }
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Ball B = AddNewBall();

            Task.Run(() =>
            {
                while (true)
                {
                    if (B.PictureBox.Location.X + B.moveX + B.PictureBox.Width > ClientSize.Width)
                    {
                        B.moveX = -1;
                    }

                    if (B.PictureBox.Location.Y + B.moveY + B.PictureBox.Height > ClientSize.Height)
                    {
                        B.moveY = -1;
                    }

                    if (B.PictureBox.Location.X + B.moveX < 0)
                    {
                        B.moveX = 1;
                    }

                    if (B.PictureBox.Location.Y + B.moveY < 0)
                    {
                        B.moveY = 1;
                    }

                  //  checkSides(balls);

                    Action a = () => { B.PictureBox.Location = new Point(B.PictureBox.Location.X + B.moveX, B.PictureBox.Location.Y + B.moveY); };
                    B.PictureBox.BeginInvoke(a);

                    Thread.Sleep(13);
                }
            });
        }
    }
}
