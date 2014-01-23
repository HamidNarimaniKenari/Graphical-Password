using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DBFunctions
/// </summary>
public class DBFunctions
{
	public DBFunctions()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    string ConStr = ConfigurationManager.ConnectionStrings["OPUPCPSysDBConnectionString"].ConnectionString;
    public SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OPUPCPSysDBConnectionString"].ConnectionString);

    public void DBConnectionOpen()
    {
        Connection.Open();
    }
    public void DBConnectionClose()
    {
        Connection.Close();
    }
    public void GetData(string QueryString, string TableName, DataSet DSet)
    {
        SqlDataAdapter SalAdp = new SqlDataAdapter(QueryString, Connection);
        DSet.Clear();
        SalAdp.Fill(DSet, TableName);
    }
    public void InsertRecord(string InsertQueryString)
    {
        SqlCommand InsertCommand = new SqlCommand(InsertQueryString, Connection);
        InsertCommand.ExecuteNonQuery();
    }
    public void UpdateRecord(String UpdateQueryString)
    {
        SqlCommand UpdateCommand = new SqlCommand(UpdateQueryString, Connection);
        UpdateCommand.ExecuteNonQuery();
    }
    public void DDLDataBind(string QueryString, string TableName, string DataMember, string DataValue, DropDownList DDLControl)
    {
        DataSet DSet = new DataSet();
        GetData(QueryString, TableName, DSet);
        DDLControl.DataSource = DSet.Tables[TableName];
        DDLControl.DataTextField = DataMember;
        DDLControl.DataValueField = DataValue;
        DDLControl.DataBind();
    }
    public void RBLDataBind(string QueryString, string TableName, string DataMember, string DataValue, RadioButtonList RBLControl)
    {
        DataSet DSet = new DataSet();
        GetData(QueryString, TableName, DSet);
        RBLControl.DataSource = DSet.Tables[TableName];
        RBLControl.DataTextField = DataMember;
        RBLControl.DataValueField = DataValue;
        RBLControl.DataBind();
    }

}
