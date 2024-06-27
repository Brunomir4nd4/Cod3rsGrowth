using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormModificaReceita : Form
    {
        private ServicoReceita _servicoReceita;
        private ServicoIngrediente _servicoIngrediente;
        private FiltroIngrediente _filtroIngrediente = new FiltroIngrediente();
        public FormModificaReceita(
            ServicoReceita servicoReceita,
            ServicoIngrediente servicoIngrediente
            )
        {
            _servicoReceita = servicoReceita;
            _servicoIngrediente = servicoIngrediente;

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


                MessageBox.Show(
                    "Receita Criada com sucesso!", 
                    "SECCESS!", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"ERRO: {ex.Message}", 
                    "ERROR!", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
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
            const int indexCheck = 1, indexNome = 0;
            var listaDeIdIngrediente = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells[indexCheck].Value != null)
                .Select(row =>
                {
                    var nome = row.Cells[indexNome].Value.ToString();
                    return _servicoIngrediente
                        .ObterTodos(_filtroIngrediente)
                        .First(i => i.Nome == nome)
                        .Id;
                })
                .ToList();

            return listaDeIdIngrediente;
        }

        public void InsereTituloCriar()
        {
            label_Titulo.Text = "Criação da Receita";
        }
    }
}
