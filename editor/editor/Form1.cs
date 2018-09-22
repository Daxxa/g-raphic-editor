using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace editor
{
    public partial class Form1 : Form
    {
        Color CurrentColor = Color.Black;
        bool isPressed = false;
        Point CurrentPoint;
        Point PrevPoint;
        Graphics g;
        PaintEventArgs f;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void iNFOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                button6.BackColor = button5.BackColor;
                button5.BackColor = MyDialog.Color;
                
                
            }
            DialogResult D = MyDialog.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK) {
                CurrentColor = MyDialog.Color;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button7.Visible = true;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button7.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 mainf = new Form1();
            int x, y, xx, yy;
            x = Convert.ToInt32(textBox1.Text);
            y = Convert.ToInt32(textBox2.Text);
            button7.Visible = false;
            panel1.Height = y;
            panel1.Width = x;
            mainf.Height = mainf.Height + (250 - y);
            mainf.Width = mainf.Width + (500 - x);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                button4.BackColor = MyDialog.Color;
                panel1.BackColor = MyDialog.Color;
            }
        }

       

      
        private void for_paint() {
            Pen p = new Pen(CurrentColor);
            p.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;

            g.DrawLine(p, PrevPoint, CurrentPoint);
        }
        private void for_paint1() {
            Brush l = new SolidBrush(Color.Beige);
            Brush solidFunnyOrangyBrownBrush = new SolidBrush(Color.FromArgb(255, 155, 100));
            
        }
       

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed) {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                for_paint();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            CurrentPoint = e.Location;

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }
    }
}
