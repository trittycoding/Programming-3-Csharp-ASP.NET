using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_TravisTaylor.Models;


namespace BITCollegeSiteTT
{
    public partial class wfDrop : System.Web.UI.Page
    {
        BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        /// <summary>
        /// Handles the page loading event of the wfDrop view. The detail view is populated with the student's registrations based on course id.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.User.Identity.IsAuthenticated) {
                try
                {
                    pageLoad();
                }

                catch (Exception exception)
                {
                    lblwfDropErrorMsg.Text = exception.Message;
                }
            }
        }

        /// <summary>
        /// When the "Return to Registration Listings" link button is clicked, return to wfStudents view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbwfDropReturnRegistrationListing_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/wfStudents.aspx");
        }

        /// <summary>
        /// When the "Drop Course" link button is clicked, the registration is dropped from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbwfDropDropCourse_Click(object sender, EventArgs e)
        {
            ServiceReference.CollegeRegistrationClient localWS = new ServiceReference.CollegeRegistrationClient();
            localWS.dropCourse(int.Parse(this.dtvwfDrop.Rows[0].Cells[1].Text));
        }

        /// <summary>
        /// When the page index is changed, the page index is set to the new page index.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dtvwfDrop_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            dtvwfDrop.PageIndex = e.NewPageIndex;
            pageLoad();
        }

        /// <summary>
        /// Populates the details view with registration data.
        /// </summary>
        public void pageLoad()
        {
            //Using session variable to pass the student from wfStudents to wfDrop
            Student selectedStudent = (Student)Session["student"];
            String selectedCourseNumber = Session["selectedCourseNumber"].ToString();

            Course query = (from results
                           in db.Courses
                            where results.CourseNumber == selectedCourseNumber
                            select results).SingleOrDefault();

            IQueryable<Registration> rquery = from results
                                              in db.Registrations
                                              where results.StudentId == selectedStudent.StudentId
                                              where results.CourseId == query.CourseId
                                              select results;
            dtvwfDrop.AllowPaging = true;

            //Populate the details grid view with the student's registrations for that particular course.
            dtvwfDrop.DataSource = rquery.ToList();
            this.DataBind();
            lblwfDropErrorMsg.Visible = false;

            //If the item is not graded i.e. null, then enable the Drop Course button.
            if (this.dtvwfDrop.Rows[4].Cells[1].Text == "&nbsp;")
            {
                lbwfDropDropCourse.Enabled = true;
            }

            else
            {
                lbwfDropDropCourse.Enabled = false;
            }
        }
    }
}