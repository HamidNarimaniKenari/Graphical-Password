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

public partial class Users_CheckPassPoint : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    int[] X_pos = new int[5];
    int[] Y_pos = new int[5];
    int[] Width = new int[5];
    int[] Height = new int[5];
    bool result;

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

        if (IsPostBack == false)
        {
            if (Request.QueryString["ImageID"] != null)
            {
                hdnImageID.Value = Request.QueryString["ImageID"].ToString();
                ibtnPasswordImage.ImageUrl = "GetImages.ashx?ImageID=" + hdnImageID.Value.ToString();
            }
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
    protected void ibtnPasswordImage_Click(object sender, ImageClickEventArgs e)
    {
        //tX0.Text = tX.Text;
        //tY0.Text = tY.Text;
        txtCount.Text = (int.Parse(txtCount.Text) + 1).ToString();
        //if (txtCount.Text == "1")
        //{
        //    lstX.Items.Add(tX.Text);
        //    lstY.Items.Add(tY.Text);
        //}
        //else if (txtCount.Text == "2")
        //{
        //    lstX.Items.Add(tX.Text);
        //    lstY.Items.Add(tY.Text);
        //}
        //else if (txtCount.Text == "3")
        //{
        //    lstX.Items.Add(tX.Text);
        //    lstY.Items.Add(tY.Text);
        //}
        //else if (txtCount.Text == "4")
        //{
        //    lstX.Items.Add(tX.Text);
        //    lstY.Items.Add(tY.Text);
        //}
        //else 
        string QryStr = "select * from UserImagePassword where UserID=" + hdnUserID.Value.ToString() + " order by UserImgPwdID";
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "UserImagePassword", DSet);

        if (txtCount.Text == DSet.Tables[0].Rows.Count.ToString())
        {
            lstX.Items.Add(tX.Text);
            lstY.Items.Add(tY.Text);
            //GetXandY();

            CheckPassword();
            if (result == true)
            {
                Response.Redirect("~/Users/HomePage.aspx");

            }
            else
            {
               
                Response.Redirect("~/Users/TryAgain.aspx");
            }
        }
        else
        {
            lstX.Items.Add(tX.Text);
            lstY.Items.Add(tY.Text);
        }
    }
    void GetXandY()
    {
        for (int i = 0; i < 5; i++)
        {
            //lblX.Text += lstX.Items[i].Text + "<br>";
            //lblY.Text += lstY.Items[i].Text + "<br>";
        }
    }
    void CheckPassword()
    {
        string QryStr = "select * from UserImagePassword where UserID=" + hdnUserID.Value.ToString() + " order by UserImgPwdID";
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "UserImagePassword", DSet);
        for (int i = 0; i < DSet.Tables[0].Rows.Count; i++)
        {
            X_pos[i] = int.Parse(DSet.Tables[0].Rows[i]["X_Axis"].ToString());
            Y_pos[i] = int.Parse(DSet.Tables[0].Rows[i]["Y_Axis"].ToString());
            Width[i] = int.Parse(DSet.Tables[0].Rows[i]["Width"].ToString());
            Height[i] = int.Parse(DSet.Tables[0].Rows[i]["Height"].ToString());
        }
        for (int i = 0; i < DSet.Tables[0].Rows.Count; i++)
        {
            if ((int.Parse(lstX.Items[i].Text) >= X_pos[i] &&
                 int.Parse(lstX.Items[i].Text) <= X_pos[i] + Width[i]) &&
                (int.Parse(lstY.Items[i].Text) >= Y_pos[i] &&
                 int.Parse(lstY.Items[i].Text) <= Y_pos[i] + Height[i]))
            {
                result = true;
            }
            else
            {
                result = false;
                return;
            }

        }
    }

}
