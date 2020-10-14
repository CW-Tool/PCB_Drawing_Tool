using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCB_Drawing_Tool
{
    public partial class Form1 : Form
    {
        private LineManager lineManager;

        public Form1()
        {
            this.lineManager = new LineManager();

            InitializeComponent();
        }

        private void Form1_Load(object sender, PaintEventArgs e)
        {
            
        }

        private void PaintGraphics(object sender, System.Windows.Forms.PaintEventArgs args)
        {
            int numberOfLines = lineManager.GetLineCount();
            for (int i = 1; i <= numberOfLines; i++)
            {
                Console.WriteLine(i);
                List<int> info = lineManager.GetLineDetails(i);
                DrawLine(info[0], info[1], info[2], info[3], info[4]);
            }
        }

        private void DrawLine(int x1, int y1, int x2, int y2, int linewidth)
        {
            int width = Math.Abs(x2-x1);
            int height = Math.Abs(y2-y1);
            int picBoxNum = lineManager.GetLineCount();

            PictureBox picBox = new PictureBox { Location = new Point(x1, y1), Name = "lineBox"+picBoxNum, Size = new Size(width+300, height+300), BackColor = Color.Black };

            Bitmap bitmap = new Bitmap(width+300, height+300);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (Pen pen = new Pen(Color.Red, linewidth))
                {
                    int margin = Convert.ToInt16(linewidth / 1.4);
                    int startPosX = 0; 
                    int startPosY = 0;
                    int endPosX = width;
                    int endPosY = height;
                    if (x2-x1 < 0 ^ y2-y1 < 0)
                    {
                        startPosX = 0;
                        startPosY = height;
                        endPosX = width;
                        endPosY = 0;
                    } 
                    g.DrawLine(pen, startPosX+margin, startPosY+margin, endPosX+margin, endPosY+margin);
                }
            }

            picBox.Image = bitmap;
            mainDrawBox.Controls.Add(picBox);
            Console.WriteLine(mainDrawBox.Controls.GetChildIndex(picBox));
            Console.WriteLine(picBoxNum + 100);
            mainDrawBox.Controls.SetChildIndex(picBox, (picBoxNum+100);
            Console.WriteLine(mainDrawBox.Controls.GetChildIndex(picBox));

        }

        private void CreateLineLabel(int x1, int y1, int x2, int y2, int linewidth)
        {
            int lineID = this.lineManager.AddLine(x1, y1, x2, y2, linewidth);
            Point location = new Point(15 + x1 + (x2 - x1) / 2, -15 + y1 + (y2 - y1) / 2);
            Label currentLabel = new Label { Name = "lblID"+lineID, Location = location, Text = "ID"+lineID, BackColor = Color.Transparent};
            mainDrawBox.Controls.Add(currentLabel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int x1 = Int16.Parse(txtX1.Text);
                int y1 = Int16.Parse(txtY1.Text);
                int x2 = Int16.Parse(txtX2.Text);
                int y2 = Int16.Parse(txtY2.Text);
                int linewidth = Int16.Parse(cboLinewidth.Text);

                CreateLineLabel(x1, y1, x2, y2, linewidth);
                DrawLine(x1, y1, x2, y2, linewidth);
            } catch (Exception error)
            {
                makeErrorMsgBox(error);
            }
            
        }

        private void makeErrorMsgBox(Exception error) 
        {
            System.Windows.Forms.MessageBox.Show("Something went wrong: " + error);
        }
    }
}
