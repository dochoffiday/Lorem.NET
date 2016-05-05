Write-Host "Patching project.json version..."
(Get-Content $PSScriptRoot\Lorem.DNX.NET\project.ci.json).replace('$version$', $Env:APPVEYOR_BUILD_VERSION) | Set-Content $PSScriptRoot\Lorem.DNX.NET\project.json
(Get-Content $PSScriptRoot\Lorem.Universal.NET\project.ci.json).replace('$version$', $Env:APPVEYOR_BUILD_VERSION) | Set-Content $PSScriptRoot\Lorem.Universal.NET\project.json
Write-Host "Updated project.json to use version $($Env:APPVEYOR_BUILD_VERSION)"

dnvm upgrade

dnu restore
nuget restore