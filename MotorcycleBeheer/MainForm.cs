using MRL.Desktop.Pages;
using MRL.Desktop.Pages.ListPages;
using MRL.Desktop.Services;
using System.Runtime.InteropServices;

namespace MotorcycleBeheer
{
    public partial class MainForm : Form
    {
        private readonly MotorcycleService _motorcycleService;
        private readonly BrandService _brandService;
        private readonly ReviewService _reviewService;
        private readonly UserService _userService;
        private readonly CategoryService _categoryService;

        private const string BaseURL = "https://localhost:44324/";

        public MainForm()
        {
            InitializeComponent();

            this.MinimumSize = new Size(1600, 900);

            // Example: dark title bar + white text + green borders
            int borderColor = ColorTranslator.ToWin32(Color.FromArgb(40, 40, 40));
            int captionColor = ColorTranslator.ToWin32(Color.FromArgb(30, 30, 30));
            int textColor = ColorTranslator.ToWin32(Color.White);

            _ = DwmSetWindowAttribute(Handle, DWMWA_BORDER_COLOR, ref borderColor, sizeof(int));
            _ = DwmSetWindowAttribute(Handle, DWMWA_CAPTION_COLOR, ref captionColor, sizeof(int));
            _ = DwmSetWindowAttribute(Handle, DWMWA_TEXT_COLOR, ref textColor, sizeof(int));

            // Base URL of your API
            _motorcycleService = new MotorcycleService(BaseURL);
            _brandService = new BrandService(BaseURL);
            _reviewService = new ReviewService(BaseURL);
            _userService = new UserService(BaseURL);
            _categoryService = new CategoryService(BaseURL);

            // Setup navigation buttons
            brandsMenuButton.Click += (s, e) => ShowPage(new BrandListPage(_brandService));
            motorcyclesMenuButton.Click += (s, e) => ShowPage(new MotorcycleListPage(_motorcycleService));
            reviewsMenuButton.Click += (s, e) => ShowPage(new ReviewListPage(_reviewService, _motorcycleService, _userService));
            userMenuButton.Click += (s, e) => ShowPage(new UserListPage(_userService));
            categoryMenuButton.Click += (s, e) => ShowPage(new CategoryListPage(_categoryService));

            // Show default page
            ShowPage(new MotorcycleListPage(_motorcycleService));
        }

        private void ShowPage(UserControl page)
        {
            contentPanel.SuspendLayout();

            contentPanel.Controls.Clear();
            page.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(page);

            contentPanel.ResumeLayout();
        }

        private void CloseAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_BORDER_COLOR = 34;
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;
    }
}
