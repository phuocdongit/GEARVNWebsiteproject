<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backup_Restore.aspx.cs" Inherits="WEB_Project.BACKUP_RESTORE.Backup_Restore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <title>Backup and Restore</title>




    <script type="text/javascript">
        function showFilePicker() {
            var fileInput = document.createElement('input');
            fileInput.type = 'file';
            fileInput.accept = '.bak';
            fileInput.addEventListener('change', function () {
                var fileName = fileInput.value;
                // Lấy đường dẫn thực sự của file nếu có thể
                var fullPath = fileName;
                if (fileInput.files && fileInput.files.length > 0) {
                    fullPath = fileInput.files[0].path || fileInput.files[0].name;
                }

                // Hiển thị đường dẫn thực sự trong ô text box
                document.getElementById('<%=txtRestore.ClientID %>').value = fullPath;
        });
            fileInput.click();
        }
        function refreshPage() {
            location.href = location.href; // true forces a reload from the server, bypassing the cache
        }

        function goBack() {
            window.location.href = '/admin/home';
        }
    </script>

    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        .container {
            max-width: 600px;
            margin: auto;
        }

        h2 {
            text-align: center;
        }

        form {
            display: flex;
            flex-direction: column;
        }

        label {
            margin-bottom: 8px;
        }

        input {
            margin-bottom: 20px;
            padding: 8px;
        }

        button {
            background-color: #4CAF50;
            color: white;
            padding: 10px;
            border: none;
            cursor: pointer;
        }

            button:hover {
                background-color: #45a049;
            }
    </style>
</head>
<body>
    <div class="container"">
        <h2>Sao lưu và Phục hồi</h2>
        <%-- <label for="backup"><strong>Lưu ý:</strong><i>Vì chính sách bảo mật nên tập tin sao lưu sẽ mặc định ở ổ đĩa D (D:\)</i> </label>--%>
    
        <br />
        <br />
        <br />
        <form id="backupRestoreForm" runat="server" style="border:solid 2px #808080; padding:20px">
            <label for="backup"><strong>Sao lưu dữ liệu hệ thống của GEARVN: Vui lòng nhấn chọn "Sao lưu"</strong></label><br />
           

            <div class="row">
            </div>
            <asp:Button ID="btnBackUp" runat="server" Text="Sao lưu" BackColor="#66CCFF" Font-Bold="True" Font-Size="15px" OnClick="btnBackUp_Click" />
            <br />
            <br />
            <br />
            <label for="restore"><strong>Chọn file phục hồi:</strong><i> (Những file đã sao lưu ở ổ đĩa D trước đó)</i></label>
            <div>
                <asp:TextBox Style="width: 430px" ID="txtRestore" runat="server" autocomplete="fale"></asp:TextBox>
                <asp:HiddenField ID="hiddenFilePath" runat="server" />
                <asp:Button Style="border: solid 2px #000000; border-radius: 5px; margin-left: 10px; width: 90px; background-color: orangered; color: white" ID="btnUpFile" runat="server" Text="File" Font-Bold="True" OnClientClick="showFilePicker(); return false;" />
            </div>
            <br />
            <asp:Button ID="btnRestore" runat="server" Text="Phục hồi" BackColor="#66CCFF" Font-Bold="True" Font-Size="15px" OnClick="btnRestore_Click" />
        </form>
        <br />
        <br />
    
    <button style="float:right;width:100px;border:solid 2px #000000; border-radius:5px; background-color:#ff4848" onclick="goBack()">Back</button>
             <button style="float:right; margin-right:10px;width:100px;border:solid 2px #000000; border-radius:5px;" onclick="refreshPage()">Refresh</button>
    </div>

</body>
</html>
