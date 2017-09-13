using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GetInfo_XP
{
    public partial class Rewrite : Form
    {
        public string getName { get; set; }
        public string getPath { get; set; }
        public string getContent { get; set; }
        public Rewrite()
        {
            InitializeComponent();

        }

        private void Rewrite_Load(object sender, EventArgs e)
        {
            string a = getName;
            string b = getPath;
            string c = getContent;
            label1.Text = a + ".txt" + " has existed.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter info = new StreamWriter(getPath);
            info.Write(getContent);
            info.Flush();
            info.Close();
            DialogResult done = MessageBox.Show("Done.");
            if (done==DialogResult.OK )
            {
                System.Diagnostics.Process.Start(getPath );
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
