using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using MY_SMS_Application;


public partial class Users_PasswordReset : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();

    void GetLoginName()
    {
        string qryLoginDetails = "select * " +
                                 "from UserDetails " +
                                 "where  UserID=" + hdnUserID.Value.ToString();

        DataSet DSet = new DataSet();
        DB.GetData(qryLoginDetails, "UserDetails", DSet);
        if (DSet.Tables["UserDetails"].Rows.Count > 0)
        {
            txtUserName.Text = DSet.Tables["UserDetails"].Rows[0]["LoginName"].ToString();
            txtUserName0.Text = DSet.Tables["UserDetails"].Rows[0]["LoginName"].ToString();
            txtMobileNo.Text = DSet.Tables["UserDetails"].Rows[0]["MobileNo"].ToString();
        }
    }
    bool GetLoginDetails(string UserName, string Password)
    {
        string qryLoginDetails = "select * " +
                                 "from UserDetails " +
                                 "where LoginName='" + UserName + "' and Password='" + Password + "'";

        DataSet DSet = new DataSet();
        DB.GetData(qryLoginDetails, "UserDetails", DSet);
        if (DSet.Tables["UserDetails"].Rows.Count > 0)
        {
            if (DSet.Tables["UserDetails"].Rows[0]["LoginName"].ToString() == UserName && DSet.Tables["UserDetails"].Rows[0]["Password"].ToString() == Password)
            {
                return true;
                //UpdatePassword();
                //lblLoginMessage.Text = "Password updated successfully";
            }
            else
            {
                lblLoginMessage.Text = "Invalid User Name (or) Password...!";
                lblLoginMessage0.Text = "Invalid User Name (or) Password...!";
                return false;
            }

        }
        else
        {
            lblLoginMessage.Text = "Invalid User Name (or) Password...!";
            lblLoginMessage0.Text = "Invalid User Name (or) Password...!";
            return false;
        }
    }
    void UpdatePassword()
    {
        // UserImgPwdID, UserID, PasswordModeID, ImageID, X_Axis, Y_Axis, Width, Height, , , , , , , , , ,
        string InsQry = "Update UserDetails set Password=@Password where UserID=@UserID";

        SqlCommand InsCmd = new SqlCommand(InsQry, DB.Connection);

        InsCmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = int.Parse(hdnUserID.Value.ToString());
        InsCmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50)).Value = txtNewPassword.Text;


        DB.Connection.Open();
        InsCmd.ExecuteNonQuery();
        DB.Connection.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            hdnUserID.Value = Session["UserID"].ToString();
        }
        if (IsPostBack == false)
        {
            GetLoginName();
        }
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        if (btnChangePassword.Text == "Change Password")
        {
            if (GetLoginDetails(txtUserName.Text, txtCurrentPassword.Text) == true)
            {
                UpdatePassword();
                lblLoginMessage.Text = "Password changed successfully";
                btnChangePassword.Text = "Ok";
                btnChangePassword.CausesValidation = false;
            }
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
    protected void rblOptions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblOptions.SelectedIndex == 0)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        else if (rblOptions.SelectedIndex == 1)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
    }
    SerialPort port = new SerialPort();
    clsSMS objclsSMS = new clsSMS();
    protected void btnSendCode_Click(object sender, EventArgs e)
    {
        Random rnd = new Random();
        hdnVerification.Value = rnd.Next(1000, 10000).ToString();
        string MsgStatus = string.Empty;
        //if (btnSendSMS.Text == "Send SMS")
        //{
        if (GetLoginDetails(txtUserName0.Text, txtCurrentPassword0.Text) == false)
        {
            return;
        }
        try
        {

            Session["Port"] = objclsSMS.OpenPort("COM15", Convert.ToInt32("9600"), Convert.ToInt32("8"), Convert.ToInt32("300"), Convert.ToInt32("300"));

            if (Session["Port"] != null)
            {

                string strMsg = string.Concat("Verification Code :", hdnVerification.Value.ToString());
                if (objclsSMS.sendMsg((SerialPort)Session["Port"], this.txtMobileNo.Text, strMsg))
                {
                    lblLoginMessage0.Text = "Message has sent successfully";
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                }
                else
                {
                    lblLoginMessage0.ForeColor = System.Drawing.Color.Red;
                    lblLoginMessage0.Text = "Failed to send message";
                }
            }
            else
            {
                lblLoginMessage0.ForeColor = System.Drawing.Color.Red;
                lblLoginMessage0.Text = "Invalid port settings";
            }
            //(SerialPort)Session["Port"])
        }
        catch (Exception ex)
        {
            lblLoginMessage0.ForeColor = System.Drawing.Color.Red;
            lblLoginMessage0.Text = "Failed to send message";

            //ErrorLog(ex.Message);
        }
    }

    void PasswordReset()
    {
        string InsQry = "Delete from UserImagePassword where UserID=@UserID1 "+
                        "Delete from UserPersuasivePassword where UserID=@UserID2";

        SqlCommand InsCmd = new SqlCommand(InsQry, DB.Connection);

        InsCmd.Parameters.Add(new SqlParameter("@UserID1", SqlDbType.SmallInt)).Value = int.Parse(hdnUserID.Value.ToString());
        InsCmd.Parameters.Add(new SqlParameter("@UserID2", SqlDbType.SmallInt)).Value = int.Parse(hdnUserID.Value.ToString());
      
        DB.Connection.Open();
        InsCmd.ExecuteNonQuery();
        DB.Connection.Close();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (btnReset.Text == "Reset")
        {
            if (hdnVerification.Value.ToString() == txtVerificationCode.Text)
            {
                PasswordReset();
                lblLoginMessage1.Text = "Password reset successfully";
                btnReset.Text = "Ok";
            }
            else
            {
                txtVerificationCode.Text = "";
                lblLoginMessage1.Text = "Invalid verification code";
            }
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