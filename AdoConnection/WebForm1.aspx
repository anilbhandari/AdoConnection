<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AdoConnection.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
  

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> <asp:Button ID="Button1" runat="server" Text="Get employee" OnClick="Button1_Click" />


        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <div>

       <table style ="border:ridge 1px solid; background:repeat ">
           <tr>
               <td>
                   EmployeeName
               </td>
               <td>
                   <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
               </td>
           </tr>
            <tr>
               <td>
                   Gender
               </td>
               <td>
                   <asp:DropDownList ID="DropDownList1" runat="server">
                       <asp:ListItem>Select Gender</asp:ListItem>
                         <asp:ListItem>Maler</asp:ListItem>
                         <asp:ListItem>Female</asp:ListItem>
                   </asp:DropDownList>
               </td>
           </tr>
            <tr>
               <td>
                   Salary
               </td>
               <td>
                   <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
               </td>
           </tr>
          
           <tr>
               <td colspan="2">
                    <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" />
           
               </td>
             
           </tr>
           <tr>
               <td colspan="2">
                              <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

               </td>
           </tr>
            
             
         
        </table>
             
            </div>
    </form>
</body>
</html>
