<%@ WebHandler Language="C#" Class="GetImages" %>

using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public class GetImages : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        Int32 intImageID;
        if (context.Request.QueryString["ImageID"] != null)
            intImageID = Convert.ToInt32(context.Request.QueryString["ImageID"]);
        else
            throw new ArgumentException("No parameter specified");

        context.Response.ContentType = "image/jpeg";
        Stream strm = ShowCustomerPhoto(intImageID);
        byte[] buffer = new byte[4096];
        int byteSeq = strm.Read(buffer, 0, 4096);

        while (byteSeq > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, byteSeq);
            byteSeq = strm.Read(buffer, 0, 4096);
        }
    }

    public Stream ShowCustomerPhoto(int intAccountNo)
    {
        DBFunctions DB = new DBFunctions();

        string sql = "SELECT Image " +
                     "FROM ImageUploads " +
                     "WHERE ImageID = @ImageID";

        SqlCommand cmd = new SqlCommand(sql, DB.Connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ImageID", intAccountNo);
        DB.Connection.Open();
        object img = cmd.ExecuteScalar();
        try
        {
            return new MemoryStream((byte[])img);
        }
        catch
        {
            return null;
        }
        finally
        {
            DB.Connection.Close();
        }
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}