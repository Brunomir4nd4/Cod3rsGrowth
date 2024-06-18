using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagemReceita : Form
    {
        private ServicoReceita _servicoReceita;
        private FiltroReceita _filtroReceita = new FiltroReceita();

        public FormListagemReceita(ServicoReceita servicoReceita)
        {
            _servicoReceita = servicoReceita;

            InitializeComponent();

            RenderData(_filtroReceita);
        }

        private void FormListagemReceita_Load(object sender, EventArgs e)
        {
        }

        public void RenderData(FiltroReceita filtroReceita)
        {
            try
            {
                dataGridView1.DataSource = _servicoReceita.ObterTodos(filtroReceita);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível obter elementos ERRO: {ex.Message}");
            }
        }

        private FiltroReceita AoClicarBotaoFiltrar()
        {
            FiltroReceita filtroReceita = new FiltroReceita();

            if (!textBox_Id.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroReceita.Id = Int32.Parse(textBox_Id.Text);
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
                    filtroReceita.Nome = textBox_Nome.Text;
                    textBox_Nome.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Nome inserido não é valido!");
                }
            }

            if (!textBox_Valor.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroReceita.Valor = Decimal.Parse(textBox_Valor.Text);
                    textBox_Valor.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Valor inserido não é valido!");
                }
            }

            if (!textBox_Validade.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroReceita.ValidadeEmMeses = Int32.Parse(textBox_Validade.Text);
                    textBox_Validade.Text = "";
                }
                catch
                {
                    MessageBox.Show($"Campo Validade inserido não é valido!");
                }
            }

            return filtroReceita;
        }

        private void button_Filtro_Click(object sender, EventArgs e)
        {
            RenderData(AoClicarBotaoFiltrar());
        }
    }
}
