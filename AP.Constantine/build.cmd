dotnet restore
dotnet build --configuratuion release
dotnet lambda package -pl ./AP.Constantine --configuration release --framework netcoreapp3.1 --output-package AP.Constantine.zip