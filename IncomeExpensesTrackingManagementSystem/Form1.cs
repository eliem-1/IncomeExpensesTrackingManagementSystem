namespace IncomeExpensesTrackingManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Added to match designer-generated event wiring that references a lowercase 'close' method
        private void close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Call dotnet clean
            System.Diagnostics.Process.Start("dotnet", "clean");

            // Call dotnet build
            System.Diagnostics.Process.Start("dotnet", "build");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
