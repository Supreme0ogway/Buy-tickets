<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HW4WebSiteApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            float: right;
            left: -222px;
            top: -30px;
            width: 56px;
            height: 26px;
        }
        .auto-style2 {
            position: relative;
            float: right;
            left: -48px;
            top: -26px;
        }
        .auto-style3 {
            position: relative;
            float: right;
            left: -49px;
            top: -26px;
        }
        .auto-style4 {
            position: relative;
            float: right;
            left: -133px;
            top: -27px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: 'Bahnschrift SemiBold'; font-size: 100px; font-weight: bold; background-color: #00CC66; color: #000000">
            Ticket Expert</div>
        <p style="font-family: 'Bahnschrift SemiBold'; font-size: 30px; color: #00CC66">
            <asp:Button ID="Button1" runat="server" BackColor="#00CC66" Text="Login" style="margin-right:20px;" CssClass="auto-style1" OnClick="Button1_Click"/>
            Home<asp:Button ID="Button3" runat="server" style="margin-right:20px;" Text="Sign Up" CssClass="auto-style2" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" style="margin-right:20px;" Text="Log out" CssClass="auto-style3" OnClick="Button4_Click" />
            <asp:Button ID="Button5" runat="server" style="margin-right:20px;" Text="Reciepts" CssClass="auto-style4" OnClick="Button5_Click" />
        </p>
    &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View Concert Catelog" Width="214px" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
