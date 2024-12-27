namespace WindowsFormsApp3
{
    partial class SizeSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btn2x2;
        private System.Windows.Forms.Button btn3x3;
        private System.Windows.Forms.Button btn4x4;
        private System.Windows.Forms.Button btn5x5;

        private void InitializeComponent()
        {
            this.btn2x2 = new System.Windows.Forms.Button();
            this.btn3x3 = new System.Windows.Forms.Button();
            this.btn4x4 = new System.Windows.Forms.Button();
            this.btn5x5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn2x2
            // 
            this.btn2x2.Location = new System.Drawing.Point(50, 50);
            this.btn2x2.Name = "btn2x2";
            this.btn2x2.Size = new System.Drawing.Size(75, 23);
            this.btn2x2.TabIndex = 0;
            this.btn2x2.Text = "2x2";
            this.btn2x2.UseVisualStyleBackColor = true;
            this.btn2x2.Click += new System.EventHandler(this.btn2x2_Click);
            // 
            // btn3x3
            // 
            this.btn3x3.Location = new System.Drawing.Point(50, 100);
            this.btn3x3.Name = "btn3x3";
            this.btn3x3.Size = new System.Drawing.Size(75, 23);
            this.btn3x3.TabIndex = 1;
            this.btn3x3.Text = "3x3";
            this.btn3x3.UseVisualStyleBackColor = true;
            this.btn3x3.Click += new System.EventHandler(this.btn3x3_Click);
            // 
            // btn4x4
            // 
            this.btn4x4.Location = new System.Drawing.Point(50, 150);
            this.btn4x4.Name = "btn4x4";
            this.btn4x4.Size = new System.Drawing.Size(75, 23);
            this.btn4x4.TabIndex = 2;
            this.btn4x4.Text = "4x4";
            this.btn4x4.UseVisualStyleBackColor = true;
            this.btn4x4.Click += new System.EventHandler(this.btn4x4_Click);
            
            // 
            // SizeSelectionForm
            // 
            this.ClientSize = new System.Drawing.Size(200, 300);
            this.Controls.Add(this.btn5x5);
            this.Controls.Add(this.btn4x4);
            this.Controls.Add(this.btn3x3);
            this.Controls.Add(this.btn2x2);
            this.Name = "SizeSelectionForm";
            this.Text = "Select Size";
            this.ResumeLayout(false);
        }
    }
}
