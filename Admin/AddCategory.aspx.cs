using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void addcatBtn_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);

            var category = "";
            category = cat.Text;

            myConnection.Open();
            SqlCommand cmd = new SqlCommand("Insert into [dbo].[Category] (CatName) values(@category)", myConnection);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>window.alert('Sucessfully Added')</script>");
            cat.Text = "";
            myConnection.Close();

        }
        catch (Exception ex)
        {
            Response.Write(ex + "<scrip>alert('Cant Submit Data')</script>");
        }
    }
}