using Cod3rsGrowth.Dominio.Migradores;

namespace Cod3rsGrowth.Forms
{
    partial class FormListagemIngrediente
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ingredienteBindingSource = new BindingSource(components);
            migradorBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            naturalidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            painel_de_filtragem = new Panel();
            comboBox1 = new ComboBox();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button_Filtro = new Button();
            textBox1 = new TextBox();
            button_Adicionar = new Button();
            button_Editar = new Button();
            button_Remover = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)ingredienteBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)migradorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            painel_de_filtragem.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ingredienteBindingSource
            // 
            ingredienteBindingSource.DataSource = typeof(Dominio.Entidades.Ingrediente);
            // 
            // migradorBindingSource
            // 
            migradorBindingSource.DataSource = typeof(Migrador);
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, quantidadeDataGridViewTextBoxColumn, naturalidadeDataGridViewTextBoxColumn });
            dataGridView1.DataSource = ingredienteBindingSource;
            dataGridView1.Location = new Point(0, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(800, 344);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            // 
            // naturalidadeDataGridViewTextBoxColumn
            // 
            naturalidadeDataGridViewTextBoxColumn.DataPropertyName = "Naturalidade";
            naturalidadeDataGridViewTextBoxColumn.HeaderText = "Naturalidade";
            naturalidadeDataGridViewTextBoxColumn.Name = "naturalidadeDataGridViewTextBoxColumn";
            // 
            // painel_de_filtragem
            // 
            painel_de_filtragem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            painel_de_filtragem.BackColor = Color.White;
            painel_de_filtragem.Controls.Add(comboBox1);
            painel_de_filtragem.Controls.Add(textBox5);
            painel_de_filtragem.Controls.Add(label5);
            painel_de_filtragem.Controls.Add(textBox3);
            painel_de_filtragem.Controls.Add(label4);
            painel_de_filtragem.Controls.Add(label3);
            painel_de_filtragem.Controls.Add(label2);
            painel_de_filtragem.Controls.Add(label1);
            painel_de_filtragem.Controls.Add(button_Filtro);
            painel_de_filtragem.Controls.Add(textBox1);
            painel_de_filtragem.Location = new Point(0, 0);
            painel_de_filtragem.Name = "painel_de_filtragem";
            painel_de_filtragem.Size = new Size(800, 68);
            painel_de_filtragem.TabIndex = 3;
            painel_de_filtragem.Paint += painel_de_filtragem_Paint;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "OverWorld", "Nather", "TheEnd" });
            comboBox1.Location = new Point(598, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(109, 23);
            comboBox1.TabIndex = 11;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top;
            textBox5.Location = new Point(169, 37);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 10;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(488, 39);
            label5.Name = "label5";
            label5.Size = new Size(104, 17);
            label5.TabIndex = 8;
            label5.Text = "Naturalidade";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top;
            textBox3.Location = new Point(378, 35);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 7;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(284, 38);
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
            label3.Location = new Point(123, 40);
            label3.Name = "label3";
            label3.Size = new Size(40, 17);
            label3.TabIndex = 4;
            label3.Text = "Nome";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(13, 37);
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
            label1.Location = new Point(388, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 19);
            label1.TabIndex = 2;
            label1.Text = "Filtro";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button_Filtro
            // 
            button_Filtro.Anchor = AnchorStyles.Top;
            button_Filtro.Cursor = Cursors.Hand;
            button_Filtro.Location = new Point(713, 35);
            button_Filtro.Name = "button_Filtro";
            button_Filtro.Size = new Size(75, 23);
            button_Filtro.TabIndex = 1;
            button_Filtro.Text = "Filtrar";
            button_Filtro.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.Location = new Point(43, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(71, 23);
            textBox1.TabIndex = 0;
            // 
            // button_Adicionar
            // 
            button_Adicionar.Anchor = AnchorStyles.Right;
            button_Adicionar.Cursor = Cursors.Hand;
            button_Adicionar.Location = new Point(485, 3);
            button_Adicionar.Margin = new Padding(0);
            button_Adicionar.Name = "button_Adicionar";
            button_Adicionar.Size = new Size(75, 23);
            button_Adicionar.TabIndex = 15;
            button_Adicionar.Text = "Adicionar";
            button_Adicionar.UseVisualStyleBackColor = true;
            // 
            // button_Editar
            // 
            button_Editar.Anchor = AnchorStyles.Right;
            button_Editar.Cursor = Cursors.Hand;
            button_Editar.Location = new Point(571, 3);
            button_Editar.Margin = new Padding(0);
            button_Editar.Name = "button_Editar";
            button_Editar.Size = new Size(75, 23);
            button_Editar.TabIndex = 14;
            button_Editar.Text = "Editar";
            button_Editar.UseVisualStyleBackColor = true;
            // 
            // button_Remover
            // 
            button_Remover.Anchor = AnchorStyles.Right;
            button_Remover.Cursor = Cursors.Hand;
            button_Remover.Location = new Point(655, 3);
            button_Remover.Margin = new Padding(0);
            button_Remover.Name = "button_Remover";
            button_Remover.Size = new Size(75, 23);
            button_Remover.TabIndex = 13;
            button_Remover.Text = "Remover";
            button_Remover.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(button_Remover);
            panel1.Controls.Add(button_Adicionar);
            panel1.Controls.Add(button_Editar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 415);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 35);
            panel1.TabIndex = 16;
            // 
            // FormListagemIngrediente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(painel_de_filtragem);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormListagemIngrediente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estoque dos Ingredientes";
            Load += FormListagemIngrediente_Load;
            ((System.ComponentModel.ISupportInitialize)ingredienteBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)migradorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            painel_de_filtragem.ResumeLayout(false);
            painel_de_filtragem.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private BindingSource migradorBindingSource;
        private BindingSource ingredienteBindingSource;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn naturalidadeDataGridViewTextBoxColumn;
        private Panel painel_de_filtragem;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button_Filtro;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button button_Adicionar;
        private Button button_Editar;
        private Button button_Remover;
        private Panel panel1;
    }
}
