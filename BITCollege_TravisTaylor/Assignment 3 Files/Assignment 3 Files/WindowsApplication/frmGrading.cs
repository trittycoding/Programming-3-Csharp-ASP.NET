using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BITCollege_TravisTaylor.Models;
using Utility;


namespace WindowsApplication
{
    public partial class frmGrading : Form
    {
        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;

        //Default constructor
        public frmGrading()
        {
            InitializeComponent();
            
        }


        /// <summary>
        /// given:  This constructor will be used when called from 
        /// frmStudent.  This constructor will receive 
        /// specific information about the student and registration
        /// further code required:  
        /// </summary>
        /// <param name="student">specific student instance</param>
        /// <param name="registration">specific registration instance</param>
        public frmGrading(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;
        }

        /// <summary>
        /// given: this code will navigate back to frmStudent with
        /// the specific student and registration data that launched
        /// this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //return to student with the data selected for this form
            frmStudent frmStudent = new frmStudent(constructorData);
            frmStudent.MdiParent = this.MdiParent;
            frmStudent.Show();
            this.Close();
        }

        /// <summary>
        /// given:  open in top right of frame
        /// further code required:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGrading_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            try
            {
                studentBindingSource.DataSource = constructorData.student;
                registrationBindingSource.DataSource = constructorData.registration;
                
                Student student = constructorData.student;
                Registration registration = constructorData.registration;
                double? registrationGrade = registration.Grade;
                if (registrationGrade == null)
                {
                    lnkUpdate.Enabled = true;
                    lblExisting.Visible = false;
                    gradeTextBox.Enabled = true;
                }
                else
                {
                    lnkUpdate.Enabled = false;
                    lblExisting.Visible = true;
                    gradeTextBox.Enabled = false;
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Handles the event when the link button for "Update Grade" is clicked.
        /// Parses the input and updates the grade for the given registration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string formatClearedValue = Numeric.ClearFormatting(gradeTextBox.Text, "%");
            if(Numeric.isNumeric(formatClearedValue, System.Globalization.NumberStyles.Float))
            {
                double gradeParsed = double.Parse(formatClearedValue);
                gradeParsed = gradeParsed / 100;
                if(gradeParsed >= 0 && gradeParsed <= 1)
                {
                    Registration idToBeUpdated = constructorData.registration;
                    int registrationID = idToBeUpdated.RegistrationId;
                    string notes = idToBeUpdated.Notes;
                    ServiceReference.CollegeRegistrationClient localWS = new ServiceReference.CollegeRegistrationClient();
                    localWS.updateGrade(gradeParsed, registrationID, notes);
                    frmStudent frmStudent = new frmStudent(constructorData);
                    frmStudent.MdiParent = this.MdiParent;
                    frmStudent.Show();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Grade value is out of range, please enter a value between 0 to 1.");
                }
            }
            else
            {
                MessageBox.Show("Please enter grade in decimal format between 0 and 1. Update failed.");
            }
        }


    }
}
