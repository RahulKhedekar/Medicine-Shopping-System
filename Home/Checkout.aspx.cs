using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Home_Checkout : System.Web.UI.Page
{
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
    string s;
    string t;
    string[] a = new string[6];
    decimal tot = 0;
    int dis = 0;
    decimal rp = 0;
    int q = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("MName"), new DataColumn("MPrice"), new DataColumn("MSPrice"), new DataColumn("Discount"), new DataColumn("BQty"), new DataColumn("MImage"), new DataColumn("Mid") });

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
                    dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), a[5].ToString(), j.ToString());

                    tot = tot + (Convert.ToDecimal(a[2].ToString()) * Convert.ToDecimal(a[4].ToString()));
                    dis = dis + (Convert.ToInt32(a[3].ToString()));
                    rp = rp + (Convert.ToDecimal(a[1].ToString()));
                    q = q + (Convert.ToInt32(a[4].ToString()));
                    LT.Text = tot.ToString();
                    LP.Text = rp.ToString();
                    LD.Text = dis.ToString();
                    CQ.Text = q.ToString();
                }
            }
        }
    }

    protected void checkout_Click(object sender, EventArgs e)
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
        try
        {
            myConnection.Open();
            SqlCommand cmd = myConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert INTO [dbo].[ShipDetails] (name, contact, altcontact, email, address, city, state, zipcode) VALUES('" + Fname.Text + "','" + cont.Text + "', '" + altcont.Text + "', '" + email.Text + "', '" + address.Text + "', '" + city.Text + "', '" + state.Text + "', '" + zipcode.Text + "')";
            cmd.ExecuteNonQuery();
            myConnection.Close();

            Fname.Text = "";
            altcont.Text = "";
            cont.Text = "";
            email.Text = "";
            address.Text = "";
            city.Text = "";
            state.Text = "";
            zipcode.Text = "";
            
            var order_no = findorderid();
            var paymode = "";
            Session["order_no"] = order_no.ToString();
            Session["tot"] = tot.ToString();
            string total = tot.ToString();
            if(cashRadio.Checked)
            {
                 paymode = "Cash";
                //Response.Redirect("orderDetails.aspx?orderid=" + order_no);
                Response.Redirect("OrderDetails.aspx?orderid=" + order_no + "&paymode=" + paymode);
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something went Wrong')</script>");
        }
    }
    public string findorderid()
    {
        string oid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        Random r = new Random();
        char[] myoid = new char[5];

        for (int i = 0; i < 5; i++)
        {
            myoid[i] = oid[(int)(35 * r.NextDouble())];
        }
        string orderid;
        orderid = "OD" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString() + new string(myoid);
        return orderid;
    }
}