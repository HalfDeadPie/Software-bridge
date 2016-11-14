﻿namespace PSIP
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
            this.btnReset = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labDown0 = new System.Windows.Forms.Label();
            this.labDown1 = new System.Windows.Forms.Label();
            this.labUp0 = new System.Windows.Forms.Label();
            this.labUp1 = new System.Windows.Forms.Label();
            this.labName0 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labDownUDP0 = new System.Windows.Forms.Label();
            this.labUpUDP0 = new System.Windows.Forms.Label();
            this.labDownTCP0 = new System.Windows.Forms.Label();
            this.labUpTCP0 = new System.Windows.Forms.Label();
            this.labDownARP0 = new System.Windows.Forms.Label();
            this.labUpARP0 = new System.Windows.Forms.Label();
            this.labDownICMP0 = new System.Windows.Forms.Label();
            this.labUpICMP0 = new System.Windows.Forms.Label();
            this.labDownDropped0 = new System.Windows.Forms.Label();
            this.labUpDropped0 = new System.Windows.Forms.Label();
            this.labUpDropped1 = new System.Windows.Forms.Label();
            this.labDownDropped1 = new System.Windows.Forms.Label();
            this.labUpICMP1 = new System.Windows.Forms.Label();
            this.labDownICMP1 = new System.Windows.Forms.Label();
            this.labUpARP1 = new System.Windows.Forms.Label();
            this.labDownARP1 = new System.Windows.Forms.Label();
            this.labUpTCP1 = new System.Windows.Forms.Label();
            this.labDownTCP1 = new System.Windows.Forms.Label();
            this.labUpUDP1 = new System.Windows.Forms.Label();
            this.labDownUDP1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.labName1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.filterICMP = new System.Windows.Forms.CheckBox();
            this.filterARP = new System.Windows.Forms.CheckBox();
            this.filterTCP = new System.Windows.Forms.CheckBox();
            this.filterUDP = new System.Windows.Forms.CheckBox();
            this.filterDSTmac = new System.Windows.Forms.TextBox();
            this.filterSRCmac = new System.Windows.Forms.TextBox();
            this.filterDSTip = new System.Windows.Forms.TextBox();
            this.filterSRCip = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.mac_table.Location = new System.Drawing.Point(12, 43);
            this.mac_table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mac_table.MultiSelect = false;
            this.mac_table.Name = "mac_table";
            this.mac_table.Size = new System.Drawing.Size(295, 499);
            this.mac_table.TabIndex = 0;
            this.mac_table.UseCompatibleStateImageBehavior = false;
            this.mac_table.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Port";
            this.columnHeader1.Width = 40;
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
            this.buttonStart.Location = new System.Drawing.Point(227, 549);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReset.ForeColor = System.Drawing.Color.Snow;
            this.btnReset.Location = new System.Drawing.Point(38, 262);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(60, 38);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClear.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonClear.Location = new System.Drawing.Point(247, 0);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(61, 38);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(120, 549);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(100, 23);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Sthap";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Downstream";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Upstream";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Device0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Device1";
            // 
            // labDown0
            // 
            this.labDown0.AutoSize = true;
            this.labDown0.Location = new System.Drawing.Point(420, 75);
            this.labDown0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDown0.Name = "labDown0";
            this.labDown0.Size = new System.Drawing.Size(16, 17);
            this.labDown0.TabIndex = 18;
            this.labDown0.Text = "0";
            // 
            // labDown1
            // 
            this.labDown1.AutoSize = true;
            this.labDown1.Location = new System.Drawing.Point(420, 103);
            this.labDown1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDown1.Name = "labDown1";
            this.labDown1.Size = new System.Drawing.Size(16, 17);
            this.labDown1.TabIndex = 19;
            this.labDown1.Text = "0";
            // 
            // labUp0
            // 
            this.labUp0.AutoSize = true;
            this.labUp0.Location = new System.Drawing.Point(512, 75);
            this.labUp0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUp0.Name = "labUp0";
            this.labUp0.Size = new System.Drawing.Size(16, 17);
            this.labUp0.TabIndex = 20;
            this.labUp0.Text = "0";
            // 
            // labUp1
            // 
            this.labUp1.AutoSize = true;
            this.labUp1.Location = new System.Drawing.Point(512, 103);
            this.labUp1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUp1.Name = "labUp1";
            this.labUp1.Size = new System.Drawing.Size(16, 17);
            this.labUp1.TabIndex = 21;
            this.labUp1.Text = "0";
            // 
            // labName0
            // 
            this.labName0.AutoSize = true;
            this.labName0.Location = new System.Drawing.Point(316, 148);
            this.labName0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labName0.Name = "labName0";
            this.labName0.Size = new System.Drawing.Size(44, 17);
            this.labName0.TabIndex = 26;
            this.labName0.Text = "DEV0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(484, 176);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Upstream";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(388, 176);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "Downstream";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(324, 204);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 17);
            this.label10.TabIndex = 29;
            this.label10.Text = "UDP";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(324, 234);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "TCP";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(324, 261);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 17);
            this.label12.TabIndex = 31;
            this.label12.Text = "ARP";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(324, 289);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 17);
            this.label13.TabIndex = 32;
            this.label13.Text = "ICMP";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(324, 316);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 17);
            this.label14.TabIndex = 33;
            this.label14.Text = "Dropped";
            // 
            // labDownUDP0
            // 
            this.labDownUDP0.AutoSize = true;
            this.labDownUDP0.Location = new System.Drawing.Point(420, 204);
            this.labDownUDP0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDownUDP0.Name = "labDownUDP0";
            this.labDownUDP0.Size = new System.Drawing.Size(16, 17);
            this.labDownUDP0.TabIndex = 34;
            this.labDownUDP0.Text = "0";
            // 
            // labUpUDP0
            // 
            this.labUpUDP0.AutoSize = true;
            this.labUpUDP0.Location = new System.Drawing.Point(512, 204);
            this.labUpUDP0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUpUDP0.Name = "labUpUDP0";
            this.labUpUDP0.Size = new System.Drawing.Size(16, 17);
            this.labUpUDP0.TabIndex = 35;
            this.labUpUDP0.Text = "0";
            // 
            // labDownTCP0
            // 
            this.labDownTCP0.AutoSize = true;
            this.labDownTCP0.Location = new System.Drawing.Point(420, 234);
            this.labDownTCP0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDownTCP0.Name = "labDownTCP0";
            this.labDownTCP0.Size = new System.Drawing.Size(16, 17);
            this.labDownTCP0.TabIndex = 36;
            this.labDownTCP0.Text = "0";
            // 
            // labUpTCP0
            // 
            this.labUpTCP0.AutoSize = true;
            this.labUpTCP0.Location = new System.Drawing.Point(512, 234);
            this.labUpTCP0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUpTCP0.Name = "labUpTCP0";
            this.labUpTCP0.Size = new System.Drawing.Size(16, 17);
            this.labUpTCP0.TabIndex = 37;
            this.labUpTCP0.Text = "0";
            // 
            // labDownARP0
            // 
            this.labDownARP0.AutoSize = true;
            this.labDownARP0.Location = new System.Drawing.Point(420, 261);
            this.labDownARP0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDownARP0.Name = "labDownARP0";
            this.labDownARP0.Size = new System.Drawing.Size(16, 17);
            this.labDownARP0.TabIndex = 38;
            this.labDownARP0.Text = "0";
            // 
            // labUpARP0
            // 
            this.labUpARP0.AutoSize = true;
            this.labUpARP0.Location = new System.Drawing.Point(512, 261);
            this.labUpARP0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUpARP0.Name = "labUpARP0";
            this.labUpARP0.Size = new System.Drawing.Size(16, 17);
            this.labUpARP0.TabIndex = 39;
            this.labUpARP0.Text = "0";
            // 
            // labDownICMP0
            // 
            this.labDownICMP0.AutoSize = true;
            this.labDownICMP0.Location = new System.Drawing.Point(420, 289);
            this.labDownICMP0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDownICMP0.Name = "labDownICMP0";
            this.labDownICMP0.Size = new System.Drawing.Size(16, 17);
            this.labDownICMP0.TabIndex = 40;
            this.labDownICMP0.Text = "0";
            // 
            // labUpICMP0
            // 
            this.labUpICMP0.AutoSize = true;
            this.labUpICMP0.Location = new System.Drawing.Point(512, 289);
            this.labUpICMP0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUpICMP0.Name = "labUpICMP0";
            this.labUpICMP0.Size = new System.Drawing.Size(16, 17);
            this.labUpICMP0.TabIndex = 41;
            this.labUpICMP0.Text = "0";
            // 
            // labDownDropped0
            // 
            this.labDownDropped0.AutoSize = true;
            this.labDownDropped0.Location = new System.Drawing.Point(420, 316);
            this.labDownDropped0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDownDropped0.Name = "labDownDropped0";
            this.labDownDropped0.Size = new System.Drawing.Size(16, 17);
            this.labDownDropped0.TabIndex = 42;
            this.labDownDropped0.Text = "0";
            // 
            // labUpDropped0
            // 
            this.labUpDropped0.AutoSize = true;
            this.labUpDropped0.Location = new System.Drawing.Point(512, 316);
            this.labUpDropped0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUpDropped0.Name = "labUpDropped0";
            this.labUpDropped0.Size = new System.Drawing.Size(16, 17);
            this.labUpDropped0.TabIndex = 43;
            this.labUpDropped0.Text = "0";
            // 
            // labUpDropped1
            // 
            this.labUpDropped1.AutoSize = true;
            this.labUpDropped1.Location = new System.Drawing.Point(515, 516);
            this.labUpDropped1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUpDropped1.Name = "labUpDropped1";
            this.labUpDropped1.Size = new System.Drawing.Size(16, 17);
            this.labUpDropped1.TabIndex = 60;
            this.labUpDropped1.Text = "0";
            // 
            // labDownDropped1
            // 
            this.labDownDropped1.AutoSize = true;
            this.labDownDropped1.Location = new System.Drawing.Point(423, 516);
            this.labDownDropped1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDownDropped1.Name = "labDownDropped1";
            this.labDownDropped1.Size = new System.Drawing.Size(16, 17);
            this.labDownDropped1.TabIndex = 59;
            this.labDownDropped1.Text = "0";
            // 
            // labUpICMP1
            // 
            this.labUpICMP1.AutoSize = true;
            this.labUpICMP1.Location = new System.Drawing.Point(515, 489);
            this.labUpICMP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUpICMP1.Name = "labUpICMP1";
            this.labUpICMP1.Size = new System.Drawing.Size(16, 17);
            this.labUpICMP1.TabIndex = 58;
            this.labUpICMP1.Text = "0";
            // 
            // labDownICMP1
            // 
            this.labDownICMP1.AutoSize = true;
            this.labDownICMP1.Location = new System.Drawing.Point(423, 489);
            this.labDownICMP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDownICMP1.Name = "labDownICMP1";
            this.labDownICMP1.Size = new System.Drawing.Size(16, 17);
            this.labDownICMP1.TabIndex = 57;
            this.labDownICMP1.Text = "0";
            // 
            // labUpARP1
            // 
            this.labUpARP1.AutoSize = true;
            this.labUpARP1.Location = new System.Drawing.Point(515, 460);
            this.labUpARP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUpARP1.Name = "labUpARP1";
            this.labUpARP1.Size = new System.Drawing.Size(16, 17);
            this.labUpARP1.TabIndex = 56;
            this.labUpARP1.Text = "0";
            // 
            // labDownARP1
            // 
            this.labDownARP1.AutoSize = true;
            this.labDownARP1.Location = new System.Drawing.Point(423, 460);
            this.labDownARP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDownARP1.Name = "labDownARP1";
            this.labDownARP1.Size = new System.Drawing.Size(16, 17);
            this.labDownARP1.TabIndex = 55;
            this.labDownARP1.Text = "0";
            // 
            // labUpTCP1
            // 
            this.labUpTCP1.AutoSize = true;
            this.labUpTCP1.Location = new System.Drawing.Point(515, 433);
            this.labUpTCP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUpTCP1.Name = "labUpTCP1";
            this.labUpTCP1.Size = new System.Drawing.Size(16, 17);
            this.labUpTCP1.TabIndex = 54;
            this.labUpTCP1.Text = "0";
            // 
            // labDownTCP1
            // 
            this.labDownTCP1.AutoSize = true;
            this.labDownTCP1.Location = new System.Drawing.Point(423, 433);
            this.labDownTCP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDownTCP1.Name = "labDownTCP1";
            this.labDownTCP1.Size = new System.Drawing.Size(16, 17);
            this.labDownTCP1.TabIndex = 53;
            this.labDownTCP1.Text = "0";
            // 
            // labUpUDP1
            // 
            this.labUpUDP1.AutoSize = true;
            this.labUpUDP1.Location = new System.Drawing.Point(515, 404);
            this.labUpUDP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labUpUDP1.Name = "labUpUDP1";
            this.labUpUDP1.Size = new System.Drawing.Size(16, 17);
            this.labUpUDP1.TabIndex = 52;
            this.labUpUDP1.Text = "0";
            // 
            // labDownUDP1
            // 
            this.labDownUDP1.AutoSize = true;
            this.labDownUDP1.Location = new System.Drawing.Point(423, 404);
            this.labDownUDP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDownUDP1.Name = "labDownUDP1";
            this.labDownUDP1.Size = new System.Drawing.Size(16, 17);
            this.labDownUDP1.TabIndex = 51;
            this.labDownUDP1.Text = "0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(327, 516);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 17);
            this.label25.TabIndex = 50;
            this.label25.Text = "Dropped";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(327, 489);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 17);
            this.label26.TabIndex = 49;
            this.label26.Text = "ICMP";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(327, 460);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(36, 17);
            this.label27.TabIndex = 48;
            this.label27.Text = "ARP";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(327, 433);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 17);
            this.label28.TabIndex = 47;
            this.label28.Text = "TCP";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(327, 404);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(37, 17);
            this.label29.TabIndex = 46;
            this.label29.Text = "UDP";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(487, 375);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(69, 17);
            this.label30.TabIndex = 45;
            this.label30.Text = "Upstream";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(391, 375);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(86, 17);
            this.label31.TabIndex = 44;
            this.label31.Text = "Downstream";
            // 
            // labName1
            // 
            this.labName1.AutoSize = true;
            this.labName1.Location = new System.Drawing.Point(6, 1);
            this.labName1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labName1.Name = "labName1";
            this.labName1.Size = new System.Drawing.Size(44, 17);
            this.labName1.TabIndex = 61;
            this.labName1.Text = "DEV1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.filterICMP);
            this.panel1.Controls.Add(this.filterARP);
            this.panel1.Controls.Add(this.filterTCP);
            this.panel1.Controls.Add(this.filterUDP);
            this.panel1.Controls.Add(this.filterDSTmac);
            this.panel1.Controls.Add(this.filterSRCmac);
            this.panel1.Controls.Add(this.filterDSTip);
            this.panel1.Controls.Add(this.filterSRCip);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Location = new System.Drawing.Point(572, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 326);
            this.panel1.TabIndex = 62;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnApply.ForeColor = System.Drawing.SystemColors.Window;
            this.btnApply.Location = new System.Drawing.Point(236, 262);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(61, 38);
            this.btnApply.TabIndex = 63;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(37, 196);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 17);
            this.label15.TabIndex = 11;
            this.label15.Text = "Destination MAC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Source MAC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Destination IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Source IP";
            // 
            // filterICMP
            // 
            this.filterICMP.AutoSize = true;
            this.filterICMP.Location = new System.Drawing.Point(168, 229);
            this.filterICMP.Name = "filterICMP";
            this.filterICMP.Size = new System.Drawing.Size(62, 21);
            this.filterICMP.TabIndex = 7;
            this.filterICMP.Text = "ICMP";
            this.filterICMP.UseVisualStyleBackColor = true;
            // 
            // filterARP
            // 
            this.filterARP.AutoSize = true;
            this.filterARP.Location = new System.Drawing.Point(104, 229);
            this.filterARP.Name = "filterARP";
            this.filterARP.Size = new System.Drawing.Size(58, 21);
            this.filterARP.TabIndex = 6;
            this.filterARP.Text = "ARP";
            this.filterARP.UseVisualStyleBackColor = true;
            // 
            // filterTCP
            // 
            this.filterTCP.AutoSize = true;
            this.filterTCP.Location = new System.Drawing.Point(240, 229);
            this.filterTCP.Name = "filterTCP";
            this.filterTCP.Size = new System.Drawing.Size(57, 21);
            this.filterTCP.TabIndex = 5;
            this.filterTCP.Text = "TCP";
            this.filterTCP.UseVisualStyleBackColor = true;
            // 
            // filterUDP
            // 
            this.filterUDP.AutoSize = true;
            this.filterUDP.Location = new System.Drawing.Point(39, 229);
            this.filterUDP.Name = "filterUDP";
            this.filterUDP.Size = new System.Drawing.Size(59, 21);
            this.filterUDP.TabIndex = 4;
            this.filterUDP.Text = "UDP";
            this.filterUDP.UseVisualStyleBackColor = true;
            // 
            // filterDSTmac
            // 
            this.filterDSTmac.Location = new System.Drawing.Point(155, 191);
            this.filterDSTmac.Name = "filterDSTmac";
            this.filterDSTmac.Size = new System.Drawing.Size(142, 22);
            this.filterDSTmac.TabIndex = 3;
            // 
            // filterSRCmac
            // 
            this.filterSRCmac.Location = new System.Drawing.Point(155, 143);
            this.filterSRCmac.Name = "filterSRCmac";
            this.filterSRCmac.Size = new System.Drawing.Size(142, 22);
            this.filterSRCmac.TabIndex = 2;
            // 
            // filterDSTip
            // 
            this.filterDSTip.Location = new System.Drawing.Point(155, 94);
            this.filterDSTip.Name = "filterDSTip";
            this.filterDSTip.Size = new System.Drawing.Size(142, 22);
            this.filterDSTip.TabIndex = 1;
            // 
            // filterSRCip
            // 
            this.filterSRCip.Location = new System.Drawing.Point(155, 46);
            this.filterSRCip.Name = "filterSRCip";
            this.filterSRCip.Size = new System.Drawing.Size(142, 22);
            this.filterSRCip.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(313, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 92);
            this.panel2.TabIndex = 63;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(313, 141);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 203);
            this.panel3.TabIndex = 64;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labName1);
            this.panel4.Location = new System.Drawing.Point(313, 350);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(253, 192);
            this.panel4.TabIndex = 65;
            // 
            // Form2
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1548, 766);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labUpDropped1);
            this.Controls.Add(this.labDownDropped1);
            this.Controls.Add(this.labUpICMP1);
            this.Controls.Add(this.labDownICMP1);
            this.Controls.Add(this.labUpARP1);
            this.Controls.Add(this.labDownARP1);
            this.Controls.Add(this.labUpTCP1);
            this.Controls.Add(this.labDownTCP1);
            this.Controls.Add(this.labUpUDP1);
            this.Controls.Add(this.labDownUDP1);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.labUpDropped0);
            this.Controls.Add(this.labDownDropped0);
            this.Controls.Add(this.labUpICMP0);
            this.Controls.Add(this.labDownICMP0);
            this.Controls.Add(this.labUpARP0);
            this.Controls.Add(this.labDownARP0);
            this.Controls.Add(this.labUpTCP0);
            this.Controls.Add(this.labDownTCP0);
            this.Controls.Add(this.labUpUDP0);
            this.Controls.Add(this.labDownUDP0);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labName0);
            this.Controls.Add(this.labUp1);
            this.Controls.Add(this.labUp0);
            this.Controls.Add(this.labDown1);
            this.Controls.Add(this.labDown0);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.mac_table);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView mac_table;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label labDown0;
        public System.Windows.Forms.Label labDown1;
        public System.Windows.Forms.Label labUp0;
        public System.Windows.Forms.Label labUp1;
        private System.Windows.Forms.Label labName0;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label labDownUDP0;
        public System.Windows.Forms.Label labUpUDP0;
        public System.Windows.Forms.Label labDownTCP0;
        public System.Windows.Forms.Label labUpTCP0;
        public System.Windows.Forms.Label labDownARP0;
        public System.Windows.Forms.Label labUpARP0;
        public System.Windows.Forms.Label labDownICMP0;
        public System.Windows.Forms.Label labUpICMP0;
        public System.Windows.Forms.Label labDownDropped0;
        public System.Windows.Forms.Label labUpDropped0;
        public System.Windows.Forms.Label labUpDropped1;
        public System.Windows.Forms.Label labDownDropped1;
        public System.Windows.Forms.Label labUpICMP1;
        public System.Windows.Forms.Label labDownICMP1;
        public System.Windows.Forms.Label labUpARP1;
        public System.Windows.Forms.Label labDownARP1;
        public System.Windows.Forms.Label labUpTCP1;
        public System.Windows.Forms.Label labDownTCP1;
        public System.Windows.Forms.Label labUpUDP1;
        public System.Windows.Forms.Label labDownUDP1;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label labName1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox filterICMP;
        private System.Windows.Forms.CheckBox filterARP;
        private System.Windows.Forms.CheckBox filterTCP;
        private System.Windows.Forms.CheckBox filterUDP;
        private System.Windows.Forms.TextBox filterDSTmac;
        private System.Windows.Forms.TextBox filterSRCmac;
        private System.Windows.Forms.TextBox filterDSTip;
        private System.Windows.Forms.TextBox filterSRCip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}