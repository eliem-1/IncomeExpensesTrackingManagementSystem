namespace IncomeExpensesTrackingManagementSystem
{
    public class CategoryItem
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public CategoryItem(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
