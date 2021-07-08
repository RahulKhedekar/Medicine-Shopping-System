using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default_DeleteCart : System.Web.UI.Page
{
    string s;
    string t;
    string[] a = new string[6];
    int Mid;
    string pname, pprice, psprice, pimg, pdisc, pqty;

    protected void Page_Load(object sender, EventArgs e)
    {
        Mid = Convert.ToInt32(Request.QueryString["Mid"].ToString());

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
            }
        }
        dt.Rows.RemoveAt(Mid);

        Response.Cookies["bk"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["bk"].Expires = DateTime.Now.AddDays(-1);

        foreach (DataRow dr in dt.Rows)
        {
            pname = dr["BName"].ToString();
            pprice = dr["BPrice"].ToString();
            psprice = dr["BSPrice"].ToString();
            pdisc = dr["BDisc"].ToString();
            pqty = dr["BQty"].ToString();
            pimg = dr["BImage"].ToString();

            Response.Cookies["bk"].Value = Response.Cookies["bk"].Value + "|" + pname.ToString() + "," + pprice.ToString() + "," + psprice.ToString() + "," + pdisc.ToString() + "," + pqty.ToString() + "," + pimg.ToString();
            Response.Cookies["bk"].Expires = DateTime.Now.AddDays(1);
            
        }
        Response.Redirect("AddCart.aspx");
    }
}