The {{TimeSpanFormatInfo}} class, which can be used with both {{TimeSpan}} and {{TimeSpan2}} objects, has a rich syntax for defining how strings are parsed and how output strings are formatted.

**Formatting**

The following table lists the standard {{TimeSpan}} format patterns associated with {{TimeSpanFormatInfo}} properties.

||Format pattern||Associated property/description||Example output||
|c|Constant (invariant) format. This specifier is not culture-sensitive. It takes the form {{[-](-)[d’.’](d’.’)hh’:’mm’:’ss[‘.’fffffff](‘.’fffffff)}}.|8.04:15:12.0401200|
|f|General word format|8 days, 4 hours, 15 minutes, 12 seconds, 40 milliseconds|
|g|General short format.This specifier outputs only what is needed. It is culture-sensitive and takes the form {{[-](-)[d’:’](d’_’)h’:’mm’:’ss[.FFFFFFF](.FFFFFFF)}}.|8.4:15:12.04012|
|G|General long format.This specifier always outputs days and seven fractional digits. It is culture-sensitive and takes the form {{[-](-)d’:’hh’:’mm’:’ss.fffffff}}.|8.04:15:12.0401200|
|j|JIRA duration format. This specifier outputs weeks, days, hours, minutes and seconds in the style defined by JIRA. It takes the form {{[w'w'](w'w') [d'd'](d'd') [h'h'](h'h') [m'm'](m'm') [s's'](s's')}}.|1w 1d 4h 15m 12s|
|x|ISO 8601 pattern for time intervals. See [http://www.iso.org/iso/date_and_time_format](http://www.iso.org/iso/date_and_time_format) for more information.|P8DT4H15M12.04S|

The following table lists the custom TimeSpan format patterns and their behavior.


||Format specifier||Description||Examples||
|"d" or "%d"|The number of whole days in the time interval.|8.04:15:12.0401200 -> 8|
|"dd" - "dddddddd"|The number of whole days in the time interval, padded with leading zeros as needed.|8.04:15:12.0401200 (ddd) -> 008|
|"D", "%D" or {""D[n](n)""}|The total number of days expressed in whole and fractional days. Placing an integer after the letter will limit the number of decimal places shown.|8.04:15:12.0401200 (%D) -> 8.17722268657407; 8.04:15:12.0400000 (D2) -> 8.18|
|"%f"|The tenths of a second in the time interval.|8.04:15:12.0401200 -> 0|
|"ff"|The hundredths of a second in the time interval.|8.04:15:12.0401200 -> 04|
|"fff"|The milliseconds in the time interval.|8.04:15:12.0401200 -> 040|
|"ffff"|The ten thousandths of a second in the time interval.|8.04:15:12.0401200 -> 0401|
|"fffff"|The hundred thousandths of a second in the time interval.|8.04:15:12.0401200 -> 04012|
|"ffffff"|The millionths of a second in the time interval.|8.04:15:12.0401200 -> 040120|
|"fffffff"|The ten millionths of a second in the time interval.|8.04:15:12.0401200 -> 0401200|
|"%F"|If non-zero, the tenths of a second in the time interval.|8.04:15:12.0401200 -> (no output)|
|"FF"|If non-zero, the hundredths of a second in the time interval.|8.04:15:12.0401200 -> 04|
|"FFF"|If non-zero, the milliseconds in the time interval.|8.04:15:12.0401200 -> 040|
|"FFFF"|If non-zero, the ten thousandths of a second in the time interval.|8.04:15:12.0401200 -> 0401|
|"FFFFF"|If non-zero, the hundred thousandths of a second in the time interval.|8.04:15:12.0401200 -> 04012|
|"FFFFFF"|If non-zero, the millionths of a second in the time interval.|8.04:15:12.0401200 -> 04012|
|"FFFFFFF"|If non-zero, the ten millionths of a second in the time interval.|8.04:15:12.0401200 -> 04012|
|"h" or "%h"|The number of whole hours in the time interval.|8.04:15:12.0401200 -> 4|
|"hh" - "hhhhhhhh"|The number of whole hours in the time interval, padded with leading zeros as needed.|8.04:15:12.0401200 (hhh) -> 004|
|"H", "%H" or {""H[n](n)""}|The total number of hours expressed in whole and fractional hours. Placing an integer after the letter will limit the number of decimal places shown.|8.04:15:12.0401200 (%H) -> 196.253344477778; 8.04:15:12.0401200 (H2) -> 196.25|
|"k" or "%k"|The number of whole milliseconds in the time interval.|8.04:15:12.0401200 -> 40|
|"kk" - "kkkkkkkk"|The number of whole milliseconds in the time interval, padded with leading zeros as needed.|8.04:15:12.0401200 (kkk) -> 040|
|"K", "%K" or {""K[n](n)""}|The total number of milliseconds expressed in whole and fractional hours. Placing an integer after the letter will limit the number of decimal places shown.|8.04:15:12.0401200 (%K) -> 706512040.12; 8.04:15:12.0401200 (K2) -> 706512040.12|
|"m" or "%m"|The number of whole minutes in the time interval.|8.04:15:12.0401200 -> 15|
|"mm" - "mmmmmmmm"|The number of whole minutes in the time interval, padded with leading zeros as needed.|8.04:15:12.0401200 (mmm) -> 015|
|"M", "%M" or {""M[n](n)""}|The total number of minutes expressed in whole and fractional hours. Placing an integer after the letter will limit the number of decimal places shown.|8.04:15:12.0401200 (%M) -> 11775.2006666667; 8.04:15:12.0401200 (M2) -> 11775.2|
|"r" or "%r"|The number of days in any partial week in the time interval.|8.04:15:12.0401200 -> 1|
|"rr" - "rrrrrrrr"|The number of days in any partial week in the time interval, padded with leading zeros as needed.|8.04:15:12.0401200 (rrr) -> 001|
|"s" or "%s"|The number of whole seconds in the time interval.|8.04:15:12.0401200 -> 12|
|"ss" - "ssssssss"|The number of whole seconds in the time interval, padded with leading zeros as needed.|8.04:15:12.0401200 (sss) -> 012|
|"S", "%S" or {""S[n](n)""}|The total number of seconds expressed in whole and fractional hours. Placing an integer after the letter will limit the number of decimal places shown.|8.04:15:12.0401200 (%S) -> 706512.04012; 8.04:15:12.0400000 (S2) -> 706512.04|
|"t" or "%t"|The number of ticks (equal to 100 nanoseconds) in the time interval.|8.04:15:12.0401200 -> 7065120401200|
|"tt" - "tttttttt"|The number of ticks in the time interval, padded with leading zeros as needed.|00:00:00.0050000 (tttttt) -> 050000|
|"w" or "%w"|The number of whole weeks in the time interval.|8.04:15:12.0401200 -> 1|
|"ww" - "wwwwwwww"|The number of whole weeks in the time interval, padded with leading zeros as needed.|8.04:15:12.0401200 (www) -> 001|
|"string", 'string'|Literal string delimiter.|8.04:15:12.0401200 ("Days: "%d) -> Days: 8|
|'\'|The escape character.|8.04:15:12.0401200 (%d\d) -> 8d|
|'_'|White space.|8.04:15:12.0401200 (%d_%h) -> 8 4|
|':'|The culture-specific time separator.|8.04:15:12.0401200 (%h:%m) -> 4:15|
|'.'|The culture-specific number decimal separator.|8.04:15:12.0401200 (%d.%h) -> 8.4|
|{""[<format specifier(s)>](_format-specifier(s)_)""}|Grouping of specifiers that, if entire grouping results in a zero, will not be displayed|8.0:15:12.0401200 ({"[%h:](%h_)[%m](%m)"}) -> 15|

**Parsing**
_forthcoming_