using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Threading;


namespace Zadan3
{
    public partial class blank : Form
    {
        public string DocName = "";
        

        public blank()
        {
            InitializeComponent();
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            sbTime.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void Cut()
        {
            richTextBox1.Cut();
        }
        public void Copy()
        {
            richTextBox1.Copy();
        }
        public void Paste()
        {
            richTextBox1.Paste();
        }
        public void SelectAll()
        {
            richTextBox1.SelectAll();
        }
        public void Delete()
        {
            richTextBox1.SelectedText = "";
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut(); 
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        public void Open(string OpenFileName)
        {
            if (OpenFileName == "")
            {
                return;
            }
            else
            {
                StreamReader sr = new StreamReader(OpenFileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                DocName = OpenFileName;
            }
        }
             public void Save (string SaveFileName)
        {
            if(SaveFileName=="")
            {
                return;
            }
            else
            {
                StreamWriter sw = new StreamWriter(SaveFileName);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
                DocName=SaveFileName;
            }
        }
             public bool IsSaved = false;
             private void blank_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
             {
                 if(IsSaved==false)
                     if (MessageBox.Show(frmmain.resourceManager.GetString("MessageText"), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                         this.Save(this.DocName);
                     }
             

             }

             private void richTextBox1_TextChanged_1(object sender, EventArgs e)
             {
                 sbAmount.Text = "Amount of symbols" + richTextBox1.Text.Length.ToString();
                 IsSaved = false;
             }

            
    }
}
