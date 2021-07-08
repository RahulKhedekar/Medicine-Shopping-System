using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Home_OrderDetails : System.Web.UI.Page
{
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);

    string order = "";
    string order_id = "";
    string method = "";
    string s;
    string t;
    string[] a = new string[6];
    decimal tot = 0;
    int dis = 0;
    decimal rp = 0;
    int count = 0;
    DateTime date = DateTime.Now;
    string delidate;
    string address, state, city, zipcode, landmark, username;

    protected void Page_Load(object sender, EventArgs e)
    {
        myConnection.Open();
        order = Request.QueryString["orderid"];
        method = Request.QueryString["paymode"];

        if (order == Session["order_no"].ToString())
        {
            //for getting user details and storing in order_details

            SqlCommand cmd = myConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[User_info] where email='" + Session["USERNAME"] + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                SqlCommand cmd1 = myConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE [dbo].[ShipDetails] SET email='" + dr["email"].ToString() + "', payment='" + method.ToString() + "'";
                cmd.ExecuteNonQuery();
            }

            //now we'll get orderid from table

            SqlCommand cmd2 = myConnection.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT TOP 1 * FROM [dbo].[ShipDetails] where email='" + Session["USERNAME"].ToString() + "'ORDER BY id DESC";
            cmd2.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                order_id = dr2["id"].ToString();
                address = dr2["address"].ToString();
                state = dr2["state"].ToString();
                city = dr2["city"].ToString();                
                zipcode = dr2["zipcode"].ToString();
                username = dr2["name"].ToString();
            }

            if (Request.Cookies["bk"] != null)
            {
                s = Convert.ToString(Request.Cookies["bk"].Value);

                string[] strArr = s.Split('|');

                for (int j = 0; j < strArr.Length; j++)
                {
                    t = Convert.ToString(strArr[j].ToString());
                    string[] strArr1 = t.Split(',');

                    for (int i = 0; i < strArr1.Length; i++)
                    {
                        a[i] = strArr1[i].ToString();
                    }
                    tot = tot + (Convert.ToDecimal(a[2].ToString()) * Convert.ToDecimal(a[4].ToString()));
                    SqlCommand cmd3 = myConnection.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "INSERT INTO [dbo].[Order] (OrderID, PName, PAmount, PQty, PImage, purdate, orderno, name, deldate, paymethod, totamt) VALUES('" + order_id.ToString() + "', '" + a[0].ToString() + "', '" + a[2].ToString() + "', '" + a[4].ToString() + "', '" + a[5].ToString() + "', '" + date.ToString() + "', '" + order.ToString() + "',  '" + username.ToString() + "', '" + date.AddDays(12).ToString().Substring(0, 10) + "', '" + method.ToString() + "', '" + tot.ToString() + "')";
                    cmd3.ExecuteNonQuery();


                    dis = dis + (Convert.ToInt32(a[3].ToString()) * Convert.ToInt32(a[4].ToString()));
                    rp = rp + (Convert.ToDecimal(a[1].ToString()) * Convert.ToDecimal(a[4].ToString()));
                    count = count + 1;
                    LCount.Text = count.ToString();
                    LT.Text = tot.ToString();
                    LP.Text = rp.ToString();
                    LD.Text = "-" + dis.ToString();
                    LOrder.Text = order.ToString();
                    Lpayment.Text = method.ToString();
                    delidate = date.AddDays(12).ToString();
                    LDDate.Text = delidate.Substring(0, 10);
                    LDate.Text = DateTime.Now.ToString().Substring(0, 10);
                    LAddress.Text = address;
                    LState.Text = state;
                    LCity.Text = city;                    
                    LZipcode.Text = zipcode;

                    Response.Cookies["bk"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["bk"].Expires = DateTime.Now.AddDays(-1);
                }
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }

        }
        else
        {
            Response.Redirect("~/Login/log.aspx");
        }


        SqlCommand cmd4 = myConnection.CreateCommand();
        cmd4.CommandType = CommandType.Text;
        cmd4.CommandText = "SELECT * FROM [dbo].[Order] where OrderID=" + order_id + "";

        cmd4.ExecuteNonQuery();
        DataTable dt4 = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd4);
        sda.Fill(dt4);
        RepeatOrder.DataSource = dt4;
        RepeatOrder.DataBind();

        user.Text = username.ToString();

        myConnection.Close();
    }
}