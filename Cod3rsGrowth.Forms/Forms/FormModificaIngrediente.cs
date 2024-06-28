using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormModificaIngrediente : Form
    {
        private ServicoIngrediente _servicoIngrediente;
        private Naturalidade _NATURALIDADE;
        public FormModificaIngrediente(ServicoIngrediente servicoIngrediente)
        {
            InitializeComponent();
            _servicoIngrediente = servicoIngrediente;
        }

        private void AoClicarSalvarCriacao(object sender, EventArgs e)
        {
            try
            {
                var ingrediente = new Ingrediente();
                int valorInteiroDeNaturalidade = comboBox_Naturalidade.SelectedIndex;
                ingrediente.Nome = textBox_Nome.Text;
                ingrediente.Quantidade = Int32.Parse(textBox_Quantidade.Text);
                ingrediente.Naturalidade = (Naturalidade)valorInteiroDeNaturalidade;

                _servicoIngrediente.Criar(ingrediente);

                MessageBox.Show(
                    $"Ingrediente criado com sucesso!",
                    "SUCCESS!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao tentar criar, {ex.Message}",
                    "ERROR!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AoClicarSalvarEdicao(object sender, EventArgs e, int id)
        {
            var ingrediente = _servicoIngrediente.ObterPorId(id);
            int valorInteiroDeNaturalidade = comboBox_Naturalidade.SelectedIndex;

            ingrediente.Nome = textBox_Nome.Text;
            ingrediente.Quantidade = Int32.Parse(textBox_Quantidade.Text);
            ingrediente.Naturalidade = (Naturalidade)valorInteiroDeNaturalidade;

            _servicoIngrediente.Editar(ingrediente);
            MessageBox.Show(
                $"Ingrediente atualizado com sucesso!",
                "SUCCESS!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            Close();
        }

        private void FormModificaIngrediente_Load(object sender, EventArgs e)
        {
            CarregarDadosComboBox();
        }

        private void AoClicarFcharForms(object sender, EventArgs e)
        {
            Close();
        }

        private void CarregarDadosComboBox() 
        {
            try
            {
                comboBox_Naturalidade.DataSource = Enum.GetValues(typeof(Naturalidade));
                comboBox_Naturalidade.SelectedItem = _NATURALIDADE;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível carregar os dados de Naturalidade ERRO: {ex.Message}",
                    "ERROR!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public void InserirCabecalhoDeCriacao()
        {
            label_Cabecalho.Text = "Criação do Ingrediente";
        }
        public void InserirValoresTextoParaEdicao(int id)
        {
            var ingrediente = _servicoIngrediente.ObterPorId(id);

            label_Cabecalho.Text = "  Edição do Ingrediente";
            textBox_Nome.Text = ingrediente.Nome;
            textBox_Quantidade.Text = ingrediente.Quantidade.ToString();
            _NATURALIDADE = ingrediente.Naturalidade;
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
