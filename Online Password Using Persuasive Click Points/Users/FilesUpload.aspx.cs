using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;

public partial class Users_FilesUpload : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            hdnUserID.Value = Session["UserID"].ToString();
        }
        else
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (btnSubmit.Text == "Submit")
        {
            SaveTracedVehicleHandover();
            lblMessage.Text = "Record saved successfully";
            btnSubmit.Text = "Ok";
            btnSubmit.CausesValidation = false;
        }

        else if (btnSubmit.Text == "Ok")
        {
            Clearing();
            btnSubmit.Text = "Submit";
            btnSubmit.CausesValidation = true;           
        }
    }
    void Clearing()
    {
        txtFileName.Text = "";
        txtFileDesciption.Text = "";
    }
    void SaveTracedVehicleHandover()
    {
        //Check whether FileUpload control has file 
        if (fileUpload.HasFile)
        {
            string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
            string fileExtension = Path.GetExtension(fileUpload.PostedFile.FileName);
            string fileType = fileUpload.PostedFile.ContentType;
            int fileSize = fileUpload.PostedFile.ContentLength;

            byte[] documentBinary = new byte[fileSize];
            fileUpload.PostedFile.InputStream.Read(documentBinary, 0, fileSize);


            //FileID, UserID, FileTitle, FileName, Description, FileUpload, , , , , , , , , , , , 
            string InsQry = "insert into FilesUpload(UserID, FileTitle, FileName, Description, DoFileUpload, FileUpload)" +
                                      "values(@UserID, @FileTitle, @FileName, @Description, @DoFileUpload, @FileUpload) -- set @LoginID = SCOPE_IDENTITY()";

            SqlCommand InsCmd = new SqlCommand(InsQry, DB.Connection);


            InsCmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = int.Parse(hdnUserID.Value);
            InsCmd.Parameters.Add(new SqlParameter("@FileTitle", SqlDbType.VarChar, 100)).Value = txtFileName.Text;
            InsCmd.Parameters.Add(new SqlParameter("@FileName", SqlDbType.VarChar, 100)).Value = fileName;
            InsCmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 500)).Value = txtFileDesciption.Text;
            InsCmd.Parameters.Add(new SqlParameter("@FileType", SqlDbType.VarChar, 500)).Value = fileType;
            InsCmd.Parameters.Add(new SqlParameter("@DoFileUpload", SqlDbType.SmallDateTime)).Value = DateTime.Now;
            InsCmd.Parameters.Add(new SqlParameter("@FileUpload", SqlDbType.Binary, fileSize)).Value = documentBinary;

            DB.Connection.Open();
            InsCmd.ExecuteNonQuery();
            DB.Connection.Close();
        }

    }
}