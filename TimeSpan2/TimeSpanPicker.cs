using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace System.Windows.Forms
{
	/// <summary>
	/// Drop down control that will display a formatted TimeSpan.
	/// </summary>
    [DefaultEvent("ValueChanged"), DefaultProperty("Value")]
    public partial class TimeSpanPicker : UserControl
    {
        private TimeSpan value = TimeSpan.MinValue;
		private TimeSpanCollection list;

		/// <summary>
		/// List of TimeSpan structures.
		/// </summary>
		public class TimeSpanCollection : StrongListWrapper<TimeSpan>
		{
			internal TimeSpanCollection(ComboBox.ObjectCollection coll) : base(coll)
			{
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeSpanPicker"/> class.
		/// </summary>
        public TimeSpanPicker()
        {
			FormatString = "f";
            InitializeComponent();
			Microsoft.Win32.SystemEvents.UserPreferenceChanged += new Microsoft.Win32.UserPreferenceChangedEventHandler(this.UserPreferenceChanged);
			list = new TimeSpanCollection(comboBoxTimeSpan.Items);
        }

		/// <summary>
		/// Refreshes all the items in the list and applies any changes to the current language.
		/// </summary>
		public void RefreshItems()
		{
			comboBoxTimeSpan.BeginUpdate();
			TimeSpan? cVal = null;
			if (comboBoxTimeSpan.Text.Length > 0)
				cVal = this.Value;
			TimeSpan[] temp = new TimeSpan[Items.Count];
			Items.CopyTo(temp, 0);
			Items.Clear();
			Items.AddRange(temp);
			if (cVal.HasValue)
				comboBoxTimeSpan.Text = GetString(cVal.Value);
			comboBoxTimeSpan.EndUpdate();
		}

		/// <summary>
		/// Occurs when the value changes.
		/// </summary>
        [Category("Property Changed")]
        public event EventHandler ValueChanged;

		/// <summary>
		/// Gets or sets the string used to represent <c>TimeSpan.Zero</c>.
		/// </summary>
		/// <value>The formatted zero.</value>
        [DefaultValue(null), Category("Appearance")]
        public string FormattedZero
        {
            get; set;
        }

		[DefaultValue("f"), Category("Appearance")]
		public string FormatString { get; set; }

		/// <summary>
		/// Gets the items displayed in the drop-down list.
		/// </summary>
		/// <value>The items.</value>
		public TimeSpanCollection Items
        {
            get { return list; }
        }

		/// <summary>
		/// Gets or sets the value of the control.
		/// </summary>
		/// <value>The TimeSpan value.</value>
        [DefaultValue("00:00:00"), Category("Data")]
        public TimeSpan Value
        {
            get
            {
                this.ControlsToData();
                return this.value;
            }
            set
            {
                this.value = value;
                this.DataToControls();
                OnValueChanged(EventArgs.Empty);
            }
        }

        internal void DeselectText()
        {
            this.comboBoxTimeSpan.SelectionLength = 0;
        }

        protected virtual void OnValueChanged(EventArgs args)
        {
            EventHandler h = ValueChanged;
            if (h != null)
                h(this, args);
        }

        private bool ControlsToData()
        {
            try { value = GetValue(this.comboBoxTimeSpan.Text); }
            catch { return false; }
            return true;
        }

        private void DataToControls()
        {
            this.comboBoxTimeSpan.Text = GetString(value);
        }

        private string GetString(TimeSpan t)
        {
			if (t == TimeSpan.Zero)
				return FormattedZero;
            return TimeSpanFormatInfo.CurrentInfo.Format(FormatString, t, null);
        }

        private TimeSpan GetValue(string s)
        {
            return TimeSpanFormatInfo.CurrentInfo.Parse(s);
        }

        private void comboBoxTimeSpan_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.DesiredType == typeof(string) && e.ListItem is TimeSpan)
                e.Value = GetString(((TimeSpan)e.ListItem));
        }

        private void comboBoxTimeSpan_Leave(object sender, EventArgs e)
        {
            if (this.ControlsToData())
                OnValueChanged(EventArgs.Empty);
        }

		private void UserPreferenceChanged(object sender, Microsoft.Win32.UserPreferenceChangedEventArgs e)
		{
			switch(e.Category)
			{
				case Microsoft.Win32.UserPreferenceCategory.Locale:
					System.Threading.Thread.CurrentThread.CurrentCulture.ClearCachedData();
					RefreshItems();
					break;

				default:
					break;
			}
		}
    }
}