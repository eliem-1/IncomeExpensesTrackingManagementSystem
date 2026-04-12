namespace IncomeExpensesTrackingManagementSystem
{
    public partial class CategoryForm : UserControl
    {
        private readonly CategoryData _categoryData = new();
        private int _selectedCategoryId;
        private int _currentUserId;

        public CategoryForm()
        {
            InitializeComponent();
            category_dataGridView.CellClick += CategoryDataGridView_CellClick;
        }

        public void SetUserId(int userId)
        {
            _currentUserId = userId;
        }

        public void LoadCategories()
        {
            try
            {
                List<CategoryData> categories = _categoryData.GetCategoryList(_currentUserId);
                DisplayCategoryList(categories);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCategoryList(List<CategoryData> categories)
        {
            category_dataGridView.DataSource = categories;
        }

        private void ClearFields()
        {
            category_name.Clear();
            category_type.SelectedIndex = -1;
            category_status.SelectedIndex = -1;
            _selectedCategoryId = 0;
        }

        private void CategoryAddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(category_name.Text) || category_type.SelectedIndex == -1 || category_status.SelectedIndex == -1)
            {
                MessageBox.Show(AppConstants.FillAllFieldsError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string categoryName = category_name.Text.Trim();
                    string categoryType = category_type.SelectedItem?.ToString() ?? string.Empty;
                    string categoryStatus = category_status.SelectedItem?.ToString() ?? string.Empty;

                    if (_categoryData.AddCategory(_currentUserId, categoryName, categoryType, categoryStatus))
                    {
                        MessageBox.Show(AppConstants.CategoryAddedSuccessfully, AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields();
                        LoadCategories();
                    }
                    else
                    {
                        MessageBox.Show(AppConstants.CategoryAddFailedError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CategoryUpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(category_name.Text) || category_type.SelectedIndex == -1 || category_status.SelectedIndex == -1)
            {
                MessageBox.Show(AppConstants.SelectCategoryError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show(AppConstants.ConfirmUpdateCategory, AppConstants.ConfirmationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string categoryName = category_name.Text.Trim();
                        string categoryType = category_type.SelectedItem?.ToString() ?? string.Empty;
                        string categoryStatus = category_status.SelectedItem?.ToString() ?? string.Empty;

                        if (_categoryData.UpdateCategory(_currentUserId, _selectedCategoryId, categoryName, categoryType, categoryStatus))
                        {
                            MessageBox.Show(AppConstants.CategoryUpdatedSuccessfully, AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearFields();
                            LoadCategories();
                        }
                        else
                        {
                            MessageBox.Show(AppConstants.CategoryUpdateFailedError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CategoryClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void CategoryRefreshBtn_Click(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void CategoryDeleteBtn_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId > 0)
            {
                if (MessageBox.Show(AppConstants.ConfirmDeleteCategory, AppConstants.ConfirmationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    if (_categoryData.DeleteCategory(_currentUserId, _selectedCategoryId))
                    {
                        MessageBox.Show(AppConstants.CategoryDeletedSuccessfully, AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadCategories();
                    }
                    else
                    {
                        MessageBox.Show(AppConstants.CategoryDeleteFailedError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(AppConstants.SelectCategoryToDeleteError, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoryDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = category_dataGridView.Rows[e.RowIndex];

                if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    _selectedCategoryId = Convert.ToInt32(row.Cells[0].Value);
                    category_name.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                    category_type.SelectedItem = row.Cells[2].Value?.ToString() ?? string.Empty;
                    category_status.SelectedItem = row.Cells[3].Value?.ToString() ?? string.Empty;
                }
            }
        }

        private void CategoryTypeSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
