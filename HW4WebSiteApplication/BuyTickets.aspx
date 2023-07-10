<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyTickets.aspx.cs" Inherits="HW4WebSiteApplication.BuyTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div style="font-family: 'Bahnschrift SemiBold'; font-size: 100px; background-color: #00CC66">
            Buy Tickets</div>
        <p>
            <asp:Button ID="Button4" runat="server" Text="Search" OnClick="Button4_Click" />
            <asp:Button ID="Button8" runat="server" style="position:relative; float:right; margin-right:20px; height: 26px;" Text="Home" OnClick="Button8_Click" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="[Please Note]: All tickets come at a first come first serve basis. You are only able to buy tickets after the artist's previous concert. Every concert will be placed at least 3 days in advance."></asp:Label>
        </p>
        <p>
            Keyword: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
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
        <p>
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Buy tickets" />
&nbsp;<asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
