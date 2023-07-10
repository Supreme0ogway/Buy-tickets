<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilesPage.aspx.cs" Inherits="HW4WebSiteApplication.FilesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div style="font-family: 'Bahnschrift SemiBold'; font-size: 100px; background-color: #00CC66">
            Reciepts</div>
        <p>
            <asp:Button ID="Button4" runat="server" Text="Upload Reciepts" OnClick="Button4_Click" />
            <asp:Button ID="Button8" runat="server" style="position:relative; float:right; margin-right:20px; height: 26px;" Text="Home" OnClick="Button8_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
            <p>
                Upload a file: <asp:FileUpload ID="FileUpload1" runat="server" />
        </p>
            <p>
                &nbsp;</p>
            <p>
                Reciept list:
                <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        </div>
    </form>
</body>
</html>
