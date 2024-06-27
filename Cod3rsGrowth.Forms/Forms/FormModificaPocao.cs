using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormModificaPocao : Form
    {
        private ServicoPocao _servicoPocao;
        private ServicoIngrediente _servicoIngrediente;
        private FiltroIngrediente _filtroIngrediente = new FiltroIngrediente();
        public FormModificaPocao(ServicoPocao servicoPocao, ServicoIngrediente servicoIngrediente)
        {
            InitializeComponent();

            _servicoIngrediente = servicoIngrediente;
            _servicoPocao = servicoPocao;
        }
        private void FormModificaPocao_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void AoClicarSalvarCriacaoPocao(object sender, EventArgs e)
        {
            try
            {
                _servicoPocao.CriarPocao(ObterListaDeIngredientesSelecionados());
                MessageBox.Show(
                    "Poção Criada com sucesso!", 
                    "SECCESS!", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            try
            {
                dataGridView1.DataSource = _servicoIngrediente.ObterTodos(_filtroIngrediente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível carregar os dados de Ingrediente ERRO: {ex.Message}",
                    "ERROR!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AoClicarFecharForms(object sender, EventArgs e)
        {
            Close();
        }

        private List<Ingrediente> ObterListaDeIngredientesSelecionados()
        {
            const int indexCheck = 1, indexNome = 0;
            var listaIngrediente = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells[indexCheck].Value != null)
                .Select(row =>
                {
                    var nome = row.Cells[indexNome].Value.ToString();
                    return _servicoIngrediente
                        .ObterTodos(_filtroIngrediente)
                        .First(i => i.Nome == nome);
                })
                .ToList();

            return listaIngrediente;
        }
    }
}
