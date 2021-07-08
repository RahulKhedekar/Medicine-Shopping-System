<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Fogot Password</title>
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
       <asp:SqlDataSource ID="Sample" runat="server" ConnectionString="<%$ ConnectionStrings:OMSConnectionString %>" SelectCommand="SELECT * FROM [ForgotPassword]"></asp:SqlDataSource>
            <div class="center2">
                <b><h3>Password assistance</h3></b>
                   <lable>Enter your email and we'll send you a link to get back into your account.</lable><br /><br />
                    <b><label>Email</label></b><br />
                        <asp:TextBox ID="username" class="input2" runat="server" placeholder="Email" onkeyup="change(this,'Button1');"></asp:TextBox><br /><br />
                        <asp:Button ID="Button1" Enabled="false" runat="server" Text="Send" Height="38px" Width="279px" OnClick="Button1_Click" /><br />
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <hr class="mt-3 mb-2" style="width: 280px;" />
                        <a href="SignUp.aspx">Create New Account</a>
            </div>
    </form>
    <script type="text/javascript">
        function change(textb, button) {
            var firstt = document.getElementById('<%= username.ClientID %>');
            if ((textb.value.length >= 1 && firstt.value.length >= 1)) {
                document.getElementById(button).disabled = false;
            }
            else
                document.getElementById(button).disabled = true;

        }
    </script>
</body>
</html>
