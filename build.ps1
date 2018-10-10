[xml]$doc = Get-Content .\Freya.Template.nuspec
$version = $doc.package.metadata.version # the version under development, update after a release
$versionSuffix = '-build.0' # manually incremented for local builds

function isVersionTag($tag){
    $v = New-Object Version
    [Version]::TryParse($tag, [ref]$v)
}

if ($env:appveyor){
    $versionSuffix = '-build.' + $env:appveyor_build_number
    if ($env:appveyor_repo_tag -eq 'true' -and (isVersionTag($env:appveyor_repo_tag_name))){
        $version = $env:appveyor_repo_tag_name
        $versionSuffix = ''
    }
    Update-AppveyorBuild -Version "$version$versionSuffix"
}

dotnet --info
nuget.exe pack
dotnet new --install .
    
mkdir testA
pushd testA
dotnet new freya
dotnet restore
dotnet build -c Release
popd

mkdir testB
pushd testB
dotnet new freya -c hopac -f kestrel
dotnet restore
dotnet build -c Release
popd
