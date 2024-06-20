using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.ConexaoBD;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagem : Form
    {
        private ServicoIngrediente _servicoIngrediente;
        private ServicoReceita _servicoReceita;
        private ServicoPocao _servicoPocao;
        private MeuContextoDeDados _db;
        private FiltroIngrediente _filtroIngrediente = new FiltroIngrediente();
        private FiltroReceita _filtroReceita = new FiltroReceita();
        private FiltroPocao _filtroPocao = new FiltroPocao();
        public FormListagem(
            ServicoIngrediente servicoIngrediente,
            ServicoReceita servicoReceita,
            ServicoPocao servicoPocao,
            MeuContextoDeDados db
            )
        {
            InitializeComponent();

            _db = db;
            _servicoIngrediente = servicoIngrediente;
            _servicoReceita = servicoReceita;
            _servicoPocao = servicoPocao;

            comboBox_Naturalidade_Ingrediente.DataSource = Enum.GetValues(typeof(Naturalidade));
            CarregarDadosIngrediente(_filtroIngrediente);
            CarregarDadosReceita(_filtroReceita);
            CarregarDadosPocao(_filtroPocao);
        }

        private void FormListagem_Load_1(object sender, EventArgs e)
        {
            comboBox_Naturalidade_Ingrediente.Text = "";
        }

        private void button_Filtrar_Receita_Click(object sender, EventArgs e)
        {
            CarregarDadosReceita(AoClicarBotaoFiltrarReceita());
        }
        private void button_Filtrar_Ingrediente_Click(object sender, EventArgs e)
        {
            CarregarDadosIngrediente(AoClicarBotaoFiltrarIngrediente());
        }
        private void button_Filtrar_Pocao_Click(object sender, EventArgs e)
        {
            CarregarDadosPocao(AoClicarBotaoFiltrarPocao());
        }

        private void CarregarDadosIngrediente(FiltroIngrediente filtroIngrediente)
        {
            try
            {
                dataGridView_Ingrediente.DataSource = _servicoIngrediente.ObterTodos(filtroIngrediente);
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
                var novaTabela = _servicoPocao.ObterTodos(filtroPocao);

                dataGridView_Pocao.DataSource = novaTabela.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível obter elementos de Pocao ERRO: {ex.Message}");
            }
        }

        private FiltroIngrediente AoClicarBotaoFiltrarIngrediente()
        {
            FiltroIngrediente filtroIngrediente = new FiltroIngrediente();

            if (!textBox_Id_Ingrediente.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroIngrediente.Id = Int32.Parse(textBox_Id_Ingrediente.Text);
                    textBox_Id_Ingrediente.Text = "";
                }
                catch
                {
                    MessageBox.Show("Campo Id inserido não é valido!");
                }
            }

            if (!textBox_Quantidade_Ingrediente.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroIngrediente.Quantidade = Int32.Parse(textBox_Quantidade_Ingrediente.Text);
                    textBox_Quantidade_Ingrediente.Text = "";
                }
                catch
                {
                    MessageBox.Show("Campo Quantidade inserido não é valido!");
                }
            }

            if (!textBox_Nome_Ingrediente.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroIngrediente.Nome = textBox_Nome_Ingrediente.Text;
                    textBox_Nome_Ingrediente.Text = "";
                }
                catch
                {
                    MessageBox.Show("Campo Nome inserido não é valido!");
                }
            }

            if (!comboBox_Naturalidade_Ingrediente.Text.IsNullOrEmpty())
            {
                try
                {
                    var valorInteiroDoEnum = comboBox_Naturalidade_Ingrediente.SelectedIndex;

                    filtroIngrediente.Naturalidade = (Naturalidade)valorInteiroDoEnum;

                    comboBox_Naturalidade_Ingrediente.Text = "";
                }
                catch
                {
                    MessageBox.Show("Campo Naturalidade inserido não é valido!");
                }
            }

            return filtroIngrediente;
        }

        private FiltroReceita AoClicarBotaoFiltrarReceita()
        {
            FiltroReceita filtroReceita = new FiltroReceita();

            if (!textBox_Id_Receita.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroReceita.Id = Int32.Parse(textBox_Id_Receita.Text);
                    textBox_Id_Receita.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Id inserido não é valido!");
                }
            }

            if (!textBox_Nome_Receita.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroReceita.Nome = textBox_Nome_Receita.Text;
                    textBox_Nome_Receita.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Nome inserido não é valido!");
                }
            }

            if (!textBox_Valor_Receita.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroReceita.Valor = Decimal.Parse(textBox_Valor_Receita.Text);
                    textBox_Valor_Receita.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Valor inserido não é valido!");
                }
            }

            if (!textBox_Validade_Receita.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroReceita.ValidadeEmMeses = Int32.Parse(textBox_Validade_Receita.Text);
                    textBox_Validade_Receita.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Validade inserido não é valido!");
                }
            }

            return filtroReceita;
        }

        private FiltroPocao AoClicarBotaoFiltrarPocao()
        {
            FiltroPocao filtroPocao = new FiltroPocao();

            if (!textBox_Id_Pocao.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroPocao.Id = Int32.Parse(textBox_Id_Pocao.Text);
                    textBox_Id_Pocao.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Id inserido não é valido!");
                }
            }

            if (!textBox_Nome_Pocao.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroPocao.Nome = textBox_Nome_Pocao.Text;
                    textBox_Nome_Pocao.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Nome inserido não é valido!");
                }
            }

            if (!maskedTextBox_Data_Pocao.Text.IsNullOrEmpty() & maskedTextBox_Data_Pocao.Text != "  /  /")
            {
                try
                {
                    filtroPocao.DataDeFabricacao = DateTime.Parse(maskedTextBox_Data_Pocao.Text);
                    maskedTextBox_Data_Pocao.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Data inserido não é valido!");
                }
            }

            if (!comboBox_Vencido_Pocao.Text.IsNullOrEmpty())
            {
                filtroPocao.Vencido = comboBox_Vencido_Pocao.Text == "Vencido"
                    ?
                    true
                    :
                    false;
            }

            return filtroPocao;
        }
    }
}
