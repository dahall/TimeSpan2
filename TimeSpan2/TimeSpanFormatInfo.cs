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
        const string generalLongPattern = "-d:hh:mm:ss.fffffff";
        const string generalShortPattern = "-[d:]h:mm:ss[.FFFFFFF]";
		const RegexOptions opts = RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase;
		const string pattern = @"(?>(?<LEVEL>)\[|\](?<OPT-LEVEL>)|(?! \[ | \] )'(?<q>[^']*)'|\\(?<e>.)|(?<d>%d|d+)|(?<h>%h|h+)|(?<m>%m|m+)|(?<s>%s|s+)|(?<k>%k|k+)|(?<t>%t|t+)|(?<D>%D|D\d*)|(?<H>%H|H\d*)|(?<M>%M|M\d*)|(?<S>%S|S\d*)|(?<K>%K|K\d*)|(?<p>p\d*)|(?<vd>@[dD])|(?<vh>@[hH])|(?<vm>@[mM])|(?<vs>@[sS])|(?<vk>@[kK])|(?<vt>@[tT])|(?<f>%f|f+)|(?<F>%F|F+)|(?<ws>_)|(?<ts>:)|(?<ds>\.))+(?(LEVEL)(?!))";
        const string post = @")*(?:;(?<z>[ A-Za-z0-9,:\(\)]+))?\s*$";
        const string pre = @"^\s*(?<n>-)?(?:";
		const string ISO8601Pattern = @"\P[d\D][\T[h\H][m\M][p3\S]];PT0S";

        static readonly string fullPattern = string.Concat(pre, pattern, post);

        private string longPattern = generalLongPattern;
        private Regex regex = new Regex(fullPattern, opts);
        private string shortPattern = generalShortPattern;

        /// <summary>
        /// Initializes a new writable instance of the <see cref="TimeSpanFormatInfo"/> class that is culture-independent (invariant).
        /// </summary>
        public TimeSpanFormatInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpanFormatInfo"/> class that is associated with the supplied culture.
        /// </summary>
        /// <param name="culture">The culture.</param>
        internal TimeSpanFormatInfo(CultureInfo culture)
        {
            Properties.Resources.Culture = culture;
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
        /// Gets or sets the long pattern.
        /// </summary>
        /// <value>The long pattern.</value>
        public string LongPattern
        {
            get { return longPattern; }
            set { longPattern = value; }
        }

        /// <summary>
        /// Gets or sets the short pattern.
        /// </summary>
        /// <value>The short pattern.</value>
        public string ShortPattern
        {
            get { return shortPattern; }
            set { shortPattern = value; }
        }

        /// <summary>
        /// Gets or sets the string to display the representing <c>TimeSpan.Zero</c>.
        /// </summary>
        public string TimeSpanZeroDisplay
        {
            get; set;
        }

        /// <summary>
        /// Returns the <see cref="TimeSpanFormatInfo"/> associated with the specified <see cref="IFormatProvider"/>. 
        /// </summary>
        /// <param name="provider">The <see cref="IFormatProvider"/> that gets the <see cref="TimeSpanFormatInfo"/>. -or- <c>null</c> reference (Nothing in Visual Basic) to get <see cref="CurrentInfo"/>.</param>
        /// <returns>A <see cref="TimeSpanFormatInfo"/> associated with the specified <see cref="IFormatProvider"/>.</returns>
        public static TimeSpanFormatInfo GetInstance(IFormatProvider provider)
        {
            CultureInfo info2 = provider as CultureInfo;
            if (info2 != null)
                return new TimeSpanFormatInfo(info2);

            TimeSpanFormatInfo timeSpanInfo = provider as TimeSpanFormatInfo;
            if (timeSpanInfo != null)
                return timeSpanInfo;

            if (provider != null)
            {
                timeSpanInfo = provider.GetFormat(typeof(TimeSpanFormatInfo)) as TimeSpanFormatInfo;
                if (timeSpanInfo != null)
                    return timeSpanInfo;
            }
            return CurrentInfo;
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
        /// <item><term>x</term><description>ISO 8601 XML standard for durations</description></item>
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

            return (arg is IFormattable && !(arg is TimeSpan2)) ? ((IFormattable)arg).ToString(format, formatProvider) : arg.ToString();
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
        /// Converts the specified string representation of a time span to its <see cref="TimeSpan"/> equivalent. 
        /// </summary>
        /// <param name="s">A string containing a time span to parse.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s"/>.</param>
        /// <returns>A <see cref="TimeSpan"/> equivalent to the time span contained in <paramref name="s"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> is <c>null</c>.</exception>
        /// <exception cref="FormatException"><paramref name="s"/> does not contain a valid string representation of a time span.</exception>
        internal TimeSpan Parse(string s, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException();
            TimeSpan ts;
            if (TryParse(s, provider, out ts))
                return ts;
            throw new FormatException();
        }

        /// <summary>
        /// Converts the specified string representation of a time span to its <see cref="TimeSpan"/> equivalent using the specified format and culture-specific format information. The format of the string representation must match the specified format exactly.
        /// </summary>
        /// <param name="s">A string containing a time span to parse.</param>
        /// <param name="formats">An array of standard or custom format strings that define the required format of <paramref name="s"/>.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s"/>.</param>
        /// <returns>A <see cref="TimeSpan"/> equivalent to the time span contained in <paramref name="s"/> as specified by <paramref name="format"/> and <paramref name="provider"/>.</returns>
        internal TimeSpan ParseExact(string s, string[] formats, IFormatProvider provider)
        {
            if (s == null)
                throw new ArgumentNullException("s");

			TimeSpan ts;
			if (!TryParseExact(s, formats, provider, out ts))
				throw new FormatException();

            return ts;
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see cref="TimeSpan"/> equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">A string containing a time span to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s"/>.</param>
        /// <param name="result">When this method returns, contains the <see cref="TimeSpan"/> value equivalent to the time span contained in <paramref name="s"/>, if the conversion succeeded, or <c>TimeSpan.Zero</c> if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <c>null</c>, is an empty string (""), or does not contain a valid string representation of a time span. This parameter is passed uninitialized.</param>
        /// <returns>
        /// 	<c>true</c> if the <paramref name="value"/> parameter was converted successfully; otherwise, <c>false</c>.
        /// </returns>
        internal bool TryParse(string s, IFormatProvider provider, out TimeSpan result)
        {
            s = s.Trim();
            result = TimeSpan.Zero;
            if (string.IsNullOrEmpty(s))
                return false;

            // Try for the easy one
            if (TimeSpan.TryParse(s, out result))
                return true;

			if (TryParseExact(s, new string[] { ShortPattern, LongPattern, ISO8601Pattern, Properties.Resources.TimeSpanWordPattern }, provider, out result))
				return true;

            // Setup
            if (!string.IsNullOrEmpty(TimeSpanZeroDisplay) && (string.Compare(s, TimeSpanZeroDisplay, StringComparison.CurrentCultureIgnoreCase) == 0))
                return true;

			return false;
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see cref="TimeSpan"/> equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">A string containing a time span to convert.</param>
        /// <param name="formats">An array of allowable formats of <paramref name="s"/>.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s"/>.</param>
        /// <param name="result">When this method returns, contains the <see cref="TimeSpan"/> value equivalent to the time span contained in <paramref name="s"/>, if the conversion succeeded, or <c>TimeSpan.Zero</c> if the conversion failed. The conversion fails if <paramref name="s"/> or <paramref name="formats"/> is <c>null</c>, <paramref name="s"/> or an element of <paramref name="formats"/> is an empty string, or the format of <paramref name="s"/> is not exactly as specified by at least one of the format patterns in <paramref name="formats"/>. This parameter is passed uninitialized.</param>
        /// <returns>
        /// 	<c>true</c> if the <paramref name="value"/> parameter was converted successfully; otherwise, <c>false</c>.
        /// </returns>
        internal bool TryParseExact(string s, string[] formats, IFormatProvider provider, out TimeSpan result)
        {
            foreach (string f in formats)
            {
                Match m = ValidateCustomPattern(f);

                string pExp = BuildParsingExpression(m);
                System.Diagnostics.Debug.WriteLine(pExp);
                Match p = Regex.Match(s, pExp, opts);
                if (!p.Success)
                    continue;

                try
                {
                    result = TimeSpanFromParseMatch(p);
                    return true;
                }
                catch { }
            }

            result = TimeSpan.Zero;
            return false;
        }

        private string BuildParsingExpression(Match m)
        {
            ParseEntity head = GetParsedTokens(m);
            if (head.children == null)
                throw new FormatException();
            ProcessParseEntity(head);
            return head.ToString();
        }

        private string CustomFormat(TimeSpan core, string format, string zeroFormat)
        {
            // Validate whole string
            Match match = ValidateCustomPattern(format);
            Group zGrp = match.Groups["z"];
            if (core == TimeSpan.Zero && (zGrp.Success || zeroFormat != null))
                return zGrp.Success ? zGrp.Value : zeroFormat;

            ParseEntity head = GetParsedTokens(match);
            if (head.children == null)
                throw new FormatException();
			ParseEntity z = head.children.Find(delegate(ParseEntity p) { return p.name == "z"; });
			if (z != null && core == TimeSpan.Zero)
				return z.value;
			else
				head.children.Remove(z);
            ProcessFormatEntity(head, core);
            return head.ToString();
        }

        private string FormatTimeSpan(TimeSpan core, string format)
        {
            char fmt = string.IsNullOrEmpty(format) ? 'c' : format[0];
            string zeroFormat = string.IsNullOrEmpty(TimeSpanZeroDisplay) ? string.Empty : TimeSpanZeroDisplay;
            if (format.Length > 1)
            {
                if (format[0] == ';')
                    zeroFormat = format.Substring(1);
                else if (format[0] != '\\' && format[1] == ';')
                    zeroFormat = format.Substring(2);
                else
                    return CustomFormat(core, format, zeroFormat);
            }

            switch (fmt)
            {
                case ';':
                case 'c':
                    return (core == TimeSpan.Zero && zeroFormat != null) ? zeroFormat : core.ToString();
                case 'g':
                    return CustomFormat(core, ShortPattern, null);
                case 'G':
                    return CustomFormat(core, LongPattern, null);
                case 'f':
                    if (core == TimeSpan.Zero && zeroFormat != null)
                        return zeroFormat;
                    Dictionary<char, string> sc = new Dictionary<char, string>(5);
                    if (core.Days > 0)
                        sc.Add('d', string.Format(Properties.Resources.TimeSpanNumberWordPattern, core.Days, GetCultureString(core.Days, "vd")));
                    if (core.Hours > 0)
                        sc.Add('h', string.Format(Properties.Resources.TimeSpanNumberWordPattern, core.Hours, GetCultureString(core.Hours, "vh")));
                    if (core.Minutes > 0)
                        sc.Add('m', string.Format(Properties.Resources.TimeSpanNumberWordPattern, core.Minutes, GetCultureString(core.Minutes, "vm")));
                    if (core.Seconds > 0)
                        sc.Add('s', string.Format(Properties.Resources.TimeSpanNumberWordPattern, core.Seconds, GetCultureString(core.Seconds, "vs")));
                    if (core.Milliseconds > 0)
                        sc.Add('k', string.Format(Properties.Resources.TimeSpanNumberWordPattern, core.Milliseconds, GetCultureString(core.Milliseconds, "vk")));
                    if (sc.Count == 0 && core.TotalSeconds > 0)
                        sc.Add('s', string.Format(Properties.Resources.TimeSpanNumberWordPattern, core.TotalSeconds, GetCultureString((long)core.TotalSeconds, "vs")));
                    string[] vals = new string[sc.Count];
                    string ordering = Properties.Resources.TimeSpanFullBuildOrder;
                    for (int i = 0, p = 0; i < 5; i++)
                    {
                        if (sc.ContainsKey(ordering[i]))
                            vals[p++] = sc[ordering[i]];
                    }
                    return string.Join(Properties.Resources.TimeSpanSeparator, vals);
                case 'x':
                    if (core == TimeSpan.Zero)
                        return "PT0S";
                    //if (core.TotalDays - Math.Truncate(core.TotalDays) == 0)
                    //    return CustomFormat(core, @"\P[d\D]", null);
                    //return CustomFormat(core, @"\P[d\D]\T[h\H][m\M][p3\S]", null);
					return CustomFormat(core, ISO8601Pattern, null);
				default:
                    throw new FormatException("Invalid format specified");
            }
        }

        private string GetCultureString(long value, string matchValue)
        {
            string ret = string.Empty;
            switch (char.ToLower(matchValue[1]))
            {
                case 'd':
                    ret = value == 1 ? Properties.Resources.TimeSpanOneDayFormat : Properties.Resources.TimeSpanManyDayFormat;
                    break;
                case 'h':
                    ret = value == 1 ? Properties.Resources.TimeSpanOneHourFormat : Properties.Resources.TimeSpanManyHourFormat;
                    break;
                case 'm':
                    ret = value == 1 ? Properties.Resources.TimeSpanOneMinuteFormat : Properties.Resources.TimeSpanManyMinuteFormat;
                    break;
                case 's':
                    ret = value == 1 ? Properties.Resources.TimeSpanOneSecondFormat: Properties.Resources.TimeSpanManySecondFormat;
                    break;
                case 'k':
                    ret = value == 1 ? Properties.Resources.TimeSpanOneMillisecondFormat : Properties.Resources.TimeSpanManyMillisecondFormat;
                    break;
                case 't':
                    ret = value == 1 ? Properties.Resources.TimeSpanOneTickFormat : Properties.Resources.TimeSpanManyTickFormat;
                    break;
            }
            if (ret.Length > 0 && char.IsUpper(matchValue[1]))
                return char.ToUpper(ret[0]) + (ret.Length > 1 ? ret.Substring(1) : string.Empty);
            return ret;
        }

        private ParseEntity GetParsedTokens(Match m)
        {
            // Handle each match group
            ParseEntity head = new ParseEntity(".", m);
            List<ParseEntity> list = head.children = new List<ParseEntity>();
            foreach (string gn in regex.GetGroupNames())
            {
                Group g = m.Groups[gn];
                if (g.Success && gn != "OPT" && gn != "0")
                    foreach (Capture c in g.Captures)
                        list.Add(new ParseEntity(gn, c));
            }
            list.Sort(delegate(ParseEntity p1, ParseEntity p2) { return p1.start - p2.start; });

            // Put in groupings
            foreach (Capture c in m.Groups["OPT"].Captures)
            {
                int f = list.FindIndex(delegate(ParseEntity p1) { return p1.start > c.Index; });
                int l = list.FindLastIndex(delegate(ParseEntity p1) { return p1.start + p1.length < c.Index + c.Length; });
                ParseEntity p = new ParseEntity(null, c);
                p.children = list.GetRange(f, l - f + 1);
                list.Insert(f, p);
                list.RemoveRange(f + 1, l - f + 1);
            }
            #if DEBUG
            for (int i = 0; i < list.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Match {3} = \"{1}\" ({0}:{2})", list[i].start, list[i].value, list[i].length, list[i].name));
            }
            #endif
            return head;
        }

        private string GetStringValue(double value, string matchValue)
        {
            if (matchValue.StartsWith("%") || matchValue.Length == 1)
                return value.ToString();
            else if (char.IsDigit(matchValue, 1))
            {
                int precision = int.Parse(matchValue.Substring(1));
                double newVal = Math.Round(value, precision, MidpointRounding.AwayFromZero);
                return newVal.ToString();
            }
            else
                return value.ToString(matchValue.Replace(matchValue[0], '0'));
        }

        private double GetValueForGroup(TimeSpan core, string matchGroup)
        {
            switch (matchGroup)
            {
                case "d":
                    return core.Days;
                case "D":
                    return core.TotalDays;
                case "h":
                    return core.Hours;
                case "H":
                    return core.TotalHours;
                case "m":
                    return core.Minutes;
                case "M":
                    return core.TotalMinutes;
                case "s":
                    return core.Seconds;
                case "S":
                    return core.TotalSeconds;
                case "t":
                    return core.Ticks;
                case "k":
                    return core.Milliseconds;
                case "K":
                    return core.TotalMilliseconds;
                case "f":
                case "F":
                    return core.Ticks % TimeSpan.TicksPerSecond;
                case "p":
                    return core.TotalSeconds % 60;
            }
            throw new FormatException();
        }

        private bool ProcessFormatEntity(ParseEntity e, TimeSpan core)
        {
            if (e.name == null && e.children == null)
            {
                e.output = string.Empty;
                return false;
            }
			bool foundValue = false;
			if (e.children != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < e.children.Count; i++)
                {
					if (ProcessFormatEntity(e.children[i], core) && !foundValue)
						foundValue = true;
                    sb.Append(e.children[i].output);
                }
				e.output = (foundValue) ? sb.ToString() : string.Empty;
                return foundValue;
            }
            switch (e.name)
            {
                case "n":
                    if (core.Ticks < 0)
                        e.output = CultureInfo.CurrentCulture.NumberFormat.NegativeSign;
                    break;
                case "d":
                case "D":
                case "h":
                case "H":
                case "m":
                case "M":
                case "s":
                case "S":
                case "t":
                case "k":
                case "K":
                case "p":
					double val = GetValueForGroup(core, e.name);
                    e.output = GetStringValue(val, e.value);
					foundValue = val != 0;
                    break;
                case "ts":
                    e.output = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
                    break;
                case "ds":
                    e.output = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    break;
				case "ws":
					e.output = " ";
					break;
				case "vd":
                case "vh":
                case "vm":
                case "vs":
                case "vk":
                case "vt":
                    e.output = GetCultureString((long)GetValueForGroup(core, e.name.Substring(1)), e.value);
                    break;
                case "f":
                case "F":
                    long dec = core.Ticks % TimeSpan.TicksPerSecond;
                    bool trailingZeros = e.name == "f";
                    e.output = dec.ToString("0000000");
                    if (e.value.StartsWith("%") || e.value.Length == 1)
                        e.output = e.output.Substring(0, 1);
                    else if (e.value.Length < 7)
                        e.output = e.output.Substring(0, e.value.Length);
                    if (!trailingZeros)
                        e.output = e.output.TrimEnd('0');
					foundValue = dec != 0;
                    break;
                case "q":
                case "e":
                default:
                    e.output = e.value;
                    break;
            }
			return foundValue;
        }

        private void ProcessParseEntity(ParseEntity e)
        {
            if (e.name == null && e.children == null)
            {
                e.output = string.Empty;
                return;
            }
            if (e.children != null)
            {
                StringBuilder sb = new StringBuilder();
                if (e.name != ".")
                    sb.Append(@"(?:");
                else
                    sb.Append(@"^\s*");
                for (int i = 0; i < e.children.Count; i++)
                {
                    ProcessParseEntity(e.children[i]);
                    sb.Append(e.children[i].output);
                }
                if (e.name != ".")
                    sb.Append(@")?");
                else
                    sb.Append(@"\s*$");
                e.output = sb.ToString();
                return;
            }
            switch (e.name)
            {
				case "z":
					break;
				case "n":
                    e.output = string.Format(@"(?<n>{0})?", Regex.Escape(CultureInfo.CurrentCulture.NumberFormat.NegativeSign));
                    break;
                case "d":
                case "D":
                case "h":
                case "H":
                case "m":
                case "M":
                case "s":
                case "S":
                case "t":
                case "k":
                case "K":
                case "f":
                case "F":
                    e.output = string.Format(@"(?<{0}>\d+)", e.name);
                    break;
				case "p":
					e.output = string.Format(@"(?<p>\d+(?:{0}\d{{0,{1}}})?)", Regex.Escape(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator), e.value.Substring(1));
					break;
				case "vd":
					e.output = string.Format(@"\b(?:{0})\b", string.Join("|", Properties.Resources.TimeSpanDayStrings.Split(',')));
					break;
				case "vh":
					e.output = string.Format(@"\b(?:{0})\b", string.Join("|", Properties.Resources.TimeSpanHourStrings.Split(',')));
					break;
				case "vm":
					e.output = string.Format(@"\b(?:{0})\b", string.Join("|", Properties.Resources.TimeSpanMinuteStrings.Split(',')));
					break;
				case "vs":
					e.output = string.Format(@"\b(?:{0})\b", string.Join("|", Properties.Resources.TimeSpanSecondStrings.Split(',')));
					break;
				case "vk":
					e.output = string.Format(@"\b(?:{0})\b", string.Join("|", Properties.Resources.TimeSpanMillisecondStrings.Split(',')));
					break;
				case "vt":
					e.output = string.Format(@"\b(?:{0})\b", string.Join("|", Properties.Resources.TimeSpanTickStrings.Split(',')));
					break;
				case "ts":
                    e.output = Regex.Escape(CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator);
                    break;
                case "ds":
                    e.output = Regex.Escape(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    break;
				case "ws":
					e.output = @"\s+";
					break;
				case "q":
                case "e":
                default:
                    e.output = Regex.Escape(e.value);
                    break;
            }
        }

        private TimeSpan TimeSpanFromParseMatch(Match p)
        {
			int d = 0, h = 0, m = 0, s = 0;
			double ps = 0, dk = 0;
            try
            {
                if (p.Groups["d"].Success)
                    d = int.Parse(p.Groups["d"].Value);
                if (p.Groups["h"].Success)
                    h = int.Parse(p.Groups["h"].Value);
                if (p.Groups["m"].Success)
                    m = int.Parse(p.Groups["m"].Value);
                if (p.Groups["s"].Success)
                    s = int.Parse(p.Groups["s"].Value);
				if (p.Groups["p"].Success)
				{
					ps = double.Parse(p.Groups["p"].Value);
					s = (int)Math.Truncate(ps);
					dk = ps - s;
				}
				else if (p.Groups["s"].Success)
					s = int.Parse(p.Groups["s"].Value);
			}
            catch
            {
                throw new OverflowException();
            }

            TimeSpan ret = new TimeSpan(d, h, m, s);

            string fVal = string.Empty;
            if (p.Groups["f"].Success)
                fVal = p.Groups["f"].Value;
            else if (p.Groups["F"].Success)
                fVal = p.Groups["F"].Value;

            if (fVal.Length > 0)
                dk = double.Parse("0" + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + fVal);

			if (p.Groups["k"].Success)
				dk = int.Parse(p.Groups["k"].Value) / 1000.0;

            if (dk != 0)
				ret += TimeSpan.FromTicks((long)Math.Round(dk * 10000000));

			if (p.Groups["t"].Success)
				ret += TimeSpan.FromTicks(int.Parse(p.Groups["t"].Value));

			return ret;
        }

        private Match ValidateCustomPattern(string pattern)
        {
            try
            {
                Match m = regex.Match(pattern);
                if (m == null || !m.Success)
                    throw new FormatException();
                return m;
            }
            catch
            {
                throw new FormatException();
            }
        }

        private class ParseEntity
        {
            public List<ParseEntity> children;
            public string name, value, output;
            public int start, length;

            public ParseEntity(string n, Capture c)
            {
                name = n; value = c.Value; start = c.Index; length = c.Length;
            }

            public override string ToString()
            {
                return output == null ? string.Empty : output;
            }
        }
    }
}