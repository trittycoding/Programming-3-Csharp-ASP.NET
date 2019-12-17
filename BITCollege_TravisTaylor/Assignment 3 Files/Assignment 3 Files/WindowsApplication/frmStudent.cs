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

namespace WindowsApplication
{
    public partial class frmStudent : Form
    {
        ///Given: Student and Registration data will be retrieved
        ///in this form and passed throughout application
        ///These variables will be used to store the current
        ///Student and selected Registration
        ConstructorData constructorData = new ConstructorData();

        /// <summary>
        /// Default constructor
        /// </summary>
        public frmStudent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when returning to frmStudent
        /// from another form.  This constructor will pass back
        /// specific information about the student and registration
        /// based on activites taking place in another form
        /// </summary>
        /// <param name="constructorData">Student data passed among forms</param>
        public frmStudent(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;
            this.studentNumberMaskedTextBox.Text = constructorData.student.StudentNumber.ToString();
            this.studentNumberMaskedTextBox_Leave(null, null);
        }

        /// <summary>
        /// given: open grading form passing constructor data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setConstructorData();
            //instance of frmTransaction passing constructor data
            frmGrading frmGrading = new frmGrading(constructorData);
            //open in frame
            frmGrading.MdiParent = this.MdiParent;
            //show form
            frmGrading.Show();
            this.Close();
        }

        /// <summary>
        /// given: open history form passing data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setConstructorData();
            //instance of frmHistory passing constructor data
            frmHistory frmHistory = new frmHistory(constructorData);
            //open in frame
            frmHistory.MdiParent = this.MdiParent;
            //show form
            frmHistory.Show();
            this.Close();
        }

        /// <summary>
        /// given:  opens form in top right of frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStudent_Load(object sender, EventArgs e)
        {
            //keeps location of form static when opened and closed
            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// Handles the event when the user leave the masked student number textbox. 
        /// Updates the form fields based on the student number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void studentNumberMaskedTextBox_Leave(object sender, EventArgs e)
        {
            BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

            try
            {
                if (studentNumberMaskedTextBox.MaskCompleted == true)
                {
                    string boxValue = studentNumberMaskedTextBox.Text;
                    long studentNumber = long.Parse(boxValue);

                    Student student = (from results
                                      in db.Students
                                       where results.StudentNumber == studentNumber
                                       select results).SingleOrDefault();
                    if (student != null)
                    {
                        studentBindingSource.DataSource = student;
                        registrationNumberComboBox.Enabled = true;
                        int studentID = student.StudentId;

                        IQueryable<Registration> registrations = from results
                                                                 in db.Registrations
                                                                 where results.StudentId == studentID
                                                                 select results;

                        if (registrations.Count() > 0)
                        {
                            lnkUpdate.Enabled = true;
                            lnkDetails.Enabled = true;
                            registrationBindingSource.DataSource = registrations.ToList();
                            
                            //If it is not null, then we are returning from another form
                            //Sets the drop down list that is generated to the current registration
                            if(constructorData.registration != null)
                            {
                                registrationNumberComboBox.Text = constructorData.registration.RegistrationNumber.ToString();
                            }
                        }
                        else
                        {
                            lnkUpdate.Enabled = false;
                            lnkDetails.Enabled = false;
                            registrationBindingSource.Clear();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Student Number does not exist");
                        registrationNumberComboBox.Enabled = false;
                        lnkDetails.Enabled = false;
                        lnkUpdate.Enabled = false;
                        studentBindingSource.Clear();
                        registrationBindingSource.Clear();
                        studentNumberMaskedTextBox.Focus();
                    }
                }
                registrationNumberComboBox.Focus();
            }

            catch (Exception exception)
            {
                studentBindingSource.Clear();
                registrationBindingSource.Clear();
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Populates the constructor data object with the selected student and registration object from the form.
        /// </summary>
        private void setConstructorData()
        {
            constructorData.registration = (Registration)registrationBindingSource.Current;
            constructorData.student = (Student)studentBindingSource.Current;
        }

    }
}
