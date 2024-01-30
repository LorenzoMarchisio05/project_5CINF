<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BancaDelTempo.Client.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                Benvenuto nella Banca del tempo 5C inf
            </h1>
            <asp:Label ID="lblEmail" Text="Email:" runat="server" AssociatedControlID="txtEmail"/>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            <br />

            <asp:Label ID="lblPassword" Text="Password:" runat="server" AssociatedControlID="txtPassword"/>
            <br />
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />

            <asp:Label ID="lblMessaggio" Text="" runat="server"/>
            <br />

            <asp:HyperLink ID="RegisterLink" runat="server" NavigateUrl="~/register.aspx">Registrati</asp:HyperLink>
        </div>
    </form>
</body>
</html>
