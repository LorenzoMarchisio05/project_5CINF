<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Consumer.View.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Consumer says hello</h1>
            <asp:Label ID="lblClasse" runat="server" Text="Classe"></asp:Label>
            <asp:DropDownList ID="cmbClassi" runat="server"></asp:DropDownList>
            
            <hr />

            <asp:GridView ID="dgvAlunni" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
