<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ES04_SqlServer.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink NavigateUrl="alunni.aspx" runat="server" >Alunni</asp:HyperLink>
            <asp:HyperLink NavigateUrl="materie.aspx" runat="server" >Materie</asp:HyperLink>
            <asp:HyperLink NavigateUrl="voti.aspx" runat="server" >Voti</asp:HyperLink>
        </div>
    </form>
</body>
</html>
