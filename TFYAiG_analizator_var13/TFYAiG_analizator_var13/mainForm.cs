using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TFYAiG_analizator_var13
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }


        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            message.Text = Analyzer.getAnalize(stroka.Text);
            stroka.Select();
            stroka.SelectionLength = 1;
            stroka.SelectionStart = Analyzer.Pos;
            constant.Items.Clear();
            identifikator.Items.Clear();
            foreach (int i in Analyzer.Constants)
                constant.Items.Add(i);
            foreach (string i in Analyzer.Identifikators)
                identifikator.Items.Add(i);
            iterations.Text = Analyzer.Count();
            
        }

        private void разработчикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Михаил Гуреев\r\nгруппа 6301\r\n2017 год");
        }

        private void заданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new task().Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
