using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class MasterPage_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USERNAME"] == null)
        {
            Response.Write("<script language='javascript'>window.location='http://localhost:1341/Online Medicine Shopping/Default/Default.aspx';</script>");
        }
        else
        {

            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
            myConnection.Open();
            string query = "Select fname from User_info where email='" + Session["USERNAME"] + "'";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            string uname;
            uname = dt.Rows[0]["fname"].ToString().Trim();
            LSuccess1.Text = "Hello" + " " + uname;
        }   
    }
    protected void logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Write("<script language='javascript'>window.location='http://localhost:1341/Online Medicine Shopping/Default/Default.aspx';</script>");
    }
}
