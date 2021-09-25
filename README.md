# Extensible calculator

This is sample project that shows how to create application with extensions
on net6.0.

There's 2 main directories - *Calculator* and *Extensions*.
Each one shows own development perspective.

* *Calculator* shows how application developers can extend application and provide SDK for extensions writers.
* *Extensions* show how extension writers see extension writing process.

Almost every file have comments that explain what's done right here.

Main purpose of this repo is to show how you can create single file that can be
transferred to extension developer who can start extending your application
without writing boilerplate code

## Advantages

### Application developer

* Highly customizable
* No weird hacks is required
* Include new libraries with `<IncludeInSdk>true</IncludeInSdk>`
* Each build produces `.nupkg` file that can be shared the way you want

### Extensions developer

* Single `.nupkg` have everything needed to create extensions
* Minimal project file - only set Project's SDK and you're ready to go

    ```xml
    <Project Sdk="Calculator.Sdk/1.0.0" />
    ```

    *Decades of evolution to single line project file*

### Everyone

* Easy to maintain dependencies. Your dependencies won't interfere with others
* Easy to build - no need for third-party build tools. Everything is resolved by MSBuild!
* DLL hell & Version hell is no more!

---

## Build

You need net6.0 sdk.

1. Go to `Calculator` folder and type `dotnet build`
1. Go to `Extensions` folder and type `dotnet build`

## Execution

1. Create folder in `Calculator/Calculator.Program/bin/debug/net6.0/` called `Extensions`
1. Compile `Extensions/Addition`
1. Copy output to directory from `1`
1. Run `Calculator.Program` app
