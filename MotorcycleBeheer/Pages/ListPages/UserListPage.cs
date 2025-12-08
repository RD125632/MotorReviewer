using MRL.Desktop.Pages.DetailPages;
using MRL.Desktop.Services;
using MRL.Shared.Contracts;
using System.ComponentModel;

namespace MRL.Desktop.Pages.ListPages
{
    public partial class UserListPage : UserControl
    {
        private readonly UserService _viewService;
        private readonly BindingList<UserDTO> _bindingList = [];

        public UserListPage(UserService viewService)
        {
            InitializeComponent();
            _viewService = viewService;

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
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "User",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExperienceLevel",
                HeaderText = "Experience",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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
                DefaultCellStyle = new DataGridViewCellStyle() { BackColor = Color.LightSteelBlue }
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
                DefaultCellStyle = new DataGridViewCellStyle() { BackColor = Color.MistyRose }
            };
            dataGridView.Columns.Add(deleteColumn);

            // Wire up click handler
            dataGridView.CellContentClick += DataGridView_CellContentClick;
            dataGridView.DataSource = _bindingList;

            // Load data when control is created
            this.Load += async (_, __) => await LoadDataAsync();
        }
        private async Task LoadDataAsync()
        {
            _bindingList.Clear();
            var data = await _viewService.GetUsersAsync();  // returns List<UserDto>
            foreach (var b in data)
                _bindingList.Add(b);
        }

        private async void DataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = (DataGridView)sender!;

            // Get the UserDto for this row
            if (grid.Rows[e.RowIndex].DataBoundItem is not UserDTO user)
                return;

            string colName = dataGridView.Columns[e.ColumnIndex].Name;

            if (colName == "EditColumn")
            {
                await EditItemAsync(user);
            }
            else if (colName == "DeleteColumn")
            {
                await DeleteItemAsync(user);
            }
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            // New DTO for the form to fill in
            await AddUserAsync(new UserDTO());
        }


        private async Task AddUserAsync(UserDTO newUser)
        {
            using var detailForm = new UserDetailForm(newUser);
            detailForm.Text = "Add User";

            if (detailForm.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                var created = await _viewService.CreateUserAsync(newUser);
                if (created != null)
                {
                    _bindingList.Add(created);   // BindingList automatically updates the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add User:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EditItemAsync(UserDTO selectedItem)
        {
            using var detailForm = new UserDetailForm(selectedItem);
            detailForm.Text = "Edit User";

            if (detailForm.ShowDialog(this) != DialogResult.OK)
                return;

            if (detailForm.IsChanged)
            {
                // Something changed
                try
                {
                    await _viewService.UpdateUserAsync(selectedItem); // PUT to API
                    dataGridView.Refresh(); // refresh grid display
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update user:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task DeleteItemAsync(UserDTO selectedItem)
        {
            if (MessageBox.Show($"Delete user '{selectedItem.Name}'?",
                                "Confirm", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                await _viewService.DeleteUserAsync(selectedItem.Id);
                _bindingList.Remove(selectedItem); // BindingList<UserDto> _Users
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to user User:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
