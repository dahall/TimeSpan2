**_The following applies only to the 2.0 version of the TimeSpan2 library._**

The following tables list the format patterns associated with TimeSpan2FormatInfo properties. After any format pattern, standard or custom, a custom string for the Zero value can be provided after a semi-colon. For example, if the {{TimeSpan2}} value was equal to {{TimeSpan2.Zero}} and the format pattern was just "c", then the output would be "00:00:00". If the format pattern was "c;Nothing", the formatted output would be "Nothing". This can be used in place of setting the {{TimeSpan2FormatInfo.TimeSpanZeroDisplay}} property.

|| Standard format pattern || Associated Property/Description ||
| "c" | Constant (invariant) format. This specifier is not culture-sensitive. It takes the form {{[-](-)[d’.’](d’.’)hh’:’mm’:’ss[‘.’fffffff](‘.’fffffff)}} |
| "f" | Fully localized string displaying each time element with separator between (e.g. '1 day, 4 hours, 17 minutes') |
| "g" | General short format. This specifier outputs only what is needed. It is culture-sensitive and takes the form {{[-](-)[d’:’](d’_’)h’:’mm’:’ss[.FFFFFFF](.FFFFFFF)}} |
| "G" | General long format. This specifier always outputs days and seven fractional digits. It is culture-sensitive and takes the form {{[-](-)d’:’hh’:’mm’:’ss.fffffff}} |
| "x" | ISO 8601 XML standard for durations. It is not culture-sensitive and takes the form {{'P'[d'D'](d'D')['T'[h'H']('T'[h'H')[m'M'](m'M')[p3'S'](p3'S')];PT0S}}. It does not support the parsing of the year or month values specified by the standard as those values are indeterminate based on whether the year or month in question is affected by leap year. |

For custom format strings when parsing, the specifiers with a preceding '%' character and a single specifying character (e.g. "%s", "s") can be used without the '%' character. When formatting, the '%' is required if the format string consists of only that character. For example, "h" is a valid parsing format and will translate any digits to hours in the resulting time interval. However, to format an existing time interval, "%h" must be specified so as to not make the formatter look for a standard pattern called "h".

|| Custom format specifier || Associated Property/Description ||
| "{{[}}<custom specifier(s)>{{](}}_custom-specifier(s)_{{)}}" | The square brackets provide the ability to mark the enclosed specifiers as optional. For parsing, these elements must not be present in order for the string to be parsed. For formatting, the enclosed elements will only be displayed if there is at least on number value that does not equal 0. |
| "d", "%d" | The number of whole days in the time interval. |
| "dd"-"dddddddd" | The number of whole days in the time interval, padded with leading zeros as needed. |
| "@d" | The localized word for 'day' with proper pluralization for the number of whole days in the time interval. | 
| "h", "%h" | The number of whole hours in the time interval that are not counted as part of days. Single-digit hours do not have a leading zero. |
| "hh" | The number of whole hours in the time interval that are not counted as part of days. Single-digit hours have a leading zero. |
| "@h" | The localized word for 'hour' with proper pluralization for the number of whole hours in the time interval. | 
| "m", "%m" | The number of whole minutes in the time interval that are not included as part of hours or days. Single-digit minutes do not have a leading zero. |
| "mm" | The number of whole minutes in the time interval that are not included as part of hours or days. Single-digit minutes have a leading zero. |
| "@m" | The localized word for 'minute' with proper pluralization for the number of whole minutes in the time interval. | 
| "s", "%s" | The number of whole seconds in the time interval that are not included as part of minutes, hours or days. Single-digit seconds do not have a leading zero. |
| "ss" | The number of whole seconds in the time interval that are not included as part of minutes, hours or days. Single-digit seconds have a leading zero. |
| "@s" | The localized word for 'second' with proper pluralization for the number of whole seconds in the time interval. | 
| "f", "%f" | The tenths of a second in a time interval. |
| "ff" | The hundredths of a second in a time interval. |
| "fff" | The milliseconds in a time interval. |
| "ffff" | The ten-thousandths of a second in a time interval. |
| "fffff" | The hundred-thousandths of a second in a time interval. |
| "ffffff" | The millionths of a second in a time interval. |
| "fffffff" | The ten-millionths of a second in a time interval. |
| "F", "%F" | The tenths of a second in a time interval. Nothing is displayed if the digit is zero. 
| "FF" | The hundredths of a second in a time interval. Any fractional trailing zeros or two zero digits are not included. |
| "FFF" | The milliseconds in a time interval. Any fractional trailing zeros are not included. |
| "FFFF" | The ten-thousandths of a second in a time interval. Any fractional trailing zeros are not included. |
| "FFFFF" | The hundred-thousandths of a second in a time interval. Any fractional trailing zeros are not included. |
| "FFFFFF" | The millionths of a second in a time interval. Any fractional trailing zeros are not included. |
| "FFFFFFF" | The ten-millionths of a second in a time interval. Any fractional trailing zeros are not included. |
| "@k" | The localized word for 'millisecond' with proper pluralization for the number of milliseconds in the time interval. | 
| "t", "%t" | The number of total ticks in the time interval. |
| "@t" | The localized word for 'tick' with proper pluralization for the number of ticks in the time interval. | 
| "p<n>" | The decimal number of second. If <n> is omitted, then the fractional portion will be whatever is neccessary to display the entire fraction. If there is no fraction, then only the number of seconds will be returned. If <n> is provided, then the fractional portion will be rounded to 'n' digits. (Example: "p" would display "214.83384" while "p2" would display "214.83" for the same time interval.) |
| "%D", "D<n>" | The decimal number of total days in the time interval. If <n> is omitted, then the fractional portion will be whatever is neccessary to display the entire fraction. If there is no fraction, then only the number of seconds will be returned. If <n> is provided, then the fractional portion will be rounded to 'n' digits. (Example: For a duration of 1 day and 3 hours, "%D" would display "1.125" whereas "D1" would display "1.1".) |
| "%H", "H<n>" | The decimal number of total hours in the time interval. If <n> is omitted, then the fractional portion will be whatever is neccessary to display the entire fraction. If there is no fraction, then only the number of seconds will be returned. If <n> is provided, then the fractional portion will be rounded to 'n' digits. |
| "%M", "M<n>" | The decimal number of total minutes in the time interval. If <n> is omitted, then the fractional portion will be whatever is neccessary to display the entire fraction. If there is no fraction, then only the number of seconds will be returned. If <n> is provided, then the fractional portion will be rounded to 'n' digits. |
| "%S", "S<n>" | The decimal number of total seconds in the time interval. If <n> is omitted, then the fractional portion will be whatever is neccessary to display the entire fraction. If there is no fraction, then only the number of seconds will be returned. If <n> is provided, then the fractional portion will be rounded to 'n' digits. |
| "%K", "K<n>" | The decimal number of total milliseconds in the time interval. If <n> is omitted, then the fractional portion will be whatever is neccessary to display the entire fraction. If there is no fraction, then only the number of seconds will be returned. If <n> is provided, then the fractional portion will be rounded to 'n' digits. |
| ":" | Culture-sensitive time separator. This instructs the parser to look for the locale specific time separator string and instructs the formatter to display that same string. |
| "." | Culture-sensitive decimal separator. This instructs the parser to look for the locale specific decimal number separator string and instructs the formatter to display that same string. |
| "_" | White space indicator. This instructs the parser to allow any whitespace character or characters and instructs the formatter to display a single space. |
| "," | Culture-sensitive list separator. This instructs the parser to look for the locale specific list separator string and instructs the formatter to display that same string if there are list items on both sides of the separator. |