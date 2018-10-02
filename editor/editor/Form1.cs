using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        PaintEventArgs X;
        PaintEventArgs Y;
        int x1;
        int y1;
        int x2;
        int y2;
        bool mouseDown;
        Bitmap snapshot;
        Bitmap tempDraw;
        Color foreColor;
        string selectedTool;
        int lineWidth;
        int CursorX;
        int CursorY;
        PaintEventArgs pEventArg;
        FileInfo file = null;
        
        public Form1()
        {
            InitializeComponent();
            snapshot = new Bitmap(panel1.ClientRectangle.Width, this.ClientRectangle.Height);
            g = Graphics.FromImage(snapshot);
            foreColor = Color.Black;
            lineWidth = 1;
            this.SetStyle(ControlStyles.UserPaint, true);
            // timer1.Start();
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
            selectedTool = "q";
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
               


                button4.BackColor = MyDialog.Color;
                panel1.BackColor = MyDialog.Color;

                g.Clear(Color.White);
                g = Graphics.FromImage(snapshot);
                g.FillRectangle(new SolidBrush(MyDialog.Color), 0, 0, panel1.ClientRectangle.Width, this.ClientRectangle.Height);
                g = panel1.CreateGraphics();
                


            }
        }


        private void panel1_MouseHover(object sender, EventArgs e)
        {
            //this.Cursor = new Cursor("C:/Users/hp/Desktop/brash.cur");
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
            /*if (isPressed) {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                for_paint();
            }*/
            if (mouseDown)
            {
                x2 = e.X;
                y2 = e.Y;
                panel1.Invalidate();

                //panel1.Update();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            x1 = e.X;
            y1 = e.Y;

            tempDraw = (Bitmap)snapshot.Clone();

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            snapshot = (Bitmap)tempDraw.Clone();

        }
        private Random _rnd = new Random();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            pEventArg = e;
            switch (selectedTool)
            {
                case "button10":
                    if (tempDraw != null)
                    {
                        tempDraw = (Bitmap)snapshot.Clone();
                        Graphics g = Graphics.FromImage(tempDraw);
                        Pen myPen = new Pen(foreColor, lineWidth);
                        g.DrawLine(myPen, x1, y1, x2, y2);
                        myPen.Dispose();
                        e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        g.Dispose();
                    }
                    break;
                   
                case "button8":
                    if (tempDraw != null)
                    {
                        tempDraw = (Bitmap)snapshot.Clone();
                        Graphics g = Graphics.FromImage(tempDraw);
                        Pen myPen = new Pen(CurrentColor, lineWidth);
                        g.DrawRectangle(myPen, x1, y1, x2 - x1, y2 - y1);
                        myPen.Dispose();
                        e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        g.Dispose();
                    }
                    break;
                case "button9":
                    if (tempDraw != null)
                    {
                        tempDraw = (Bitmap)snapshot.Clone();
                        Graphics g = Graphics.FromImage(tempDraw);
                        Pen myPen = new Pen(CurrentColor, lineWidth);
                        g.DrawEllipse(myPen, x1, y1, x2 - x1, y2 - y1);
                        myPen.Dispose();
                        e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        g.Dispose();
                    }
                    break;

            

                case "button1":
                    if (tempDraw != null)
                    {
                        Graphics g = Graphics.FromImage(tempDraw);
                        Pen myPen = new Pen(CurrentColor, lineWidth);
                        g.DrawLine(myPen, x1, y1, x2, y2);
                        myPen.Dispose();
                        e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        g.Dispose();
                        x1 = x2;
                        y1 = y2;
                    }
                    break;

                case "button2":
                    if (tempDraw != null)
                    {
                        Graphics g = Graphics.FromImage(tempDraw);
                        Pen myPen = new Pen(CurrentColor, lineWidth);
                        int k;
                        Random r = new Random();
                        
                          for(k= 0;k<10;k++)
                            {
                            int i = r.Next(-20, 20);
                            int j = r.Next(-20, 20);
                            if ((Math.Pow(i,2)+ Math.Pow(j, 2))<=400)
                            g.DrawLine(myPen, x2 + i, y2 + j, x2 + 1 + i, y2 + j );
                            

                        }
                        
                        myPen.Dispose();
                        e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        g.Dispose();
                        x1 = x2;
                        y1 = y2;
                    }
                    break;


                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            selectedTool = button1.Name;
           
    }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedTool = button2.Name;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            selectedTool = button8.Name;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            selectedTool = button9.Name;
        }


        
        private void button10_Click(object sender, EventArgs e)
        {
            selectedTool = button10.Name;
        }
       
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        { 

        }

        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
            ImageFormat format = ImageFormat.Png;
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        snapshot.Save(sfd.FileName,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        snapshot.Save(sfd.FileName,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        
                        break;

                    case 3:
                        snapshot.Save(sfd.FileName,
                           System.Drawing.Imaging.ImageFormat.Png);
                        
                        break;
                }
                file = new FileInfo(sfd.FileName);
            }
            
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file != null) {
                snapshot.Save(file.FullName);

            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = "q";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
            

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                g.Clear(Color.White);
                
                
               
                // Assign the cursor in the Stream to the Form's Cursor property.  
                snapshot = new Bitmap(openFileDialog1.OpenFile());
                g = Graphics.FromImage(snapshot);
                g = panel1.CreateGraphics();
                tempDraw = (Bitmap)snapshot.Clone();
            }
        }

        private void пензельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = button1.Name;
        }

        private void розпиленняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = button2.Name;
        }

        private void гумкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void фонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTool = "q";
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {



                button4.BackColor = MyDialog.Color;
                panel1.BackColor = MyDialog.Color;

                g.Clear(Color.White);
                g = Graphics.FromImage(snapshot);
                g.FillRectangle(new SolidBrush(MyDialog.Color), 0, 0, panel1.ClientRectangle.Width, this.ClientRectangle.Height);
                g = panel1.CreateGraphics();



            }
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

        }
    }
}
