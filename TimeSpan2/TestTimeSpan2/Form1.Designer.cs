namespace TestTimeSpan2
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
			this.langCombo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dayUpDn = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.hrUpDn = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.minUpDn = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.secUpDn = new System.Windows.Forms.NumericUpDown();
			this.msUpDn = new System.Windows.Forms.NumericUpDown();
			this.outputLabel = new System.Windows.Forms.Label();
			this.parseText = new System.Windows.Forms.TextBox();
			this.parseBtn = new System.Windows.Forms.Button();
			this.parseLabel = new System.Windows.Forms.Label();
			this.pickerValueLabel = new System.Windows.Forms.Label();
			this.formatTextBox = new System.Windows.Forms.TextBox();
			this.timeSpanPicker = new System.Windows.Forms.TimeSpanPicker();
			((System.ComponentModel.ISupportInitialize)(this.dayUpDn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hrUpDn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minUpDn)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.secUpDn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.msUpDn)).BeginInit();
			this.SuspendLayout();
			// 
			// langCombo
			// 
			this.langCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.langCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.langCombo.FormattingEnabled = true;
			this.langCombo.Location = new System.Drawing.Point(76, 13);
			this.langCombo.Name = "langCombo";
			this.langCombo.Size = new System.Drawing.Size(457, 21);
			this.langCombo.TabIndex = 1;
			this.langCombo.SelectedIndexChanged += new System.EventHandler(this.langCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Language:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Days:";
			// 
			// dayUpDn
			// 
			this.dayUpDn.Location = new System.Drawing.Point(43, 3);
			this.dayUpDn.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.dayUpDn.Name = "dayUpDn";
			this.dayUpDn.Size = new System.Drawing.Size(50, 20);
			this.dayUpDn.TabIndex = 1;
			this.dayUpDn.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.dayUpDn.ValueChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(99, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Hours:";
			// 
			// hrUpDn
			// 
			this.hrUpDn.Location = new System.Drawing.Point(143, 3);
			this.hrUpDn.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
			this.hrUpDn.Name = "hrUpDn";
			this.hrUpDn.Size = new System.Drawing.Size(50, 20);
			this.hrUpDn.TabIndex = 3;
			this.hrUpDn.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.hrUpDn.ValueChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(199, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Minutes:";
			// 
			// minUpDn
			// 
			this.minUpDn.Location = new System.Drawing.Point(252, 3);
			this.minUpDn.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.minUpDn.Name = "minUpDn";
			this.minUpDn.Size = new System.Drawing.Size(50, 20);
			this.minUpDn.TabIndex = 5;
			this.minUpDn.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.minUpDn.ValueChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 10;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.minUpDn, 5, 0);
			this.tableLayoutPanel1.Controls.Add(this.dayUpDn, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.hrUpDn, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.label5, 6, 0);
			this.tableLayoutPanel1.Controls.Add(this.label6, 8, 0);
			this.tableLayoutPanel1.Controls.Add(this.secUpDn, 7, 0);
			this.tableLayoutPanel1.Controls.Add(this.msUpDn, 9, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 50);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(517, 26);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(308, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Seconds:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(422, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(36, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Msec:";
			// 
			// secUpDn
			// 
			this.secUpDn.Location = new System.Drawing.Point(366, 3);
			this.secUpDn.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.secUpDn.Name = "secUpDn";
			this.secUpDn.Size = new System.Drawing.Size(50, 20);
			this.secUpDn.TabIndex = 7;
			this.secUpDn.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.secUpDn.ValueChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
			// 
			// msUpDn
			// 
			this.msUpDn.Location = new System.Drawing.Point(464, 3);
			this.msUpDn.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.msUpDn.Name = "msUpDn";
			this.msUpDn.Size = new System.Drawing.Size(50, 20);
			this.msUpDn.TabIndex = 9;
			this.msUpDn.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
			this.msUpDn.ValueChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
			// 
			// outputLabel
			// 
			this.outputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.outputLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.outputLabel.Location = new System.Drawing.Point(159, 83);
			this.outputLabel.Name = "outputLabel";
			this.outputLabel.Size = new System.Drawing.Size(370, 26);
			this.outputLabel.TabIndex = 3;
			this.outputLabel.Text = "label7";
			this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// parseText
			// 
			this.parseText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.parseText.Location = new System.Drawing.Point(13, 146);
			this.parseText.Name = "parseText";
			this.parseText.Size = new System.Drawing.Size(274, 20);
			this.parseText.TabIndex = 4;
			// 
			// parseBtn
			// 
			this.parseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.parseBtn.Location = new System.Drawing.Point(293, 144);
			this.parseBtn.Name = "parseBtn";
			this.parseBtn.Size = new System.Drawing.Size(75, 23);
			this.parseBtn.TabIndex = 5;
			this.parseBtn.Text = "Parse";
			this.parseBtn.UseVisualStyleBackColor = true;
			this.parseBtn.Click += new System.EventHandler(this.button1_Click);
			// 
			// parseLabel
			// 
			this.parseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.parseLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.parseLabel.Location = new System.Drawing.Point(374, 146);
			this.parseLabel.Name = "parseLabel";
			this.parseLabel.Size = new System.Drawing.Size(159, 20);
			this.parseLabel.TabIndex = 6;
			this.parseLabel.Text = "label7";
			this.parseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pickerValueLabel
			// 
			this.pickerValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pickerValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pickerValueLabel.Location = new System.Drawing.Point(374, 177);
			this.pickerValueLabel.Name = "pickerValueLabel";
			this.pickerValueLabel.Size = new System.Drawing.Size(159, 20);
			this.pickerValueLabel.TabIndex = 8;
			this.pickerValueLabel.Text = "label7";
			this.pickerValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// formatTextBox
			// 
			this.formatTextBox.Location = new System.Drawing.Point(22, 87);
			this.formatTextBox.Name = "formatTextBox";
			this.formatTextBox.Size = new System.Drawing.Size(131, 20);
			this.formatTextBox.TabIndex = 2;
			this.formatTextBox.Text = "f";
			this.formatTextBox.TextChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
			// 
			// timeSpanPicker
			// 
			this.timeSpanPicker.FormattedZero = "Nothing";
			this.timeSpanPicker.Items.AddRange(new System.TimeSpan2[] {
            new System.TimeSpan2(0, 0, 0, 0),
            new System.TimeSpan2(0, 0, 0, 1),
            new System.TimeSpan2(0, 0, 0, 15),
            new System.TimeSpan2(0, 0, 1, 0),
            new System.TimeSpan2(0, 0, 5, 0),
            new System.TimeSpan2(0, 1, 0, 0),
            new System.TimeSpan2(0, 3, 0, 0),
            new System.TimeSpan2(1, 0, 0, 0),
            new System.TimeSpan2(30, 0, 0, 0)});
			this.timeSpanPicker.Location = new System.Drawing.Point(12, 177);
			this.timeSpanPicker.Name = "timeSpanPicker";
			this.timeSpanPicker.Size = new System.Drawing.Size(275, 21);
			this.timeSpanPicker.TabIndex = 7;
			this.timeSpanPicker.Value = new System.TimeSpan2(1, 0, 0, 0);
			this.timeSpanPicker.ValueChanged += new System.EventHandler(this.timeSpanPicker_ValueChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(545, 210);
			this.Controls.Add(this.formatTextBox);
			this.Controls.Add(this.timeSpanPicker);
			this.Controls.Add(this.parseBtn);
			this.Controls.Add(this.parseText);
			this.Controls.Add(this.pickerValueLabel);
			this.Controls.Add(this.parseLabel);
			this.Controls.Add(this.outputLabel);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.langCombo);
			this.Name = "Form1";
			this.Text = "Test TimeSpan2";
			((System.ComponentModel.ISupportInitialize)(this.dayUpDn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hrUpDn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minUpDn)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.secUpDn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.msUpDn)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox langCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown dayUpDn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown hrUpDn;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown minUpDn;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown secUpDn;
		private System.Windows.Forms.NumericUpDown msUpDn;
		private System.Windows.Forms.Label outputLabel;
		private System.Windows.Forms.TextBox parseText;
		private System.Windows.Forms.Button parseBtn;
		private System.Windows.Forms.Label parseLabel;
		private System.Windows.Forms.TimeSpanPicker timeSpanPicker;
		private System.Windows.Forms.Label pickerValueLabel;
		private System.Windows.Forms.TextBox formatTextBox;
	}
}

