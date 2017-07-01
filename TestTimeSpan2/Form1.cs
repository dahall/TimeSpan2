using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace TestTimeSpan2
{
	public partial class Form1 : Form
	{
		private IFormatProvider formatInfo;

		public Form1()
		{
			InitializeComponent();

			// Add languages to combo
			langCombo.BeginUpdate();
			langCombo.SelectedIndex = -1;
			foreach (
				var culture in
				GetAsmCultures(typeof(TimeSpan2).Assembly.DefinedTypes.First(t => t.Name == "Resources").AsType()))
				langCombo.Items.Add(culture);
			langCombo.EndUpdate();
			langCombo.SelectedItem = Thread.CurrentThread.CurrentUICulture;
		}

		private static IEnumerable<CultureInfo> GetAsmCultures(Type type)
		{
			var rm = new ResourceManager(type);
			foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
				if (!culture.Equals(CultureInfo.InvariantCulture) && rm.GetResourceSet(culture, true, false) != null)
					yield return culture;
		}

		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			/*System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("it-IT");
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

		private void dayUpDn_ValueChanged(object sender, EventArgs e)
		{
			var ts = new TimeSpan2((int) dayUpDn.Value, (int) hrUpDn.Value, (int) minUpDn.Value,
				(int) secUpDn.Value, (int) msUpDn.Value);
			try
			{
				outputLabel.Text = ts.ToString(formatTextBox.Text, formatInfo);
			}
			catch (Exception ex)
			{
				outputLabel.Text = ex.Message;
			}
			button1_Click(sender, e);
		}

		private void langCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			Thread.CurrentThread.CurrentUICulture = langCombo.SelectedItem as CultureInfo;
			formatInfo = TimeSpan2FormatInfo.CurrentInfo;
			((TimeSpan2FormatInfo) formatInfo).TimeSpanZeroDisplay = timeSpanPicker.FormattedZero;
			dayUpDn_ValueChanged(dayUpDn, EventArgs.Empty);
			timeSpanPicker_ValueChanged(timeSpanPicker, EventArgs.Empty);
			//timeSpanPicker.FormatInfo = (System.Globalization.TimeSpan2FormatInfo)formatInfo;
			parseText.Clear();
			parseLabel.Text = string.Empty;
		}

		private void outputLabel_DoubleClick(object sender, EventArgs e)
		{
			Clipboard.SetText(outputLabel.Text, TextDataFormat.Text);
		}

		private void parseLabel_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(parseLabel.Text, TextDataFormat.Text);
		}

		private void timeSpanPicker_ValueChanged(object sender, EventArgs e)
		{
			pickerValueLabel.Text = timeSpanPicker.Value.ToString(formatTextBox.Text, formatInfo);
		}
	}
}