namespace Futoverseny
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button2 = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 5);
            label1.Name = "label1";
            label1.Size = new Size(27, 17);
            label1.TabIndex = 0;
            label1.Text = "Fájl";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 5);
            label2.Name = "label2";
            label2.Size = new Size(89, 17);
            label2.TabIndex = 1;
            label2.Text = "Eredménylista";
            label2.Click += eredménylistaToolStripMenuItem_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(147, 29);
            label3.Name = "label3";
            label3.Size = new Size(183, 27);
            label3.TabIndex = 2;
            label3.Text = "Maratoni futóverseny";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 61);
            label4.Name = "label4";
            label4.Size = new Size(85, 17);
            label4.TabIndex = 3;
            label4.Text = "RÉSZTVEVŐK";
            // 
            // button1
            // 
            button1.Location = new Point(22, 360);
            button1.Name = "button1";
            button1.Size = new Size(133, 25);
            button1.TabIndex = 5;
            button1.Text = "adatBe";
            button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(161, 97);
            label5.Name = "label5";
            label5.Size = new Size(60, 17);
            label5.TabIndex = 6;
            label5.Text = "Rajtszám";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(161, 161);
            label6.Name = "label6";
            label6.Size = new Size(50, 17);
            label6.TabIndex = 7;
            label6.Text = "Ország";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(161, 217);
            label7.Name = "label7";
            label7.Size = new Size(85, 17);
            label7.TabIndex = 8;
            label7.Text = "Időeredmény";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(161, 273);
            label8.Name = "label8";
            label8.Size = new Size(48, 17);
            label8.TabIndex = 9;
            label8.Text = "Életkor";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(223, 94);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(126, 25);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(219, 158);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(130, 25);
            textBox3.TabIndex = 11;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(254, 214);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(95, 25);
            textBox4.TabIndex = 12;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(222, 270);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(127, 25);
            textBox5.TabIndex = 13;
            // 
            // button2
            // 
            button2.Location = new Point(199, 337);
            button2.Name = "button2";
            button2.Size = new Size(121, 31);
            button2.TabIndex = 14;
            button2.Text = "bezár";
            button2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(23, 81);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(132, 276);
            listBox1.TabIndex = 16;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 403);
            Controls.Add(listBox1);
            Controls.Add(button2);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "futóverseny";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button2;
        private ListBox listBox1;
    }
}
