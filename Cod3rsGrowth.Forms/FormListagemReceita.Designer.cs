namespace Cod3rsGrowth.Forms
{
    partial class FormListagemReceita
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
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imagemDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            validadeEmMesesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            receitaBindingSource = new BindingSource(components);
            painel_de_filtragem = new Panel();
            textBox_Valor = new TextBox();
            textBox_Validade = new TextBox();
            label5 = new Label();
            label4 = new Label();
            textBox_Nome = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button_Filtro = new Button();
            textBox_Id = new TextBox();
            panel1 = new Panel();
            button_Adicionar = new Button();
            button_Editar = new Button();
            button_Remover = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)receitaBindingSource).BeginInit();
            painel_de_filtragem.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn, valorDataGridViewTextBoxColumn, imagemDataGridViewTextBoxColumn, validadeEmMesesDataGridViewTextBoxColumn });
            dataGridView1.DataSource = receitaBindingSource;
            dataGridView1.Location = new Point(0, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(800, 383);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 42;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            // 
            // valorDataGridViewTextBoxColumn
            // 
            valorDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            valorDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            valorDataGridViewTextBoxColumn.Width = 58;
            // 
            // imagemDataGridViewTextBoxColumn
            // 
            imagemDataGridViewTextBoxColumn.DataPropertyName = "Imagem";
            imagemDataGridViewTextBoxColumn.HeaderText = "Imagem";
            imagemDataGridViewTextBoxColumn.Name = "imagemDataGridViewTextBoxColumn";
            // 
            // validadeEmMesesDataGridViewTextBoxColumn
            // 
            validadeEmMesesDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            validadeEmMesesDataGridViewTextBoxColumn.DataPropertyName = "ValidadeEmMeses";
            validadeEmMesesDataGridViewTextBoxColumn.HeaderText = "Validade Em Meses";
            validadeEmMesesDataGridViewTextBoxColumn.Name = "validadeEmMesesDataGridViewTextBoxColumn";
            validadeEmMesesDataGridViewTextBoxColumn.Width = 91;
            // 
            // receitaBindingSource
            // 
            receitaBindingSource.DataSource = typeof(Dominio.Entidades.Receita);
            // 
            // painel_de_filtragem
            // 
            painel_de_filtragem.BackColor = Color.White;
            painel_de_filtragem.Controls.Add(textBox_Valor);
            painel_de_filtragem.Controls.Add(textBox_Validade);
            painel_de_filtragem.Controls.Add(label5);
            painel_de_filtragem.Controls.Add(label4);
            painel_de_filtragem.Controls.Add(textBox_Nome);
            painel_de_filtragem.Controls.Add(label3);
            painel_de_filtragem.Controls.Add(label2);
            painel_de_filtragem.Controls.Add(label1);
            painel_de_filtragem.Controls.Add(button_Filtro);
            painel_de_filtragem.Controls.Add(textBox_Id);
            painel_de_filtragem.Dock = DockStyle.Top;
            painel_de_filtragem.Location = new Point(0, 0);
            painel_de_filtragem.Name = "painel_de_filtragem";
            painel_de_filtragem.Size = new Size(800, 68);
            painel_de_filtragem.TabIndex = 1;
            // 
            // textBox_Valor
            // 
            textBox_Valor.Location = new Point(388, 35);
            textBox_Valor.Name = "textBox_Valor";
            textBox_Valor.Size = new Size(100, 23);
            textBox_Valor.TabIndex = 10;
            // 
            // textBox_Validade
            // 
            textBox_Validade.Location = new Point(582, 35);
            textBox_Validade.Name = "textBox_Validade";
            textBox_Validade.Size = new Size(100, 23);
            textBox_Validade.TabIndex = 9;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(504, 37);
            label5.Name = "label5";
            label5.Size = new Size(72, 17);
            label5.TabIndex = 8;
            label5.Text = "Validade";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(334, 37);
            label4.Name = "label4";
            label4.Size = new Size(48, 17);
            label4.TabIndex = 6;
            label4.Text = "Valor";
            // 
            // textBox_Nome
            // 
            textBox_Nome.Location = new Point(213, 35);
            textBox_Nome.Name = "textBox_Nome";
            textBox_Nome.Size = new Size(100, 23);
            textBox_Nome.TabIndex = 5;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(167, 37);
            label3.Name = "label3";
            label3.Size = new Size(40, 17);
            label3.TabIndex = 4;
            label3.Text = "Nome";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(20, 37);
            label2.Name = "label2";
            label2.Size = new Size(24, 17);
            label2.TabIndex = 3;
            label2.Text = "Id";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("JetBrains Mono ExtraBold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(388, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 19);
            label1.TabIndex = 2;
            label1.Text = "Filtro";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button_Filtro
            // 
            button_Filtro.Cursor = Cursors.Hand;
            button_Filtro.Location = new Point(713, 35);
            button_Filtro.Name = "button_Filtro";
            button_Filtro.Size = new Size(75, 23);
            button_Filtro.TabIndex = 1;
            button_Filtro.Text = "Filtrar";
            button_Filtro.UseVisualStyleBackColor = true;
            button_Filtro.Click += button_Filtro_Click;
            // 
            // textBox_Id
            // 
            textBox_Id.Location = new Point(50, 35);
            textBox_Id.Name = "textBox_Id";
            textBox_Id.Size = new Size(100, 23);
            textBox_Id.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(button_Adicionar);
            panel1.Controls.Add(button_Editar);
            panel1.Controls.Add(button_Remover);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 412);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 38);
            panel1.TabIndex = 2;
            // 
            // button_Adicionar
            // 
            button_Adicionar.Cursor = Cursors.Hand;
            button_Adicionar.Location = new Point(543, 6);
            button_Adicionar.Margin = new Padding(0);
            button_Adicionar.Name = "button_Adicionar";
            button_Adicionar.Size = new Size(75, 23);
            button_Adicionar.TabIndex = 12;
            button_Adicionar.Text = "Adicionar";
            button_Adicionar.UseVisualStyleBackColor = true;
            // 
            // button_Editar
            // 
            button_Editar.Cursor = Cursors.Hand;
            button_Editar.Location = new Point(629, 6);
            button_Editar.Margin = new Padding(0);
            button_Editar.Name = "button_Editar";
            button_Editar.Size = new Size(75, 23);
            button_Editar.TabIndex = 11;
            button_Editar.Text = "Editar";
            button_Editar.UseVisualStyleBackColor = true;
            // 
            // button_Remover
            // 
            button_Remover.Cursor = Cursors.Hand;
            button_Remover.Location = new Point(713, 6);
            button_Remover.Margin = new Padding(0);
            button_Remover.Name = "button_Remover";
            button_Remover.Size = new Size(75, 23);
            button_Remover.TabIndex = 10;
            button_Remover.Text = "Remover";
            button_Remover.UseVisualStyleBackColor = true;
            // 
            // FormListagemReceita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(painel_de_filtragem);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormListagemReceita";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estoque das Receitas";
            Load += FormListagemReceita_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)receitaBindingSource).EndInit();
            painel_de_filtragem.ResumeLayout(false);
            painel_de_filtragem.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource receitaBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imagemDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn validadeEmMesesDataGridViewTextBoxColumn;
        private Panel painel_de_filtragem;
        private Label label1;
        private Button button_Filtro;
        private TextBox textBox_Id;
        private Panel panel1;
        private TextBox textBox_Nome;
        private Label label3;
        private Label label2;
        private TextBox textBox_Validade;
        private Label label5;
        private Label label4;
        private Button button_Adicionar;
        private Button button_Editar;
        private Button button_Remover;
        private TextBox textBox_Valor;
    }
}