using MRL.Desktop.Pages.DetailPages;
using MRL.Desktop.Services;
using MRL.Shared.Contracts;
using System.ComponentModel;

namespace MRL.Desktop.Pages
{
    public partial class ReviewListPage : UserControl
    {
        private readonly ReviewService _viewService;
        private readonly MotorcycleService _motorcycleService;
        private readonly UserService _userService;

        private List<MotorcycleDTO> motorcycleDTOs = [];
        private List<UserDTO> userDTOs = [];

        private readonly BindingList<ReviewDTO> _bindingList = [];

        public ReviewListPage(
                ReviewService viewService,
                MotorcycleService motorcycleService,
                UserService userService)
        {
            InitializeComponent();

            _viewService = viewService;
            _motorcycleService = motorcycleService;
            _userService = userService;

            dataGridView.AutoGenerateColumns = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Id",
                Width = 60,
                ReadOnly = true
            });

            // FK -> MotorcycleId
            var motorcycleColumn = new DataGridViewComboBoxColumn
            {
                Name = "MotorcycleColumn",
                DataPropertyName = "MotorcycleId",   // <- property on ReviewDto
                HeaderText = "Motorcycle",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            };
            dataGridView.Columns.Add(motorcycleColumn);

            // FK -> UserId
            var userColumn = new DataGridViewComboBoxColumn
            {
                Name = "UserColumn",
                DataPropertyName = "UserId",        // <- property on ReviewDto
                HeaderText = "User",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            };
            dataGridView.Columns.Add(userColumn);

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReviewDate",
                HeaderText = "Date",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HandlingScore",
                HeaderText = "Handling",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SpeedScore",
                HeaderText = "Speed",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ComfortScore",
                HeaderText = "Comfort",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BrakesScore",
                HeaderText = "Brakes",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StabilityScore",
                HeaderText = "Stability",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValueScore",
                HeaderText = "Value",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OverallScore",
                HeaderText = "Overall",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Comment",
                HeaderText = "Comment",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // EDIT button column
            var editColumn = new DataGridViewImageColumn
            {
                Name = "EditColumn",
                HeaderText = "",
                Image = Properties.Resources.edit,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 24,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightSteelBlue }
            };
            dataGridView.Columns.Add(editColumn);

            // DELETE button column
            var deleteColumn = new DataGridViewImageColumn
            {
                Name = "DeleteColumn",
                HeaderText = "",
                Image = Properties.Resources.delete,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 24,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.MistyRose }
            };
            dataGridView.Columns.Add(deleteColumn);

            dataGridView.CellContentClick += DataGridView_CellContentClick;
            dataGridView.DataSource = _bindingList;

            // single async load handler
            Load += ReviewListPage_LoadAsync;
        }

        private async void ReviewListPage_LoadAsync(object? sender, EventArgs e)
        {
            motorcycleDTOs = await _motorcycleService.GetMotorcyclesAsync();
            userDTOs = await _userService.GetUsersAsync();

            // Motorcycle column
            if (dataGridView.Columns["MotorcycleColumn"] is not DataGridViewComboBoxColumn motorcycleColumn)
                throw new InvalidOperationException("MotorcycleColumn not found or wrong type.");

            motorcycleColumn.DataSource = motorcycleDTOs;
            motorcycleColumn.ValueMember = "Id";
            motorcycleColumn.DisplayMember = "Name";

            // User column
            if (dataGridView.Columns["UserColumn"] is not DataGridViewComboBoxColumn userColumn)
                throw new InvalidOperationException("UserColumn not found or wrong type.");

            userColumn.DataSource = userDTOs;
            userColumn.ValueMember = "Id";
            userColumn.DisplayMember = "Name";

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            _bindingList.Clear();
            var data = await _viewService.GetReviewsAsync();  // returns List<ReviewDto>
            foreach (var b in data)
                _bindingList.Add(b);
        }

        private async void DataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = (DataGridView)sender!;

            // Get the ReviewDto for this row
            if (grid.Rows[e.RowIndex].DataBoundItem is not ReviewDTO Review)
                return;

            string colName = dataGridView.Columns[e.ColumnIndex].Name;

            if (colName == "EditColumn")
            {
                await EditReviewAsync(Review);
            }
            else if (colName == "DeleteColumn")
            {
                await DeleteReviewAsync(Review);
            }
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            // New DTO for the form to fill in
            await AddReviewAsync(new ReviewDTO());
        }


        private async Task AddReviewAsync(ReviewDTO newReview)
        {
            using var detailForm = new ReviewDetailForm(newReview, _motorcycleService, _userService);
            detailForm.Text = "Add Review";

            if (detailForm.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                var created = await _viewService.CreateReviewAsync(newReview);
                if (created != null)
                {
                    _bindingList.Add(created);   // BindingList automatically updates the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add Review:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EditReviewAsync(ReviewDTO selectedItem)
        {
            using var detailForm = new ReviewDetailForm(selectedItem, _motorcycleService, _userService);
            detailForm.Text = "Edit Review";

            if (detailForm.ShowDialog(this) != DialogResult.OK)
                return;

            if (detailForm.IsChanged)
            {
                // Something changed
                try
                {
                    await _viewService.UpdateReviewAsync(selectedItem); // PUT to API
                    dataGridView.Refresh(); // refresh grid display
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Review:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task DeleteReviewAsync(ReviewDTO selectedItem)
        {
            if (MessageBox.Show($"Delete Review '{selectedItem.Id}'?",
                                "Confirm", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                await _viewService.DeleteReviewAsync(selectedItem.Id);
                _bindingList.Remove(selectedItem); // BindingList<ReviewDto> _Reviews
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete Review:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
