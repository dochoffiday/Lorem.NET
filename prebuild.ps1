Write-Host "Patching project.json version..."
(Get-Content $PSScriptRoot\Lorem.DNX.NET\project.ci.json).replace('$version$', $Env:APPVEYOR_BUILD_VERSION) | Set-Content $PSScriptRoot\Lorem.DNX.NET\project.json
(Get-Content $PSScriptRoot\Lorem.Universal.NET\project.ci.json).replace('$version$', $Env:APPVEYOR_BUILD_VERSION) | Set-Content $PSScriptRoot\Lorem.Universal.NET\project.json
(Get-Content $PSScriptRoot\Lorem.Universal.NET\Lorem.Universal.NET.ci.nuspec).replace('$version$', $Env:APPVEYOR_BUILD_VERSION) | Set-Content $PSScriptRoot\Lorem.Universal.NET\Lorem.Universal.NET.nuspec
(Get-Content $PSScriptRoot\Lorem.PCL.NET\Lorem.PCL.NET.ci.nuspec).replace('$version$', $Env:APPVEYOR_BUILD_VERSION) | Set-Content $PSScriptRoot\Lorem.PCL.NET\Lorem.PCL.NET.nuspec
Write-Host "Updated project.json to use version $($Env:APPVEYOR_BUILD_VERSION)"

dotnet restore
nuget restore