using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
			langCombo.EndUpdate();
			langCombo.SelectedItem = curCulture = System.Globalization.CultureInfo.CurrentCulture;

			timeSpanPicker.Items.AddRange(new TimeSpan[] { TimeSpan.Zero, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(5),
				TimeSpan.FromMinutes(15), TimeSpan.FromHours(1), TimeSpan.FromHours(12), TimeSpan.FromDays(1), TimeSpan.FromDays(3) });
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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		private void langCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			System.Threading.Thread.CurrentThread.CurrentCulture = langCombo.SelectedItem as System.Globalization.CultureInfo;
			formatInfo = System.Globalization.TimeSpanFormatInfo.CurrentInfo;
			if (langCombo.SelectedIndex == 0)
				((System.Globalization.TimeSpanFormatInfo)formatInfo).TimeSpanZeroDisplay = timeSpanPicker.FormattedZero = "Nothing";
			else
				((System.Globalization.TimeSpanFormatInfo)formatInfo).TimeSpanZeroDisplay = timeSpanPicker.FormattedZero = "??";
			dayUpDn_ValueChanged(dayUpDn, EventArgs.Empty);
			parseText.Clear();
			parseLabel.Text = string.Empty;
			timeSpanPicker.RefreshItems();
		}

		private void dayUpDn_ValueChanged(object sender, EventArgs e)
		{
			TimeSpan2 ts = new TimeSpan2((int)dayUpDn.Value, (int)hrUpDn.Value, (int)minUpDn.Value, (int)secUpDn.Value, (int)msUpDn.Value);
			outputLabel.Text = ts.ToString("f", formatInfo);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				TimeSpan ts = TimeSpan2.Parse(parseText.Text, formatInfo);
				parseLabel.Text = ts.ToString();
			}
			catch (Exception ex)
			{
				parseLabel.Text = ex.Message;
			}
		}

		private void timeSpanPicker_ValueChanged(object sender, EventArgs e)
		{
			pickerValueLabel.Text = timeSpanPicker.Value.ToString();
		}
	}
}
