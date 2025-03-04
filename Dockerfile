FROM mcr.microsoft.com/dotnet/aspnet:8.0
LABEL version="2.0" maintainer="Guilherme S. de Azevedo"
WORKDIR /app
COPY . . 
ENTRYPOINT ["dotnet", "my-movies-api.presentation.dll"]
