<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="HW4WebSiteApplication.SignUpPage" %>

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
    <form id="form1" runat="server">
        <div>
        <div style="font-family: 'Bahnschrift SemiBold'; font-size: 100px; background-color: #00CC66">
            Sign Up</div>
        <p>
&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" style="margin-right:63px;" Text="Home" CssClass="auto-style1" OnClick="Button3_Click" />
            Sign up! (It&#39;s FREE!)<asp:Button ID="Button5" runat="server" style="position:relative; float:right; margin-right:63px;" Text="Log In" OnClick="Button5_Click" />
        </p>
            <p>
                Username: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
            <p>
                Password:
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
            <p>
                Re-Enter Password:
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
            <p>
            &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Remember me?" />
        </p>
            <p>
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Sign Up" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        </div>
    </form>
</body>
</html>
