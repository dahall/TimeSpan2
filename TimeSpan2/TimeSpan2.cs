using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace System
{
	/// <summary>
	/// Represents a time interval.
	/// </summary>
	/// <remarks>
	/// A TimeSpan2 object represents a time interval (duration of time or elapsed time) that is measured as a positive or negative number of days, hours, minutes, seconds, and fractions of a second. The TimeSpan2 structure can also be used to represent the time of day, but only if the time is unrelated to a particular date.
	/// </remarks>
	[Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true)]
	[TypeConverter(typeof(TimeSpan2Converter))]
	public struct TimeSpan2 : IComparable, IComparable<TimeSpan2>, IComparable<TimeSpan>, IEquatable<TimeSpan2>, IEquatable<TimeSpan>, IFormattable, IConvertible, ISerializable
	{
		private TimeSpan core;

		/// <summary>Represents the maximum <see cref="TimeSpan2"/> value. This field is read-only.</summary>
		public static readonly TimeSpan2 MaxValue;
		/// <summary>Represents the minimum <see cref="TimeSpan2"/> value. This field is read-only.</summary>
		public static readonly TimeSpan2 MinValue;
		/// <summary>Represents the zero <see cref="TimeSpan2"/> value. This field is read-only.</summary>
		public static readonly TimeSpan2 Zero;
		/// <summary>Represents the number of ticks in 1 day. This field is constant.</summary>
		public static readonly long TicksPerDay;
		/// <summary>Represents the number of ticks in 1 hour. This field is constant.</summary>
		public static readonly long TicksPerHour;
		/// <summary>Represents the number of ticks in 1 millisecond. This field is constant.</summary>
		public static readonly long TicksPerMillisecond;
		/// <summary>Represents the number of ticks in 1 minute. This field is constant.</summary>
		public static readonly long TicksPerMinute;
		/// <summary>Represents the number of ticks in 1 second. This field is constant.</summary>
		public static readonly long TicksPerSecond;

		static TimeSpan2()
		{
			Zero = new TimeSpan2(TimeSpan.Zero);
			MaxValue = new TimeSpan2(TimeSpan.MaxValue);
			MinValue = new TimeSpan2(TimeSpan.MinValue);
			TicksPerDay = TimeSpan.TicksPerDay;
			TicksPerHour = TimeSpan.TicksPerHour;
			TicksPerMillisecond = TimeSpan.TicksPerMillisecond;
			TicksPerMinute = TimeSpan.TicksPerMinute;
			TicksPerSecond = TimeSpan.TicksPerSecond;
		}

		/// <summary>
		/// Initializes a new <see cref="TimeSpan2"/> with the specified <see cref="TimeSpan"/>.
		/// </summary>
		/// <param name="span">The initializing <see cref="TimeSpan"/>.</param>
		public TimeSpan2(TimeSpan span)
		{
			core = span;
		}

		/// <summary>
		/// Initializes a new <see cref="TimeSpan2"/> with the specified number of ticks.
		/// </summary>
		/// <param name="ticks">A time period expressed in 100-nanosecond units.</param>
		public TimeSpan2(long ticks)
		{
			core = new TimeSpan(ticks);
		}

		/// <summary>
		/// Initializes a new <see cref="TimeSpan2"/> with the specified number of hours, minutes, and seconds.
		/// </summary>
		/// <param name="hours">Number of hours.</param>
		/// <param name="minutes">Number of minutes.</param>
		/// <param name="seconds">Number of seconds.</param>
		public TimeSpan2(int hours, int minutes, int seconds)
		{
			core = new TimeSpan(hours, minutes, seconds);
		}

		/// <summary>
		/// Initializes a new <see cref="TimeSpan2"/> with the specified number of days, hours, minutes, and seconds.
		/// </summary>
		/// <param name="days">Number of days.</param>
		/// <param name="hours">Number of hours.</param>
		/// <param name="minutes">Number of minutes.</param>
		/// <param name="seconds">Number of seconds.</param>
		public TimeSpan2(int days, int hours, int minutes, int seconds)
			: this(days, hours, minutes, seconds, 0)
		{
		}

		/// <summary>
		/// Initializes a new <see cref="TimeSpan2"/> with the specified number of days, hours, minutes, seconds, and milliseconds.
		/// </summary>
		/// <param name="days">Number of days.</param>
		/// <param name="hours">Number of hours.</param>
		/// <param name="minutes">Number of minutes.</param>
		/// <param name="seconds">Number of seconds.</param>
		/// <param name="milliseconds">Number of milliseconds</param>
		public TimeSpan2(int days, int hours, int minutes, int seconds, int milliseconds)
		{
			core = new TimeSpan(days, hours, minutes, seconds, milliseconds);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeSpan2"/> struct.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The serialization context.</param>
		public TimeSpan2(SerializationInfo info, StreamingContext context)
		{
			core = new TimeSpan(info.GetInt64("ticks"));
		}

		/// <summary>
		/// Gets the days component of the time interval represented by the current <see cref="TimeSpan2"/> structure.
		/// </summary>
		/// <value>The day component of this instance. The return value can be positive or negative.</value>
		[Browsable(false)]
		public int Days
		{
			get { return core.Days; }
		}

		/// <summary>
		/// Gets the hours component of the time interval represented by the current <see cref="TimeSpan2"/> structure.
		/// </summary>
		/// <value>The hours component of this instance. The return value ranges from -23 through 23.</value>
		[Browsable(false)]
		public int Hours
		{
			get { return core.Hours; }
		}

		/// <summary>
		/// Gets a value indicating whether this instance is zero.
		/// </summary>
		/// <value><c>true</c> if this instance is zero; otherwise, <c>false</c>.</value>
		[Browsable(false)]
		public bool IsZero
		{
			get { return core == TimeSpan.Zero; }
		}

		/// <summary>
		/// Gets the milliseconds component of the time interval represented by the current <see cref="TimeSpan2"/> structure.
		/// </summary>
		/// <value>The milliseconds component of this instance. The return value ranges from -999 through 999.</value>
		[Browsable(false)]
		public int Milliseconds
		{
			get { return core.Milliseconds; }
		}

		/// <summary>
		/// Gets the minutes component of the time interval represented by the current <see cref="TimeSpan2"/> structure.
		/// </summary>
		/// <value>The minutes component of this instance. The return value ranges from -59 through 59.</value>
		[Browsable(false)]
		public int Minutes
		{
			get { return core.Minutes; }
		}

		/// <summary>
		/// Gets the seconds component of the time interval represented by the current <see cref="TimeSpan2"/> structure.
		/// </summary>
		/// <value>The seconds component of this instance. The return value ranges from -59 through 59.</value>
		[Browsable(false)]
		public int Seconds
		{
			get { return core.Seconds; }
		}

		/// <summary>
		/// Gets the number of ticks that represent the value of the current <see cref="TimeSpan2"/> structure.
		/// </summary>
		/// <value>The number of ticks contained in this instance.</value>
		[Browsable(false)]
		public long Ticks
		{
			get { return core.Ticks; }
		}

		/// <summary>
		/// Gets the value of the current <see cref="TimeSpan2"/> structure expressed in whole and fractional days.
		/// </summary>
		/// <value>The total number of days represented by this instance.</value>
		[Browsable(false)]
		public double TotalDays
		{
			get { return core.TotalDays; }
		}

		/// <summary>
		/// Gets the value of the current <see cref="TimeSpan2"/> structure expressed in whole and fractional hours.
		/// </summary>
		/// <value>The total number of hours represented by this instance.</value>
		[Browsable(false)]
		public double TotalHours
		{
			get { return core.TotalHours; }
		}

		/// <summary>
		/// Gets the value of the current <see cref="TimeSpan2"/> structure expressed in whole and fractional milliseconds.
		/// </summary>
		/// <value>The total number of milliseconds represented by this instance.</value>
		[Browsable(false)]
		public double TotalMilliseconds
		{
			get { return core.TotalMilliseconds; }
		}

		/// <summary>
		/// Gets the value of the current <see cref="TimeSpan2"/> structure expressed in whole and fractional minutes.
		/// </summary>
		/// <value>The total number of minutes represented by this instance.</value>
		[Browsable(false)]
		public double TotalMinutes
		{
			get { return core.TotalMinutes; }
		}

		/// <summary>
		/// Gets the value of the current <see cref="TimeSpan2"/> structure expressed in whole and fractional seconds.
		/// </summary>
		/// <value>The total number of seconds represented by this instance.</value>
		[Browsable(false)]
		public double TotalSeconds
		{
			get { return core.TotalSeconds; }
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.TimeSpan2"/> to <see cref="System.TimeSpan"/>.
		/// </summary>
		/// <param name="d">The <see cref="TimeSpan2"/> structure to convert.</param>
		/// <returns>The <see cref="TimeSpan"/> equivalent of the converted <see cref="TimeSpan2"/>.</returns>
		public static implicit operator TimeSpan(TimeSpan2 d)
		{
			return d.core;
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.TimeSpan"/> to <see cref="System.TimeSpan2"/>.
		/// </summary>
		/// <param name="d">The <see cref="TimeSpan"/> structure to convert.</param>
		/// <returns>The <see cref="TimeSpan2"/> equivalent of the converted <see cref="TimeSpan"/>.</returns>
		public static implicit operator TimeSpan2(TimeSpan d)
		{
			return new TimeSpan2(d);
		}

		/// <summary>
		/// Indicates whether two <see cref="TimeSpan2"/> instances are not equal.
		/// </summary>
		/// <param name="t1">A <see cref="TimeSpan2"/>.</param>
		/// <param name="t2">A <c>TimeSpan2</c>.</param>
		/// <returns><c>true</c> if the values of <paramref name="t1"/> and <paramref name="t2"/> are not equal; otherwise, <c>false</c>.</returns>
		public static bool operator !=(TimeSpan2 t1, TimeSpan2 t2)
		{
			return (t1.core != t2.core);
		}

		/// <summary>
		/// Returns the specified instance of <see cref="TimeSpan2"/>.
		/// </summary>
		/// <param name="t">A <see cref="TimeSpan2"/>.</param>
		/// <returns>Returns <paramref name="t"/>.</returns>
		public static TimeSpan2 operator +(TimeSpan2 t)
		{
			return t;
		}

		/// <summary>
		/// Adds two specified <see cref="TimeSpan2"/> instances.
		/// </summary>
		/// <param name="t1">A <see cref="TimeSpan2"/>.</param>
		/// <param name="t2">A <c>TimeSpan2</c>.</param>
		/// <returns>A <see cref="TimeSpan2"/> whose value is the sum of the values of <paramref name="t1"/> and <paramref name="t2"/>.</returns>
		public static TimeSpan2 operator +(TimeSpan2 t1, TimeSpan2 t2)
		{
			return t1.Add(t2);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan2"/> whose value is the negated value of the specified instance.
		/// </summary>
		/// <param name="t">A <see cref="TimeSpan2"/>.</param>
		/// <returns>A <see cref="TimeSpan2"/> with the same numeric value as this instance, but the opposite sign.</returns>
		public static TimeSpan2 operator -(TimeSpan2 t)
		{
			return new TimeSpan2(-t.core);
		}

		/// <summary>
		/// Subtracts a specified <see cref="TimeSpan2"/> from another specified <c>TimeSpan2</c>.
		/// </summary>
		/// <param name="t1">A <see cref="TimeSpan2"/>.</param>
		/// <param name="t2">A <c>TimeSpan2</c>.</param>
		/// <returns>A <see cref="TimeSpan2"/> whose value is the result of the value of <paramref name="t1"/> minus the value of <paramref name="t2"/>.</returns>
		public static TimeSpan2 operator -(TimeSpan2 t1, TimeSpan2 t2)
		{
			return t1.Subtract(t2);
		}

		/// <summary>
		/// Indicates whether a specified <see cref="TimeSpan2"/> is less than another specified <see cref="TimeSpan2"/>. 
		/// </summary>
		/// <param name="t1">A <see cref="TimeSpan2"/>.</param>
		/// <param name="t2">A <c>TimeSpan2</c>.</param>
		/// <returns><c>true</c> if the value of <paramref name="t1"/> is less than the value of <paramref name="t2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator <(TimeSpan2 t1, TimeSpan2 t2)
		{
			return (t1.core < t2.core);
		}

		/// <summary>
		/// Indicates whether a specified <see cref="TimeSpan2"/> is less than or equal to another specified <see cref="TimeSpan2"/>. 
		/// </summary>
		/// <param name="t1">A <see cref="TimeSpan2"/>.</param>
		/// <param name="t2">A <c>TimeSpan2</c>.</param>
		/// <returns><c>true</c> if the value of <paramref name="t1"/> is less than or equal to the value of <paramref name="t2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator <=(TimeSpan2 t1, TimeSpan2 t2)
		{
			return (t1.core <= t2.core);
		}

		/// <summary>
		/// Indicates whether two <see cref="TimeSpan2"/> instances are equal.
		/// </summary>
		/// <param name="t1">A <see cref="TimeSpan2"/>.</param>
		/// <param name="t2">A <c>TimeSpan2</c>.</param>
		/// <returns><c>true</c> if the values of <paramref name="t1"/> and <paramref name="t2"/> are equal; otherwise, <c>false</c>.</returns>
		public static bool operator ==(TimeSpan2 t1, TimeSpan2 t2)
		{
			return (t1.core == t2.core);
		}

		/// <summary>
		/// Indicates whether a specified <see cref="TimeSpan2"/> is greater than another specified <see cref="TimeSpan2"/>. 
		/// </summary>
		/// <param name="t1">A <see cref="TimeSpan2"/>.</param>
		/// <param name="t2">A <c>TimeSpan2</c>.</param>
		/// <returns><c>true</c> if the value of <paramref name="t1"/> is greater than the value of <paramref name="t2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator >(TimeSpan2 t1, TimeSpan2 t2)
		{
			return (t1.core > t2.core);
		}

		/// <summary>
		/// Indicates whether a specified <see cref="TimeSpan2"/> is greater than or equal to another specified <see cref="TimeSpan2"/>. 
		/// </summary>
		/// <param name="t1">A <see cref="TimeSpan2"/>.</param>
		/// <param name="t2">A <c>TimeSpan2</c>.</param>
		/// <returns><c>true</c> if the value of <paramref name="t1"/> is greater than or equal to the value of <paramref name="t2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator >=(TimeSpan2 t1, TimeSpan2 t2)
		{
			return (t1.core >= t2.core);
		}

		/// <summary>
		/// Compares two <see cref="TimeSpan2"/> values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
		/// </summary>
		/// <param name="t1">A <see cref="TimeSpan2"/>.</param>
		/// <param name="t2">A <c>TimeSpan2</c>.</param>
		/// <returns>
		/// <list>
		/// <listheader><term>Value</term><description>Condition</description></listheader>
		/// <item><term>-1</term><description><paramref name="t1"/> is shorter than <paramref name="t2"/></description></item>
		/// <item><term>0</term><description><paramref name="t1"/> is equal to <paramref name="t2"/></description></item>
		/// <item><term>1</term><description><paramref name="t1"/> is longer than <paramref name="t2"/></description></item>
		/// </list>
		/// </returns>
		public static int Compare(TimeSpan2 t1, TimeSpan2 t2)
		{
			return global::System.TimeSpan.Compare(t1.core, t2.core);
		}

		/// <summary>
		/// Indicates whether two <see cref="TimeSpan2"/> instances are equal.
		/// </summary>
		/// <param name="t1">A <see cref="TimeSpan2"/>.</param>
		/// <param name="t2">A <c>TimeSpan2</c>.</param>
		/// <returns><c>true</c> if the values of <paramref name="t1"/> and <paramref name="t2"/> are equal; otherwise, <c>false</c>.</returns>
		public static bool Equals(TimeSpan2 t1, TimeSpan2 t2)
		{
			return (t1.core == t2.core);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan2"/> that represents a specified number of days, where the specification is accurate to the nearest millisecond.
		/// </summary>
		/// <param name="value">A number of days, accurate to the nearest millisecond.</param>
		/// <returns>A <see cref="TimeSpan2"/> that represents <paramref name="value"/>.</returns>
		public static TimeSpan2 FromDays(double value)
		{
			return new TimeSpan2(global::System.TimeSpan.FromDays(value));
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan2"/> that represents a specified number of hours, where the specification is accurate to the nearest millisecond.
		/// </summary>
		/// <param name="value">A number of hours, accurate to the nearest millisecond.</param>
		/// <returns>A <see cref="TimeSpan2"/> that represents <paramref name="value"/>.</returns>
		public static TimeSpan2 FromHours(double value)
		{
			return new TimeSpan2(global::System.TimeSpan.FromHours(value));
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan2"/> that represents a specified number of milliseconds.
		/// </summary>
		/// <param name="value">A number of milliseconds.</param>
		/// <returns>A <see cref="TimeSpan2"/> that represents <paramref name="value"/>.</returns>
		public static TimeSpan2 FromMilliseconds(double value)
		{
			return new TimeSpan2(global::System.TimeSpan.FromMilliseconds(value));
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan2"/> that represents a specified number of minutes, where the specification is accurate to the nearest millisecond.
		/// </summary>
		/// <param name="value">A number of minutes, accurate to the nearest millisecond.</param>
		/// <returns>A <see cref="TimeSpan2"/> that represents <paramref name="value"/>.</returns>
		public static TimeSpan2 FromMinutes(double value)
		{
			return new TimeSpan2(global::System.TimeSpan.FromMinutes(value));
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan2"/> that represents a specified number of seconds, where the specification is accurate to the nearest millisecond.
		/// </summary>
		/// <param name="value">A number of seconds, accurate to the nearest millisecond.</param>
		/// <returns>A <see cref="TimeSpan2"/> that represents <paramref name="value"/>.</returns>
		public static TimeSpan2 FromSeconds(double value)
		{
			return new TimeSpan2(global::System.TimeSpan.FromSeconds(value));
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan2"/> that represents a specified time, where the specification is in units of ticks.
		/// </summary>
		/// <param name="value">A number of ticks that represent a time.</param>
		/// <returns>A <see cref="TimeSpan2"/> with a value of <paramref name="value"/>.</returns>
		public static TimeSpan2 FromTicks(long value)
		{
			return new TimeSpan2(global::System.TimeSpan.FromTicks(value));
		}

		/// <summary>
		/// Converts the specified string representation of a time span to its <see cref="TimeSpan2"/> equivalent. 
		/// </summary>
		/// <param name="value">A string containing a time span to parse.</param>
		/// <returns>A <see cref="TimeSpan2"/> equivalent to the time span contained in <paramref name="value"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
		/// <exception cref="FormatException"><paramref name="value"/> does not contain a valid string representation of a time span.</exception>
		public static TimeSpan2 Parse(string value)
		{
			return Parse(value, null);
		}

		/// <summary>
		/// Converts the specified string representation of a time span to its <see cref="TimeSpan2"/> equivalent using the specified culture-specific format information. 
		/// </summary>
		/// <param name="value">A string containing a time span to parse.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about <paramref name="value"/>.</param>
		/// <returns>A <see cref="TimeSpan2"/> equivalent to the time span contained in <paramref name="value"/> as specified by <paramref name="formatProvider"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
		/// <exception cref="FormatException"><paramref name="value"/> does not contain a valid string representation of a time span.</exception>
		public static TimeSpan2 Parse(string value, IFormatProvider formatProvider)
		{
			TimeSpan2FormatInfo fi = TimeSpan2FormatInfo.GetInstance(formatProvider);
			return new TimeSpan2(fi.Parse(value, null));
		}

		/// <summary>
		/// Converts the string representation of a time interval to its <see cref="TimeSpan2"/> equivalent by using the specified array of format strings and culture-specific format information. The format of the string representation must match the specified format exactly.
		/// </summary>
		/// <param name="input">A string that specifies the time interval to convert.</param>
		/// <param name="format">A standard or custom format string that defines the required format of <paramref name="input"/>.</param>
		/// <param name="formatProvider">An object that provides culture-specific formatting information.</param>
		/// <returns>A time interval that corresponds to <paramref name="input"/>, as specified by <paramref name="format"/> and <paramref name="formatProvider"/>.</returns>
		public static TimeSpan2 ParseExact(string input, string format, IFormatProvider formatProvider)
		{
			return ParseExact(input, new string[] { format }, formatProvider);
		}

		/// <summary>
		/// Converts the string representation of a time interval to its <see cref="TimeSpan2"/> equivalent by using the specified format and culture-specific format information. The format of the string representation must match the specified format exactly.
		/// </summary>
		/// <param name="input">A string that specifies the time interval to convert.</param>
		/// <param name="formats">A array of standard or custom format strings that defines the required format of <paramref name="input"/>.</param>
		/// <param name="formatProvider">An object that provides culture-specific formatting information.</param>
		/// <returns>A time interval that corresponds to <paramref name="input"/>, as specified by <paramref name="formats"/> and <paramref name="formatProvider"/>.</returns>
		public static TimeSpan2 ParseExact(string input, string[] formats, IFormatProvider formatProvider)
		{
			TimeSpan2FormatInfo fi = TimeSpan2FormatInfo.GetInstance(formatProvider);
			return fi.ParseExact(input, formats, null);
		}

		/// <summary>
		/// Converts the specified string representation of a date and time to its <see cref="TimeSpan2"/> equivalent and returns a value that indicates whether the conversion succeeded. 
		/// </summary>
		/// <param name="s">A string containing a time span to convert.</param>
		/// <param name="result">When this method returns, contains the <see cref="TimeSpan2"/> value equivalent to the time span contained in <paramref name="s"/>, if the conversion succeeded, or <c>TimeSpan.Zero</c> if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <c>null</c>, is an empty string (""), or does not contain a valid string representation of a time span. This parameter is passed uninitialized.</param>
		/// <returns><c>true</c> if the <paramref name="s"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
		public static bool TryParse(string s, out TimeSpan2 result)
		{
			return TryParse(s, null, out result);
		}

		/// <summary>
		/// Converts the specified string representation of a date and time to its <see cref="TimeSpan2"/> equivalent and returns a value that indicates whether the conversion succeeded. 
		/// </summary>
		/// <param name="s">A string containing a time span to convert.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about <paramref name="s"/>.</param>
		/// <param name="result">When this method returns, contains the <see cref="TimeSpan2"/> value equivalent to the time span contained in <paramref name="s"/>, if the conversion succeeded, or <c>TimeSpan.Zero</c> if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <c>null</c>, is an empty string (""), or does not contain a valid string representation of a time span. This parameter is passed uninitialized.</param>
		/// <returns><c>true</c> if the <paramref name="s"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
		public static bool TryParse(string s, IFormatProvider formatProvider, out TimeSpan2 result)
		{
			TimeSpan2FormatInfo fi = TimeSpan2FormatInfo.GetInstance(formatProvider);
			return fi.TryParse(s, null, out result.core);
		}

		/// <summary>
		/// Converts the string representation of a time interval to its <see cref="TimeSpan2"/> equivalent by using the specified format and culture-specific format information, and returns a value that indicates whether the conversion succeeded. The format of the string representation must match the specified format exactly.
		/// </summary>
		/// <param name="input">A string that specifies the time interval to convert.</param>
		/// <param name="format">A standard or custom format string that defines the required format of <paramref name="input"/>.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about <paramref name="input"/>.</param>
		/// <param name="result">When this method returns, contains an object that represents the time interval specified by <paramref name="input"/>, or <see cref="TimeSpan.Zero"/> if the conversion failed. This parameter is passed uninitialized.</param>
		/// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
		public static bool TryParseExact(string input, string format, IFormatProvider formatProvider, out TimeSpan2 result)
		{
			return TryParseExact(input, new string[] { format }, formatProvider, out result);
		}

		/// <summary>
		/// Converts the string representation of a time interval to its <see cref="TimeSpan2"/> equivalent by using the specified formats and culture-specific format information, and returns a value that indicates whether the conversion succeeded. The format of the string representation must match one of the specified formats exactly.
		/// </summary>
		/// <param name="input">A string that specifies the time interval to convert.</param>
		/// <param name="formats">A array of standard or custom format strings that define the acceptable formats of <paramref name="input"/>.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about <paramref name="input"/>.</param>
		/// <param name="result">When this method returns, contains an object that represents the time interval specified by <paramref name="input"/>, or <see cref="TimeSpan.Zero"/> if the conversion failed. This parameter is passed uninitialized.</param>
		/// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
		public static bool TryParseExact(string input, string[] formats, IFormatProvider formatProvider, out TimeSpan2 result)
		{
			TimeSpan2FormatInfo fi = TimeSpan2FormatInfo.GetInstance(formatProvider);
			return fi.TryParseExact(input, formats, null, out result.core);
		}

		/// <summary>
		/// Adds the specified <see cref="TimeSpan2"/> to this instance.
		/// </summary>
		/// <param name="ts">A <see cref="TimeSpan2"/>.</param>
		/// <returns>A <see cref="TimeSpan2"/> that represents the value of this instance plus the value of <paramref name="ts"/>.</returns>
		public TimeSpan2 Add(TimeSpan2 ts)
		{
			return new TimeSpan2(core.Add(ts.core));
		}

		/// <summary>
		/// Compares this instance to a specified object and returns an integer that indicates whether this [instance] is shorter than, equal to, or longer than the specified object. 
		/// </summary>
		/// <param name="value">An object to compare, or <c>null</c>.</param>
		/// <returns>A signed number indicating the relative values of this instance and <paramref name="value"/>.
		/// <list>
		/// <listheader><term>Value</term><description>Condition</description></listheader>
		/// <item><term>-1</term><description>This instance is shorter than <paramref name="value"/></description></item>
		/// <item><term>0</term><description>This instance is equal to <paramref name="value"/></description></item>
		/// <item><term>1</term><description>This instance is longer than <paramref name="value"/></description></item>
		/// </list>
		/// </returns>
		public int CompareTo(object value)
		{
			if (value is TimeSpan2)
				value = ((TimeSpan2)value).core;
			return core.CompareTo(value);
		}

		/// <summary>
		/// Compares this instance to a specified <see cref="TimeSpan2"/> object and returns an integer that indicates whether this [instance] is shorter than, equal to, or longer than the <see cref="TimeSpan2"/> object.
		/// </summary>
		/// <param name="value">A <see cref="TimeSpan2"/> object to compare to this instance.</param>
		/// <returns>A signed number indicating the relative values of this instance and <paramref name="value"/>.
		/// <list>
		/// <listheader><term>Value</term><description>Condition</description></listheader>
		/// <item><term>-1</term><description>This instance is shorter than <paramref name="value"/></description></item>
		/// <item><term>0</term><description>This instance is equal to <paramref name="value"/></description></item>
		/// <item><term>1</term><description>This instance is longer than <paramref name="value"/></description></item>
		/// </list>
		/// </returns>
		public int CompareTo(TimeSpan2 value)
		{
			return core.CompareTo(value.core);
		}

		/// <summary>
		/// Compares this instance to a specified <see cref="TimeSpan"/> object and returns an integer that indicates whether this [instance] is shorter than, equal to, or longer than the <see cref="TimeSpan2"/> object.
		/// </summary>
		/// <param name="value">A <see cref="TimeSpan"/> object to compare to this instance.</param>
		/// <returns>A signed number indicating the relative values of this instance and <paramref name="value"/>.
		/// <list>
		/// <listheader><term>Value</term><description>Condition</description></listheader>
		/// <item><term>-1</term><description>This instance is shorter than <paramref name="value"/></description></item>
		/// <item><term>0</term><description>This instance is equal to <paramref name="value"/></description></item>
		/// <item><term>1</term><description>This instance is longer than <paramref name="value"/></description></item>
		/// </list>
		/// </returns>
		public int CompareTo(TimeSpan value)
		{
			return core.CompareTo(value);
		}

		/// <summary>
		/// Returns a new <see cref="TimeSpan2"/> object whose value is the absolute value of the current <see cref="TimeSpan2"/> object.
		/// </summary>
		/// <returns>A new <see cref="TimeSpan2"/> object whose value is the absolute value of the current <see cref="TimeSpan2"/> object.</returns>
		public TimeSpan2 Duration()
		{
			return new TimeSpan2(core.Duration());
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object.
		/// </summary>
		/// <param name="value">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the <paramref name="value"/> parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object value)
		{
			if (value is TimeSpan2)
				return core.Equals(((TimeSpan2)value).core);
			return core.Equals(value);
		}

		/// <summary>
		/// Indicates whether the current object is equal to a specified <see cref="TimeSpan2"/> object.
		/// </summary>
		/// <param name="obj">A <see cref="TimeSpan2"/> object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the <paramref name="obj"/> parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(TimeSpan2 obj)
		{
			return core.Equals(obj.core);
		}

		/// <summary>
		/// Indicates whether the current object is equal to a specified <see cref="TimeSpan"/> object.
		/// </summary>
		/// <param name="other">A <see cref="TimeSpan"/> object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(TimeSpan other)
		{
			return core.Equals(other);
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that is the hash code for this instance.
		/// </returns>
		public override int GetHashCode()
		{
			return core.GetHashCode();
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.Object;
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(core.Ticks);
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return Convert.ToDecimal(core.Ticks);
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return Convert.ToDouble(core.Ticks);
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(core.Ticks);
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return Convert.ToInt32(core.Ticks);
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return core.Ticks;
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(core.Ticks);
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(core.Ticks);
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return ToString(null, provider);
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			if (conversionType == typeof(TimeSpan))
				return core;
			else if (conversionType == typeof(TimeSpan2))
				return this;
			return Convert.ChangeType(this, conversionType, provider);
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(core.Ticks);
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(core.Ticks);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(core.Ticks);
		}

		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
				throw new ArgumentNullException("info");
			info.AddValue("ticks", core.Ticks);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan2"/> whose value is the negated value of this instance.
		/// </summary>
		/// <returns>The same numeric value as this instance, but with the opposite sign.</returns>
		public TimeSpan2 Negate()
		{
			return new TimeSpan2(core.Negate());
		}

		/// <summary>
		/// Subtracts the specified <see cref="TimeSpan2"/> from this instance.
		/// </summary>
		/// <param name="ts">A <see cref="TimeSpan2"/>.</param>
		/// <returns>A <see cref="TimeSpan2"/> whose value is the result of the value of this instance minus the value of <paramref name="ts"/>.</returns>
		public TimeSpan2 Subtract(TimeSpan2 ts)
		{
			return new TimeSpan2(core.Subtract(ts.core));
		}

		/// <summary>
		/// Returns string representation of the value of this instance using the specified format.
		/// </summary>
		/// <param name="format">A TimeSpan format string.</param>
		/// <param name="formatProvider">An <see cref="T:System.IFormatProvider"/> object that supplies format information about the current instance.</param>
		/// <returns>A string representation of value of the current <see cref="TimeSpan2"/> object as specified by format.</returns>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			TimeSpan2FormatInfo tfi = TimeSpan2FormatInfo.GetInstance(formatProvider);
			return tfi.Format(format, this, formatProvider);
		}

		/// <summary>
		/// Returns string representation of the value of this instance using the specified format.
		/// </summary>
		/// <param name="format">A TimeSpan format string.</param>
		/// <returns>A string representation of value of the current <see cref="TimeSpan2"/> object as specified by format.</returns>
		/// <remarks>
		/// <para>The following table lists the standard TimeSpan format patterns.</para>
		/// <list type="table">
		/// <listheader><term>Format specifier</term><description>Name</description><description>Description</description><description>Examples</description></listheader>
		/// <item><term>"c"</term>
		///		<description>Constant (invariant) format</description>
		///		<description>This specifier is not culture-sensitive. It takes the form <code>[-][d’.’]hh’:’mm’:’ss[‘.’fffffff]</code>.</description>
		///		<description></description>
		/// </item>
		/// <item><term>"f"</term>
		///		<description>General word format</description>
		///		<description></description>
		///		<description></description>
		/// </item>
		/// <item><term>"g"</term>
		///		<description>General short format</description>
		///		<description>This specifier outputs only what is needed. It is culture-sensitive and takes the form <code>[-][d’:’]h’:’mm’:’ss[.FFFFFFF]</code>.</description>
		///		<description></description>
		/// </item>
		/// <item><term>"G"</term>
		///		<description>General long format</description>
		///		<description>This specifier always outputs days and seven fractional digits. It is culture-sensitive and takes the form <code>[-]d’:’hh’:’mm’:’ss.fffffff</code>.</description>
		///		<description></description>
		/// </item>
		/// </list>
		/// <para>The following table lists the standard TimeSpan format patterns.</para>
		/// <list type="table">
		/// <listheader><term>Format specifier</term><description>Description</description><description>Examples</description></listheader>
		/// <item><term>"d", "%d"</term>
		///		<description>The number of whole days in the time interval.</description>
		///		<description></description>
		/// </item>
		/// <item><term>"dd"-"dddddddd"</term>
		///		<description>The number of whole days in the time interval, padded with leading zeros as needed.</description>
		///		<description></description>
		/// </item>
		/// <item><term>"h", "%h"</term>
		///		<description>The number of whole hours in the time interval that are not counted as part of days. Single-digit hours do not have a leading zero.</description>
		///		<description></description>
		/// </item>
		/// <item><term>"hh"</term>
		///		<description>The number of whole hours in the time interval that are not counted as part of days. Single-digit hours have a leading zero.</description>
		///		<description></description>
		/// </item>
		/// </list>
		/// </remarks>
		public string ToString(string format)
		{
			return TimeSpan2FormatInfo.CurrentInfo.Format(format, this, null);
		}

		/// <summary>
		/// Returns the string representation of the value of this instance.
		/// </summary>
		/// <returns>
		/// A string that represents the value of this instance. The return value is of the form: 
		/// <para>[-][d.]hh:mm:ss[.fffffff]</para>
		/// </returns>
		public override string ToString()
		{
			return core.ToString();
		}
	}
}