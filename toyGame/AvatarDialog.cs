using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game.toyGame
{
    public partial class AvatarDialog : Form
    {
        public int AvatarNumber { get { return Convert.ToInt32(this.pictureBox1.Tag); } }
        public string AvatarName { get { return this.NameBox.Text; } }

        public AvatarDialog()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {
            int tagNumber = Convert.ToInt32(this.pictureBox1.Tag);
            switch (tagNumber)
            {
                case 1:
                    this.pictureBox1.BackgroundImage = Properties.Resources._2;
                    this.pictureBox1.Tag = 2;
                    break;
                case 2:
                    this.pictureBox1.BackgroundImage = Properties.Resources._3;
                    this.pictureBox1.Tag = 3;
                    break;
                case 3:
                    this.pictureBox1.BackgroundImage = Properties.Resources._4;
                    this.pictureBox1.Tag = 4;
                    break;
                case 4:
                    this.pictureBox1.BackgroundImage = Properties.Resources._5;
                    this.pictureBox1.Tag = 5;
                    break;
                case 5:
                    this.pictureBox1.BackgroundImage = Properties.Resources._6;
                    this.pictureBox1.Tag = 6;
                    break;
                case 6:
                    this.pictureBox1.BackgroundImage = Properties.Resources._7;
                    this.pictureBox1.Tag = 7;
                    break;
                case 7:
                    this.pictureBox1.BackgroundImage = Properties.Resources._8;
                    this.pictureBox1.Tag = 8;
                    break;
                case 8:
                    this.pictureBox1.BackgroundImage = Properties.Resources._9;
                    this.pictureBox1.Tag = 9;
                    break;
                case 9:
                    this.pictureBox1.BackgroundImage = Properties.Resources._10;
                    this.pictureBox1.Tag = 10;
                    break;
                case 10:
                    this.pictureBox1.BackgroundImage = Properties.Resources._11;
                    this.pictureBox1.Tag = 11;
                    break;
                case 11:
                    this.pictureBox1.BackgroundImage = Properties.Resources._12;
                    this.pictureBox1.Tag = 12;
                    break;
                case 12:
                    this.pictureBox1.BackgroundImage = Properties.Resources._13;
                    this.pictureBox1.Tag = 13;
                    break;
                case 13:
                    this.pictureBox1.BackgroundImage = Properties.Resources._14;
                    this.pictureBox1.Tag = 14;
                    break;
                case 14:
                    this.pictureBox1.BackgroundImage = Properties.Resources._15;
                    this.pictureBox1.Tag = 15;
                    break;
                case 15:
                    this.pictureBox1.BackgroundImage = Properties.Resources._1;
                    this.pictureBox1.Tag = 1;
                    break;

                default:
                    this.pictureBox1.BackgroundImage = Properties.Resources._1;
                    this.pictureBox1.Tag = 1;
                    break;
            }
        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            int tagNumber = Convert.ToInt32(this.pictureBox1.Tag);
            switch (tagNumber)
            {
                case 1:
                    this.pictureBox1.BackgroundImage = Properties.Resources._15;
                    this.pictureBox1.Tag = 15;
                    break;
                case 2:
                    this.pictureBox1.BackgroundImage = Properties.Resources._1;
                    this.pictureBox1.Tag = 1;
                    break;
                case 3:
                    this.pictureBox1.BackgroundImage = Properties.Resources._2;
                    this.pictureBox1.Tag = 2;
                    break;
                case 4:
                    this.pictureBox1.BackgroundImage = Properties.Resources._3;
                    this.pictureBox1.Tag = 3;
                    break;
                case 5:
                    this.pictureBox1.BackgroundImage = Properties.Resources._4;
                    this.pictureBox1.Tag = 4;
                    break;
                case 6:
                    this.pictureBox1.BackgroundImage = Properties.Resources._5;
                    this.pictureBox1.Tag = 5;
                    break;
                case 7:
                    this.pictureBox1.BackgroundImage = Properties.Resources._6;
                    this.pictureBox1.Tag = 6;
                    break;
                case 8:
                    this.pictureBox1.BackgroundImage = Properties.Resources._7;
                    this.pictureBox1.Tag = 7;
                    break;
                case 9:
                    this.pictureBox1.BackgroundImage = Properties.Resources._8;
                    this.pictureBox1.Tag = 8;
                    break;
                case 10:
                    this.pictureBox1.BackgroundImage = Properties.Resources._9;
                    this.pictureBox1.Tag = 9;
                    break;
                case 11:
                    this.pictureBox1.BackgroundImage = Properties.Resources._10;
                    this.pictureBox1.Tag = 10;
                    break;
                case 12:
                    this.pictureBox1.BackgroundImage = Properties.Resources._11;
                    this.pictureBox1.Tag = 11;
                    break;
                case 13:
                    this.pictureBox1.BackgroundImage = Properties.Resources._12;
                    this.pictureBox1.Tag = 12;
                    break;
                case 14:
                    this.pictureBox1.BackgroundImage = Properties.Resources._13;
                    this.pictureBox1.Tag = 13;
                    break;
                case 15:
                    this.pictureBox1.BackgroundImage = Properties.Resources._14;
                    this.pictureBox1.Tag = 14;
                    break;

                default:
                    this.pictureBox1.BackgroundImage = Properties.Resources._1;
                    this.pictureBox1.Tag = 1;
                    break;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
