using MRL.Shared.Contracts;

namespace MRL.Desktop.Pages.DetailPages
{
    public partial class BrandDetailForm : Form
    {
        private readonly BrandDTO OriginalItem;
        public BrandDTO CurrentItem;

        public bool IsChanged
        {
            get
            {
                return !CurrentItem.Equals(OriginalItem);
            }
        }

        public BrandDetailForm(BrandDTO brand)
        {
            InitializeComponent();
            CurrentItem = brand ?? throw new ArgumentNullException(nameof(brand));
            OriginalItem = CurrentItem.Clone();

            saveButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;

            AcceptButton = saveButton;
            CancelButton = cancelButton;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Load DTO into controls
            idValueLabel.Text = CurrentItem.Id.ToString();
            nameTextBox.Text = CurrentItem.Name;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Push values back into the DTO
            CurrentItem.Name = nameTextBox.Text;
        }
    }
}
