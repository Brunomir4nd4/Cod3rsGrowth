using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormModificaReceita : Form
    {
        private ServicoReceita _servicoReceita;
        private ServicoIngrediente _servicoIngrediente;
        private List<int> _LISTA_ID_INGREDIENTE = new List<int>();
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

        private void AoClicarSalvarCriacao(object sender, EventArgs e)
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

                _servicoReceita.Criar(receita);


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
        
        private void AoClicarSalvarEdicao(object sender, EventArgs e, int id)
        {
            var receita = _servicoReceita.ObterPorId(id);

            receita.Nome = textBox_Nome.Text;
            receita.Descricao = richTextBox_Descricao.Text;
            receita.Valor = Decimal.Parse(textBox_Valor.Text);
            receita.ValidadeEmMeses = Int32.Parse(textBox_Validade.Text);
            receita.ListaIdIngrediente = ObterListaIdIngredientesSelecionados();

            _servicoReceita.Editar(receita);
            MessageBox.Show(
                $"Receita atualizado com sucesso!",
                "SUCCESS!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            Close();
        }

        private void CarregarDadosIngrediente()
        {
            try
            {
                dataGridView1.DataSource = _servicoIngrediente.ObterTodos();
                InserirIngredientesDaReceitaAoCheckList(_LISTA_ID_INGREDIENTE);
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
            const bool CheckBoxDesmaracado = false;
            var listaDeIdIngrediente = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Where(row => Convert.ToBoolean(row.Cells[indexCheck].Value) != CheckBoxDesmaracado)
                .Select(row =>
                {
                    var nome = row.Cells[indexNome].Value.ToString();
                    return _servicoIngrediente
                        .ObterTodos()
                        .First(i => i.Nome == nome)
                        .Id;
                })
                .ToList();

            return listaDeIdIngrediente;
        }

        private void InserirIngredientesDaReceitaAoCheckList(List<int> listaIdIngrediente)
        {
            const int indexNome = 0, indexCheck = 1;
            const bool checkBoxMarcado = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var nome = row.Cells[indexNome].Value.ToString();

                if (listaIdIngrediente.Any(id => _servicoIngrediente.ObterPorId(id).Nome == nome))
                {
                    row.Cells[indexCheck].Value = checkBoxMarcado;
                }
            }
        }

        public void InserirCabecalhoDeCriacao()
        {
            label_Titulo.Text = "Criação da Receita";
        }

        public void InserirValoresTextoParaEdicao(int id)
        {
            var receita = _servicoReceita.ObterPorId(id);

            label_Titulo.Text = "  Edição da Receita";
            textBox_Nome.Text = receita.Nome;
            richTextBox_Descricao.Text = receita.Descricao;
            textBox_Valor.Text = receita.Valor.ToString();
            textBox_Validade.Text = receita.ValidadeEmMeses.ToString();
            _LISTA_ID_INGREDIENTE = receita.ListaIdIngrediente;
        }
        public void AddEventoClickCriar()
        {
            button_Salvar.Click += (sender, e) => AoClicarSalvarCriacao(sender, e);
        }
        public void AddEventoClickEditar(int id)
        {
            button_Salvar.Click += (sender, e) => AoClicarSalvarEdicao(sender, e, id);
        }
    }
}
