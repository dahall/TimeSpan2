using System;
using System.Windows.Forms;

namespace TestTimeSpan2
{
	public partial class Form1 : Form
	{
		private System.Globalization.CultureInfo curCulture;
		private System.IFormatProvider formatInfo;

		public Form1()
		{
			InitializeComponent();

			// Add languages to combo
			langCombo.BeginUpdate();
			langCombo.SelectedIndex = -1;
			langCombo.Items.Add(new System.Globalization.CultureInfo("en-US"));
			langCombo.Items.Add(new System.Globalization.CultureInfo("it-IT"));
			langCombo.Items.Add(new System.Globalization.CultureInfo("de-DE"));
			langCombo.Items.Add(new System.Globalization.CultureInfo("es-ES"));
			langCombo.Items.Add(new System.Globalization.CultureInfo("fr-FR"));
			langCombo.Items.Add(new System.Globalization.CultureInfo("pt-PT"));
			langCombo.Items.Add(new System.Globalization.CultureInfo("ru-RU"));
			langCombo.Items.Add(new System.Globalization.CultureInfo("zh-CN"));
			langCombo.EndUpdate();
			langCombo.SelectedItem = curCulture = System.Globalization.CultureInfo.CurrentCulture;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			/*System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("it-IT");
			TimeSpan2 ts = new TimeSpan2(2, 1, 4);
			string s = ts.ToString("f", null);
			Console.Write(s);
			System.Globalization.TimeSpanFormatInfo tfi = System.Globalization.TimeSpanFormatInfo.CurrentInfo;
			TimeSpan t = tfi.Parse("1 giorno");
			Console.Write(s = tfi.Format("f", t, null));
			s = string.Empty;*/
			/*TimeSpan ts = new TimeSpan(3, 2, 1);
			System.Collections.Specialized.ListDictionary dict = new System.Collections.Specialized.ListDictionary();
			dict.Add("Ticks", 450L);
			TimeSpan2 ts2 = (TimeSpan2)ts;
			TypeConverter tc = TypeDescriptor.GetConverter(typeof(TimeSpan2));
			ts2 = (TimeSpan2)tc.ConvertFrom(23);
			ts2 = (TimeSpan2)tc.ConvertFrom("1.2:3:4");
			ts2 = (TimeSpan2)tc.CreateInstance(dict);*/

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		private void langCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			System.Threading.Thread.CurrentThread.CurrentCulture = langCombo.SelectedItem as System.Globalization.CultureInfo;
			formatInfo = System.Globalization.TimeSpan2FormatInfo.CurrentInfo;
			if (langCombo.SelectedIndex == 0)
				((System.Globalization.TimeSpan2FormatInfo)formatInfo).TimeSpanZeroDisplay = timeSpanPicker.FormattedZero = "Nothing";
			else
				((System.Globalization.TimeSpan2FormatInfo)formatInfo).TimeSpanZeroDisplay = timeSpanPicker.FormattedZero = "??";
			dayUpDn_ValueChanged(dayUpDn, EventArgs.Empty);
			parseText.Clear();
			parseLabel.Text = string.Empty;
		}

		private void dayUpDn_ValueChanged(object sender, EventArgs e)
		{
			TimeSpan2 ts = new TimeSpan2((int)dayUpDn.Value, (int)hrUpDn.Value, (int)minUpDn.Value, (int)secUpDn.Value, (int)msUpDn.Value);
			try { outputLabel.Text = ts.ToString(formatTextBox.Text, formatInfo); }
			catch (Exception ex) { outputLabel.Text = ex.Message; }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				TimeSpan2 ts;
				if (TimeSpan2.TryParse(parseText.Text, out ts))
				{
					parseLabel.Text = ts.ToString(formatTextBox.Text, formatInfo);
					timeSpanPicker.Value = ts;
				}
			}
			catch (Exception ex)
			{
				parseLabel.Text = ex.Message;
			}
		}

		private void timeSpanPicker_ValueChanged(object sender, EventArgs e)
		{
			pickerValueLabel.Text = timeSpanPicker.Value.ToString(formatTextBox.Text, formatInfo);
		}
	}
}