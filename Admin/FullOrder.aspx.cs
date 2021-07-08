using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_FullOrder : System.Web.UI.Page
{
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
    int id;    
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["id"].ToString());

        myConnection.Open();

        SqlCommand cmd1 = myConnection.CreateCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = "SELECT * FROM [dbo].[Order] WHERE OrderId=" + id + "";
        cmd1.ExecuteNonQuery();
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        da1.Fill(dt1);
        Repeater1.DataSource = dt1;
        Repeater1.DataBind();
        myConnection.Close(); 
    }
}