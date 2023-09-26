<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ES03_ViewStateCookieSession.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pagina Partenza</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnViewState" Text="ViewState" runat="server" OnClick="btnViewState_Click" />

            <asp:Button ID="btnCookie" Text="Cookie" runat="server" OnClick="btnCookie_Click"/>

            <asp:Button ID="btnSession" Text="Session" runat="server" OnClick="btnSession_Click" />

            <br />
            <hr />
            <br />

            <asp:Button ID="btnVediOggetti" Text="Vedi oggetti" runat="server" OnClick="btnVediOggetti_Click" />
            
            <br />

            <asp:HyperLink ID="link_index1" NavigateUrl="~/index1.aspx" runat="server" >
                Apri Pagina Destinazione
            </asp:HyperLink>

        </div>
    </form>
</body>
</html>
