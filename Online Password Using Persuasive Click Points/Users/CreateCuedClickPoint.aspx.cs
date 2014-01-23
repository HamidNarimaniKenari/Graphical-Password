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

public partial class Users_CuedClickPoint : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    void GetPasswordModeID()
    {
        string QryStr = "select * from ImageUploads where ImageID=" + hdnImageID.Value.ToString();
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "ImageUploads", DSet);
        if (DSet.Tables["ImageUploads"].Rows.Count > 0)
        {
            hdnPasswordModeID.Value = DSet.Tables["ImageUploads"].Rows[0]["PasswordModeID"].ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //UserControl uc1 = (UserControl)this.Page.Master.FindControl("Menu2");
        //uc1.Visible = false;
        Session.LCID = 2057;
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/UserLogin.aspx");
        }
        else
        {
            hdnUserID.Value = Session["UserID"].ToString();
        }
        if (Request.QueryString["ImageID"] != null)
        {
            hdnImageID.Value = Request.QueryString["ImageID"].ToString();
            imgPicture.ImageUrl = "GetImages.ashx?ImageID=" + hdnImageID.Value.ToString();
            GetPasswordModeID();
            GetNoCreatedPwd();
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        //Session.Abandon();//Abandon session
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();//Abandon session
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        Response.Redirect("~/UserLogin.aspx");
    }
    int GetNoCreatedPwd()
    {
        string QryStr = "select * from UserImagePassword where UserID=" + hdnUserID.Value.ToString();
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "UserImagePassword", DSet);
        //txtNoCreatedPwd.Text = .ToString();
        return DSet.Tables["UserImagePassword"].Rows.Count;
        //if (int.Parse(txtNoCreatedPwd.Text) == 5)
        //{
        //    btnSave.Text = "Ok";
        //    lblMessage.Text = "Password created successfylly...!";
        //}
    }
    void SaveImagePassword()
    {
        // UserImgPwdID, UserID, PasswordModeID, ImageID, X_Axis, Y_Axis, Width, Height, , , , , , , , , ,
        string InsQry = "insert into UserImagePassword(UserID, PasswordModeID, ImageID, X_Axis, Y_Axis, Width, Height)" +
                                            " values(@UserID, @PasswordModeID, @ImageID, @X_Axis, @Y_Axis, @Width, @Height) --set @UserID=";

        SqlCommand InsCmd = new SqlCommand(InsQry, DB.Connection);

        InsCmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = int.Parse(hdnUserID.Value.ToString());
        InsCmd.Parameters.Add(new SqlParameter("@PasswordModeID", SqlDbType.SmallInt)).Value = int.Parse(hdnPasswordModeID.Value.ToString());
        InsCmd.Parameters.Add(new SqlParameter("@ImageID", SqlDbType.SmallInt)).Value = int.Parse(hdnImageID.Value.ToString());
        InsCmd.Parameters.Add(new SqlParameter("@X_Axis", SqlDbType.SmallInt)).Value = int.Parse(tX.Text);
        InsCmd.Parameters.Add(new SqlParameter("@Y_Axis", SqlDbType.SmallInt)).Value = int.Parse(tY.Text);
        InsCmd.Parameters.Add(new SqlParameter("@Width", SqlDbType.SmallInt)).Value = int.Parse(tW.Text);
        InsCmd.Parameters.Add(new SqlParameter("@Height", SqlDbType.SmallInt)).Value = int.Parse(tH.Text);

        DB.Connection.Open();
        InsCmd.ExecuteNonQuery();
        DB.Connection.Close();
    }
    void Clearing()
    {
        tH.Text = ""; tW.Text = ""; tX.Text = ""; tY.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            if (tH.Text == "" || tW.Text == "" || tX.Text == "" || tY.Text == "")
            {
                return;
            }
            SaveImagePassword();
            Clearing();
            btnSave.Text = "Ok";
        }
        else if (btnSave.Text == "Ok")
        {
            if (GetNoCreatedPwd() < int.Parse(Session["NoCP"].ToString()))
            {
                Response.Redirect("~/Users/CreatePassword.aspx?PM=2");
            }
            else
            {
                Session.Clear();
                Session.Abandon();//Abandon session
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Response.Redirect("~/UserLogin.aspx");
            }

        }

    }
}
