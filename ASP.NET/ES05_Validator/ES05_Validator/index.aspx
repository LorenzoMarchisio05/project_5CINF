<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ES05_Validator.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="Required Validator"></asp:Label>
            <asp:TextBox ID="txtRequired" runat="server"></asp:TextBox>
            
            <br />

            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1"
                runat="server"
                ErrorMessage="RequiredFieldValidator"
                ControlToValidate="txtRequired"
                Display="Dynamic">

            </asp:RequiredFieldValidator>

            <hr />

            <asp:Label ID="Label2" runat="server" Text="Range Validator"></asp:Label>
            <asp:TextBox ID="txtRange" runat="server"></asp:TextBox>

            <asp:RangeValidator
                ID="RangeValidator1"
                runat="server" 
                ErrorMessage="RangeValidator"
                ControlToValidate="txtRange"
                MinimumValue="1"
                MaximumValue="100"
                Type="Integer">

            </asp:RangeValidator>
            <br />

            <hr />

            <asp:Button ID="btnSubmit" Text="Send" runat="server" />
        </div>
    </form>
</body>
</html>
