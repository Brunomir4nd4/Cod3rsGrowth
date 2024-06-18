using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagemPocao : Form
    {
        private ServicoPocao _servicoPocao;
        private FiltroPocao _filtroPocao = new FiltroPocao();
        public FormListagemPocao(ServicoPocao servicoPocao, ServicoReceita servicoReceita)
        {
            _servicoPocao = servicoPocao;
            _servicoReceita = servicoReceita;

            InitializeComponent();

            RenderData(_filtroPocao);
        }

        private void FormListagemPocao_Load(object sender, EventArgs e)
        {
        }

        private void RenderData(FiltroPocao filtroPocao)
        {
            try
            {
                dataGridView1.DataSource = _servicoPocao.ObterTodos(filtroPocao);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível obter elementos ERRO: {ex.Message}");
            }
        }

        private FiltroPocao AoClicarBotaoFiltrar()
        {
            FiltroPocao filtroPocao = new FiltroPocao();

            if (!textBox_Id.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroPocao.Id = Int32.Parse(textBox_Id.Text);
                    textBox_Id.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Id inserido não é valido!");
                }
            }

            if (!textBox_Nome.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroPocao.IdReceita = Int32.Parse(textBox_Nome.Text);
                    textBox_Nome.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo IdReceita inserido não é valido!");
                }
            }

            if (!maskedTextBox_Data.Text.IsNullOrEmpty() & maskedTextBox_Data.Text != "  /  /")
            {
                try
                {
                    filtroPocao.DataDeFabricação = DateTime.Parse(maskedTextBox_Data.Text);
                    maskedTextBox_Data.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Data inserido não é valido!");
                }
            }

            if (!comboBox_Vencido.Text.IsNullOrEmpty())
            {
                filtroPocao.Vencido = comboBox_Vencido.Text == "Vencido"
                    ?
                    true
                    :
                    false;
            }

            return filtroPocao;
        }

        private void button_Filtro_Click(object sender, EventArgs e)
        {
            RenderData(AoClicarBotaoFiltrar());
        }

    }
}
