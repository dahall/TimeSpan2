using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Globalization
{
	/// <summary>
	/// Defines how <see cref="TimeSpan"/> values are formatted and displayed, depending on the culture.
	/// </summary>
	public sealed class TimeSpanFormatInfo : IFormatProvider, ICustomFormatter
	{
		private TimeSpanResources res;

		/// <summary>
		/// Initializes a new writable instance of the <see cref="TimeSpanFormatInfo"/> class that is culture-independent (invariant).
		/// </summary>
		public TimeSpanFormatInfo()
		{
			res = new TimeSpanResources();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeSpanFormatInfo"/> class that is associated with the supplied culture.
		/// </summary>
		/// <param name="culture">The culture.</param>
		internal TimeSpanFormatInfo(CultureInfo culture)
		{
			res = new TimeSpanResources(culture);
		}

		/// <summary>
		/// Returns the <see cref="TimeSpanFormatInfo"/> associated with the specified <see cref="IFormatProvider"/>. 
		/// </summary>
		/// <param name="provider">The <see cref="IFormatProvider"/> that gets the <see cref="TimeSpanFormatInfo"/>. -or- <c>null</c> reference (Nothing in Visual Basic) to get <see cref="CurrentInfo"/>.</param>
		/// <returns>A <see cref="TimeSpanFormatInfo"/> associated with the specified <see cref="IFormatProvider"/>.</returns>
		public static TimeSpanFormatInfo GetInstance(IFormatProvider provider)
		{
			CultureInfo info2 = provider as CultureInfo;
			if ((info2 != null))
			{
				return new TimeSpanFormatInfo(info2);
			}
			TimeSpanFormatInfo timeSpanInfo = provider as TimeSpanFormatInfo;
			if (timeSpanInfo != null)
			{
				return timeSpanInfo;
			}
			if (provider != null)
			{
				timeSpanInfo = provider.GetFormat(typeof(TimeSpanFormatInfo)) as TimeSpanFormatInfo;
				if (timeSpanInfo != null)
				{
					return timeSpanInfo;
				}
			}
			return CurrentInfo;
		}

		/// <summary>
		/// Gets a read-only <see cref="TimeSpanFormatInfo"/> object that formats values based on the current culture.
		/// </summary>
		/// <value>A read-only <see cref="TimeSpanFormatInfo"/> object based on the <see cref="CultureInfo"/> object for the current thread.</value>
		public static TimeSpanFormatInfo CurrentInfo
		{
			get
			{
				return new TimeSpanFormatInfo(CultureInfo.CurrentCulture);
			}
		}

		/// <summary>
		/// Returns an object of the specified type that provides a <see cref="TimeSpan"/> formatting service.
		/// </summary>
		/// <param name="formatType">The <see cref="Type"/> of the required formatting service.</param>
		/// <returns>
		/// The current <see cref="TimeSpanFormatInfo"/>, if <paramref name="formatType"/> is the same as the type of the current <see cref="TimeSpanFormatInfo"/>; otherwise, <c>null</c>. 
		/// </returns>
		public object GetFormat(Type formatType)
		{
			return (formatType != typeof(ICustomFormatter)) ? null : this;
		}

		/// <summary>
		/// Converts the value of the <see cref="TimeSpan"/> object to its equivalent string representation using the specified format.
		/// </summary>
		/// <param name="format">A TimeSpan format string.</param>
		/// <param name="arg">An object to format.</param>
		/// <param name="formatProvider">An <see cref="T:System.IFormatProvider"/> object that supplies format information about the current instance.</param>
		/// <returns>A string representation of value of the current <see cref="TimeSpan"/> object as specified by format.</returns>
		/// <remarks>The following table lists the standard TimeSpan format patterns associated with TimeSpanFormatInfo properties.
		/// <list type="table">
		/// <listheader><term>Format pattern</term><description>Associated Property/Description</description></listheader>
		/// <item><term>d</term><description>Localized string for TotalDays</description></item>
		/// <item><term>f</term><description>Full localized string displaying each time element with separator between</description></item>
		/// <item><term>h</term><description>Localized string for TotalHours</description></item>
		/// <item><term>m</term><description>Localized string for TotalMinutes</description></item>
		/// <item><term>n</term><description>Standard TimeSpan format (00:00:00:00)</description></item>
		/// <item><term>s</term><description>Localized string for TotalSeconds</description></item>
		/// <item><term>t</term><description>Localized string for TotalMilliseconds</description></item>
		/// </list>
		/// </remarks>
		public string Format(string format, object arg, IFormatProvider formatProvider)
		{
			if (arg == null) throw new ArgumentNullException("arg");

			if (format != null)
			{
				if (arg is TimeSpan)
					return FormatTimeSpan((TimeSpan)arg, format);
				else if (arg is TimeSpan2)
					return FormatTimeSpan((TimeSpan)Convert.ChangeType(arg, typeof(TimeSpan)), format);
			}

			return (arg is IFormattable) ? ((IFormattable)arg).ToString(format, formatProvider) : arg.ToString();
		}

		/// <summary>
		/// Converts the specified string representation of a date and time to its <see cref="TimeSpan"/> equivalent and returns a value that indicates whether the conversion succeeded. 
		/// </summary>
		/// <param name="value">A string containing a time span to convert.</param>
		/// <param name="ts">When this method returns, contains the <see cref="TimeSpan"/> value equivalent to the time span contained in <paramref name="value"/>, if the conversion succeeded, or <c>TimeSpan.Zero</c> if the conversion failed. The conversion fails if the <paramref name="value"/> parameter is <c>null</c>, is an empty string (""), or does not contain a valid string representation of a time span. This parameter is passed uninitialized.</param>
		/// <returns><c>true</c> if the <paramref name="value"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
		public bool TryParse(string value, out TimeSpan ts)
		{
			value = value.Trim();
			ts = TimeSpan.Zero;
			if (string.IsNullOrEmpty(value))
				return false;

			// Try for the easy one
			if (TimeSpan.TryParse(value, out ts))
				return true;

			// Setup
			if (!string.IsNullOrEmpty(TimeSpanZeroDisplay) && (string.Compare(value, TimeSpanZeroDisplay, StringComparison.CurrentCultureIgnoreCase) == 0))
			{
				return true;
			}
			else
			{
				bool f = false;
				StringBuilder sb = new StringBuilder(value.ToLower(this.res.Culture));
				foreach (var s in res.TimeSpanMillisecondStrings.Split(','))
					if (sb.ToString().IndexOf(s) != -1) { f = true; sb.Replace(s, "t"); }
				foreach (var s in res.TimeSpanSecondStrings.Split(','))
					if (sb.ToString().IndexOf(s) != -1) { f = true; sb.Replace(s, "s"); }
				foreach (var s in res.TimeSpanMinuteStrings.Split(','))
					if (sb.ToString().IndexOf(s) != -1) { f = true; sb.Replace(s, "m"); }
				foreach (var s in res.TimeSpanHourStrings.Split(','))
					if (sb.ToString().IndexOf(s) != -1) { f = true; sb.Replace(s, "h"); }
				foreach (var s in res.TimeSpanDayStrings.Split(','))
					if (sb.ToString().IndexOf(s) != -1) { f = true; sb.Replace(s, "d"); }
				if (f)
				{
					Regex regex = new Regex(res.TimeSpanParseRegEx, RegexOptions.IgnoreCase | RegexOptions.Compiled);
					/*Regex regex = new Regex(@"(?:(?<d>\d+)\s*d\s*[,]?\s*)?(?:(?<h>\d+)\s*h\s*[,]?\s*)?(?:(?<m>\d+)\s*m\s*[,]?\s*)?(?:(?<s>\d+)\s*s\s*[,]?\s*)?(?:(?<t>\d+)\s*t)?",
									RegexOptions.IgnoreCase |
									RegexOptions.Compiled |
									RegexOptions.Singleline);*/
					Match m = regex.Match(sb.ToString());
					if (m.Success)
					{
						int d = 0, h = 0, mi = 0, sc = 0, t = 0;
						if (m.Groups["d"].Success) d = int.Parse(m.Groups["d"].Value);
						if (m.Groups["h"].Success) h = int.Parse(m.Groups["h"].Value);
						if (m.Groups["m"].Success) mi = int.Parse(m.Groups["m"].Value);
						if (m.Groups["s"].Success) sc = int.Parse(m.Groups["s"].Value);
						if (m.Groups["t"].Success) sc = int.Parse(m.Groups["t"].Value);
						ts = new TimeSpan(d, h, mi, sc, t);
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Converts the specified string representation of a time span to its <see cref="TimeSpan"/> equivalent. 
		/// </summary>
		/// <param name="s">A string containing a time span to parse.</param>
		/// <returns>A <see cref="TimeSpan"/> equivalent to the time span contained in <paramref name="s"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="s"/> is <c>null</c>.</exception>
		/// <exception cref="FormatException"><paramref name="s"/> does not contain a valid string representation of a time span.</exception>
		public TimeSpan Parse(string s)
		{
			if (string.IsNullOrEmpty(s))
				throw new ArgumentNullException();
			TimeSpan ts;
			if (TryParse(s, out ts))
				return ts;
			throw new FormatException();
		}

		/// <summary>
		/// Gets or sets the string to display the representing <c>TimeSpan.Zero</c>.
		/// </summary>
		public string TimeSpanZeroDisplay { get; set; }

		private string FormatTimeSpan(TimeSpan core, string format)
		{
			char fmt = string.IsNullOrEmpty(format) ? 'n' : format[0];
			string zeroFormat = string.IsNullOrEmpty(TimeSpanZeroDisplay) ? string.Empty : TimeSpanZeroDisplay;
			if (format.Length > 1 && format[1] == ';')
				zeroFormat = format.Substring(2);

			if (core == TimeSpan.Zero && !string.IsNullOrEmpty(zeroFormat))
				return zeroFormat;

			switch (fmt)
			{
				case 'n':
					return core.ToString();
				case 'f':
					Dictionary<char, string> sc = new Dictionary<char, string>(5);
					if (core.Days > 0)
						sc.Add('d', string.Format(core.Days == 1 ? res.TimeSpanOneDayFormat : res.TimeSpanManyDayFormat, core.Days));
					if (core.Hours > 0)
						sc.Add('h', string.Format(core.Hours == 1 ? res.TimeSpanOneHourFormat : res.TimeSpanManyHourFormat, core.Hours));
					if (core.Minutes > 0)
						sc.Add('m', string.Format(core.Minutes == 1 ? res.TimeSpanOneMinuteFormat : res.TimeSpanManyMinuteFormat, core.Minutes));
					if (core.Seconds > 0)
						sc.Add('s', string.Format(core.Seconds == 1 ? res.TimeSpanOneSecondFormat : res.TimeSpanManySecondFormat, core.Seconds));
					if (core.Milliseconds > 0)
						sc.Add('t', string.Format(core.Milliseconds == 1 ? res.TimeSpanOneMillisecondFormat : res.TimeSpanManyMillisecondFormat, core.Milliseconds));
					if (sc.Count == 0 && core.TotalSeconds > 0)
						sc.Add('s', string.Format(core.TotalSeconds == 1 ? res.TimeSpanOneSecondFormat : res.TimeSpanManySecondFormat, core.TotalSeconds));
					string[] vals = new string[sc.Count];
					string ordering = res.TimeSpanFullBuildOrder;
					for (int i = 0, p = 0; i < 5; i++)
					{
						if (sc.ContainsKey(ordering[i]))
							vals[p++] = sc[ordering[i]];
					}
					return string.Join(res.TimeSpanSeparator, vals);
				case 's':
					return string.Format(core.TotalSeconds == 1 ? res.TimeSpanOneSecondFormat : res.TimeSpanManySecondFormat, core.TotalSeconds);
				case 'm':
					return string.Format(core.TotalMinutes == 1 ? res.TimeSpanOneMinuteFormat : res.TimeSpanManyMinuteFormat, core.TotalMinutes);
				case 'h':
					return string.Format(core.TotalHours == 1 ? res.TimeSpanOneHourFormat : res.TimeSpanManyHourFormat, core.TotalHours);
				case 'd':
					return string.Format(core.TotalDays == 1 ? res.TimeSpanOneDayFormat : res.TimeSpanManyDayFormat, core.TotalDays);
				case 't':
					return string.Format(core.TotalMilliseconds == 1 ? res.TimeSpanOneMillisecondFormat : res.TimeSpanManyMillisecondFormat, core.TotalMilliseconds);
				default:
					throw new FormatException("Invalid format specified");
			}
		}
	}
}
