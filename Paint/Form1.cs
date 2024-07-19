
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kurs_ishi_Paint
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
        }


        double qalinlik;
        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(color: Color.Black, 1);
        Pen erase = new Pen(color: Color.White, 10);
        int index;

        int x, y, sX, sY, cX, cY;

        ColorDialog cd = new ColorDialog();
        Color new_Color;
        private void pen1_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void ochirgich_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            index = 3;
        }
        private void tortb_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void chiziq_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void boyash_Click(object sender, EventArgs e)
        {
            index = 7;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index = 8;
        }

        private void togriuchb_Click(object sender, EventArgs e)
        {
            index = 9;
        }

        private void romb_Click(object sender, EventArgs e)
        {
            index = 10;
        }

        private void parallelogramm_Click(object sender, EventArgs e)
        {
            index = 11;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index = 12;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            p.Width = 2;
        }
        private void line2_Click(object sender, EventArgs e)
        {
            p.Width = 5;
        }

        private void line3_Click(object sender, EventArgs e)
        {
            p.Width = 10;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }





        private void Form1_Load(object sender, EventArgs e)
        {
            pic_olcham.Text = $"{pic.Size.Width} x {pic.Size.Height}";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;
            cX = e.X;
            cY = e.Y;
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {

            paint = false;
            sX = x - cX;
            sY = y - cY;

            if (index == 3)
            {
                g.DrawEllipse(p, cX, cY, sX, sY);
            }

            if (index == 4)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
            }
            if (index == 5)
            {
                g.DrawLine(p, cX, cY, x, y);
            }

            if (index == 8)
            {
                Point p1 = new Point(cX + sX / 2, cY);
                Point p2 = new Point(cX + sX, cY + sY);
                Point p3 = new Point(cX, cY + sY);
                Point[] uchburchak =
                {
                    p1 , p2 , p3
                };

                g.DrawPolygon(p, uchburchak);
            }

            if (index == 9)
            {
                Point p1 = new Point(cX, cY);
                Point p2 = new Point(cX + sX, cY + sY);
                Point p3 = new Point(cX, cY + sY);
                Point[] uchburchak =
                {
                    p1 , p2 , p3
                };

                g.DrawPolygon(p, uchburchak);
            }

            if (index == 10)
            {
                Point r1 = new Point(cX + sX / 2, cY);
                Point r2 = new Point(cX + sX, cY + sY / 2);
                Point r3 = new Point(cX + sX / 2, cY + sY);
                Point r4 = new Point(cX, cY + sY / 2);
                Point[] romb =
                {
                   r1 , r2 , r3 , r4
                };

                g.DrawPolygon(p, romb);
            }

            if (index == 11)
            {
                Point p1 = new Point(cX + 2 * sX / 5, cY);
                Point p2 = new Point(cX + sX, cY);
                Point p3 = new Point(cX + 3 * sX / 5, cY + sY);
                Point p4 = new Point(cX, cY + sY);
                Point[] parallelogramm =
                {
                    p1 , p2 , p3,p4
                };

                g.DrawPolygon(p, parallelogramm);
            }

        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            joylashuv.Text = $"{x}, {y}piksel";

            if (paint)
            {
                if (index == 1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;
                }
                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    py = px;
                }
            }
            pic.Refresh();

            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;

        }



        private void fillcolor_Click(object sender, EventArgs e)
        {

        }
        private void pic_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;


            if (paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }

                if (index == 4)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }
                if (index == 5)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }

                if (index == 8)
                {
                    Point p1 = new Point(cX + sX / 2, cY);
                    Point p2 = new Point(cX + sX, cY + sY);
                    Point p3 = new Point(cX, cY + sY);
                    Point[] uchburchak =
                    {
                    p1 , p2 , p3
                };

                    g.DrawPolygon(p, uchburchak);
                }

                if (index == 9)
                {
                    Point p1 = new Point(cX, cY);
                    Point p2 = new Point(cX + sX, cY + sY);
                    Point p3 = new Point(cX, cY + sY);
                    Point[] uchburchak =
                    {
                    p1 , p2 , p3
                };

                    g.DrawPolygon(p, uchburchak);
                }

                if (index == 10)
                {
                    Point r1 = new Point(cX + sX / 2, cY);
                    Point r2 = new Point(cX + sX, cY + sY / 2);
                    Point r3 = new Point(cX + sX / 2, cY + sY);
                    Point r4 = new Point(cX, cY + sY / 2);
                    Point[] romb =
                    {
                   r1 , r2 , r3 , r4
                };

                    g.DrawPolygon(p, romb);
                }


                if (index == 11)
                {
                    Point p1 = new Point(cX + 2 * sX / 5, cY);
                    Point p2 = new Point(cX + sX, cY);
                    Point p3 = new Point(cX + 3 * sX / 5, cY + sY);
                    Point p4 = new Point(cX, cY + sY);
                    Point[] parallelogramm =
                    {
                    p1 , p2 , p3,p4
                };

                    g.DrawPolygon(p, parallelogramm);
                }
            }

        }

        private void tozalashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(color: Color.White);
            pic.Image = bm;
            index = 0;
        }

        private void Palitra_Click(object sender, EventArgs e)
        {

            cd.ShowDialog();
            new_Color = cd.Color;
            pencolor.BackColor = cd.Color;
            p.Color = cd.Color;
        }

        static Point set_point(PictureBox pb, Point pt)
        {
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY));
        }

        private void color_picker_MouseClick(object sender, MouseEventArgs e)
        {

        }




        private void validate(Bitmap bm, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
        {
            Color cx = bm.GetPixel(x, y);
            if (cx == old_color)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, new_color);

            }
        }

        public void Fill(Bitmap bm, int x, int y, Color new_color)
        {
            Color old_color = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, new_color);
            if (old_color == new_color) return;

            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    validate(bm, pixel, pt.X - 1, pt.Y, old_color, new_color);
                    validate(bm, pixel, pt.X, pt.Y - 1, old_color, new_color);
                    validate(bm, pixel, pt.X + 1, pt.Y, old_color, new_color);
                    validate(bm, pixel, pt.X, pt.Y + 1, old_color, new_color);

                }
            }

        }




        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 7)
            {
                Point point = set_point(pic, e.Location);
                Fill(bm, point.X, point.Y, new_Color);

            }
            if (index == 12)
            {
                Point point = set_point(pic, e.Location);
                pencolor.BackColor = ((Bitmap)pic.Image).GetPixel(point.X, point.Y);
                new_Color = pencolor.BackColor;
                p.Color = pencolor.BackColor;
            }
        }



        private void color_picker_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = set_point(pictureBox3, e.Location);
            pencolor.BackColor = ((Bitmap)pictureBox3.Image).GetPixel(point.X, point.Y);
            new_Color = pencolor.BackColor;
            p.Color = pencolor.BackColor;

        }

        private void asasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            saveFile();
        }

        private void asasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Bitmap newImage = new Bitmap(ofd.FileName))
                    {

                        bm = new Bitmap(newImage);
                        pic.Size = bm.Size;
                        g.Clear(Color.White);
                        pic.Image = bm;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Faylni ochishda xatolik : {ex.Message}");
                }
            }
        }

        private void chopEtishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintImage();

        }
        private void PrintImage()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrintPage += (s, ev) =>
                {
                    Bitmap imageToPrint = bm.Clone(new Rectangle(0, 0, pic.Width, pic.Height), bm.PixelFormat);
                    ev.Graphics.DrawImage(imageToPrint, 0, 0);
                };

                printDocument.Print();
            }
        }

        private void yaratishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveFile()
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*)";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Bitmap btm = bm.Clone(new Rectangle(0, 0, pic.Width, pic.Height), bm.PixelFormat);
                btm.Save(sfd.FileName, ImageFormat.Jpeg);
                MessageBox.Show("Rasm muvaffaqiyatli saqlandi");
            }
        }

        private void olchamToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void qollashToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void qollashToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                p.Width = int.Parse(qalamqalingi.Text);
            }
            catch
            {
                MessageBox.Show("Qalam qalinligini berishda xatolik yuz berdi, \nbutun sonlar bo'yicha o'lcham bering");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form2 ikkinchiForm = new Form2();


            ikkinchiForm.Show();




        }



        private void olchamToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
        }

        private void qollashToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(xolcham.Text);
                int y = int.Parse(yolcham.Text);
                Size size = new Size(x, y);
                pic.Size = size;

            }
            catch
            {
                MessageBox.Show("O'lcham berishda xatolik yuz berdi, \nbutun sonlar bo'yicha o'lcham bering");
            }
        }
    }
}


