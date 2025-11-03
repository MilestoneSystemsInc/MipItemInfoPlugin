param(
    [Parameter()]
    [string]
    $Version
)

& dotnet tool restore

$null = New-Item $PSScriptRoot\output, .cache\ -ItemType Directory -Force
Get-ChildItem $PSScriptRoot\output | Remove-Item -Recurse -Force

if (!$PSCmdlet.MyInvocation.BoundParameters.ContainsKey('Version')) {
    $Version = (dotnet nbgv get-version -f json | ConvertFrom-Json).Version
}

Write-Host "Building MipItemInfoPlugin.$Version.msi"

& msbuild Setup/setup.wixproj /t:Rebuild /restore:True /p:Configuration=Release /p:Platform=x64 /p:BuildVersion=$Version

if (!$?) {
    throw "MSBuild exited with code $LASTEXITCODE"
}
Write-Host "Build completed successfully." -ForegroundColor Green

[pscustomobject]@{
    Version   = $Version
    Artifacts = Resolve-Path $PSScriptRoot\output\MipItemInfoPlugin\
    Installer = Resolve-Path $PSScriptRoot\output\Setup\en-US\
}