using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagemIngrediente : Form
    {
        private ServicoIngrediente _servicoIngrediente;

        public FormListagemIngrediente(ServicoIngrediente servicoIngrediente)
        {
            _servicoIngrediente = servicoIngrediente;
            InitializeComponent();
            GetData();
        }

        private void FormListagemIngrediente_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void GetData()
        {
            FiltroIngrediente filtroIngrediente = new FiltroIngrediente();

            dataGridView1.DataSource = _servicoIngrediente.ObterTodos(filtroIngrediente);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void painel_de_filtragem_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}