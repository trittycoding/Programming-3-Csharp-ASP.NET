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
    public partial class frmHistory : Form
    {
        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;
        BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        //Default Constructor
        public frmHistory()
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
        public frmHistory(ConstructorData constructorData)
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
        /// given:  open in top left of frame
        /// further code required:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistory_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            try
            {
                studentBindingSource.DataSource = constructorData.student;
                registrationBindingSource.DataSource = constructorData.registration;
                Student student = constructorData.student;
                Registration registration = constructorData.registration;
                int studentID = student.StudentId;
                int courseIDRegistration = registration.CourseId;
                var query = (from resultsR in db.Registrations
                             join resultsC in db.Courses
                             on resultsR.CourseId equals resultsC.CourseId
                             where resultsR.StudentId == studentID
                             select new
                             {
                                 RegistrationNumber = resultsR.RegistrationNumber,
                                 RegistrationDate = resultsR.RegistrationDate,
                                 Course = resultsC.Title,
                                 Grade = resultsR.Grade,
                                 Notes = resultsR.Notes
                             }).ToList();
                this.registrationDataGridView.DataSource = query;
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

    }
}
