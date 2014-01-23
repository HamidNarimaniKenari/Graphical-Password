using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ResetPassword : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CPID"] != null)
        {
            hdnUserID.Value = Session["CPID"].ToString();
        }
        else
        {
            Response.Redirect("~/UserLogin.aspx");
        }
    }
    void UpdatePassword()
    {
        // UserImgPwdID, UserID, PasswordModeID, ImageID, X_Axis, Y_Axis, Width, Height, , , , , , , , , ,
        string UpdQry = "Update UserDetails set Password=@Password where UserID=@UserID " +
                        "Delete from UserImagePassword where UserID=@UserID1 " +
                        "Delete from UserPersuasivePassword where UserID=@UserID2 ";
        SqlCommand UpdCmd = new SqlCommand(UpdQry, DB.Connection);

        UpdCmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = int.Parse(hdnUserID.Value.ToString());
        UpdCmd.Parameters.Add(new SqlParameter("@UserID1", SqlDbType.SmallInt)).Value = int.Parse(hdnUserID.Value.ToString());
        UpdCmd.Parameters.Add(new SqlParameter("@UserID2", SqlDbType.SmallInt)).Value = int.Parse(hdnUserID.Value.ToString());
        UpdCmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50)).Value = txtNewPassword.Text;

        DB.Connection.Open();
        UpdCmd.ExecuteNonQuery();
        DB.Connection.Close();
    }
    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        if (btnResetPassword.Text == "Reset Password")
        {
            UpdatePassword();
            lblLoginMessage.Text = "Password reset successfully";
            btnResetPassword.Text = "Ok";
            btnResetPassword.CausesValidation = false;
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
    protected void Page_Init(object sender, EventArgs e)
    {
        //Session.Abandon();//Abandon session
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
    }
}