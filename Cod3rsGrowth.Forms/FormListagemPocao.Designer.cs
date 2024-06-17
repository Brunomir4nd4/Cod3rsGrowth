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
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idReceitaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataDeFabricaçãoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            vencidoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            pocaoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pocaoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, idReceitaDataGridViewTextBoxColumn, dataDeFabricaçãoDataGridViewTextBoxColumn, vencidoDataGridViewCheckBoxColumn });
            dataGridView1.DataSource = pocaoBindingSource;
            dataGridView1.Location = new Point(180, 88);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(445, 49);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // idReceitaDataGridViewTextBoxColumn
            // 
            idReceitaDataGridViewTextBoxColumn.DataPropertyName = "IdReceita";
            idReceitaDataGridViewTextBoxColumn.HeaderText = "IdReceita";
            idReceitaDataGridViewTextBoxColumn.Name = "idReceitaDataGridViewTextBoxColumn";
            // 
            // dataDeFabricaçãoDataGridViewTextBoxColumn
            // 
            dataDeFabricaçãoDataGridViewTextBoxColumn.DataPropertyName = "DataDeFabricação";
            dataDeFabricaçãoDataGridViewTextBoxColumn.HeaderText = "DataDeFabricação";
            dataDeFabricaçãoDataGridViewTextBoxColumn.Name = "dataDeFabricaçãoDataGridViewTextBoxColumn";
            // 
            // vencidoDataGridViewCheckBoxColumn
            // 
            vencidoDataGridViewCheckBoxColumn.DataPropertyName = "Vencido";
            vencidoDataGridViewCheckBoxColumn.HeaderText = "Vencido";
            vencidoDataGridViewCheckBoxColumn.Name = "vencidoDataGridViewCheckBoxColumn";
            // 
            // pocaoBindingSource
            // 
            pocaoBindingSource.DataSource = typeof(Dominio.Entidades.Pocao);
            // 
            // FormListagemPocao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 449);
            Controls.Add(dataGridView1);
            Name = "FormListagemPocao";
            Text = "FormListagemPocao";
            Load += FormListagemPocao_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pocaoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idReceitaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDeFabricaçãoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn vencidoDataGridViewCheckBoxColumn;
        private BindingSource pocaoBindingSource;
    }
}