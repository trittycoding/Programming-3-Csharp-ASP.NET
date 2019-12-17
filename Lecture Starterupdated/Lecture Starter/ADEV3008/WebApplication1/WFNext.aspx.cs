using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WFNext : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Section2.Models.Section2Context db = new Section2.Models.Section2Context();
            int author = int.Parse(Session["Author"].ToString());
            //lblAuthor.Text = db.Authors.Where(X=>X.AuthorId == X.FirstName ).SingleorDefault();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //Session['Author'] = txtAuthor.Text;
            Response.Redirect("WFNext.aspx");
        }
    }
}