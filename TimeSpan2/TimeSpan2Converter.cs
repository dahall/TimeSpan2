using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace System
{
	public class TimeSpan2Converter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) ||
				TypeDescriptor.GetConverter(sourceType).CanConvertTo(typeof(long)) ||
				base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				if (string.IsNullOrEmpty((string)value))
					return TimeSpan2.Zero;

				TimeSpan2FormatInfo fi = new TimeSpan2FormatInfo(culture);
				TimeSpan ts;
				if (fi.TryParse(value.ToString(), null, out ts))
					return (TimeSpan2)ts;
			}
			try { long l = Convert.ToInt64(value); return new TimeSpan2(l); }
			catch { }
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value is TimeSpan)
				value = new TimeSpan2((TimeSpan)value);
			if (value is TimeSpan2)
			{
				if (destinationType == typeof(InstanceDescriptor))
				{
					TimeSpan2 ts = (TimeSpan2)value;
					/*if (ts.IsZero)
					{
						System.Reflection.FieldInfo field = outType.GetField("Zero");
						if (field != null)
							return new InstanceDescriptor(field, new object[0]);
					}
					else
					{*/
					if (ts.Ticks % TimeSpan.TicksPerSecond == 0)
					{
						System.Reflection.ConstructorInfo constructor = typeof(TimeSpan2).GetConstructor(new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) });
						if (constructor != null)
							return new InstanceDescriptor(constructor, new object[] { ts.Days, ts.Hours, ts.Minutes, ts.Seconds });
					}
					else
					{
						System.Reflection.ConstructorInfo constructor = typeof(TimeSpan2).GetConstructor(new Type[] { typeof(long) });
						if (constructor != null)
							return new InstanceDescriptor(constructor, new object[] { ts.Ticks });
					}
				}

				try { return Convert.ChangeType(value, destinationType); }
				catch { }
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
		{
			if (propertyValues == null)
				throw new ArgumentNullException("propertyValues");

			object obj = propertyValues["Ticks"];
			if ((obj == null) || (!(obj is long)))
			{
				throw new ArgumentException("Invalid property entry.");
			}
			return new TimeSpan2((long)obj);
		}

		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(value.GetType(), attributes).Sort(new string[] { "Ticks" });
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}
