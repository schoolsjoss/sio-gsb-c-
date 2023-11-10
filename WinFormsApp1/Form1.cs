namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private DrugDataAcess dataAccess = new DrugDataAcess();
        public Form1()
        {
            InitializeComponent();
            updateDataGridView();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Drug drug = new Drug(this.textBox1.Text, this.textBox2.Text);
            //dataAccess.addDrug(drug);
            int result = dataAccess.addDrugToDB(drug);
            if (result == 0)
            {
                MessageBox.Show("Impossible d'ajouter le médicament");
            }
            else if (result > 0)
            {
                MessageBox.Show("Le médicament: " + this.textBox1.Text + " à bien été ajouté");
            }

            updateDataGridView();
        }

        public void updateDataGridView()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = dataAccess.getDrugListFromDB();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = this.dataGridView1.Rows[e.RowIndex];
                string name = selectedRow.Cells["Name"].Value.ToString();
                string description = selectedRow.Cells["Description"].Value.ToString();

                FormDetails formDetails = new FormDetails(name, description);
                formDetails.Show();


            }
        }
    }
}