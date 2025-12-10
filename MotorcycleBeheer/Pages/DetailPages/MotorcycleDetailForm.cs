using MRL.Desktop.Services;
using MRL.Shared.Contracts;

namespace MRL.Desktop.Pages.DetailPages
{
    public partial class MotorcycleDetailForm : Form
    {
        private readonly BrandService _brandService;
        private readonly CategoryService _categoryService;

        private readonly MotorcycleDTO OriginalItem;
        public MotorcycleDTO CurrentItem;

        public bool IsChanged
        {
            get
            {
                return !CurrentItem.Equals(OriginalItem);
            }
        }

        public MotorcycleDetailForm(MotorcycleDTO Motorcycle, BrandService brandService, CategoryService categoryService)
        {
            _brandService = brandService;
            _categoryService = categoryService;

            InitializeComponent();
            CurrentItem = Motorcycle ?? throw new ArgumentNullException(nameof(Motorcycle));
            OriginalItem = CurrentItem.Clone();

            saveButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;

            AcceptButton = saveButton;
            CancelButton = cancelButton;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _ = LoadBrands();
            _ = LoadCategories();

            // Load DTO into controls
            idValueLabel.Text = CurrentItem.Id.ToString();
            modelTextBox.Text = CurrentItem.Model;
            yearTextBox.Text = CurrentItem.Year.ToString();
            ccTextBox.Text = CurrentItem.EngineCc.ToString();
            powerTextBox.Text = CurrentItem.PowerHp.ToString();
        }

        private async Task LoadBrands()
        {
            brandComboBox.DisplayMember = "Name";
            brandComboBox.ValueMember = "Id";
            brandComboBox.DataSource = await _brandService.GetBrandsAsync();

            if (CurrentItem != null)
                brandComboBox.SelectedValue = CurrentItem.BrandId;

        }
        private async Task LoadCategories()
        {
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "Id";
            categoryComboBox.DataSource = await _categoryService.GetCategorysAsync();

            if (CurrentItem != null)
                categoryComboBox.SelectedValue = CurrentItem.CategoryId;
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Push values back into the DTO
            CurrentItem.BrandId = Convert.ToInt32(brandComboBox.SelectedValue);
            CurrentItem.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);

            var year = ParseInt(yearTextBox);
            var enginecc = ParseInt(ccTextBox);
            var power = ParseInt(powerTextBox);

            // Store individual scores
            CurrentItem.Model = modelTextBox.Text;
            CurrentItem.Year = (int)year;
            CurrentItem.EngineCc = (int)enginecc;
            CurrentItem.PowerHp = (int)power;
        }

        // Parse helper
        private static decimal ParseInt(TextBox tb)
        {
            return decimal.TryParse(tb.Text, out var value) ? value : 0; // or throw / show error
        }
    }
}
