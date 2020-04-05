using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Multi_Login
{
    public partial class Form2 : Form
    {

        static string User;
        static string Pass;
        static string Hint;
        static int timer = 0;
        static int time = 0;


        public Form2()
        {
            InitializeComponent();

            var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            var width = screen.Width;
            var height = screen.Height;
            this.Size = new Size(width, height);


            timer1.Start();

            panel2.Location = new Point(
            this.ClientSize.Width / 2 - panel2.Size.Width / 2,
            this.ClientSize.Height / 2 - panel2.Size.Height / 2);
            panel2.Anchor = AnchorStyles.None;

            panel3.Location = new Point(
            this.ClientSize.Width / 2 - panel3.Size.Width / 2,
            this.ClientSize.Height / 2 - panel3.Size.Height / 2);
            panel3.Anchor = AnchorStyles.None;

            panel4.Location = new Point(
            this.ClientSize.Width / 2 - panel4.Size.Width / 2,
            this.ClientSize.Height / 2 - panel4.Size.Height / 2);
            panel4.Anchor = AnchorStyles.None;

            panel5.Location = new Point(
            this.ClientSize.Width / 2 - panel5.Size.Width / 2,
            this.ClientSize.Height / 2 - panel5.Size.Height / 2);
            panel5.Anchor = AnchorStyles.None;

            panel9.Location = new Point(
            this.ClientSize.Width / 2 - panel9.Size.Width / 2,
            this.ClientSize.Height / 2 - panel9.Size.Height / 2);
            panel9.Anchor = AnchorStyles.None;

            panel2.BackColor = Color.FromArgb(90, 0, 0, 0);

            panel3.BackColor = Color.FromArgb(90, 0, 0, 0);

            panel4.BackColor = Color.FromArgb(90, 0, 0, 0);

            panel5.BackColor = Color.FromArgb(90, 0, 0, 0);

            panel7.BackColor = Color.FromArgb(0, 0, 0, 0);

            panel8.BackColor = Color.FromArgb(0, 0, 0, 0);

            panel11.BackColor = Color.FromArgb(0, 0, 0, 0);

            panel9.BackColor = Color.FromArgb(90, 0, 0, 0);
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
            label11.Text = "Create Account";
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
            label11.Text = "Delete Account";
            panel4.Visible = true;
            panel3.Visible = false;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            user = user.ToLower();
            User = user;
            string path = User + ".txt";
            string data;

            bool fileExists = File.Exists(path);

            if (fileExists)
            {
                panel2.Visible = false;
                panel5.Visible = true;
                label5.Text = "Username has been taken.\nTry another Username!";
                
            }
            else
            {
                User = textBox1.Text;
                panel7.Visible = false;
                timer = timer + 1;
            }
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            label5.Text = "";
            panel2.Visible = true;
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                Pass = textBox2.Text;
                timer = timer + 1;
                panel8.Visible = false;
            }
            else
            {
                panel2.Visible = false;
                panel5.Visible = true;
                label5.Text = "Passwords do not match.\nTry again!";
            }
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            Hint = textBox4.Text;
            timer = timer + 1;
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            User = User.ToLower();
            StreamWriter File = new StreamWriter(User + ".txt");
            File.Write(User + ";" + Pass + ";" + Hint);
            File.Close();
            panel5.Visible = true;
            label5.Text = "Account was created succesfully!";
            panel2.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            User = "";
            Pass = "";
            Hint = "";
            panel7.Visible = true;
            panel8.Visible = true;
            panel3.Visible = true;
            panel5.Visible = false;
            label5.Text = "";
            label11.Visible = false;
            label11.Text = "";
            timer = 0;

        }

        private void PictureBox14_Click(object sender, EventArgs e)
        {
            string user = textBox8.Text;
            user = user.ToLower();
            string path = user + ".txt";
            string data;

            bool fileExists = File.Exists(path);

            if (fileExists)
            {
                User = textBox8.Text;
                time = time + 1;
                panel11.Visible = false;


                StreamReader sr = new StreamReader(path);
                data = sr.ReadToEnd();
                sr.Close();

                string[] split_data = data.Split(';');

                User = split_data[0];
                Pass = split_data[1];
                Hint = split_data[2];
            }
            else
            {
                panel4.Visible = false;
                panel9.Visible = true;
                label10.Text = "Username is not valid.\nTry Again!";
            }


        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == textBox7.Text)
            {
                
                check_pass();
            }
            else
            {
                panel4.Visible = false;
                panel9.Visible = true;
                label10.Text = "Passwords do not match.\nTry again!";
            }
        }

        private void check_pass()
        {

            if (Pass == textBox6.Text)
            {
                time = time + 1;
            }
            else
            {
                panel4.Visible = false;
                panel9.Visible = true;
                label10.Text = "Password is incorrect.\nTry again!";

            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (timer >= 3)
            {
                pictureBox9.Visible = true;
            }
            else
            {
                pictureBox9.Visible = false;
            }

            if (time >= 2)
            {
                pictureBox10.Visible = true;
            }
            else
            {
                pictureBox10.Visible = false;
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox10_Click(object sender, EventArgs e)
        {
            User = User.ToLower();
            string path = User + ".txt";
            File.Delete(path);
            panel9.Visible = true;
            label10.Text = "Account was deleted succesfully!";
            panel11.Visible = true;
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            User = "";
            Pass = "";
            Hint = "";
            panel9.Visible = false;
            panel4.Visible = false;
            label10.Text = "";
            label11.Visible = false;
            label11.Text = "";
            time = 0;
            panel3.Visible = true;
        }

        private void PictureBox15_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel9.Visible = false;
            label10.Text = "";
        }
    }
}
