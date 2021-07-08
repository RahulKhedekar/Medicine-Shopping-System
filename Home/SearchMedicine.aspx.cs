using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Home_SearchMedicine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
        try
        {
            myConnection.Open();
            SqlCommand cmd = myConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  [MName], [MPrice], [MSPrice], [Mimage], [MExtention] FROM [dbo].[Medicine] WHERE MName like '%'+@MName+'%'";
            cmd.Connection = myConnection;
            cmd.Parameters.AddWithValue("MName", Request.QueryString["result"]);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            RepeatBooks.DataSource = dt;
            RepeatBooks.DataBind();

            myConnection.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex + "Error");
        }
    }
}