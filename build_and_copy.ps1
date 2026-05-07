param(
    [string]$Solution = "SpawnEditor2.sln",
    [string]$Configuration = "Debug",
    [string]$TransferServerProject = "TransferServer\TransferServer.csproj"
)
$root = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $root
Write-Host "Building solution: $Solution (Configuration: $Configuration)"
$dotnet = Get-Command dotnet -ErrorAction SilentlyContinue
if ($dotnet) {
    dotnet build $Solution -c $Configuration
    $rc = $LASTEXITCODE
    if ($rc -eq 0 -and (Test-Path $TransferServerProject)) {
        Write-Host "Building shared server DLL: $TransferServerProject (Configuration: $Configuration)"
        dotnet build $TransferServerProject -c $Configuration
        $rc = $LASTEXITCODE
    }
} else {
    Write-Host "dotnet not found in PATH. Trying msbuild..."
    $msbuild = Get-Command msbuild -ErrorAction SilentlyContinue
    if ($msbuild) {
        msbuild $Solution /t:Rebuild /p:Configuration=$Configuration
        $rc = $LASTEXITCODE
        if ($rc -eq 0 -and (Test-Path $TransferServerProject)) {
            Write-Host "Building shared server DLL: $TransferServerProject (Configuration: $Configuration)"
            msbuild $TransferServerProject /t:Rebuild /p:Configuration=$Configuration
            $rc = $LASTEXITCODE
        }
    } else {
        Write-Host "ERROR: Neither dotnet nor msbuild were found in PATH. Install the .NET SDK or add msbuild to PATH."
        exit 1
    }
}
if ($rc -ne 0) {
    Write-Host "Build failed with exit code $rc"
    exit $rc
}

$distClientDir = Join-Path $root "dist\Client"
$distServerDllDir = Join-Path $root "dist\Server\DLL"

if (Test-Path $distClientDir) {
    Get-ChildItem -Path $distClientDir -Filter *.pdb -File | Remove-Item -Force
}

if (Test-Path $distServerDllDir) {
    Get-ChildItem -Path $distServerDllDir -Filter *.pdb -File | Remove-Item -Force
}

Write-Host "Build succeeded. Listing dist\Client contents:"
Get-ChildItem -Path $distClientDir | Select-Object Name, LastWriteTime, Length | Format-List
if (Test-Path $distServerDllDir) {
    Write-Host "Build succeeded. Listing dist\Server\DLL contents:"
    Get-ChildItem -Path $distServerDllDir | Select-Object Name, LastWriteTime, Length | Format-List
}
exit 0
