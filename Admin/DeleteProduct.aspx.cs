using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_DeleteProduct : System.Web.UI.Page
{
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
        try
        {
            myConnection.Open();            
            SqlCommand cmd = myConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [Mid], [MName], [MPrice], [MSPrice], [Discount], [MDescription], [MImage], [MExtention], [CatName] FROM [dbo].[Medicine]";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            RptTable.DataSource = dt;
            RptTable.DataBind();

            myConnection.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something went Wrong')</script>");
        }
    }
}