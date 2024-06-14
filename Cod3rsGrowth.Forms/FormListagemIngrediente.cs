using Microsoft.Data.SqlClient;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Dominio.Entidades;
using System.Data.Common;
using System.Data;
using System.Globalization;
using System.Configuration;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagemIngrediente : Form
    {
        private ServicoIngrediente _servicoIngrediente;
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public FormListagemIngrediente(ServicoIngrediente servicoIngrediente)
        {
            _servicoIngrediente = servicoIngrediente;
            GetData();
            InitializeComponent();
        }

        private void FormListagemIngrediente_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void GetData()
        {
            try
            {
                FiltroIngrediente filtroIngrediente = new FiltroIngrediente();
                dataGridView1.DataSource = _servicoIngrediente.ObterTodos(filtroIngrediente);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
    }
}