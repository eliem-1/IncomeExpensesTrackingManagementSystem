using System.Data.SqlClient;

namespace IncomeExpensesTrackingManagementSystem
{
    public partial class CategoryForm : UserControl
    {
        private readonly CategoryData _categoryData = new();
        private int getId = 0;
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
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCategoryList(List<CategoryData> categories)
        {
            category_dataGridView.DataSource = categories;
        }

        private void clearFields()
        {
            category_name.Clear();
            category_type.SelectedIndex = -1;
            category_status.SelectedIndex = -1;
            getId = 0;
        }

        private void CategoryAddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(category_name.Text) || category_type.SelectedIndex == -1 || category_status.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Category added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        clearFields();
                        LoadCategories();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add category", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CategoryUpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(category_name.Text) || category_type.SelectedIndex == -1 || category_status.SelectedIndex == -1)
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Update ID: " + getId + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connect = new(DatabaseSetup.ConnectionString))
                        {
                            connect.Open();

                            string updateData = "UPDATE category SET cate_name = @cate_name, cate_type = @cate_type, cate_status = @cate_status WHERE cate_id = @cate_id AND user_id = @user_id";

                            using (SqlCommand cmd = new(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@cate_id", getId);
                                cmd.Parameters.AddWithValue("@user_id", _currentUserId);
                                cmd.Parameters.AddWithValue("@cate_name", category_name.Text.Trim());
                                cmd.Parameters.AddWithValue("@cate_type", category_type.SelectedItem);
                                cmd.Parameters.AddWithValue("@cate_status", category_status.SelectedItem);

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Updated successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
                            LoadCategories();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CategoryClearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void CategoryRefreshBtn_Click(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void CategoryDeleteBtn_Click(object sender, EventArgs e)
        {
            if (getId > 0)
            {
                try
                {
                    if (_categoryData.DeleteCategory(_currentUserId, getId))
                    {
                        MessageBox.Show("Category deleted successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                        LoadCategories();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete category", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoryDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = category_dataGridView.Rows[e.RowIndex];

                if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    getId = Convert.ToInt32(row.Cells[0].Value);
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
