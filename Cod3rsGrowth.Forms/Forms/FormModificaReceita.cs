using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormModificaReceita : Form
    {
        private ServicoReceita _servicoReceita;
        private ServicoIngrediente _servicoIngrediente;
        private ServicoReceitaIngrediente _servicoReceitaIngrediente;
        private FiltroIngrediente _filtroIngrediente = new FiltroIngrediente();
        private FiltroReceita _filtroReceita = new FiltroReceita();
        public FormModificaReceita(
            ServicoReceita servicoReceita,
            ServicoIngrediente servicoIngrediente,
            ServicoReceitaIngrediente servicoReceitaIngrediente
            )
        {
            _servicoReceita = servicoReceita;
            _servicoIngrediente = servicoIngrediente;
            _servicoReceitaIngrediente = servicoReceitaIngrediente;

            InitializeComponent();
        }

        private void FormModificaReceita_Load(object sender, EventArgs e)
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
                receita.Nome = textBox_Nome.Text;
                receita.Descricao = richTextBox_Descricao.Text;
                receita.Valor = Decimal.Parse(textBox_Valor.Text);
                receita.ValidadeEmMeses = Int32.Parse(textBox_Validade.Text);
                receita.Imagem = "Caminho/da/imagem";
                receita.ListaIdIngrediente = ObterListaIdIngredientesSelecionados();


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

        private List<int> ObterListaIdIngredientesSelecionados()
        {
            List<int> listaDeIdIngrediente = new List<int>();
            int indexChack = 1, indexNome = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[indexChack];
                if (chk.Value != null)
                {
                    var ingrediente = _servicoIngrediente.ObterTodos(_filtroIngrediente).First(i
                        => i.Nome == row.Cells[indexNome].Value.ToString());

                    listaDeIdIngrediente.Add(ingrediente.Id);
                }
            }
            return listaDeIdIngrediente;
        }

        public void InsereTituloCriar()
        {
            label_Titulo.Text = "Criação da Receita";
        }
    }
}
