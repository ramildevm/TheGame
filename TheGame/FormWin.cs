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
    public partial class FormWin : Form
    {
        public FormFindNum form1;
        public FormWin()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                bool flag = true;
                using (PlayerContext db = new PlayerContext())
                {
                    foreach (Player player in db.Players)
                    {
                        if (textBox1.Text == player.Name)
                        {
                            if(Convert.ToInt32(player.HighScore.Substring(3)) + Convert.ToInt32(player.HighScore.Substring(0, 2))*60 >= Convert.ToInt32(form1.textBoxTimer.Text.Substring(3)) + Convert.ToInt32(form1.textBoxTimer.Text.Substring(0, 2)))
                            {
                                player.HighScore = form1.textBoxTimer.Text;
                                flag = false;
                            }
                        }
                    }
                    if (flag)
                    {
                        db.Players.Add(new Player(textBox1.Text, form1.textBoxTimer.Text));
                    }
                    db.SaveChanges();
                }
                MessageBox.Show("Данные успешно сохранены.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Введены недопустимые данные.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
