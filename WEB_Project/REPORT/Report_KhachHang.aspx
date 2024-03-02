<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_KhachHang.aspx.cs" Inherits="WEB_Project.REPORT.Report_KhachHang" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .container {
            display: flex;
            justify-content: space-between; /* Các phần tử ở hai đầu cùng của container */
            align-items: center; /* Căn giữa theo chiều dọc */
            padding: 10px; /* Khoảng cách xung quanh */
        }

        .left-section {
            order: 1; /* Đặt vị trí hiển thị của .left-section ở đầu tiên */
        }

        .right-section {
            order: 2; /* Đặt vị trí hiển thị của .right-section ở thứ hai */
            margin-left: 10px; /* Tạo khoảng cách bên trái của .right-section */
        }

        .my-button {
            background-color: #00CCFF;
            font-weight: bold;
            height: 40px;
            width: 118px;
            margin-right:300px;
        }

        .my-dropdown {
            width: 150px; 
            height: 40px;
        }

        .my-table {
       /*     height: 680px;
            width: 877px;
            border-color: black;
            border-style: solid;
            border-width: 1px;*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button class="my-button" style="border:solid 2px; border-radius:9px;" ID="btnBackKH" runat="server" Text="Quay lại" OnClick="btnBackKH_Click" Font-Bold="True" Font-Size="15px" />
           <asp:Label runat="server" ClientIDMode="AutoID" Font-Bold="True" Font-Names="Arial"> Sắp xếp:</asp:Label>
                <asp:DropDownList class="my-dropdown" style="border:solid 1px; border-radius:5px;" ID="ddlEast" runat="server"  Font-Bold="True" Height="37px" Width="192px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" AutoPostBack="true" Font-Names="Arial" Font-Size="15px">
              
                <asp:ListItem style="height: 30px;" Value="1" Selected="True">Mặc định</asp:ListItem>
                <asp:ListItem style="height: 30px;" Value="2">Mua hàng nhiều nhất</asp:ListItem>
            </asp:DropDownList>
            
        </div>
        <br />
        <div >
            
        </div>
        <br />
        <div  align="center">
            <asp:ScriptManager ID="Scrip2" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportKhachHang" runat="server" Height="571px" Width="940px" BorderStyle="Solid" BorderWidth="1px"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
