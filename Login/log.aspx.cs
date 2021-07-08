using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class log : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USERNAME"] != null)
        {
            Response.Write("<script language='javascript'>window.location='http://localhost:1341/Online Medicine Shopping/Home/Home.aspx';</script>");
        }
        else
        {
        }

    }

    protected void signin_Click(object sender, EventArgs e)
    {        
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
        try
        {
            var text1 = username.Text;
            var text2 = password.Text;
            myConnection.Open();
            string query = "Select * from User_info where email='" + text1 + "' and password='" + text2 + "'";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SqlDataReader sdr = cmd.ExecuteReader();
                      
            if (sdr.Read())
            {
                string utype;
                utype = dt.Rows[0]["usertype"].ToString().Trim();

                if (utype == "U")
                {
                    Session["USERNAME"] = text1;
                    Response.Write("<script language='javascript'>window.location='http://localhost:1341/Online Medicine Shopping/Home/Home.aspx';</script>");
                    if (Request.QueryString["url"] != null)
                    {
                        if (Request.QueryString["url"] == "cart")
                        {
                            Response.Redirect("~/Home/AddCart.aspx");
                        }
                    }
                    else
                    {
                        Response.Cookies["bk"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["bk"].Expires = DateTime.Now.AddDays(-1);
                        Response.Redirect("~/Home/Home.aspx");
                    }
                }

                if (utype == "A")
                {
                    Session["USERNAME"] = text1;
                    Response.Write("<script language='javascript'>window.location='http://localhost:1341/Online Medicine Shopping/Admin/Admin.aspx';</script>");
                }

                
                myConnection.Close();
            }
            else
            {
                LError.Text = "Invalid Username or Password";
                username.Text = null;
                password.Text = null;
            }
            myConnection.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex + "Invalid User");
        }
    }
}