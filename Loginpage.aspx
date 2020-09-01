<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="GeregindenAsiriFazlaUltraSuperMukemmelProje.Loginpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <%-- <link rel="stylesheet" href="./style.css"/>--%>

</head>
<body>
    <form id="form1" runat="server">
        <div class="form">
            <h1>LOGIN PAGE</h1>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registerpage.aspx">Register now</asp:HyperLink>
            <br />
            <br />
            <label for="txtUserName" id="ah" class="label-name">Email</label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            

            
  
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="password" ></asp:Label>

            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
        </div>
    </form>
</body>
</html>
