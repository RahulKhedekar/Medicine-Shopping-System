using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_Default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void searchMedicine(object sender, EventArgs e)
    {
        string result = "http://localhost:1341/Online Medicine Shopping/Default/SearchMedicine.aspx?result=" + TextBox1.Text.ToUpper();
        Response.Redirect(result);
    }
}
