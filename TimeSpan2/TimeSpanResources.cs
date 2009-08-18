using System;

namespace System.Globalization
{
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    internal class TimeSpanResources
    {
        private global::System.Globalization.CultureInfo resourceCulture;
        private global::System.Resources.ResourceManager resourceMan;

		internal TimeSpanResources()
        {
        }

		public TimeSpanResources(CultureInfo culture)
		{
			resourceCulture = culture;
		}

        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal global::System.Globalization.CultureInfo Culture
        {
            get { return resourceCulture; }
			set { resourceCulture = value; resourceMan = null; }
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal global::System.Resources.ResourceManager ResourceManager
        {
            get
			{
                if (object.ReferenceEquals(resourceMan, null))
				{
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("System.Properties.Resources", typeof(TimeSpanResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

		internal string GetString(string name)
		{
			string ret = ResourceManager.GetString(name, resourceCulture);
			return string.IsNullOrEmpty(ret) ? string.Empty : ret;
		}

        /// <summary>
        ///   Looks up a localized string similar to days,day,d.
        /// </summary>
        internal string TimeSpanDayStrings
        {
            get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
        }

        /// <summary>
        ///   Looks up a localized string similar to dhmst.
        /// </summary>
        internal string TimeSpanFullBuildOrder
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to hours,hour,hrs,hr,h.
        /// </summary>
        internal string TimeSpanHourStrings
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to {0} days.
        /// </summary>
        internal string TimeSpanManyDayFormat
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to {0} hours.
        /// </summary>
        internal string TimeSpanManyHourFormat
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to {0} milliseconds.
        /// </summary>
        internal string TimeSpanManyMillisecondFormat
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to {0} minutes.
        /// </summary>
        internal string TimeSpanManyMinuteFormat
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to {0} seconds.
        /// </summary>
        internal string TimeSpanManySecondFormat
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to milliseconds,millisecond,msec,ms.
        /// </summary>
        internal string TimeSpanMillisecondStrings
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to minutes,minute,mins,min,m.
        /// </summary>
        internal string TimeSpanMinuteStrings
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to {0} day.
        /// </summary>
        internal string TimeSpanOneDayFormat
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to {0} hour.
        /// </summary>
        internal string TimeSpanOneHourFormat
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to {0} millisecond.
        /// </summary>
        internal string TimeSpanOneMillisecondFormat
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to {0} minute.
        /// </summary>
        internal string TimeSpanOneMinuteFormat
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to {0} second.
        /// </summary>
        internal string TimeSpanOneSecondFormat
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to \s*(?:(?&lt;d&gt;\d+)\s*d)?(?:\s*|\s*,\s*)(?:(?&lt;h&gt;\d+)\s*h)?(?:\s*|\s*,\s*)(?:(?&lt;m&gt;\d+)\s*m)?(?:\s*|\s*,\s*)(?:(?&lt;s&gt;\d+)\s*s)?(?:\s*|\s*,\s*)(?:(?&lt;t&gt;\d+)\s*t)?\s*.
        /// </summary>
        internal string TimeSpanParseRegEx
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to seconds,second,secs,sec,s.
        /// </summary>
        internal string TimeSpanSecondStrings
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}

        /// <summary>
        ///   Looks up a localized string similar to , .
        /// </summary>
        internal string TimeSpanSeparator
        {
			get { return GetString(System.Reflection.MethodInfo.GetCurrentMethod().Name.Substring(4)); }
		}
    }
}