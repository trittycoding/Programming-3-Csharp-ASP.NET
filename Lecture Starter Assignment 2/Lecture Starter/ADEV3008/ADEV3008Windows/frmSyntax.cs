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
    public partial class frmSyntax : Form
    {

        /// <summary>
        /// XML Comments required for all procedures
        /// </summary>
        public frmSyntax()
        {
            InitializeComponent();
        }

        /// <summary>
        /// module level variables
        /// </summary>
        int number;
        string name = ".NET";
        decimal one, two, three;


        /// <summary>
        ///  Sample code for If Statement and Case Statement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIfAndCase_Click(object sender, EventArgs e)
        {
            int result;

            if(int.TryParse(txtUser.Text,out result))
            {
                //true condition
                //evaluate value
                //switch statement
                switch (int.Parse(txtUser.Text))
                {
                    case 1:
                        MessageBox.Show("Value is 1");
                        break;
                    case 2:
                        MessageBox.Show("Value is 2");
                        break;
                    default:
                        MessageBox.Show("Value is NOT 1 NOR 2");
                        break;
                }

            }
            else
            {
                MessageBox.Show("Value is not numeric");
            }          
        }

        /// <summary>
        /// Loop syntax examples
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoops_Click(object sender, EventArgs e)
        {
            //for loop
            for (int i = 0; i < 5; i++)
            {
                rtxtLoopResults.Text += "For Loop " + i + "\r\n";
            }


            //foreach loop
            foreach (Control ctrl in this.Controls)
            {
                rtxtLoopResults.Text += "ForEach Loop " + ctrl.Name + "\r\n";
            }


            //while loop
            int whileCounter = 10;
            while (whileCounter < 15)
            {
                whileCounter += 1;
                rtxtLoopResults.Text += "While Loop " + whileCounter + "\r\n";
            }

            //do-while loop
            int doCounter = 20;
            do
            {
                doCounter += 1;
                rtxtLoopResults.Text += "Do While Loop " + doCounter + "\r\n";
            } while (doCounter < 15);



        }


        /// <summary>
        /// Exception handling example
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnException_Click(object sender, EventArgs e)
        {
            int divide = 5;
            double result, quotient;
            try
            {
                //example of developer-thrown exception
                if(double.TryParse(txtUser.Text,out result))
                {
                    throw new Exception("Data must be numeric");
                }

                //if user entered data is 0, example of system thrown exception
                quotient = result / int.Parse(txtUser.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBindings_Click(object sender, EventArgs e)
        {
            //SYNTAX:
            //NOTE:  Most data binding will be handled automatically
            //by the LINQ-to-SQL Server provider

            //labels and textboxes
            //lblBind.DataBindings.Add("Text",Data Source, Field Name);

            //comboboxes and listboxes
            //cboData.DataSource = Data Source;
            //cboData.DisplayMember = Field Name;
            //cboData.ValueMember = FieldName;

            //DataGrids
            //dgData.DataSource = Data Source;

        }

        /// <summary>
        /// messagebox syntax
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessagebox_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Evaluating Dialog Result", "Dialog Result", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            switch (result)
            {
                case DialogResult.Abort:
                    MessageBox.Show("Abort");
                    break;
                case DialogResult.Retry:
                    MessageBox.Show("Retry");
                    break;
                case DialogResult.Ignore:
                    MessageBox.Show("Ignore");
                    break;
                default:
                    MessageBox.Show("Unknown Selection");
                    break;
            }
        }
    }
}
