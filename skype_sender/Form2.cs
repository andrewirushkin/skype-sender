using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace skype_sender
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void setText(String text)
        {
            richTextBox1.Text += text;            
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
