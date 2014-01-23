<%@ WebHandler Language="C#" Class="GetImagePart" %>

using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public class GetImagePart : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        Int32 intImagePartID;
        if (context.Request.QueryString["ImagePartID"] != null)
            intImagePartID = Convert.ToInt32(context.Request.QueryString["ImagePartID"]);
        else
            throw new ArgumentException("No parameter specified");

        context.Response.ContentType = "image/jpeg";
        Stream strm = getPersuasiveImage(intImagePartID);
        byte[] buffer = new byte[4096];
        int byteSeq = strm.Read(buffer, 0, 4096);

        while (byteSeq > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, byteSeq);
            byteSeq = strm.Read(buffer, 0, 4096);
        }
    }

    public Stream getPersuasiveImage(int intPersuasiveImgID)
    {
        DBFunctions DB = new DBFunctions();

        string sql = "SELECT ImagePart " +
                     "FROM PersuasiveImages " +
                     "WHERE PersuasiveImgID = @PersuasiveImgID";

        SqlCommand cmd = new SqlCommand(sql, DB.Connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@PersuasiveImgID", intPersuasiveImgID);
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