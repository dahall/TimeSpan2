using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Globalization
{
	/// <summary>
	/// Type of pattern to extract.
	/// </summary>
	public enum TimeSpanPatternType
	{
		/// <summary>Pattern used for formatting output.</summary>
		Formatting,
		/// <summary>Pattern used for parsing input string.</summary>
		Parsing
	}

	/// <summary>
    /// Defines how <see cref="TimeSpan"/> values are formatted and displayed, depending on the culture.
    /// </summary>
    public sealed class TimeSpan2FormatInfo : IFormatProvider, ICustomFormatter
    {
        const string defaultPattern = "-[d'.']hh':'mm':'ss['.'fffffff]";
        const string generalLongPattern = "-d.hh:mm:ss.fffffff";
        const string generalShortPattern = "-[d.]h:mm:ss[.FFFFFFF]";
        const string ISO8601Pattern = @"'P'[d'D']['T'[h'H'][m'M'][p3'S']];PT0S";
        const RegexOptions opts = RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace; // | RegexOptions.IgnoreCase;
        const string pattern = @"(?>(?<LEVEL>)\[|\](?<OPT-LEVEL>)|(?! \[ | \] )'(?<q>[^']*)'|\\(?<e>.)|(?<d>%d|d+)|(?<h>%h|h+)|(?<m>%m|m+)|(?<s>%s|s+)|(?<k>%k|k+)|(?<t>%t|t+)|(?<D>%D|D\d*)|(?<H>%H|H\d*)|(?<M>%M|M\d*)|(?<S>%S|S\d*)|(?<K>%K|K\d*)|(?<p>p\d*)|(?<vd>@[dD])|(?<vh>@[hH])|(?<vm>@[mM])|(?<vs>@[sS])|(?<vk>@[kK])|(?<vt>@[tT])|(?<f>%f|f+)|(?<F>%F|F+)|(?<fs>,)|(?<ws>_)|(?<ts>:)|(?<ds>\.))+(?(LEVEL)(?!))";
        const string post = @")*(?:;(?<z>[ A-Za-z0-9,:\(\)]+))?\s*$";
        const string pre = @"^\s*(?<n>-)?(?:";

        static readonly string fullPattern = string.Concat(pre, pattern, post);

        private string longPattern = generalLongPattern;
        private Regex regex = new Regex(fullPattern, opts);
        private string shortPattern = generalShortPattern;

        /// <summary>
        /// Initializes a new writable instance of the <see cref="TimeSpan2FormatInfo"/> class that is culture-independent (invariant).
        /// </summary>
        public TimeSpan2FormatInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpan2FormatInfo"/> class that is associated with the supplied culture.
        /// </summary>
        /// <param name="culture">The culture.</param>
        internal TimeSpan2FormatInfo(CultureInfo culture)
        {
            Properties.Resources.Culture = culture;
        }

        /// <summary>
        /// Gets a read-only <see cref="TimeSpan2FormatInfo"/> object that formats values based on the current culture.
        /// </summary>
        /// <value>A read-only <see cref="TimeSpan2FormatInfo"/> object based on the <see cref="CultureInfo"/> object for the current thread.</value>
        public static TimeSpan2FormatInfo CurrentInfo
        {
            get
            {
                return new TimeSpan2FormatInfo(CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the default pattern.
        /// </summary>
        /// <value>The default pattern.</value>
        public string DefaultPattern
        {
            get { return defaultPattern; }
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
        /// Gets a value indicating whether to ignore case when parsing word formatted time spans. Pulls value, if available, from localized resources.
        /// </summary>
        private bool WordPatternIgnoreCase
        {
            get
            {
                try { return bool.Parse(Properties.Resources.TimeSpanWordPatternIgnoreCase); }
                catch { return true; }
            }
        }

        /// <summary>
        /// Returns the <see cref="TimeSpan2FormatInfo"/> associated with the specified <see cref="IFormatProvider"/>. 
        /// </summary>
        /// <param name="provider">The <see cref="IFormatProvider"/> that gets the <see cref="TimeSpan2FormatInfo"/>. -or- <c>null</c> reference (Nothing in Visual Basic) to get <see cref="CurrentInfo"/>.</param>
        /// <returns>A <see cref="TimeSpan2FormatInfo"/> associated with the specified <see cref="IFormatProvider"/>.</returns>
        public static TimeSpan2FormatInfo GetInstance(IFormatProvider provider)
        {
            CultureInfo info2 = provider as CultureInfo;
            if (info2 != null)
                return new TimeSpan2FormatInfo(info2);

            TimeSpan2FormatInfo timeSpanInfo = provider as TimeSpan2FormatInfo;
            if (timeSpanInfo != null)
                return timeSpanInfo;

            if (provider != null)
            {
                timeSpanInfo = provider.GetFormat(typeof(TimeSpan2FormatInfo)) as TimeSpan2FormatInfo;
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
        /// <remarks>The following table lists the standard TimeSpan format patterns associated with TimeSpan2FormatInfo properties.
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
		/// Returns all the standard patterns in which <see cref="TimeSpan"/> values can be formatted.
		/// </summary>
		/// <param name="patternType">Type of the pattern.</param>
		/// <returns>
		/// An array containing the standard patterns in which <see cref="TimeSpan"/> values can be formatted.
		/// </returns>
        public string[] GetAllTimeSpanPatterns(TimeSpanPatternType patternType)
        {
            List<string> output = new List<string>();
            foreach (char f in "cgGfx".ToCharArray())
                output.AddRange(GetAllTimeSpanPatterns(patternType, f));
            return output.ToArray();
        }

		/// <summary>
		/// Returns all the standard patterns in which <see cref="TimeSpan"/> values can be formatted using the specified format pattern.
		/// </summary>
		/// <param name="patternType">Type of the pattern.</param>
		/// <param name="format">A standard format pattern.</param>
		/// <returns>
		/// An array containing the standard patterns in which <see cref="TimeSpan"/> values can be formatted using the specified format pattern.
		/// </returns>
        public string[] GetAllTimeSpanPatterns(TimeSpanPatternType patternType, char format)
        {
            return new string[] { GetTimeSpanPattern(patternType, format) };
        }

        /// <summary>
        /// Returns an object of the specified type that provides a <see cref="TimeSpan"/> formatting service.
        /// </summary>
        /// <param name="formatType">The <see cref="Type"/> of the required formatting service.</param>
        /// <returns>
        /// The current <see cref="TimeSpan2FormatInfo"/>, if <paramref name="formatType"/> is the same as the type of the current <see cref="TimeSpan2FormatInfo"/>; otherwise, <c>null</c>. 
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
        /// <returns>A <see cref="TimeSpan"/> equivalent to the time span contained in <paramref name="s"/> as specified by <paramref name="formats"/> and <paramref name="provider"/>.</returns>
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
        /// 	<c>true</c> if the <paramref name="s"/> parameter was converted successfully; otherwise, <c>false</c>.
        /// </returns>
        internal bool TryParse(string s, IFormatProvider provider, out TimeSpan result)
        {
            s = s.Trim();
            result = TimeSpan.Zero;
            if (string.IsNullOrEmpty(s))
                return false;

            if (TryParseExact(s, GetAllTimeSpanPatterns(TimeSpanPatternType.Parsing), provider, out result))
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
        /// 	<c>true</c> if the <paramref name="s"/> parameter was converted successfully; otherwise, <c>false</c>.
        /// </returns>
        internal bool TryParseExact(string s, string[] formats, IFormatProvider provider, out TimeSpan result)
        {
            foreach (string f in formats)
            {
                string zeroFormat;
                string cFormat = GetCustomFormatString(TimeSpanPatternType.Parsing, f, out zeroFormat);
                if (cFormat.Length == 0)
                    return TimeSpan.TryParse(s, out result);

                Match m = ValidateCustomPattern(cFormat);

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
            string zeroFormat;
			string cFormat = GetCustomFormatString(TimeSpanPatternType.Formatting, format, out zeroFormat);
            if (cFormat.Length == 0)
                return (core == TimeSpan.Zero && zeroFormat != null) ? zeroFormat : core.ToString();
            return CustomFormat(core, cFormat, zeroFormat);
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

        private string GetCustomFormatString(TimeSpanPatternType patternType, string format, out string zeroFormat)
        {
            char fmt = string.IsNullOrEmpty(format) ? 'c' : format[0];
            zeroFormat = string.IsNullOrEmpty(TimeSpanZeroDisplay) ? string.Empty : TimeSpanZeroDisplay;
            if (format.Length > 1)
            {
                if (format[0] == ';')
                {
                    fmt = 'c';
                    zeroFormat = format.Substring(1);
                }
                else if (format[0] != '\\' && format[1] == ';')
                    zeroFormat = format.Substring(2);
                else
                    return format;
            }

			return GetTimeSpanPattern(patternType, fmt);
        }

        private ParseEntity GetParsedTokens(Match m)
        {
            // Handle each match group
            ParseEntity head = new ParseEntity(".", m, null);
            List<ParseEntity> list = head.children = new List<ParseEntity>();
            foreach (string gn in regex.GetGroupNames())
            {
                if (gn != "OPT" && gn != "0")
                {
                    Group g = m.Groups[gn];
                    if (g.Success)
                        foreach (Capture c in g.Captures)
                            list.Add(new ParseEntity(gn, c, head));
                }
            }
            list.Sort(delegate(ParseEntity p1, ParseEntity p2) { return p1.start - p2.start; });

            // Put in groupings
            foreach (Capture c in m.Groups["OPT"].Captures)
            {
                int f = list.FindIndex(delegate(ParseEntity p1) { return p1.start > c.Index; });
                int l = list.FindLastIndex(delegate(ParseEntity p1) { return p1.start + p1.length < c.Index + c.Length; });
                ParseEntity p = new ParseEntity(null, c, head);
                p.children = list.GetRange(f, l - f + 1);
                list.RemoveRange(f, l - f + 1);
                p.children.ForEach(delegate(ParseEntity pe) { pe.parent = p; });
                list.Insert(f, p);
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

        private string GetTimeSpanPattern(TimeSpanPatternType patternType, char format)
        {
            switch (format)
            {
                case 'c':
                    return DefaultPattern;
                case 'g':
                    return ShortPattern;
                case 'G':
                    return LongPattern;
                case 'f':
					return patternType == TimeSpanPatternType.Formatting ? Properties.Resources.TimeSpanWordFormat : Properties.Resources.TimeSpanWordPattern;
                case 'x':
                    return ISO8601Pattern;
                default:
                    throw new ArgumentException("format");
            }
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

        private string GetVerboseParseString(string entityName)
        {
            string parseWords = null;
            switch (entityName)
            {
                case "vd":
                    parseWords = Properties.Resources.TimeSpanDayStrings;
                    break;
                case "vh":
                    parseWords = Properties.Resources.TimeSpanHourStrings;
                    break;
                case "vm":
                    parseWords = Properties.Resources.TimeSpanMinuteStrings;
                    break;
                case "vs":
                    parseWords = Properties.Resources.TimeSpanSecondStrings;
                    break;
                case "vk":
                    parseWords = Properties.Resources.TimeSpanMillisecondStrings;
                    break;
                case "vt":
                    parseWords = Properties.Resources.TimeSpanTickStrings;
                    break;
                default:
                    return string.Empty;
            }
            return string.Format(@"\b(?{1}:{0})\b", string.Join("|", parseWords.Split(',')), this.WordPatternIgnoreCase ? "i" : string.Empty);
        }

        private bool ProcessFormatEntity(ParseEntity e, TimeSpan core)
        {
            if (e.name == null && e.children == null)
            {
                e.output = string.Empty;
                return false;
            }
            bool foundValue = false, foundSep = false;
            if (e.children != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < e.children.Count; i++)
                {
                    if (ProcessFormatEntity(e.children[i], core) && !foundValue)
                        foundValue = true;
                    if (e.children[i].name == "fs")
                    {
                        if (sb.Length > 0)
                            foundSep = true;
                    }
                    else
                    {
                        if (foundSep && !string.IsNullOrEmpty(e.children[i].output))
                        {
                            sb.Append(Properties.Resources.TimeSpanSeparator);
                            foundSep = false;
                        }
                        sb.Append(e.children[i].output);
                    }
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
                case "f":
                case "F":
                    double val = GetValueForGroup(core, e.name);
                    e.output = GetStringValue(val, e.value);
                    foundValue = val != 0;
                    if (e.name == "F")
                        e.output = e.output.TrimEnd('0');
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
                case "fs":
                    e.output = string.Empty;
                    break;
                case "vd":
                case "vh":
                case "vm":
                case "vs":
                case "vk":
                case "vt":
                    e.output = GetCultureString((long)GetValueForGroup(core, e.name.Substring(1)), e.value);
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
                case "vh":
                case "vm":
                case "vs":
                case "vk":
                case "vt":
                    e.output = GetVerboseParseString(e.name);
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
                case "fs":
					e.output = @"\s*" + Regex.Escape(Properties.Resources.TimeSpanSeparator.Trim()) + @"\s*";
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
            public ParseEntity parent;
            public int start, length;

            public ParseEntity(string n, Capture c, ParseEntity p)
            {
                name = n; value = c.Value; start = c.Index; length = c.Length; parent = p;
            }

            public ParseEntity SiblingAfter
            {
                get
                {
                    int idx = parent.children.IndexOf(this);
                    if (idx < parent.children.Count - 1)
                        return parent.children[idx + 1];
                    return null;
                }
            }

            public ParseEntity SiblingPrior
            {
                get
                {
                    int idx = parent.children.IndexOf(this);
                    if (idx > 0)
                        return parent.children[idx - 1];
                    return null;
                }
            }

            public override string ToString()
            {
                return output == null ? string.Empty : output;
            }
        }
    }
}