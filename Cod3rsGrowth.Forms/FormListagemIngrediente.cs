using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagemIngrediente : Form
    {
        private ServicoIngrediente _servicoIngrediente;
        private FiltroIngrediente _filtroIngrediente = new FiltroIngrediente();

        public FormListagemIngrediente(ServicoIngrediente servicoIngrediente)
        {
            _servicoIngrediente = servicoIngrediente;

            InitializeComponent();

            comboBox_Naturalidade.DataSource = Enum.GetValues(typeof(Naturalidade));
            RenderData(_filtroIngrediente);
        }

        private void FormListagemIngrediente_Load(object sender, EventArgs e)
        {
            comboBox_Naturalidade.Text = "";
        }

        private void button_Filtro_Click(object sender, EventArgs e)
        {
            RenderData(AoClicarBotaoFiltrar());
        }

        private FiltroIngrediente AoClicarBotaoFiltrar()
        {
            FiltroIngrediente filtroIngrediente = new FiltroIngrediente();

            if (!textBox_Id.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroIngrediente.Id = Int32.Parse(textBox_Id.Text);
                    textBox_Id.Text = "";
                }
                catch
                {
                    MessageBox.Show("Campo Id inserido não é valido!");
                }
            }

            if (!textBox_Quantidade.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroIngrediente.Quantidade = Int32.Parse(textBox_Quantidade.Text);
                    textBox_Quantidade.Text = "";
                }
                catch
                {
                    MessageBox.Show("Campo Quantidade inserido não é valido!");
                }
            }

            if (!textBox_Nome.Text.IsNullOrEmpty())
            {
                try
                {
                    filtroIngrediente.Nome = textBox_Nome.Text;
                    textBox_Nome.Text = "";
                }
                catch
                {
                    MessageBox.Show("Campo Nome inserido não é valido!");
                }
            }

            if (!comboBox_Naturalidade.Text.IsNullOrEmpty())
            {
                try
                {
                    var valorInteiroDoEnum = comboBox_Naturalidade.SelectedIndex;
                    
                    filtroIngrediente.Naturalidade = (Naturalidade)valorInteiroDoEnum;
                    
                    comboBox_Naturalidade.Text = "";
                }
                catch
                {
                    MessageBox.Show("Campo Naturalidade inserido não é valido!");
                }
            }

            return filtroIngrediente;
        }
        private void RenderData(FiltroIngrediente filtroIngrediente)
        {
            dataGridView1.DataSource = _servicoIngrediente.ObterTodos(filtroIngrediente);
        }
    }
}