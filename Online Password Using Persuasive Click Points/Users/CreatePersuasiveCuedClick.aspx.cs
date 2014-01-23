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

public partial class Users_CreatePersuasiveCuedClick : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    void GetImages()
    {
        string QryStr = "select * from PersuasiveImages where ImageID=" + hdnImageID.Value.ToString() + " order by PersuasiveImgID";
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "PersuasiveImages", DSet);
        DataList1.DataSource = DSet;
        DataList1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            hdnUserID.Value = Session["UserID"].ToString();
        }
        else
        {
            Response.Redirect("~/UserLogin.aspx");
        }
        if (Request.QueryString["ImageID"] != null)
        {
            hdnImageID.Value = Request.QueryString["ImageID"].ToString();
            GetImages();
            lblPointNo.Text = (GetCount() + 1).ToString();
        }
        if (IsPostBack == false)
        {
            UserControl uc = (UserControl)this.Page.Master.FindControl("Menu2");
            uc.Visible = false;
        }
    }
    int GetCount()
    {
        string QryStr = "select * from UserPersuasivePassword where UserID=" + hdnUserID.Value.ToString();
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "UserPersuasivePassword", DSet);
        return DSet.Tables["UserPersuasivePassword"].Rows.Count;        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {           
            SaveImagePassword();
            if (lblPointNo.Text == Session["NoCP"].ToString())
            {
                btnSave.Text = "Ok";
                lblMessage.Text = "Password created successfylly...!";
            }
            else
            {
                Response.Redirect("~/Users/CreatePassword.aspx?PM=3");
            }
        }
        else if (btnSave.Text == "Ok")
        {
            Session.Clear();
            Session.Abandon();//Abandon session
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Redirect("~/UserLogin.aspx");
        }
    }
    void SaveImagePassword()
    {
        // UserPerPwdID, UserID, ImageID, PersuasiveImgID, , , , , , , , , ,
        string InsQry = "insert into UserPersuasivePassword(UserID, ImageID, PersuasiveImgID)" +
                                            " values(@UserID, @ImageID, @PersuasiveImgID) --set @UserID=";

        SqlCommand InsCmd = new SqlCommand(InsQry, DB.Connection);

        InsCmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = int.Parse(hdnUserID.Value.ToString());
        InsCmd.Parameters.Add(new SqlParameter("@ImageID", SqlDbType.SmallInt)).Value = int.Parse(hdnImageID.Value.ToString());
        InsCmd.Parameters.Add(new SqlParameter("@PersuasiveImgID", SqlDbType.SmallInt)).Value = int.Parse(hdnImagePartID.Value.ToString());
        
        DB.Connection.Open();
        InsCmd.ExecuteNonQuery();
        DB.Connection.Close();
    }   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton myImageButton = sender as LinkButton;
        if (myImageButton != null)
        {
            btnSave.Visible = true;
            Image1.Visible = true;
            hdnImagePartID.Value = myImageButton.CommandArgument;
            Image1.ImageUrl = "~/Users/GetImagePart.ashx?ImagePartID=" + hdnImagePartID.Value.ToString();
        }
    }
}
