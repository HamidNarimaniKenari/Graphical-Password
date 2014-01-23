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
using System.Data.SqlClient;
public partial class Users_CreatePassword : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    MastersList ML = new MastersList();
    void GetImages()
    {
        string QryStr = "select * from ImageUploads where PasswordModeID=" + ddlPasswordMode.SelectedValue +
                        " and ImageID not in(select ImageID from UserImagePassword  where UserID=" + hdnUserID.Value.ToString() + ")";
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "ImageUploads", DSet);
        DataList1.DataSource = DSet;
        DataList1.DataBind();
    }
    void GetPersuaciveImages()
    {
        string QryStr = "select * from ImageUploads where PasswordModeID=" + ddlPasswordMode.SelectedValue +
                        " and ImageID not in(select ImageID from UserPersuasivePassword where UserID=" + hdnUserID.Value.ToString() + ")";
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "ImageUploads", DSet);
        DataList1.DataSource = DSet;
        DataList1.DataBind();
    }
    void NoPoints()
    {
        for (int i = 2; i <= 10; i++)
        {
            ddlNoPoints.Items.Add(i.ToString());
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        UserControl uc1 = (UserControl)this.Page.Master.FindControl("Menu2");
        uc1.Visible = false;
        if (Session["UserID"] != null)
        {
            hdnUserID.Value = Session["UserID"].ToString();
        }
        else
        {
            Response.Redirect("~/UserLogin.aspx");
        }

        if (IsPostBack == false)
        {
            ML.PasswordMode(ddlPasswordMode);
            NoPoints();
            //Response.Redirect("~/Users/CreatePersuasiveCuedClick.aspx?ImageID=8");
        }
        if (Request.QueryString["PM"] != null)
        {
            ddlPasswordMode.SelectedValue = Request.QueryString["PM"].ToString();
            ddlPasswordMode.Enabled = false;
            if (Session["NoCP"] != null)
            {
                ddlNoPoints.Enabled = false;
                ddlNoPoints.SelectedValue = Session["NoCP"].ToString();
            }
            if (ddlPasswordMode.SelectedValue == "2")
            {
                GetImages();
            }
            else if (ddlPasswordMode.SelectedValue == "3")
            {
                GetPersuaciveImages();
            }
        }
    }
    protected void ddlPasswordMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPasswordMode.SelectedValue == "1" || ddlPasswordMode.SelectedValue == "2")
        {
            GetImages();
        }
        else if (ddlPasswordMode.SelectedValue == "3")
        {
            GetPersuaciveImages();
        }
    }
    protected void lnkImage_Click(object sender, EventArgs e)
    {
        LinkButton myImageButton = sender as LinkButton;
        if (myImageButton != null)
        {
            int id = int.Parse(myImageButton.CommandArgument);

            Session["NoCP"] = ddlNoPoints.SelectedValue;

            if (ddlPasswordMode.SelectedValue == "1")
            {
                UpdatePasswordMode();
                Session["NoCP"] = ddlNoPoints.SelectedValue;
                Response.Redirect("~/Users/CreatePassPoint.aspx?ImageID=" + id.ToString());
            }
            else if (ddlPasswordMode.SelectedValue == "2")
            {
                UpdatePasswordMode();
                Response.Redirect("~/Users/CreateCuedClickPoint.aspx?ImageID=" + id.ToString());
            }
            else if (ddlPasswordMode.SelectedValue == "3")
            {
                UpdatePasswordMode();
                Response.Redirect("~/Users/CreatePersuasiveCuedClick.aspx?ImageID=" + id.ToString());
            }

            //Image1.ImageUrl = "~/Users/GetImagePart.ashx?ImagePartID=" + hdnImagePartID.Value.ToString();
        }
    }
    void UpdatePasswordMode()
    {
        //UserID, FirstName, LastName, EMailID, LoginName, Password, 
        string UpdQry = "update UserDetails set PasswordModeID=@PasswordModeID where UserID=@UserID";

        SqlCommand UpdCmd = new SqlCommand(UpdQry, DB.Connection);

        UpdCmd.Parameters.Add(new SqlParameter("@PasswordModeID", SqlDbType.SmallInt)).Value = int.Parse(ddlPasswordMode.SelectedValue);
        UpdCmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = int.Parse(hdnUserID.Value.ToString());
        
        DB.Connection.Open();
        UpdCmd.ExecuteNonQuery();
        DB.Connection.Close();
    }
}