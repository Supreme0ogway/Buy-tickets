<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchConcertPage.aspx.cs" Inherits="HW4WebSiteApplication.SearchConcertPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            float: right;
            left: 59px;
            top: -11px;
        }
        .auto-style2 {
            position: relative;
            float: right;
            left: 57px;
            top: -11px;
        }
        .auto-style3 {
            position: relative;
            float: right;
            left: 55px;
            top: -12px;
        }
    </style>
    </head>
<body>
    <form id="form2" runat="server">
        <div style="font-family: 'Bahnschrift SemiBold'; font-size: 100px; background-color: #00CC66">
            Search</div>
        <p>
            <asp:Button ID="Button4" runat="server" Text="Search" OnClick="Button4_Click" />
            <asp:Button ID="Button5" runat="server" style="margin-right:63px;" Text="Home" CssClass="auto-style1" OnClick="Button5_Click" />
            <asp:Button ID="Button6" runat="server" style="margin-right:20px; height: 26px;" Text="Back" CssClass="auto-style2" OnClick="Button6_Click" />
            <asp:Button ID="Button7" runat="server" style="margin-right:20px;" Text="Buy tickets" CssClass="auto-style3" OnClick="Button7_Click" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="[Please Note]: All tickets come at a first come first serve basis. You are only able to buy tickets after the artist's previous concert. Every concert will be placed at least 3 days in advance."></asp:Label>
        </p>
        <p>
            Keyword: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Content Amount (must be less than 20 ; default is 1):
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            Country ID (Default: &quot;US&quot;):
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            Search between now and up to the date of:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;(default format: &quot;2023-08-01T12:00:00Z&quot;)</p>
        <p>
            Information:</p>
        <p>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
