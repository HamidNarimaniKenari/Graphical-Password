using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Ports;
using MY_SMS_Application;

public partial class Users_SendSMS : System.Web.UI.Page
{
    SerialPort port = new SerialPort();
    clsSMS objclsSMS = new clsSMS();
   // ShortMessageCollection objShortMessageCollection = new ShortMessageCollection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string MsgStatus = string.Empty;
        //if (btnSendSMS.Text == "Send SMS")
        //{
            try
            {
                Session["Port"] = objclsSMS.OpenPort("COM15", Convert.ToInt32("9600"), Convert.ToInt32("8"), Convert.ToInt32("300"), Convert.ToInt32("300"));

                if (Session["Port"] != null)
                {

                    string strMsg = string.Concat(TextBox2.Text);
                    if (objclsSMS.sendMsg((SerialPort)Session["Port"], this.TextBox1.Text, strMsg))
                    {
                        lblLVIMessage0.Text = "Message has sent successfully";
                    }
                    else
                    {
                        lblLVIMessage0.ForeColor = System.Drawing.Color.Red;
                        lblLVIMessage0.Text = "Failed to send message";
                    }
                }
                else
                {
                    lblLVIMessage0.ForeColor = System.Drawing.Color.Red;
                    lblLVIMessage0.Text = "Invalid port settings";
                }

                //(SerialPort)Session["Port"])
            }
            catch (Exception ex)
            {
                lblLVIMessage0.ForeColor = System.Drawing.Color.Red;
                lblLVIMessage0.Text = "Failed to send message";

                //ErrorLog(ex.Message);
            }
           
            //btnSendSMS.Text = "Ok";
        //}
        //else
        //{
        //    Response.Redirect("~/PolicePersonals/PolicePersonalHome.aspx");
        //}
    }
}