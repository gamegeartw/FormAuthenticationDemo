using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormAuthenticationDemo
{
    using System.Web.Security;

    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}