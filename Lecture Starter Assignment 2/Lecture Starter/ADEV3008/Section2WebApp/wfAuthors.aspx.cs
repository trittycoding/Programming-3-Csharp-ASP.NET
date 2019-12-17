using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Section2WebApp
{
    public partial class wfAuthors : System.Web.UI.Page
    {
        //instance of datacontext object
        Section2.Models.Section2Context db = 
            new Section2.Models.Section2Context();

        /// <summary>
        /// on page load populate gridview control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //only run on initial page load
            if (!IsPostBack)
            {
                //only proceed if user has logged in
                if (this.Page.User.Identity.IsAuthenticated)
                {
                    //grab the user id and display it
                    lblUserId.Text = Page.User.Identity.Name;


                    IQueryable<Section2.Models.Author> query = db.Authors;
                    //IQueryable<Section2.Models.Author> tradQuery =
                    //    from results in db.Authors
                    //    select results;

                    //need tolist for gridviews otherwise runtime error
                    gvAuthor.DataSource = query.ToList();

                    //need this line otherwise no data
                    this.DataBind();
                }
                else
                {
                    //if not logged in redirect to login page
                    Response.Redirect("~/Account/Login.aspx");
                }
            }


        }

        /// <summary>
        /// populate session variable and redirect to next page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNext_Click(object sender, EventArgs e)
        {
            Session["Author"] = txtAuthor.Text;

            Response.Redirect("wfNext.aspx");

        }

        /// <summary>
        /// place value from gridview into textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAuthor.Text = gvAuthor.
                Rows[gvAuthor.SelectedIndex].Cells[1].Text;


        }
    }
}