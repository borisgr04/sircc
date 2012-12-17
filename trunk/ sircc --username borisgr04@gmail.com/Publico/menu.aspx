<%@ Page Language="VB" AutoEventWireup="false" CodeFile="menu.aspx.vb" Inherits="Publico_menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <style type="text/css">
        li 
        { 
            border:1px solid black; 
            padding:20px 20px 20px 20px; 
            width:110px; 
            background-color:Gray; 
            color:White; 
            cursor:pointer;
        }
        a { color:White; font-family:Tahoma; }
    </style>

    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.4.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("ul.level1 li").hover(function () {
                $(this).stop().animate({ opacity: 0.7, width: "170px" }, "slow");
            }, function () {
                $(this).stop().animate({ opacity: 1, width: "110px" }, "slow");
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" />

    <br />
    <hr />
    <div id="menu">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" RenderingMode="List">            
            <Items>
                <asp:MenuItem NavigateUrl="~/Default.aspx" ImageUrl="~/images/2012/derecha.png" 
                    Text="Home" Value="Home"  />
                <asp:MenuItem NavigateUrl="~/About.aspx" 
                    ImageUrl="~/images/2012/document-excel-icon.png" Text="About Us" 
                    Value="AboutUs" />
                <asp:MenuItem NavigateUrl="~/Products.aspx"  ImageUrl="~/Images/Box.png" Text="Products" Value="Products" />
                <asp:MenuItem NavigateUrl="~/Contact.aspx" ImageUrl="~/Images/Chat.png" Text="Contact Us" Value="ContactUs" />
            </Items>
        </asp:Menu>
    </div>

         <div>
       <ul id="ulMenu">
             <li><a href="#">Microsoft</a>
                 <ul>
                     <li><a href="#">MVA</a></li>
                    <li><a href="#">MSDN</a></li>
                     <li><a href="#">Technet</a></li>
                 </ul>
             </li>
            <li><a href="#">Redes Sociales</a>
                <ul>
                    <li><a href="#">Facebook</a></li>
                    <li><a href="#">Twitter</a></li>
                    <li><a href="#">LinkedIn</a></li>
                </ul>
            </li>
        </ul>
   </div>
    <hr /> </form>
</body>
</html>
