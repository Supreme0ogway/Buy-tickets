<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogPage.aspx.cs" Inherits="HW4WebSiteApplication.CatalogPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            float: right;
            left: 0px;
            top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: 'Bahnschrift SemiBold'; font-size: 100px; background-color: #00CC66">
            Catalog</div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show Upcoming Concerts" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search For Upcoming Concerts" Width="211px" />
            <asp:Button ID="Button3" runat="server" style="margin-right:63px;" Text="Home" CssClass="auto-style1" OnClick="Button3_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            Enter a valid country code (for example: &quot;US&quot;):
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" Text="Buy tickets" OnClick="Button4_Click" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
