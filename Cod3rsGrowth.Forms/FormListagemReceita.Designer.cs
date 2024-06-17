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
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imagemDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            validadeEmMesesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            receitaBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)receitaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn, valorDataGridViewTextBoxColumn, imagemDataGridViewTextBoxColumn, validadeEmMesesDataGridViewTextBoxColumn });
            dataGridView1.DataSource = receitaBindingSource;
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(800, 450);
            dataGridView1.TabIndex = 0;
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
            // descricaoDataGridViewTextBoxColumn
            // 
            descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            // 
            // valorDataGridViewTextBoxColumn
            // 
            valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            // 
            // imagemDataGridViewTextBoxColumn
            // 
            imagemDataGridViewTextBoxColumn.DataPropertyName = "Imagem";
            imagemDataGridViewTextBoxColumn.HeaderText = "Imagem";
            imagemDataGridViewTextBoxColumn.Name = "imagemDataGridViewTextBoxColumn";
            // 
            // validadeEmMesesDataGridViewTextBoxColumn
            // 
            validadeEmMesesDataGridViewTextBoxColumn.DataPropertyName = "ValidadeEmMeses";
            validadeEmMesesDataGridViewTextBoxColumn.HeaderText = "ValidadeEmMeses";
            validadeEmMesesDataGridViewTextBoxColumn.Name = "validadeEmMesesDataGridViewTextBoxColumn";
            // 
            // receitaBindingSource
            // 
            receitaBindingSource.DataSource = typeof(Dominio.Entidades.Receita);
            // 
            // FormListagemReceita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "FormListagemReceita";
            Text = "FormListagemReceita";
            Load += FormListagemReceita_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)receitaBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imagemDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn validadeEmMesesDataGridViewTextBoxColumn;
        private BindingSource receitaBindingSource;
    }
}