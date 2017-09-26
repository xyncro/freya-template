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
`Hopac.Job` and to configure which garbage collector should be used. By default,
the template uses [Suave](https://suave.io) as the host web framework. These
options can be exposed using `dotnet new freya --help`.


    Freya on Kestrel (F#)
    Author: Marcus Griep
    Options:
    -c|--concurrency  Chooses the underlying concurrency construct
                        async    - Use Async from FSharp.Core
                        hopac    - Use Job from Hopac
                    Default: async

    -f|--framework
                        suave      - Uses Suave as the underlying I/O framework
                        kestrel    - Uses Kestrel as the underlying I/O framework
                    Default: suave

    -s|--serverGc   Use the server garbage collector
                    bool - Optional
                    Default: true

## After creating a project

After creating a new Freya project, you are ready to run the project:

    dotnet run

Note that on .NET Core 1.1, you may need to run `dotnet restore` prior to
the run command.

The server will respond on `http://localhost:5000` for Kestrel projects and
`http://localhost:8080` for Suave projects. In both cases, a single "Hello,
World!" endpoint is exposed on the `/hello/{name}` path.