using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
    [Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true)]
    public struct TimeSpan2 : IComparable, IComparable<TimeSpan2>, IComparable<TimeSpan>, IEquatable<TimeSpan2>, IEquatable<TimeSpan>, IFormattable, IConvertible, ISerializable
    {
        private TimeSpan core;

        public static readonly TimeSpan2 MaxValue;
        public static readonly TimeSpan2 MinValue;
        public static readonly TimeSpan2 Zero;

        static TimeSpan2()
        {
            Zero = new TimeSpan2(TimeSpan.Zero);
            MaxValue = new TimeSpan2(TimeSpan.MaxValue);
            MinValue = new TimeSpan2(TimeSpan.MinValue);
        }

        public TimeSpan2(TimeSpan span)
        {
            core = span;
        }

        public TimeSpan2(long ticks)
        {
            core = new TimeSpan(ticks);
        }

        public TimeSpan2(int hours, int minutes, int seconds)
        {
            core = new TimeSpan(hours, minutes, seconds);
        }

        public TimeSpan2(int days, int hours, int minutes, int seconds)
            : this(days, hours, minutes, seconds, 0)
        {
        }

        public TimeSpan2(int days, int hours, int minutes, int seconds, int milliseconds)
        {
            core = new TimeSpan(days, hours, minutes, seconds, milliseconds);
        }

        public int Days
        {
            get { return core.Days; }
        }

        public int Hours
        {
            get { return core.Hours; }
        }

        public int Milliseconds
        {
            get { return core.Milliseconds; }
        }

        public int Minutes
        {
            get { return core.Minutes; }
        }

        public int Seconds
        {
            get { return core.Seconds; }
        }

        public long Ticks
        {
            get { return core.Ticks; }
        }

        public double TotalDays
        {
            get { return core.TotalDays; }
        }

        public double TotalHours
        {
            get { return core.TotalHours; }
        }

        public double TotalMilliseconds
        {
            get { return core.TotalMilliseconds; }
        }

        public double TotalMinutes
        {
            get { return core.TotalMinutes; }
        }

        public double TotalSeconds
        {
            get { return core.TotalSeconds; }
        }

        public static implicit operator TimeSpan(TimeSpan2 d)
        {
            return d.core;
        }

        public static implicit operator TimeSpan2(TimeSpan d)
        {
            return new TimeSpan2(d);
        }

        public static bool operator !=(TimeSpan2 t1, TimeSpan2 t2)
        {
            return (t1.core != t2.core);
        }

        public static TimeSpan2 operator +(TimeSpan2 t)
        {
            return t;
        }

        public static TimeSpan2 operator +(TimeSpan2 t1, TimeSpan2 t2)
        {
            return t1.Add(t2);
        }

        public static TimeSpan2 operator -(TimeSpan2 t)
        {
            return new TimeSpan2(-t.core);
        }

        public static TimeSpan2 operator -(TimeSpan2 t1, TimeSpan2 t2)
        {
            return t1.Subtract(t2);
        }

        public static bool operator <(TimeSpan2 t1, TimeSpan2 t2)
        {
            return (t1.core < t2.core);
        }

        public static bool operator <=(TimeSpan2 t1, TimeSpan2 t2)
        {
            return (t1.core <= t2.core);
        }

        public static bool operator ==(TimeSpan2 t1, TimeSpan2 t2)
        {
            return (t1.core == t2.core);
        }

        public static bool operator >(TimeSpan2 t1, TimeSpan2 t2)
        {
            return (t1.core > t2.core);
        }

        public static bool operator >=(TimeSpan2 t1, TimeSpan2 t2)
        {
            return (t1.core >= t2.core);
        }

        public static int Compare(TimeSpan2 t1, TimeSpan2 t2)
        {
            return global::System.TimeSpan.Compare(t1.core, t2.core);
        }

        public static bool Equals(TimeSpan2 t1, TimeSpan2 t2)
        {
            return (t1.core == t2.core);
        }

        public static TimeSpan2 FromDays(double value)
        {
            return new TimeSpan2(global::System.TimeSpan.FromDays(value));
        }

        public static TimeSpan2 FromHours(double value)
        {
            return new TimeSpan2(global::System.TimeSpan.FromHours(value));
        }

        public static TimeSpan2 FromMilliseconds(double value)
        {
            return new TimeSpan2(global::System.TimeSpan.FromMilliseconds(value));
        }

        public static TimeSpan2 FromMinutes(double value)
        {
            return new TimeSpan2(global::System.TimeSpan.FromMinutes(value));
        }

        public static TimeSpan2 FromSeconds(double value)
        {
            return new TimeSpan2(global::System.TimeSpan.FromSeconds(value));
        }

        public static TimeSpan2 FromTicks(long value)
        {
            return new TimeSpan2(global::System.TimeSpan.FromTicks(value));
        }

        public static TimeSpan2 Parse(string value)
        {
            return Parse(value, null, String.Empty);
        }

        public static TimeSpan2 Parse(string value, IFormatProvider formatProvider)
        {
            return Parse(value, formatProvider, String.Empty);
        }

        public static TimeSpan2 Parse(string value, IFormatProvider formatProvider, string formattedZero)
        {
			TimeSpanFormatInfo fi = TimeSpanFormatInfo.GetInstance(formatProvider);
			fi.TimeSpanZeroDisplay = formattedZero;
			return new TimeSpan2(fi.Parse(value));
        }

		public static bool TryParse(string s, IFormatProvider formatProvider, string formattedZero, out TimeSpan2 result)
		{
			TimeSpanFormatInfo fi = TimeSpanFormatInfo.GetInstance(formatProvider);
			fi.TimeSpanZeroDisplay = formattedZero;
			return fi.TryParse(s, out result.core);
		}

		public static bool TryParse(string s, string formattedZero, out TimeSpan2 result)
		{
			return TryParse(s, null, formattedZero, out result);
		}

		public static bool TryParse(string s, out TimeSpan2 result)
        {
			return TryParse(s, null, null, out result);
        }

        public TimeSpan2 Add(TimeSpan2 ts)
        {
            return new TimeSpan2(core.Add(ts.core));
        }

        public int CompareTo(object value)
        {
            if (value is TimeSpan2)
                value = ((TimeSpan2)value).core;
            return core.CompareTo(value);
        }

        public int CompareTo(TimeSpan2 value)
        {
            return core.CompareTo(value.core);
        }

        public int CompareTo(TimeSpan other)
        {
            return core.CompareTo(other);
        }

        public TimeSpan2 Duration()
        {
            return new TimeSpan2(core.Duration());
        }

        public override bool Equals(object value)
        {
            if (value is TimeSpan2)
                return core.Equals(((TimeSpan2)value).core);
            return core.Equals(value);
        }

        public bool Equals(TimeSpan2 obj)
        {
            return core.Equals(obj.core);
        }

        public bool Equals(TimeSpan other)
        {
            return core.Equals(other);
        }

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

        public TimeSpan2 Negate()
        {
            return new TimeSpan2(core.Negate());
        }

        public TimeSpan2 Subtract(TimeSpan2 ts)
        {
            return new TimeSpan2(core.Subtract(ts.core));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
			TimeSpanFormatInfo tfi = TimeSpanFormatInfo.GetInstance(formatProvider);
			return tfi.Format(format, this, formatProvider);
        }

        public override string ToString()
        {
            return ToString(null, null);
        }
    }
}