using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Section2WebApp
{
    public partial class wfNext : System.Web.UI.Page
    {
        Section2.Models.Section2Context db = 
            new Section2.Models.Section2Context();

        /// <summary>
        /// use session variable value to populate label
        /// with first name that corresponds to session variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            int author = int.Parse(Session["Author"].ToString());


            lblAuthor.Text = db.Authors
                .Where(x => x.AuthorId == author)
                .Select(x => x.FirstName).SingleOrDefault();


        }
    }
}