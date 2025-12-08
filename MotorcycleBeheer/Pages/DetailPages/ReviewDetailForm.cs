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

            motorcycleComboBox.DataSource = _motorcycleService.GetMotorcyclesAsync();
            motorcycleComboBox.DisplayMember = "Name";
            motorcycleComboBox.ValueMember = "Id";
            motorcycleComboBox.SelectedValue = CurrentItem.MotorcycleId;

            userComboBox.DataSource = _userService.GetUsersAsync();
            userComboBox.DisplayMember = "Name";
            userComboBox.ValueMember = "Id";
            userComboBox.SelectedValue = CurrentItem.UserId;

            // Load DTO into controls
            idValueLabel.Text = CurrentItem.Id.ToString();
            dateTimePicker.Value = CurrentItem.ReviewDate;

            handlingTextBox.Text = CurrentItem.HandlingScore.ToString();
            speedTextBox.Text = CurrentItem.SpeedScore.ToString();
            comfortTextBox.Text = CurrentItem.ComfortScore.ToString();
            brakesTextBox.Text = CurrentItem.BrakesScore.ToString();
            stabilityTextBox.Text = CurrentItem.StabilityScore.ToString();
            valueTextBox.Text = CurrentItem.ValueScore.ToString();
            overallLabel.Text = "Overall: " + CurrentItem.OverallScore;
            commentRich.Text = CurrentItem.Comment;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Push values back into the DTO
            CurrentItem.MotorcycleId = Convert.ToInt32(motorcycleComboBox.SelectedValue);
            CurrentItem.UserId = Convert.ToInt32(userComboBox.SelectedValue);
            CurrentItem.ReviewDate = dateTimePicker.Value;

            // Parse all scores once
            var handling = ParseScore(handlingTextBox);
            var speed = ParseScore(speedTextBox);
            var comfort = ParseScore(comfortTextBox);
            var brakes = ParseScore(brakesTextBox);
            var stability = ParseScore(stabilityTextBox);
            var value = ParseScore(valueTextBox);

            // Store individual scores
            CurrentItem.HandlingScore = handling;
            CurrentItem.SpeedScore = speed;
            CurrentItem.ComfortScore = comfort;
            CurrentItem.BrakesScore = brakes;
            CurrentItem.StabilityScore = stability;
            CurrentItem.ValueScore = value;

            // Calculate average based on other scores
            var allScores = new[] { handling, speed, comfort, brakes, stability, value };
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
