FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY bin/Debug/net5.0/ /api
WORKDIR /api
ENTRYPOINT ["dotnet", "api.dll"]