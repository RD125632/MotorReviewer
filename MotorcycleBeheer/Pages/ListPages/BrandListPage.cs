using MRL.Desktop.Pages.DetailPages;
using MRL.Desktop.Services;
using MRL.Shared.Contracts;
using System.ComponentModel;

namespace MRL.Desktop.Pages
{
    public partial class BrandListPage : UserControl
    {
        private readonly BrandService _viewService;
        private readonly BindingList<BrandDTO> _bindingList = [];

        public BrandListPage(BrandService viewService)
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
                HeaderText = "Brand",
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
            var data = await _viewService.GetBrandsAsync();  // returns List<BrandDto>
            foreach (var b in data)
                _bindingList.Add(b);
        }

        private async void DataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = (DataGridView)sender!;

            // Get the BrandDto for this row
            if (grid.Rows[e.RowIndex].DataBoundItem is not BrandDTO brand)
                return;

            string colName = dataGridView.Columns[e.ColumnIndex].Name;

            if (colName == "EditColumn")
            {
                await EditBrandAsync(brand);
            }
            else if (colName == "DeleteColumn")
            {
                await DeleteBrandAsync(brand);
            }
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            // New DTO for the form to fill in
            await AddBrandAsync(new BrandDTO());
        }


        private async Task AddBrandAsync(BrandDTO newBrand)
        {
            using var detailForm = new BrandDetailForm(newBrand);
            detailForm.Text = "Add Brand";

            if (detailForm.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                var created = await _viewService.CreateBrandAsync(newBrand);
                if (created != null)
                {
                    _bindingList.Add(created);   // BindingList automatically updates the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add brand:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EditBrandAsync(BrandDTO selectedItem)
        {
            using var detailForm = new BrandDetailForm(selectedItem);
            detailForm.Text = "Edit Brand";

            if (detailForm.ShowDialog(this) != DialogResult.OK)
                return;

            if (detailForm.IsChanged)
            {
                // Something changed
                try
                {
                    await _viewService.UpdateBrandAsync(selectedItem); // PUT to API
                    dataGridView.Refresh(); // refresh grid display
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update brand:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task DeleteBrandAsync(BrandDTO selectedItem)
        {
            if (MessageBox.Show($"Delete brand '{selectedItem.Name}'?",
                                "Confirm", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                await _viewService.DeleteBrandAsync(selectedItem.Id);
                _bindingList.Remove(selectedItem); // BindingList<BrandDto> _brands
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete brand:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
