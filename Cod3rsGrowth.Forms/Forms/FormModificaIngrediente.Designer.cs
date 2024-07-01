namespace Cod3rsGrowth.Forms
{
    partial class FormModificaIngrediente
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
            textBox_Nome = new TextBox();
            textBox_Quantidade = new TextBox();
            label_Nome = new Label();
            label_Quantidade = new Label();
            label_Naturalidade = new Label();
            comboBox_Naturalidade = new ComboBox();
            label_Cabecalho = new Label();
            button_Salvar = new Button();
            button_Cancelar = new Button();
            SuspendLayout();
            // 
            // textBox_Nome
            // 
            textBox_Nome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Nome.Location = new Point(12, 89);
            textBox_Nome.Name = "textBox_Nome";
            textBox_Nome.PlaceholderText = "Nome...";
            textBox_Nome.Size = new Size(375, 23);
            textBox_Nome.TabIndex = 0;
            // 
            // textBox_Quantidade
            // 
            textBox_Quantidade.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Quantidade.Location = new Point(12, 175);
            textBox_Quantidade.Name = "textBox_Quantidade";
            textBox_Quantidade.PlaceholderText = "Quantidade...";
            textBox_Quantidade.Size = new Size(375, 23);
            textBox_Quantidade.TabIndex = 2;
            // 
            // label_Nome
            // 
            label_Nome.AutoSize = true;
            label_Nome.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_Nome.Location = new Point(12, 67);
            label_Nome.Name = "label_Nome";
            label_Nome.Size = new Size(45, 19);
            label_Nome.TabIndex = 4;
            label_Nome.Text = "Nome";
            // 
            // label_Quantidade
            // 
            label_Quantidade.AutoSize = true;
            label_Quantidade.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_Quantidade.Location = new Point(12, 153);
            label_Quantidade.Name = "label_Quantidade";
            label_Quantidade.Size = new Size(99, 19);
            label_Quantidade.TabIndex = 5;
            label_Quantidade.Text = "Quantidade";
            // 
            // label_Naturalidade
            // 
            label_Naturalidade.AutoSize = true;
            label_Naturalidade.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_Naturalidade.Location = new Point(12, 237);
            label_Naturalidade.Name = "label_Naturalidade";
            label_Naturalidade.Size = new Size(117, 19);
            label_Naturalidade.TabIndex = 6;
            label_Naturalidade.Text = "Naturalidade";
            // 
            // comboBox_Naturalidade
            // 
            comboBox_Naturalidade.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox_Naturalidade.FormattingEnabled = true;
            comboBox_Naturalidade.Location = new Point(12, 259);
            comboBox_Naturalidade.Name = "comboBox_Naturalidade";
            comboBox_Naturalidade.Size = new Size(375, 24);
            comboBox_Naturalidade.TabIndex = 8;
            // 
            // label_Cabecalho
            // 
            label_Cabecalho.AutoSize = true;
            label_Cabecalho.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Cabecalho.Location = new Point(46, 20);
            label_Cabecalho.Name = "label_Cabecalho";
            label_Cabecalho.Size = new Size(0, 27);
            label_Cabecalho.TabIndex = 9;
            // 
            // button_Salvar
            // 
            button_Salvar.Cursor = Cursors.Hand;
            button_Salvar.Location = new Point(12, 350);
            button_Salvar.Name = "button_Salvar";
            button_Salvar.Size = new Size(73, 26);
            button_Salvar.TabIndex = 10;
            button_Salvar.Text = "Salvar";
            button_Salvar.UseVisualStyleBackColor = true;
            // 
            // button_Cancelar
            // 
            button_Cancelar.Cursor = Cursors.Hand;
            button_Cancelar.Location = new Point(314, 350);
            button_Cancelar.Name = "button_Cancelar";
            button_Cancelar.Size = new Size(73, 26);
            button_Cancelar.TabIndex = 11;
            button_Cancelar.Text = "Cancelar";
            button_Cancelar.UseVisualStyleBackColor = true;
            button_Cancelar.Click += AoClicarFcharForms;
            // 
            // FormModificaIngrediente
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(399, 413);
            Controls.Add(button_Cancelar);
            Controls.Add(button_Salvar);
            Controls.Add(label_Cabecalho);
            Controls.Add(comboBox_Naturalidade);
            Controls.Add(label_Naturalidade);
            Controls.Add(label_Quantidade);
            Controls.Add(label_Nome);
            Controls.Add(textBox_Quantidade);
            Controls.Add(textBox_Nome);
            Font = new Font("JetBrains Mono", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormModificaIngrediente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Criar Ingrediente";
            Load += FormModificaIngrediente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_Nome;
        private TextBox textBox_Quantidade;
        private Label label_Nome;
        private Label label_Quantidade;
        private Label label_Naturalidade;
        private ComboBox comboBox_Naturalidade;
        private Label label_Cabecalho;
        private Button button_Salvar;
        private Button button_Cancelar;
    }
}