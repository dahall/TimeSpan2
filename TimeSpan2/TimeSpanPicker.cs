using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms.Design;

namespace System.Windows.Forms
{
	/// <summary>
	/// Drop down control that will display a formatted TimeSpan.
	/// </summary>
	[DefaultEvent("ValueChanged"), DefaultProperty("Value")]
	public partial class TimeSpanPicker : ComboBox
	{
		private bool isValid = true;
		private TimeSpan lastVal;
		private TimeSpanCollection list;
		private string zero;

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeSpanPicker"/> class.
		/// </summary>
		public TimeSpanPicker()
		{
			base.FormatString = "f";
			base.FormattingEnabled = true;
			ResetLocale();
			list = new TimeSpanCollection(base.Items);
			ResetValue();
			Microsoft.Win32.SystemEvents.UserPreferenceChanged += this.UserPreferenceChanged;
		}

		/// <summary>
		/// Occurs when the value changes.
		/// </summary>
		[Category("Property Changed")]
		public event EventHandler ValueChanged;

		/// <summary>
		/// Gets or sets the <see cref="TimeSpan2FormatInfo"/> that provides custom formatting behavior.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// The <see cref="TimeSpan2FormatInfo"/> implementation that provides custom formatting behavior.
		/// </returns>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new TimeSpan2FormatInfo FormatInfo
		{
			get
			{
				return (TimeSpan2FormatInfo)base.FormatInfo;
			}
			set
			{
				if (!string.IsNullOrEmpty(this.FormattedZero))
					((TimeSpan2FormatInfo)value).TimeSpanZeroDisplay = this.FormattedZero;
				base.FormatInfo = value;
			}
		}

		/// <summary>
		/// Gets or sets the format string for displaying values. See <seealso cref="TimeSpan2FormatInfo.Format"/> for more information on valid format strings.
		/// </summary>
		/// <value>The format string.</value>
		[DefaultValue("f"), Category("Appearance"), Localizable(true)]
		public new string FormatString
		{
			get { return base.FormatString; }
			set { base.FormatString = value; }
		}

		/// <summary>
		/// Gets or sets the string used to represent <c>TimeSpan.Zero</c>.
		/// </summary>
		/// <value>The formatted zero.</value>
		[DefaultValue(null), Category("Appearance"), Localizable(true)]
		public string FormattedZero
		{
			get { return zero; }
			set
			{
				this.zero = value;
				this.FormatInfo.TimeSpanZeroDisplay = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether formatting is applied to the <see cref="P:System.Windows.Forms.ListControl.DisplayMember"/> property of the <see cref="T:System.Windows.Forms.ListControl"/>.
		/// </summary>
		/// <value></value>
		/// <returns>true if formatting of the <see cref="P:System.Windows.Forms.ListControl.DisplayMember"/> property is enabled; otherwise, false. The default is false.
		/// </returns>
		[DefaultValue(true), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool FormattingEnabled
		{
			get { return base.FormattingEnabled; }
			set { base.FormattingEnabled = value; }
		}

		/// <summary>
		/// Gets a value indicating whether the current text can be parsed into a valid <see cref="TimeSpan2"/> value.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this text is valid; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(true), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsTextValid
		{
			get { return isValid; }
		}

		/// <summary>
		/// Gets the items displayed in the drop-down list.
		/// </summary>
		/// <value>The items.</value>
		[Category("Data"), Localizable(false)]
		[Editor(typeof(TimeSpanCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		public new TimeSpanCollection Items
		{
			get { return list; }
		}

		/// <summary>
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// The text associated with this control.
		/// </returns>
		/// <PermissionSet>
		/// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
		/// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
		/// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
		/// </PermissionSet>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		//[RefreshProperties(RefreshProperties.Repaint)]
		public override string Text
		{
			get { return base.Text; }
			set { base.Text = value; }
		}

		/// <summary>
		/// Gets or sets the value of the control.
		/// </summary>
		/// <value>The TimeSpan value.</value>
		[Category("Data")]
		//[RefreshProperties(RefreshProperties.Repaint)]
		public TimeSpan2 Value
		{
			get
			{
				TimeSpan ts;
				if (this.FormatInfo.TryParse(base.Text, null, out ts))
					return (TimeSpan2)ts;
				return TimeSpan2.Zero;
			}
			set
			{
				lastVal = this.Value;
				base.Text = value.ToString(base.FormatString, this.FormatInfo);
			}
		}

		internal void ResetValue()
		{
			this.Value = TimeSpan2.Zero;
		}

		internal bool ShouldSerializeValue()
		{
			return this.Value != TimeSpan2.Zero;
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.ComboBox"/> and optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			Microsoft.Win32.SystemEvents.UserPreferenceChanged -= this.UserPreferenceChanged;
			base.Dispose(disposing);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged"/> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnTextChanged(EventArgs e)
		{
			TimeSpan ts;
			isValid = this.FormatInfo.TryParse(base.Text, null, out ts);
			if (ts != lastVal)
				OnValueChanged(e);
			base.OnTextChanged(e);
		}

		/// <summary>
		/// Raises the <see cref="E:ValueChanged"/> event.
		/// </summary>
		/// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected virtual void OnValueChanged(EventArgs args)
		{
			EventHandler h = ValueChanged;
			if (h != null)
				h(this, args);
		}

		/// <summary>
		/// Processes Windows messages.
		/// </summary>
		/// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				// change in a systemwide or policy setting
				case 0x001A: // WM_SETTINGCHANGE
					ResetLocale();
					break;
			}

			base.WndProc(ref m);
		}

		private void ResetLocale()
		{
			System.Threading.Thread.CurrentThread.CurrentCulture.ClearCachedData();
			this.FormatInfo = TimeSpan2FormatInfo.CurrentInfo;
		}

		private void UserPreferenceChanged(object sender, Microsoft.Win32.UserPreferenceChangedEventArgs e)
		{
			switch(e.Category)
			{
				case Microsoft.Win32.UserPreferenceCategory.Locale:
					ResetLocale();
					break;
			}
		}

		/// <summary>
		/// List of TimeSpan structures.
		/// </summary>
		public class TimeSpanCollection : StrongListWrapper<TimeSpan2>
		{
			internal TimeSpanCollection(ComboBox.ObjectCollection coll)
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

			protected override string FormTitle
			{
				get { return "TimeSpan Collection Editor"; }
			}

			protected override string InstructionText
			{
				get { return "Enter string representations of TimeSpan objects (one per line):"; }
			}

			public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
			{
				TimeSpanPicker p = context.Instance as TimeSpanPicker;
				if (p != null)
					format = p.FormatString;
				return base.EditValue(context, provider, value);
			}

			protected override object[] GetItems(object editValue)
			{
				if (editValue is TimeSpanCollection)
				{
					TimeSpanCollection c = (TimeSpanCollection)editValue;
					List<string> output = new List<string>(c.Count);
					foreach (var t in c)
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
				if (editValue != null && !(editValue is TimeSpanCollection))
					return editValue;

				TimeSpanCollection c = (TimeSpanCollection)editValue;
				c.Clear();
				TimeSpan2FormatInfo fi = TimeSpan2FormatInfo.CurrentInfo;
				foreach (var v in value)
				{
					TimeSpan ts;
					if (fi.TryParse(v.ToString(), null, out ts))
						c.Add(ts);
				}
				return c;
			}
		}
	}
}