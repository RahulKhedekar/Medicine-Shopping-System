<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Reset Password</title>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.0/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.19.0/css/mdb.min.css" rel="stylesheet"/>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center2">
            <h3 >Reset Password</h3>
            <asp:Label ID="lblMsg" runat="server" CssClass="col-md-0 control-label"></asp:Label><br />
            <asp:TextBox ID="pass" class="input1" runat="server" placeholder="New Password" Visible="False" onkeyup="change(this,'Button1');"></asp:TextBox><br />
            <asp:TextBox ID="cpass" class="input1" runat="server" placeholder="Confirm Password" Visible="False" onkeyup="change(this,'Button1');"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Enabled="false" Text="Send" Height="38px" Width="279px"  Visible="False" OnClick="Button1_Click" /><br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/js/bootstrap.bundle.min.js" integrity="sha256-OUFW7hFO0/r5aEGTQOz9F/aXQOt+TwqI1Z4fbVvww04=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="../js/script.js"></script>
    <script type="text/javascript">
        function change(textb, button) {
            var firstt = document.getElementById('<%= pass.ClientID %>');
            var secondt = document.getElementById('<%= cpass.ClientID %>');
            if ((textb.value.length >= 1 && firstt.value.length >= 1) && (textb.value.length >= 1 && secondt.value.length >= 1)) {
                document.getElementById(button).disabled = false;
            }
            else
                document.getElementById(button).disabled = true;

        }
    </script>
</body>
</html>
