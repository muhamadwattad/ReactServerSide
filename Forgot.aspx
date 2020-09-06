<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="ReactProject_ServerSide.Forgot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Password"></asp:Label>
        </div>
            <p>
                <asp:TextBox ID="password" runat="server"></asp:TextBox>
        </p>
    <p>
            <asp:Label ID="Label2" runat="server" Text="Repeat Password"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="rptpassword" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" style="height: 26px" />
    </form>
    </body>
</html>
