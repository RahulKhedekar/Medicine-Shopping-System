using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class ResetPassword : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    string email;


    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
        string GUIDvalue;
        GUIDvalue = Request.QueryString["Uid"];
        if (GUIDvalue != null)
        {
            SqlCommand cmd = new SqlCommand("select * from ForgotPassword where guid='" + GUIDvalue + "'", myConnection);
            myConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);            
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                email = dt.Rows[0]["email"].ToString().Trim();
            }
            else
            {
                lblMsg.Text = "Your Password Reset Link is Expired or Invalid !";
                lblMsg.ForeColor = Color.Red;
            }
        }
        else
        {
            Response.Redirect("http://localhost:1341/Online Medicine Shopping/Default/Default.aspx");
        }

        if (!IsPostBack)
        {
            if (dt.Rows.Count != 0)
            {
                pass.Visible = true;
                cpass.Visible = true;
                Button1.Visible = true;

            }
            else
            {
                lblMsg.Text = "Your Password Reset Link is Expired or Invalid !";
                lblMsg.ForeColor = Color.Red;
            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (pass.Text != "" && cpass.Text != "" && pass.Text == cpass.Text)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);            
            SqlCommand cmd = new SqlCommand("update User_info set password='" + pass.Text + "' where email='" + email + "'", myConnection);
            myConnection.Open();
            cmd.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("delete from ForgotPassword where email='" + email + "'", myConnection);
            cmd2.ExecuteNonQuery();
            Response.Redirect("http://localhost:1341/Online Medicine Shopping/log.aspx");
            
        }
    }
}