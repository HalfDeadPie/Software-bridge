namespace PSIP
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
            this.firstDev = new System.Windows.Forms.ListView();
            this.secondDev = new System.Windows.Forms.ListView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstDev
            // 
            this.firstDev.Location = new System.Drawing.Point(50, 12);
            this.firstDev.Name = "firstDev";
            this.firstDev.Size = new System.Drawing.Size(622, 144);
            this.firstDev.TabIndex = 0;
            this.firstDev.UseCompatibleStateImageBehavior = false;
            // 
            // secondDev
            // 
            this.secondDev.Location = new System.Drawing.Point(50, 162);
            this.secondDev.Name = "secondDev";
            this.secondDev.Size = new System.Drawing.Size(622, 145);
            this.secondDev.TabIndex = 1;
            this.secondDev.UseCompatibleStateImageBehavior = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(321, 313);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 456);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.secondDev);
            this.Controls.Add(this.firstDev);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView firstDev;
        private System.Windows.Forms.ListView secondDev;
        private System.Windows.Forms.Button btnOpen;
    }
}