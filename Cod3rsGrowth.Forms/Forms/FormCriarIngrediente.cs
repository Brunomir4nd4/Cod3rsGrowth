using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCriarIngrediente : Form
    {
        private ServicoIngrediente _servicoIngrediente;
        public FormCriarIngrediente(ServicoIngrediente servicoIngrediente)
        {
            InitializeComponent();
            _servicoIngrediente = servicoIngrediente;
            comboBox_Naturalidade.DataSource = Enum.GetValues(typeof(Naturalidade));
        }

        private void AoClicarSalvarCriacao(object sender, EventArgs e)
        {
            var ingrediente = new Ingrediente();
            var valorInteiroDoEnum = comboBox_Naturalidade.SelectedIndex;
            try
            {
                ingrediente.Nome = textBox_Nome.Text;
                ingrediente.Quantidade = Int32.Parse(textBox_Quantidade.Text);
                ingrediente.Naturalidade = (Naturalidade)valorInteiroDoEnum;

                _servicoIngrediente.CriarIngrediente(ingrediente);

                MessageBox.Show("Ingrediente Criado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormCriarIngrediente_Load(object sender, EventArgs e)
        {
        }

        private void AoClicarFcharForms(object sender, EventArgs e)
        {
            Close();
        }
    }
}
