namespace Cod3rsGrowth.Forms
{
    partial class FormModificaReceita
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
            label_Titulo = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            richTextBox_Descricao = new RichTextBox();
            label6 = new Label();
            textBox_Nome = new TextBox();
            textBox_Valor = new TextBox();
            textBox_Validade = new TextBox();
            button_Salvar = new Button();
            button_Cancelar = new Button();
            dataGridView1 = new DataGridView();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Check = new DataGridViewCheckBoxColumn();
            ingredienteBindingSource = new BindingSource(components);
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ingredienteBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label_Titulo
            // 
            label_Titulo.AutoSize = true;
            label_Titulo.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Titulo.Location = new Point(73, 19);
            label_Titulo.Name = "label_Titulo";
            label_Titulo.Size = new Size(0, 27);
            label_Titulo.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(45, 19);
            label2.TabIndex = 20;
            label2.Text = "Nome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 206);
            label3.Name = "label3";
            label3.Size = new Size(90, 19);
            label3.TabIndex = 21;
            label3.Text = "Descrição";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 139);
            label4.Name = "label4";
            label4.Size = new Size(54, 19);
            label4.TabIndex = 22;
            label4.Text = "Valor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(202, 139);
            label5.Name = "label5";
            label5.Size = new Size(180, 19);
            label5.TabIndex = 23;
            label5.Text = "Validade (Em Meses)";
            // 
            // richTextBox_Descricao
            // 
            richTextBox_Descricao.Location = new Point(12, 228);
            richTextBox_Descricao.Name = "richTextBox_Descricao";
            richTextBox_Descricao.Size = new Size(375, 109);
            richTextBox_Descricao.TabIndex = 30;
            richTextBox_Descricao.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 361);
            label6.Name = "label6";
            label6.Size = new Size(117, 19);
            label6.TabIndex = 24;
            label6.Text = "Ingredientes";
            // 
            // textBox_Nome
            // 
            textBox_Nome.Location = new Point(12, 86);
            textBox_Nome.Name = "textBox_Nome";
            textBox_Nome.PlaceholderText = "Nome...";
            textBox_Nome.Size = new Size(370, 23);
            textBox_Nome.TabIndex = 32;
            // 
            // textBox_Valor
            // 
            textBox_Valor.Location = new Point(12, 161);
            textBox_Valor.Name = "textBox_Valor";
            textBox_Valor.PlaceholderText = "Valor...";
            textBox_Valor.Size = new Size(185, 23);
            textBox_Valor.TabIndex = 33;
            // 
            // textBox_Validade
            // 
            textBox_Validade.Location = new Point(202, 161);
            textBox_Validade.Name = "textBox_Validade";
            textBox_Validade.PlaceholderText = "Validade...";
            textBox_Validade.Size = new Size(185, 23);
            textBox_Validade.TabIndex = 34;
            // 
            // button_Salvar
            // 
            button_Salvar.Cursor = Cursors.Hand;
            button_Salvar.Location = new Point(12, 561);
            button_Salvar.Name = "button_Salvar";
            button_Salvar.Size = new Size(75, 23);
            button_Salvar.TabIndex = 35;
            button_Salvar.Text = "Salvar";
            button_Salvar.UseVisualStyleBackColor = true;
            button_Salvar.Click += AoClicarSalvarCriacaoReceita;
            // 
            // button_Cancelar
            // 
            button_Cancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Cancelar.Cursor = Cursors.Hand;
            button_Cancelar.Location = new Point(312, 559);
            button_Cancelar.Name = "button_Cancelar";
            button_Cancelar.Size = new Size(75, 25);
            button_Cancelar.TabIndex = 36;
            button_Cancelar.Text = "Cancelar";
            button_Cancelar.UseVisualStyleBackColor = true;
            button_Cancelar.Click += AoClicarFaharForms;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nomeDataGridViewTextBoxColumn, Check });
            dataGridView1.DataSource = ingredienteBindingSource;
            dataGridView1.Location = new Point(12, 392);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(375, 137);
            dataGridView1.TabIndex = 37;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // Check
            // 
            Check.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Check.HeaderText = "Check";
            Check.Name = "Check";
            Check.Resizable = DataGridViewTriState.True;
            Check.SortMode = DataGridViewColumnSortMode.Automatic;
            Check.Width = 67;
            // 
            // ingredienteBindingSource
            // 
            ingredienteBindingSource.DataSource = typeof(Dominio.Entidades.Ingrediente);
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // FormModificaReceita
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(399, 613);
            Controls.Add(dataGridView1);
            Controls.Add(button_Cancelar);
            Controls.Add(button_Salvar);
            Controls.Add(textBox_Validade);
            Controls.Add(textBox_Valor);
            Controls.Add(textBox_Nome);
            Controls.Add(richTextBox_Descricao);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label_Titulo);
            Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormModificaReceita";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FormModificaReceita_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ingredienteBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Titulo;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox5;
        private RichTextBox richTextBox_Descricao;
        private Label label6;
        private TextBox textBox_Nome;
        private TextBox textBox_Valor;
        private TextBox textBox_Validade;
        private Button button_Salvar;
        private Button button_Cancelar;
        private DataGridView dataGridView1;
        private BindingSource ingredienteBindingSource;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn Check;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}