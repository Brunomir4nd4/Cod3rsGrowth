namespace Cod3rsGrowth.Forms
{
    partial class FormListagem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tabControl = new TabControl();
            Ingredientes = new TabPage();
            panel1 = new Panel();
            button_Adicionar_Ingrediente = new Button();
            button_Remover_Ingrediente = new Button();
            button_Editar_Ingrediente = new Button();
            painel_de_filtragem = new Panel();
            comboBox_Naturalidade_Ingrediente = new ComboBox();
            button_Filtrar_Ingrediente = new Button();
            textBox_Nome_Ingrediente = new TextBox();
            label5 = new Label();
            textBox_Quantidade_Ingrediente = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox_Id_Ingrediente = new TextBox();
            dataGridView_Ingrediente = new DataGridView();
            ingredienteBindingSource = new BindingSource(components);
            Receitas = new TabPage();
            dataGridView_Receita = new DataGridView();
            receitaBindingSource = new BindingSource(components);
            panel3 = new Panel();
            button_Adicionar_Receita = new Button();
            button_Remover_Receita = new Button();
            button_Editar_Receita = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            panel2 = new Panel();
            textBox_Valor_Receita = new TextBox();
            textBox_Validade_Receita = new TextBox();
            label6 = new Label();
            label7 = new Label();
            button_Filtrar_Receita = new Button();
            textBox_Id_Receita = new TextBox();
            label10 = new Label();
            textBox_Nome_Receita = new TextBox();
            label9 = new Label();
            label8 = new Label();
            Poções = new TabPage();
            dataGridView_Pocao = new DataGridView();
            pocaoBindingSource = new BindingSource(components);
            panel5 = new Panel();
            button_Adicionar_Pocao = new Button();
            button_Remover_Pocao = new Button();
            button_Editar_Pocao = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            panel4 = new Panel();
            comboBox_Vencido_Pocao = new ComboBox();
            button_Filtrar_Pocao = new Button();
            maskedTextBox_Data_Pocao = new MaskedTextBox();
            textBox_Id_Pocao = new TextBox();
            label13 = new Label();
            label15 = new Label();
            label14 = new Label();
            label11 = new Label();
            textBox_Nome_Pocao = new TextBox();
            label12 = new Label();
            receitaIngredienteBindingSource = new BindingSource(components);
            fbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            fbCommand2 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            fbCommand3 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            ingredienteBindingSource1 = new BindingSource(components);
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            receitaBindingSource1 = new BindingSource(components);
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            pocaoBindingSource1 = new BindingSource(components);
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            DataDeFabricacao = new DataGridViewTextBoxColumn();
            vencidoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            tabControl.SuspendLayout();
            Ingredientes.SuspendLayout();
            panel1.SuspendLayout();
            painel_de_filtragem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Ingrediente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ingredienteBindingSource).BeginInit();
            Receitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Receita).BeginInit();
            ((System.ComponentModel.ISupportInitialize)receitaBindingSource).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            Poções.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Pocao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pocaoBindingSource).BeginInit();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)receitaIngredienteBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ingredienteBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)receitaBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pocaoBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(Ingredientes);
            tabControl.Controls.Add(Receitas);
            tabControl.Controls.Add(Poções);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(862, 556);
            tabControl.TabIndex = 0;
            // 
            // Ingredientes
            // 
            Ingredientes.Controls.Add(panel1);
            Ingredientes.Controls.Add(painel_de_filtragem);
            Ingredientes.Controls.Add(dataGridView_Ingrediente);
            Ingredientes.Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            Ingredientes.Location = new Point(4, 25);
            Ingredientes.Name = "Ingredientes";
            Ingredientes.Padding = new Padding(3);
            Ingredientes.Size = new Size(854, 527);
            Ingredientes.TabIndex = 0;
            Ingredientes.Text = "Ingredientes";
            Ingredientes.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(button_Adicionar_Ingrediente);
            panel1.Controls.Add(button_Remover_Ingrediente);
            panel1.Controls.Add(button_Editar_Ingrediente);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 485);
            panel1.Name = "panel1";
            panel1.Size = new Size(848, 39);
            panel1.TabIndex = 19;
            // 
            // button_Adicionar_Ingrediente
            // 
            button_Adicionar_Ingrediente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Adicionar_Ingrediente.Cursor = Cursors.Hand;
            button_Adicionar_Ingrediente.Location = new Point(558, 8);
            button_Adicionar_Ingrediente.Name = "button_Adicionar_Ingrediente";
            button_Adicionar_Ingrediente.Size = new Size(75, 25);
            button_Adicionar_Ingrediente.TabIndex = 2;
            button_Adicionar_Ingrediente.Text = "Adicionar";
            button_Adicionar_Ingrediente.UseVisualStyleBackColor = true;
            button_Adicionar_Ingrediente.Click += AoClicarAbrirFormCriarIngrediente;
            // 
            // button_Remover_Ingrediente
            // 
            button_Remover_Ingrediente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Remover_Ingrediente.Cursor = Cursors.Hand;
            button_Remover_Ingrediente.Location = new Point(720, 8);
            button_Remover_Ingrediente.Name = "button_Remover_Ingrediente";
            button_Remover_Ingrediente.Size = new Size(75, 25);
            button_Remover_Ingrediente.TabIndex = 1;
            button_Remover_Ingrediente.Text = "Remover";
            button_Remover_Ingrediente.UseVisualStyleBackColor = true;
            // 
            // button_Editar_Ingrediente
            // 
            button_Editar_Ingrediente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Editar_Ingrediente.Cursor = Cursors.Hand;
            button_Editar_Ingrediente.Location = new Point(639, 8);
            button_Editar_Ingrediente.Name = "button_Editar_Ingrediente";
            button_Editar_Ingrediente.Size = new Size(75, 25);
            button_Editar_Ingrediente.TabIndex = 0;
            button_Editar_Ingrediente.Text = "Editar";
            button_Editar_Ingrediente.UseVisualStyleBackColor = true;
            button_Editar_Ingrediente.Click += AoClicarEditarIngrediente;
            // 
            // painel_de_filtragem
            // 
            painel_de_filtragem.BackColor = Color.White;
            painel_de_filtragem.Controls.Add(comboBox_Naturalidade_Ingrediente);
            painel_de_filtragem.Controls.Add(button_Filtrar_Ingrediente);
            painel_de_filtragem.Controls.Add(textBox_Nome_Ingrediente);
            painel_de_filtragem.Controls.Add(label5);
            painel_de_filtragem.Controls.Add(textBox_Quantidade_Ingrediente);
            painel_de_filtragem.Controls.Add(label4);
            painel_de_filtragem.Controls.Add(label3);
            painel_de_filtragem.Controls.Add(label2);
            painel_de_filtragem.Controls.Add(label1);
            painel_de_filtragem.Controls.Add(textBox_Id_Ingrediente);
            painel_de_filtragem.Dock = DockStyle.Top;
            painel_de_filtragem.Location = new Point(3, 3);
            painel_de_filtragem.Name = "painel_de_filtragem";
            painel_de_filtragem.Size = new Size(848, 73);
            painel_de_filtragem.TabIndex = 18;
            // 
            // comboBox_Naturalidade_Ingrediente
            // 
            comboBox_Naturalidade_Ingrediente.Anchor = AnchorStyles.Top;
            comboBox_Naturalidade_Ingrediente.FormattingEnabled = true;
            comboBox_Naturalidade_Ingrediente.Location = new Point(618, 37);
            comboBox_Naturalidade_Ingrediente.Name = "comboBox_Naturalidade_Ingrediente";
            comboBox_Naturalidade_Ingrediente.Size = new Size(97, 24);
            comboBox_Naturalidade_Ingrediente.TabIndex = 13;
            // 
            // button_Filtrar_Ingrediente
            // 
            button_Filtrar_Ingrediente.Anchor = AnchorStyles.Top;
            button_Filtrar_Ingrediente.Cursor = Cursors.Hand;
            button_Filtrar_Ingrediente.Location = new Point(734, 37);
            button_Filtrar_Ingrediente.Name = "button_Filtrar_Ingrediente";
            button_Filtrar_Ingrediente.Size = new Size(75, 25);
            button_Filtrar_Ingrediente.TabIndex = 12;
            button_Filtrar_Ingrediente.Text = "Filtrar";
            button_Filtrar_Ingrediente.UseVisualStyleBackColor = true;
            button_Filtrar_Ingrediente.Click += AoClicarBotaoFiltrarIngrediente;
            // 
            // textBox_Nome_Ingrediente
            // 
            textBox_Nome_Ingrediente.Anchor = AnchorStyles.Top;
            textBox_Nome_Ingrediente.Location = new Point(204, 37);
            textBox_Nome_Ingrediente.Name = "textBox_Nome_Ingrediente";
            textBox_Nome_Ingrediente.PlaceholderText = "Nome...";
            textBox_Nome_Ingrediente.Size = new Size(81, 23);
            textBox_Nome_Ingrediente.TabIndex = 10;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(508, 39);
            label5.Name = "label5";
            label5.Size = new Size(104, 17);
            label5.TabIndex = 8;
            label5.Text = "Naturalidade";
            // 
            // textBox_Quantidade_Ingrediente
            // 
            textBox_Quantidade_Ingrediente.Anchor = AnchorStyles.Top;
            textBox_Quantidade_Ingrediente.Location = new Point(397, 37);
            textBox_Quantidade_Ingrediente.Name = "textBox_Quantidade_Ingrediente";
            textBox_Quantidade_Ingrediente.PlaceholderText = "Quantidade...";
            textBox_Quantidade_Ingrediente.Size = new Size(97, 23);
            textBox_Quantidade_Ingrediente.TabIndex = 7;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(303, 39);
            label4.Name = "label4";
            label4.Size = new Size(88, 17);
            label4.TabIndex = 6;
            label4.Text = "Quantidade";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(158, 39);
            label3.Name = "label3";
            label3.Size = new Size(40, 17);
            label3.TabIndex = 4;
            label3.Text = "Nome";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(33, 39);
            label2.Name = "label2";
            label2.Size = new Size(24, 17);
            label2.TabIndex = 3;
            label2.Text = "Id";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("JetBrains Mono ExtraBold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(406, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 19);
            label1.TabIndex = 2;
            label1.Text = "Filtro";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_Id_Ingrediente
            // 
            textBox_Id_Ingrediente.Anchor = AnchorStyles.Top;
            textBox_Id_Ingrediente.Location = new Point(61, 37);
            textBox_Id_Ingrediente.Name = "textBox_Id_Ingrediente";
            textBox_Id_Ingrediente.PlaceholderText = "Id...";
            textBox_Id_Ingrediente.Size = new Size(81, 23);
            textBox_Id_Ingrediente.TabIndex = 0;
            textBox_Id_Ingrediente.Tag = "";
            // 
            // dataGridView_Ingrediente
            // 
            dataGridView_Ingrediente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_Ingrediente.AutoGenerateColumns = false;
            dataGridView_Ingrediente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Ingrediente.BackgroundColor = SystemColors.Window;
            dataGridView_Ingrediente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Ingrediente.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dataGridView_Ingrediente.DataSource = ingredienteBindingSource1;
            dataGridView_Ingrediente.Location = new Point(3, 82);
            dataGridView_Ingrediente.Name = "dataGridView_Ingrediente";
            dataGridView_Ingrediente.RowTemplate.Height = 25;
            dataGridView_Ingrediente.Size = new Size(848, 397);
            dataGridView_Ingrediente.TabIndex = 1;
            // 
            // Receitas
            // 
            Receitas.Controls.Add(dataGridView_Receita);
            Receitas.Controls.Add(panel3);
            Receitas.Controls.Add(panel2);
            Receitas.Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            Receitas.Location = new Point(4, 25);
            Receitas.Name = "Receitas";
            Receitas.Padding = new Padding(3);
            Receitas.Size = new Size(854, 527);
            Receitas.TabIndex = 1;
            Receitas.Text = "Receitas";
            Receitas.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Receita
            // 
            dataGridView_Receita.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_Receita.AutoGenerateColumns = false;
            dataGridView_Receita.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Receita.BackgroundColor = SystemColors.Window;
            dataGridView_Receita.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Receita.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11 });
            dataGridView_Receita.DataSource = receitaBindingSource1;
            dataGridView_Receita.Location = new Point(3, 82);
            dataGridView_Receita.Name = "dataGridView_Receita";
            dataGridView_Receita.RowTemplate.Height = 25;
            dataGridView_Receita.Size = new Size(848, 381);
            dataGridView_Receita.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.Controls.Add(button_Adicionar_Receita);
            panel3.Controls.Add(button_Remover_Receita);
            panel3.Controls.Add(button_Editar_Receita);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button4);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(3, 477);
            panel3.Name = "panel3";
            panel3.Size = new Size(848, 47);
            panel3.TabIndex = 25;
            // 
            // button_Adicionar_Receita
            // 
            button_Adicionar_Receita.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Adicionar_Receita.Cursor = Cursors.Hand;
            button_Adicionar_Receita.Location = new Point(563, 11);
            button_Adicionar_Receita.Name = "button_Adicionar_Receita";
            button_Adicionar_Receita.Size = new Size(75, 25);
            button_Adicionar_Receita.TabIndex = 5;
            button_Adicionar_Receita.Text = "Adicionar";
            button_Adicionar_Receita.UseVisualStyleBackColor = true;
            button_Adicionar_Receita.Click += AoClicarAbrirFormModificaReceita;
            // 
            // button_Remover_Receita
            // 
            button_Remover_Receita.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Remover_Receita.Cursor = Cursors.Hand;
            button_Remover_Receita.Location = new Point(725, 11);
            button_Remover_Receita.Name = "button_Remover_Receita";
            button_Remover_Receita.Size = new Size(75, 25);
            button_Remover_Receita.TabIndex = 4;
            button_Remover_Receita.Text = "Remover";
            button_Remover_Receita.UseVisualStyleBackColor = true;
            // 
            // button_Editar_Receita
            // 
            button_Editar_Receita.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Editar_Receita.Cursor = Cursors.Hand;
            button_Editar_Receita.Location = new Point(644, 11);
            button_Editar_Receita.Name = "button_Editar_Receita";
            button_Editar_Receita.Size = new Size(75, 25);
            button_Editar_Receita.TabIndex = 3;
            button_Editar_Receita.Text = "Editar";
            button_Editar_Receita.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(1207, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 25);
            button2.TabIndex = 2;
            button2.Text = "Adicionar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Cursor = Cursors.Hand;
            button3.Location = new Point(1369, 12);
            button3.Name = "button3";
            button3.Size = new Size(75, 25);
            button3.TabIndex = 1;
            button3.Text = "Remover";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Cursor = Cursors.Hand;
            button4.Location = new Point(1288, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 25);
            button4.TabIndex = 0;
            button4.Text = "Editar";
            button4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox_Valor_Receita);
            panel2.Controls.Add(textBox_Validade_Receita);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(button_Filtrar_Receita);
            panel2.Controls.Add(textBox_Id_Receita);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(textBox_Nome_Receita);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(848, 73);
            panel2.TabIndex = 24;
            // 
            // textBox_Valor_Receita
            // 
            textBox_Valor_Receita.Anchor = AnchorStyles.Top;
            textBox_Valor_Receita.Location = new Point(414, 33);
            textBox_Valor_Receita.Name = "textBox_Valor_Receita";
            textBox_Valor_Receita.PlaceholderText = "Valor...";
            textBox_Valor_Receita.Size = new Size(81, 23);
            textBox_Valor_Receita.TabIndex = 26;
            // 
            // textBox_Validade_Receita
            // 
            textBox_Validade_Receita.Anchor = AnchorStyles.Top;
            textBox_Validade_Receita.Location = new Point(594, 33);
            textBox_Validade_Receita.Name = "textBox_Validade_Receita";
            textBox_Validade_Receita.PlaceholderText = "Validade...";
            textBox_Validade_Receita.Size = new Size(81, 23);
            textBox_Validade_Receita.TabIndex = 25;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(516, 35);
            label6.Name = "label6";
            label6.Size = new Size(72, 17);
            label6.TabIndex = 24;
            label6.Text = "Validade";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(360, 35);
            label7.Name = "label7";
            label7.Size = new Size(48, 17);
            label7.TabIndex = 23;
            label7.Text = "Valor";
            // 
            // button_Filtrar_Receita
            // 
            button_Filtrar_Receita.Anchor = AnchorStyles.Top;
            button_Filtrar_Receita.Cursor = Cursors.Hand;
            button_Filtrar_Receita.Location = new Point(707, 33);
            button_Filtrar_Receita.Name = "button_Filtrar_Receita";
            button_Filtrar_Receita.Size = new Size(75, 25);
            button_Filtrar_Receita.TabIndex = 22;
            button_Filtrar_Receita.Text = "Filtrar";
            button_Filtrar_Receita.UseVisualStyleBackColor = true;
            button_Filtrar_Receita.Click += AoClicarBotaoFiltrarReceita;
            // 
            // textBox_Id_Receita
            // 
            textBox_Id_Receita.Anchor = AnchorStyles.Top;
            textBox_Id_Receita.Location = new Point(114, 33);
            textBox_Id_Receita.Name = "textBox_Id_Receita";
            textBox_Id_Receita.PlaceholderText = "Id...";
            textBox_Id_Receita.Size = new Size(81, 23);
            textBox_Id_Receita.TabIndex = 14;
            textBox_Id_Receita.Tag = "";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Font = new Font("JetBrains Mono ExtraBold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(401, -1);
            label10.Name = "label10";
            label10.Size = new Size(63, 19);
            label10.TabIndex = 15;
            label10.Text = "Filtro";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_Nome_Receita
            // 
            textBox_Nome_Receita.Anchor = AnchorStyles.Top;
            textBox_Nome_Receita.Location = new Point(257, 33);
            textBox_Nome_Receita.Name = "textBox_Nome_Receita";
            textBox_Nome_Receita.PlaceholderText = "Nome...";
            textBox_Nome_Receita.Size = new Size(81, 23);
            textBox_Nome_Receita.TabIndex = 21;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(86, 35);
            label9.Name = "label9";
            label9.Size = new Size(24, 17);
            label9.TabIndex = 16;
            label9.Text = "Id";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(211, 35);
            label8.Name = "label8";
            label8.Size = new Size(40, 17);
            label8.TabIndex = 17;
            label8.Text = "Nome";
            // 
            // Poções
            // 
            Poções.BackColor = SystemColors.Window;
            Poções.Controls.Add(dataGridView_Pocao);
            Poções.Controls.Add(panel5);
            Poções.Controls.Add(panel4);
            Poções.Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            Poções.Location = new Point(4, 25);
            Poções.Name = "Poções";
            Poções.Size = new Size(854, 527);
            Poções.TabIndex = 2;
            Poções.Text = "Poções";
            // 
            // dataGridView_Pocao
            // 
            dataGridView_Pocao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_Pocao.AutoGenerateColumns = false;
            dataGridView_Pocao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Pocao.BackgroundColor = SystemColors.Window;
            dataGridView_Pocao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Pocao.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, Nome, DataDeFabricacao, vencidoDataGridViewCheckBoxColumn });
            dataGridView_Pocao.DataSource = pocaoBindingSource1;
            dataGridView_Pocao.Location = new Point(0, 79);
            dataGridView_Pocao.Name = "dataGridView_Pocao";
            dataGridView_Pocao.RowTemplate.Height = 25;
            dataGridView_Pocao.Size = new Size(851, 382);
            dataGridView_Pocao.TabIndex = 27;
            // 
            // panel5
            // 
            panel5.Controls.Add(button_Adicionar_Pocao);
            panel5.Controls.Add(button_Remover_Pocao);
            panel5.Controls.Add(button_Editar_Pocao);
            panel5.Controls.Add(button9);
            panel5.Controls.Add(button10);
            panel5.Controls.Add(button11);
            panel5.Controls.Add(button12);
            panel5.Controls.Add(button13);
            panel5.Controls.Add(button14);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 480);
            panel5.Name = "panel5";
            panel5.Size = new Size(854, 47);
            panel5.TabIndex = 26;
            // 
            // button_Adicionar_Pocao
            // 
            button_Adicionar_Pocao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Adicionar_Pocao.Cursor = Cursors.Hand;
            button_Adicionar_Pocao.Location = new Point(566, 13);
            button_Adicionar_Pocao.Name = "button_Adicionar_Pocao";
            button_Adicionar_Pocao.Size = new Size(75, 25);
            button_Adicionar_Pocao.TabIndex = 8;
            button_Adicionar_Pocao.Text = "Adicionar";
            button_Adicionar_Pocao.UseVisualStyleBackColor = true;
            button_Adicionar_Pocao.Click += AoClicarAbrirFromsCriarPocao;
            // 
            // button_Remover_Pocao
            // 
            button_Remover_Pocao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Remover_Pocao.Cursor = Cursors.Hand;
            button_Remover_Pocao.Location = new Point(728, 13);
            button_Remover_Pocao.Name = "button_Remover_Pocao";
            button_Remover_Pocao.Size = new Size(75, 25);
            button_Remover_Pocao.TabIndex = 7;
            button_Remover_Pocao.Text = "Remover";
            button_Remover_Pocao.UseVisualStyleBackColor = true;
            // 
            // button_Editar_Pocao
            // 
            button_Editar_Pocao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Editar_Pocao.Cursor = Cursors.Hand;
            button_Editar_Pocao.Location = new Point(647, 13);
            button_Editar_Pocao.Name = "button_Editar_Pocao";
            button_Editar_Pocao.Size = new Size(75, 25);
            button_Editar_Pocao.TabIndex = 6;
            button_Editar_Pocao.Text = "Editar";
            button_Editar_Pocao.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button9.Cursor = Cursors.Hand;
            button9.Location = new Point(1217, 11);
            button9.Name = "button9";
            button9.Size = new Size(75, 25);
            button9.TabIndex = 5;
            button9.Text = "Adicionar";
            button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button10.Cursor = Cursors.Hand;
            button10.Location = new Point(1379, 11);
            button10.Name = "button10";
            button10.Size = new Size(75, 25);
            button10.TabIndex = 4;
            button10.Text = "Remover";
            button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button11.Cursor = Cursors.Hand;
            button11.Location = new Point(1298, 11);
            button11.Name = "button11";
            button11.Size = new Size(75, 25);
            button11.TabIndex = 3;
            button11.Text = "Editar";
            button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button12.Cursor = Cursors.Hand;
            button12.Location = new Point(1861, 12);
            button12.Name = "button12";
            button12.Size = new Size(75, 25);
            button12.TabIndex = 2;
            button12.Text = "Adicionar";
            button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button13.Cursor = Cursors.Hand;
            button13.Location = new Point(2023, 12);
            button13.Name = "button13";
            button13.Size = new Size(75, 25);
            button13.TabIndex = 1;
            button13.Text = "Remover";
            button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            button14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button14.Cursor = Cursors.Hand;
            button14.Location = new Point(1942, 12);
            button14.Name = "button14";
            button14.Size = new Size(75, 25);
            button14.TabIndex = 0;
            button14.Text = "Editar";
            button14.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(comboBox_Vencido_Pocao);
            panel4.Controls.Add(button_Filtrar_Pocao);
            panel4.Controls.Add(maskedTextBox_Data_Pocao);
            panel4.Controls.Add(textBox_Id_Pocao);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(textBox_Nome_Pocao);
            panel4.Controls.Add(label12);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(854, 73);
            panel4.TabIndex = 0;
            // 
            // comboBox_Vencido_Pocao
            // 
            comboBox_Vencido_Pocao.Anchor = AnchorStyles.Top;
            comboBox_Vencido_Pocao.FormattingEnabled = true;
            comboBox_Vencido_Pocao.Items.AddRange(new object[] { "Valido", "Vencido" });
            comboBox_Vencido_Pocao.Location = new Point(585, 37);
            comboBox_Vencido_Pocao.Name = "comboBox_Vencido_Pocao";
            comboBox_Vencido_Pocao.Size = new Size(81, 24);
            comboBox_Vencido_Pocao.TabIndex = 18;
            // 
            // button_Filtrar_Pocao
            // 
            button_Filtrar_Pocao.Anchor = AnchorStyles.Top;
            button_Filtrar_Pocao.Cursor = Cursors.Hand;
            button_Filtrar_Pocao.Location = new Point(728, 37);
            button_Filtrar_Pocao.Name = "button_Filtrar_Pocao";
            button_Filtrar_Pocao.Size = new Size(75, 25);
            button_Filtrar_Pocao.TabIndex = 32;
            button_Filtrar_Pocao.Text = "Filtrar";
            button_Filtrar_Pocao.UseVisualStyleBackColor = true;
            button_Filtrar_Pocao.Click += AoClicarBotaoFiltrarPocao;
            // 
            // maskedTextBox_Data_Pocao
            // 
            maskedTextBox_Data_Pocao.Anchor = AnchorStyles.Top;
            maskedTextBox_Data_Pocao.Location = new Point(395, 37);
            maskedTextBox_Data_Pocao.Mask = "00/00/0000";
            maskedTextBox_Data_Pocao.Name = "maskedTextBox_Data_Pocao";
            maskedTextBox_Data_Pocao.Size = new Size(81, 23);
            maskedTextBox_Data_Pocao.TabIndex = 17;
            maskedTextBox_Data_Pocao.ValidatingType = typeof(DateTime);
            // 
            // textBox_Id_Pocao
            // 
            textBox_Id_Pocao.Anchor = AnchorStyles.Top;
            textBox_Id_Pocao.Location = new Point(59, 37);
            textBox_Id_Pocao.Name = "textBox_Id_Pocao";
            textBox_Id_Pocao.PlaceholderText = "Id...";
            textBox_Id_Pocao.Size = new Size(81, 23);
            textBox_Id_Pocao.TabIndex = 24;
            textBox_Id_Pocao.Tag = "";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top;
            label13.AutoSize = true;
            label13.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(515, 39);
            label13.Name = "label13";
            label13.Size = new Size(64, 17);
            label13.TabIndex = 16;
            label13.Text = "Vencido";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top;
            label15.AutoSize = true;
            label15.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(349, 39);
            label15.Name = "label15";
            label15.Size = new Size(40, 17);
            label15.TabIndex = 15;
            label15.Text = "Data";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top;
            label14.AutoSize = true;
            label14.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(184, 39);
            label14.Name = "label14";
            label14.Size = new Size(40, 17);
            label14.TabIndex = 27;
            label14.Text = "Nome";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.Font = new Font("JetBrains Mono ExtraBold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(404, 0);
            label11.Name = "label11";
            label11.Size = new Size(63, 19);
            label11.TabIndex = 25;
            label11.Text = "Filtro";
            label11.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_Nome_Pocao
            // 
            textBox_Nome_Pocao.Anchor = AnchorStyles.Top;
            textBox_Nome_Pocao.Location = new Point(230, 37);
            textBox_Nome_Pocao.Name = "textBox_Nome_Pocao";
            textBox_Nome_Pocao.PlaceholderText = "Nome...";
            textBox_Nome_Pocao.Size = new Size(81, 23);
            textBox_Nome_Pocao.TabIndex = 31;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(31, 39);
            label12.Name = "label12";
            label12.Size = new Size(24, 17);
            label12.TabIndex = 26;
            label12.Text = "Id";
            // 
            // ingredienteBindingSource1
            // 
            ingredienteBindingSource1.DataSource = typeof(Dominio.Entidades.Ingrediente);
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Id";
            dataGridViewTextBoxColumn3.HeaderText = "Id";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Nome";
            dataGridViewTextBoxColumn4.HeaderText = "Nome";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "Quantidade";
            dataGridViewTextBoxColumn5.HeaderText = "Quantidade";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "Naturalidade";
            dataGridViewTextBoxColumn6.HeaderText = "Naturalidade";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // receitaBindingSource1
            // 
            receitaBindingSource1.DataSource = typeof(Dominio.Entidades.Receita);
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "Id";
            dataGridViewTextBoxColumn7.HeaderText = "Id";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "Nome";
            dataGridViewTextBoxColumn8.HeaderText = "Nome";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.DataPropertyName = "Descricao";
            dataGridViewTextBoxColumn9.HeaderText = "Descricao";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.DataPropertyName = "Valor";
            dataGridViewTextBoxColumn10.HeaderText = "Valor";
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.DataPropertyName = "ValidadeEmMeses";
            dataGridViewTextBoxColumn11.HeaderText = "ValidadeEmMeses";
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // pocaoBindingSource1
            // 
            pocaoBindingSource1.DataSource = typeof(Dominio.Entidades.Pocao);
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // Nome
            // 
            Nome.DataPropertyName = "Nome";
            Nome.FillWeight = 200F;
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            // 
            // DataDeFabricacao
            // 
            DataDeFabricacao.DataPropertyName = "DataDeFabricacao";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataDeFabricacao.DefaultCellStyle = dataGridViewCellStyle1;
            DataDeFabricacao.FillWeight = 150F;
            DataDeFabricacao.HeaderText = "Data De Fabricacao";
            DataDeFabricacao.Name = "DataDeFabricacao";
            // 
            // vencidoDataGridViewCheckBoxColumn
            // 
            vencidoDataGridViewCheckBoxColumn.DataPropertyName = "Vencido";
            vencidoDataGridViewCheckBoxColumn.HeaderText = "Vencido";
            vencidoDataGridViewCheckBoxColumn.Name = "vencidoDataGridViewCheckBoxColumn";
            // 
            // FormListagem
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 555);
            Controls.Add(tabControl);
            Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormListagem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estoque";
            Load += FormListagem_Load;
            tabControl.ResumeLayout(false);
            Ingredientes.ResumeLayout(false);
            panel1.ResumeLayout(false);
            painel_de_filtragem.ResumeLayout(false);
            painel_de_filtragem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Ingrediente).EndInit();
            ((System.ComponentModel.ISupportInitialize)ingredienteBindingSource).EndInit();
            Receitas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_Receita).EndInit();
            ((System.ComponentModel.ISupportInitialize)receitaBindingSource).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            Poções.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_Pocao).EndInit();
            ((System.ComponentModel.ISupportInitialize)pocaoBindingSource).EndInit();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)receitaIngredienteBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ingredienteBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)receitaBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pocaoBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage Ingredientes;
        private TabPage Receitas;
        private BindingSource ingredienteBindingSource;
        private Panel painel_de_filtragem;
        private TextBox textBox_Nome_Ingrediente;
        private Label label5;
        private TextBox textBox_Quantidade_Ingrediente;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox_Id_Ingrediente;
        private ComboBox comboBox_Naturalidade_Ingrediente;
        private Button button_Filtrar_Ingrediente;
        private Panel panel1;
        private Button button_Adicionar_Ingrediente;
        private Button button_Remover_Ingrediente;
        private Button button_Editar_Ingrediente;
        private TabPage Poções;
        private DataGridView dataGridView_Ingrediente;
        private Panel panel2;
        private Button button_Filtrar_Receita;
        private TextBox textBox_Id_Receita;
        private Label label10;
        private TextBox textBox_Nome_Receita;
        private Label label9;
        private Label label8;
        private Panel panel3;
        private Button button_Adicionar_Receita;
        private Button button_Remover_Receita;
        private Button button_Editar_Receita;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel panel4;
        private Button button_Filtrar_Pocao;
        private TextBox textBox_Id_Pocao;
        private Label label14;
        private Label label11;
        private TextBox textBox_Nome_Pocao;
        private Label label12;
        private Panel panel5;
        private Button button_Adicionar_Pocao;
        private Button button_Remover_Pocao;
        private Button button_Editar_Pocao;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private ComboBox comboBox_Vencido_Pocao;
        private MaskedTextBox maskedTextBox_Data_Pocao;
        private Label label13;
        private Label label15;
        private TextBox textBox_Valor_Receita;
        private TextBox textBox_Validade_Receita;
        private Label label6;
        private Label label7;
        private BindingSource receitaBindingSource;
        private DataGridView dataGridView_Receita;
        private DataGridView dataGridView_Pocao;
        private BindingSource pocaoBindingSource;
        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn naturalidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn validadeEmMesesDataGridViewTextBoxColumn;
        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand2;
        private BindingSource receitaIngredienteBindingSource;
        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private BindingSource ingredienteBindingSource1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private BindingSource receitaBindingSource1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn DataDeFabricacao;
        private DataGridViewCheckBoxColumn vencidoDataGridViewCheckBoxColumn;
        private BindingSource pocaoBindingSource1;
    }
}