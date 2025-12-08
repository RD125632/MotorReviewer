using MRL.Shared.Contracts;

namespace MRL.Desktop.Pages.DetailPages
{
    public partial class CategoryDetailForm : Form
    {
        private readonly CategoryDTO OriginalItem;
        public CategoryDTO CurrentItem;

        public bool IsChanged
        {
            get
            {
                return !CurrentItem.Equals(OriginalItem);
            }
        }

        public CategoryDetailForm(CategoryDTO Category)
        {
            InitializeComponent();
            CurrentItem = Category ?? throw new ArgumentNullException(nameof(Category));
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
