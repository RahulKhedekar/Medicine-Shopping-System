using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class Admin_AddProduct : System.Web.UI.Page
{
    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategory();
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
            var mname = "";
            var mdecription = "";
            var mimage = "";
            var mcategory = "";
            var mcatname = "";
            decimal mprice = Convert.ToDecimal(txtPrice.Text);
            decimal msprice = Convert.ToDecimal(txtSelPrice.Text);
            decimal disc = mprice - msprice;

            mname = txtPName.Text.ToUpper();
            mdecription = txtDesc.Text;
            mimage = txtPName.Text.ToString().Trim();
            mcategory = ddlCategory.SelectedItem.Value;
            mcatname = ddlCategory.SelectedItem.ToString();
            myConnection.Open();
            if (fuImg01.HasFile)
            {
                string SavePath = Server.MapPath("~/image/ProductImages/" + txtPName.Text.ToString().Trim());
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                var Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
                fuImg01.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + Extention);

                string query = "Insert into [dbo].[Medicine] (MName,MPrice,MSPrice,Discount,MDescription,Mimage,MExtention,Category,CatName) Values (@mname,@mprice,@msprice,@disc,@mdescription,@mimage,@Extention,@mcategory,@mcatname)";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@mname", mname);
                cmd.Parameters.AddWithValue("@mprice", mprice);
                cmd.Parameters.AddWithValue("@msprice", msprice);
                cmd.Parameters.AddWithValue("@disc", disc);
                cmd.Parameters.AddWithValue("@mdescription", mdecription);
                cmd.Parameters.AddWithValue("@mimage", mimage);
                cmd.Parameters.AddWithValue("@Extention", Extention);
                cmd.Parameters.AddWithValue("@mcategory", mcategory);
                cmd.Parameters.AddWithValue("@mcatname", mcatname);
                cmd.ExecuteNonQuery();
            }

            Response.Write("<script language='javascript'>window.alert('Medicine Added Sucessfull');</script>");
            txtPName.Text = "";
            txtPrice.Text = "";
            txtSelPrice.Text = "";
            txtDesc.Text = "";
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Can't Insert the Medicine.. Sorry!!');</script>");
            myConnection.Close();
        }
    }
}