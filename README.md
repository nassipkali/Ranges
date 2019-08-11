[![Codacy Badge](https://api.codacy.com/project/badge/Grade/32e016893f0f4fd286714a6612e47f04)](https://app.codacy.com/app/drakonard/Ranges?utm_source=github.com&utm_medium=referral&utm_content=linksplatform/Ranges&utm_campaign=Badge_Grade_Dashboard)
[![CodeFactor](https://www.codefactor.io/repository/github/linksplatform/ranges/badge)](https://www.codefactor.io/repository/github/linksplatform/ranges)

# [Ranges](https://github.com/linksplatform/Ranges)
LinksPlatform's Platform.Ranges Class Library

This library contains `Range` *struct* with `Minumum` and `Maximum` *fields*. It is possible to create only a valid `Range`, overwise exception is thrown.

Namespace: [Platform.Ranges](https://linksplatform.github.io/Ranges/api/Platform.Ranges.html)

Forked from: [Konard/LinksPlatform/Platform/Platform.Helpers](https://github.com/Konard/LinksPlatform/tree/0c85f236b75e6e3110790008b1a379c03c954501/Platform/Platform.Helpers)

NuGet package: [Platform.Ranges](https://www.nuget.org/packages/Platform.Ranges)

## [Documentation](https://linksplatform.github.io/Ranges/)
* Class [Range\<T\>](https://linksplatform.github.io/Ranges/api/Platform.Ranges.Range-1.html).

[PDF file](https://linksplatform.github.io/Ranges/Platform.Ranges.pdf) with code for e-readers.

## Depend on
* [Platform.Exceptions](https://github.com/linksplatform/Exceptions)

## Mystery files
* [.travis.yml](.travis.yml) - Travis CI build configuration.
* [docfx.json](docfx.json) and [toc.yml](toc.yml) - DocFX build configuration.
* [fmt.sh](fmt.sh) - script for formating `tex` file for generating PDF from it.
* [fmt.py](fmt.py) - script for formating single `.cs` file as a part of `tex` file.
* [Makefile](Makefile) - PDF build configuration.
* [generate-pdf.sh](generate-pdf.sh) - script that generates PDF with code for e-readers.
* [publish-docs.sh](publish-docs.sh) - script that publishes generated documentation and PDF with code for e-readers to `gh-pages` branch.
* [push-nuget.bat](push-nuget.bat) - Windows script for publishing current version of NuGet package.

## Similar packages
### [alansav/range](https://github.com/alansav/range)
`Range` *class* with `Floor` and `Ceiling` *fields*.

### [mnelsonwhite/Range.NET](https://github.com/mnelsonwhite/Range.NET)
`Range` *class* with `Minumum` and `Maximum` *properties*.

### [sdcb/Sdcb.System.Range](https://github.com/sdcb/Sdcb.System.Range)
`Range` *struct* with `Start` and `End` *properties*.
