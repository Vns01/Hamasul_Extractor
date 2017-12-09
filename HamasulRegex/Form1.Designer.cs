namespace HamasulRegex
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnFile = new System.Windows.Forms.Button();
            this.opfDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.numRegistros = new System.Windows.Forms.NumericUpDown();
            this.lblQntd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(306, 45);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(40, 27);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // opfDialog
            // 
            this.opfDialog.FileName = "Selecione um arquivo texto";
            this.opfDialog.InitialDirectory = "c:\\\\";
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(34, 50);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(250, 22);
            this.txtPath.TabIndex = 1;
            // 
            // numRegistros
            // 
            this.numRegistros.Location = new System.Drawing.Point(163, 104);
            this.numRegistros.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRegistros.Name = "numRegistros";
            this.numRegistros.Size = new System.Drawing.Size(120, 22);
            this.numRegistros.TabIndex = 2;
            this.numRegistros.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblQntd
            // 
            this.lblQntd.AutoSize = true;
            this.lblQntd.Location = new System.Drawing.Point(34, 106);
            this.lblQntd.Name = "lblQntd";
            this.lblQntd.Size = new System.Drawing.Size(123, 17);
            this.lblQntd.TabIndex = 3;
            this.lblQntd.Text = "Qntd de Registros";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 183);
            this.Controls.Add(this.lblQntd);
            this.Controls.Add(this.numRegistros);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extractor v.0.4";
            ((System.ComponentModel.ISupportInitialize)(this.numRegistros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.OpenFileDialog opfDialog;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.NumericUpDown numRegistros;
        private System.Windows.Forms.Label lblQntd;
    }
}

