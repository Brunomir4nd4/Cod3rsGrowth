using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCriarPocao : Form
    {
        private ServicoPocao _servicoPocao;
        private ServicoIngrediente _servicoIngrediente;
        private FiltroPocao _filtroPocao = new FiltroPocao();
        private FiltroIngrediente _filtroIngrediente = new FiltroIngrediente();
        public FormCriarPocao(ServicoPocao servicoPocao, ServicoIngrediente servicoIngrediente)
        {
            InitializeComponent();

            _servicoIngrediente = servicoIngrediente;
            _servicoPocao = servicoPocao;
        }
        private void FormCriarPocao_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void AoClicarSlavarCriacaoPocao(object sender, EventArgs e)
        {
            try
            {
                _servicoPocao.CriarPocao(ObterListaDeIngredientesSelecionados());
                MessageBox.Show("Poção Criada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            dataGridView1.DataSource = _servicoIngrediente.ObterTodos(_filtroIngrediente);
        }

        private void AoClicarFecharForms(object sender, EventArgs e)
        {
            Close();
        }

        private List<Ingrediente> ObterListaDeIngredientesSelecionados()
        {
            List<Ingrediente> listaIngrediente = new List<Ingrediente>();
            int indexChack = 1, indexNome = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[indexChack];
                if (chk.Value != null)
                {
                    var ingrediente = _servicoIngrediente.ObterTodos(_filtroIngrediente).First(i
                        => i.Nome == row.Cells[indexNome].Value.ToString());

                    listaIngrediente.Add(ingrediente);
                }
            }
            return listaIngrediente;
        }
    }
}
