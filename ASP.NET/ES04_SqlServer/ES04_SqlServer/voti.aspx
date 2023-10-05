<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="voti.aspx.cs" Inherits="ES04_SqlServer.voti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Voti</h1>
            <asp:Label ID="lblNominativo" runat="server"></asp:Label>
            <asp:GridView ID="dgvVoti" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
