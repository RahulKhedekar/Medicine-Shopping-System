using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Net;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {        
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMSConnectionString"].ConnectionString);
        var text1 = username.Text;
        
        string query = "Select * from User_info where email='" + text1 + "'";
        SqlCommand cmd = new SqlCommand(query, myConnection);
        myConnection.Open();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count != 0)
        {
            // Send Mail
            string myGUID = Guid.NewGuid().ToString();
            String ToEmailAddress = dt.Rows[0]["email"].ToString().Trim();
            SqlCommand cmd1 = new SqlCommand("Insert into ForgotPassword values ('" + myGUID + "','" + ToEmailAddress + "',getdate())", myConnection);
            cmd1.ExecuteNonQuery();
            String uname = dt.Rows[0]["fname"].ToString().Trim();
            String EmailBody = "Hi " + uname + ",<br><br> Click the link below to reset your password <br><br>http://localhost:1341/Online%20Medicine%20Shopping/Login/ResetPassword.aspx?Uid="+myGUID;
            MailMessage PassReMail = new MailMessage("rahulkhedekar956@gmail.com", ToEmailAddress);
            PassReMail.Body = EmailBody;
            PassReMail.IsBodyHtml = true;
            PassReMail.Subject = "Reset Password";
            PassReMail.Priority = MailPriority.High;
            SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
            SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
            SMTP.UseDefaultCredentials = false;
            SMTP.Credentials = new NetworkCredential()
            {
                UserName = "rahulkhedekar956@gmail.com",
                Password = "95khedekarrahul6$"

            };
            SMTP.EnableSsl = true;
            SMTP.Send(PassReMail);
            Label1.Text = "Check your email to reset your password";
            Label1.ForeColor = Color.Green;
        }
        else
        {
            Label1.Text = "Email not exist";
            Label1.ForeColor = Color.Red;
        }
    }
}