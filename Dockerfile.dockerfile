FROM mcr.microsoft.com/dotnet/aspnet:7.0
LABEL version="1.0" maintainer="Guilherme S. de Azevedo"
WORKDIR /app
COPY my-movie-api-artifact dist/
ENTRYPOINT ["dotnet", "my-movies-api.dll"]
