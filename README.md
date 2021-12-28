# TimeSpan2
> Library extending the .NET TimeSpan structure to be comparable, serializable, and convertible, and to support localized string formatting and parsing.

There are three public classes of note:
* `TimeSpan2` is a wrapper around the existing `TimeSpan` structure that adds serialization, comparability, and convertibility. It can be used anywhere a TimeSpan is used.
* `TimeSpanFormatInfo` is an `IFormatProvider` for TimeSpan instances and provides a richer set of output formats. It works similarly to DateTimeFormatInfo. If you use the TimeSpan2 structure, you can access the parsing and output functionality directly from the structure's Parse and ToString methods. A list of format strings can be found here and in the inline documentation for `TimeSpanFormatInfo`.
* `TimeSpanPicker` is a editable ComboBox that exposes a localized list of TimeSpan instances and allows for text entry.

This project has translations for English, Spanish, French, Italian, Russian, Chinese, and German. If anyone would like to provide translations for other languages, or better ones for those in the project, please post them in the Discussions area. A description of the translations needed for each localization are here.

## Installation

This is a standard Visual Studio 2022 solution containing the library as a project and a test harness as another project.

It is available for inclusion into .NET projects via [NuGet](https://www.nuget.org/packages/TimeSpan2/).

## Documentation

For sample code, see the [Documentation](docs\Documentation.md).

## Release History

* 2.4.0 - Added support for .NET 6.0
* 2.3.0 - Added support for .NET Core 3.0 and 3.1
* 2.1.6 - Added Dutch and fixed a bug
* 2.1.5 - Added Danish
* 2.1.4 - Added .NET version builds
* 2.1.1 - Minor bug fixes and new languages added
* Since 2.0.1 - Added .NET 2.0 and 4.0 assemblies and build, improved performance, added support for IXmlSerialization, improved error checking.

Not backwards compatible with 1.x library. Aligned and expanded upon functionality in .NET 4.0. Provides TimeSpan2FormatInfo which is culturally aware. It now provides an advanced syntax for formatting and parsing. TimeSpan2 is now functionally equivalent to the 4.0 TimeSpan. See inline Documentation for more detail on syntax. Significant work to enrich design-time experience with TimeSpanPicker.

## Contributing

1. Fork it (<https://github.com/yourname/yourproject/fork>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request
