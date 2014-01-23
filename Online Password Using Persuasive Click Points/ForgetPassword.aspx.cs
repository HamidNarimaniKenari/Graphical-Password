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

public partial class ForgetPassword : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();


    bool GetLoginDetails(string UserName)
    {
        string qryLoginDetails = "select * " +
                                 "from UserDetails " +
                                 "where LoginName='" + UserName + "'";

        DataSet DSet = new DataSet();
        DB.GetData(qryLoginDetails, "UserDetails", DSet);
        if (DSet.Tables["UserDetails"].Rows.Count > 0)
        {
            if (DSet.Tables["UserDetails"].Rows[0]["LoginName"].ToString() == UserName)
            {
                hdnUserID.Value = DSet.Tables["UserDetails"].Rows[0]["UserID"].ToString();
                hdnMobileNo.Value = DSet.Tables["UserDetails"].Rows[0]["MobileNo"].ToString();
                return true;
                //UpdatePassword();
                //lblLoginMessage.Text = "Password updated successfully";
            }
            else
            {
                lblLoginMessage0.Text = "Invalid User Name (or) Password...!";
                return false;
            }
        }
        else
        {
            lblLoginMessage0.Text = "Invalid User Name...!";
            return false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {

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
        if (GetLoginDetails(txtUserName.Text) == false)
        {
            return;
        } 
        Panel2.Visible = false;
        Panel3.Visible = true;  
        try
        {
            Session["Port"] = objclsSMS.OpenPort("COM15", Convert.ToInt32("9600"), Convert.ToInt32("8"), Convert.ToInt32("300"), Convert.ToInt32("300"));

            if (Session["Port"] != null)
            {
                Panel2.Visible = false;
                Panel3.Visible = true;
                //txtMobileNo
                string strMsg = string.Concat("Verification Code :", hdnVerification.Value.ToString());
                if (objclsSMS.sendMsg((SerialPort)Session["Port"], this.hdnMobileNo.Value.ToString(), strMsg))
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
            lblLoginMessage1.ForeColor = System.Drawing.Color.Red;
            lblLoginMessage1.Text = "Failed to send message";

            //ErrorLog(ex.Message);
        }
        lblLoginMessage1.ForeColor = System.Drawing.Color.Green;
        lblLoginMessage1.Text = "Message has sent successfully";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (btnReset.Text == "Reset")
        {
            if (hdnVerification.Value.ToString() == txtVerificationCode.Text)
            {
                Session["CPID"] = hdnUserID.Value;
                Response.Redirect("ResetPassword.aspx");
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