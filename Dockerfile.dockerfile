FROM mcr.microsoft.com/dotnet/aspnet:7.0
LABEL version="1.0" maintainer="Guilherme S. de Azevedo"
WORKDIR /app
RUN cd /dist
COPY . . 
ENTRYPOINT ["dotnet", "my-movies-api.dll"]
