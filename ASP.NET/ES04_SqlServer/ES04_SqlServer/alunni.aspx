<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alunni.aspx.cs" Inherits="ES04_SqlServer.Alunni" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Alunni</h1>
            <asp:DropDownList 
                ID="cmbAlunni" 
                runat="server" 
                AutoPostBack="true" 
                OnSelectedIndexChanged="cmbAlunni_SelectedIndexChanged">

            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
