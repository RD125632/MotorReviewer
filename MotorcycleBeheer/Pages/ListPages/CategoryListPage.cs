using MRL.Desktop.Pages.DetailPages;
using MRL.Desktop.Services;
using MRL.Shared.Contracts;
using System.ComponentModel;

namespace MRL.Desktop.Pages.ListPages
{
    public partial class CategoryListPage : UserControl
    {
        private readonly CategoryService _viewService;
        private readonly BindingList<CategoryDTO> _bindingList = [];

        public CategoryListPage(CategoryService viewService)
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
                HeaderText = "Category",
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
            var data = await _viewService.GetCategorysAsync();  // returns List<CategoryDto>
            foreach (var b in data)
                _bindingList.Add(b);
        }

        private async void DataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = (DataGridView)sender!;

            // Get the CategoryDto for this row
            if (grid.Rows[e.RowIndex].DataBoundItem is not CategoryDTO Category)
                return;

            string colName = dataGridView.Columns[e.ColumnIndex].Name;

            if (colName == "EditColumn")
            {
                await EditCategoryAsync(Category);
            }
            else if (colName == "DeleteColumn")
            {
                await DeleteCategoryAsync(Category);
            }
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            // New DTO for the form to fill in
            await AddCategoryAsync(new CategoryDTO());
        }


        private async Task AddCategoryAsync(CategoryDTO newCategory)
        {
            using var detailForm = new CategoryDetailForm(newCategory);
            detailForm.Text = "Add Category";

            if (detailForm.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                var created = await _viewService.CreateCategoryAsync(newCategory);
                if (created != null)
                {
                    _bindingList.Add(created);   // BindingList automatically updates the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add Category:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EditCategoryAsync(CategoryDTO selectedItem)
        {
            using var detailForm = new CategoryDetailForm(selectedItem);
            detailForm.Text = "Edit Category";

            if (detailForm.ShowDialog(this) != DialogResult.OK)
                return;

            if (detailForm.IsChanged)
            {
                // Something changed
                try
                {
                    await _viewService.UpdateCategoryAsync(selectedItem); // PUT to API
                    dataGridView.Refresh(); // refresh grid display
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Category:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task DeleteCategoryAsync(CategoryDTO selectedItem)
        {
            if (MessageBox.Show($"Delete Category '{selectedItem.Name}'?",
                                "Confirm", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                await _viewService.DeleteCategoryAsync(selectedItem.Id);
                _bindingList.Remove(selectedItem); // BindingList<CategoryDto> _Categorys
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete Category:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
