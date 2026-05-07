# Auto-build watcher: runs build_and_copy.ps1 on file changes
param(
    [string]$Path = "$(Split-Path -Parent $MyInvocation.MyCommand.Path)",
    [int]$DebounceMs = 1500
)
Write-Host "Starting auto-build watcher on $Path"
$patterns = '*.cs','*.csproj','*.config'
$fsw = New-Object System.IO.FileSystemWatcher $Path -Property @{ IncludeSubdirectories = $true; EnableRaisingEvents = $true }
$timer = $null
$sync = [ref]$false
$action = {
    if ($sync.Value) { return }
    $sync.Value = $true
    try {
        if ($timer) { $timer.Stop(); $timer.Dispose() }
        $timer = New-Object Timers.Timer $DebounceMs
        $timer.AutoReset = $false
        $timer.add_Elapsed({
            Write-Host "Change detected, running build_and_copy.ps1..."
            try {
                powershell -NoProfile -ExecutionPolicy Bypass -File "$Path\build_and_copy.ps1"
            } catch {
                Write-Host "Build script failed: $_"
            }
            $sync.Value = $false
        })
        $timer.Start()
    } catch {
        Write-Host "Watcher error: $_"
        $sync.Value = $false
    }
}
Register-ObjectEvent $fsw Changed -SourceIdentifier FileChanged -Action $action | Out-Null
Register-ObjectEvent $fsw Created -SourceIdentifier FileCreated -Action $action | Out-Null
Register-ObjectEvent $fsw Renamed -SourceIdentifier FileRenamed -Action $action | Out-Null
Register-ObjectEvent $fsw Deleted -SourceIdentifier FileDeleted -Action $action | Out-Null
Write-Host "Watcher running. Press Enter to stop."
[Console]::ReadLine() | Out-Null
Unregister-Event -SourceIdentifier FileChanged,FileCreated,FileRenamed,FileDeleted -ErrorAction SilentlyContinue
$fsw.EnableRaisingEvents = $false
$fsw.Dispose()
if ($timer) { $timer.Dispose() }
Write-Host "Watcher stopped."