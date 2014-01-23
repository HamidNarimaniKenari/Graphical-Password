using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_TryAgain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Chance"] == null)
        {
            Session["Chance"] = "1";
        }
        else
        {
            Session["Chance"] = (int.Parse(Session["Chance"].ToString()) + 1).ToString();

        }
    }
    protected void imgTryAgain_Click(object sender, ImageClickEventArgs e)
    {
        if (int.Parse(Session["Chance"].ToString()) <= 4)
        {
            Response.Redirect("~/Users/UserHome.aspx");
        }
        else
        {
            Session.Clear();
            Session.Abandon();//Abandon session
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Redirect("~/Users/InvalidPassword.aspx");

        }
    }
}