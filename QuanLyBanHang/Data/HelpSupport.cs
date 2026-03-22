// HelpSupport.cs – Cung cấp HelpProvider cho tất cả các form
// Theo hướng dẫn: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-provide-help-in-a-windows-application

namespace QuanLyBanHang.Data
{
    /// <summary>
    /// Lớp tĩnh chứa HelpProvider dùng chung cho toàn ứng dụng.
    /// Mỗi form gọi HelpSupport.DangKy(this) trong constructor để được
    /// tích hợp phím F1 → mở trang HTML hướng dẫn.
    /// </summary>
    public static class HelpSupport
    {
        private static HelpProvider _provider;

        static HelpSupport()
        {
            _provider = new HelpProvider();

            // Tìm file Help\index.html
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string helpFile = Path.Combine(exeDir, "Help", "index.html");
            if (!File.Exists(helpFile))
            {
                string projectDir = exeDir
                    .TrimEnd(Path.DirectorySeparatorChar)
                    .Replace(@"bin\Debug\net8.0-windows", "")
                    .Replace(@"bin\Release\net8.0-windows", "");
                helpFile = Path.Combine(projectDir, "Help", "index.html");
            }

            // HelpNamespace trỏ đến file HTML
            if (File.Exists(helpFile))
                _provider.HelpNamespace = helpFile;
            else
                _provider.HelpNamespace = "https://fit.agu.edu.vn";
        }

        /// <summary>
        /// Đăng ký form với HelpProvider.
        /// Sau khi gọi, nhấn F1 trên form sẽ mở trang hướng dẫn.
        /// </summary>
        public static void DangKy(Form frm)
        {
            _provider.SetHelpNavigator(frm, HelpNavigator.TableOfContents);
            _provider.SetShowHelp(frm, true);

            // Cũng xử lý sự kiện HelpRequested để mở trình duyệt
            frm.HelpRequested += (s, e) =>
            {
                e.Handled = true;
                frmMain.MoTrangHuongDan();
            };

            // Phím F1 trên KeyDown cũng mở hướng dẫn
            frm.KeyPreview = true;
            frm.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F1)
                {
                    e.Handled = true;
                    frmMain.MoTrangHuongDan();
                }
            };
        }
    }
}
