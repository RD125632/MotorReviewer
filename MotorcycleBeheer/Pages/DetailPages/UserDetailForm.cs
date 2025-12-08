using MRL.Shared.Contracts;

namespace MRL.Desktop.Pages.DetailPages
{
    public partial class UserDetailForm : Form
    {
        private readonly UserDTO OriginalItem;
        public UserDTO CurrentItem;

        public bool IsChanged
        {
            get
            {
                return !CurrentItem.Equals(OriginalItem);
            }
        }

        public UserDetailForm(UserDTO user)
        {
            InitializeComponent();
            CurrentItem = user ?? throw new ArgumentNullException(nameof(user));
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
            experienceLevelTextBox.Text = CurrentItem.ExperienceLevel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Push values back into the DTO
            CurrentItem.Name = nameTextBox.Text;
            CurrentItem.ExperienceLevel = experienceLevelTextBox.Text;
        }
    }
}
