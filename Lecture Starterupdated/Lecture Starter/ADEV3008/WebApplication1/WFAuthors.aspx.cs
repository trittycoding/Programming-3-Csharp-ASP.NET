using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WFAuthors : System.Web.UI.Page
    {
        Section2.Models.Section2Context db = new Section2.Models.Section2Context();
        protected void Page_Load(object sender, EventArgs e)
        {
#if (!IsPostBack)
            IQueryable<Section2.Models.Author> query = db.Authors;
            //need to list for gridviews otherwise it will error out
            //gvAuthor.DataSource = query.ToList();

            //binds all data to controls on page
            //this.DataBind();  
#endif
        }
    }
}