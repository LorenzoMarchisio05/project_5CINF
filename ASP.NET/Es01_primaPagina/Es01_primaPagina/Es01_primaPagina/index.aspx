<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Es01_primaPagina.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lblTagASPNET" runat="server" Text="Tag ASPNET"></asp:Label>
            <asp:TextBox ID="txtASPNET" runat="server" placeholder="sono un tag aspnet"></asp:TextBox>
            <br />
            <hr />
            <br />
            <%-- Noi non useremo mai i tag HTML (salvo casi particolari) --%>
            <span id="lblTagHTML">Tag HTML</span>
            <input id="txtHTML" name="txtHTML" type="text" placeholder="sono un tag HTML"/>
            <br />
            <hr />
            <br />
            <asp:Button ID="btnLeggiASPNET" runat="server" Text="Leggi ASPNET" OnClick="btnLeggiASPNET_Click" />
            <asp:Label ID="lblLettoASPNET" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnLeggiHTML" runat="server" Text="Leggi HTML" OnClick="btnLeggiHTML_Click" />
            <asp:Label ID="lblLettoHTML" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>

</html>
