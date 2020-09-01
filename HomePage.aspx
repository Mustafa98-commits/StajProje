<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GeregindenAsiriFazlaUltraSuperMukemmelProje.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 80px;
        }
        .auto-style2 {
            margin-left: 600px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div aria-dropeffect="none" class="auto-style1">
            <div>
                <asp:Label ID="ahaha" runat="server"></asp:Label>
            </div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Marka"></asp:Label>
                <asp:DropDownList ID="listMarka" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listMarka_SelectedIndexChanged" Width="150px"></asp:DropDownList>
                <asp:Label ID="modelLabel" runat="server" Text="Model"></asp:Label>
                <asp:DropDownList ID="ListModel" runat="server" Width="150px"></asp:DropDownList>
                <asp:Label ID="Label3" runat="server" Text="Sikayet"></asp:Label>
                <asp:DropDownList ID="ListSikayet" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ListSikayet_SelectedIndexChanged"></asp:DropDownList>
                <asp:Label ID="labelSikayet" runat="server" Text="Ek Sikayet" Visible="False"></asp:Label>
                <asp:TextBox ID="txtSikayetPlus" runat="server" Visible="False"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Yorum"></asp:Label>
                
                <asp:TextBox ID="txtYorum" runat="server" Height="100px" Width="100px"></asp:TextBox>
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Sikayet EKLE" />
            </div>

            <br />
            <asp:HiddenField ID="gizliii" Value="" runat="server" />
                <div>
                    <asp:Label ID="labele1" runat="server" Text="Beklenenler"></asp:Label>
                    
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    
                    <asp:Label ID="labele2" runat="server" Text="Bitirilenler"></asp:Label>
               </div>
            <div>
                    <asp:ListBox ID="listGonderilen" runat="server" Height="245px" Width="212px"></asp:ListBox>
                 <asp:ListBox ID="listYapilan" runat="server" Height="245px" Width="212px"></asp:ListBox>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" OnClick="Button3_Click" Text="Getirsene" />
            </div>
          
            <asp:Label ID="sonucLAR" runat="server" Text="Label" Visible="False"></asp:Label>
       <div class="auto-style2">
            <asp:Button ID="Button2" runat="server" Text="Ana Sayfa" OnClick="Button2_Click" />
       </div>
            
            <br />
            <br />
        </div>
    </form>
</body>
</html>
