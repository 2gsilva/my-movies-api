FROM mcr.microsoft.com/dotnet/aspnet:7.0
LABEL version="1.0" maintainer="Guilherme S. de Azevedo"
WORKDIR /app
COPY /home/runner/work/my-movies-api/my-movies-api/my-movies-api/bin/Release/net7.0/ .
ENTRYPOINT ["dotnet", "my-movies-api.dll"]