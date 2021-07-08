<%@ Page Language="C#" AutoEventWireup="true" CodeFile="log.aspx.cs" Inherits="log" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Sign In</title>
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
       <asp:SqlDataSource ID="Sample" runat="server" ConnectionString="<%$ ConnectionStrings:OMSConnectionString %>" SelectCommand="SELECT * FROM [User_info]"></asp:SqlDataSource>
        <br />
            <div class="center1">
                <h2>Sign In</h2><br />
                        <asp:TextBox ID="username" class="input1" runat="server" placeholder="Email" onkeyup="change(this,'signin');"></asp:TextBox><br />                        
                        <asp:TextBox ID="password" class="input1" runat="server" placeholder="Password" onkeyup="change(this,'signin');"></asp:TextBox><br /><br />
                        
                        <asp:Button ID="signin" runat="server" Enabled="false" class="input1" Text="Login" onclick="signin_Click" Width="279px" Height="38px" />
                        <asp:Label ID="LError" runat="server" Cssclass="text-danger"></asp:Label><br />
                        <a href="ForgotPassword.aspx" class="mt-1">Forgot Password ?</a><br />
                        <hr class="mt-1 mb-1" style="width: 280px;" />
                        <p>Don't have an account ? <a href="SignUp.aspx">Sign up</a> </p>
            </div>
    </form>
    <script type="text/javascript">
        function change(textb, button) {
            var firstt = document.getElementById('<%= username.ClientID %>');
            var secondt = document.getElementById('<%= password.ClientID %>');
            if ((textb.value.length >= 1 && firstt.value.length >= 1) && (textb.value.length >= 1 && secondt.value.length >= 1)) 
            {
                document.getElementById(button).disabled = false;              
            }
            else
                document.getElementById(button).disabled = true;

        }
    </script>
</body>
</html>
