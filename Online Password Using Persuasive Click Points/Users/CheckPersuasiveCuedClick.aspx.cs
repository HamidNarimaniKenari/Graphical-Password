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

public partial class Users_PersuasiveCuedClick : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    void GetImages(string ImageID)
    {
        string QryStr = "select * from PersuasiveImages where ImageID=" + ImageID + " order by PersuasiveImgID";
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "PersuasiveImages", DSet);
        DataList1.DataSource = DSet;
        DataList1.DataBind();
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

        //if (Request.QueryString["ImageID"] != null)
        //{
        //    hdnUserID.Value = Request.QueryString["ImageID"].ToString();
        //}
        if (IsPostBack == false)
        {
            GetPersuasivePassword();
            GetImages(ListBox1.SelectedItem.Text);
        }
    }

    void GetPersuasivePassword()
    {
        string QryStr = "select * from UserPersuasivePassword where UserID=" + hdnUserID.Value.ToString() + " order by UserPerPwdID";
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "UserPersuasivePassword", DSet);
        ListBox1.DataSource = DSet;
        ListBox1.DataTextField = "ImageID";
        ListBox1.DataValueField = "PersuasiveImgID";
        ListBox1.DataBind();
        ListBox1.SelectedIndex = 0;
    }
    void GetCount()
    {
        string QryStr = "select * from UserPersuasivePassword where UserID=" + hdnUserID.Value.ToString();
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "UserPersuasivePassword", DSet);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton myImageButton = sender as LinkButton;
        if (myImageButton != null)
        {
            int index = 0;
            if (ListBox1.SelectedIndex < ListBox1.Items.Count-1)
            {
                index = ListBox1.SelectedIndex + 1;
            }
            else
            {
                index = ListBox1.SelectedIndex;
            }

            ListBox1.SelectedIndex = index;
            GetImages(ListBox1.SelectedItem.Text);
            ListBox2.Items.Add(myImageButton.CommandArgument);
            if (ListBox1.Items.Count == ListBox2.Items.Count)
            {
                lblPointNo.Text = "Password Checked";
                for (int i = 0; i < ListBox1.Items.Count; i++)
                {
                    if (ListBox1.Items[i].Value != ListBox2.Items[i].Value)
                    {
                        Response.Redirect("~/Users/TryAgain.aspx");
                    }
                }
                Response.Redirect("~/Users/HomePage.aspx");

            }

            //btnSave.Visible = true;
            //Image1.Visible = true;
            //hdnImagePartID.Value = myImageButton.CommandArgument;
            //Image1.ImageUrl = "~/Users/GetImagePart.ashx?ImagePartID=" + hdnImagePartID.Value.ToString();
        }
    }
}
