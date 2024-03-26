using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_Cinemate_FinalMP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            form2.Visible = false;
        }

        protected void signupButton_Click(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {

        }

        protected void SignButton_Click(object sender, EventArgs e)
        {
            form2.Visible = true;
            form1.Visible = false;
        }

        protected void LogButton_Click(object sender, EventArgs e)
        {
            form1.Visible = true;
            form2.Visible = false;
        }
    }
}