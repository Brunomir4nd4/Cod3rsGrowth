using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagem : Form
    {
        private ServicoIngrediente _servicoIngrediente;
        private ServicoReceita _servicoReceita;
        private ServicoPocao _servicoPocao;
        private FiltroIngrediente _filtroIngrediente = new FiltroIngrediente();
        private FiltroReceita _filtroReceita = new FiltroReceita();
        private FiltroPocao _filtroPocao = new FiltroPocao();
        public FormListagem(
            ServicoIngrediente servicoIngrediente,
            ServicoReceita servicoReceita,
            ServicoPocao servicoPocao
            )
        {
            InitializeComponent();

            _servicoIngrediente = servicoIngrediente;
            _servicoReceita = servicoReceita;
            _servicoPocao = servicoPocao;
        }

        private void FormListagem_Load(object sender, EventArgs e)
        {
            CarregarDadosIngrediente(_filtroIngrediente);
            CarregarDadosReceita(_filtroReceita);
            CarregarDadosPocao(_filtroPocao);
            comboBox_Naturalidade_Ingrediente.DataSource = Enum.GetValues(typeof(Naturalidade));
        }

        private void AoClicarBotaoFiltrarReceita(object sender, EventArgs e)
        {
            CarregarDadosReceita(ObterFiltroReceita());
        }
        private void AoClicarBotaoFiltrarIngrediente(object sender, EventArgs e)
        {
            CarregarDadosIngrediente(ObterFiltroIngrediente());
        }
        private void AoClicarBotaoFiltrarPocao(object sender, EventArgs e)
        {
            CarregarDadosPocao(ObterFiltroPocao());
        }

        private void AoClicarAbrirFormCriarIngrediente(object sender, EventArgs e)
        {
            var formCriarIngrediente = new FormCriarIngrediente(_servicoIngrediente);
            formCriarIngrediente.ShowDialog();
            CarregarDadosIngrediente(_filtroIngrediente);
        }

        private void AoClicarAbrirFormModificaReceita(object sender, EventArgs e)
        {
            var formModificaReceita = new FormModificaReceita(_servicoReceita, _servicoIngrediente);
            formModificaReceita.InsereTituloCriar();
            formModificaReceita.ShowDialog();
            CarregarDadosReceita(_filtroReceita);
        }

        private void AoClicarAbrirFromsCriarPocao(object sender, EventArgs e)
        {
            var formCriarPocao = new FormCriarPocao(_servicoPocao, _servicoIngrediente);
            formCriarPocao.ShowDialog();
            CarregarDadosPocao(_filtroPocao);
        }

        public void CarregarDadosIngrediente(FiltroIngrediente filtroIngrediente)
        {
            try
            {
                dataGridView_Ingrediente.DataSource = _servicoIngrediente.ObterTodos(filtroIngrediente);
                comboBox_Naturalidade_Ingrediente.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível obter elementos de Ingrediente ERRO: {ex.Message}");
            }
        }

        private void CarregarDadosReceita(FiltroReceita filtroReceita)
        {
            try
            {
                dataGridView_Receita.DataSource = _servicoReceita.ObterTodos(filtroReceita);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível obter elementos de Receita ERRO: {ex.Message}");
            }
        }

        private void CarregarDadosPocao(FiltroPocao filtroPocao)
        {
            try
            {
                dataGridView_Pocao.DataSource = _servicoPocao.ObterTodos(filtroPocao);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível obter elementos de Pocao ERRO: {ex.Message}");
            }
        }

        private FiltroIngrediente ObterFiltroIngrediente()
        {
            FiltroIngrediente filtroIngrediente = new FiltroIngrediente();

            try
            {
                if (!textBox_Id_Ingrediente.Text.IsNullOrEmpty())
                {
                    filtroIngrediente.Id = Int32.Parse(textBox_Id_Ingrediente.Text);
                    textBox_Id_Ingrediente.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Id inserido não é valido! ERRO: {ex.Message}");
            }

            try
            {
                if (!textBox_Quantidade_Ingrediente.Text.IsNullOrEmpty())
                {
                    filtroIngrediente.Quantidade = Int32.Parse(textBox_Quantidade_Ingrediente.Text);
                    textBox_Quantidade_Ingrediente.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Quantidade inserido não é valido! ERRO: {ex.Message}");
            }

            try
            {
                if (!textBox_Nome_Ingrediente.Text.IsNullOrEmpty())
                {
                    filtroIngrediente.Nome = textBox_Nome_Ingrediente.Text;
                    textBox_Nome_Ingrediente.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Nome inserido não é valido! ERRO: {ex.Message}");
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(comboBox_Naturalidade_Ingrediente.Text))
                {
                    var valorInteiroDoEnum = comboBox_Naturalidade_Ingrediente.SelectedIndex;

                    filtroIngrediente.Naturalidade = (Naturalidade)valorInteiroDoEnum;

                    comboBox_Naturalidade_Ingrediente.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Naturalidade inserido não é valido! ERRO: {ex.Message}");
            }

            return filtroIngrediente;
        }

        private FiltroReceita ObterFiltroReceita()
        {
            FiltroReceita filtroReceita = new FiltroReceita();

            try
            {
                if (!textBox_Id_Receita.Text.IsNullOrEmpty())
                {
                    filtroReceita.Id = Int32.Parse(textBox_Id_Receita.Text);
                    textBox_Id_Receita.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Id inserido não é valido! ERRO: {ex.Message}");
            }

            try
            {
                if (!textBox_Nome_Receita.Text.IsNullOrEmpty())
                {
                    filtroReceita.Nome = textBox_Nome_Receita.Text;
                    textBox_Nome_Receita.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Nome inserido não é valido! ERRO: {ex.Message}");
            }

            try
            {
                if (!textBox_Valor_Receita.Text.IsNullOrEmpty())
                {
                    filtroReceita.Valor = Decimal.Parse(textBox_Valor_Receita.Text);
                    textBox_Valor_Receita.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Valor inserido não é valido! ERRO: {ex.Message}");
            }

            try
            {
                if (!textBox_Validade_Receita.Text.IsNullOrEmpty())
                {
                    filtroReceita.ValidadeEmMeses = Int32.Parse(textBox_Validade_Receita.Text);
                    textBox_Validade_Receita.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Validade inserido não é valido! ERRO: {ex.Message}");
            }

            return filtroReceita;
        }

        private FiltroPocao ObterFiltroPocao()
        {
            FiltroPocao filtroPocao = new FiltroPocao();

            try
            {
                if (!textBox_Id_Pocao.Text.IsNullOrEmpty())
                {
                    filtroPocao.Id = Int32.Parse(textBox_Id_Pocao.Text);
                    textBox_Id_Pocao.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Id inserido não é valido! ERRO: {ex.Message}");
            }

            try
            {
                if (!textBox_Nome_Pocao.Text.IsNullOrEmpty())
                {
                    filtroPocao.Nome = textBox_Nome_Pocao.Text;
                    textBox_Nome_Pocao.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Nome inserido não é valido! ERRO: {ex.Message}");
            }

            try
            {
                if (!maskedTextBox_Data_Pocao.Text.IsNullOrEmpty() & maskedTextBox_Data_Pocao.Text != "  /  /")
                {
                    filtroPocao.DataDeFabricacao = DateTime.Parse(maskedTextBox_Data_Pocao.Text);
                    maskedTextBox_Data_Pocao.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Data inserido não é valido! ERRO: {ex.Message}");
            }

            try
            {
                if (!comboBox_Vencido_Pocao.Text.IsNullOrEmpty())
                {
                    filtroPocao.Vencido = comboBox_Vencido_Pocao.Text == "Vencido"
                        ?
                        true
                        :
                        false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Campo Vencido inserido não é valido! ERRO: {ex.Message}");
            }

            return filtroPocao;
        }
    }
}

