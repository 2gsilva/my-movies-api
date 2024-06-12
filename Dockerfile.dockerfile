FROM mcr.microsoft.com/dotnet/aspnet:7.0
LABEL version="1.0" maintainer="Guilherme S. de Azevedo"
COPY dist .
WORKDIR /app.
ENTRYPOINT ["dotnet", "my-movies-api.dll"]
