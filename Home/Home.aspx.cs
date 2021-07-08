using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Home_Home2 : System.Web.UI.Page
{
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindCategory();
        }

        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
        try
        {
            myConnection.Open();
            SqlCommand cmd = myConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [Mid], [MName], [MPrice], [MSPrice], [MImage], [MExtention] FROM [dbo].[Medicine]";
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

    protected void dropCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        var query = "";
        var selectproduct = dropCategory.SelectedItem.Value.ToString();
        if (selectproduct == "0")
        {
            query = "";
        }
        else
        {
            query = "where Category ='" + selectproduct + "' ";
        }
        SqlDataAdapter sda = new SqlDataAdapter("SELECT [Mid], [MName], [MPrice], [MSPrice], [Discount], [MImage], [MExtention] FROM [dbo].[Medicine] " + query + " ", myConnection);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        try
        {
            if (selectproduct == dt.Rows[0][4].ToString())
            {

            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('No Medicine Found')</script>");
        }
        RepeatBooks.DataSourceID = null;
        RepeatBooks.DataSource = dt;
        RepeatBooks.DataBind();
    }

    private void BindCategory()
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
        myConnection.Open();
        SqlCommand cmd = new SqlCommand("Select * from [dbo].[Category]", myConnection);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        dropCategory.BorderStyle = BorderStyle.None;

        if (dt.Rows.Count != 0)
        {
            dropCategory.DataSource = dt;
            dropCategory.DataTextField = "CatName";
            dropCategory.DataValueField = "CatID";
            dropCategory.DataBind();
            dropCategory.Items.Insert(0, new ListItem("All Medicine", "0"));
        }

    }
}