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

		protected virtual string FormTitle => null;
		protected virtual string InstructionText => null;

		protected override CollectionForm CreateCollectionForm() => new StringCollectionForm(this);

		// Nested Types
		private class StringCollectionForm : CollectionForm
		{
			private readonly ExposedStringCollectionEditor editor;

			// Fields
			private Button cancelButton;

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

			protected override void OnEditValueChanged()
			{
				object[] items = Items;
				string str = string.Empty;
				for (int i = 0; i < items.Length; i++)
				{
					if (items[i] is string s)
					{
						str += s;
						if (i != items.Length - 1)
						{
							str += "\r\n";
						}
					}
				}
				textEntry.Text = str;
			}

			private void Edit1_keyDown(object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Escape)
				{
					cancelButton.PerformClick();
					e.Handled = true;
				}
			}

			private void Form_HelpRequested(object sender, HelpEventArgs e) => editor.ShowHelp();

			private void HookEvents()
			{
				textEntry.KeyDown += Edit1_keyDown;
				okButton.Click += OKButton_click;
				HelpButtonClicked += StringCollectionEditor_HelpButtonClicked;
			}

			private void InitializeComponent()
			{
				ComponentResourceManager manager = new(Type.GetType("System.Windows.Forms.Design.StringCollectionEditor, System.Design"));
				instruction = new Label();
				textEntry = new TextBox();
				okButton = new Button();
				cancelButton = new Button();
				okCancelTableLayoutPanel = new TableLayoutPanel();
				okCancelTableLayoutPanel.SuspendLayout();
				SuspendLayout();
				manager.ApplyResources(instruction, "instruction");
				instruction.Margin = new Padding(3, 1, 3, 0);
				instruction.Name = "instruction";
				if (editor.InstructionText is not null)
				{
					instruction.Text = editor.InstructionText;
				}

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
				AutoScaleMode = AutoScaleMode.Font;
				Controls.Add(okCancelTableLayoutPanel);
				Controls.Add(instruction);
				Controls.Add(textEntry);
				HelpButton = true;
				MaximizeBox = false;
				MinimizeBox = false;
				Name = "StringCollectionEditor";
				ShowIcon = false;
				ShowInTaskbar = false;
				if (editor.FormTitle is not null)
				{
					Text = editor.FormTitle;
				}

				okCancelTableLayoutPanel.ResumeLayout(false);
				okCancelTableLayoutPanel.PerformLayout();
				HelpRequested += Form_HelpRequested;
				ResumeLayout(false);
				PerformLayout();
			}

			private void OKButton_click(object sender, EventArgs e)
			{
				char[] separator = new[] { '\n' };
				char[] trimChars = new[] { '\r' };
				string[] strArray = textEntry.Text.Split(separator);
				object[] items = Items;
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
					DialogResult = DialogResult.Cancel;
				}
				else
				{
					if (strArray.Length > 0 && strArray[strArray.Length - 1].Length == 0)
					{
						length--;
					}
					object[] objArray2 = new object[length];
					for (int j = 0; j < length; j++)
					{
						objArray2[j] = strArray[j];
					}
					Items = objArray2;
				}
			}

			private void StringCollectionEditor_HelpButtonClicked(object sender, CancelEventArgs e)
			{
				e.Cancel = true;
				editor.ShowHelp();
			}
		}
	}
}