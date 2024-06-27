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
            CarregarDadosComboBox();
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
            try
            {
                var formCriarIngrediente = new FormCriarIngrediente(_servicoIngrediente);
                formCriarIngrediente.ShowDialog();
                CarregarDadosIngrediente(_filtroIngrediente);
            }
            catch (Exception ex)
            {
                const string nomeForms = "FromModificaIngrediente";
                MenssagemDeErroModuloAbrirFormDeModificao(nomeForms, ex.Message);
            }
        }

        private void AoClicarAbrirFormModificaReceita(object sender, EventArgs e)
        {
            try
            {
                var formModificaReceita = new FormModificaReceita(_servicoReceita, _servicoIngrediente);
                formModificaReceita.InsereTituloCriar();
                formModificaReceita.ShowDialog();
                CarregarDadosReceita(_filtroReceita);
            }
            catch (Exception ex)
            {
                const string nomeForms = "FromModificaReceita";
                MenssagemDeErroModuloAbrirFormDeModificao(nomeForms, ex.Message);
            }
        }

        private void AoClicarAbrirFromsCriarPocao(object sender, EventArgs e)
        {
            try
            {
                var formCriarPocao = new FormCriarPocao(_servicoPocao, _servicoIngrediente);
                formCriarPocao.ShowDialog();
                CarregarDadosPocao(_filtroPocao);
                CarregarDadosIngrediente(_filtroIngrediente);
            }
            catch (Exception ex)
            {
                const string nomeForms = "FromModificaPocao";
                MenssagemDeErroModuloAbrirFormDeModificao(nomeForms, ex.Message);
            }
        }


        const int indexDaColunaNome = 1, indexDaColunaId = 0;
        private void AoClicarRemoverIngrediente(object sender, EventArgs e)
        {
            try
            {
                var nomeObjetoSelecionado = dataGridView_Ingrediente.CurrentCell != null
                    ? dataGridView_Ingrediente
                        .CurrentCell
                        .OwningRow
                        .Cells[indexDaColunaNome]
                        .Value
                        .ToString()
                    : throw new Exception("Você precissa selecionar uma linha para remover");

                if (MenssagemDeAlertaModuloRemover(nomeObjetoSelecionado) == DialogResult.Yes)
                {
                    int id = (int)dataGridView_Ingrediente
                        .CurrentCell
                        .OwningRow
                        .Cells[indexDaColunaId]
                        .Value;

                    _servicoIngrediente.RemoverIngredientes(id);
                    CarregarDadosIngrediente(_filtroIngrediente);
                    CarregarDadosReceita(_filtroReceita);
                    CarregarDadosPocao(_filtroPocao);
                }
            }
            catch (Exception ex)
            {
                MenssagemDeErroModuloRemover(ex.Message);
            }
        }

        private void AoClicarRemoverReceita(object sender, EventArgs e)
        {
            try
            {
                var nomeObjetoSelecionado = dataGridView_Receita.CurrentCell != null
                    ? dataGridView_Receita
                        .CurrentCell
                        .OwningRow
                        .Cells[indexDaColunaNome]
                        .Value
                        .ToString()
                    : throw new Exception("Você precissa selecionar uma linha para remover");

                if (MenssagemDeAlertaModuloRemover(nomeObjetoSelecionado) == DialogResult.Yes)
                {
                    int id = (int)dataGridView_Receita
                        .CurrentCell
                        .OwningRow
                        .Cells[indexDaColunaId]
                        .Value;

                    _servicoReceita.RemoverReceita(id);
                    CarregarDadosReceita(_filtroReceita);
                    CarregarDadosPocao(_filtroPocao);
                }
            }
            catch (Exception ex)
            {
                MenssagemDeErroModuloRemover(ex.Message);
            }
        }

        private void AoClicarRemoverPocao(object sender, EventArgs e)
        {
            try
            {
                var nomeObjetoSelecionado = dataGridView_Pocao.CurrentCell != null
                    ? dataGridView_Pocao
                        .CurrentCell
                        .OwningRow
                        .Cells[indexDaColunaNome]
                        .Value
                        .ToString()
                    : throw new Exception("Você precissa selecionar uma linha para remover");

                if (MenssagemDeAlertaModuloRemover(nomeObjetoSelecionado) == DialogResult.Yes)
                {
                    int id = (int)dataGridView_Pocao.CurrentCell.OwningRow.Cells[indexDaColunaId].Value;
                    _servicoReceita.RemoverReceita(id);
                    CarregarDadosReceita(_filtroReceita);
                    CarregarDadosPocao(_filtroPocao);
                }
            }
            catch (Exception ex)
            {
                MenssagemDeErroModuloRemover(ex.Message);
            }
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
                const string campo = "Ingrediente";
                MenssagemDeErroModuloCarregarDados(campo, ex.Message);
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
                const string campo = "Receita";
                MenssagemDeErroModuloCarregarDados(campo, ex.Message);
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
                const string campo = "Poção";
                MenssagemDeErroModuloCarregarDados(campo, ex.Message);
            }
        }

        private void CarregarDadosComboBox()
        {
            try
            {
                comboBox_Naturalidade_Ingrediente.DataSource = Enum.GetValues(typeof(Naturalidade));
            }
            catch (Exception ex)
            {
                const string campo = "Naturalidade";
                MenssagemDeErroModuloCarregarDados(campo, ex.Message);       
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
                const string campo = "Id";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
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
                const string campo = "Quantidade";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
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
                const string campo = "Nome";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
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
                const string campo = "Naturalidade";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
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
                const string campo = "Id";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
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
                const string campo = "Nome";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
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
                const string campo = "Valor";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
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
                const string campo = "Validade";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
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
                const string campo = "Id";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
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
                const string campo = "Nome";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
            }

            try
            {
                const string mascaraData = "  /  /";
                if (!maskedTextBox_Data_Pocao.Text.IsNullOrEmpty() & maskedTextBox_Data_Pocao.Text != mascaraData)
                {
                    filtroPocao.DataDeFabricacao = DateTime.Parse(maskedTextBox_Data_Pocao.Text);
                    maskedTextBox_Data_Pocao.Text = "";
                }
            }
            catch (Exception ex)
            {
                const string campo = "Data";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
            }

            try
            {
                const string stringEsperada = "Vencido";
                if (!comboBox_Vencido_Pocao.Text.IsNullOrEmpty())
                {
                    filtroPocao.Vencido = comboBox_Vencido_Pocao.Text == stringEsperada
                        ?
                        true
                        :
                        false;
                }
            }
            catch (Exception ex)
            {
                const string campo = "Vencido";
                MenssagemDeErroModuloFiltragem(campo, ex.Message);
            }

            return filtroPocao;
        }

        private void MenssagemDeErroModuloAbrirFormDeModificao(string nomeForms, string menssagem)
        {
            MessageBox.Show(
                $"Não foi possível obter {nomeForms} ERRO: {menssagem}",
                "ERROR!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
        }
        private void MenssagemDeErroModuloRemover(string menssagem)
        {
            MessageBox.Show(
                menssagem,
                "ERROR!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
        }
        private DialogResult MenssagemDeAlertaModuloRemover(string nomeObjetoSelecionado)
        {
            return MessageBox.Show(
                    $"Isso apagará todas as dependencias de " +
                    $"{nomeObjetoSelecionado},\nDeseja continuar?",
                    "WARNING!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
        }
        private void MenssagemDeErroModuloCarregarDados(string campo, string menssagem)
        {
            MessageBox.Show(
                    $"Não foi possível carregar os dados de {campo} ERRO: {menssagem}",
                    "ERROR!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
        }
        private void MenssagemDeErroModuloFiltragem(string campo, string menssagem)
        {
            MessageBox.Show(
                    $"Campo {campo} inserido não é valido! ERRO: {menssagem}",
                    "ERROR!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
        }
    }
}

