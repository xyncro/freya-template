# Freya Templates

## Installing the template

This template can be installed into the dotnet CLI template cache by using the
following command:

    dotnet new --install Freya.Template::*

If you want to install a specific version of the Freya templates, you can do so
by replacing `*` with the version you wish to install.

## Using the template

Once installed, a new Freya project can be created by using:

    dotnet new freya

Additional options can be specified to switch between `FSharp.Core.Async` and
`Hopac.Job` and to configure which garbage collector should be used. These
options can be exposed using `dotnet new freya --help`.


    Freya on Kestrel (F#)
    Author: Marcus Griep
    Options:
    -f|--freyaCore  Chooses the underlying concurrency construct
                        async    - Use Async from FSharp.Core
                        hopac    - Use Job from Hopac
                    Default: async

    -s|--serverGc   Use the server garbage collector
                    bool - Optional
                    Default: true

## After creating a project

After creating a new Freya project, you will still need to restore before you
can build:

    dotnet restore
    dotnet build

To run the program, use `dotnet run`. The server will respond on
`http://localhost:5000`.