using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UserLogin : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    void GetLoginDetails()
    {
        string qryLoginDetails = "select * " +
                                 "from UserDetails " +
                                 "where  LoginName='" + txtUserName.Text + "' and Password='" + txtLoginPassword.Text + "'";

        DataSet DSet = new DataSet();
        DB.GetData(qryLoginDetails, "UserDetails", DSet);
        if (DSet.Tables["UserDetails"].Rows.Count > 0)
        {
            if (DSet.Tables["UserDetails"].Rows[0]["LoginName"].ToString() == txtUserName.Text && DSet.Tables["UserDetails"].Rows[0]["Password"].ToString() == txtLoginPassword.Text)
            {
                Session["UserID"] = int.Parse(DSet.Tables["UserDetails"].Rows[0]["UserID"].ToString());
                Response.Redirect("~/Users/UserHome.aspx");
            }
            else
            {
                lblLoginMessage.Text = "Invalid User Name (or) Password...!";
            }

        }
        else
        {
            lblLoginMessage.Text = "Invalid User Name (or) Password...!";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        GetLoginDetails();
    }
}
