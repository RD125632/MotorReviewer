using MRL.Desktop.Services;

namespace MRL.Desktop.Pages
{
    public partial class MotorcycleListPage : UserControl
    {
        private readonly MotorcycleService _motorcycleService;

        public MotorcycleListPage(MotorcycleService motorcycleService)
        {
            InitializeComponent();
            _motorcycleService = motorcycleService;

            // Load data when control is created
            this.Load += async (s, e) => await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var bikes = await _motorcycleService.GetMotorcyclesAsync();
                motorcycleListDataGridView.DataSource = bikes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load motorcycles.\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
