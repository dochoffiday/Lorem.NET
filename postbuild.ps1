cd Lorem.DNX.Net

dnu pack --configuration $Env:CONFIGURATION 

cd ..\Lorem.Universal.Net

nuget pack Lorem.Universal.Net.csproj -Prop Configuration=$Env:CONFIGURATION 