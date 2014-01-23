using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administrator_PasswordChart : System.Web.UI.Page
{
    DBFunctions db = new DBFunctions();
    Dictionary<string, int> ChartData = new Dictionary<string, int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            GetValues();
        }
    }

    void GetValues()
    {
        string QryStr = "select p.PasswordModeName, count(*) as NoUsers  " +
                        "from UserDetails as u, PasswordMode as p " +
                        "where u.PasswordModeID=p.PasswordModeID " +
                        "group by u.PasswordModeID, p.PasswordModeName";
        DataSet DSet = new DataSet();
        db.GetData(QryStr, "UserDetails", DSet);
        foreach (DataRow drow in DSet.Tables["UserDetails"].Rows)
        {
            ChartData.Add(drow["PasswordModeName"].ToString(), int.Parse(drow["NoUsers"].ToString()));
        }
        Chart1.Series["PasswordChart"].Points.DataBind(ChartData, "Key", "Value", string.Empty);
        Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
    }
}