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

public partial class AdministratorLogin : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    void GetLoginDetails()
    {
        string qryLoginDetails = "select * " +
                                 "from Logins " +
                                 "where  LoginName='" + txtUserName.Text + "' and Password='" + txtLoginPassword.Text + "'";

        DataSet DSet = new DataSet();
        DB.GetData(qryLoginDetails, "Logins", DSet);
        if (DSet.Tables["Logins"].Rows.Count > 0)
        {
            if (DSet.Tables["Logins"].Rows[0]["LoginName"].ToString() == txtUserName.Text && DSet.Tables["Logins"].Rows[0]["Password"].ToString() == txtLoginPassword.Text)
            {
                Session["LoginID"] = int.Parse(DSet.Tables["Logins"].Rows[0]["LoginID"].ToString());
                Response.Redirect("~/Administrator/AdministratorHome.aspx");
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
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        GetLoginDetails();
    }
}
