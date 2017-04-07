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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            resources.ApplyResources(this.langCombo, "langCombo");
            this.langCombo.DisplayMember = "EnglishName";
            this.langCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.langCombo.FormattingEnabled = true;
            this.langCombo.Name = "langCombo";
            this.langCombo.SelectedIndexChanged += new System.EventHandler(this.langCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dayUpDn
            // 
            resources.ApplyResources(this.dayUpDn, "dayUpDn");
            this.dayUpDn.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.dayUpDn.Name = "dayUpDn";
            this.dayUpDn.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.dayUpDn.ValueChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // hrUpDn
            // 
            resources.ApplyResources(this.hrUpDn, "hrUpDn");
            this.hrUpDn.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hrUpDn.Name = "hrUpDn";
            this.hrUpDn.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.hrUpDn.ValueChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // minUpDn
            // 
            resources.ApplyResources(this.minUpDn, "minUpDn");
            this.minUpDn.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minUpDn.Name = "minUpDn";
            this.minUpDn.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.minUpDn.ValueChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // secUpDn
            // 
            resources.ApplyResources(this.secUpDn, "secUpDn");
            this.secUpDn.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.secUpDn.Name = "secUpDn";
            this.secUpDn.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.secUpDn.ValueChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
            // 
            // msUpDn
            // 
            resources.ApplyResources(this.msUpDn, "msUpDn");
            this.msUpDn.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.msUpDn.Name = "msUpDn";
            this.msUpDn.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.msUpDn.ValueChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
            // 
            // outputLabel
            // 
            resources.ApplyResources(this.outputLabel, "outputLabel");
            this.outputLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.DoubleClick += new System.EventHandler(this.outputLabel_DoubleClick);
            // 
            // parseText
            // 
            resources.ApplyResources(this.parseText, "parseText");
            this.parseText.Name = "parseText";
            // 
            // parseBtn
            // 
            resources.ApplyResources(this.parseBtn, "parseBtn");
            this.parseBtn.Name = "parseBtn";
            this.parseBtn.UseVisualStyleBackColor = true;
            this.parseBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // parseLabel
            // 
            resources.ApplyResources(this.parseLabel, "parseLabel");
            this.parseLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.parseLabel.Name = "parseLabel";
            this.parseLabel.Click += new System.EventHandler(this.parseLabel_Click);
            // 
            // pickerValueLabel
            // 
            resources.ApplyResources(this.pickerValueLabel, "pickerValueLabel");
            this.pickerValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pickerValueLabel.Name = "pickerValueLabel";
            // 
            // formatTextBox
            // 
            resources.ApplyResources(this.formatTextBox, "formatTextBox");
            this.formatTextBox.Name = "formatTextBox";
            this.formatTextBox.TextChanged += new System.EventHandler(this.dayUpDn_ValueChanged);
            // 
            // timeSpanPicker
            // 
            resources.ApplyResources(this.timeSpanPicker, "timeSpanPicker");
            this.timeSpanPicker.Items.AddRange(new System.TimeSpan2[] {
            new System.TimeSpan2(0, 0, 0, 0),
            new System.TimeSpan2(0, 0, 0, 1),
            new System.TimeSpan2(0, 0, 0, 5),
            new System.TimeSpan2(0, 0, 1, 0),
            new System.TimeSpan2(0, 0, 5, 0),
            new System.TimeSpan2(0, 1, 0, 0),
            new System.TimeSpan2(0, 5, 0, 0),
            new System.TimeSpan2(1, 0, 0, 0),
            new System.TimeSpan2(5, 0, 0, 0)});
            this.timeSpanPicker.Name = "timeSpanPicker";
            this.timeSpanPicker.ValueChanged += new System.EventHandler(this.timeSpanPicker_ValueChanged);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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

