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

/// <summary>
/// Summary description for MastersList
/// </summary>
public class MastersList
{
    DBFunctions DB = new DBFunctions();
	public MastersList()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void PasswordMode(DropDownList DDLControl)
    {
        string QryStr = "select * from PasswordMode";
        DB.DDLDataBind(QryStr, "PasswordMode", "PasswordModeName", "PasswordModeID", DDLControl);
        DDLControl.Items.Insert(0, new ListItem("--Select Password Mode--", "0"));
    }
}
