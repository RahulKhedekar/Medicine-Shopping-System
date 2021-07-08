using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_Delete : System.Web.UI.Page
{
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            myConnection.Open();
            SqlCommand cmd = myConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM [dbo].[Medicine] WHERE Mid='" + Request.QueryString["id"] + "'";
            cmd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>window.alert('Book Deleted Successfully');window.location='DeleteProduct.aspx';</script>");

        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }
}