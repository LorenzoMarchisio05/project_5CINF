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
            <h1>Elenco Alunni</h1>
            <asp:DropDownList 
                ID="cmbAlunni" 
                runat="server" 
                AutoPostBack="true" 
                OnSelectedIndexChanged="cmbAlunni_SelectedIndexChanged">
            </asp:DropDownList>

            <h1>Elenco Alunni GridView</h1>
             <asp:GridView ID="dgvAlunni" runat="server" AutoGenerateColumns="False" CellPadding="5" OnRowCommand="dgvAlunni_RowCommand" DataKeyNames="idAlunno">
                <Columns>
                    <asp:BoundField DataField="idAlunno" HeaderText="Id Alunno" Visible="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="nome" HeaderText="Nome">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="cognome" HeaderText="Cognome">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:ButtonField ButtonType="Button" HeaderText="Dettagli" Text="Vedi Dettaglio" CommandName="mostraDettagli" />

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
