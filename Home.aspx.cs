using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_Cinemate_FinalMP
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Movie1Button_Click(object sender, EventArgs e)
        {
            // Redirect to Home.aspx
            Response.Redirect("Movie1.aspx");
        }
        protected void Movie2Button_Click(object sender, EventArgs e)
        {
            // Redirect to Home.aspx
            Response.Redirect("Movie2.aspx");
        }
        protected void Movie3Button_Click(object sender, EventArgs e)
        {
            // Redirect to Home.aspx
            Response.Redirect("Movie3.aspx");
        }
    }
}