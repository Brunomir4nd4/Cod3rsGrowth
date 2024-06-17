using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagemPocao : Form
    {
        private ServicoPocao _servicoPocao;
        public FormListagemPocao(ServicoPocao servicoPocao)
        {
            _servicoPocao = servicoPocao;
            InitializeComponent();
            GetData();
        }

        private void FormListagemPocao_Load(object sender, EventArgs e)
        {

        }
        private void GetData()
        {
            FiltroPocao filtroPocao = new FiltroPocao();

            dataGridView1.DataSource = _servicoPocao.ObterTodos(filtroPocao);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
