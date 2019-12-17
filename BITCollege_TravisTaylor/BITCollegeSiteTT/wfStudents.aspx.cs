using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_TravisTaylor.Models;

namespace BITCollegeSiteTT
{
    public partial class wfStudents : System.Web.UI.Page
    {
        BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        /// <summary>
        /// Handles the page load event of wfStudents. The data grid view is populated with the user's info if the user is logged in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //If it's an initial page load
            if (!IsPostBack)
            {
                //Proceed if user is logged in
                if (this.Page.User.Identity.IsAuthenticated)
                {

                    try
                    {
                        string userLogin = Page.User.Identity.Name;
                        int atSymbol = userLogin.IndexOf('@');
                        string studentID = userLogin.Substring(0, atSymbol);
                        long parsedStudentNum = long.Parse(studentID);
                        Student query = (from results
                                            in db.Students
                                         where results.StudentNumber == parsedStudentNum
                                         select results).SingleOrDefault();
                        Student selectedStudent = query;
                        Session["student"] = selectedStudent;
                        lblwfStudentsStudentName.Text = selectedStudent.FullName;

                        IQueryable<Registration> rquery = from results
                                                          in db.Registrations
                                                          where results.StudentId == selectedStudent.StudentId
                                                          select results;
                        Session["registrations"] = rquery;
                        dgvwfStudents.DataSource = rquery.ToList();
                        this.DataBind();
                        lblwfStudentsErrorMsg.Visible = false;
                    }
                    catch (Exception exception)
                    {
                        //Catch any exception and output to the error message label
                        lblwfStudentsErrorMsg.Text = exception.Message;
                        lblwfStudentsErrorMsg.Visible = true;
                    }
                }

                //Redirect user to login page
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
        }

        /// <summary>
        /// When the selected index of the data grid view is changed, a Session variable is populated with the course number of the selected row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dgvwfStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //The course number is stored in a session variable, as cell 1 is representing the course number
            Session["selectedCourseNumber"] = this.dgvwfStudents.Rows[this.dgvwfStudents.SelectedIndex].Cells[1].Text; 
            Response.Redirect("~/wfDrop.aspx");
        }

        /// <summary>
        /// Handles the event where the user clicks on the 'Click Here To Register For a Course' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbwfStudentsRegisterCourse_Click(object sender, EventArgs e)
        {
            Session["courseNumber"] = this.dgvwfStudents.Rows[1].Cells[1].Text;
            Response.Redirect("~/wfRegister.aspx");
        }
    }
}