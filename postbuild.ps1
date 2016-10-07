cd Lorem.DNX.Net

dotnet pack --configuration $Env:CONFIGURATION 

cd ..\Lorem.Universal.Net

nuget pack Lorem.Universal.Net.csproj -Prop Configuration=$Env:CONFIGURATION 

cd ..\Lorem.PCL.Net

nuget pack Lorem.PCL.Net.csproj -Prop Configuration=$Env:CONFIGURATION 
