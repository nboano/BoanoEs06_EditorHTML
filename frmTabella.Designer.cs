namespace BoanoEs06_EditorHTML
{
    partial class frmTabella
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudRighe = new System.Windows.Forms.NumericUpDown();
            this.nudColonne = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEsci = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudRighe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColonne)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RIGHE";
            // 
            // nudRighe
            // 
            this.nudRighe.Location = new System.Drawing.Point(80, 7);
            this.nudRighe.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRighe.Name = "nudRighe";
            this.nudRighe.Size = new System.Drawing.Size(120, 20);
            this.nudRighe.TabIndex = 1;
            this.nudRighe.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudColonne
            // 
            this.nudColonne.Location = new System.Drawing.Point(80, 38);
            this.nudColonne.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColonne.Name = "nudColonne";
            this.nudColonne.Size = new System.Drawing.Size(120, 20);
            this.nudColonne.TabIndex = 3;
            this.nudColonne.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "COLONNE";
            // 
            // btnEsci
            // 
            this.btnEsci.Location = new System.Drawing.Point(15, 65);
            this.btnEsci.Name = "btnEsci";
            this.btnEsci.Size = new System.Drawing.Size(185, 23);
            this.btnEsci.TabIndex = 4;
            this.btnEsci.Text = "OK";
            this.btnEsci.UseVisualStyleBackColor = true;
            this.btnEsci.Click += new System.EventHandler(this.btnEsci_Click);
            // 
            // frmTabella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 100);
            this.Controls.Add(this.btnEsci);
            this.Controls.Add(this.nudColonne);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudRighe);
            this.Controls.Add(this.label1);
            this.Name = "frmTabella";
            this.Text = "frmTabella";
            ((System.ComponentModel.ISupportInitialize)(this.nudRighe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColonne)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRighe;
        private System.Windows.Forms.NumericUpDown nudColonne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEsci;
    }
}