<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BancaDelTempo.Client.login1" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <h1>
        Benvenuto nella Banca del tempo 5C inf
    </h1>
</asp:Content>

<asp:Content ID="links" ContentPlaceHolderID="links" runat="server">
    <asp:HyperLink ID="RegisterLink" runat="server" NavigateUrl="~/register.aspx">Registrati</asp:HyperLink>
</asp:Content>

<asp:Content ID="main" ContentPlaceHolderID="main" runat="server">
    <div>
        <asp:Label ID="lblEmail" Text="Email:" runat="server" AssociatedControlID="txtEmail" CssClass="form-label"/>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="lblPassword" Text="Password:" runat="server" AssociatedControlID="txtPassword" CssClass="form-label"/>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
            
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
        <br />

        <asp:Label ID="lblMessaggio" Text="" runat="server"/>
        <br />
    </div>
</asp:Content>
