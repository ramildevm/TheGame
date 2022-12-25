using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TheGame
{
    public partial class FormFindNum : Form
    {
        List<int> numbers = new List<int>();
        IEnumerable<int> nums = Enumerable.Range(1, 90);
        System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
        Random rnd = new Random();
        public bool randomOn = false;
        public bool timeOn = false;
        public bool timerReverse = false;

        public Timer timer = new Timer();
        public int timerCounter = 0;
        public int timerMinute = 0;
        public FormFindNum()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
        }
        private void FormFindNum_Load(object sender, EventArgs e)
        {
            foreach (var button in this.Controls)
            {
                try
                {
                    if (((Button)button).Text != "Старт")
                    {
                        ((Button)button).Text = "";
                    }
                }
                catch { }
            }
            #region Buttons
            // редактирование кнопок
            Point[] points = new Point[] {
                new Point(0, 0),
                new Point(button6.Width, (int)button6.Height*1/4),
                new Point(button6.Width, (int)button6.Height*3/4),
                new Point(0, button6.Height)
            };
            button6.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            points = new Point[] {
                new Point(button7.Width, 0),
                new Point(0, (int)button7.Height*1/4),
                new Point(0, (int)button7.Height*3/4),
                new Point(button7.Width, button7.Height)
            };
            button7.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point(button13.Width,0),
                new Point((int)button13.Width/2, button13.Height)
            };
            button13.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            points = new Point[] {
                new Point(button15.Width, 0),
                new Point(0, (int)button15.Height*1/4),
                new Point(0, (int)button15.Height*3/4),
                new Point(button15.Width, button15.Height)
            };
            button15.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            control10.BringToFront();
            control11.BringToFront();
            button15.BringToFront();
            button13.BringToFront();
            points = new Point[] {
                new Point(0, 0),
                new Point(button25.Width, (int)button25.Height*1/4),
                new Point(button25.Width, (int)button25.Height*3/4),
                new Point(0, button25.Height)
            };
            button25.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));

            points = new Point[] {
                new Point(button24.Width, 0),
                new Point(0, (int)button24.Height*1/4),
                new Point(0, (int)button24.Height*3/4),
                new Point(button24.Width, button24.Height)
            };
            button24.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point(button35.Width, 0),
                new Point((int)button35.Width*3/4, button35.Height),
                new Point((int)button35.Width/4, button35.Height)
            };
            button35.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));

            points = new Point[] {
                new Point(0, 0),
                new Point((int)button36.Width*3/4, 0),
                new Point(button36.Width, button36.Height),
                new Point((int)button36.Width/4, button36.Height)
            };
            button36.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            points = new Point[] {
                new Point((int)button37.Width/4, 0),
                new Point(button37.Width, 0),
                new Point((int)button37.Width*3/4, button37.Height),
                new Point(0, button37.Height)
            };
            button37.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point(button38.Width, 0),
                new Point(button38.Width, button38.Height),
                new Point((int)button38.Width/2, button38.Height)
            };
            button38.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point((int)button39.Width, 0),
                new Point((int)button39.Width/2, button39.Height),
                new Point(0, button39.Height)
            };
            button39.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            button35.BringToFront();
            button36.BringToFront();
            button37.BringToFront();
            button38.BringToFront();
            button39.BringToFront();
            button8.BringToFront();
            button42.BringToFront();
            points = new Point[] {
                new Point(0, 0),
                new Point(button35.Width, 0),
                new Point((int)button35.Width*3/4, button35.Height),
                new Point((int)button35.Width/4, button35.Height)
            };
            button50.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));

            points = new Point[] {
                new Point(0, 0),
                new Point((int)button36.Width*3/4, 0),
                new Point(button36.Width, button36.Height),
                new Point((int)button36.Width/4, button36.Height)
            };
            button49.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            points = new Point[] {
                new Point((int)button37.Width/4, 0),
                new Point(button37.Width, 0),
                new Point((int)button37.Width*3/4, button37.Height),
                new Point(0, button37.Height)
            };
            button48.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point(button38.Width, 0),
                new Point(button38.Width, button38.Height),
                new Point((int)button38.Width/2, button38.Height)
            };
            button47.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point((int)button39.Width, 0),
                new Point((int)button39.Width/2, button39.Height),
                new Point(0, button39.Height)
            };
            button50.BringToFront();
            button49.BringToFront();
            button48.BringToFront();
            button47.BringToFront();
            button46.BringToFront();
            button43.BringToFront();
            button46.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point(button59.Width,0),
                new Point((int)button59.Width/2, button59.Height)
            };
            button59.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            button59.BringToFront();
            points = new Point[] {
                new Point((int)button54.Width*2/6, 0),
                new Point((int)button54.Width*4/6, 0),
                new Point((int)button54.Width, button54.Height),
                new Point(0, button54.Height)
            };
            button54.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            button54.BringToFront();
            points = new Point[] {
                new Point(0, 0),
                new Point(control4.Width,0),
                new Point(0, control4.Height)
            };
            control4.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            points = new Point[] {
                new Point(0, button62.Height),
                new Point((int)button62.Width/2,0),
                new Point(button62.Width, button62.Height)
            };
            button62.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point(button63.Width,0),
                new Point((int)button63.Width/2, button63.Height)
            };
            button63.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));

            points = new Point[] {
                new Point(control5.Width/2, 0),
                new Point(control5.Width, 0),
                new Point(control5.Width, control5.Height),
                new Point(0, control5.Height)
            };
            control5.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));
            control4.BringToFront();
            button61.BringToFront();
            button62.BringToFront();
            button63.BringToFront();
            button64.BringToFront();
            points = new Point[] {
                new Point(0, 0),
                new Point(button73.Width,0),
                new Point((int)button73.Width/2, button73.Height)
            };
            button73.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));

            button59.BringToFront();
            points = new Point[] {
                new Point(button74.Width, 0),
                new Point(button74.Width,button74.Height),
                new Point(0, button74.Height/2)
            };
            button74.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point(button75.Width,button75.Height/2),
                new Point(0, button75.Height)
            };
            button75.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            button69.BringToFront();
            button75.BringToFront();
            control9.BringToFront();
            button76.BringToFront();
            points = new Point[] {
                new Point((int)button80.Width*2/6, 0),
                new Point((int)button80.Width*4/6, 0),
                new Point((int)button80.Width, button80.Height),
                new Point(0, button80.Height)
            };
            button80.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1, 1 }));

            points = new Point[] {
                new Point(0, 0),
                new Point(control7.Width,control7.Height),
                new Point(0, control7.Height)
            };
            control7.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            points = new Point[] {
                new Point(control9.Width, 0),
                new Point(control9.Width,control9.Height),
                new Point(0, control9.Height)
            };
            control9.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point(button85.Width,0),
                new Point((int)button85.Width/2, button85.Height)
            };
            button85.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            button85.BringToFront();
            points = new Point[] {
                new Point(0, 0),
                new Point(button86.Width,button86.Height/2),
                new Point(0, button86.Height)
            };
            button86.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            points = new Point[] {
                new Point(button87.Width, 0),
                new Point(button87.Width,button87.Height),
                new Point(0, button87.Height/2)
            };
            button87.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            points = new Point[] {
                new Point(0, 0),
                new Point(button88.Width,0),
                new Point((int)button88.Width/2, button88.Height)
            };
            button88.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));
            points = new Point[] {
                new Point(0, button89.Height),
                new Point(button89.Width,button89.Height),
                new Point((int)button89.Width/2, 0)
            };
            button89.Region = new Region(new GraphicsPath(points, new byte[] { 1, 1, 1 }));

            System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, this.button21.Width, this.button21.Height);
            Region Button_Region = new Region(Button_Path);
            this.button21.Region = Button_Region;

            Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, this.button20.Width, this.button20.Height);
            Button_Region = new Region(Button_Path);
            this.button20.Region = Button_Region;

            Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, this.button55.Width, this.button55.Height);
            Button_Region = new Region(Button_Path);
            this.button55.Region = Button_Region;

            Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, this.button33.Width, this.button33.Height);
            Button_Region = new Region(Button_Path);
            this.button33.Region = Button_Region;
            Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, this.button90.Width, this.button90.Height);
            Button_Region = new Region(Button_Path);
            this.button90.Region = Button_Region;
            button21.BringToFront();
            button20.BringToFront();
            button15.BringToFront();
            button66.BringToFront();
            button84.BringToFront();
            button33.BringToFront();
            button55.BringToFront();
            #endregion
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            if (!timerReverse)
            {
                if (timerCounter == 59) { timerMinute += 1; timerCounter = -1; }
                string elapsedTime = String.Format("{0:00}:{1:00}", timerMinute, ++timerCounter);
                this.textBoxTimer.Text = elapsedTime;
            }
            else
            {
                if (timerCounter == 0) { timerMinute -= 1; timerCounter = 60; }
                timerCounter--;
                string elapsedTime = String.Format("{0:00}:{1:00}", timerMinute, timerCounter);
                this.textBoxTimer.Text = elapsedTime;
                if (textBoxTimer.Text == "00:00")
                {
                    MessageBox.Show("Вы проиграли(((" + textBoxTimer.Text, "Увы но!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    textBox1.Text = "1";
                    if (randomOn) textBox1.Text = rnd.Next(1, 90).ToString();
                    timerCounter = 10;
                    timerMinute = 1;
                    elapsedTime = String.Format("{0:00}:{1:00}", timerMinute, timerCounter);
                    this.textBoxTimer.Text = elapsedTime;
                }
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == textBox1.Text && ((Button)sender).Text != "90")
            {
                textBox1.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
                if(randomOn) textBox1.Text = rnd.Next(1,90).ToString();
            }
            else if (((Button)sender).Text == textBox1.Text && ((Button)sender).Text == "90")
            {
                timer.Stop();
                if (!timerReverse)
                {
                    MessageBox.Show("Вы выиграли!\nВаше время составляет: " + textBoxTimer.Text, "Поздравляем!", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("Вы выиграли!", "Поздравляем!", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                FormWin form = new FormWin();
                form.form1 = this;
                form.ShowDialog();
                textBox1.Text = "1";
                if (randomOn) textBox1.Text = rnd.Next(1, 90).ToString();
            }
        }
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            if (randomOn) textBox1.Text = rnd.Next(1, 90).ToString();
            timerCounter = 0;
            timerMinute = 0;
            textBoxTimer.Text = "00:00";
            Form3 form3 = new Form3(this);
            this.Visible = false;
            form3.ShowDialog();
            this.Visible = true;
            // создание массива с перемешанными числами
            int[] numsArr = nums.ToArray();
            Shuffle(numsArr);            
            // присваивание кнопкам чисел
            int i = 0;
            foreach (var button in this.Controls)
            {
                try
                {
                    if (((Button)button).Text != "Старт")
                    {
                        ((Button)button).Text = numsArr[i].ToString();
                        i++;
                    }
                }
                catch { }
            }
            timer.Start();
        }
        private void ТаблицаРекордовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }
        public static void Shuffle(int[] arr)
        {
            Random rand = new Random();
            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                int tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }
    }
}
