namespace Cod3rsGrowth.Forms
{
    partial class FormModificaPocao
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
            button_Cancelar = new Button();
            button_Salvar = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            ingredienteBindingSource = new BindingSource(components);
            label6 = new Label();
            Nome = new DataGridViewTextBoxColumn();
            Check = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ingredienteBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button_Cancelar
            // 
            button_Cancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Cancelar.Cursor = Cursors.Hand;
            button_Cancelar.Location = new Point(314, 382);
            button_Cancelar.Name = "button_Cancelar";
            button_Cancelar.Size = new Size(73, 28);
            button_Cancelar.TabIndex = 20;
            button_Cancelar.Text = "Cancelar";
            button_Cancelar.UseVisualStyleBackColor = true;
            button_Cancelar.Click += AoClicarFecharForms;
            // 
            // button_Salvar
            // 
            button_Salvar.Cursor = Cursors.Hand;
            button_Salvar.Location = new Point(12, 382);
            button_Salvar.Name = "button_Salvar";
            button_Salvar.Size = new Size(73, 28);
            button_Salvar.TabIndex = 19;
            button_Salvar.Text = "Salvar";
            button_Salvar.UseVisualStyleBackColor = true;
            button_Salvar.Click += AoClicarSalvarCriacaoPocao;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(90, 18);
            label1.Name = "label1";
            label1.Size = new Size(220, 27);
            label1.TabIndex = 18;
            label1.Text = "Criação da Poção";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Nome, Check });
            dataGridView1.DataSource = ingredienteBindingSource;
            dataGridView1.Location = new Point(12, 102);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(375, 247);
            dataGridView1.TabIndex = 39;
            // 
            // ingredienteBindingSource
            // 
            ingredienteBindingSource.DataSource = typeof(Dominio.Entidades.Ingrediente);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 69);
            label6.Name = "label6";
            label6.Size = new Size(117, 19);
            label6.TabIndex = 38;
            label6.Text = "Ingredientes";
            // 
            // Nome
            // 
            Nome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nome.DataPropertyName = "Nome";
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
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
            // FormCriarPocao
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(399, 441);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            Controls.Add(button_Cancelar);
            Controls.Add(button_Salvar);
            Controls.Add(label1);
            Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormCriarPocao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Criar Pocao";
            Load += FormModificaPocao_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ingredienteBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Cancelar;
        private Button button_Salvar;
        private Label label1;
        private DataGridView dataGridView1;
        private BindingSource ingredienteBindingSource;
        private Label label6;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewCheckBoxColumn Check;
    }
}