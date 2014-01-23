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

public partial class UserRegister : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    void SaveUserDetails()
    {
        //UserID, FirstName, LastName, EMailID, LoginName, Password, 
        string InsQry = "insert into UserDetails(FirstName, LastName, EMailID, MobileNo, LoginName, Password)" +
                                            " values(@FirstName, @LastName, @EMailID, @MobileNo, @LoginName, @Password) --set @UserID=";

        SqlCommand InsCmd = new SqlCommand(InsQry, DB.Connection);

        InsCmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 20)).Value = txtFirstName.Text;
        InsCmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 20)).Value = txtLastName.Text;
        InsCmd.Parameters.Add(new SqlParameter("@EMailID", SqlDbType.VarChar, 50)).Value = txtEMailID.Text;
        InsCmd.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.VarChar, 15)).Value = txtMobileNo.Text;
        InsCmd.Parameters.Add(new SqlParameter("@LoginName", SqlDbType.VarChar, 50)).Value = txtLoginName.Text;
        InsCmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50)).Value = txtPassword.Text;
        
       

        DB.Connection.Open();
        InsCmd.ExecuteNonQuery();
        DB.Connection.Close();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (btnSubmit.Text == "Submit")
        {
            if (lblAvailable.ForeColor == System.Drawing.Color.Red)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Login name is not avalilble, please select another login name";
                return;
            }
            lblMessage.ForeColor = System.Drawing.Color.Green;
            SaveUserDetails();
            lblMessage.Text = "Registered successfully";
            btnSubmit.Text = "Ok";
            btnSubmit.CausesValidation = false;
        }
        else
        {
            Response.Redirect("~/Users/UserHome.aspx");
        }
    }
    protected void txtLoginName_TextChanged(object sender, EventArgs e)
    {
        string QryStr = "select * from UserDetails where LoginName='" + txtLoginName.Text + "'";
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "UserDetails", DSet);
        if (DSet.Tables[0].Rows.Count > 0)
        {
            lblAvailable.Text = "<br>Login Name is not available";
            lblAvailable.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblAvailable.Text = "<br>Login Name is available";
            lblAvailable.ForeColor = System.Drawing.Color.Green;
        }
    }
}
