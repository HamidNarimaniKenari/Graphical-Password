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

public partial class Users_UserHome : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    void CheckPasswordCreated()
    {

        string QryStr = "select * from UserImagePassword where UserID=" + hdnUserID.Value.ToString();
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "UserImagePassword", DSet);

        if (DSet.Tables["UserImagePassword"].Rows.Count == 0)
        {
            //Response.Redirect("~/Users/CreatePassword.aspx");
        }
        else if (DSet.Tables["UserImagePassword"].Rows.Count > 0 && DSet.Tables["UserImagePassword"].Rows.Count < 2 &&
            DSet.Tables["UserImagePassword"].Rows[0]["PasswordModeID"].ToString() == "1")
        {
            Response.Redirect("~/Users/CreatePassPoint.aspx?ImageID=" + DSet.Tables["UserImagePassword"].Rows[0]["ImageID"].ToString());            
        }
        else if (DSet.Tables["UserImagePassword"].Rows.Count > 0 && DSet.Tables["UserImagePassword"].Rows.Count < 2 &&
            DSet.Tables["UserImagePassword"].Rows[0]["PasswordModeID"].ToString() == "2")
        {
            Response.Redirect("~/Users/CreatePassword.aspx?PM=2");
        }
        else if (DSet.Tables["UserImagePassword"].Rows[0]["PasswordModeID"].ToString() == "1" &&
            DSet.Tables["UserImagePassword"].Rows.Count >= 2)
        {
            Response.Redirect("~/Users/CheckPassPoint.aspx?ImageID=" + DSet.Tables["UserImagePassword"].Rows[0]["ImageID"].ToString());
        }
        else if (DSet.Tables["UserImagePassword"].Rows[0]["PasswordModeID"].ToString() == "2" &&
            DSet.Tables["UserImagePassword"].Rows.Count >= 2)
        {
            Response.Redirect("~/Users/CheckCuedClickPoint.aspx?ImageID=" + DSet.Tables["UserImagePassword"].Rows[0]["ImageID"].ToString());
        }

    }

    void CheckPersuasivePasswordCreated()
    {
        string QryStr = "select * from UserPersuasivePassword where UserID=" + hdnUserID.Value.ToString();
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "UserPersuasivePassword", DSet);
        if (DSet.Tables["UserPersuasivePassword"].Rows.Count == 0 || DSet.Tables["UserPersuasivePassword"].Rows.Count < 2)
        {
            Response.Redirect("~/Users/CreatePassword.aspx");
        }
        else if (DSet.Tables["UserPersuasivePassword"].Rows.Count >= 2)
        {
            Response.Redirect("~/Users/CheckPersuasiveCuedClick.aspx");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.LCID = 2057;

        if (Session["UserID"] == null)
        {
            Response.Redirect("~/UserLogin.aspx");

        }
        else
        {
            hdnUserID.Value = Session["UserID"].ToString();
            CheckPasswordCreated();
            CheckPersuasivePasswordCreated();
        }
    }
}
