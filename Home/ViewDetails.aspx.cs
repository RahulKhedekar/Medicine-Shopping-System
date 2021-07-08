using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Home_ViewDetails : System.Web.UI.Page
{
    int mid;
    string pname, pprice, pdisc, psprice, pqty, pimg;
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Mid"] == null)
            {
                Response.Redirect("http://localhost:1341/Online Medicine Shopping/Default/Default.aspx");
            }
            else
            {
                mid = Convert.ToInt32(Request.QueryString["Mid"].ToString());
                myConnection.Open();
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [dbo].[Medicine] where Mid=" + mid + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                RepeatBooks.DataSource = dt;
                RepeatBooks.DataBind();

                myConnection.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex + "<script>alert('Something went Wrong')</script>");
        }
    }
    protected void cartBtn_Click(object sender, EventArgs e)
    {
        myConnection.Open();
        SqlCommand cmd = myConnection.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT * FROM [dbo].[Medicine] where Mid=" + mid + "";
        cmd.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            pname = dr["MImage"].ToString();
            pprice = dr["MPrice"].ToString();
            psprice = dr["MSPrice"].ToString();
            pdisc = dr["Discount"].ToString();
            pqty = DropDownList1.SelectedItem.ToString();
            pimg = dr["MImage"].ToString();
        }
        myConnection.Close();

        if (Request.Cookies["bk"] == null)
        {
            Response.Cookies["bk"].Value = pname.ToString() + "," + pprice.ToString() + "," + psprice.ToString() + "," + pdisc.ToString() + "," + pqty.ToString() + "," + pimg.ToString();
            Response.Cookies["bk"].Expires = DateTime.Now.AddDays(1);
        }
        else
        {
            Response.Cookies["bk"].Value = Request.Cookies["bk"].Value + "|" + pname.ToString() + "," + pprice.ToString() + "," + psprice.ToString() + "," + pdisc.ToString() + "," + pqty.ToString() + "," + pimg.ToString();
            Response.Cookies["bk"].Expires = DateTime.Now.AddDays(1);
        }
        Response.Redirect("ViewDetails.aspx?mid=" + mid);
    }
}