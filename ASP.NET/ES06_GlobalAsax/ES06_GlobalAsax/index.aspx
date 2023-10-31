<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ES06_GlobalAsax.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblContaVisite" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="lblConteggioUtenti" runat="server" Text="Label"></asp:Label>
            
            <br />
            <br />

            <asp:Button ID="btnLogout" Text="Logout" runat="server" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
