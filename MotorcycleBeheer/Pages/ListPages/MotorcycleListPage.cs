using MRL.Desktop.Pages.DetailPages;
using MRL.Desktop.Services;
using MRL.Shared.Contracts;
using System.ComponentModel;

namespace MRL.Desktop.Pages
{
    public partial class MotorcycleListPage : UserControl
    {
        private readonly MotorcycleService _viewService;
        private readonly BrandService _brandService;
        private readonly CategoryService _categoryService;

        private List<BrandDTO> brandDTOs = [];
        private List<CategoryDTO> categoryDTOs = [];

        private readonly BindingList<MotorcycleDTO> _bindingList = [];

        public MotorcycleListPage(
                MotorcycleService viewService,
                BrandService brandService,
                CategoryService categoryService)
        {
            InitializeComponent();

            _viewService = viewService;
            _brandService = brandService;
            _categoryService = categoryService;

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

            // FK -> BrandId
            var brandColumn = new DataGridViewComboBoxColumn
            {
                Name = "BrandColumn",
                DataPropertyName = "BrandId",   // <- property on MotorcycleDto
                HeaderText = "Brand",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            };
            dataGridView.Columns.Add(brandColumn);

            // FK -> CategoryId
            var categoryColumn = new DataGridViewComboBoxColumn
            {
                Name = "CategoryColumn",
                DataPropertyName = "CategoryId",        // <- property on MotorcycleDto
                HeaderText = "Category",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            };
            dataGridView.Columns.Add(categoryColumn);

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Model",
                HeaderText = "Model",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Year",
                HeaderText = "Year",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EngineCc",
                HeaderText = "EngineCc",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PowerHp",
                HeaderText = "PowerHp",
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
            Load += MotorcycleListPage_LoadAsync;
        }

        private async void MotorcycleListPage_LoadAsync(object? sender, EventArgs e)
        {
            brandDTOs = await _brandService.GetBrandsAsync();
            categoryDTOs = await _categoryService.GetCategorysAsync();

            // Motorcycle column
            if (dataGridView.Columns["BrandColumn"] is not DataGridViewComboBoxColumn brandColumn)
                throw new InvalidOperationException("BrandColumn not found or wrong type.");

            brandColumn.DataSource = brandDTOs;
            brandColumn.ValueMember = "Id";
            brandColumn.DisplayMember = "Name";

            // User column
            if (dataGridView.Columns["CategoryColumn"] is not DataGridViewComboBoxColumn categoryColumn)
                throw new InvalidOperationException("CategoryColumn not found or wrong type.");

            categoryColumn.DataSource = categoryDTOs;
            categoryColumn.ValueMember = "Id";
            categoryColumn.DisplayMember = "Name";

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            _bindingList.Clear();
            var data = await _viewService.GetMotorcyclesAsync();  // returns List<MotorcycleDto>
            foreach (var b in data)
                _bindingList.Add(b);
        }

        private async void DataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = (DataGridView)sender!;

            // Get the MotorcycleDto for this row
            if (grid.Rows[e.RowIndex].DataBoundItem is not MotorcycleDTO Motorcycle)
                return;

            string colName = dataGridView.Columns[e.ColumnIndex].Name;

            if (colName == "EditColumn")
            {
                await EditMotorcycleAsync(Motorcycle);
            }
            else if (colName == "DeleteColumn")
            {
                await DeleteMotorcycleAsync(Motorcycle);
            }
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            // New DTO for the form to fill in
            await AddMotorcycleAsync(new MotorcycleDTO());
        }


        private async Task AddMotorcycleAsync(MotorcycleDTO newMotorcycle)
        {
            using var detailForm = new MotorcycleDetailForm(newMotorcycle, _brandService, _categoryService);
            detailForm.Text = "Add Motorcycle";

            if (detailForm.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                var created = await _viewService.CreateMotorcycleAsync(newMotorcycle);
                if (created != null)
                {
                    _bindingList.Add(created);   // BindingList automatically updates the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add Motorcycle:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EditMotorcycleAsync(MotorcycleDTO selectedItem)
        {
            using var detailForm = new MotorcycleDetailForm(selectedItem, _brandService, _categoryService);
            detailForm.Text = "Edit Motorcycle";

            if (detailForm.ShowDialog(this) != DialogResult.OK)
                return;

            if (detailForm.IsChanged)
            {
                // Something changed
                try
                {
                    await _viewService.UpdateMotorcycleAsync(selectedItem); // PUT to API
                    dataGridView.Refresh(); // refresh grid display
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Motorcycle:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task DeleteMotorcycleAsync(MotorcycleDTO selectedItem)
        {
            if (MessageBox.Show($"Delete Motorcycle '{selectedItem.Id}'?",
                                "Confirm", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                await _viewService.DeleteMotorcycleAsync(selectedItem.Id);
                _bindingList.Remove(selectedItem); // BindingList<MotorcycleDto> _Motorcycles
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete Motorcycle:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
