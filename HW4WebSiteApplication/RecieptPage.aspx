<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecieptPage.aspx.cs" Inherits="HW4WebSiteApplication.RecieptPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            font-family: "Bahnschrift SemiBold";
            font-size: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div style="background-color: #00CC66" class="auto-style1">
            Information</div>
        <p>
            <asp:Button ID="Button8" runat="server" style="position:relative; float:right; margin-right:20px; height: 26px;" Text="Home" OnClick="Button8_Click" />
            Reciept:</p>
            <p>
                Name:
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
            <p>
                Card number charged:
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </p>
            <p>
                Concert:
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Download" />
            </p>
        </div>
    </form>
</body>
</html>
