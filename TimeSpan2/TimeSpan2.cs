using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable,
    StructLayout(LayoutKind.Sequential),
    ComVisible(true)]
    public struct TimeSpan2 : IComparable, IComparable<TimeSpan2>, IComparable<TimeSpan>, IEquatable<TimeSpan2>, IEquatable<TimeSpan>, IFormattable, IConvertible, ISerializable
    {
        private TimeSpan core;

		/// <summary>Represents the maximum <see cref="TimeSpan2"/> value. This field is read-only.</summary>
		public static readonly TimeSpan2 MaxValue;

		/// <summary>Represents the minimum <see cref="TimeSpan2"/> value. This field is read-only.</summary>
		public static readonly TimeSpan2 MinValue;

        /// <summary>Represents the zero <see cref="TimeSpan2"/> value. This field is read-only.</summary>
        public static readonly TimeSpan2 Zero;

        static TimeSpan2()
        {
            Zero = new TimeSpan2(TimeSpan.Zero);
            MaxValue = new TimeSpan2(TimeSpan.MaxValue);
            MinValue = new TimeSpan2(TimeSpan.MinValue);
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
		/// Gets the days component of the time interval represented by the current <see cref="TimeSpan2"/> structure.
        /// </summary>
		/// <value>The day component of this instance. The return value can be positive or negative.</value>
        public int Days
        {
            get { return core.Days; }
        }

		/// <summary>
		/// Gets the hours component of the time interval represented by the current <see cref="TimeSpan2"/> structure.
		/// </summary>
		/// <value>The hours component of this instance. The return value ranges from -23 through 23.</value>
		public int Hours
        {
            get { return core.Hours; }
        }

		/// <summary>
		/// Gets the milliseconds component of the time interval represented by the current <see cref="TimeSpan2"/> structure.
		/// </summary>
		/// <value>The milliseconds component of this instance. The return value ranges from -999 through 999.</value>
		public int Milliseconds
        {
            get { return core.Milliseconds; }
        }

		/// <summary>
		/// Gets the minutes component of the time interval represented by the current <see cref="TimeSpan2"/> structure.
		/// </summary>
		/// <value>The minutes component of this instance. The return value ranges from -59 through 59.</value>
		public int Minutes
        {
            get { return core.Minutes; }
        }

		/// <summary>
		/// Gets the seconds component of the time interval represented by the current <see cref="TimeSpan2"/> structure.
		/// </summary>
		/// <value>The seconds component of this instance. The return value ranges from -59 through 59.</value>
		public int Seconds
        {
            get { return core.Seconds; }
        }

        /// <summary>
		/// Gets the number of ticks that represent the value of the current <see cref="TimeSpan2"/> structure.
        /// </summary>
        /// <value>The number of ticks contained in this instance.</value>
        public long Ticks
        {
            get { return core.Ticks; }
        }

        /// <summary>
		/// Gets the value of the current <see cref="TimeSpan2"/> structure expressed in whole and fractional days.
        /// </summary>
		/// <value>The total number of days represented by this instance.</value>
        public double TotalDays
        {
            get { return core.TotalDays; }
        }

		/// <summary>
		/// Gets the value of the current <see cref="TimeSpan2"/> structure expressed in whole and fractional hours.
		/// </summary>
		/// <value>The total number of hours represented by this instance.</value>
		public double TotalHours
        {
            get { return core.TotalHours; }
        }

		/// <summary>
		/// Gets the value of the current <see cref="TimeSpan2"/> structure expressed in whole and fractional milliseconds.
		/// </summary>
		/// <value>The total number of milliseconds represented by this instance.</value>
		public double TotalMilliseconds
        {
            get { return core.TotalMilliseconds; }
        }

		/// <summary>
		/// Gets the value of the current <see cref="TimeSpan2"/> structure expressed in whole and fractional minutes.
		/// </summary>
		/// <value>The total number of minutes represented by this instance.</value>
		public double TotalMinutes
        {
            get { return core.TotalMinutes; }
        }

		/// <summary>
		/// Gets the value of the current <see cref="TimeSpan2"/> structure expressed in whole and fractional seconds.
		/// </summary>
		/// <value>The total number of seconds represented by this instance.</value>
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
            return Parse(value, null, String.Empty);
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
            return Parse(value, formatProvider, String.Empty);
        }

		/// <summary>
		/// Converts the specified string representation of a time span to its <see cref="TimeSpan2"/> equivalent using the specified culture-specific format information. 
		/// </summary>
		/// <param name="value">A string containing a time span to parse.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about <paramref name="value"/>.</param>
		/// <param name="formattedZero">The string to use if <paramref name="value"/> equals <c>TimeSpan2.Zero</c>.</param>
		/// <returns>A <see cref="TimeSpan2"/> equivalent to the time span contained in <paramref name="value"/> as specified by <paramref name="formatProvider"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
		/// <exception cref="FormatException"><paramref name="value"/> does not contain a valid string representation of a time span.</exception>
		public static TimeSpan2 Parse(string value, IFormatProvider formatProvider, string formattedZero)
        {
            TimeSpanFormatInfo fi = TimeSpanFormatInfo.GetInstance(formatProvider);
            fi.TimeSpanZeroDisplay = formattedZero;
            return new TimeSpan2(fi.Parse(value));
        }

		/// <summary>
		/// Converts the specified string representation of a date and time to its <see cref="TimeSpan2"/> equivalent and returns a value that indicates whether the conversion succeeded. 
		/// </summary>
		/// <param name="s">A string containing a time span to convert.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about <paramref name="s"/>.</param>
		/// <param name="formattedZero">The string to use if <paramref name="s"/> equals <c>TimeSpan2.Zero</c>.</param>
		/// <param name="result">When this method returns, contains the <see cref="TimeSpan2"/> value equivalent to the time span contained in <paramref name="s"/>, if the conversion succeeded, or <c>TimeSpan.Zero</c> if the conversion failed. The conversion fails if the <paramref name="value"/> parameter is <c>null</c>, is an empty string (""), or does not contain a valid string representation of a time span. This parameter is passed uninitialized.</param>
		/// <returns><c>true</c> if the <paramref name="s"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
		public static bool TryParse(string s, IFormatProvider formatProvider, string formattedZero, out TimeSpan2 result)
        {
            TimeSpanFormatInfo fi = TimeSpanFormatInfo.GetInstance(formatProvider);
            fi.TimeSpanZeroDisplay = formattedZero;
            return fi.TryParse(s, out result.core);
        }

		/// <summary>
		/// Converts the specified string representation of a date and time to its <see cref="TimeSpan2"/> equivalent and returns a value that indicates whether the conversion succeeded. 
		/// </summary>
		/// <param name="s">A string containing a time span to convert.</param>
		/// <param name="formattedZero">The string to use if <paramref name="s"/> equals <c>TimeSpan2.Zero</c>.</param>
		/// <param name="result">When this method returns, contains the <see cref="TimeSpan2"/> value equivalent to the time span contained in <paramref name="s"/>, if the conversion succeeded, or <c>TimeSpan.Zero</c> if the conversion failed. The conversion fails if the <paramref name="value"/> parameter is <c>null</c>, is an empty string (""), or does not contain a valid string representation of a time span. This parameter is passed uninitialized.</param>
		/// <returns><c>true</c> if the <paramref name="s"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
		public static bool TryParse(string s, string formattedZero, out TimeSpan2 result)
        {
            return TryParse(s, null, formattedZero, out result);
        }

		/// <summary>
		/// Converts the specified string representation of a date and time to its <see cref="TimeSpan2"/> equivalent and returns a value that indicates whether the conversion succeeded. 
		/// </summary>
		/// <param name="s">A string containing a time span to convert.</param>
		/// <param name="result">When this method returns, contains the <see cref="TimeSpan2"/> value equivalent to the time span contained in <paramref name="s"/>, if the conversion succeeded, or <c>TimeSpan.Zero</c> if the conversion failed. The conversion fails if the <paramref name="value"/> parameter is <c>null</c>, is an empty string (""), or does not contain a valid string representation of a time span. This parameter is passed uninitialized.</param>
		/// <returns><c>true</c> if the <paramref name="s"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
		public static bool TryParse(string s, out TimeSpan2 result)
        {
            return TryParse(s, null, null, out result);
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
		public int CompareTo(TimeSpan other)
        {
            return core.CompareTo(other);
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
		/// <remarks>The following table lists the standard TimeSpan format patterns.
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
		public string ToString(string format, IFormatProvider formatProvider)
        {
            TimeSpanFormatInfo tfi = TimeSpanFormatInfo.GetInstance(formatProvider);
            return tfi.Format(format, this, formatProvider);
        }

        /// <summary>
		/// Returns the string representation of the value of this instance.
        /// </summary>
        /// <returns>
		/// A string that represents the value of this instance. The return value is of the form: 
		/// <para>[-][d.]hh:mm:ss[.fffffff]</para>
		/// <para>Elements in square brackets ([ and ]) may not be included in the returned string. Colons and periods (: and.) are literal characters. The non-literal elements are listed in the following table.</para>
		/// <list>
		/// <listheader><term>Item</term><description>Description</description></listheader>
		/// <item><term>"-"</term><description>A minus sign, which indicates a negative time span. No sign is included for a positive time span</description></item>
		/// <item><term>"d"</term><description>The number of days in the time span. This element is omitted if the time span is less than one day.</description></item>
		/// <item><term>"hh"</term><description>The number of hours in the time span, ranging from 0 to 23.</description></item>
		/// <item><term>"mm"</term><description>The number of minutes in the time span, ranging from 0 to 59.</description></item>
		/// <item><term>"ss"</term><description>The number of seconds in the time span, ranging from 0 to 59.</description></item>
		/// <item><term>"fffffff"</term><description>Fractional seconds in the time span. This element is omitted if the time span does not include fractional seconds. If present, fractional seconds are always expressed using 7 decimal digits.</description></item>
		/// </list>
		/// </returns>
		public override string ToString()
        {
            return ToString(null, null);
        }
    }
}