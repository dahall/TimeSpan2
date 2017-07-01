**Project Description**
Library to extend the functionality of the TimeSpan structure to be comparable, serializable, and convertible. It also supports localized string formatting and parsing so a TimeSpan can be represented by something like "3 days, 2 hours, 19 minutes" instead of "3:02:19:00".

There are three public classes of note:

**TimeSpan2** is a wrapper around the existing TimeSpan structure that adds serialization, comparability, and convertibility. It can be used anywhere a TimeSpan is used.

**TimeSpanFormatInfo** is an IFormatProvider for TimeSpan instances and provides a richer set of output formats. It works similarly to DateTimeFormatInfo. If you use the TimeSpan2 structure, you can access the parsing and output functionality directly from the structure's Parse and ToString methods. A list of format strings can be found [here](TimeSpanFormatInfo) and in the inline documentation for TimeSpanFormatInfo.

**TimeSpanPicker** is a editable ComboBox that exposes a localized list of TimeSpan instances and allows for text entry.

This project has partial translations for English, Spanish, French, Italian, Russian, Chinese, and German. If anyone would like to provide translations for other languages, or better ones for those in the project, please post them in the Discussions area. A description of the translations needed for each localization are [here](LocalizationStrings).