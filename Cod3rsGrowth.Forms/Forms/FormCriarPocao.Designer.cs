namespace Cod3rsGrowth.Forms
{
    partial class FormCriarPocao
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
            button_Cancelar = new Button();
            button_Salvar = new Button();
            label1 = new Label();
            label_Nome = new Label();
            textBox_Nome = new TextBox();
            SuspendLayout();
            // 
            // button_Cancelar
            // 
            button_Cancelar.Cursor = Cursors.Hand;
            button_Cancelar.Location = new Point(314, 334);
            button_Cancelar.Name = "button_Cancelar";
            button_Cancelar.Size = new Size(73, 26);
            button_Cancelar.TabIndex = 20;
            button_Cancelar.Text = "Cancelar";
            button_Cancelar.UseVisualStyleBackColor = true;
            // 
            // button_Salvar
            // 
            button_Salvar.Cursor = Cursors.Hand;
            button_Salvar.Location = new Point(12, 334);
            button_Salvar.Name = "button_Salvar";
            button_Salvar.Size = new Size(120, 26);
            button_Salvar.TabIndex = 19;
            button_Salvar.Text = "Salvar Criação";
            button_Salvar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("JetBrains Mono", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(47, 19);
            label1.Name = "label1";
            label1.Size = new Size(298, 27);
            label1.TabIndex = 18;
            label1.Text = "Criação do Ingrediente";
            // 
            // label_Nome
            // 
            label_Nome.AutoSize = true;
            label_Nome.Font = new Font("JetBrains Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_Nome.Location = new Point(12, 67);
            label_Nome.Name = "label_Nome";
            label_Nome.Size = new Size(45, 19);
            label_Nome.TabIndex = 14;
            label_Nome.Text = "Nome";
            // 
            // textBox_Nome
            // 
            textBox_Nome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Nome.Location = new Point(12, 89);
            textBox_Nome.Name = "textBox_Nome";
            textBox_Nome.Size = new Size(375, 23);
            textBox_Nome.TabIndex = 21;
            // 
            // FormCriarPocao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(399, 413);
            Controls.Add(textBox_Nome);
            Controls.Add(button_Cancelar);
            Controls.Add(button_Salvar);
            Controls.Add(label1);
            Controls.Add(label_Nome);
            Name = "FormCriarPocao";
            Text = "FormCriarPocao";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Cancelar;
        private Button button_Salvar;
        private Label label1;
        private Label label_Nome;
        private TextBox textBox_Nome;
    }
}