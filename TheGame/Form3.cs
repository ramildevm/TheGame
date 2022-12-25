using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGame
{
    public partial class Form3 : Form
    {
        FormFindNum form;
        public Form3(FormFindNum f)
        {
            InitializeComponent();
            form = f;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked) form.randomOn = true;
            this.Close();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) form.randomOn = true;
            form.timerReverse = true;
            form.timerMinute = 1;
            form.timerCounter = 10;
            this.Close();
        }
    }
}
