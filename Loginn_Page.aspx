<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginn_Page.aspx.cs" Inherits="Login_Page_Creation.Loginn_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
     <link href="bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        
    </style>
    <script>>
    function validate() {
        let email = document.getElementById("txtEmail").value;
        let pwd = document.getElementById("txtPwd").value;

        if (email.trim().length == 0) {
            document.getElementById("lblMsg").innerHTML = "Enter Email id";
            return false;
        }
        if (pwd.trim().length == 0) {
            document.getElementById("lblMsg").innerHTML = "Enter Password";
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <center> <div style="width:50%;border:solid thin blue; ">
            <br />
            <div><center><h1 style="text-align:center">Login Page</h1></center></div>
            <hr /><br />
            <div style="text-align:center">WelCome:
                <asp:Label ID="lblUser" runat="server" Text="" CssClass="form-Control"></asp:Label>
            </div>
            <br /><br />
            <div style="text-align:center">
                Username:
                <asp:TextBox ID="txtName1" runat="server" cssClass="form-Control" Width="335px"></asp:TextBox>
            </div>
            <br /><br />
            <div style="text-align:center">
                Password:
                <asp:TextBox ID="txtPwd" runat="server" CssClass="form-Control" Width="327px"></asp:TextBox>
            </div>
            <br /><br />
            <div style="text-align:center">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="202px" OnClientClick="return validate()" />
            </div><br />
            <br />
            <div style="text-align:center" >
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <br />
        </div></center>
    </form>
</body>
</html>
