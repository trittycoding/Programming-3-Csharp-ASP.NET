using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADEV3000Windows
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }


        /// <summary>
        /// given - opens Syntax form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void syntaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSyntax instSyntax = new frmSyntax();
            instSyntax.MdiParent = this;
            instSyntax.Show();
        }

        /// <summary>
        /// given - opens LINQ form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lINQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLinq instLinq = new frmLinq();
            instLinq.MdiParent = this;
            instLinq.Show();
        }



        /// <summary>
        /// given - opens file i/o
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFileIO instFileIO = new frmFileIO();
            instFileIO.MdiParent = this;
            instFileIO.Show();
        }

        /// <summary>
        /// given - close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// given - uncomment when ready
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAbout instAbout = new frmAbout();
            //instAbout.ShowDialog();
        }

        /// <summary>
        /// given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webServicelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWCFService instWCFService = new frmWCFService();
            instWCFService.MdiParent = this;
            instWCFService.Show();
        }

        /// <summary>
        /// given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataSource instDataSource = new frmDataSource();
            instDataSource.MdiParent = this;
            instDataSource.Show();
        }
    }
}
