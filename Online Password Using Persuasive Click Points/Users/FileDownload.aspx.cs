using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Users_FileDownload : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    void GetFilesList()
    {
        string QryStr = "select * from FilesUpload --where UserID=";
        DataSet DSet=new DataSet();
        DB.GetData(QryStr, "FilesUpload", DSet);
        gridFilesDetails.DataSource = DSet;
        gridFilesDetails.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            GetFilesList();
        }
    }
    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        int fileid = Convert.ToInt32(gridFilesDetails.DataKeys[gvrow.RowIndex].Value.ToString());
        string name, type;

        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "select FileName, FileType, FileUpload from FilesUpload where FileID=@FileID";
        cmd.Parameters.AddWithValue("@FileID", fileid);
        cmd.Connection = DB.Connection;
        DB.Connection.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Response.ContentType = dr["FileType"].ToString();
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + dr["FileName"] + "\"");
            Response.BinaryWrite((byte[])dr["FileUpload"]);
            Response.End();
        }

    }
    //if (e.CommandName == "Download")
    //{
    //    string fileName = string.Empty;
    //    int index = Convert.ToInt32(e.CommandArgument);
    //    GridViewRow row = gridDesignDetails.Rows[index];
    //    int documentID = Convert.ToInt32(gridDesignDetails.DataKeys[index].Value);

    //    SqlCommand cmd = new SqlCommand("select 'OrderCopy'+ convert(varchar, HandoverID) as OrderCopyName, OrderCopy " +
    //                                    "from TracedVehHandover where HandoverID=" + documentID, DB.Connection);
    //    DB.Connection.Open();
    //    SqlDataReader dReader = cmd.ExecuteReader();
    //    while (dReader.Read())
    //    {
    //        fileName = dReader["OrderCopyName"].ToString();
    //        byte[] documentBinary = (byte[])dReader["OrderCopy"];
    //        FileStream fStream = new FileStream(Server.MapPath(@"~\Docs\") + @"\" + fileName, FileMode.Create);
    //        fStream.Write(documentBinary, 0, documentBinary.Length);
    //        fStream.Close();
    //        fStream.Dispose();
    //    }
    //    DB.Connection.Close();
    //    Response.Redirect(@"~\Docs\" + fileName);
    //}

}