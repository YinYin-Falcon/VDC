using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VDC
{
    public partial class FormSettings : Form
    {
        public FormVDC vdc;

        public FormSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.font = fontDialog1.Font;
                textBox1.Text = Properties.Settings.Default.font.Name;
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.font.Name;
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            vdc.fs = null;
            Properties.Settings.Default.Save();
        }
    }
}