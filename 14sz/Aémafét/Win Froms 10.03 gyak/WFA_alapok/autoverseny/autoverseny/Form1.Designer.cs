
namespace autoverseny
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
            this.label1 = new System.Windows.Forms.Label();
            this.feladatoklista_combobox = new System.Windows.Forms.ComboBox();
            this.lekerdezes_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eredmeny_listbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A feladatok:";
            // 
            // feladatoklista_combobox
            // 
            this.feladatoklista_combobox.AllowDrop = true;
            this.feladatoklista_combobox.FormattingEnabled = true;
            this.feladatoklista_combobox.Location = new System.Drawing.Point(15, 41);
            this.feladatoklista_combobox.Name = "feladatoklista_combobox";
            this.feladatoklista_combobox.Size = new System.Drawing.Size(121, 21);
            this.feladatoklista_combobox.TabIndex = 1;
            this.feladatoklista_combobox.SelectedIndexChanged += new System.EventHandler(this.feladatoklista_combobox_SelectedIndexChanged);
            // 
            // lekerdezes_textbox
            // 
            this.lekerdezes_textbox.Location = new System.Drawing.Point(284, 25);
            this.lekerdezes_textbox.Multiline = true;
            this.lekerdezes_textbox.Name = "lekerdezes_textbox";
            this.lekerdezes_textbox.Size = new System.Drawing.Size(480, 58);
            this.lekerdezes_textbox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lekérdezés:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Eredmény:";
            // 
            // eredmeny_listbox
            // 
            this.eredmeny_listbox.FormattingEnabled = true;
            this.eredmeny_listbox.Location = new System.Drawing.Point(284, 118);
            this.eredmeny_listbox.Name = "eredmeny_listbox";
            this.eredmeny_listbox.Size = new System.Drawing.Size(480, 316);
            this.eredmeny_listbox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.eredmeny_listbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lekerdezes_textbox);
            this.Controls.Add(this.feladatoklista_combobox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Autoverseny SQL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox feladatoklista_combobox;
        private System.Windows.Forms.TextBox lekerdezes_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox eredmeny_listbox;
    }
}

