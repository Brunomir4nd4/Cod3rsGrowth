using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagemReceita : Form
    {
        private ServicoReceita _servicoReceita;
        public FormListagemReceita(ServicoReceita servicoReceita)
        {
            _servicoReceita = servicoReceita;
            InitializeComponent();
            GetData();
        }

        private void FormListagemReceita_Load(object sender, EventArgs e)
        {

        }

        public void GetData()
        {
            FiltroReceita filtroReceita = new FiltroReceita();

            dataGridView1.DataSource = _servicoReceita.ObterTodos(filtroReceita);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
