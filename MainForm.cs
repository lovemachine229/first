using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm frm = new ChildForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuItemOpen_Click(object sender, EventArgs e)
        {
            Form activeForm = this.ActiveMdiChild;
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Title = "Mở file";
            openDlg.Filter = "Mở file văn bản | *.txt";
            openDlg.InitialDirectory = @"C:\";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openDlg.FileName);
                if (activeForm != null)
                {
                    RichTextBox richtxt = (RichTextBox)activeForm.ActiveControl;
                    if (richtxt != null)
                        richtxt.Text = reader.ReadToEnd();
                }
                else
                    MessageBox.Show("Không có form để hiển thị");
                reader.Close();
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form activeForm = this.ActiveMdiChild;
            if (activeForm != null)
            {
                activeForm.Close();
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != null)
                    frm.Close();
            }
        }

        private void cascaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arangIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void tigerHorizontialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void toolStripNew_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void toolStripOpen_Click(object sender, EventArgs e)
        {
            mnuItemOpen_Click(sender, e);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
