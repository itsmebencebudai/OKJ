namespace mozi_WFA
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ido_label = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mozi = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.szerkesztToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Típus:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(87, 138);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 165);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(635, 284);
            this.dataGridView1.TabIndex = 6;
            // 
            // ido_label
            // 
            this.ido_label.AutoSize = true;
            this.ido_label.Location = new System.Drawing.Point(519, 49);
            this.ido_label.Name = "ido_label";
            this.ido_label.Size = new System.Drawing.Size(25, 13);
            this.ido_label.TabIndex = 10;
            this.ido_label.Text = "Idő:";
            // 
            // button3
            // 
            this.button3.Image = global::mozi_WFA.Properties.Resources.kilep;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(260, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 88);
            this.button3.TabIndex = 9;
            this.button3.Text = "Kilép";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::mozi_WFA.Properties.Resources.ember;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(182, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 88);
            this.button2.TabIndex = 8;
            this.button2.Text = "Ember";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::mozi_WFA.Properties.Resources.film;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(104, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 88);
            this.button1.TabIndex = 7;
            this.button1.Text = "FIlm";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // mozi
            // 
            this.mozi.Image = global::mozi_WFA.Properties.Resources.mozi2;
            this.mozi.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mozi.Location = new System.Drawing.Point(26, 18);
            this.mozi.Name = "mozi";
            this.mozi.Size = new System.Drawing.Size(72, 88);
            this.mozi.TabIndex = 0;
            this.mozi.Text = "Mozi";
            this.mozi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mozi.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.szerkesztToolStripMenuItem,
            this.keresToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 48);
            // 
            // szerkesztToolStripMenuItem
            // 
            this.szerkesztToolStripMenuItem.Name = "szerkesztToolStripMenuItem";
            this.szerkesztToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.szerkesztToolStripMenuItem.Text = "Szerkeszt";
            this.szerkesztToolStripMenuItem.Click += new System.EventHandler(this.SzerkesztToolStripMenuItem_Click);
            // 
            // keresToolStripMenuItem
            // 
            this.keresToolStripMenuItem.Name = "keresToolStripMenuItem";
            this.keresToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.keresToolStripMenuItem.Text = "Keres";
            this.keresToolStripMenuItem.Click += new System.EventHandler(this.KeresToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.ido_label);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mozi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Moziműsor";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mozi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label ido_label;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem szerkesztToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keresToolStripMenuItem;
    }
}

