namespace ot_engy
{
    partial class Form1
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
            this.txtFajlPath = new System.Windows.Forms.TextBox();
            this.btnSzamol = new System.Windows.Forms.Button();
            this.lblEredmeny = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFajlPath
            // 
            this.txtFajlPath.Location = new System.Drawing.Point(21, 21);
            this.txtFajlPath.Name = "txtFajlPath";
            this.txtFajlPath.Size = new System.Drawing.Size(100, 20);
            this.txtFajlPath.TabIndex = 0;
            // 
            // btnSzamol
            // 
            this.btnSzamol.Location = new System.Drawing.Point(21, 47);
            this.btnSzamol.Name = "btnSzamol";
            this.btnSzamol.Size = new System.Drawing.Size(75, 23);
            this.btnSzamol.TabIndex = 1;
            this.btnSzamol.Text = "Számol";
            this.btnSzamol.UseVisualStyleBackColor = true;
            this.btnSzamol.Click += new System.EventHandler(this.btnSzamol_Click);
            // 
            // lblEredmeny
            // 
            this.lblEredmeny.AutoSize = true;
            this.lblEredmeny.Location = new System.Drawing.Point(31, 95);
            this.lblEredmeny.Name = "lblEredmeny";
            this.lblEredmeny.Size = new System.Drawing.Size(0, 13);
            this.lblEredmeny.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(153, 147);
            this.Controls.Add(this.lblEredmeny);
            this.Controls.Add(this.btnSzamol);
            this.Controls.Add(this.txtFajlPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFajlPath;
        private System.Windows.Forms.Button btnSzamol;
        private System.Windows.Forms.Label lblEredmeny;
    }
}

