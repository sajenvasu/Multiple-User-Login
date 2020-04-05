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
    public partial class Form1 : Form
    {
        static string User;
        static string Pass;
        static string Hint;
        public Form1()
        {
            InitializeComponent();

            var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            var width = screen.Width;
            var height = screen.Height;
            this.Size = new Size(width, height);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparm = base.CreateParams;
                handleparm.ExStyle |= 0x02000000;
                return handleparm;
            }
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            panel2.BackColor = Color.FromArgb(90, 0, 0, 0);

            panel3.BackColor = Color.FromArgb(90, 0, 0, 0);

            panel4.BackColor = Color.FromArgb(90, 0, 0, 0);

            panel5.BackColor = Color.FromArgb(90, 0, 0, 0);

            panel2.Location = new Point(
            this.ClientSize.Width / 2 - panel2.Size.Width / 2,
            this.ClientSize.Height / 2 - panel2.Size.Height / 2);
            panel2.Anchor = AnchorStyles.None;

            panel3.Location = new Point(
            this.ClientSize.Width / 2 - panel3.Size.Width / 2,
            this.ClientSize.Height / 2 - panel3.Size.Height / 2);
            panel3.Anchor = AnchorStyles.None;

            panel5.Location = new Point(
            this.ClientSize.Width / 2 - panel5.Size.Width / 2,
            this.ClientSize.Height / 2 - panel5.Size.Height / 2);
            panel5.Anchor = AnchorStyles.None;

            panel4.Location = new Point(
            this.ClientSize.Width / 2 - panel4.Size.Width / 2,
            this.ClientSize.Height / 2 - panel4.Size.Height / 2);
            panel5.Anchor = AnchorStyles.None;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            check_user();
        }

        private void check_user()
        {
            string user = textBox1.Text;
            user = user.ToLower();
            string path = user + ".txt";
            string data;

            bool fileExists = File.Exists(path);

            if (fileExists)
            {
                panel2.Visible = false;
                panel3.Visible = true;
                textBox1.Text = "";
                textBox1.Text = "";

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
                panel2.Visible = false;
                panel4.Visible = true;
                label3.Text = "Username not Valid";
                textBox1.Text = "";
            }


        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            check_pass();
        }

        private void check_pass()
        {
            if (textBox2.Text == Pass)
            {
                panel3.Visible = false;
                panel5.Visible = true;
                label5.Text = "Login Success";
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                panel3.Visible = false;
                panel5.Visible = true;
                label5.Text = "Login Failed\nHint: " + Hint;
                
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            label5.Text = "";
            panel3.Visible = true;
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            label3.Text = "";
            panel2.Visible = true;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            check_user();
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            check_pass();
        }
    }
}
