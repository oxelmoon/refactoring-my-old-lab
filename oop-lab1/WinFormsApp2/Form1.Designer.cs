namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelDiscriminant;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.TextBox textBoxX2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelA = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxC = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDiscriminant = new System.Windows.Forms.Label();
            this.textBoxX1 = new System.Windows.Forms.TextBox();
            this.textBoxX2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // labelA
            this.labelA.AutoSize = true;
            this.labelA.Font = new System.Drawing.Font("Arial", 14F);
            this.labelA.Location = new System.Drawing.Point(12, 9);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(91, 22);
            this.labelA.TabIndex = 0;
            this.labelA.Text = "Значення a:";

            // labelB
            this.labelB.AutoSize = true;
            this.labelB.Font = new System.Drawing.Font("Arial", 14F);
            this.labelB.Location = new System.Drawing.Point(12, 41);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(90, 22);
            this.labelB.TabIndex = 1;
            this.labelB.Text = "Значення b:";

            // labelC
            this.labelC.AutoSize = true;
            this.labelC.Font = new System.Drawing.Font("Arial", 14F);
            this.labelC.Location = new System.Drawing.Point(12, 73);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(90, 22);
            this.labelC.TabIndex = 2;
            this.labelC.Text = "Значення c:";

            // textBoxA
            this.textBoxA.Font = new System.Drawing.Font("Arial", 14F);
            this.textBoxA.Location = new System.Drawing.Point(110, 6);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(200, 29);
            this.textBoxA.TabIndex = 3;

            // textBoxB
            this.textBoxB.Font = new System.Drawing.Font("Arial", 14F);
            this.textBoxB.Location = new System.Drawing.Point(110, 38);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(200, 29);
            this.textBoxB.TabIndex = 4;

            // textBoxC
            this.textBoxC.Font = new System.Drawing.Font("Arial", 14F);
            this.textBoxC.Location = new System.Drawing.Point(110, 70);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.Size = new System.Drawing.Size(200, 29);
            this.textBoxC.TabIndex = 5;

            // button1
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Font = new System.Drawing.Font("Arial", 14F);
            this.button1.Location = new System.Drawing.Point(110, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Обчислити";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // labelDiscriminant
            this.labelDiscriminant.AutoSize = true;
            this.labelDiscriminant.Font = new System.Drawing.Font("Arial", 14F);
            this.labelDiscriminant.Location = new System.Drawing.Point(12, 149);
            this.labelDiscriminant.Name = "labelDiscriminant";
            this.labelDiscriminant.Size = new System.Drawing.Size(0, 22);
            this.labelDiscriminant.TabIndex = 7;

            // textBoxX1
            this.textBoxX1.Font = new System.Drawing.Font("Arial", 14F);
            this.textBoxX1.Location = new System.Drawing.Point(110, 179);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.ReadOnly = true;
            this.textBoxX1.Size = new System.Drawing.Size(200, 29);
            this.textBoxX1.TabIndex = 8;

            // textBoxX2
            this.textBoxX2.Font = new System.Drawing.Font("Arial", 14F);
            this.textBoxX2.Location = new System.Drawing.Point(110, 214);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.ReadOnly = true;
            this.textBoxX2.Size = new System.Drawing.Size(200, 29);
            this.textBoxX2.TabIndex = 9;

            // Form1
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.labelDiscriminant);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxC);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторна робота №1. Завдання 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
