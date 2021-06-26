namespace TabacchiFinale.Carrello
{
    partial class Carrello
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
            this.picProdotto = new System.Windows.Forms.PictureBox();
            this.nomeProd = new System.Windows.Forms.Label();
            this.prezzoProd = new System.Windows.Forms.Label();
            this.prezzoTot = new System.Windows.Forms.Label();
            this.btnMeno = new System.Windows.Forms.Button();
            this.btnPiu = new System.Windows.Forms.Button();
            this.quantitaProd = new System.Windows.Forms.Label();
            this.btnX = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProdotto)).BeginInit();
            this.SuspendLayout();
            // 
            // picProdotto
            // 
            this.picProdotto.Location = new System.Drawing.Point(94, 12);
            this.picProdotto.Name = "picProdotto";
            this.picProdotto.Size = new System.Drawing.Size(213, 274);
            this.picProdotto.TabIndex = 0;
            this.picProdotto.TabStop = false;
            // 
            // nomeProd
            // 
            this.nomeProd.AutoSize = true;
            this.nomeProd.Location = new System.Drawing.Point(170, 322);
            this.nomeProd.Name = "nomeProd";
            this.nomeProd.Size = new System.Drawing.Size(55, 13);
            this.nomeProd.TabIndex = 2;
            this.nomeProd.Text = "nomeProd";
            // 
            // prezzoProd
            // 
            this.prezzoProd.AutoSize = true;
            this.prezzoProd.Location = new System.Drawing.Point(372, 92);
            this.prezzoProd.Name = "prezzoProd";
            this.prezzoProd.Size = new System.Drawing.Size(35, 13);
            this.prezzoProd.TabIndex = 3;
            this.prezzoProd.Text = "label2";
            // 
            // prezzoTot
            // 
            this.prezzoTot.AutoSize = true;
            this.prezzoTot.Location = new System.Drawing.Point(372, 174);
            this.prezzoTot.Name = "prezzoTot";
            this.prezzoTot.Size = new System.Drawing.Size(35, 13);
            this.prezzoTot.TabIndex = 4;
            this.prezzoTot.Text = "label3";
            // 
            // btnMeno
            // 
            this.btnMeno.Location = new System.Drawing.Point(51, 374);
            this.btnMeno.Name = "btnMeno";
            this.btnMeno.Size = new System.Drawing.Size(75, 23);
            this.btnMeno.TabIndex = 5;
            this.btnMeno.Text = "button1";
            this.btnMeno.UseVisualStyleBackColor = true;
            this.btnMeno.Click += new System.EventHandler(this.btnMeno_Click);
            // 
            // btnPiu
            // 
            this.btnPiu.Location = new System.Drawing.Point(263, 374);
            this.btnPiu.Name = "btnPiu";
            this.btnPiu.Size = new System.Drawing.Size(75, 23);
            this.btnPiu.TabIndex = 6;
            this.btnPiu.Text = "button2";
            this.btnPiu.UseVisualStyleBackColor = true;
            this.btnPiu.Click += new System.EventHandler(this.btnPiu_Click);
            // 
            // quantitaProd
            // 
            this.quantitaProd.AutoSize = true;
            this.quantitaProd.Location = new System.Drawing.Point(179, 379);
            this.quantitaProd.Name = "quantitaProd";
            this.quantitaProd.Size = new System.Drawing.Size(35, 13);
            this.quantitaProd.TabIndex = 7;
            this.quantitaProd.Text = "label4";
            // 
            // btnX
            // 
            this.btnX.Location = new System.Drawing.Point(82, 518);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(75, 23);
            this.btnX.TabIndex = 8;
            this.btnX.Text = "button3";
            this.btnX.UseVisualStyleBackColor = true;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(241, 518);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "button4";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Carrello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 576);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.quantitaProd);
            this.Controls.Add(this.btnPiu);
            this.Controls.Add(this.btnMeno);
            this.Controls.Add(this.prezzoTot);
            this.Controls.Add(this.prezzoProd);
            this.Controls.Add(this.nomeProd);
            this.Controls.Add(this.picProdotto);
            this.Name = "Carrello";
            this.Text = "Carrello";
            this.Load += new System.EventHandler(this.Carrello_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProdotto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picProdotto;
        private System.Windows.Forms.Label nomeProd;
        private System.Windows.Forms.Label prezzoProd;
        private System.Windows.Forms.Label prezzoTot;
        private System.Windows.Forms.Button btnMeno;
        private System.Windows.Forms.Button btnPiu;
        private System.Windows.Forms.Label quantitaProd;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnOk;
    }
}