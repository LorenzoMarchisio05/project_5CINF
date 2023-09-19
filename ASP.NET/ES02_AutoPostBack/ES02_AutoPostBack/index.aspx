<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ES02_AutoPostBack.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:CheckBox ID="chkAutoPostBack" Text="AutoPostBack" runat="server" OnCheckedChanged="chkAutoPostBack_CheckedChanged" />
            <hr />
            <asp:DropDownList ID="cmbColori" runat="server" OnSelectedIndexChanged="cmbColori_SelectedIndexChanged"></asp:DropDownList>
            <hr />
            <asp:Panel ID="pnlColore" Height="65px" Width="130px" runat="server"></asp:Panel>
            <hr />
            <asp:Button ID="btnInvia" runat="server" Text="Invia" />
        </div>
    </form>
</body>
</html>
