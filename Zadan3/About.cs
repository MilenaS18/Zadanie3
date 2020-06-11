using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zadan3
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "Unable to open link that was clicked.");
            }
        }
        private void VisitLink()
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.mysite.com");
        }
        private void button1_Click(object sender,System.EventArgs e)
        {
            this.Close();
        }
        private void mnuAbout_Click(object sender,System.EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
                 
        }
    }
}
