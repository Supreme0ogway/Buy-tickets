<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInPage.aspx.cs" Inherits="HW4WebSiteApplication.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


        .auto-style1 {
            position: relative;
            float: right;
            left: 2px;
            top: 0px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
        <div style="font-family: 'Bahnschrift SemiBold'; font-size: 100px; background-color: #00CC66">
            Log In</div>
        <p>
&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" style="margin-right:63px;" Text="Home" CssClass="auto-style1" OnClick="Button3_Click" />
            <asp:Button ID="Button5" runat="server" style="position:relative; float:right; margin-right:63px;" Text="Sign Up" OnClick="Button5_Click" />
        </p>
            <p>
                Username: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
            <p>
                Password:
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
            <p>
            &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Remember me?" />
        </p>
            <p>
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Log In" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        </div>
    </form>
</body>
</html>
