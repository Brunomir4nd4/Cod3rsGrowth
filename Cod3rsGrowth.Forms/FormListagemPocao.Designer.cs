namespace Cod3rsGrowth.Forms
{
    partial class FormListagemPocao
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
            pocaoBindingSource = new BindingSource(components);
            pocaoBindingSource1 = new BindingSource(components);
            painel_de_filtragem = new Panel();
            checkBox1 = new CheckBox();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button_Filtro = new Button();
            textBox1 = new TextBox();
            vencidoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataDeFabricacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idReceitaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            button_Adicionar = new Button();
            button_Editar = new Button();
            button_Remover = new Button();
            ((System.ComponentModel.ISupportInitialize)pocaoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pocaoBindingSource1).BeginInit();
            painel_de_filtragem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pocaoBindingSource
            // 
            pocaoBindingSource.DataSource = typeof(Dominio.Entidades.Pocao);
            // 
            // pocaoBindingSource1
            // 
            pocaoBindingSource1.DataSource = typeof(Dominio.Entidades.Pocao);
            // 
            // painel_de_filtragem
            // 
            painel_de_filtragem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            painel_de_filtragem.BackColor = Color.White;
            painel_de_filtragem.Controls.Add(checkBox1);
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
            painel_de_filtragem.Size = new Size(801, 68);
            painel_de_filtragem.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(652, 40);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 12;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top;
            textBox5.Location = new Point(267, 36);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 10;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(582, 38);
            label5.Name = "label5";
            label5.Size = new Size(64, 17);
            label5.TabIndex = 8;
            label5.Text = "Vencido";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top;
            textBox3.Location = new Point(461, 35);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 7;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(411, 38);
            label4.Name = "label4";
            label4.Size = new Size(40, 17);
            label4.TabIndex = 6;
            label4.Text = "Data";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(173, 38);
            label3.Name = "label3";
            label3.Size = new Size(88, 17);
            label3.TabIndex = 4;
            label3.Text = "Id_Receita";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("JetBrains Mono SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(33, 38);
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
            textBox1.Location = new Point(63, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(71, 23);
            textBox1.TabIndex = 0;
            // 
            // vencidoDataGridViewCheckBoxColumn
            // 
            vencidoDataGridViewCheckBoxColumn.DataPropertyName = "Vencido";
            vencidoDataGridViewCheckBoxColumn.HeaderText = "Vencido";
            vencidoDataGridViewCheckBoxColumn.Name = "vencidoDataGridViewCheckBoxColumn";
            // 
            // dataDeFabricacaoDataGridViewTextBoxColumn
            // 
            dataDeFabricacaoDataGridViewTextBoxColumn.DataPropertyName = "DataDeFabricacao";
            dataDeFabricacaoDataGridViewTextBoxColumn.HeaderText = "Data De Fabricacao";
            dataDeFabricacaoDataGridViewTextBoxColumn.Name = "dataDeFabricacaoDataGridViewTextBoxColumn";
            // 
            // idReceitaDataGridViewTextBoxColumn
            // 
            idReceitaDataGridViewTextBoxColumn.DataPropertyName = "IdReceita";
            idReceitaDataGridViewTextBoxColumn.HeaderText = "IdReceita";
            idReceitaDataGridViewTextBoxColumn.Name = "idReceitaDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, idReceitaDataGridViewTextBoxColumn, dataDeFabricacaoDataGridViewTextBoxColumn, vencidoDataGridViewCheckBoxColumn });
            dataGridView1.DataSource = pocaoBindingSource;
            dataGridView1.Location = new Point(0, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(801, 376);
            dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(button_Adicionar);
            panel1.Controls.Add(button_Editar);
            panel1.Controls.Add(button_Remover);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 411);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 38);
            panel1.TabIndex = 4;
            // 
            // button_Adicionar
            // 
            button_Adicionar.Anchor = AnchorStyles.Right;
            button_Adicionar.Cursor = Cursors.Hand;
            button_Adicionar.Location = new Point(482, 6);
            button_Adicionar.Margin = new Padding(0);
            button_Adicionar.Name = "button_Adicionar";
            button_Adicionar.Size = new Size(75, 23);
            button_Adicionar.TabIndex = 12;
            button_Adicionar.Text = "Adicionar";
            button_Adicionar.UseVisualStyleBackColor = true;
            // 
            // button_Editar
            // 
            button_Editar.Anchor = AnchorStyles.Right;
            button_Editar.Cursor = Cursors.Hand;
            button_Editar.Location = new Point(568, 6);
            button_Editar.Margin = new Padding(0);
            button_Editar.Name = "button_Editar";
            button_Editar.Size = new Size(75, 23);
            button_Editar.TabIndex = 11;
            button_Editar.Text = "Editar";
            button_Editar.UseVisualStyleBackColor = true;
            // 
            // button_Remover
            // 
            button_Remover.Anchor = AnchorStyles.Right;
            button_Remover.Cursor = Cursors.Hand;
            button_Remover.Location = new Point(652, 6);
            button_Remover.Margin = new Padding(0);
            button_Remover.Name = "button_Remover";
            button_Remover.Size = new Size(75, 23);
            button_Remover.TabIndex = 10;
            button_Remover.Text = "Remover";
            button_Remover.UseVisualStyleBackColor = true;
            // 
            // FormListagemPocao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 449);
            Controls.Add(panel1);
            Controls.Add(painel_de_filtragem);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormListagemPocao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estoque das Pocoes";
            Load += FormListagemPocao_Load;
            ((System.ComponentModel.ISupportInitialize)pocaoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pocaoBindingSource1).EndInit();
            painel_de_filtragem.ResumeLayout(false);
            painel_de_filtragem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridViewTextBoxColumn dataDeFabricaçãoDataGridViewTextBoxColumn;
        private BindingSource pocaoBindingSource;
        private BindingSource pocaoBindingSource1;
        private Panel painel_de_filtragem;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button_Filtro;
        private TextBox textBox1;
        private DataGridViewCheckBoxColumn vencidoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataDeFabricacaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idReceitaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button button_Adicionar;
        private Button button_Editar;
        private Button button_Remover;
        private TextBox textBox5;
        private CheckBox checkBox1;
    }
}