using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using System.Text.Json;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCriarReceita : Form
    {
        private ServicoReceita _servicoReceita;
        private ServicoIngrediente _servicoIngrediente;
        private FiltroIngrediente _filtroIngrediente = new FiltroIngrediente();
        public FormCriarReceita(
            ServicoReceita servicoReceita,
            ServicoIngrediente servicoIngrediente
            )
        {
            _servicoReceita = servicoReceita;
            _servicoIngrediente = servicoIngrediente;

            InitializeComponent();
        }

        private void FormCriarReceita_Load(object sender, EventArgs e)
        {
            CarregarDadosIngrediente();
        }

        private void AoClicarFaharForms(object sender, EventArgs e)
        {
            Close();
        }

        private void AoClicarSalvarCriacaoReceita(object sender, EventArgs e)
        {
            Receita receita = new Receita();
            try
            {
                receita.ListaDeIngredientes = ObterListaDeIngredientesSelecionados();
                receita.Nome = textBox_Nome.Text;
                receita.Descricao = richTextBox_Descricao.Text;
                receita.Valor = Decimal.Parse(textBox_Valor.Text);
                receita.ValidadeEmMeses = Int32.Parse(textBox_Validade.Text);
                receita.Imagem = "Caminho/da/imagem";

                _servicoReceita.CriarReceita(receita);
                MessageBox.Show("Ingrediente Criado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarDadosIngrediente()
        {
            try
            {
                dataGridView1.DataSource = _servicoIngrediente.ObterTodos(_filtroIngrediente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível obter elementos de Ingrediente ERRO: {ex.Message}",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
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
