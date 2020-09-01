<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registerpage.aspx.cs" Inherits="GeregindenAsiriFazlaUltraSuperMukemmelProje.Registerpage" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REGISTER PAGE</title>
    <script src="jquery-3.5.1.min.js"></script>
    
        <script>
            $(document).ready(function () {
                $('Button1').click(function () {
                    if ($('txtName').val().length === 0) {
                        alert('Enter your name!');
                    }
                })
            });
            
        </script>  
</head>
<body>
    
    <form id="form1" runat="server">
        <div id="con">
            <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" class="aa" runat="server"></asp:TextBox>
        </div>
        <br />
        <div id="con">
            <asp:Label ID="Label3" runat="server" Text="E-mail"></asp:Label>
            <asp:TextBox ID="txtEmail" class="aa" runat="server"></asp:TextBox>
        </div>
        <br />
        <div id="con">
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" class="aa" runat="server"></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="Button1" CssClass="sivas" runat="server" OnClick="Button1_Click" Text="Register" Style="width: 90px; height: 29px" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Geri Don" Style="width: 90px; height: 29px" />
        <br />
        
    </form>
    <script>
     $(document).ready(function () {
             $("#Button1").click(function () {
                 var str1 = $("#txtName").val();
                 var str2 = $("#txtEmail").val();
                 var str3 = $("#txtPassword").val();
                 if (str1 == "") {
                     alert("ad girsene");

                 } else if (str2 == "") {
                     alert("mail girsene")
                 }
                 else if (str3 == "sifre girsene ") {
                     alert("3");
                 }
                 else {
                     alert("hic");
                 }         
             });
     });

        $("")

     </script>
    
</body>
</html>
