using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class Admin_Update : System.Web.UI.Page
{
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
   
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);

        if (!IsPostBack)
        {
            BindCategory();

            myConnection.Open();
            int mid = Convert.ToInt32(Request.QueryString["id"]);
            SqlCommand cmd = myConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[Medicine] WHERE Mid=" + mid + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtPName.Text = dr["MImage"].ToString();
                txtPrice.Text = dr["MPrice"].ToString();
                txtSelPrice.Text = dr["MSPrice"].ToString();
                txtDesc.Text = dr["MDescription"].ToString();
            }
        }
    }
    private void BindCategory()
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
        myConnection.Open();
        SqlCommand cmd = new SqlCommand("Select * from [dbo].[Category]", myConnection);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count != 0)
        {
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "CatName";
            ddlCategory.DataValueField = "CatID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void updatep(object sender, EventArgs e)
    {
        try
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
            int mid = Convert.ToInt32(Request.QueryString["id"]);
            decimal dis = (Convert.ToDecimal(txtPrice.Text)) - (Convert.ToDecimal(txtSelPrice.Text));

            myConnection.Open();

            if (fuImg01.HasFile)
            {
                string SavePath = Server.MapPath("../image/ProductImages/" + txtPName.Text.ToString().Trim());
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
                fuImg01.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + Extention);


                SqlCommand insertCommand = myConnection.CreateCommand();
                insertCommand.CommandType = CommandType.Text;
                insertCommand.CommandText = "UPDATE [dbo].[Medicine] SET MName='" + txtPName.Text.ToUpper() + "', MPrice='" + Convert.ToDecimal(txtPrice.Text) + "', MSPrice='" + Convert.ToDecimal(txtSelPrice.Text) + "', Discount='" + dis + "', MDescription='" + txtDesc.Text + "', MImage='" + txtPName.Text.ToString().Trim() + "', Category='" + ddlCategory.SelectedItem.Value + "', CatName='" + ddlCategory.SelectedItem.ToString() + "' WHERE Mid=" + mid + "";
                insertCommand.ExecuteNonQuery();
            }

            Response.Write("<script language='javascript'>window.alert('Product Updated Sucessfully');;window.location='DeleteProduct.aspx';</script>");
            txtPName.Text = "";
            txtPrice.Text = "";
            txtSelPrice.Text = "";
            txtDesc.Text = "";

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Can't Update the Medicine.. Sorry!!');</script>");
            myConnection.Close();
        }
    }
}