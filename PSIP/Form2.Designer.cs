namespace PSIP
{
    partial class Form2
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
            this.mac_table = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStart = new System.Windows.Forms.Button();
            this.listDevices = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textPacket = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mac_table
            // 
            this.mac_table.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader5});
            this.mac_table.FullRowSelect = true;
            this.mac_table.GridLines = true;
            this.mac_table.HideSelection = false;
            this.mac_table.Location = new System.Drawing.Point(12, 46);
            this.mac_table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mac_table.MultiSelect = false;
            this.mac_table.Name = "mac_table";
            this.mac_table.Size = new System.Drawing.Size(687, 480);
            this.mac_table.TabIndex = 0;
            this.mac_table.UseCompatibleStateImageBehavior = false;
            this.mac_table.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Port";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Source";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Timestamp";
            this.columnHeader5.Width = 100;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(625, 532);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // listDevices
            // 
            this.listDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listDevices.FullRowSelect = true;
            this.listDevices.HideSelection = false;
            this.listDevices.Location = new System.Drawing.Point(719, 47);
            this.listDevices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(804, 105);
            this.listDevices.TabIndex = 3;
            this.listDevices.UseCompatibleStateImageBehavior = false;
            this.listDevices.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Devices";
            this.columnHeader3.Width = 315;
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonReset.ForeColor = System.Drawing.Color.Snow;
            this.buttonReset.Location = new System.Drawing.Point(1463, 2);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(60, 38);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClear.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonClear.Location = new System.Drawing.Point(639, 2);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(61, 38);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textPacket
            // 
            this.textPacket.Location = new System.Drawing.Point(719, 186);
            this.textPacket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textPacket.Multiline = true;
            this.textPacket.Name = "textPacket";
            this.textPacket.Size = new System.Drawing.Size(804, 340);
            this.textPacket.TabIndex = 11;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(519, 532);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(100, 23);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Sthap";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1548, 568);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.textPacket);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.listDevices);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.mac_table);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView mac_table;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ListView listDevices;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textPacket;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button buttonStop;
    }
}