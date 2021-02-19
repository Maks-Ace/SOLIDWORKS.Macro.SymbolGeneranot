namespace SymbolCodeGenerator
{
    partial class SymbolGenFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbolGenFrm));
            this.BeginCreationCmd = new System.Windows.Forms.Button();
            this.SymbolCodeText = new System.Windows.Forms.RichTextBox();
            this.GeneraCodeCmd = new System.Windows.Forms.Button();
            this.ExitCmd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openSymFileCmd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BeginCreationCmd
            // 
            this.BeginCreationCmd.Location = new System.Drawing.Point(27, 190);
            this.BeginCreationCmd.Name = "BeginCreationCmd";
            this.BeginCreationCmd.Size = new System.Drawing.Size(132, 44);
            this.BeginCreationCmd.TabIndex = 0;
            this.BeginCreationCmd.Text = "Новое пространство";
            this.BeginCreationCmd.UseVisualStyleBackColor = true;
            this.BeginCreationCmd.Click += new System.EventHandler(this.BeginCreationCmd_Click);
            // 
            // SymbolCodeText
            // 
            this.SymbolCodeText.Location = new System.Drawing.Point(201, 31);
            this.SymbolCodeText.Name = "SymbolCodeText";
            this.SymbolCodeText.ReadOnly = true;
            this.SymbolCodeText.Size = new System.Drawing.Size(314, 269);
            this.SymbolCodeText.TabIndex = 1;
            this.SymbolCodeText.Text = "";
            // 
            // GeneraCodeCmd
            // 
            this.GeneraCodeCmd.Location = new System.Drawing.Point(27, 31);
            this.GeneraCodeCmd.Name = "GeneraCodeCmd";
            this.GeneraCodeCmd.Size = new System.Drawing.Size(132, 49);
            this.GeneraCodeCmd.TabIndex = 2;
            this.GeneraCodeCmd.Text = "Сгенерировать код символа";
            this.GeneraCodeCmd.UseVisualStyleBackColor = true;
            this.GeneraCodeCmd.Click += new System.EventHandler(this.GeneraCodeCmd_Click);
            // 
            // ExitCmd
            // 
            this.ExitCmd.Location = new System.Drawing.Point(27, 256);
            this.ExitCmd.Name = "ExitCmd";
            this.ExitCmd.Size = new System.Drawing.Size(132, 44);
            this.ExitCmd.TabIndex = 3;
            this.ExitCmd.Text = "Отмена";
            this.ExitCmd.UseVisualStyleBackColor = true;
            this.ExitCmd.Click += new System.EventHandler(this.ExitCmd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.openSymFileCmd);
            this.groupBox1.Controls.Add(this.ExitCmd);
            this.groupBox1.Controls.Add(this.GeneraCodeCmd);
            this.groupBox1.Controls.Add(this.SymbolCodeText);
            this.groupBox1.Controls.Add(this.BeginCreationCmd);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 320);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // openSymFileCmd
            // 
            this.openSymFileCmd.Location = new System.Drawing.Point(27, 109);
            this.openSymFileCmd.Name = "openSymFileCmd";
            this.openSymFileCmd.Size = new System.Drawing.Size(132, 49);
            this.openSymFileCmd.TabIndex = 4;
            this.openSymFileCmd.Text = "Открыть файл с символами";
            this.openSymFileCmd.UseVisualStyleBackColor = true;
            this.openSymFileCmd.Click += new System.EventHandler(this.openSymFileCmd_Click);
            // 
            // SymbolGenFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 348);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SymbolGenFrm";
            this.Text = "Генератор символов v1.0";
            this.Load += new System.EventHandler(this.SymbolGenFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BeginCreationCmd;
        private System.Windows.Forms.RichTextBox SymbolCodeText;
        private System.Windows.Forms.Button GeneraCodeCmd;
        private System.Windows.Forms.Button ExitCmd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button openSymFileCmd;
    }
}