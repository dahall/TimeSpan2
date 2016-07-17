using System.ComponentModel;
using System.ComponentModel.Design;

namespace System.Windows.Forms.Design
{
	internal class ExposedStringCollectionEditor : CollectionEditor
	{
		// Methods
		public ExposedStringCollectionEditor(Type type)
			: base(type)
		{
		}

		protected virtual string InstructionText => null;
		protected virtual string FormTitle => null;

		protected override CollectionEditor.CollectionForm CreateCollectionForm() => new StringCollectionForm(this);

		// Nested Types
		private class StringCollectionForm : CollectionEditor.CollectionForm
		{
			// Fields
			private Button cancelButton;
			private ExposedStringCollectionEditor editor;
			private Label instruction;
			private Button okButton;
			private TableLayoutPanel okCancelTableLayoutPanel;
			private TextBox textEntry;

			// Methods
			public StringCollectionForm(CollectionEditor editor)
				: base(editor)
			{
				this.editor = (ExposedStringCollectionEditor)editor;
				InitializeComponent();
				HookEvents();
			}

			private void Edit1_keyDown(object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Escape)
				{
					cancelButton.PerformClick();
					e.Handled = true;
				}
			}

			private void Form_HelpRequested(object sender, HelpEventArgs e)
			{
				editor.ShowHelp();
			}

			private void HookEvents()
			{
				textEntry.KeyDown += new KeyEventHandler(Edit1_keyDown);
				okButton.Click += new EventHandler(OKButton_click);
				base.HelpButtonClicked += new CancelEventHandler(StringCollectionEditor_HelpButtonClicked);
			}

			private void InitializeComponent()
			{
				ComponentResourceManager manager = new ComponentResourceManager(Type.GetType("System.Windows.Forms.Design.StringCollectionEditor, System.Design"));
				instruction = new Label();
				textEntry = new TextBox();
				okButton = new Button();
				cancelButton = new Button();
				okCancelTableLayoutPanel = new TableLayoutPanel();
				okCancelTableLayoutPanel.SuspendLayout();
				base.SuspendLayout();
				manager.ApplyResources(instruction, "instruction");
				instruction.Margin = new Padding(3, 1, 3, 0);
				instruction.Name = "instruction";
				if (editor.InstructionText != null)
					instruction.Text = editor.InstructionText;
				textEntry.AcceptsTab = true;
				textEntry.AcceptsReturn = true;
				manager.ApplyResources(textEntry, "textEntry");
				textEntry.Name = "textEntry";
				manager.ApplyResources(okButton, "okButton");
				okButton.DialogResult = DialogResult.OK;
				okButton.Margin = new Padding(0, 0, 3, 0);
				okButton.Name = "okButton";
				manager.ApplyResources(cancelButton, "cancelButton");
				cancelButton.DialogResult = DialogResult.Cancel;
				cancelButton.Margin = new Padding(3, 0, 0, 0);
				cancelButton.Name = "cancelButton";
				manager.ApplyResources(okCancelTableLayoutPanel, "okCancelTableLayoutPanel");
				okCancelTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
				okCancelTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
				okCancelTableLayoutPanel.Controls.Add(okButton, 0, 0);
				okCancelTableLayoutPanel.Controls.Add(cancelButton, 1, 0);
				okCancelTableLayoutPanel.Name = "okCancelTableLayoutPanel";
				okCancelTableLayoutPanel.RowStyles.Add(new RowStyle());
				manager.ApplyResources(this, "$this");
				base.AutoScaleMode = AutoScaleMode.Font;
				base.Controls.Add(okCancelTableLayoutPanel);
				base.Controls.Add(instruction);
				base.Controls.Add(textEntry);
				base.HelpButton = true;
				base.MaximizeBox = false;
				base.MinimizeBox = false;
				base.Name = "StringCollectionEditor";
				base.ShowIcon = false;
				base.ShowInTaskbar = false;
				if (editor.FormTitle != null)
					base.Text = editor.FormTitle;
				okCancelTableLayoutPanel.ResumeLayout(false);
				okCancelTableLayoutPanel.PerformLayout();
				base.HelpRequested += new HelpEventHandler(Form_HelpRequested);
				base.ResumeLayout(false);
				base.PerformLayout();
			}

			private void OKButton_click(object sender, EventArgs e)
			{
				char[] separator = new char[] { '\n' };
				char[] trimChars = new char[] { '\r' };
				string[] strArray = textEntry.Text.Split(separator);
				object[] items = base.Items;
				int length = strArray.Length;
				for (int i = 0; i < length; i++)
				{
					strArray[i] = strArray[i].Trim(trimChars);
				}
				bool flag = true;
				if (length == items.Length)
				{
					int index = 0;
					while (index < length)
					{
						if (!strArray[index].Equals((string)items[index]))
						{
							break;
						}
						index++;
					}
					if (index == length)
					{
						flag = false;
					}
				}
				if (!flag)
				{
					base.DialogResult = DialogResult.Cancel;
				}
				else
				{
					if ((strArray.Length > 0) && (strArray[strArray.Length - 1].Length == 0))
					{
						length--;
					}
					object[] objArray2 = new object[length];
					for (int j = 0; j < length; j++)
					{
						objArray2[j] = strArray[j];
					}
					base.Items = objArray2;
				}
			}

			protected override void OnEditValueChanged()
			{
				object[] items = base.Items;
				string str = string.Empty;
				for (int i = 0; i < items.Length; i++)
				{
					if (items[i] is string)
					{
						str = str + ((string)items[i]);
						if (i != (items.Length - 1))
						{
							str = str + "\r\n";
						}
					}
				}
				textEntry.Text = str;
			}

			private void StringCollectionEditor_HelpButtonClicked(object sender, CancelEventArgs e)
			{
				e.Cancel = true;
				editor.ShowHelp();
			}
		}
	}
}
