<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Register</title>
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>            
        <!-- Sign Up -->
        <div class="center">
            <h2>Create Account</h2><br />            
                <asp:TextBox ID="username" class="input" runat="server" placeholder="Name" onkeyup="change(this,'signup');"></asp:TextBox><br />                                                    
                <asp:TextBox ID="mobilenumber" class="input" runat="server" placeholder="Mobile number" onkeyup="change(this,'signup');"></asp:TextBox><br />
                <asp:TextBox ID="email" class="input" runat="server" TextMode="Email" placeholder="Email" onkeyup="change(this,'signup');"></asp:TextBox><br />
                <asp:TextBox ID="password" class="input" runat="server" placeholder="Password" onkeyup="change(this,'signup');"></asp:TextBox><br /><br />

            <div class="col-xs-11 space-vert">
                <asp:Button ID="signup" runat="server" Enabled="false" Text="Sign Up" OnClick="signup_Click" Height="38px" Width="281px" />
            </div>
                        
            <asp:Label ID="LError" runat="server" Cssclass="text-danger"></asp:Label><br />
            <hr class="mt-0" style="width: 280px;" />
            <p>Do you have an account ? <a href="log.aspx">Sign in</a></p>

        </div>
        
      <!-- Sign Up -->
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/js/bootstrap.bundle.min.js" integrity="sha256-OUFW7hFO0/r5aEGTQOz9F/aXQOt+TwqI1Z4fbVvww04=" crossorigin="anonymous"></script>
    <script src="./js/script.js"></script>
    </form>
    <script type="text/javascript">
        function change(textb, button) {
            var firstt = document.getElementById('<%= username.ClientID %>');
            var secondt = document.getElementById('<%= mobilenumber.ClientID %>');
            var thirdt = document.getElementById('<%= email.ClientID %>');
            var fourtht = document.getElementById('<%= password.ClientID %>');
            if ((textb.value.length >= 1 && firstt.value.length >= 1) && (textb.value.length >= 1 && secondt.value.length >= 1) && (textb.value.length >= 1 && thirdt.value.length >= 1) && (textb.value.length >= 1 && fourtht.value.length >= 1)) {
                document.getElementById(button).disabled = false;
            }
            else
                document.getElementById(button).disabled = true;

        }
    </script>
    </body>
</html>
