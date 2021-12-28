using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Threading;
using System.Windows.Forms.Design;

namespace System.Windows.Forms
{
	/// <summary>Drop down control that will display a formatted TimeSpan.</summary>
	[DefaultEvent("ValueChanged"), DefaultProperty("Value")]
	public class TimeSpanPicker : ComboBox
	{
		private readonly TimeSpanCollection list;
		private bool isValid = true;
		private TimeSpan tsValue;
		private string zero;

		/// <summary>Initializes a new instance of the <see cref="TimeSpanPicker"/> class.</summary>
		public TimeSpanPicker()
		{
			base.FormatString = "f";
			base.FormattingEnabled = true;
			//ResetLocale();
			FormatInfo = TimeSpan2FormatInfo.CurrentInfo;
			list = new TimeSpanCollection(base.Items);
			ResetValue();
			SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
		}

		/// <summary>Occurs when the value changes.</summary>
		[Category("Property Changed")]
		public event EventHandler ValueChanged;

		/// <summary>Gets or sets the <see cref="TimeSpan2FormatInfo"/> that provides custom formatting behavior.</summary>
		/// <value></value>
		/// <returns>The <see cref="TimeSpan2FormatInfo"/> implementation that provides custom formatting behavior.</returns>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new TimeSpan2FormatInfo FormatInfo
		{
			get => (TimeSpan2FormatInfo)base.FormatInfo;
			set
			{
				if (!string.IsNullOrEmpty(FormattedZero) && value is not null)
				{
					value.TimeSpanZeroDisplay = FormattedZero;
				}

				base.FormatInfo = value;
			}
		}

		/// <summary>
		/// Gets or sets the format string for displaying values. See <seealso cref="TimeSpan2FormatInfo.Format"/> for more information on
		/// valid format strings.
		/// </summary>
		/// <value>The format string.</value>
		[DefaultValue("f"), Category("Appearance"), Localizable(true)]
		public new string FormatString
		{
			get => base.FormatString;
			set => base.FormatString = value;
		}

		/// <summary>Gets or sets the string used to represent <c>TimeSpan.Zero</c>.</summary>
		/// <value>The formatted zero.</value>
		[DefaultValue(null), Category("Appearance"), Localizable(true)]
		public string FormattedZero
		{
			get => zero;
			set
			{
				zero = value;
				FormatInfo.TimeSpanZeroDisplay = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether formatting is applied to the <see
		/// cref="P:System.Windows.Forms.ListControl.DisplayMember"/> property of the <see cref="T:System.Windows.Forms.ListControl"/>.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// true if formatting of the <see cref="P:System.Windows.Forms.ListControl.DisplayMember"/> property is enabled; otherwise, false.
		/// The default is false.
		/// </returns>
		[DefaultValue(true), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool FormattingEnabled
		{
			get => base.FormattingEnabled;
			set => base.FormattingEnabled = value;
		}

		/// <summary>Gets a value indicating whether the current text can be parsed into a valid <see cref="TimeSpan2"/> value.</summary>
		/// <value><c>true</c> if this text is valid; otherwise, <c>false</c>.</value>
		[DefaultValue(true), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsTextValid => isValid;

		/// <summary>Gets the items displayed in the drop-down list.</summary>
		/// <value>The items.</value>
		[Category("Data"), Localizable(false)]
		[Editor(typeof(TimeSpanCollectionEditor), typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		public new TimeSpanCollection Items => list;

		/// <summary>Gets or sets the text associated with this control.</summary>
		/// <value></value>
		/// <returns>The text associated with this control.</returns>
		/// <PermissionSet>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
		/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
		/// class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
		/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
		/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
		/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
		/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral,
		/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
		/// </PermissionSet>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		//[RefreshProperties(RefreshProperties.Repaint)]
		public override string Text
		{
			get => base.Text;
			set => base.Text = value;
		}

		/// <summary>Gets or sets the value of the control.</summary>
		/// <value>The TimeSpan value.</value>
		[Category("Data")]
		//[RefreshProperties(RefreshProperties.Repaint)]
		public TimeSpan2 Value
		{
			get => tsValue;
			set
			{
				tsValue = Value;
				base.Text = TimeSpan.Zero.Equals(value) ? FormatInfo.TimeSpanZeroDisplay : value.ToString(base.FormatString, FormatInfo);
			}
		}

		internal void ResetValue() => Value = TimeSpan2.Zero;

		internal bool ShouldSerializeValue() => Value != TimeSpan2.Zero;

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.ComboBox"/> and optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			SystemEvents.UserPreferenceChanged -= UserPreferenceChanged;
			base.Dispose(disposing);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.TextChanged"/> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnTextChanged(EventArgs e)
		{
			isValid = TimeSpan2.TryParse(base.Text, TimeSpan2FormatInfo.CurrentInfo, out var ts);
			if (isValid && !ts.Equals(tsValue))
			{
				tsValue = ts;
				OnValueChanged(e);
			}
			base.OnTextChanged(e);
		}

		/// <summary>Raises the <see cref="E:ValueChanged"/> event.</summary>
		/// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected virtual void OnValueChanged(EventArgs args) => ValueChanged?.Invoke(this, args);

		/// <summary>Processes Windows messages.</summary>
		/// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				// change in a system-wide or policy setting
				case 0x001A: // WM_SETTINGCHANGE
					ResetLocale();
					break;
			}

			base.WndProc(ref m);
		}

		private void ResetLocale()
		{
			Thread.CurrentThread.CurrentUICulture.ClearCachedData();
			FormatInfo = TimeSpan2FormatInfo.CurrentInfo;
		}

		private void UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
		{
			switch (e.Category)
			{
				case UserPreferenceCategory.Locale:
					ResetLocale();
					break;
			}
		}

		/// <summary>List of TimeSpan structures.</summary>
		public class TimeSpanCollection : StrongListWrapper<TimeSpan2>
		{
			internal TimeSpanCollection(ObjectCollection coll)
				: base(coll)
			{
			}
		}

		internal class TimeSpanCollectionEditor : ExposedStringCollectionEditor
		{
			private string format = "f";

			public TimeSpanCollectionEditor(Type type)
				: base(type)
			{
			}

			protected override string FormTitle => "TimeSpan Collection Editor";

			protected override string InstructionText => "Enter string representations of TimeSpan objects (one per line):";

			public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
			{
				if (context is null)
				{
					throw new ArgumentNullException(nameof(context));
				}

				if (context.Instance is TimeSpanPicker p)
				{
					format = p.FormatString;
				}

				return base.EditValue(context, provider, value);
			}

			protected override object[] GetItems(object editValue)
			{
				if (editValue is TimeSpanCollection value)
				{
					TimeSpanCollection c = value;
					List<string> output = new(c.Count);
					foreach (TimeSpan2 t in c)
					{
						string s = t.ToString(format);
						output.Add(string.IsNullOrEmpty(s) ? "0:0:0" : s);
					}
					return output.ToArray();
				}
				return new object[0];
			}

			protected override object SetItems(object editValue, object[] value)
			{
				if (editValue is not TimeSpanCollection)
				{
					return editValue;
				}

				TimeSpanCollection c = (TimeSpanCollection)editValue;
				c.Clear();
				foreach (object v in value)
				{
					if (TimeSpan2.TryParse(v.ToString(), TimeSpan2FormatInfo.CurrentInfo, out TimeSpan2 ts))
					{
						c.Add(ts);
					}
				}
				return c;
			}
		}
	}
}