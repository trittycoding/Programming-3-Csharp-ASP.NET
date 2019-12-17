using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_TravisTaylor.Models;
using Utility;

namespace BITCollegeSiteTT
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        /// <summary>
        /// Handles the page loading event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pageload();
            }

            catch(Exception exception)
            {
                lblwfRegisterErrorMsg.Text = exception.Message;
            }
        }

        /// <summary>
        /// Handles the event when the user clicks the Register button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbwfRegisterRegisterButton_Click(object sender, EventArgs e)
        {
            string courseSelected = ddlwfRegisterCourses.Text;
            Course courseToRegister = (from results
                                      in db.Courses
                                       where results.Title == courseSelected
                                       select results).SingleOrDefault();
            Student user = (Student)Session["student"];
            int userID = user.StudentId;
            string notes = txtwfRegisterTextbox.Text;
            int courseID = (int)courseToRegister.CourseId;

            ServiceReference.CollegeRegistrationClient localWS = new ServiceReference.CollegeRegistrationClient();
            int returnCode = localWS.registerCourse(userID, courseID, notes);
            if(returnCode == 0)
            {
                Response.Redirect("~/wfStudents.aspx");
            }

            else
            {
                lblwfRegisterErrorMsg.Visible = true;
                lblwfRegisterErrorMsg.Text = registerError(returnCode);
            }
        }

        /// <summary>
        /// Handles the event where the user clicks the Return to Listing button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbwfRegisterReturnToListing_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/wfStudents.aspx");
        }

        /// <summary>
        /// Populates the name label on the page as well as the available courses the user.
        /// </summary>
        public void pageload()
        {
            if (!IsPostBack)
            {
                try
                {
                    //Assigning student name to label
                    Student selectedStudent = (Student)Session["student"];
                    lblwfRegisterName.Text = selectedStudent.FullName;
                    string courseNumber = (string)Session["courseNumber"];

                    //Grab a Course object according to it's course number provided by the session variable.
                    Course course = (from results
                                        in db.Courses
                                     where results.CourseNumber == courseNumber
                                     select results).SingleOrDefault();

                    /*If the course ID is not null, then grab the program ID associated with that course and populate
                    the dropdown list with available courses from that program*/
                    if (course != null)
                    {
                        int programID = (int)course.ProgramId;
                        IQueryable<string> listOfCourses = from results
                                                           in db.Courses
                                                           where results.ProgramId == programID
                                                           select results.Title;
                        ddlwfRegisterCourses.DataSource = listOfCourses.ToList();
                        this.DataBind();
                        lblwfRegisterErrorMsg.Visible = false;
                    }

                    //If course is null then populate the dropdown with courses from all programs
                    else
                    {
                        IQueryable<string> listOfCourses = from results
                                                           in db.Courses
                                                           select results.Title;
                        ddlwfRegisterCourses.DataSource = listOfCourses.ToList();
                        this.DataBind();
                        lblwfRegisterErrorMsg.Visible = false;
                        
                    }
                }

                catch (Exception exception)
                {

                    lblwfRegisterErrorMsg.Visible = true;
                    lblwfRegisterErrorMsg.Text = exception.Message;
                } 
            }
        }

        /// <summary>
        /// Returns a string message according to the error code received from the web service.
        /// </summary>
        /// <param name="errorcode"></param>
        /// <returns>String error Message</returns>
        public static string registerError(int errorcode)
        {
            if (errorcode == -100)
            {
                return "Student cannot register for a course in which there is already an ungraded registration.";
            }

            else if (errorcode == -200)
            {
                return "Student has exceeded maximum attempts on a mastery course.";
            }

            else if (errorcode == -300)
            {
                return "An error has occurred while updating the registration.";
            }

            else
            {
                return "Unknown error.";
            }
        }

    }
}