using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
using WindowsApplication;
using BITCollege_TravisTaylor.Models;

namespace WindowsApplication
{
    /// <summary>
    /// Code behind batch form class
    /// </summary>
    public partial class frmBatch : Form
    {
        Batch batch = new Batch();
        BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        /// <summary>
        /// Constructs an instance of batch.
        /// </summary>
        public frmBatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the event when the process batch link label is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtKey.Text.Length != 8)
            {
                MessageBox.Show("A 64-bit Key must be entered", "Error");
            }
            else
            {
                if (radAll.Checked)
                {
                    //Looping through each possible program acronym
                    int x = comboBox1.Items.Count;
                    for(int i = 0; i < x; i++)
                    {
                        comboBox1.SelectedIndex = i;
                        batch.processTransmission(comboBox1.Items[i].ToString(), txtKey.Text);
                        richTextBox1.Text += batch.writeLogData();
                    }
                }
                else
                {
                    batch.processTransmission(comboBox1.Text.ToString(), txtKey.Text);
                    richTextBox1.Text += batch.writeLogData();
                }
            }
        }

        /// <summary>
        /// Handles the event when the batch form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBatch_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            programBindingSource.DataSource = db.Programs.ToList();
        }

        /// <summary>
        /// Handles the event when the all programs radio button is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked)
            {
                comboBox1.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the event when the encrypt button is clicked, encrypts test files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            //Test programs: VT, PMM, PBP
            Utility.Encryption.encrypt("2019-331-PMM.xml", "2019-331-PMM.xml.encrypted", txtKey.Text);
            Utility.Encryption.encrypt("2019-331-PBP.xml", "2019-331-PBP.xml.encrypted", txtKey.Text);
            Utility.Encryption.encrypt("2019-331-VT.xml", "2019-331-VT.xml.encrypted", txtKey.Text);
        }

    }
}
