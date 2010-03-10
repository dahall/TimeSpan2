using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
        private TimeSpanCollection list;
        private string zero;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpanPicker"/> class.
        /// </summary>
        public TimeSpanPicker()
        {
            base.FormatString = "f";
            base.FormatInfo = TimeSpan2FormatInfo.CurrentInfo;
            base.FormattingEnabled = true;
            list = new TimeSpanCollection(base.Items);
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
				if (base.FormatInfo == null)
					this.FormatInfo = TimeSpan2FormatInfo.CurrentInfo;
				return (TimeSpan2FormatInfo)base.FormatInfo;
			}
			set
			{
				base.FormatInfo = value;
				((TimeSpan2FormatInfo)base.FormatInfo).TimeSpanZeroDisplay = this.FormattedZero;
			}
		}

		/// <summary>
        /// Gets or sets the format string for displaying values. See <seealso cref="TimeSpanFormatInfo.Format"/> for more information on valid format strings.
        /// </summary>
        /// <value>The format string.</value>
        [DefaultValue("f"), Category("Appearance")]
        public new string FormatString
        {
            get { return base.FormatString; }
            set { base.FormatString = value; }
        }

        /// <summary>
        /// Gets or sets the string used to represent <c>TimeSpan.Zero</c>.
        /// </summary>
        /// <value>The formatted zero.</value>
        [DefaultValue(null), Category("Appearance")]
        public string FormattedZero
        {
            get { return zero; }
            set
            {
                this.zero = value;
                this.FormatInfo.TimeSpanZeroDisplay = value;
            }
        }

		[DefaultValue(true), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool FormattingEnabled
		{
			get { return base.FormattingEnabled; }
			set { base.FormattingEnabled = value; }
		}

		/// <summary>
        /// Gets the items displayed in the drop-down list.
        /// </summary>
        /// <value>The items.</value>
        [Category("Data"), Localizable(false)]
        [Editor(typeof(TimeSpanCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new TimeSpanCollection Items
        {
            get { return list; }
        }

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                base.SelectedItem = value;
				if (!value.Equals(base.SelectedItem))
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

        protected override void Dispose(bool disposing)
        {
            Microsoft.Win32.SystemEvents.UserPreferenceChanged -= this.UserPreferenceChanged;
            base.Dispose(disposing);
        }

		protected override void OnFormat(ListControlConvertEventArgs e)
		{
			base.OnFormat(e);
		}

        protected override void OnSelectedItemChanged(EventArgs e)
        {
            OnValueChanged(e);
            base.OnSelectedItemChanged(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            TimeSpan ts;
			isValid = this.FormatInfo.TryParse(base.Text, null, out ts);
			if (isValid)
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

        private void UserPreferenceChanged(object sender, Microsoft.Win32.UserPreferenceChangedEventArgs e)
        {
            switch(e.Category)
            {
                case Microsoft.Win32.UserPreferenceCategory.Locale:
                    System.Threading.Thread.CurrentThread.CurrentCulture.ClearCachedData();
                    this.FormatInfo = TimeSpan2FormatInfo.CurrentInfo;
                    break;

                default:
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
                        output.Add(t.ToString(format));
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