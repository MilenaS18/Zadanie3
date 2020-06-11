using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace Zadan3
{
    public partial class frmmain : Form
    {
        public string CultureDefine;
        private string EnglishCulture;
        private string RussianCulture;
        public static ResourceManager resourceManager;
        private int openDocuments = 0;
        public frmmain()
        {
            Thread.CurrentThread.CurrentUICulture 
            = Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            EnglishCulture = "en-US";
            RussianCulture = "ru-RU";
            CultureDefine = CultureInfo.InstalledUICulture.ToString();
            resourceManager = new ResourceManager("Zadan3.ClosingText", Assembly.GetExecutingAssembly());
            mnuSave.Enabled = false;
        }
        public frmmain(string FormCulture)
        {
            Thread.CurrentThread.CurrentUICulture 
            = Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            EnglishCulture = "en-US";
            RussianCulture = "ru-RU";
            CultureDefine = CultureInfo.InstalledUICulture.ToString();
            resourceManager = new ResourceManager("Zadan3.ClosingText", Assembly.GetExecutingAssembly());
            mnuSave.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            blank frm = new blank();
            frm.DocName = "Unitled" + ++openDocuments;
            frm.Text = frm.DocName;
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileVetrical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Paste();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Delete();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.SelectAll();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                
            {
                blank frm = new blank();
                frm.Open(openFileDialog1.FileName);
                frm.MdiParent = this;
                frm.DocName = openFileDialog1.FileName;
                frm.Text = frm.DocName;
                frm.Show();
                mnuSave.Enabled = true;
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = (blank)this.ActiveMdiChild;
                frm.Save(saveFileDialog1.FileName);
                frm.MdiParent = this;
                frm.DocName = saveFileDialog1.FileName;
                frm.Text = frm.DocName;
                frm.Save(frm.DocName);
                frm.IsSaved = true;

            }
        }

        private void cmnuSaveAs_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = (blank)this.ActiveMdiChild;
                frm.Save(saveFileDialog1.FileName);
                frm.MdiParent = this;
                frm.DocName = saveFileDialog1.FileName;
                frm.Text = frm.DocName;
                mnuSave.Enabled = true;
                frm.IsSaved = true;
            }
        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            fontDialog1.ShowColor = true;
            fontDialog1.Font = frm.richTextBox1.SelectionFont;
            fontDialog1.Color = frm.richTextBox1.SelectionColor;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionFont = fontDialog1.Font;
                frm.richTextBox1.SelectionColor = fontDialog1.Color;
            }
            frm.Show();
        }
        
            private void mnuColor_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            colorDialog1.Color = frm.richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionColor = colorDialog1.Color;
            }
            frm.Show();

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }
        private void colorDialog1_Apply(object sender, EventArgs e)
        
        {

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tbNew_Click_1(object sender, EventArgs e)
        {
            mnuNew_Click(this, new EventArgs());
        }

        private void tbOpen_Click_1(object sender, EventArgs e)
        {
            mnuOpen_Click(this, new EventArgs());
        }

        private void tbSave_Click_1(object sender, EventArgs e)
        {
            mnuSave_Click(this, new EventArgs());
        }

        private void tbCut_Click_1(object sender, EventArgs e)
        {
            mnuCut_Click(this, new EventArgs());
        }

        private void tbCopy_Click_1(object sender, EventArgs e)
        {
            mnuCopy_Click(this, new EventArgs());
        }

        private void tbPaste_Click_1(object sender, EventArgs e)
        {
            mnuPaste_Click(this, new EventArgs());
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"D:/Справка/Notepad.html");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CultureDefine = EnglishCulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureDefine, false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureDefine, false);
            frmmain frm = new frmmain(CultureDefine);
            this.Hide();
            frm.Show();

        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CultureDefine = RussianCulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureDefine, false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureDefine, false);
            frmmain frm = new frmmain(CultureDefine);
            this.Hide();
            frm.Show();
        }
        private void Form1_Closed(object sender, System.EventArgs e)
        {
            Application.Exit();
        }   
    }
 }
   

