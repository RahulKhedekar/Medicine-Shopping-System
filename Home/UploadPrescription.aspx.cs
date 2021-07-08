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

public partial class Home_UploadPrescription : System.Web.UI.Page
{
    string pname = "";
    string pmobileno = "";
    string pemail = "";
    string pimg = "";
    protected void Page_Load(object sender, EventArgs e)
    {        
        var sess="";
        sess = Session["USERNAME"].ToString();
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
        myConnection.Open();
        string query = "Select * from User_info where email='" + Session["USERNAME"] + "'";
        SqlCommand cmd = new SqlCommand(query, myConnection);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();            
        sda.Fill(dt);
        pname = dt.Rows[0]["name"].ToString().Trim();
        pmobileno = dt.Rows[0]["mobile_no"].ToString().Trim();
        pemail = dt.Rows[0]["email"].ToString().Trim();
        pimg = dt.Rows[0]["name"].ToString().Trim(); 
    }
     
    protected void Button1_Click(object sender, EventArgs e)
    {        
        try
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
            myConnection.Open();
            if (FileUpload1.HasFile)
            {
                string SavePath = Server.MapPath("../image/Prescription/" + pname);
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extention = Path.GetExtension(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(SavePath + "\\" + pname + Extention);
                string query = "Insert into [dbo].[Prescription] (name,mobile_no,email,pimage,extention) Values (@pname,@pmobileno,@pemail,@pimg,@Extention)";
                SqlCommand insertCommand = new SqlCommand(query, myConnection);
                insertCommand.Parameters.AddWithValue("@pname",pname);
                insertCommand.Parameters.AddWithValue("@pmobileno",pmobileno);
                insertCommand.Parameters.AddWithValue("@pemail",pemail);
                insertCommand.Parameters.AddWithValue("@pimg",pimg);
                insertCommand.Parameters.AddWithValue("@Extention",Extention);
                insertCommand.ExecuteNonQuery();
            }
            Response.Write("<script language='javascript'>window.alert('Prescription Added Sucessfull');</script>");
        }
        catch (Exception ex)
        {
  
        }
        
    }
}