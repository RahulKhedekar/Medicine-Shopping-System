using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Globalization;




    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void signup_Click(object sender, EventArgs e)
        {
            if (checkemail() == true)
            {                
                LError.Text = "Email already exist";

            }
            else
            {
                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
                try
                {
                    var name = "";
                    var cont = "";
                    var emailid = "";
                    var pass = "";            


                    name = username.Text;
                    var titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
                    var str = " ";
                    var name1=titleCase+str;
                    cont = mobilenumber.Text;
                    emailid = email.Text;
                    pass = password.Text;
                    var firstspaceindex = name1.IndexOf(" ");
                    var firstString = titleCase.Substring(0, firstspaceindex);
                    var utype = "U";
                    myConnection.Open();

                    string query = "Insert into [dbo].[User_info] (name,mobile_no,email,password,fname,usertype,date) Values (@titleCase,@cont,@emailid,@pass,@firstString,@utype,getdate())";
                    SqlCommand insertCommand = new SqlCommand(query, myConnection);                  
                    insertCommand.Parameters.AddWithValue("@titleCase", titleCase);
                    insertCommand.Parameters.AddWithValue("@cont", cont);
                    insertCommand.Parameters.AddWithValue("@emailid", emailid);
                    insertCommand.Parameters.AddWithValue("@pass", pass);
                    insertCommand.Parameters.AddWithValue("@firstString", firstString);
                    insertCommand.Parameters.AddWithValue("@utype", utype);
                    insertCommand.ExecuteNonQuery();
                    Session["USERNAME"] = emailid;
                    myConnection.Close();
                    Response.Write("<script language='javascript'>window.location='http://localhost:1341/Online Medicine Shopping/Home/Home.aspx';</script>");

                }
                catch (Exception ex)
                {
                    Response.Write(ex + "Can't Submit Your Data");
                }
            }
        }
        private Boolean checkemail()
        {
            Boolean emailavailable = false;
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
            String myquery = "Select * from User_info where email='" + email.Text + "'";
            SqlCommand insertCommand = new SqlCommand(myquery, myConnection);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = insertCommand;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                emailavailable = true;

            }
            myConnection.Close();

            return emailavailable;
        }
    }
