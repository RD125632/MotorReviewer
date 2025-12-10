using MRL.Desktop.Services;
using MRL.Shared.Contracts;

namespace MRL.Desktop.Pages.DetailPages
{
    public partial class ReviewDetailForm : Form
    {
        private readonly MotorcycleService _motorcycleService;
        private readonly UserService _userService;

        private readonly ReviewDTO OriginalItem;
        public ReviewDTO CurrentItem;

        public bool IsChanged
        {
            get
            {
                return !CurrentItem.Equals(OriginalItem);
            }
        }

        public ReviewDetailForm(ReviewDTO Review, MotorcycleService motorcycleService, UserService userService)
        {
            _motorcycleService = motorcycleService;
            _userService = userService;

            InitializeComponent();
            CurrentItem = Review ?? throw new ArgumentNullException(nameof(Review));
            OriginalItem = CurrentItem.Clone();

            saveButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;

            AcceptButton = saveButton;
            CancelButton = cancelButton;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _ = LoadMotorcycles();
            _ = LoadUsers();

            // Load DTO into controls
            idValueLabel.Text = CurrentItem.Id.ToString();
            dateTimePicker.Value = DateTime.Now;

            handlingTextBox.Text = CurrentItem.HandlingScore.ToString();
            EngineTextBox.Text = CurrentItem.EngineScore.ToString();
            comfortTextBox.Text = CurrentItem.ComfortScore.ToString();
            brakesTextBox.Text = CurrentItem.BrakesScore.ToString();
            stabilityTextBox.Text = CurrentItem.StabilityScore.ToString();
            valueTextBox.Text = CurrentItem.ValueScore.ToString();
            overallLabel.Text = "Overall: " + CurrentItem.OverallScore;
            commentRich.Text = CurrentItem.Comment;
        }

        private async Task LoadMotorcycles()
        {
            motorcycleComboBox.DisplayMember = "Model";
            motorcycleComboBox.ValueMember = "Id";
            motorcycleComboBox.DataSource = await _motorcycleService.GetMotorcyclesAsync();

            if (CurrentItem != null)
                motorcycleComboBox.SelectedValue = CurrentItem.MotorcycleId;
        }

        private async Task LoadUsers()
        {
            userComboBox.DisplayMember = "Name";
            userComboBox.ValueMember = "Id";
            userComboBox.DataSource = await _userService.GetUsersAsync();

            if (CurrentItem != null)
                userComboBox.SelectedValue = CurrentItem.UserId;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Push values back into the DTO
            CurrentItem.MotorcycleId = Convert.ToInt32(motorcycleComboBox.SelectedValue);
            CurrentItem.UserId = Convert.ToInt32(userComboBox.SelectedValue);
            CurrentItem.ReviewDate = dateTimePicker.Value;

            // Parse all scores once
            var handling = ParseScore(handlingTextBox);
            var Engine = ParseScore(EngineTextBox);
            var comfort = ParseScore(comfortTextBox);
            var brakes = ParseScore(brakesTextBox);
            var stability = ParseScore(stabilityTextBox);
            var value = ParseScore(valueTextBox);

            // Store individual scores
            CurrentItem.HandlingScore = handling;
            CurrentItem.EngineScore = Engine;
            CurrentItem.ComfortScore = comfort;
            CurrentItem.BrakesScore = brakes;
            CurrentItem.StabilityScore = stability;
            CurrentItem.ValueScore = value;

            // Calculate average based on other scores
            var allScores = new[] { handling, Engine, comfort, brakes, stability, value };
            CurrentItem.OverallScore = allScores.Average();

            CurrentItem.Comment = commentRich.Text;
        }


        // Parse helper
        private static decimal ParseScore(TextBox tb)
        {
            return decimal.TryParse(tb.Text, out var value) ? value : 0; // or throw / show error
        }
    }
}
